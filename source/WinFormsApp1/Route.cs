using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointF = System.Drawing.PointF;

namespace WinFormsWithAspose
{
    public class Route : IDrawable
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Scale { get; set; }
        public List<PointF> Motions { get; set; }
        public string Ending { get; set; }
        public string Name { get; set; }
        public Route(string name, double x, double y, string ending, List<PointF> motions)
        {
            this.X = x;
            Name = name;
            this.Y = y;
            Motions = motions;
        }

        public void Draw(Page page)
        {
            //adds name of player to page
            page.AddText(X+0.4, Y-0.25, 1, Height, Name);
            List<PointF> points = new List<PointF>();
            //adds starting point
            points.Add(new PointF((float)X, (float)Y));
            //adds each point for each step in a route
            for (int i = 0; i < Motions.Count; i++)
            {
                points.Add(new((float)(points[i].X) + (float)(Motions[i].X)*.5f, (float)(points[i].Y) + (float)((Motions[i].Y)*.5f)));
            }

            //draws lines between the points
            for (int i = 0; i < points.Count - 1; i++)
            {
                page.DrawLine(points[i].X , points[i].Y , points[i + 1].X , points[i + 1].Y);
            }

            //switch statement for how we will end each route
            //free version of visio limited us a lot here
            switch (Ending)
            {
                case "flathead":
                    page.DrawLine(points[points.Count - 1].X, points[points.Count - 1].Y, points[points.Count - 1].X - 1, points[points.Count - 1].Y);
                    page.DrawLine(points[points.Count - 1].X, points[points.Count - 1].Y, points[points.Count - 1].X + 1, points[points.Count - 1].Y);
                    break;
                case "arrow":

                    break;
                case "circle":

                    break;
                case "none":
                    break;
            }
        }

        //not implemented in V1
        public void DrawFlatHead(Page page, PointF startPoint, PointF endPoint)
        {
            // get slope of line
            // get length of line
            // try to get inverse slope
            // get points that are 1/10th of the length away
            // get perpendicular line equation using endPoint x and y-> y = mx + b

        }
    }
}
