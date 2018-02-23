using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordFind_HugoV
{
    class Puzzle
    {
        private byte row;                                                               //How many rows the puzzle has
        private byte col;                                                               //How many column the puzzle has
        private Finder finder;                                                          //The puzzle needs to call the finder

        public List<string> letters;                                                    //The letters that goes in the puzzle
        public List<string> words;                                                      //List of words for the puzzle
        public List<LetterBox> letterBoxes;                                             //List of textBox with a method (check LetterSquare class)

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: Puzzle
        ///  Method return type: constructor
        ///  Parameters: none
        ///  Synopsis: This method makes a puzzle
        ///  Updates: November 3, 2017:
        ///              -Initialization
        ///===============================================================================================================================
        public Puzzle()
        {
            words = new List<string>();                                                 //Instantiate the List
            letters = new List<string>();                                               //Instantiate the List
            letterBoxes = new List<LetterBox>();                                        //Instantiate the list
        }

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: Solve
        ///  Method return type: void
        ///  Parameters: None
        ///  Synopsis: This method sets the how many rows the puzzle has
        ///  Updates: November 20, 2017:
        ///              -Calls the actual solve method
        ///===============================================================================================================================
        public void Solve(ref List<int> list)
        {
            finder = new Finder(this);                                                  //Make the object
            finder.FindWords(ref list);                                                 //This is the solver
            finder = null;                                                              //Delete the object
        }

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: SetRow
        ///  Method return type: void
        ///  Parameters: byte Row
        ///  Synopsis: This method sets the how many rows the puzzle has
        ///  Updates: November 3, 2017:
        ///              -Setter
        ///===============================================================================================================================
        public void SetRow(byte Row){row = Row;}                                        //Set the row

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: SetColumn
        ///  Method return type: void
        ///  Parameters: byte Column
        ///  Synopsis: This method sets the how many columns the puzzle has
        ///  Updates: November 3, 2017:
        ///              -Setter
        ///===============================================================================================================================
        public void SetColumn(byte Column){col = Column;}                               //Set the column

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: GetRow
        ///  Method return type: byte
        ///  Parameters: none
        ///  Synopsis: This method is a getter
        ///  Updates: November 3, 2017:
        ///              -Getter
        ///===============================================================================================================================
        public byte GetRow(){return row;}                                               //Get the row

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: GetColumn
        ///  Method return type: byte
        ///  Parameters: none
        ///  Synopsis: This method is a getter
        ///  Updates: November 3, 2017:
        ///              -Getter
        ///===============================================================================================================================
        public byte GetColumn() { return col; }                                         //Get the column
    }
}
