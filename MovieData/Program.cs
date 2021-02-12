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
                try
                {
                StreamReader sr = new StreamReader("movies.csv");
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] arr = line.Split(',');
                    string movieID = arr[0];

                    string genres = arr[arr.Length - 1];
                    string[] arrgenres = genres.Split('|');



                    // display array data
                    Console.Write("{0,-10}", movieID);
                    int i;
                    for (i = 1; i < arr.Length - 1; i++)
                    {
                        Console.Write("{0,10}", arr[i]);
                    }
                    int j;
                   for (j = 0; j < arrgenres.Length; j++)
                    {
                        Console.Write("{0,10}", arrgenres[j]);
                   }

                    Console.WriteLine();
                }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File could not be found or opened");
                }
                
                
               
            }
            else if (resp == "2")
            {
                int result;
                do 
                {
                    
                    Console.WriteLine("Enter 1 to add a movie");
                    Console.WriteLine("Enter 0 to stop");
                    bool input = Int32.TryParse(Console.ReadLine(), out result);
                    if (input)
                    {
                        Console.WriteLine("Please enter movie title");
                        string movieTitle = Console.ReadLine();
                        Console.WriteLine("Please enter the year the movie was released");
                        string movieYear = Console.ReadLine();
                        Console.WriteLine("Please enter movie Genre(s), seperate each with a comma if there are multiple");
                        string movieGenres = Console.ReadLine();
                        string[] movieGenresArr = movieGenres.Split(',');
                    }
                } while(result == 0 );


            }
                

            }




        }


    }





