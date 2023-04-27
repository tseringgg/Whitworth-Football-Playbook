using Aspose.Diagram;

namespace WinFormsWithAspose
{
    public static class VisioDiagramExtensions
    {
        public static void ExportDiagram(this Diagram diagram, string dataDir)
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
