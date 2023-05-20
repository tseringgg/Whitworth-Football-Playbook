using Aspose.Diagram;

namespace WinFormsWithAspose
{
    public interface IDrawable // can be drawn to a page & have its position adjusted externally
    {
        public void Draw(Page page);
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Scale { get; set; }
    }
}
