namespace ITnetwork_Pixel_Art_Improved
{
    public class Pixel
    {
        public Color Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Pixel() { }
        public Pixel(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }
}
