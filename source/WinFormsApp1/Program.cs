using Aspose.Diagram;
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

            string play = ""; // pull from excel file
            // GET


            // TODO: make draw functions into extension methods
            double width = 0.4, height = 0.3;
            //SkillPlayer x = new SkillPlayer("X", xpin, ypin);


            firstPage.DrawCenterFormation(4.25, 4.25, width, height, 0.5);
            firstPage.DrawSkillPlayer("X", 7.25, 4.25, width, height);
            firstPage.DrawSkillPlayer("Y", 3, 3.9, width, height);
            firstPage.DrawSkillPlayer("Z", 1.25, 4.25, width, height);
            firstPage.DrawSkillPlayer("Q", 4.25, 3.25, width, height);
            firstPage.DrawSkillPlayer("T", 3.75, 3, width, height);
            firstPage.DrawSkillPlayer("H", 6.3, 3.9, width, height);


            //

            ExportDiagram(dataDir, diagram);

            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
        }


        public static void ExportDiagram(string dataDir, Diagram diagram)
        {
            MemoryStream pdfStream = new MemoryStream();
            diagram.Save(pdfStream, SaveFileFormat.Pdf);

            // Create a PDF file
            diagram.Save(dataDir + "ExportToPDF.vsdx", SaveFileFormat.Vsdx);

            FileStream pdfFileStream = new FileStream(dataDir + "ExportToPDF_out.pdf", FileMode.Create, FileAccess.Write);
            pdfStream.WriteTo(pdfFileStream);
            pdfFileStream.Close();

            pdfStream.Close();
        }
    }
}