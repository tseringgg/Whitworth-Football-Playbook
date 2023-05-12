using System;
using IronXL;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.IO.Enumeration;

namespace ReadFromExcelFIle
{

    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"../../../Spring_Football_2023.xlsx";

            PlaySheets playsheet = new PlaySheets(fileName);
            playsheet.ParsePlays();
            playsheet.PrintPlays();
        }

        class playList
        {
            public string categoryName = "";
            public List<string> tags = new List<string> { };
            public List<string> personell = new List<string> { };
            public List<string> formations = new List<string> { };
        }

        class PlaySheets
        {
            public List<playList> Plays = new List<playList> { };
            string filename = "";

            public PlaySheets(string filename)
            {
                this.filename = filename;
            }

            // Initialize variable for worksheets
            //WorkSheet workSheet;

            // May want to change passing a filename or saving it in a constructor
            public bool ParsePlays(string fileName)
            {
                WorkSheet workSheet;

                // Error Case for if the WorkBook or WorkSheet are not valid
                try
                {
                    WorkBook workBook = WorkBook.Load(fileName);
                    workSheet = workBook.GetWorkSheet("Install__1");
                }
                catch (FileNotFoundException e) {
                    Console.WriteLine(e.ToString());
                    return false;
                }

                //if (false)
                //{
                //    return false;
                //}


                // Gets All Data between this range
                IronXL.Range myRange = workSheet.GetRange("A4:F57");

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

                            Plays.Add(new playList());

                            // Creates substring of the category name in order to add it to object
                            Plays[Plays.Count - 1].categoryName = singlePlay.ToString().Substring(0, j);
                        }

                    }
                    else if (singlePlay.IndexOf('\t') == 0 && counter > 4 && singlePlay.IndexOf('\t', 2) != 2)
                    {
                        int k = singlePlay.IndexOf("\t", 1);
                        int prevIndex = 1;

                        // Adds tags to list
                        string temp = singlePlay.Substring(prevIndex, k - 1 - prevIndex);
                        Plays[Plays.Count - 1].tags.Add(temp);

                        prevIndex = k + 2;

                        k = singlePlay.IndexOf("\t", prevIndex);

                        // Adds tags to list
                        Plays[Plays.Count - 1].personell.Add(singlePlay.Substring(prevIndex, k - 1 - prevIndex));

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
}
