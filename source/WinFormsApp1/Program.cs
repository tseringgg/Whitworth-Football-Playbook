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

                        for (int i = 0; i < x.formations.Count; i++)
                        {
                            string substr;
                            if (x.formations[i].Contains(" LT"))
                            {
                                substr = x.formations[i].Substring(0, x.formations[i].IndexOf(" LT"));
                            }
                            else if (x.formations[i].Contains(" RT"))
                            {
                                substr = x.formations[i].Substring(0, x.formations[i].IndexOf(" RT"));
                            }
                            else
                            {
                                Console.WriteLine("Parser failed to find LF or RT keyword!");
                                return;
                            }
                            List<string> playersTagged;
                            List<string> conceptsInPlay;

                            TagsParser tp = new(x.tags[i].Split(" "));
                            tp.Process(out playersTagged, out conceptsInPlay);

                            List<string> playerAssignments = new List<string>();
                            List<string> playerRoutes = new List<string>();
                            ConceptParser cp;

                            for (int c = 0; c < conceptsInPlay.Count; c++)
                            {
                                cp = new ConceptParser(conceptsInPlay[c], playersTagged[c]);
                                cp.assignRoutes().ForEach(x => playerRoutes.Add(x));
                                cp.assignPlayer().ForEach(x => playerAssignments.Add(x));
                            }



                            int len = substr.Split(" ").Length;
                            for (int j = 0; j < len; j++)
                            {
                                // see if substring exists in formations table
                                Formation form = formationsTable.Find(f => (f.name.ToUpper() == substr.ToUpper()));
                                if (form != null)
                                {
                                    category.Add(form.name + " " + form.side + " " + x.tags[i] ,form, new List<RouteData>()
                                    {
                                        new RouteParser(playerRoutes[0]).Parse(),
                                        new RouteParser(playerRoutes[1]).Parse(),
                                        new RouteParser(playerRoutes[2]).Parse(),
                                        new RouteParser(playerRoutes[3]).Parse(),
                                    }, playerAssignments);
                                    break;
                                }
                                substr = substr.Substring(substr.IndexOf(" ") + 1);
                            }
                        }

                        
                        categories.Add(category);
                    });



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