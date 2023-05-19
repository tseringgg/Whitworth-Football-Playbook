using Aspose.Diagram;
using Newtonsoft.Json;
using SixLabors.Fonts.Unicode;
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

            //Set up the open file dialog so they can choose an excel file to parce from
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //Title of the window
            openFileDialog.Title = "Select a playsheet";

            //Set up the initial directory the file dialog will start in
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"../../../";

            //Restrict the file type to excel formats
            openFileDialog.Filter = "excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

            //Keep running until prompted to close
            bool running = true;
            while (running)
            {
                //Show the file dialog
                System.Windows.Forms.DialogResult result = openFileDialog.ShowDialog();
                //If they select the file, then process it, otherwise, confirm they want to exit the applicaion
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    String fileName = openFileDialog.FileName;

                    PlaySheet playsheet = new PlaySheet(fileName);
                    playsheet.ParsePlays();
                    playsheet.PrintPlays();

                    List<Category> categories = new();
                    Category category;
                    playsheet.Plays.ForEach(x =>
                    {
                        category = new(x.categoryName);
                        x.formations.ForEach(y =>
                        {
                            string substr;
                            if (y.Contains(" LT"))
                            {
                                substr = y.Substring(0, y.IndexOf(" LT"));
                            }
                            else if (y.Contains(" RT"))
                            {
                                substr = y.Substring(0, y.IndexOf(" RT"));
                            }
                            else
                            {
                                Console.WriteLine("Parser failed to find LF or RT keyword!");
                                return;
                            }

                            int len = substr.Split(" ").Length;
                            for (int i = 0; i < len; i++)
                            {
                                // see if substring exists in formations table
                                Formation form = formationsTable.Find(f => (f.name.ToUpper() == substr.ToUpper()));
                                if (form != null)
                                {
                                    category.Add(form, new List<RouteData>()
                                    {
                                        new routeParser("Slant").initialize(),
                                        new routeParser("Slant").initialize(),
                                        new routeParser("Slant").initialize(),
                                        new routeParser("Slant").initialize(),
                                    }, new List<string>()
                                    {
                                        "x",
                                        "y",
                                        "h",
                                        "z"
                                    });
                                    break;
                                }
                                //
                                substr = substr.Substring(substr.IndexOf(" ")+1);
                            }
                        });
                        categories.Add(category);
                    });

                    // TODO: 1. Need parser code here to add plays to different categories.
                    //       2. I recommend storing them as a list of categories (List<Category>)
                    // Currently, this code adds every formation in the table to just one Category object
                    // * * * * * *
                    //Category category = new();
                    foreach(Formation formation in formationsTable)
                    {
                        //category.Add(formation); 
                    }
                    // * * * * * *


                    Diagram diagram = new();
                    FourLeftPlayDrawer pd;
                    Page currentPage;
                    // TODO: For each category from the list you created, run the following block of code.
                    // * * * * * *
                    foreach(Category c in categories)
                    {
                        double width, height;
                        for (int i = 0; i < c.Count; i++)
                        {
                            currentPage = diagram.Pages[diagram.Pages.Add(new()) - 1];
                            width = currentPage.PageSheet.PageProps.PageWidth.Value;
                            height = currentPage.PageSheet.PageProps.PageHeight.Value;
                            currentPage.AddText(width/2, height/100*95, 1, 1, c.Name);
                            pd = new FourLeftPlayDrawer(currentPage, c.GetPlayPage(i));
                            pd.Draw();
                        }
                    }
            
                    // * * * * * *


                    // removes empty page that gets generated at the end
                    diagram.Pages.Remove(diagram.Pages[diagram.Pages.Count-1]);
                    diagram.ExportDiagram("..\\");

                    // ignore for now
                    //ApplicationConfiguration.Initialize();
                    //Application.Run(new Form1());



                    //Set up message box to respond to the user
                    string message = "Plays generated successfully! Would you like to open another file?";
                    string title = "Whitworth Football Playmaker";
                    DialogResult quit = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

                    //If they want to quit then set running to false
                    if (quit == DialogResult.No)
                    {
                        running = false;
                    }
                }
                else
                {
                    //Set up and show message box
                    string message = "Exit the application?";
                    string title = "Whitworth Football Playmaker";
                    DialogResult quit = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

                    //If they want to close then set running to false
                    if (quit == DialogResult.Yes)
                    {
                        running = false;
                    }
                }
            }

            
        }
    }
}