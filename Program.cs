using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace hangman
{
    class Program
    {
        static void artone()
        {
            Console.WriteLine("  +---+  ");
            Console.WriteLine("  |   |  ");
            Console.WriteLine("      |  ");
            Console.WriteLine("      |  ");
            Console.WriteLine("      |  ");
            Console.WriteLine("      |  ");
            Console.WriteLine("=========");

        }
        static void arttwo()
        {
            Console.WriteLine("  +---+  ");
            Console.WriteLine("  |   |  ");
            Console.WriteLine("  o   |  ");
            Console.WriteLine("      |  ");
            Console.WriteLine("      |  ");
            Console.WriteLine("      |  ");
            Console.WriteLine("=========");
        }
        static void artthree()
        {
            Console.WriteLine("  +---+  ");
            Console.WriteLine("  |   |  ");
            Console.WriteLine("  o   |  ");
            Console.WriteLine("  |   |  ");
            Console.WriteLine("      |  ");
            Console.WriteLine("      |  ");
            Console.WriteLine("=========");
        }
        static void artfour()
        {
            Console.WriteLine("  +---+  ");
            Console.WriteLine("  |   |  ");
            Console.WriteLine("  o   |  ");
            Console.WriteLine(" /|   |  ");
            Console.WriteLine("      |  ");
            Console.WriteLine("      |  ");
            Console.WriteLine("=========");
        }
        static void artfive()
        {

            Console.WriteLine("  +---+  ");
            Console.WriteLine("  |   |  ");
            Console.WriteLine("  o   |  ");
            Console.WriteLine(" /|,  |  ");
            Console.WriteLine("      |  ");
            Console.WriteLine("      |  ");
            Console.WriteLine("=========");
        }
        static void artsix()
        {
            Console.WriteLine("  +---+  ");
            Console.WriteLine("  |   |  ");
            Console.WriteLine("  o   |  ");
            Console.WriteLine(" /|,  |  ");
            Console.WriteLine(" /    |  ");
            Console.WriteLine("      |  ");
            Console.WriteLine("=========");
        }
        static void artseven()
        {
            Console.WriteLine("  +---+  ");
            Console.WriteLine("  |   |  ");
            Console.WriteLine("  o   |  ");
            Console.WriteLine(" /|,  |  ");
            Console.WriteLine(" /|   |  ");
            Console.WriteLine("      |  ");
            Console.WriteLine("=========");
        }

        static void Main(string[] args)
        {
            //string wordtest = "AKOS";
            string[] words;
            string path = @"C:\Projects\words.txt";
            words = File.ReadAllLines(path);
            start:
            List<string> answer = new List<string>();
            int counter=0;
            int get;
            bool endgame = false;
            int count;
            int place;
            Random r = new Random();
            get = r.Next(0, words.Length);

            int lives = 7;
            //Console.WriteLine(words[get]);

            for (int i = 0; i < words[get].Length; i++)
            {
                answer.Add("_ ");
                Console.Write(answer[i]);
            }


            guess:
            Console.WriteLine("\n\nyour guess");
            string guess = Convert.ToString(Console.ReadLine());
            guess = guess.ToLower();
            if (words[get].Contains(guess))
            {
                count=Regex.Matches(words[get], guess).Count;
                //Console.WriteLine(count);
                //Console.WriteLine("\n");
               
                if (count>1)
                {
                    for (int i = words[get].IndexOf(guess); i > -1; i = words[get].IndexOf(guess, i + 1))
                    {
                        answer[i] = guess;
                    }
                }

                else
                {
                    place = words[get].IndexOf(guess);
                    answer[place] = guess;
                    //Console.WriteLine(place);
                }

                foreach (var item in answer)
                {
                    Console.Write(item);
                }
                
                string test = string.Join("",answer);
                if (test==words[get])
                {
                    Console.WriteLine("\nyou win");
                    endgame = true;
                    goto end;
                }
                counter++;
                goto guess;
                
            }
            else
            {
                lives=lives - 1;
                Console.WriteLine("you have {0,1} lives left",lives);
                Console.WriteLine("\n");
                switch (lives)
                {
                    case 6:artone();break;
                    case 5:arttwo();break;
                    case 4:artthree();break;
                    case 3:artfour();break;
                    case 2:artfive();break;
                    case 1:artsix();break;
                    case 0:artseven();break;
                }
                foreach (var item in answer)
                {
                    Console.Write(item);
                }

                if (lives==0)
                {
                    
                    goto end;
                }
                goto guess;
            }
            end:
            if (endgame==true)
            {
                Console.WriteLine("\nNice job you have found it out in {0,1} guesses",counter);
                Console.WriteLine("\nwould you like to play again?");
                Console.WriteLine("if you want you shold press f");
                string again = Convert.ToString(Console.ReadLine());
                if (again=="F"||again=="f")
                {
                    goto start;
                }
            }
            else
            {
                Console.WriteLine("\ndied");
                Console.WriteLine("The world was {0,5}",words[get]);
                Console.WriteLine("\nwould you like to play again?");
                Console.WriteLine("if you want you shold press f");
                string again = Convert.ToString(Console.ReadLine());
                if (again == "F" || again == "f")
                {
                    goto start;
                }
            }
            

            Console.ReadKey();
        }
    }
}
