using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsWithAspose
{
    public class TextBubble : IDrawable
    {
        public string Label { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Scale { get; set; }
        public TextBubble(string label, double x, double y, double width, double height)
        {
            Scale = 1;
            Label = label;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public void Draw(Page page)
        {
            page.DrawEllipse(X, Y, Width*Scale, Height*Scale);
            page.AddText(X+Width*Scale*0.1, Y-Width*Scale*0.08, 0.1, 0, this.Label, "Calibri", "Black", 0.2*Scale);
        }
    }
}
