using Aspose.Diagram;
using WinFormsWithAspose;
using PointF = System.Drawing.PointF;

namespace WinFormsWithAspose
{
    public class RouteGroup : IDiagramGroup
    {
        public Formation form;
        public List<RouteData> routeData;
        public List<string> players;

        public List<IDrawable> drawables { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double X { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Scale { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public RouteGroup(Formation form, List<RouteData> routeData, List<string> players)
        {
            this.form = form;
            this.routeData = routeData;
            this.players = players;
        }

        public void Draw(Page page)
        {
            for (int i = 0; i < players.Count; i++)
            {
                
            }

            List<PointF> routeSteps = new List<PointF>();
            foreach (string s in dataObject.steps)
            {
                string[] splitStep = s.Split(',');
                routeSteps.Add(new PointF(Convert.ToSingle(splitStep[0]), Convert.ToSingle(splitStep[1])));
            }
            Route r = new Route(x, y, "nothing", routeSteps);
            r.Draw(page);

            throw new NotImplementedException();
        }


    }
}