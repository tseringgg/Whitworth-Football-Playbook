using Aspose.Diagram;
using PointF = System.Drawing.PointF;

namespace WinFormsWithAspose
{
    public class CenterFormation : IDiagramGroup
    {
        public List<IDrawable> drawables { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Space { get; set;  }
        public double Scale { get; set; }
        public CenterFormation(double width, double height, double space)
        {
            X = 0;
            Y = 0;
            Width = width;
            Height = height;
            Space = space;
            Scale = 1;
            drawables = new List<IDrawable>() // add the shapes to the formation
            {
                new TextBubble("", X-Space, Y, Width, Height),
                new TextBubble("", X-2*Space, Y, Width, Height),
                new TextBubble("", X+Space, Y, Width, Height),
                new TextBubble("", X+2*Space, Y, Width, Height),
                new Square(X, Y, Width, Height)
            };
        }

        public void Draw(Page page)
        {
            // center formation is drawn the same across plays
            foreach (IDrawable drawable in drawables)
            {
                drawable.Scale = Scale;
                drawable.X *= Scale;
                drawable.Y *= Scale;
                drawable.X += X;
                drawable.Y += Y;
                drawable.Draw(page);
            }
        }
    }
}
