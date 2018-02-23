using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordFind_HugoV
{
    class FileIO
    {
        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Function name: LoadPuzzle
        ///  Function return type: void
        ///  Parameters: None
        ///  Synopsis: This function load the puzzle from a text file
        ///  Updates: November 5, 2017:
        ///              -Initialization
        ///===============================================================================================================================
        public void LoadPuzzle(Puzzle puzzle, string filename)
        {
            StreamReader file = new StreamReader(@"..\..\Data\" + filename + ".txt");

            for (int squareIndex = 0; squareIndex < puzzle.letterBoxes.Count(); squareIndex++)
                puzzle.letterBoxes[squareIndex].box.Dispose();                                  //Delete every squares for the letters 

            puzzle.letterBoxes.Clear();                                                         //Clear every list
            puzzle.letters.Clear();
            puzzle.words.Clear();

            string tempString = "";                                                             //Declare a local string
            byte row = Convert.ToByte(file.ReadLine());                                         //Get the byte from the file
            byte col = Convert.ToByte(file.ReadLine());                                         //Get the byte from the file
            puzzle.SetRow(row);                                                                 //Set the rows
            puzzle.SetColumn(col);                                                              //Set the columns

            for (byte rowIndex = 0; rowIndex < row; rowIndex++)                                 //For the amount of rows
            {                                                                                   //We are at the characters for the puzzle
                tempString = file.ReadLine();                                                   //Read the line from the file and assign it
                puzzle.letters.Add(tempString);                                                 //Add it to the character list
            }
            
            while(tempString != null)                                                           //While we did not reached the end of the file
            {                                                                                   //We are now at the words
                tempString = file.ReadLine();                                                   //Read the line and assign it   
                puzzle.words.Add(tempString);                                                   //Add it tho the word list
            }
            puzzle.words.RemoveAt(puzzle.words.Count() - 1);                                    //Remove the last one because it is null
   
            puzzle.words.Sort();                                                                //Sort the list in alphabetic order
        }

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Function name: Save
        ///  Function return type: void
        ///  Parameters: None
        ///  Synopsis: This function save the puzzle to a text file
        ///  Updates: November 5, 2017:
        ///              -Initialization
        ///===============================================================================================================================
        public void Save(Puzzle puzzle, string filename)
        {
            puzzle.letters.Clear();                                                             //Clear the list
            string tempString = "";                                                             //Declare a local string
            foreach(var square in puzzle.letterBoxes)                                           //For every letterSquare in the list
            {
                tempString += square.box.Text;                                                  //Add the character to the string
                if (tempString.Length == puzzle.GetColumn())                                    //If the string as reached the max length
                {
                    puzzle.letters.Add(tempString);                                             //Add it to the character list
                    tempString = "";                                                            //Then clear it
                }
            }

            File.AppendAllText(@"..\..\Data\PuzzleFiles.txt" ,"\n" + filename);                 //Add the file name to the file
            File.WriteAllText(@"..\..\Data\" + filename + ".txt", puzzle.GetRow().ToString() + "\n");//Add the amount of rows
            File.AppendAllText(@"..\..\Data\" + filename + ".txt", puzzle.GetColumn().ToString() + "\n");//Add the amount of columns
            File.AppendAllLines(@"..\..\Data\" + filename + ".txt", puzzle.letters);            //Add the character list
            File.AppendAllLines(@"..\..\Data\" + filename + ".txt", puzzle.words);              //Add the word list
        }

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Function name: Delete
        ///  Function return type: void
        ///  Parameters: ushort boxAmount, string filename, ref ComboBox CBox, ref List<string> list
        ///  Synopsis: This function deletes a file from the puzzle and from the folder
        ///  Updates: November 20, 2017:
        ///              -Delete a selected file
        ///===============================================================================================================================
        public void Delete(ushort boxAmount, string filename, ref ComboBox CBox, ref List<string> list)
        {
            if (boxAmount != 0)                                                                 //If there is still letterSquare in the application
                MessageBox.Show("A reset is required before deleting a file");                  //Display error message 
            else
            {
                File.Delete(@"..\..\Data\" + filename + ".txt");                                //Delete the file
                list.RemoveAt(CBox.SelectedIndex);                                              //Remove the string from the list
                CBox.Items.RemoveAt(CBox.SelectedIndex);                                        //Remove the string from the comboBox
                File.WriteAllLines(@"..\..\Data\PuzzleFiles.txt", list);                        //Rewrite the file names in the file
            }
        }
    }
}
