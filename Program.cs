using System;
using System.Collections.Generic;



//Գրիր ծրագիր,որը ստեղծում է մեծ քանակությամբ օբյեկտներ,անջատում reference-ները և կանչում GC.Collect()։Տպիր GC.GetGeneration() արդյունքները։
namespace GC_Demo
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x,int y)
        {
            X = x;
            Y = y;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<Point> points = new List<Point>();

            for(int i = 0; i < 60000; i++)
            {
                points.Add(new Point(i,i));
            }


            Console.WriteLine($"Gen: {GC.GetGeneration(points[5000])}"); // 0


            for (int i = 0; i < 60000; i++)
            {
                points[i] = null;
            }



            GC.Collect(); 
            GC.WaitForPendingFinalizers();

            // Console.WriteLine($"Gen: {GC.GetGeneration(points[5000])}"); Exception
        }
    }
}
