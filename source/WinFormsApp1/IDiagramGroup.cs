using Aspose.Diagram;

namespace WinFormsWithAspose
{
    public interface IDiagramGroup // for a group of drawables of the same type
    {
        public List<IDrawable> drawables { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Scale { get; set; }
        public void Draw(Page page);
    }
}