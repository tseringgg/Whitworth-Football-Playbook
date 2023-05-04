using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Aspose.Diagram;

namespace TestExportAndAppWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Create diagram 1
            Diagram diagram = new Diagram();

            double width = 4, height = 6, pinX = 4.25, pinY = 4.5;
            diagram.Pages[0].DrawRectangle(pinX, pinY, width, height);

            // Set shape properties 
            Aspose.Diagram.Shape shape = diagram.Pages[0].Shapes[0];
            shape.XForm.PinX.Value = 5;
            shape.XForm.PinY.Value = 5;
            shape.Type = TypeValue.Shape;
            shape.Text.Value.Add(new Cp(0));
            shape.Text.Value.Add(new Txt("Export image number 1"));
            shape.Chars.Add(new Aspose.Diagram.Char());
            shape.Chars[0].Size.Value = .1;
            shape.Line.LineColor.Value = "#ff0000";
            shape.Line.LineWeight.Value = 0.1;
            shape.Line.Rounding.Value = 0.1;
            shape.Fill.FillBkgnd.Value = "#ff00ff";
            shape.Fill.FillForegnd.Value = "#ebf8df";

            //Set up save path and format for diagram and save to location
            string dataDir = "../CreateDiagram_out.png";
            diagram.Save(dataDir, SaveFileFormat.Png);


            //Create diagram 2
            diagram = new Diagram();

            width = 7; height = 4; pinX = 4.25; pinY = 4.5;
            diagram.Pages[0].DrawEllipse(pinX, pinY, width, height);

            // Set shape properties 
            shape = diagram.Pages[0].Shapes[0];
            shape.XForm.PinX.Value = 4;
            shape.XForm.PinY.Value = 4;
            shape.Type = TypeValue.Shape;
            shape.Text.Value.Add(new Cp(0));
            shape.Text.Value.Add(new Txt("Export image number 2"));
            shape.Chars.Add(new Aspose.Diagram.Char());
            shape.Chars[0].Size.Value = .5;
            shape.Line.LineColor.Value = "#0000ff";
            shape.Line.LineWeight.Value = 0.1;
            shape.Line.Rounding.Value = 0.1;
            shape.Fill.FillBkgnd.Value = "#0000ff";
            shape.Fill.FillForegnd.Value = "#ffff00";

            //Set up line properties
            shape.Line.LinePattern.Value = 1;
            shape.Line.LineColor.Ufe.F = "RGB(255,255,255)";
            shape.Line.Rounding.Value = 0.3125;
            shape.Line.LineCap.Value = BOOL.True;
            shape.Line.BeginArrow.Value = 4;
            shape.Line.EndArrow.Value = 4;
            shape.Line.BeginArrowSize.Value = ArrowSizeValue.Large;
            shape.Line.EndArrowSize.Value = ArrowSizeValue.Large;

            //Set up save path and format for diagram and save to location
            dataDir = "../CreateDiagram2_out.png";
            diagram.Save(dataDir, SaveFileFormat.Png);
        }

        private void Export1(object sender, RoutedEventArgs e)
        {
            //Set the image source to the dir of the saved diagram image 
            Uri fileUri = new Uri(@"C:\Users\mpala\source\repos\whitworth-football\TestExportAndAppWindow\TestExportAndAppWindow\bin\CreateDiagram_out.png");
            image.Source = new BitmapImage(fileUri);
        }

        private void Export2(object sender, RoutedEventArgs e)
        {
            //Set the image source to the dir of the saved diagram image 
            Uri fileUri = new Uri(@"C:\Users\mpala\source\repos\whitworth-football\TestExportAndAppWindow\TestExportAndAppWindow\bin\CreateDiagram2_out.png");
            image.Source = new BitmapImage(fileUri);
        }
    }
}
