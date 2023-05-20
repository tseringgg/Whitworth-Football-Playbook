using Aspose.Diagram;
using Aspose.Diagram.Saving;

namespace WinFormsWithAspose
{
    public static class VisioDiagramExtensions // handling diagram being exported to a pdf file and a visio file format
    {
        public static void ExportDiagram(this Diagram diagram, string dataDir)
        {
            MemoryStream pdfStream = new MemoryStream();
            MemoryStream vsdxStream = new MemoryStream();
            diagram.Save(pdfStream, SaveFileFormat.Pdf);
            //diagram.Save(vsdxStream, SaveFileFormat.Vsdx);
            SaveOptions options = new DiagramSaveOptions();
            options.SaveFormat = SaveFileFormat.Vsdx;
            diagram.Save(vsdxStream, options);

            //diagram.Save(dataDir + "ExportToPDF.vsdx", SaveFileFormat.Vsdx);

            FileStream pdfFileStream = new FileStream(dataDir + "ExportToPDF_out.pdf", FileMode.Create, FileAccess.Write);
            FileStream vsdxFileStream = new FileStream(dataDir + "Export.vsdx", FileMode.Create, FileAccess.Write);
            pdfStream.WriteTo(pdfFileStream);
            vsdxStream.WriteTo(vsdxFileStream);
            vsdxFileStream.Close();
            pdfFileStream.Close();
            pdfStream.Close();
        }
    }
}
