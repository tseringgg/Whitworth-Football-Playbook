using IronXL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsWithAspose
{
    public class PlaySheet
    {
        public List<PlayList> Plays = new List<PlayList> { };
        //Filename of the excel file to parse
        string filename = "";

        public PlaySheet(string filename)
        {
            this.filename = filename;
        }

        // May want to change passing a filename or saving it in a constructor
        public bool ParsePlays(string fileName)
        {
            WorkSheet workSheet;

            // Error Case for if the WorkBook or WorkSheet are not valid
            try
            {
                WorkBook workBook = WorkBook.Load(fileName);
                workSheet = workBook.GetWorkSheet("Install_1");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

            //if (false)
            //{
            //    return false;
            //}


            // Gets All Data between this range
            IronXL.Range myRange = workSheet.GetRange("A4:F100");

            //Split the rows into an array
            string[] rows = myRange.ToString().Split(new char[] { '\n' });

            string singlePlay = "";
            int counter = 0;

            for (int i = 0; i < rows.Length; i++)
            {
                singlePlay = rows[i];

                if (singlePlay.IndexOf('\t') != 0)
                {
                    counter++;

                    if (counter > 4)
                    {
                        int j = singlePlay.IndexOf("\t");

                        Plays.Add(new PlayList());

                        // Creates substring of the category name in order to add it to object
                        Plays[Plays.Count - 1].categoryName = singlePlay.ToString().Substring(0, j);
                    }

                }
                else if (singlePlay.IndexOf('\t') == 0 && counter > 4 && singlePlay.IndexOf('\t', 2) != 2)
                {
                    int k = singlePlay.IndexOf("\t", 1);
                    int prevIndex = 1;

                    // Adds tags to list
                    string temp = singlePlay.Substring(prevIndex, k - prevIndex);
                    Plays[Plays.Count - 1].tags.Add(temp);

                    prevIndex = k + 2;

                    k = singlePlay.IndexOf("\t", prevIndex);

                    // Adds tags to list
                    Plays[Plays.Count - 1].personell.Add(singlePlay.Substring(prevIndex, k - prevIndex));

                    prevIndex = k + 2;

                    // Adds personell to list
                    Plays[Plays.Count - 1].formations.Add(singlePlay.Substring(prevIndex, singlePlay.Length - 1 - prevIndex));

                }
            }
            return true;
        }

        public void ParsePlays()
        {
            ParsePlays(filename);
        }

        public void PrintPlays()
        {
            for (int i = 0; i < Plays.Count; i++)
            {
                //Print the catagory of plays
                Console.WriteLine(Plays[i].categoryName);
                for (int j = 0; j < Plays[i].tags.Count; j++)
                {
                    //Print out all of the plays
                    Console.WriteLine(Plays[i].tags[j] + " | " + Plays[i].personell[j] + " | " + Plays[i].formations[j] + " |");
                }
                //Seperate catagories with a new line
                Console.WriteLine();
            }
        }

    }
}
