namespace WpfCanvasPOC
{
    public class BrushSizeDialogData
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public BrushSizeDialogData(double width, double height) { Width = width; Height = height; }

        public override string ToString()
        {
            return $"(Width={Width} Height={Height})";
        }
    }
}
