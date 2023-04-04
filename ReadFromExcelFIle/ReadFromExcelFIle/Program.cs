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

            string[] rows = myRange.ToString().Split(new char[] { ' ', '\n', '\t' });

            List<List<string>> plays = new List<List<string>>();
            List<string> singlePlay = new List<string>();

            //Console.WriteLine(rows[0].Length);

            for (int i = 0; i < rows.Length; i++)
            {
                if(rows[i] == "GUN" && i != 0)
                {
                    plays.Add(singlePlay);
                    Console.WriteLine("Full Play = " + singlePlay);
                    singlePlay.Clear();
                    Console.WriteLine();
                }
                singlePlay.Add(rows[i]);
            }
            plays.Add(singlePlay);

            //Console.WriteLine(plays[0]);

            foreach (List<string> i in plays)
            {
                foreach (string j in i)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }




            // Gets value from all ints in the range
            //Console.WriteLine(myRange.Value);

            //for (var i = 0; i <= 4; i++)
            //{
            //    Console.WriteLine(myRange.AllColumnsInRange[i]);

            //}


        }
    }
}
