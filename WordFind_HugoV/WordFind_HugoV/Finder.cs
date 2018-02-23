using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WordFind_HugoV
{
    class Finder
    {
        private Dictionary<char, List<string>> hash;                                                            //Private Dictionary
        private Puzzle puz;                                                                                     //Private Puzzle reference
        private List<int> indexList;                                                                            //Private list for positions
        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: Finder
        ///  Method return type: constructor
        ///  Parameters: Puzzle puzzle
        ///  Synopsis: This Method is initialize this object
        ///  Updates: November 10, 2017:
        ///              -Initialization
        ///===============================================================================================================================
        public Finder(Puzzle puzzle)
        {
            puz = puzzle;                                                                                       //Set the actual puzzle to the referene
            hash = new Dictionary<char, List<string>>();                                                        //Declare the Dictionary
            indexList = new List<int>();
        }

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: BuildDictionary
        ///  Method return type: void
        ///  Parameters: None
        ///  Synopsis: This method will build the dictionary with the first letter as key
        ///            and its proper words as a value
        ///  Updates: November 10, 2017:
        ///              -Initialization        
        ///===============================================================================================================================
        private void BuildDictionary()
        {
            byte wordCounter = 0;                                                                               //Declare a local byte
            for (byte wordIndex = 0; wordIndex < puz.words.Count(); wordIndex++)                                //Add once the first letter of the words in 
            {                                                                                                   //the list (a char map key)
                if (!hash.ContainsKey(puz.words[wordIndex].ElementAt(0)))                                       //If the key is not already in the Dictionary
                {
                    //Add every words starting with that same letter
                    List<string> words = new List<string>();                                                    //Declare a local list
                    wordCounter = wordIndex;                                                                    //Set the index
                    while (wordCounter + 1 != puz.words.Count() &&
                        puz.words[wordCounter].ElementAt(0) == puz.words[wordCounter + 1].ElementAt(0))         //Get every word starting with the same
                    {                                                                                           //letter as the key
                        words.Add(puz.words[wordCounter]);                                                      //Add the word to the list
                        wordCounter++;                                                                          //Increment the counter
                    }
                    words.Add(puz.words[wordCounter]);                                                          //Add the last word of the same letter
                    hash.Add(puz.words[wordIndex].ElementAt(0), words);                                         //Add the key and the value to the Dictionary
                }
            }
        }

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: FindWords
        ///  Method return type: void
        ///  Parameters: None
        ///  Synopsis: This method will find all the words the puzzle 
        ///  Updates: November 10, 2017:
        ///              -Initialization        
        ///           November 22, 2017:
        ///              -For loops
        ///===============================================================================================================================
        public void FindWords(ref List<int> list)
        {
            BuildDictionary();                                                                                  //Builds the Dictionary
            char letter = ' ';                                                                                  //Declare a local char
            string tempCheck = "";                                                                              //Declare a local string
            var timer = Stopwatch.StartNew();                                                                   //Start a timer
            for (ushort row = 0; row < puz.GetRow(); row++){                                                    //For every row
                for (ushort col = 0; col < puz.GetColumn(); col++){                                             //For every column
                    tempCheck = "";                                                                             //Reset the string to null
                    letter = puz.letters[row].ElementAt(col);                                                   //Get the corresponding character in the list
                    tempCheck += letter;                                                                        //Then add it to the string
                    foreach (var item in hash){                                                                 //For every key in the Dictionary (first letter)
                        if (tempCheck.ElementAt(0).Equals(item.Key)){                                           //Check if the current letter is part of the keys
                            for (byte word = 0; word < item.Value.Count(); word++){                             //If yes, check for words that starts with that letter
            /*DOWN RIGHT*/      CheckDirection(1, 1, (short)col, (short)row, item.Value[word], tempCheck, "DOWN RIGHT", ref list);
            /*DOWN LEFT*/       CheckDirection(-1, 1, (short)col, (short)row, item.Value[word], tempCheck, "DOWN LEFT", ref list);
            /*UP RIGHT*/        CheckDirection(1, -1, (short)col, (short)row, item.Value[word], tempCheck, "UP RIGHT", ref list);
            /*UP LEFT*/         CheckDirection(-1, -1, (short)col, (short)row, item.Value[word], tempCheck, "UP LEFT", ref list);
            /*RIGHT*/           CheckDirection(1, 0, (short)col, (short)row, item.Value[word], tempCheck, "RIGHT", ref list);
            /*LEFT*/            CheckDirection(-1, 0, (short)col, (short)row, item.Value[word],tempCheck, "LEFT", ref list);
            /*DOWN*/            CheckDirection(0, 1, (short)col, (short)row, item.Value[word], tempCheck, "DOWN", ref list);       
            /*UP*/              CheckDirection(0, -1, (short)col, (short)row, item.Value[word], tempCheck, "UP", ref list);
                            }
                        }
                    }
                }
            }
            timer.Stop();                                                                                       //Stop the timer
            Console.WriteLine("It took    " + timer.Elapsed.TotalMilliseconds.ToString() + "      milliseconds to solve this puzzle!");//Display the time
        }

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: CheckDirection
        ///  Method return type: bool
        ///  Parameters: short offSetX, short offSetY, short x, short y, string checkingWord, 
        ///              ref string tempWord, Color color, char firstL, string direction
        ///  Synopsis: This method will check for matching letters and word and if a word if founed, light it up in color
        ///  Updates: November 29, 2017:
        ///              -Basic logic
        ///===============================================================================================================================
        private void CheckDirection(sbyte offSetX, sbyte offSetY, short x, short y, string checkingWord, 
            string tempWord, string direction, ref List<int> tempList)
        {
            if (x + offSetX < 0 || y + offSetY < 0 || x + offSetX >= puz.GetColumn() || y + offSetY >= puz.GetRow())//Checks if we're out of bound
                return;                                                                                         //If so, return false
            indexList.Add(y * puz.GetColumn() + x);                                                             //Add the first letter of the word to the list
            while (tempWord.Length < checkingWord.Length &&                                                     //While the tempWord is shorter than the actual word
                   puz.letters[y + offSetY].ElementAt(x + offSetX).Equals(checkingWord.ElementAt(tempWord.Length)))//And the next character matches the next one
            {
                tempWord += puz.letters[y + offSetY].ElementAt(x + offSetX);                                    //Add the character to the string 

                x += offSetX;                                                                                   //Increment or decrement the x
                y += offSetY;                                                                                   //Increment or decrement the x

                indexList.Add(y * puz.GetColumn() + x);                                                         //Add the index of the letterSquare
                if (tempWord.Equals(checkingWord))                                                              //If the word matches
                {
                    Console.WriteLine(tempWord + " was found while checking  " + direction);                    //Debug message
                    foreach(var index in indexList)
                        tempList.Add(index);
                    indexList.Clear();
                    return;                                                                                     //Then return true to tell we have found a word
                }
                if (x + offSetX < 0 || y + offSetY < 0 || x + offSetX >= puz.GetColumn() || y + offSetY >= puz.GetRow())//Out of bound check
                    return;                                                                                     //If we are out of bound, return false
            }
            indexList.Clear();
            return;                                                                                             //If we're here, we didn't found a word
        }
    }
}
