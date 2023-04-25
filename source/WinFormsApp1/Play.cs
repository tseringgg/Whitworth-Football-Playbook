namespace WinFormsWithAspose
{
    internal class Play : IDiagramGroup
    {
        ITextBubbleGroup tbg;
        ILineGroup lg;
        private double X, Y;
        public Play(ITextBubbleGroup tbg, ILineGroup lg)
        {
            this.tbg = tbg;
            this.lg = lg;
            this.X = 0;
            this.Y = 0;
        }

        public IDiagramGroup SetCenter(double x, double y)
        {
            this.X = x;
            this.Y = y;
            tbg.SetCenter(x, y);
            //lg.SetCenter(x, y);
            return this;
        }
        public ITextBubbleGroup GetTextBubbleGroup() {  return this.tbg; }
        public ILineGroup GetLineGroup() { return this.lg; }

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
