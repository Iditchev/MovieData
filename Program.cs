using System;
using System.IO;
using System.Linq;

namespace SleepData
{
    class Program
    {
        static void Main(string[] args)
        {
            // ask for input
            Console.WriteLine("Enter 1 to list movie collection.");
            Console.WriteLine("Enter 2 to add movie to collection.");
            Console.WriteLine("Enter anything else to quit.");
            // input response
            string resp = Console.ReadLine();

            if (resp == "1")
            {
           StreamReader sr = new StreamReader("movies.csv");
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] arr = line.Split(',');
                    string week = arr[0];
                    DateTime sleepweek = Convert.ToDateTime(week);
                    string hours = arr[1];
                    string[] numbers = hours.Split('|');
                    int[] newnumbers = Array.ConvertAll(numbers, int.Parse);
                    double total = newnumbers.Sum();
                    double average = (total / 7);

                    // display array data
                    
                    Console.WriteLine("Week Of {0:MMM}, {0:dd}, {0:yyyy}", sleepweek);
                    Console.WriteLine(" Mo Tu We Th Fr Sa Su Tot Avg");
                    Console.WriteLine(" -- -- -- -- -- -- -- --- ---");
                    Console.WriteLine("{0,3}{1,3}{2,3}{3,3}{4,3}{5,3}{6,3} {7,3} {8,4:N1}", numbers[0], numbers[1], numbers[2], numbers[3], numbers[4], numbers[5], numbers[6], total, average);
            }
            else if (resp == "2")
            {

                // read data from file
                

                }
                sr.Close();

            }




        }


    }
}
    


