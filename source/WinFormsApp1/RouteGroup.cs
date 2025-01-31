﻿using Aspose.Diagram;
using WinFormsWithAspose;
using PointF = System.Drawing.PointF;

namespace WinFormsWithAspose
{
    public class RouteGroup : IDiagramGroup // holding routes that will be drawn to the same play
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
            //this function draws each skill player and their route
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
            
            //draws the page and scales it 
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
            //turn route steps from the json file into pointf objects
            List<PointF> routeSteps = new List<PointF>();
            foreach (string s in r.steps)
            {
                string[] splitStep = s.Split(',');
                //if object is on the right side of the formation, then flip its route vertically
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