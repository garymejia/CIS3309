using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    class UpdatedFile
    {



        private string updatedFilePath;
        private System.IO.StreamReader currentFileSR;   // Reference variable of type SR
        private int recordReadCount;

        public UpdatedFile(String filePath)
        {
            this.updatedFilePath = filePath;
            recordReadCount = 0;
            try
            {
                currentFileSR = new StreamReader(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open file" + updatedFilePath+ "Terminate Program.",
                                "Output File Connection Error.",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } // end Try
        }
        

        // Read a record from the current file
        // Returns: the text string read and (through an output argument) a true-false 
        //          indicator for end-of-file
        public string getNextRecord(ref Boolean endOfFileFlag)
        {
            string nextRecord;

            endOfFileFlag = false;
            nextRecord = currentFileSR.ReadLine();

            if (nextRecord == null)
            {
                endOfFileFlag = true;
            }
            else
            {
                recordReadCount += 1;
            } // end if

            return (nextRecord);
        } // end getNextRecord



        // Get value of number of records read
        public int getRecordsReadCount()
        {
            return recordReadCount;
        } // end getRecordsReadCount



        // Close the input file
        public void closeFile()
        {
            currentFileSR.Close();
        }  // end closeFile

        public void writeToFile(String line)
        {
            MessageBox.Show("erge");
            using (StreamWriter stream = File.AppendText(updatedFilePath))
            {
                MessageBox.Show("erge2");
                stream.WriteLine("line");
            }
        }
        /*
      // Rewind the output file
      public void rewindFile()
      {
          recordWrittenCount = 0;
          closeFile();
          updatedFileSW = new System.IO.StreamWriter(updatedFilePath);
          updatedFileSW.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
      } // end rewindFile
  */
    }
}
