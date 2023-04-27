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

        //static void ReadJson()
        //{
        //    string text = File.ReadAllText(@"./db.json");
        //    var play = JsonSerializer.Deserialize<Play>(text);

        //    Console.WriteLine($"Full_Play: {play.Full_Play}");

        //    //Console.WriteLine($"QB_pos: {play.qb}");
        //    //Console.WriteLine($"H_pos: {play.h}");
        //    //Console.WriteLine($"X_pos: {play.x}");
        //    //Console.WriteLine($"Y_pos: {play.y}");
        //    //Console.WriteLine($"Z_pos: {play.z}");
        //}

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



            WorkBook workBook = WorkBook.Load(@"../../../PACIFIC_CALL_SHEET_MIX_DOWNS.xlsx");
            WorkSheet workSheet = workBook.GetWorkSheet("CALL_SHEET_PG_1_(11x17)");

            // TODO: 
            //       - Write error case if the workbook and sheets are not valid


            // Gets All Data between this range
            IronXL.Range myRange = workSheet.GetRange("D4:E4");

            //Console.WriteLine(myRange.ToString());

            string[] rows = myRange.ToString().Split(new char[] { '\n' });

            List<List<string>> plays = new List<List<string>>();
            List<string> singlePlay = new List<string>();


            string[] splitSinglePlay;

            for (int i = 0; i < rows.Length; i++)
            {

                singlePlay.Add(rows[i]);
                splitSinglePlay = singlePlay[i].Split(' ', '\t', '\r');
                List<string> temp = new List<string>();
                foreach (string s in splitSinglePlay)
                {
                    temp.Add(s);
                }

                // TODO: Try to add empty lists to "plays" so I can add "Split Single Play" to them
                plays.Add(temp); // Adds an empty list to plays to get ready to add TempVect Elements in that spot



            }


            // Prints the contents of the 2D List "play"
            for (int j = 0; j < plays.Count; j++)
            {
                for (int k = 0; k < plays[j].Count; k++)
                {
                    Console.Write(plays[j][k] + " ");
                }
                Console.WriteLine();
            }


            // Store Deserialized object from JSON - https://www.youtube.com/watch?v=cGKA8wRCA0A
            var plays_data = JSONresponse();
            if (plays_data != null)
            {
                for (int i = 0; i < plays_data.Count; i++)
                {
                    System.Diagnostics.Debug.Print(plays_data[i].Full_Play);
                }


            }

            static List<Play> JSONresponse()
            {
                string JSONFileName = "../../../test.json";
                if (File.Exists(JSONFileName))
                {
                    var plays = JsonConvert.DeserializeObject<List<Play>>
                                (File.ReadAllText(JSONFileName));

                    return plays;
                }

                return null;
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
            List<Play> Plays;
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
