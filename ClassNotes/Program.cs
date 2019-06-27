using System;
using System.Diagnostics;

namespace ClassNotes
{
    class Program
    {
        static int GetIntegerFromUser(string question)
        {
            int integerFromUser;
            bool success;
            do
            {
                Console.WriteLine(question);
                string userResponse = Console.ReadLine();
                success = int.TryParse(userResponse, out integerFromUser);
            } while (success == false);

            return integerFromUser;
        }

        static void GiveUserARandomInsults(string[] availableInsults)
        {
            Random random = new Random();
            int insultIndex = random.Next(0, availableInsults.Length);
            string insult = availableInsults[insultIndex];
            Console.WriteLine(insult);
        }

        static void RespondToIncorrectGuess(string[] InsultsToBeUsed,string highLowHint)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(highLowHint);
            GiveUserARandomInsults(InsultsToBeUsed);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Let's play a guessing game!");
            int max = GetIntegerFromUser("What max range would you like?");

            Random rnd = new Random();
            int secretNumber = rnd.Next(1, max +1);

            string[] insults = {
                "You are stupid!!",
                "When were you born, yesterday",
                "Your mom had the same answer",
                "How long did that stupid mistake take",
                "Wooowww you need help",
                "Try"+ (secretNumber ++) + ".No really, you should try it."
            };
            int score = 0;
            int guess;
            bool shouldLaunchVideo = true;
            do
            {
                Console.ResetColor();
                
                Console.WriteLine("Your current score is " + score);
                guess = GetIntegerFromUser("Please guess a number between 1-" + max + ":");

                if (guess > max || guess < 1)
                {
                    Console.WriteLine("Is guessing really that Hard?");
                    score += 10;

                    if (shouldLaunchVideo == true)
                    {
                        shouldLaunchVideo = false;
                        System.Threading.Thread.Sleep(4000);
                        Process.Start("open", "https://www.youtube.com/watch?v=PV3_UHG73oQ");
                    }
                }
                else
                {
                    if (guess > secretNumber)
                    {
                        RespondToIncorrectGuess(insults, "You were too high, loser!");
                        score++;
                    }
                    else if (guess < secretNumber)
                    {
                        RespondToIncorrectGuess(insults, "You were too low, loser!");
                        score++;
                    }
                }    
               
            } while (guess != secretNumber);
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You finally got it!");
                Console.WriteLine("Your final score was " + score);
                Console.WriteLine("The Secret Number was " + secretNumber);
            
        }
    }
}
