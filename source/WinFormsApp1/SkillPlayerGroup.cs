using Aspose.Diagram;

namespace WinFormsWithAspose
{
    public class SkillPlayerGroup : IDiagramGroup
    {
        public List<IDrawable> drawables { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Scale { get; set; }
        public string PlayTitle { get; set; }
        public SkillPlayerGroup(string title, double width, double height)
        {
            X = 0;
            Y = 0;
            Scale = 1;
            PlayTitle = title;
            Width = width;
            Height = height;
            drawables = new List<IDrawable>();
        }
        public SkillPlayerGroup Add(string label, double x, double y)
        {
            drawables.Add(new TextBubble(label, x, y, Width, Height));
            return this;
        }

        public void Draw(Page page)
        {
            page.AddText(X, Y+1, Width, Height, PlayTitle);
            foreach (TextBubble drawable in drawables) 
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
