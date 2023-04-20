using System.Drawing.Text;

namespace WinFormsWithAspose
{
    public class SkillPlayer : ITextBubble
    {
        public string Label { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public SkillPlayer(string label, double x, double y, double width, double height)
        {
            this.Label = label;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }
    }
}