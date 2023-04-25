using System;
using IronXL;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Newtonsoft.Json;
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

            string[] rows = myRange.ToString().Split(new char[] {'\n'});

            List<List<string>> plays = new List<List<string>>();
            List<string> singlePlay = new List<string>();
            

            string[] splitSinglePlay;

            for (int i = 0; i < rows.Length; i++) {
        
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


            string _sampleJsonFilePath = "../../../db.json";

            // Read and Parse a JSON File Using JsonTextReader in Newtonsoft.Json
            var serializer = new Newtonsoft.Json.JsonSerializer();
            //List<List<Play>> play = new List<List<Play>>();
            List<ResponseData> play = new List<ResponseData>();
            using (var streamReader = new StreamReader(_sampleJsonFilePath))
            using (var textReader = new JsonTextReader(streamReader))
            {
                // "play" is a list of the data from JSON
                play = serializer.Deserialize<List<ResponseData>>(textReader);
            }

            Console.WriteLine(play);

        }

        //public class ReadAndParseJsonFileWithNewtonsoftJson
        //{
        //    private readonly string _sampleJsonFilePath;
        //    public ReadAndParseJsonFileWithNewtonsoftJson(string sampleJsonFilePath)
        //    {
        //        _sampleJsonFilePath = sampleJsonFilePath;
        //    }
        //}

        //public List<Play> UseUserDefinedObjectWithNewtonsoftJson()
        //{
        //    using StreamReader reader = new(_sampleJsonFilePath);
        //    var json = reader.ReadToEnd();
        //    List<Teacher> teachers = JsonConvert.DeserializeObject<List<Teacher>>(json);
        //    return teachers;
        //}

        class ResponseData {
            public Play Full_Play { get; set; }

            public Play Formation { get; set; }
            public Play Concept { get; set; }
            public Play Motion { get; set; }
            public Play Protection { get; set; }
            public Play Tags { get; set; }
            public Play Routes { get; set; }
        }

        class Play {
            // "side" = left/right, "strength" = strong/weak
            //public string qb { get; set; }
            //public string h { get; set; }
            //public string x { get; set; }
            //public string y { get; set; }
            //public string z { get; set; }

            //public string Formation { get; set; }
            //public string Concept { get; set; }
            //public string Motion { get; set; }
            //public string Protection { get; set; }
            //public string Tags { get; set; }
            //public string Routes { get; set; }



            //public string strength { get; set; }
            //public string passProtection { get; set; }
            //public string passDescription { get; set; }
            //public string formation { get; set; }
            //public string side { get; set; }

            //string formation, side, strength, passProtection, passDescription;
            string qb, h, x, y, z;

            // Name with underscore is the actual object for player coordinates
            Player qb_, rb_, x_, y_, z_, h_;

            Play(List<string> plays) {
                //plays[0]
            }

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
