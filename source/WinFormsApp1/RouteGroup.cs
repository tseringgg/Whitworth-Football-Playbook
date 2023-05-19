﻿using Aspose.Diagram;
using WinFormsWithAspose;
using PointF = System.Drawing.PointF;

namespace WinFormsWithAspose
{
    public class RouteGroup : IDiagramGroup
    {
        public Formation form;
        public List<RouteData> routeData;
        public List<string> players;

        public List<IDrawable> drawables { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Scale { get; set; }

        public RouteGroup(Formation form, List<RouteData> routeData, List<string> players)
        {
            this.form = form;
            this.routeData = routeData;
            this.players = players;
            drawables = new List<IDrawable>();
            Init();
        }

        private void Init()
        {
            for (int i = 0; i < players.Count && i < routeData.Count; i++)
            {
                switch (players[i])
                {
                    case "X":
                        drawables.Add(new Route(routeData[i].name, form.x_x, form.x_y, "", StringsToSteps(form.x_x, routeData[i])));
                        break;
                    case "Y":
                        drawables.Add(new Route(routeData[i].name, form.y_x, form.y_y, "", StringsToSteps(form.y_x, routeData[i])));
                        break;
                    case "H":
                        drawables.Add(new Route(routeData[i].name, form.h_x, form.h_y, "", StringsToSteps(form.h_x, routeData[i])));
                        break;
                    case "Z":
                        drawables.Add(new Route(routeData[i].name, form.z_x, form.z_y, "", StringsToSteps(form.z_x, routeData[i])));
                        break;
                }
            }
        }
        public void Draw(Page page)
        {
            
            //page.AddText(X + 0.5, Y + 1, Width + 1, Height, PlayTitle);
            foreach (Route drawable in drawables)
            {
                drawable.Scale = Scale;
                drawable.X *= Scale;
                drawable.Y *= Scale;
                drawable.X += X;
                drawable.Y += Y;
                drawable.Draw(page);
            }
        }

        private List<PointF> StringsToSteps(double x, RouteData r)
        {
            List<PointF> routeSteps = new List<PointF>();
            foreach (string s in r.steps)
            {
                string[] splitStep = s.Split(',');
                if(x > 0)
                {
                    routeSteps.Add(new PointF(-(Convert.ToSingle(splitStep[0])), Convert.ToSingle(splitStep[1])));
                }
                else
                {
                    routeSteps.Add(new PointF(Convert.ToSingle(splitStep[0]), Convert.ToSingle(splitStep[1])));
                }
                
            }
            return routeSteps;
        }
    }
}