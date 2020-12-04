using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind_App
{
    class Mastermind
    {
         //Method for getting computer array.
         public int[] computerArray()
         {
            int randomNumbers = 0;
            int[] computerArray = new int[4];
            Random randomNumber = new Random();

            //looped through to add 4 numbers to array instead of manually setting them (easy to do with 4 numbers but "in case" future games want 10, etc)
            for (int i = 0; i < computerArray.Length; i++)
            {
                randomNumbers = randomNumber.Next(1, 6);
                computerArray[i] = randomNumbers;
            }

            return computerArray;
         }

        //Method for parsing user's response into an int array to make it easy to compare with computer's
        public int[] userGuessArray(string userGuess)
        {
            string[] stringArray = userGuess.Split(" ");
            int[] userArray = new int[stringArray.Length];

            for (int i = 0; i < stringArray.Length; i++)
            {
                userArray[i] = int.Parse(stringArray[i]);
            }
            return userArray;

        }

        //main method used for this app, compares the two arrays 
        public string CompareArrays (int[] userGuessArray, int[] computerArray)
        {
            //set 4 bools to check first for right answers
            bool zeroCorrect = false;
            bool oneCorrect = false;
            bool twoCorrect = false;
            bool threeCorrect = false;

            //empty strings to build the correct string response
            string responsePlus = "";
            string responseMinus = "";
            string responseBlank = "";

            //first loop checks to see if there are correct answers and flips the bool statement to true
            //tried a foreach loop but it ended up setting all to true if one was
            for (int i = 0; i < computerArray.Length; i++)
            {
                //use i == i just to make sure the compiler was always comparing the right numbers and not submitting 
                //dupilicates to the response strings
                if (userGuessArray[0] == computerArray[0] && i == 0)
                {
                    responsePlus += "+";
                    zeroCorrect = true;
                }
                if (userGuessArray[1] == computerArray[1] && i == 1)
                {
                    responsePlus += "+";
                    oneCorrect = true;
                }
                if (userGuessArray[2] == computerArray[2] && i == 2)
                {
                    responsePlus += "+";
                    twoCorrect = true;
                }
                if (userGuessArray[3] == computerArray[3] && i == 3)
                {
                    responsePlus += "+";
                    threeCorrect = true;
                }
            }

            /*the second loop is based off of the flipping of the bools from the first loop and then
             specifically compares the numbers to build the remaining responses
             I initially had an else statement at the end of this loop for blanks but it was causing additional responses
             to get logged and needed to be within each comparison

             Intially I had one loop for this method but was running into issues with wrong responses if an number fell
             into multiple groups, ie was correct and also in another spot. 
            */

            for (int i = 0; i < computerArray.Length; i++)
            {
                if (!zeroCorrect && i == 0)
                {
                    if ((!oneCorrect && userGuessArray[0] == computerArray[1]) || (!twoCorrect && userGuessArray[0] == computerArray[2]) || (!threeCorrect && userGuessArray[0] == computerArray[3]))
                    {
                        responseMinus += "-";
                    }
                    else
                    {
                        responseBlank += "_";
                    }
                }
                if (!oneCorrect && i == 1)
                {
                    if ((!zeroCorrect && userGuessArray[1] == computerArray[0]) || (!twoCorrect && userGuessArray[1] == computerArray[2]) || (!threeCorrect &&  userGuessArray[1] == computerArray[3]))
                    {
                        responseMinus += "-";
                    }
                    else
                    {
                        responseBlank += "_";
                    }

                }
                if (!twoCorrect && i == 2)
                {
                    if ((!oneCorrect && userGuessArray[1] == computerArray[2]) || (!zeroCorrect && userGuessArray[0] == computerArray[2]) || (!threeCorrect && userGuessArray[2] == computerArray[3]))
                    {
                        responseMinus += "-";
                    }
                    else
                    {
                        responseBlank += "_";
                    }
                }
                if (!threeCorrect && i == 3)
                {
                    if ((!oneCorrect && userGuessArray[1] == computerArray[3]) || (!twoCorrect && userGuessArray[3] == computerArray[2]) || (!zeroCorrect && userGuessArray[0] == computerArray[3]))
                    {
                        responseMinus += "-";
                    }
                    else
                    {
                        responseBlank += "_";
                    }
                }
                
                
            }

            //return the response strings in the order specified in the problem
            return $"{responsePlus}{responseMinus}{responseBlank}";
        }



        /* Below is a Method that I wrote when the above Method was soley collecting the +, -, & _ and resulting in an array
         * I ended up combining the two into the Method in my Refactoring. I left it to show previous work if it helps see my
         * thought process.

        public string ResponseCounter(string[] responseArray)
        {

                string responseMinus = "";
                string responseBlank = "";
                string responsePlus = "";


                for (int i = 0; i < responseArray.Length; i++)
                {
                      if (responseArray[i] == "+")
                     {
                        responsePlus = responseArray[i] + responsePlus;
                      } 
                      else if (responseArray[i] == "-")
                      {
                        responseMinus = responseArray[i] + responseMinus;
                      }
                      else if (responseArray[i] == "_")
                      {
                        responseBlank = responseArray[i] + responseBlank;
                      }

                }
                return $"{responsePlus}{responseMinus}{responseBlank}";

        }
        */
    }
}
