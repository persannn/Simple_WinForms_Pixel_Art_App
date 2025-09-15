using System.Drawing.Imaging;

namespace ITnetwork_Pixel_Art_Improved
{
    public partial class MainForm : Form
    {
        private PaletteForm _palette;
        private Point? mouseDownEventLocation;
        private bool isMouseDown;
        public static int pixelProjectionSizeMin = 1;
        public static int pixelProjectionSizeMax = 200;
        protected string _filePath = "";
        /// <summary>
        /// The actual pixel matrix displayed in the PictureBox that the user will be drawing on.
        /// </summary>
        public MyCanvas _canvas;
        /// <summary>
        /// The BackColor property represents the color currently selected by the user.
        /// </summary>
        public Color selectedColor;
        public MainForm()
        {
            InitializeComponent();

            selectedColor = Color.Black;

            _canvas = new MyCanvas(20, 20, pictureBoxCanvas.Width, pictureBoxCanvas.Height);
            _canvas.MAX_SIZE = new Size(pictureBoxCanvas.MaximumSize.Width, pictureBoxCanvas.MaximumSize.Height);
            pictureBoxCanvas.Invalidate();

            zoomValueLabel.Text = _canvas.Zoom.ToString();

            _palette = new PaletteForm();
            _palette.SelectedColorChanged += pictureBoxBrushColor_MouseClick;
            _palette.Show();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            pictureBoxCanvas.Width = ClientSize.Width;
            pictureBoxCanvas.Height = ClientSize.Height - 40;
            pictureBoxCanvas.Location = new Point((ClientRectangle.Width / 2) - (pictureBoxCanvas.ClientRectangle.Width / 2),
                                                (ClientRectangle.Height / 2) - (pictureBoxCanvas.ClientRectangle.Height / 2));
            pictureBoxCanvas.Invalidate();
        }

        private void pictureBoxBrushColor_MouseClick(object sender, MouseEventArgs e)
        {
            // If the user right-clicks the color square, they get to change the color.
            if (e.Button == MouseButtons.Right)
            {
                ColorDialog myDialog = new ColorDialog();
                myDialog.FullOpen = true;
                myDialog.ShowHelp = true;
                myDialog.Color = selectedColor;

                if (myDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedColor = (sender as PictureBox).BackColor;
                    selectedColor = myDialog.Color;
                }
            }

            selectedColor = (sender as PictureBox).BackColor;
        }

        #region PictureBoxCanvas

        private void pictureBoxCanvas_Validated(object sender, EventArgs e)
        {
            zoomValueLabel.Text = _canvas.Zoom.ToString();
        }

        private void pictureBoxCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (_canvas.GetPixel(e.X, e.Y).Color == selectedColor)
                return;
            Rectangle? pixelBorders = _canvas.GetPixelBorders(e);
            if (pixelBorders == null)
                return;
            _canvas.Click(e.X, e.Y, selectedColor);
            pictureBoxCanvas.Invalidate((Rectangle)pixelBorders);
        }

        private void pictureBoxCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Pixel cursorPos = _canvas.GetPixel(e.X, e.Y);
            Rectangle? pixelBorders = _canvas.GetPixelBorders(e);

            if (pixelBorders == null)
            {
                if (mouseDownEventLocation != null)
                {
                    Point offset = new Point(e.X - mouseDownEventLocation.Value.X, e.Y - mouseDownEventLocation.Value.Y);
                    _canvas.TopLeftCorner.Offset(offset);
                    mouseDownEventLocation = e.Location;
                    pictureBoxCanvas.Invalidate();
                    return;
                }
                return;
            }

            labelXValue.Text = cursorPos.X.ToString();
            labelYValue.Text = (_canvas.ImageBitmap.Height - 1 - cursorPos.Y).ToString();

            if (isMouseDown && mouseDownEventLocation == null)
            {
                if (cursorPos.Color != selectedColor)
                {
                    _canvas.Click(e.X, e.Y, selectedColor);
                    pictureBoxCanvas.Invalidate((Rectangle)pixelBorders);
                }
            }
        }

        private void pictureBoxCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            if (_canvas.GetPixelBorders(e) == null)
            {
                mouseDownEventLocation = e.Location;
            }
        }

        private void pictureBoxCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            mouseDownEventLocation = null;
        }

        private void pictureBoxCanvas_Paint(object sender, PaintEventArgs e)
        {
            _canvas.Paint(e.Graphics, new Size(pictureBoxCanvas.Width, pictureBoxCanvas.Height));
        }

        private void pictureBoxCanvas_SizeChanged(object sender, EventArgs e)
        {
            pictureBoxCanvas.Invalidate();
        }

        #endregion

        private void Clear(object sender, EventArgs e)
        {
            _canvas.Clear();
            pictureBoxCanvas.Invalidate();
        }

        private void New(object sender, EventArgs e)
        {
            NewProjectForm formNew = new NewProjectForm(_canvas, gridCheckBoxStripMenuItem.Checked);
            formNew.ShowDialog();

            if (formNew.DialogResult == DialogResult.OK)
            {
                _canvas = formNew._canvas;
                _canvas.Clear();
                pictureBoxCanvas.Invalidate();
            }
        }

        private void CheckBoxMatrixChanged(object sender, EventArgs e)
        {
            _canvas.IsMatrixVisible = gridCheckBoxStripMenuItem.Checked;
            pictureBoxCanvas.Invalidate();
        }

        private void Open(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "\"c:\\\\\"";
                openFileDialog.Filter = "Image Files(*.png;*.jpeg;*.bmp)|*.png;*.jpeg;.bmp;";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _filePath = openFileDialog.FileName;
                    Bitmap bitmap = new Bitmap(_filePath);

                    Rectangle rect = new Rectangle(new Point(0, 0), bitmap.Size);
                    bitmap = bitmap.Clone(rect, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    _canvas = new MyCanvas(pictureBoxCanvas.MaximumSize, pictureBoxCanvas.Size, bitmap);

                    bitmap.Dispose();
                    pictureBoxCanvas.Invalidate();
                }
            }
        }

        private void SaveFileAs(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream myFileStream = File.Create(saveFileDialog.FileName))
                {
                    switch (saveFileDialog.FilterIndex)
                    {
                        // Save as Bitmap
                        case 1:
                            {
                                _canvas.SaveImageAs(myFileStream, ImageFormat.Bmp);
                                break;
                            }
                        // Save as JPEG
                        case 2:
                            {
                                _canvas.SaveImageAs(myFileStream, ImageFormat.Jpeg);
                                break;
                            }
                        // Save as PNG
                        case 3:
                            {
                                _canvas.SaveImageAs(myFileStream, ImageFormat.Png);
                                break;
                            }
                    }
                }
            }
        }
        /// <summary>
        /// Opens a new PaletteForm if the old one is disposed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paletteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_palette.IsDisposed)
            {
                return;
            }
            _palette = new PaletteForm();
            _palette.SelectedColorChanged += pictureBoxBrushColor_MouseClick;
            _palette.Show();
        }

        private void MouseWheeelScrolled(object sender, MouseEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
            {
                Point offset = new Point(0, (e.Delta / 120) * _canvas.PixelSize * 6);
                _canvas.TopLeftCorner.Offset(offset);
                pictureBoxCanvas.Invalidate();
                return;
            }
            double zoom = _canvas.Zoom;
            if (_canvas.PixelSize * (zoom * Math.Pow(1.1, e.Delta / 120)) < pixelProjectionSizeMin)
            {
                zoom = pixelProjectionSizeMin / _canvas.PixelSize;
            }
            else if (_canvas.PixelSize * (zoom * Math.Pow(1.1, e.Delta / 120)) > pixelProjectionSizeMax)
            {
                zoom = pixelProjectionSizeMax / _canvas.PixelSize;
            }
            else zoom = zoom * Math.Pow(1.1, e.Delta / 120);
            _canvas.Zoom = zoom;
            _canvas.Focus = new Point(e.X, e.Y);
            pictureBoxCanvas.Invalidate();
        }
    }
}
