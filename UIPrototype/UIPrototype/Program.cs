using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIPrototype
{
    internal static class Program
    {
        public static bool running = true;

        [STAThread]
        static void Main()
        {
            //Set up the open file dialog so they can choose an excel file to parce from
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //Title of the window
            openFileDialog.Title = "Select a playsheet";

            //Set up the initial directory the file dialog will start in
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "Diagrams";

            //Restrict the file type to excel formats
            openFileDialog.Filter = "excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

            //Keep running until prompted to close
            while (running)
            {
                //Show the file dialog
                System.Windows.Forms.DialogResult result = openFileDialog.ShowDialog();
                //If they select the file, then process it, otherwise, confirm they want to exit the applicaion
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    String filename = openFileDialog.FileName;

                    //Parse the file here
                    Console.WriteLine(filename);

                    //Set up message box to respond to the user
                    string message = "Plays generated successfully! Would you like to open another file?";
                    string title = "Whitworth Football Playmaker";
                    DialogResult quit = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

                    //If they want to quit then set running to false
                    if(quit == DialogResult.No)
                    {
                        running = false;
                    }
                } else
                {
                    //Set up and show message box
                    string message = "Exit the application?";
                    string title = "Whitworth Football Playmaker";
                    DialogResult quit = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

                    //If they want to close then set running to false
                    if(quit == DialogResult.Yes)
                    {
                        running = false;
                    }
                }
            }
        }
    }
}
