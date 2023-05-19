namespace WinFormsWithAspose
{
    public class RouteData
    {
        public string name;
        public List<string> steps;
        public string ending;

        public RouteData(string name, List<string> steps, string ending)
        {
            this.name = name;
            this.steps = steps;
            this.ending = ending;
        }
        
    }
}