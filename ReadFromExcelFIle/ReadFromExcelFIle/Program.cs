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

            WorkBook workBook = WorkBook.Load(@"../../../PACIFIC_CALL_SHEET_MIX_DOWNS.xlsx");
            WorkSheet workSheet = workBook.GetWorkSheet("CALL_SHEET_PG_1_(11x17)");

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
