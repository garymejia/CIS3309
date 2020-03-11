using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/* Provides a model for an internal array list used to store the information about all of the employees working 
 * for the Bookstore.  This list initially will be populated from the information stored on the Current 
 * Employee Text File, and at the end of execution of your program, it will be written out to an Updated Employee Text File.*/
namespace BookStore
{
    public class EmployeeList
    {
        List<Employee> InternalList = new List<Employee>();
        public int index;
        public Employee emp;

        // Initialize entire employee list given data in current Book File 
        public Boolean initializeEntireList()
        {
            string nextRecord;
            Boolean isEndOfFile = true;
            Boolean success;
            int countProcessedRecords = 0;
            
            nextRecord = BookStore.currentEmployeeFile.getNextRecord(ref isEndOfFile);
            while (!isEndOfFile)
            {
                countProcessedRecords++;
                Employee emp = new Employee();
                success = emp.populateEmployeeObject(nextRecord);
                if (success != true)
                {
                    MessageBox.Show
                    ("Unable to create an Employee Object.  Employee list not created.",
                     "Employee List Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
                InternalList.Add(emp);
                nextRecord = BookStore.currentEmployeeFile.getNextRecord(ref isEndOfFile);
            } //end While

            if (countProcessedRecords > 0)
                return true;
            else
                return false;
        }  // end initializeEntireList

        public int findEmployeeInList(int userId)
        {
            for(int i = 0; i < InternalList.Count; i++){
                if (InternalList[i].checkEmployeeID(userId) == true)
                {
                    index = i;
                    emp = InternalList[i];
                    return index;
                }
            }
            return 0;
        }
        public Boolean verifyPin(int pin, int index) {
            try
            {
                Boolean found = BookStore.list.InternalList[index].verifyPin(pin, BookStore.list.emp);
                return found;
            }
            catch
            {
                MessageBox.Show("ERROR");
                return false;
            }
        }
        public void displayEntireList()
        {

        }


    }
}
