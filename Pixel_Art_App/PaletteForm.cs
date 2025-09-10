namespace ITnetwork_Pixel_Art_Improved
{
    public partial class PaletteForm : Form
    {
        public PictureBox _pictureBox;
        public event MouseEventHandler SelectedColorChanged;
        public PaletteForm()
        {
            InitializeComponent();
            pictureBoxBrushColor.BackColor = Color.Black;
        }

        private void palettePictureBoxBrushColor_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender == null)
            {
                MessageBox.Show("Error - sender is null, somehow.");
                return;
            }

            if ((e.Button == MouseButtons.Left) && (_pictureBox == sender as PictureBox))
                return;

            if (_pictureBox != null)
                _pictureBox.BorderStyle = BorderStyle.None;

            _pictureBox = sender as PictureBox;
            _pictureBox.BorderStyle = BorderStyle.Fixed3D;

            if (SelectedColorChanged != null)
                SelectedColorChanged(sender, e);
        }
    }
}
