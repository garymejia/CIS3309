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

namespace BookStore
{
    public partial class BookStore : Form
    {

        // Books and the EmployeeList and all the text files belong to the Bookstore
        public static Book book;
        public static EmployeeList list = new EmployeeList();

        // The Files the Bookstore Owns
        // ASK--->Why cant we use Properties.Resources.EmployeeList?;
        private static string currentBookFilePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\BookFile.txt"));
        private static string updatedBookFilePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\UpdatedBookFile.txt"));
        private static string currentEmployeeFilePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\EmployeeFile.txt"));
        //private static string updatedEmployeeFilePath = "updatedEmployeeFile.txt";



        private static CurrentFile currentBookFile = new CurrentFile(currentBookFilePath);  
        private static UpdatedFile updatedBookFile = new UpdatedFile(updatedBookFilePath);
        public static CurrentFile currentEmployeeFile = new CurrentFile(currentEmployeeFilePath);
        //private static UpdatedFile updatedEmployeeFile = new UpdatedFile(updatedEmployeeFilePath);
        
        
            
            
            // Bookstore parameters (Named constants defined by the Bookstore)
        private int hiddenAccessIDLength = 5;   // Length of AccessNet ID
        private int hiddenISBNLeftLength = 3;   // Length of left part of ISBN
        private int hiddenISBNRightLength = 3;  // Length of right part of ISBN
        // Number of attempts BookStore allows a user before terminating an inventory 
        //    update session
        private int hiddenTryCountMax = 3;

        public static int index;
        
        /*
        // Displays the list of employees (After they were written to the Employee File)
        public void writeEntireEmployeeList()
        {
            EmployeeList.displayEntireList();
        }   // end writeEntireEmployeeList
        */

        public BookStore()
        {
            InitializeComponent();
            list.initializeEntireList();
        }


        private void btnFindMe_Click(object sender, EventArgs e)
        {
            try
            {
                int userID = Int32.Parse(txtAccessID.Text);
                index = list.findEmployeeInList(userID);
                if (index == 0)
                {
                    throw new Exception();
                }
                this.Hide();
                var Pin = new Pin();
                Pin.Closed += (s, args) => this.Close();
                Pin.Show();
            }
            catch
            {
                MessageBox.Show("Error Access ID is invalid");
                hiddenTryCountMax--;
                if (hiddenTryCountMax == 0)
                {
                    MessageBox.Show("You've reached the max number of attempts.\nPlease contact the manager for assistance");
                    this.Close();
                }
            }
            
        }
        /*
         * Checks for a duplicate record when user attempts to add new book
         */
        public Boolean checkForDuplicateRecord(String ISBN, String Author, DateTime date, String Title, Decimal Price, int onHand)
        {
            String line = ISBN + " * " + Title + " * " + Author + " * " +
                Price + " * " + onHand + " * " + date.ToString();
            Book addBook = new Book();
            String tempISBN = ISBN = ISBN.Replace("-", "");
            if (!findAndSaveBook(ISBN))
            {
                addBook.populateBookObject(line);
                addBook.displayBookRecord();
                writeOneRecord(addBook);
                return false;
            }
            return true;
        }
        /*
         * Close all external files
         */
        public void closeFiles()
        {

        }
        /*
         After an employee's changes are processed, copies all remaining records
         in the currentEmployeeFile to the updatedEmployeeFile
         */
        public void copyRemainingRecords()
        {

        }
        /*
         * Given a book ISBN(entered by the user) and a book record(read from
         * the currentBookFile) checks to see if the user ISBN matches the record 
         * ISBN(the first  field of the record_. If there is a match, this method splits
         * the record into its 6 component parts and saves them
         */
        public Boolean findAndSaveBook(String ISBN)
        {
            string nextRecord;
            Boolean isEndOfFile = true;
            Boolean success;

            nextRecord = currentBookFile.getNextRecord(ref isEndOfFile);
            while (!isEndOfFile)
            {
                Book tempBook = new Book();
                success = tempBook.populateBookObject(nextRecord);

                if (success != true)
                {
                    MessageBox.Show
                    ("Unable to create a Book Object",
                     "Book object creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
                if (tempBook.bookMatch(ISBN, tempBook))
                {
                    book = tempBook;
                    return true;
                }
                nextRecord = BookStore.currentBookFile.getNextRecord(ref isEndOfFile);
            } //end While
            return false;
        }  

        /*
         * Given an employees Access ID uses a sentinel-controlled while loop to 
         * find the correct employee record in the EmployeeList(calls findEmployeeinList 
         * in the employee list class)
         */
        public void findEmployee()
        {

        }
        /*
         * Rewinds all external files prior to closing
         */
        public void rewindFiles()
        {
            currentBookFile.rewindFile();
        }
        /*
         * Calls writeEmployeeListToFile in the Employee list class to write all 
         * Employee records in the List back out to the updatedEmployeeFile
         */
        public void writeEntireEmployeeListToFile()
        {

        }
        /*
         * Writes the contents of one Book record to the updatedBookFile
         */
        public void writeOneRecord(Book book)
        {
            String line = book.BookInfo();
            BookStore.updatedBookFile.writeToFile(line);
        }
    }
}
