using Aspose.Diagram;
using Newtonsoft.Json;
using WinFormsWithAspose;

namespace WinFormsApp1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Read from JSON, store Formation objects into a List
            string readFromFormation = File.ReadAllText(@"../../../formation.json");
            List<Formation> formationsTable = JsonConvert.DeserializeObject<DataTable<Formation>>(readFromFormation).table;


            // TODO: 1. Need parser code here to add plays to different categories.
            //       2. I recommend storing them as a list of categories (List<Category>)
            // Currently, this code adds every formation in the table to just one Category object
            // * * * * * *
            Category category = new();
            foreach(Formation formation in formationsTable)
            {
                category.Add(formation); 
            }
            // * * * * * *


            Diagram diagram = new();
            FourLeftPlayDrawer pd;
            Page currentPage;
            // TODO: For each category from the list you created, run the following block of code.
            // * * * * * *
            for (int i = 0; i < category.Count; i++)
            {
                currentPage = diagram.Pages[diagram.Pages.Add(new()) - 1];
                pd = new FourLeftPlayDrawer(currentPage, category.GetPlayPage(i));
                pd.Draw();
            }
            // * * * * * *


            // removes empty page that gets generated at the end
            diagram.Pages.Remove(diagram.Pages[diagram.Pages.Count-1]);
            diagram.ExportDiagram("..\\");

            // ignore for now
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
        }
    }
}