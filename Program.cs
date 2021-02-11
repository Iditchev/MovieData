using System;
using System.IO;
using System.Linq;

namespace MovieData
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
                    string movieID = arr[0];
                    
                    string genres = arr[arr.Length-1];
                    string[] arrgenres = genres.Split('|');

                    

                    // display array data
                    int i;
                    for (i = 0; i < arr.Length-1; i ++)
                    {
                        Console.Write("{0,-15}",arr[i]);
                    }
                        int j;
                        for(j = 0; j < arrgenres.Length; j ++)
                        {
                            Console.Write("{0,3}",arrgenres[j]);
                        }
                    
                    
                    
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
    


