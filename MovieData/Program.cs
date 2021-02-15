using System;
using System.IO;
using System.Linq;
using NLog.Web;

namespace MovieData
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";

             // create instance of Logger
             var logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();
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
                    logger.Error("File could not be found or opened");
                }
                
                
               
            }
            else if (resp == "2")
            {
                string movieID;
                string input;
                do 
                {
                    
                    Console.WriteLine("Enter 1 to add a movie");
                    Console.WriteLine("Enter 0 to stop");
                     input = Console.ReadLine();
                    if (input == "1")
                    {
                        
                        Console.WriteLine("Please enter movie title");
                        string movieTitle = Console.ReadLine();
                        bool Duplicate = false;
                        foreach (var line in File.ReadAllLines("movies.csv"))
                        {
                            
                            
                            
                            if (line.Contains(movieTitle))
                            {
                                Console.WriteLine("This movie Title already exists in data, please enter a new movie or exit");
                                 Duplicate = true;
                                break;
                            }    
                        }  
                        if (Duplicate == true)  
                        {
                            continue;
                        }
                        Console.WriteLine("Please enter the year the movie was released");
                        string movieYear = Console.ReadLine();
                        Console.WriteLine("Please enter movie Genre(s), seperate each with a comma if there are multiple");
                        string movieGenres = Console.ReadLine();
                        string[] movieGenresArr = movieGenres.Split(',');
                        int numberGenre = movieGenresArr.Length;
                        Random rnd = new Random();
                            
                        bool duplicateid = true;
                      do 
                      {
                          int movienum = rnd.Next(1,200000);
                         movieID = Convert.ToString(movienum);

                        foreach (var data in File.ReadAllLines("movies.csv"))
                        {
                            if (data.Contains(movieID))
                            {
                             duplicateid = true;
                             Console.WriteLine ("Creating new ID, ID number already exists in data");
                            }
                            else duplicateid = false;
                        }
                      }  while (duplicateid == true);    

                          try   
                          { using (StreamWriter sw = File.AppendText("movies.csv"))
                             {
                                sw.WriteLine($"{movieID},{movieTitle}({movieYear}),{string.Join("|", movieGenresArr)}");
                
                                sw.Close();
                             }	 
                            
                          } catch (FileNotFoundException)
                          {
                              Console.WriteLine("File not Found");
                              logger.Error("File could not be found or opened");
                          }
                     
                            
                    }
                        if (input =="0")
                        {
                            break;
                        }
                  
                } while(input != "0" );


            }
                

            }




        }


    }





