using Aspose.Diagram;

namespace WinFormsWithAspose
{
    public interface IDrawable
    {
        public void Draw(Page page);
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Scale { get; set; }
    }
}
