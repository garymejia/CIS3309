using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Provides a model for a bookstore Employee entity.  Note that the information about each Employee initially 
 * will be stored in a text file, one record per Employee.  Each record contains five substrings each separated from the 
 * other by an asterisk and one or more blanks.   We use this file only to validate an Employee’s AccessID and Pin and 
 * to update the last date of Bookstore Inventory access for this Employee.  The Employee is not allowed to change 
 * any of this information on his/her own*/

namespace BookStore
{
    public class Employee
    {

        private string hiddenName;
        private int hiddenAccessID, hiddenPin;
        private DateTime hiddenLastDateOfAccess;
        private decimal hiddenAnnualPay;

        private int validAccessIDLength = 5;
        private int validPinLength = 4;



        // Parameterless constructor
        public Employee(){}

        // Version of ToString Method that overrides ToString in the Object class
        // Performs ToString on this Employee Object
        public override string ToString()
        {
            string output = "AccessID: " + hiddenAccessID + "\r\nName: " + hiddenName
                + "\r\nPIN: " + hiddenPin + "\r\nAnnual Pay:" + hiddenAnnualPay
                + "\r\nLast Date of Access:" + hiddenLastDateOfAccess;
            return output;
        }  // end of ToString



        // Create an Employee Object from a string in the Employee Text File 
        // The data in the input string must be validated before it is stored in Employee Object
        // Returns: True if create is successful or false otherwise
        // Also returns a reference to the Employee object created
        public Boolean populateEmployeeObject(string s)  // IN: string from the Employee Text File
        {
            Employee thisEmployee = this;
            string[] employeeString = s.Split('*');
            int i;

            int employeeStringSize = employeeString.GetLength(0);

            for (i = 0; i <= employeeStringSize - 1; i++)
            {
                employeeString[i] = employeeString[i].Trim();
            } // end for

            // MessageBox.Show("Number of words in Record is " & employeeStringSize.ToString)


            // Convert/Validate Data Read from File
            // Convert/Validate AccessID to an integer of required length
            if (employeeString[0].Length != validAccessIDLength)
            {
                MessageBox.Show
                    (employeeString[0] + ": AccessID string is not exactly 5 characters. Employee File Corrupt.  Execution Terminated.",
                     "AccessID in Employee File Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            try
            {
                hiddenAccessID = Convert.ToInt32(employeeString[0]);
            }
            catch
            {
                MessageBox.Show
                    (employeeString[0] + " AccessID string is not a valid integer. Employee File Corrupt.  Execution Terminated.",
                    "AccessID in Employee File Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            // Validate Name string (no conversion)
            hiddenName = employeeString[1];
            if (hiddenName == " " || hiddenName == "")
            {
                MessageBox.Show
                    (hiddenName + ": Name string is empty or Blank. Employee File Corrupt.  Execution Terminated.",
                     "Name in Employee File Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (employeeString[2].Length != validPinLength)
            {
                MessageBox.Show(employeeString[2] + ": Pin string is not exactly 4 characters. Employee File Corrupt.  Execution Terminated.",
                     "AccessID in Employee File Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            try{
                hiddenPin = Convert.ToInt32(employeeString[2]);
            }
            catch
            {
                MessageBox.Show
                    (employeeString[2] + " Pin string is not a valid integer. Employee File Corrupt.  Execution Terminated.",
                    "AccessID in Employee File Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            // Convert/Validate annualPay to an positive decimal

            // ***** 2 You code this segment

            // Convert lastDateofAccess to a date
            try
            {
                hiddenLastDateOfAccess = DateTime.Parse(employeeString[4]);
            }
            catch
            {
                MessageBox.Show
                    (employeeString[4] + ": Date of Last Access string is not a valid date. Employee File Corrupt.  Execution Terminated.",
                     "Date of last access in Employee File Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return (true);
        }  // end createEmployeeObject




        // Check current Employee object (accessed in employee list)for AccessID for Employee 
        // who is trying to access the system
        // Returns: True if given AccessID is found or false otherwise
        public Boolean checkEmployeeID(int ID)   // IN: user entered employee Access ID
        {
            Employee emp = this;

            if (ID == emp.hiddenAccessID)
            {
                // Save all data from current Employee Object for later reference.
                hiddenAccessID = emp.hiddenAccessID;
                hiddenPin = emp.hiddenPin;
                hiddenName = emp.hiddenName;
                hiddenAnnualPay = emp.hiddenAnnualPay;
                hiddenLastDateOfAccess = emp.hiddenLastDateOfAccess;
                return true;
            }
            else
            {
                return false;
            }
        }  




        // Verify the Pin for the current Employee object
        // Returns: True if given Pin matches the Pin for the current Employee object
        public Boolean verifyPin(int usersPin, Employee emp)
        {
            if (emp.hiddenPin== usersPin){
                return true;
            }
            return false;

        }  


        // Update the current employee log in date (for this transaction)
        // Returns: the last date of access (not used)
        public void updateEmployeeTransactionDate(DateTime thisDate, Employee emp)      
        {
            emp.hiddenLastDateOfAccess = thisDate;
            string message = "ID:                  " + emp.hiddenAccessID
                         + "\nName:                " + emp.hiddenName
                         + "\nPin:                 " + emp.hiddenPin
                         + "\nAnnual Pay:          " + emp.hiddenAnnualPay
                         + "\nLast Date Of Access: " + emp.hiddenLastDateOfAccess;
            MessageBox.Show(message, "Revised Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
        }  // end updateEmployeeTransactionDate



        // Creates a string to write to the updated Employee File
        // Returns: string to be written
        // Also displays string data in Messagebox
        public string createStringToWrite()
        {
            string decimalAsString = String.Format("{0:c}", hiddenAnnualPay);
            string s = hiddenAccessID.ToString() + " * " + hiddenName + " * " + hiddenPin.ToString()
                       + " * " + decimalAsString + " * " + hiddenLastDateOfAccess.ToString();
            MessageBox.Show(hiddenAccessID.ToString() + "\r\n" + hiddenName + "\r\n" + hiddenPin.ToString() +
                            "\r\n" + decimalAsString + "\r\n" + hiddenLastDateOfAccess.ToString(),
                            "String Written to Updated Employee File", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return s;
        }
    }
} // end Employee Class
  // end namespace


