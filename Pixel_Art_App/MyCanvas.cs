using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ITnetwork_Pixel_Art_Improved
{
    /// <summary>
    /// Class that draws an image on a drawing surface.
    /// </summary>
    public class MyCanvas
    {
        /// <summary>
        /// Point in the PictureBox that represents the top left corner of the canvas.
        /// </summary>
        public Point TopLeftCorner;
        /// <summary>
        /// Point in the PictureBox that the user wants to zoom in/out.
        /// </summary>
        public Point Focus
        {
            get
            {
                return _focus;
            }
            set
            {
                _focus = value;
            }
        }
        private Point _focus;
        /// <summary>
        /// Array of all pixels in the image.
        /// </summary>
        public Bitmap ImageBitmap { get; set; }
        /// <summary>
        /// Points to the locked BitmapData.
        /// </summary>
        private BitmapData _imageBitmapData;
        /// <summary>
        /// Bitmap data converted into an array of bytes.
        /// </summary>
        private byte[] _imageData;
        /// <summary>
        /// Maximum width and height of the PictureBox.
        /// </summary>
        public Size MAX_SIZE { get; set; }
        /// <summary>
        /// Current size of the PictureBox.
        /// </summary>
        public Size CurrentSize { get; set; }
        /// <summary>
        /// The size of the grid Canvas will try to draw onto the PictureBox.
        /// </summary>
        public Size ProjectionSize
        {
            get
            {
                projectionSize = new Size((int)(ImageBitmap.Width * PixelSize * Zoom), (int)(ImageBitmap.Height * PixelSize * Zoom));
                return projectionSize;
            }
        }
        public Size projectionSize;
        /// <summary>
        /// Size of a single pixel.
        /// </summary>
        public int PixelSize { get; set; }
        /// <summary>
        /// How much the user is zoomed in on the canvas.
        /// </summary>
        public double Zoom
        {
            get { return zoom; }
            set
            {
                zoom = value;
                Size newProjectionSize = ProjectionSize;
                //if (newProjectionSize.Width > MAX_SIZE.Width || newProjectionSize.Height > MAX_SIZE.Height)
                //    zoom = zoom * Math.Min((MAX_SIZE.Width / newProjectionSize.Width), (MAX_SIZE.Height / newProjectionSize.Height));
                if (zoom < 0.2)
                    zoom = 0.2f;
            }
        }
        private double zoom = 1;
        /// <summary>
        /// Determines whether the borders between pixels are visible.
        /// </summary>
        public bool IsMatrixVisible { get; set; }

        #region Constructors

        /// <summary>
        /// Constructor that takes 4 ints as parameters.
        /// </summary>
        /// <param name="gridWidth">Number of pixels along the x-axis.</param>
        /// <param name="gridHeight">Number of pixels along the y-axis.</param>
        /// <param name="maxWidth">Maximum width of the PictureBox.</param>
        /// <param name="maxHeight">Maximum height of the PictureBox.</param>
        /// <param name="maxPixelSize">int that sets the maximum PixelSize.</param>
        /// <param name="zoom">How much the user is zoomed in on the canvas.</param>
        /// <param name="isMatrixVisible">bool that specifies whether the pixel matrix borders should be drawn.</param>
        public MyCanvas(int gridWidth, int gridHeight, int currentWidth, int currentHeight, int maxWidth = 20000, int maxHeight = 20000, int maxPixelSize = 16, float zoom = 1, bool isMatrixVisible = false)
        {
            MAX_SIZE = new Size(maxWidth, maxHeight);
            CurrentSize = new Size(currentWidth, currentHeight);
            PixelSize = maxPixelSize;
            ImageBitmap = new Bitmap(gridWidth, gridHeight, PixelFormat.Format32bppArgb);
            _imageData = BitmapToArray(ImageBitmap);
            Zoom = zoom;
            IsMatrixVisible = isMatrixVisible;
            Resize(CurrentSize);
            Clear();
        }
        /// <summary>
        /// Constructor that takes two ints and a vector as parameters.
        /// </summary>
        /// <param name="gridWidth">Number of pixels along the x-axis.</param>
        /// <param name="gridHeight">Number of pixels along the y-axis.</param>
        /// <param name="maxSize">Maximum width and height of the resulting canvas.</param>
        /// <param name="zoom">How much the user is zoomed in on the canvas.</param>
        /// <param name="isMatrixVisible">bool that specifies whether the pixel matrix borders should be drawn.</param>
        public MyCanvas(int gridWidth, int gridHeight, Size currentSize, Size maxSize, float zoom = 1, bool isMatrixVisible = false)
        {
            MAX_SIZE = maxSize;
            CurrentSize = currentSize;
            PixelSize = 16;
            ImageBitmap = new Bitmap(gridWidth, gridHeight, PixelFormat.Format32bppArgb);
            _imageData = BitmapToArray(ImageBitmap);
            Zoom = zoom;
            IsMatrixVisible = isMatrixVisible;
            Resize(CurrentSize);
            Clear();
        }
        /// <summary>
        /// Creates a Canvas based on a Bitmap.
        /// </summary>
        /// <param name="maxSize">Maximum width and height of the resulting canvas.</param>
        /// <param name="bitmap">Bitmap containing the image to be displayed.</param>
        /// <param name="maxPixelSize">The maximum size of a single Pixel.</param>
        /// <param name="zoom">How much the user is zoomed in on the canvas.</param>
        /// <param name="isMatrixVisible">bool that specifies whether the pixel matrix borders should be drawn.</param>
        public MyCanvas(Size maxSize, Size currentSize, Bitmap bitmap, int maxPixelSize = 16, float zoom = 1, bool isMatrixVisible = false)
        {
            MAX_SIZE = maxSize;
            CurrentSize = currentSize;
            ImageBitmap = (Bitmap) bitmap.Clone();
            _imageData = BitmapToArray(ImageBitmap);
            PixelSize = maxPixelSize;
            IsMatrixVisible = isMatrixVisible;
            Resize(CurrentSize);
        }

        #endregion

        /// <summary>
        /// Draws the picture onto the PictureBox.
        /// </summary>
        /// <param name="g">Graphics drawing surface.</param>
        /// <param name="newSize">Size of the PictureBox.</param>
        /// <param name="focus">Point on the PictureBox that should stay static before and after zooming.</param>
        public void Paint(Graphics g, Size newSize)
        {
            Pixel focusPixel = new Pixel((Focus.X - TopLeftCorner.X) / PixelSize, (Focus.Y - TopLeftCorner.Y) / PixelSize, Color.Empty);

            Resize(newSize);

            Rectangle picBoxRectangle = new Rectangle(new Point(0, 0), CurrentSize);
            TopLeftCorner = Focus;
            TopLeftCorner.Offset(-(PixelSize / 2), -(PixelSize / 2));
            TopLeftCorner.Offset(-(focusPixel.X * PixelSize), -(focusPixel.Y * PixelSize));

            SolidBrush brush = new SolidBrush(Color.White);
            for (int j = 0; j < ImageBitmap.Height; j++)
            {
                for (int i = 0; i < ImageBitmap.Width; i++)
                {
                    brush.Color = GetPixel(i, j, true).Color;
                    Rectangle pixel = new Rectangle(TopLeftCorner.X + i * PixelSize, TopLeftCorner.Y + j * PixelSize, PixelSize, PixelSize);
                    pixel.Intersect(picBoxRectangle);
                    g.FillRectangle(brush, pixel);
                }
            }

            // Draws the matrix over the canvas.
            if (IsMatrixVisible)
            {
                Pen pen = new Pen(Color.LightSkyBlue);
                // Vertical lines
                for (int i = TopLeftCorner.X; i <= TopLeftCorner.X + ImageBitmap.Width * PixelSize; i += PixelSize)
                {
                    g.DrawLine(pen, i, TopLeftCorner.Y, i, TopLeftCorner.Y + ImageBitmap.Height * PixelSize);
                }
                // Horizontal lines
                for (int j = TopLeftCorner.Y; j <= TopLeftCorner.Y + ImageBitmap.Height * PixelSize; j += PixelSize)
                {
                    g.DrawLine(pen, TopLeftCorner.X, j, TopLeftCorner.X + ImageBitmap.Width * PixelSize, j);
                }
            }
        }
        /// <summary>
        /// Changes the size of the projection to fit into the resized canvas.
        /// </summary>
        /// <param name="newPictureBoxSize">New Size of the PictureBox.</param>
        private void Resize(Size newPictureBoxSize)
        {
            CurrentSize = newPictureBoxSize;
            PixelSize = Math.Min(CurrentSize.Width / ImageBitmap.Width, CurrentSize.Height / ImageBitmap.Height);
            PixelSize = (int)(PixelSize * Zoom);
        }

        /// <summary>
        /// Paints the clicked pixel with the passed Color.
        /// </summary>
        /// <param name="x">X coordinate of the MouseClick event.</param>
        /// <param name="y">Y coordinate of the MouseClick event.</param>
        /// <param name="color">New color of the pixel.</param>
        public void Click(int x, int y, Color color)
        {
            int px = (x - TopLeftCorner.X) / PixelSize;
            int py = (y - TopLeftCorner.Y) / PixelSize;
            if (0 <= px && 0 <= py && px < ImageBitmap.Width && py < ImageBitmap.Height)
            {
                SetPixel(px, py, color, true);
            }
        }
        /// <summary>
        /// Returns a Pixel corresponding to the point of the PictureBox the user clicked on.
        /// </summary>
        /// <param name="x">x-coordinate of the click.</param>
        /// <param name="y">y-coordinate of the click.</param>
        /// <param name="getColor">Specifies whether the user wants to get the color too.</param>
        unsafe public Pixel GetPixel(int x, int y, bool usingBitmapPixelCoordinates = false)
        {
            Pixel p = new Pixel();
            if (usingBitmapPixelCoordinates)
            {
                p.X = x;
                p.Y = y;
            }
            else
            {
                p.X = (x - TopLeftCorner.X) / PixelSize;
                p.Y = (y - TopLeftCorner.Y) / PixelSize;
            }
            if (0 <= p.X && 0 <= p.Y && p.X < ImageBitmap.Width && p.Y < ImageBitmap.Height)
            {
                p.Color = Color.FromArgb(_imageData[p.Y * _imageBitmapData.Stride + p.X * 4 + 3], _imageData[p.Y * _imageBitmapData.Stride + p.X * 4 + 2], _imageData[p.Y * _imageBitmapData.Stride + p.X * 4 + 1], _imageData[p.Y * _imageBitmapData.Stride + p.X * 4]);
            }
            else p.Color = Color.Empty;
            return p;
        }
        /// <summary>
        /// Returns a Pixel corresponding to the point of the PictureBox the user clicked on.
        /// </summary>
        /// <param name="point">Point of the PictureBox the user clicked on.</param>
        /// <param name="getColor">Specifies whether the user wants to get the color too.</param>
        unsafe public Pixel GetPixel(Point point, bool usingBitmapPixelCoordiantes = false)
        {
            Pixel p = new Pixel();
            if (usingBitmapPixelCoordiantes)
            {
                p.X = point.X;
                p.Y = point.Y;
            }
            else
            {
                p.X = (point.X - TopLeftCorner.X) / PixelSize;
                p.Y = (point.Y - TopLeftCorner.Y) / PixelSize;
            }
            if (0 <= p.X && 0 <= p.Y && p.X < ImageBitmap.Width && p.Y < ImageBitmap.Height)
            {
                p.Color = Color.FromArgb(_imageData[p.Y * _imageBitmapData.Stride + p.X * 4 + 3], _imageData[p.Y * _imageBitmapData.Stride + p.X * 4 + 2], _imageData[p.Y * _imageBitmapData.Stride + p.X * 4 + 1], _imageData[p.Y * _imageBitmapData.Stride + p.X * 4]);
            }
            else p.Color = Color.Empty;
            return p;
        }
        /// <summary>
        /// Changes the color of the Pixel inside the ImageData array.
        /// </summary>
        /// <param name="x">x-coordinate of the Pixel we're setting.</param>
        /// <param name="y">y-coordinate of the Pixel we're setting.</param>
        /// <param name="usingBitmapPixelCoordinates">Specifies whether we're using the control's X and Y coordinates, or the Bitmap's.</param>
        unsafe public void SetPixel(int x, int y, Color color, bool usingBitmapPixelCoordinates = false)
        {
            Point p = new Point();
            if (usingBitmapPixelCoordinates)
            {
                p.X = x;
                p.Y = y;
            }
            else
            {
                p.X = (x - TopLeftCorner.X) / PixelSize;
                p.Y = (y - TopLeftCorner.Y) / PixelSize;
            }
            if (0 <= p.X && 0 <= p.Y && p.X < ImageBitmap.Width && p.Y < ImageBitmap.Height)
            {
                _imageData[p.Y * _imageBitmapData.Stride + p.X * 4 + 3] = color.A;
                _imageData[p.Y * _imageBitmapData.Stride + p.X * 4 + 2] = color.R;
                _imageData[p.Y * _imageBitmapData.Stride + p.X * 4 + 1] = color.G;
                _imageData[p.Y * _imageBitmapData.Stride + p.X * 4] = color.B;
            }
        }
        /// <summary>
        /// Changes the color of the Pixel inside the ImageData array.
        /// </summary>
        /// <param name="pixel">X and Y coordinates of the Pixel we're setting.</param>
        /// <param name="usingBitmapPixelCoordinates">Specifies whether we're using the control's X and Y coordinates, or the Bitmap's.</param>
        unsafe public void SetPixel(Pixel pixel, bool usingBitmapPixelCoordinates = false)
        {
            Pixel p = new Pixel();
            p.Color = pixel.Color;
            if (usingBitmapPixelCoordinates)
            {
                p.X = pixel.X;
                p.Y = pixel.Y;
            }
            else
            {
                p.X = (pixel.X - TopLeftCorner.X) / PixelSize;
                p.Y = (pixel.Y - TopLeftCorner.Y) / PixelSize;
            }
            if (0 <= p.X && 0 <= p.Y && p.X < ImageBitmap.Width && p.Y < ImageBitmap.Height)
            {
                _imageData[p.Y * _imageBitmapData.Stride + p.X * 4 + 3] = p.Color.A;
                _imageData[p.Y * _imageBitmapData.Stride + p.X * 4 + 2] = p.Color.R;
                _imageData[p.Y * _imageBitmapData.Stride + p.X * 4 + 1] = p.Color.G;
                _imageData[p.Y * _imageBitmapData.Stride + p.X * 4] = p.Color.B;
            }
        }
        /// <summary>
        ///  Returns the borders of the Pixel the used clicked on.
        /// </summary>
        /// <param name="e">Event arguments</param>
        /// <returns></returns>
        public Rectangle? GetPixelBorders(MouseEventArgs e)
        {
            Rectangle? rect = null;
            int px = (e.X - TopLeftCorner.X) / PixelSize;
            int py = (e.Y - TopLeftCorner.Y) / PixelSize;
            if (0 <= px && 0 <= py && px < ImageBitmap.Width && py < ImageBitmap.Height)
            {
                rect = new Rectangle(TopLeftCorner.X + px * PixelSize, TopLeftCorner.Y + py * PixelSize, PixelSize, PixelSize);
            }
            return rect;
        }
        /// <summary>
        /// Turns the whole canvas white.
        /// </summary>
        unsafe public void Clear()
        {
            for (int j = 0; j < ImageBitmap.Height; j++)
            {
                for (int i = 0; i < ImageBitmap.Width; i++)
                    SetPixel(i, j, Color.White, true);
            }
        }
        /// <summary>
        /// Converts a Bitmap to a 2-dimensional byte array.
        /// </summary>
        /// <param name="bmp">Bitmap to be converted</param>
        /// <returns>2-dimensional byte array</returns>
        unsafe private byte[] BitmapToArray(Bitmap bmp)
        {
            _imageBitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);

            byte[] bytes = new byte[_imageBitmapData.Stride * bmp.Height];
            try
            {
                Marshal.Copy(_imageBitmapData.Scan0, bytes, 0, bytes.Length);
            }
            finally
            {
                bmp.UnlockBits(_imageBitmapData);
            }
            return bytes;
        }
        /// <summary>
        /// Saves the Image as a file in the specified location.
        /// </summary>
        /// <param name="fileStream">Location of the saved file.</param>
        /// <param name="imageFormat">Format of the saved file.</param>
        public void SaveImageAs(FileStream fileStream, ImageFormat? imageFormat = null)
        {
            if (imageFormat == null)
                imageFormat = ImageFormat.Jpeg;
            for (int j = 0; j < ImageBitmap.Height; j++)
            {
                for (int i = 0; i < ImageBitmap.Width; i++)
                {
                    ImageBitmap.SetPixel(i, j, GetPixel(i, j, true).Color);
                }
            }
            ImageBitmap.Save(fileStream, imageFormat);
        }
    }
}