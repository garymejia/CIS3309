using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class Pin : Form
    {
        private int hiddenTryCountMax = 3;
        public Pin() {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean pinkOK = BookStore.list.verifyPin(Int32.Parse(txtPin.Text), BookStore.index);
                
                if (pinkOK)
                {
                    this.Hide();
                    var Transaction = new Transaction();
                    Transaction.Closed += (s, args) => this.Close();
                    Transaction.Show();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("ERROR INVALID PIN");
                hiddenTryCountMax--;
                if (hiddenTryCountMax == 0)
                {
                    MessageBox.Show("You've reached the max number of attempts.\nPlease contact the manager for assistance");
                    this.Close();
                }
            }
        }
    }
}
