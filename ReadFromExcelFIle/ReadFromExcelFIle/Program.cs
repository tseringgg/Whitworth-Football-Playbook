using System;
using IronXL;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace ReadFromExcelFIle
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(Directory.GetCurrentDirectory());


            // TAKE WORKBOOK NAME AND SHEET AS INPUT.

            //Console.WriteLine("Enter workBook name: ");
            //// Create a string variable and get user input from the keyboard and store it in the variable
            //string workBookName = Console.ReadLine();
            //WorkBook workBook = WorkBook.Load(@"../../../" + workBookName + ".xlsx");


            //Console.WriteLine("Enter workBook Sheet: ");
            //// Create a string variable and get user input from the keyboard and store it in the variable
            //string workBookSheet = Console.ReadLine();
            //WorkSheet workSheet = workBook.GetWorkSheet(workBookSheet);


            // TAKE RANGE AS INPUT

            //Console.WriteLine("Enter First Element of Range: ");
            //string range1 = Console.ReadLine();

            //Console.WriteLine("Enter First Element of Range: ");
            //string range2 = Console.ReadLine();

            //string range = range1 + ":" + range2;
            //IronXL.Range myRange = workSheet.GetRange(range);



            WorkBook workBook = WorkBook.Load(@"../../../Spring_Football_2023.xlsx");
            WorkSheet workSheet = workBook.GetWorkSheet("Install_1");

            // TODO: 
            //       - Write error case if the workbook and sheets are not valid


            // Gets All Data between this range
            IronXL.Range myRange = workSheet.GetRange("A4:F57");

            //Console.WriteLine(myRange.ToString());

            string[] rows = myRange.ToString().Split(new char[] { '\n' });

            List<List<string>> plays = new List<List<string>>();
            List<string> singlePlay = new List<string>();


            string[] splitSinglePlay;

            for (int i = 0; i < rows.Length; i++)
            {

                singlePlay.Add(rows[i]);
                splitSinglePlay = singlePlay[0].Split(' ', '\t', '\r');
                List<string> temp = new List<string>();
                //List<string> temp2 = new List<string>();
                string temp2 = "";

                for (int j = 0; j < splitSinglePlay.Length; j++) {
                    if (splitSinglePlay[j] != "")
                    {
                        temp2 = splitSinglePlay[j];
                        //temp2.Add(singlePlay[j]);


                        //singlePlay[j] = "";
                        //singlePlay.Remove(singlePlay[j]);
                        //j--;
                        temp.Add(temp2);
                    }
                    
                    
                }


                //foreach (string s in splitSinglePlay)
                //{
                //    if (s == "\t") {
                //        s = "";
                //    }
                //    temp.Add(s);
                //}

                // TODO: Try to add empty lists to "plays" so I can add "Split Single Play" to them
                plays.Add(new List<string>(temp)); // Adds an empty list to plays to get ready to add TempVect Elements in that spot
                temp.Clear();
                singlePlay.Clear();
                temp2 = "";
            }

            //playContents currPlayContents = null;
            //List<playContents> playContentList = null;
            //// Prints the contents of the 2D List "play"
            //for (int j = 0; j < plays.Count; j++)
            //{
                
            //    if (j == 0) { continue; }
            //    if (plays[j].Count == 0) {
            //        if (currPlayContents != null) {
            //            playContentList.Add(currPlayContents);
            //        }
            //        currPlayContents = new playContents();

            //    }
            //    else if (plays[j - 1].Count == 0) {
            //        currPlayContents.categoryName = plays[j].ToString();
            //    }
            //    else {
            //        for (int k = 0; k < plays[j].Count; k++)
            //        {
            //            if (plays[j][k] == oneoftheformaitons) { }
            //        }
            //        currPlayContents.formation.Add(plays[j]);
            //    }


            //    // Add to object attributes formation & concept until list itself is count = 0 --> Then we want to reset object category name

            //}


            // TODO: Fix parser to just take in each column in the excel file as a string in a list


            // Prints the contents of the 2D List "play"
            for (int j = 0; j < plays.Count; j++)
            {
                for (int k = 0; k < plays[j].Count; k++)
                {
                    Console.Write(plays[j][k] + " ");
                }
                Console.WriteLine();
            }



        }

        public class playContents {
            public List<string> formation;
            public List<string> concept;
            public string categoryName;
            public playContents()
            {
                    
            }

        }

        class Play_1 {
            // "side" = left/right, "strength" = strong/weak

            //string formation, side, strength, passProtection, passDescription;
            string qb, h, x, y, z;

            // Name with underscore is the actual object for player coordinates
            Player qb_, rb_, x_, y_, z_, h_;

            //Play(List<string> plays) {
            //    //plays[0]
            //}

            void QueryPlayer () {

            }

            void GenerateVSDX() {

            }

        }


        struct Player {
            float x, y;
            List<List<float>> arrowSteps;
        }



        class PlaySheet {
            List<Type> Plays;
            string filename;

            PlaySheet(string filename) {
                this.filename = filename;
            }


            // May want to change passing a filename or saving it in a constructor
            void ParsePlays(string fileName) {

            }

            void ParsePlays() {
                ParsePlays(filename);
            }
        }



    }
}
