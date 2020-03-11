    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public class Book
    {
        private string ISBN, Title, Author;
        private decimal Price;
        private int numberOnHand;
        private DateTime lastTransaction;
        
        private int validISBNIntegerLength = 7;
        private int validBookArrayLength = 6;
        
            
        //Default Constructor
        public Book(){}

        /*
         * Populate Book object
         */
         public Boolean populateBookObject(String line)
        {

            Book book = this;
            string[] bookString = line.Split('*');

            

            int i;

            //Consider changing .length to bookstringsize used below
            if (bookString.Length != validBookArrayLength)
            {
                MessageBox.Show
                    ("Record does not contain sufficient data. Book File Corrupt.  Execution Terminated.",
                     "Missing data in BookFile", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            int bookStringSize = bookString.GetLength(0);
            //Removes spaces 
            for (i = 0; i <= bookStringSize - 1; i++)
            {
                bookString[i] = bookString[i].Trim();
            }

            // Convert/Validate Data Read from File
            // Convert/Validate ISBN to a string of required length
            if (bookString[0].Length != validISBNIntegerLength)
            {
                MessageBox.Show
                    (bookString[0] + ": ISBN string is not exactly 7 characters. Book File Corrupt.  Execution Terminated.",
                     "AccessID in Employee File Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            
            try
            {
                bookString[0] = bookString[0].Replace("-", "");
                if (bookString[0].Length!= validISBNIntegerLength-1)
                {
                    throw new Exception();
                }
                int tempISBN = Int32.Parse(bookString[0]);
                ISBN = tempISBN.ToString();
            }
            catch
            {
                MessageBox.Show
                    (bookString[0] + ": ISBN does not contain 6 integers. Book File Corrupt.  Execution Terminated.",
                        "ISBN in Book File Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            Title = bookString[1];
            if (Title == "" )
            {
                MessageBox.Show
                    (bookString[1] + ": Title does not contain any characters. Book File Corrupt.  Execution Terminated.",
                        "Title in Book File Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            Author = bookString[2];
            if (Author == "")
            {
                MessageBox.Show
                    (bookString[2] + ": Author does not contain any characters. Book File Corrupt.  Execution Terminated.",
                        "Author in Book File Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            /*
            bookString[3] = bookString[3].Replace("", "");
            Regex pattern = new Regex("[,$ ]");
            pattern.Replace(bookString[3], "");
            try
            {
                Convert.ToDecimal(value, culture));
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");

            }*/
            return true;
        }


        /*
         * Given a book ISBN(as entered by the user) and a record from the current Book File,
         * checks for a match. (Must split and save the record contents in Book's attributes for
         * future reference, in addition to checking for an ISBN match
         */
        public Boolean bookMatch(String ISBN, Book book)
        {
            if (ISBN == book.ISBN)
            {
                return true;
            }
            return false;
        }
        public string BookInfo()
        {
            String line = ISBN + " * " + Title + " * " + Author + " * " +
                Price + " * " + numberOnHand.ToString() + " * " + lastTransaction.ToString();
            return line;
        }

        /*
         * Creates a nicely formatted string to display in a Message Box. (Converts content
         * (attributes) of a Book object to stirng to a format suitable for display in a Message Box.)
         */
        public void displayBookRecord()
        {
            MessageBox.Show("Title: " + Title + "\n" + "Author: " + Author + "\n" 
                + "ISBN: " + ISBN + "\n" + "Price: " + Price + "\n" + "Numner on Hand" + numberOnHand);
        }
    }
}
