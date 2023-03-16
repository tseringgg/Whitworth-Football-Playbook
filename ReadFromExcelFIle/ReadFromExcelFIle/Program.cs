using System;
using IronXL;
using System.IO;

namespace ReadFromExcelFIle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(Directory.GetCurrentDirectory());


            Console.WriteLine("Enter workBook name: ");
            // Create a string variable and get user input from the keyboard and store it in the variable
            string workBookName = Console.ReadLine();

            //WorkBook workBook = WorkBook.Load(@"../../../PACIFIC_CALL_SHEET_MIX_DOWNS.xlsx");
            WorkBook workBook = WorkBook.Load(@"../../../" + workBookName + ".xlsx");


            Console.WriteLine("Enter workBook Sheet: ");
            // Create a string variable and get user input from the keyboard and store it in the variable
            string workBookSheet = Console.ReadLine();

            //WorkSheet workSheet = workBook.GetWorkSheet("CALL_SHEET_PG_1_(11x17)");
            WorkSheet workSheet = workBook.GetWorkSheet(workBookSheet);

            // TODO: Take the workBook and Sheets as input
            //       - Take the range as inputs
            //       - Write error case if the workbook and sheets are not valid


            // Gets All Data between this range
            IronXL.Range myRange = workSheet.GetRange("D4:E19");
            Console.WriteLine(myRange);



            // Gets value from all ints in the range
            //Console.WriteLine(myRange.Value);

            //for (var i = 0; i <= 4; i++)
            //{
            //    Console.WriteLine(myRange.AllColumnsInRange[i]);

            //}


        }
    }
}
