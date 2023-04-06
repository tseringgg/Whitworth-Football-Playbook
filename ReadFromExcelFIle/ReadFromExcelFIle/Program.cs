using System;
using IronXL;
using System.IO;
using System.Collections.Generic;

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



            WorkBook workBook = WorkBook.Load(@"../../../PACIFIC_CALL_SHEET_MIX_DOWNS.xlsx");
            WorkSheet workSheet = workBook.GetWorkSheet("CALL_SHEET_PG_1_(11x17)");

            // TODO: 
            //       - Write error case if the workbook and sheets are not valid


            // Gets All Data between this range
            IronXL.Range myRange = workSheet.GetRange("D4:E19");

            //Console.WriteLine(myRange.ToString());

            string[] rows = myRange.ToString().Split(new char[] {'\n'});

            List<List<string>> plays = new List<List<string>>(15);
            List<string> singlePlay = new List<string>();
            List<string> temp = new List<string>();

            string[] splitSinglePlay;

            //Console.Write(rows.Length);

            for (int i = 0; i < rows.Length; i++) {
        
                singlePlay.Add(rows[i]);
                splitSinglePlay = singlePlay[i].Split(' ', '\t');

                // TODO: Try to add empty lists to "plays" so I can add "Split Single Play" to them
                //plays.Add(temp); // Adds an empty list to plays to get ready to add TempVect Elements in that spot


                // TODO: Fix Temp getting populated with splitSinglePlay somehow

                for (int j = 0; j < splitSinglePlay.Length; j++) {

                    // Adds the list "split single play" to the list "play" 
                    plays[i].Add(splitSinglePlay[j]);
                }

                // TODO: Need to Reset/Clear TempVect right here

                Console.WriteLine();
                //temp.Clear();
   
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
            
        }
    }
}


//plays.Add();
// Add an empty array
//Console.Write(singlePlay[i]);
//if (singlePlay[i] is string) {
//    Console.Write("SinglePlay is a string");
//}

//Console.Write("Temp Vect: " + tempVect);

//for (int i = 0; i < singlePlay.Count; i++)
//{
//    tempString = singlePlay[i];
//    tempString.Split(' ', '\t');
//    //plays.Add(tempString.Split(' ', '\t'));

//    Console.WriteLine("Temp String: " + tempString);

//    // TODO: NEED TO FIGURE OUT HOW TO ADD tempString TO 2D VECT "plays"

//    //for (int j = 0; j < singlePlay[i].Length; j++)
//    //{

//    //    Console.Write(singlePlay[i][j]);
//    //}
//    ////Console.Write
//    //Console.WriteLine();

//}

//Console.WriteLine(rows[0].Length);

//int k = 0;
//for (int i = 0; i < rows.Length; i++)
//{

//}


//Console.WriteLine("Plays Count: " + plays.Count);

//for (int i = 0; i < plays.Count; i++) {
//    Console.WriteLine(plays[0][i]);
//}





//for (int i = 0; i < plays.Count; i++) {
//    for (int j = 0; j < plays.Count; j++) {
//        Console.Write(plays[i][j] + " ");
//    }
//    Console.WriteLine();
//}

//foreach (List<string> i in plays)
//{
//    foreach (string j in i)
//    {
//        Console.Write(j + " ");
//    }
//    Console.WriteLine();
//}

// Gets value from all ints in the range
//Console.WriteLine(myRange.Value);

//for (var i = 0; i <= 4; i++)
//{
//    Console.WriteLine(myRange.AllColumnsInRange[i]);

//}
