using Aspose.Diagram;
using System.Security.Cryptography.Pkcs;
using WinFormsWithAspose;
using Newtonsoft.Json;

namespace WinFormsApp1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            string dataDir = "..\\Generated Files\\";

            Diagram diagram = new Diagram();
            Page firstPage = diagram.Pages.GetPage(0);

            // Write to JSON
            formation firstFormation = new formation("Duo", 3, 0, 2.05, -.35, -.5, -1.25, 0, -1, -1.25, -.35, -3, 0);
            List<formation> formations = new List<formation>();
            formations.Add(firstFormation);
            DataTable<formation> dataTables = new DataTable<formation>("Formations", formations);
            string formationJson = JsonConvert.SerializeObject(dataTables, Formatting.Indented);
            File.WriteAllText(@"../../../formation.json", formationJson);

            // Read from JSON
            string readFromFormation = File.ReadAllText(@"../../../formation.json");
            DataTable<formation> formationsFromJson = JsonConvert.DeserializeObject<DataTable<formation>>(readFromFormation);

            List<formation> x = formationsFromJson.table;

            List<Play> plays = new List<Play>();
            for(int i = 0; i < 4; i++)
            {
                AddSamplePlay(plays, x[0]);
                //AddSamplePlay(plays, x[i]);
            }

            FourLeftPlayDrawer pd = new FourLeftPlayDrawer(firstPage, plays);
            pd.Draw();

            diagram.ExportDiagram(dataDir);

            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
        }
        public static void AddSamplePlay(List<Play> plays, formation formation)
        {
            /*
            plays.Add(new Play(new List<IDiagramGroup>{
                new SkillPlayerGroup(0.4, 0.3)
                    .Add("X", 3, 0)
                    .Add("Y", -1.25, -.35)
                    .Add("Z", -3, 0)
                    .Add("Q", 0, -1)
                    .Add("T", -0.5, -1.25)
                    .Add("H", 2.05, -.35),
                new CenterFormation(0.4, 0.3, 0.5)
            }));
            */
            plays.Add(new Play(new List<IDiagramGroup>
            {
                new SkillPlayerGroup(0.4, 0.3)
                    .Add("X", formation.x_x, formation.x_y)
                    .Add("Y", formation.y_x, formation.y_y)
                    .Add("Z", formation.z_x, formation.z_y)
                    .Add("Q", formation.q_x, formation.q_y)
                    .Add("T", formation.t_x, formation.t_y)
                    .Add("H", formation.h_x, formation.h_y),
                new CenterFormation(0.4, 0.3, 0.5)
            }));
        }


        public class formation
        {
            public string? name;
            public double x_x;
            public double x_y;
            public double h_x;
            public double h_y;
            public double t_x;
            public double t_y;
            public double q_x;
            public double q_y;
            public double y_x;
            public double y_y;
            public double z_x;
            public double z_y;

            public formation() { }

            public formation(string name, double x_x, double x_y, double h_x, double h_y, double t_x, double t_y, double q_x, double q_y, double y_x, double y_y, double z_x, double z_y)
            {
                this.name = name;
                this.x_x = x_x;
                this.x_y = x_y;
                this.h_x = h_x;
                this.h_y = h_y;
                this.t_x = t_x;
                this.t_y = t_y;
                this.q_x = q_x;
                this.q_y = q_y;
                this.y_x = y_x;
                this.y_y = y_y;
                this.z_x = z_x;
                this.z_y = z_y;

            }
        }
        [Serializable]
        class DataTable<Type>
        {
            public DataTable() { }
            public DataTable(string name, List<Type> list)
            {
                this.name = name;
                table = list;
            }

            public void add(Type toAdd)
            {
                table.Add(toAdd);
            }

            public void delete(int i)
            {
                table.RemoveAt(i);
            }

            public List<Type> table { get; set; }
            public string name { get; set; }
        };


    }
}