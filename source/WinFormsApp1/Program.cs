using Aspose.Diagram;
using System.Security.Cryptography.Pkcs;
using WinFormsWithAspose;

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

            string formation = ""; // pull from excel file
            string concept = "";
            // GET


            List <Play> plays = new List<Play>();
            for(int i = 0; i < 8; i++)
            {
                AddSamplePlay(plays);
            }

            EightPlayDrawer pd = new EightPlayDrawer(firstPage, plays);
            pd.Draw();

            diagram.ExportDiagram(dataDir);

            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
        }
        public static void AddSamplePlay(List<Play> plays)
        {
            double x = 4.25;
            plays.Add(new Play(new List<IDiagramGroup>{
                new SkillPlayerGroup(0.4, 0.3)
                    .Add("X", 7.25 - x, 4.25 - x)
                    .Add("Y", 3 - x, 3.9 - x)
                    .Add("Z", 1.25 - x, 4.25 - x)
                    .Add("Q", 4.25 - x, 3.25 - x)
                    .Add("T", 3.75 - x, 3 - x)
                    .Add("H", 6.3 - x, 3.9 - x),
                new CenterFormation(0.4, 0.3, 0.5)
            }));
        }
    }
}