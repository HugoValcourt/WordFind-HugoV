using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace WordFind_HugoV
{
    public partial class Interface : Form
    {
        private Puzzle puzzle;                                                                      //Puzzle object
        private FileIO io;                                                                          //FileIO object

        private List<string> puzzleList;                                                            //List of string to store the puzzles name
        private List<int> coords;                                                                   //Private list of indecies
        public Interface()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;                                     //Set it to none resizable
            coords = new List<int>();
            puzzleList = new List<string>();                                                        //Instantiate the list
            puzzle = new Puzzle();                                                                  //Instantiate the object
            io = new FileIO();                                                                      //Instantiate the object
            LoadComboBox();                                                                         //Load strings to put in the comboBox

            puzzleCBox.DropDownStyle = ComboBoxStyle.DropDownList;                                  //Sets the comboBox style
                                            
            SetStandardAttributeVisible(true);                                                      //Set attributes of the form visible or not
            SetMakingAttributeVisible(false);                                                       //for just solving or making the puzzle
        }

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: enterBtn_Click
        ///  Method return type: void
        ///  Synopsis: This method add the word to the list
        ///  Updates: November 10, 2017:
        ///              -Initialization        
        ///===============================================================================================================================
        private void enterBtn_Click(object sender, EventArgs e)
        {           
            puzzle.words.Add(wordEnterText.Text.ToUpper());                                         //Add a word to the list box
         
            puzzle.words.Sort();                                                                    //Sort the list in alphabetic order and put it back int the listbox
            listBox1.Items.Clear();                                                                 //Clear the listBox
            for(short word = 0; word < puzzle.words.Count(); word++)
                listBox1.Items.Add(puzzle.words[word].ToString());                                  //Add every word in the listBox

            wordEnterText.Text = "";                                                                //Reset the textBox to null
            wordEnterText.Focus();                                                                  //Set the focus on it
        }

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: wordEnterText_TextChanged
        ///  Method return type: void
        ///  Synopsis: This method check if the word/character entered are valid
        ///  Updates: November 10, 2017:
        ///              -Initialization        
        ///===============================================================================================================================
        private void wordEnterText_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(wordEnterText.Text, @"^[a-zA-Z]+$") &&                               //If the string has something that is not a letter
                wordEnterText.Text != "")                                                           //and if it is not empty    
            {
                wordEnterText.Text = "";                                                            //If so, clear the string
                MessageBox.Show("Only letters are allowed!");                                       //Display error message
            }

        }

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: deleteBtn_Click
        ///  Method return type: void
        ///  Synopsis: This method deletes a puzzle file and remove it from the comboBox
        ///  Updates: November 10, 2017:
        ///              -Initialization        
        ///===============================================================================================================================
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            puzzle.words.RemoveAt(listBox1.SelectedIndex);                                          //Remove the string selected
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);                                        //Remove the item selected from the listbox
        }

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: generateBtn_Click
        ///  Method return type: void
        ///  Synopsis: This method generates the desired puzzle
        ///  Updates: November 10, 2017:
        ///              -Initialization        
        ///===============================================================================================================================
        private void generateBtn_Click(object sender, EventArgs e)
        {
            bool rowEntered = int.TryParse(rowText.Text, out int dummyInt);                         //Check if textBox has numeric input
            bool colEntered = int.TryParse(columnText.Text, out dummyInt);                          //Check if textBox has numeric input

            if (rowText.Text != "" &&                                                               //If the textBox is not empty
                columnText.Text != "" &&                                                            //If the textBox is not empty 
                !rowText.Text.Contains("-") &&                                                      //Make sure it's not negative
                !columnText.Text.Contains("-") &&                                                   //Make sure it's not negative
                rowEntered &&                                                                       //If the textBox has numeric in it
                colEntered &&                                                                       //If the textBox has numeric in it
                Convert.ToByte(rowText.Text) <= 30 &&                                               //Maximum of 30 by 30 puzzles
                Convert.ToByte(columnText.Text) <= 30)                                                                         
            {
                puzzle.SetRow(Convert.ToByte(rowText.Text));                                        //Set the puzzle's rows
                puzzle.SetColumn(Convert.ToByte(columnText.Text));                                  //Set the puzzle's columns
                GeneratePuzzle(true);                                                               //Generate the puzzle
            }
            else
                MessageBox.Show("Invalid inputs\nPuzzle max size is 30 by 30");                     //Display error message
        }

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: loadBtn_Click
        ///  Method return type: void
        ///  Synopsis: This method loads the desired puzzle
        ///  Updates: November 10, 2017:
        ///              -Initialization        
        ///===============================================================================================================================
        private void loadBtn_Click(object sender, EventArgs e)
        {
            if (puzzleCBox.Text != "")                                                              //If the string is not empty
            {               
                listBox1.Items.Clear();                                                             //Clear the word list box         
                io.LoadPuzzle(puzzle, puzzleCBox.SelectedItem.ToString());                          //Load the puzzle
                GeneratePuzzle(false);                                                              //Make the puzzle
            }
        }

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: saveBtn_Click
        ///  Method return type: void
        ///  Synopsis: This method loads the desired puzzle
        ///  Updates: November 10, 2017:
        ///              -Initialization        
        ///===============================================================================================================================
        private void saveBtn_Click(object sender, EventArgs e)
        {           
            foreach(var box in puzzle.letterBoxes)                                                  //For every textBox in the list
            {
                if (box.box.Text == "")                                                             //Check if it is empty
                {
                    MessageBox.Show("One or more text box is empty");                               //If so, display error message
                    return;                                                                         //And return
                }
            }
            string  filename = Interaction.InputBox("Enter a save file name", "File name", 
                                                    "examplePuzzle", 400, 400);                     //Prompt for a save file name 
            if (filename != "" || puzzleCBox.Items.Contains(filename))
                io.Save(puzzle, filename);                                                          //Check is the user has entered a 
                                                                                                    //puzzle name and if it is not in the list already
            else if (filename == "")                                                                //If the string is empty 
                MessageBox.Show("Enter a valid name");                                              //Display error message
            else if (puzzleCBox.Items.Contains(filename))                                           //If there is already a puzzle with that same name
                MessageBox.Show("A puzzle already has this name");                                  //Display error message
            LoadComboBox();                                                                         //Load the puzzle names into the comboBox
        }

        private void solveBtn_Click(object sender, EventArgs e)
        {
            if (puzzle.letterBoxes.Count() > 1)                                                     //If there is letterBoxes in place
            {
                puzzle.Solve(ref coords);                                                           //Solve the puzzle
                for (short square = 0; square < coords.Count(); square++)                           //Loop on every letterSquare of the word
                    puzzle.letterBoxes.ElementAt(coords.ElementAt(square)).
                        box.BackColor = Color.LightSalmon;                                          //And put in in a color
                coords.Clear();
            }
            else
                MessageBox.Show("There is no puzzle to solve!");                                    //Error message
        }                 

        private void btnReset_Click(object sender, EventArgs e) { ResetLetterSquare(); }            //Resets and unload everything

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: checkBox1_CheckedChanged
        ///  Method return type: void
        ///  Synopsis: This method sets attribute to make a puzzle or not
        ///  Updates: November 10, 2017:
        ///              -Initialization        
        ///===============================================================================================================================
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)                                                                  //Check if the checkBox ifs checked
            {
                SetMakingAttributeVisible(true);                                                    //Set attributes to make the puzzle
                solveBtn.Visible = false;                                                           //Make the button invisible
                ResetLetterSquare();                                                                //Resets and unload everything 
                puzzle.letters.Clear();                                                             //Clear the puzzle characters
                puzzle.words.Clear();                                                               //Clear the word list
                listBox1.Items.Clear();                                                             //Clear the listBox 
            }
            else                                                       
            {
                ResetLetterSquare();                                                                //Resets and unload everything 
                SetMakingAttributeVisible(false);                                                   //If it's not checked, set attributes 
                solveBtn.Visible = true;                                                            //to only solve loaded puzzles
            }
        }

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: deleteFileBtn_Click
        ///  Method return type: void
        ///  Synopsis: This method delete a puzzle 
        ///  Updates: November 10, 2017:
        ///              -Initialization        
        ///===============================================================================================================================
        private void deleteFileBtn_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Yes or no", "Are you sure you want to delete the puzzle?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))         //If the yes button is pressed
            {
                if (puzzleCBox.Text.Equals("Puzzle1") || puzzleCBox.Text.Equals("Puzzle2"))         //If the puzzle selected is a default puzzle
                {
                    MessageBox.Show("'Puzzle1' and 'Puzzle2' are default puzzles and cannot be deleted.");//Display error message
                    return;                                                                         //And return
                }
                if (File.Exists(@"..\..\Data\" + puzzleCBox.Text + ".txt"))                         //Check if there is actually a file with that name
                    io.Delete((ushort)puzzle.letterBoxes.Count(), puzzleCBox.Text, ref puzzleCBox, ref puzzleList);//Delete the file in this method
            }
        }

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: GeneratePuzzle
        ///  Method return type: void
        ///  Parameters: none
        ///  Synopsis: This method delete a puzzle 
        ///  Updates: November 10, 2017:
        ///              -Initialization        
        ///===============================================================================================================================
        private void GeneratePuzzle(bool editing)
        {
            bool edit = editing;                                                                //Are we making a puzzle or just loading?
            for (short word = 0; word < puzzle.words.Count(); word++)
                listBox1.Items.Add(puzzle.words[word].ToString());                              //Load every word into the listBox

            for (ushort row = 0; row < puzzle.GetRow(); row++)                                  //Make a puzzle with the desired row and column
            {
                for (ushort col = 0; col < puzzle.GetColumn(); col++)
                {
                    LetterBox lilBox = new LetterBox(row, col);                     //Make a letterSquare object
                    if(!edit)
                        lilBox.box.Text = puzzle.letters[row].ElementAt(col).ToString();//Set the proper character to the letterSquare
                    lilBox.box.ReadOnly = !checkBox1.Checked;                    //Set the textBox to only read or not
                    puzzle.letterBoxes.Add(lilBox);                                     //Add the object to the puzzle object
                    Controls.Add(lilBox.box);                                    //Add the letterSquare to the form
                }
            }
        }

        private void SetStandardAttributeVisible(bool ToF){listBox1.Visible = ToF;}             //Set stuff visible or not 

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: SetMakingAttributeVisible
        ///  Method return type: void
        ///  Parameters: bool ToF
        ///  Synopsis: This method sets atribute visible or not
        ///  Updates: November 10, 2017:
        ///              -Initialization        
        ///===============================================================================================================================
        private void SetMakingAttributeVisible(bool ToF)
        {
            deleteBtn.Visible = ToF;                                                            //Set stuuf visible or not
            enterBtn.Visible = ToF;
            wordEnterText.Visible = ToF;
            rowText.Visible = ToF;
            columnText.Visible = ToF;
            generateBtn.Visible = ToF;
            rowLbl.Visible = ToF;
            columnLbl.Visible = ToF;
            saveBtn.Visible = ToF;
        }

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: SetColumn
        ///  Method return type: void
        ///  Parameters: byte Column
        ///  Synopsis: This method resets the puzzle to null
        ///  Updates: November 20, 2017:
        ///              -Resetter
        ///===============================================================================================================================
        private void ResetLetterSquare()
        {
            for (int squareIndex = 0; squareIndex < puzzle.letterBoxes.Count(); squareIndex++)
                puzzle.letterBoxes[squareIndex].box.Dispose();                       //Remove every letterSquare
            puzzle.letterBoxes.Clear();                                                       //Clear the list of object
            listBox1.Items.Clear();                                                             //Clear the listBox 
        }

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Method name: LoadComboBox
        ///  Method return type: void
        ///  Parameters: None
        ///  Synopsis: This method load items into a combo box
        ///  Updates: November 7, 2017:
        ///              -Strings into combo box
        ///===============================================================================================================================
        private void LoadComboBox()
        {
            //Reload the name file in the combo box
            puzzleCBox.Items.Clear();                                                           //Clear the comboBox
            puzzleList = File.ReadAllLines(@"..\..\Data\PuzzleFiles.txt").ToList();             //Read the puzzle names from the file
            for (int comboBIndex = 0; comboBIndex < puzzleList.Count(); comboBIndex++)
            {               
                if (puzzleList[comboBIndex] == "")                                              //Check for any empty string and remove it
                    puzzleList.RemoveAt(comboBIndex);

                puzzleCBox.Items.Add(puzzleList[comboBIndex]);                                  //Add the file names to the comboBox
            }
        }
    }       
}           
            
            