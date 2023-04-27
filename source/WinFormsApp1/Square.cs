using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsWithAspose
{
    public class Square : IDrawable
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Scale { get; set; }
        public Square(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Scale = 1;
        }

        public void Draw(Page page)
        {
            page.DrawRectangle(X, Y, Width*Scale, Height*Scale);
        }
    }
}
