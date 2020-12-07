using Figgle;
using System;

namespace Mastermind_App
{
    class Program
    {
        static void Main(string[] args)
        {
            //new instance of Mastermind class to use in program
            Mastermind mastermind = new Mastermind();

            //Print Instructions
            mastermind.PrintInstructions();

            //statement that keeps player in the game
            bool keepPlaying = true;
            
            //loop keeping player in the game
            while (keepPlaying)
            {
                //Game Setup
                int[] computerGuessArray = mastermind.ComputerArray();
                Console.WriteLine($"Computer Numbers were ({computerGuessArray[0]}, {computerGuessArray[1]}, {computerGuessArray[2]}, {computerGuessArray[3]})");
                int remainingAttempts = 10;
                
                //loop keeping track of attempts
                while (remainingAttempts > 0)
                {
                    //asks user for guess input
                    mastermind.PrintInputGuess(remainingAttempts);

                    //gathers user input
                    string userGuess = Console.ReadLine();

                    //checks user guess to make sure it has correct format
                    if (mastermind.CheckGuess(remainingAttempts, userGuess) && mastermind.ValidateInput(remainingAttempts, userGuess))
                    {
                        //if it does, it runs through CompareArrays() and results in a string of +,-, _
                        string response = mastermind.CompareArrays(computerGuessArray, userGuess);
                        
                        //checks for correct answer
                        if (mastermind.CorrectAnswer(computerGuessArray, response))
                        {
                            //if answer is correct, it displays and then fires up PlayAgain()
                            //sets remainingAttempts to 0 to exit second loop and refresh game if user chooses
                            keepPlaying = mastermind.PlayAgain();
                            remainingAttempts = 0;
                        }
                        else if (mastermind.OutOfTries(remainingAttempts))
                        {
                            //displays out of attempts and then fires up PlayAgain()
                            //sets remainingAttempts to 0 to exit second loop and refresh game if user chooses
                            keepPlaying = mastermind.PlayAgain();
                            remainingAttempts = 0;

                        }
                        else
                        {
                            //displays that answer is incorrect and response string for next guess
                            remainingAttempts--;
                            mastermind.WrongAnswer(remainingAttempts, response);
                        }

                    }

                }


            }

        }
    }
}
