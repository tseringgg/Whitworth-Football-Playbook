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

            plays.Add((Play)new Play(new SkillPlayerGroup(0.4, 0.3)
                    .Add("X", 7.25, 4.25)
                    .Add("Y", 3, 3.9)
                    .Add("Z", 1.25, 4.25)
                    .Add("Q", 4.25, 3.25)
                    .Add("T", 3.75, 3)
                    .Add("H", 6.3, 3.9),
                    new RouteGroup()).SetCenter(4.25, 4.25));

            plays.ForEach(play => firstPage
                //.DrawCenterFormation(4.25, 4.25, 0.4, 0.3, 0.5)
                .DrawTextBubbles(play.GetTextBubbleGroup())
                //.DrawRouteGroup(play.GetRouteGroup())
            );

            // get play from excel
            // loop through keywords
            //      get data from json with keyword
            //      return skillplayergroup object
            // draw

            ExportDiagram(dataDir, diagram);

            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
        }


        public static void ExportDiagram(string dataDir, Diagram diagram)
        {
            MemoryStream pdfStream = new MemoryStream();
            diagram.Save(pdfStream, SaveFileFormat.Pdf);
            diagram.Save(dataDir + "ExportToPDF.vsdx", SaveFileFormat.Vsdx);

            FileStream pdfFileStream = new FileStream(dataDir + "ExportToPDF_out.pdf", FileMode.Create, FileAccess.Write);
            pdfStream.WriteTo(pdfFileStream);
            pdfFileStream.Close();
            pdfStream.Close();
        }
    }
}