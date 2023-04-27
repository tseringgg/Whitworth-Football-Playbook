using Aspose.Diagram;

namespace WinFormsWithAspose
{
    public interface IDiagramGroup
    {
        public List<IDrawable> drawables { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Scale { get; set; }
        public void Draw(Page page);
    }
}