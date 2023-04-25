namespace WinFormsWithAspose
{
    public class SkillPlayerGroup : ITextBubbleGroup
    {
        public List<ITextBubble> TextBubbles { get; }
        private double X, Y;
        double width, height;
        public SkillPlayerGroup(double width, double height)
        {
            this.X = 0;
            this.Y = 0;
            this.width = width;
            this.height = height;
            TextBubbles = new List<ITextBubble>();
        }
        public SkillPlayerGroup Add(string label, double x, double y)
        {
            TextBubbles.Add(new SkillPlayer(label, x, y, this.width, this.height));
            return this;
        }

        public IDiagramGroup SetDimensions(double width, double height)
        {
            this.width = width;
            this.height = height;
            this.TextBubbles.ForEach(sp =>
            {
                sp.Width = width;
                sp.Height = height;
            });

            return this;
        }

        public IDiagramGroup SetCenter(double x, double y)
        {
            this.X = x;
            this.Y = y;
            return this;
        }

        public double GetX()
        {
            return this.X;
        }

        public double GetY()
        {
            return this.Y;
        }
    }
}
