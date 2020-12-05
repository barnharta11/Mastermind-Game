using Figgle;
using System;

namespace Mastermind_App
{
    class Program
    {
        static void Main(string[] args)
        {

            Mastermind mastermind = new Mastermind();

            //Print Welcome
            mastermind.PrintInstructions();

            //bool correctGuess = true;
            //bool validated = true;
            bool keepPlaying = true;

            while (keepPlaying)
            {
                //Game Setup
                int[] computerGuessArray = mastermind.ComputerArray();
                int remainingAttempts = 10;
                string rightAnswer = "++++";

                while (remainingAttempts >= 0)
                {
                    mastermind.PrintInputGuess(remainingAttempts);

                    string userGuess = Console.ReadLine();

                    if (mastermind.CheckGuess(remainingAttempts, userGuess) && mastermind.ValidateInput(remainingAttempts, userGuess))
                    {
                        string response = mastermind.CompareArrays(computerGuessArray, userGuess);

                        //checking to see if the user's results contain the right answer (when I moved this to a seperate method, it wasn't subtracting attempts)
                        if (response.Contains(rightAnswer))
                        {
                            mastermind.CorrectAnswer(computerGuessArray, keepPlaying, response, remainingAttempts);
                        }
                        else if (!response.Contains(rightAnswer) && remainingAttempts == 1)
                        {
                            mastermind.OutOfTries(keepPlaying, remainingAttempts);
                        }
                        else if (!response.Contains(rightAnswer) && remainingAttempts > 1)
                        {
                            remainingAttempts--;
                            mastermind.WrongAnswer(remainingAttempts, response);
                        }

                    }

                }


                //Below is my attempt to follow your flow suggestions, it got stuck in an infinite loop when ran


                /*while (keepPlaying)
                {
                    mastermind.PrintInputGuess(remainingAttempts);

                    //Loop for Game
                    while (remainingAttempts >= 0 && !correctGuess)
                    {


                        do
                        {
                            mastermind.GetGuess(remainingAttempts);
                            validated = mastermind.ValidateInput(remainingAttempts);
                        } while (!validated);

                        response = mastermind.CompareArrays(computerGuessArray);

                        //checking to see if the user's results contain the right answer
                        mastermind.PrintResults(response, rightAnswer, computerGuessArray, remainingAttempts, keepPlaying);
                        correctGuess = response.Contains(rightAnswer);

                     }
                   } */



            }

        }
    }
}
