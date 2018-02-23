using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordFind_HugoV
{
    class LetterBox
    {
        public TextBox box;                                                                     //The actual text box

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Function name: box
        ///  Function return type: constructor
        ///  Parameters: ushort x, ushort y
        ///  Synopsis: This function makes a letter square text
        ///  Updates: November 3, 2017:
        ///              -Initialization
        ///===============================================================================================================================
        public LetterBox(ushort x, ushort y)
        {                   
            box = new TextBox();                                                                //Makes a new TextBox
            box.Location = new System.Drawing.Point(y * 20 + 300, x * 20 + 8);                  //Set its position
            box.Name = "Letter Square Box";
            box.Size = new System.Drawing.Size(20, 20);
            box.TabIndex = 0;
            box.TextAlign = HorizontalAlignment.Center;
            box.TextChanged += new System.EventHandler(boxTextChanged);
        }

        ///===============================================================================================================================
        ///  Developer name: Hugo Valcourt
        ///  Function name: boxTextChanged
        ///  Function return type: void
        ///  Parameters: object sender, EventArgs e
        ///  Synopsis: This function 
        ///  Updates: November 3, 2017:
        ///              -Initialization
        ///===============================================================================================================================
        private void boxTextChanged(object sender, EventArgs e)
        {
            box.Text = box.Text.ToUpper();                                                      //Put the strin to upper case
            if (box.Text.Length > 1)                                                            //If there is more than 1 character in the string
            {
                box.Text = box.Text.Remove(1);                                                  //Remove the last character
                MessageBox.Show("Only 1 character per square!");                                //Display error message
            }
            if(!Regex.IsMatch(box.Text, @"^[\p{L}]+$") && box.Text != "")                       //Only letters are allowed to be entered
            {
                box.Text = "";                                                                  //Clear the string
                MessageBox.Show("Only letters are allowed!");                                   //Display error message
            }
        }
    }
}
