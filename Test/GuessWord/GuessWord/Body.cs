using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuessWord
{
    class Body
    {
       public static string Guessed { get; set; }
       public static WordGenerator wordGen = new WordGenerator();
       public string word { get; set; }
        public Body()
        {
           
            
        }
        internal void SetGuess()
        {
            Guessed = "";
            for (int i = 0; i < word.Length; i++)
            {
                Guessed += "*";
            }
        }
        public void GameStart()
        {
            word = wordGen.Generate();
            SetGuess();
            Console.WriteLine("Welcome!");
            Console.WriteLine("The word You Require to Guess is: {0}!",Guessed);
            bool isComplete = false;
            char c='*';
            do
            {
                try
                {
                    Console.WriteLine("Pick a letter to guess");
                     c = Convert.ToChar(Console.ReadLine());
                }
                catch (FormatException)
                {

                    Console.WriteLine("Please choose a single letter");
                }
                finally
                {
                    if (word.Contains(c))
                    {
                        Swap(c);
                        Console.WriteLine("Correct!");
                        Console.WriteLine(Guessed);
                        if (IsWinner())
                        {
                            isComplete = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong! try again!");
                    }
                }
                
            } while (!isComplete);
            if (isComplete)
            {
                TryAgain();
            }

        }

        private void TryAgain()
        {
            bool response = true;
            do
            {
                Console.WriteLine("Game Over Play Again? Y/N");
                string s = string.Empty; ;
                try
                {
                    s = Console.ReadLine();
                    if (s.ToUpper() == "Y")
                        GameStart();
                    else
                    if (s.ToUpper() == "N")
                    {
                        Console.WriteLine("Bye Bye");
                        Thread.Sleep(500);
                        Environment.Exit(0);

                    }
                    else
                    {
                        Console.WriteLine("Please Select A Valid Option");
                        response = false;
                    }
                }
                catch (Exception)
                {
                    response = false;
                }
            } while (!response);
            
        }

        private bool IsWinner()
        {
            if (word == Guessed)
            {
                return true;
            }
            return false;
        }

         private void Swap(char c)
        {

            List<int> indexers = new List<int>();
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == c)
                {
                    indexers.Add(i);
                }
            }

            int index = word.IndexOf(c);
            StringBuilder sb = new StringBuilder(Guessed);
            indexers.ForEach(i => sb.Replace('*', c, i, 1));
            sb.Replace('*', c, index, 1);
            Guessed = sb.ToString();
        } 

    }
}
