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
            // Read from JSON
            string readFromFormation = File.ReadAllText(@"../../../formation.json");
            List<Formation> formationsTable = JsonConvert.DeserializeObject<DataTable<Formation>>(readFromFormation).table;

            // Formations have been corrected up to "Bundle"
            Category category = new();
            foreach(Formation formation in formationsTable)
            {
                category.Add(formation);
            }

            Diagram diagram = new();
            FourLeftPlayDrawer pd;
            Page currentPage;
            for(int i = 0; i < category.Count; i++)
            {
                currentPage = diagram.Pages[diagram.Pages.Add(new()) - 1];
                pd = new FourLeftPlayDrawer(currentPage, category.GetPlayPage(i));
                pd.Draw();
            }
            // remove empty page at end
            diagram.Pages.Remove(diagram.Pages[diagram.Pages.Count-1]);
            
            diagram.ExportDiagram("..\\");

            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
        }
    }
}