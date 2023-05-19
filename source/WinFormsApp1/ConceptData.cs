namespace WinFormsWithAspose
{
    public class ConceptData
    {
        public string name;
        public List<string> routes;
        
        //container for concepts
        public ConceptData(string name, List<string> routes)
        {
            this.name = name;
            this.routes = routes;
        }

    }
}
