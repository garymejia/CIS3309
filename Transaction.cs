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
    public partial class Transaction : Form
    {
        public Transaction()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Globals.store.findAndSaveBook(txtISBN1.Text + txtISBN2.Text))
            {
                MessageBox.Show("Sorry. The following book already exists:  ");
            }
            else
            {
                txtISBN1.Enabled = false;
                txtISBN2.Enabled = false;
                btnOK.Enabled = false;

                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnDone.Visible = true;

                txtAddISBN.Text = txtISBN1.Text + "-" + txtISBN2.Text;

                txtAddISBN.Visible = true;
                txtAuthor.Visible = true;
                txtTitle.Visible = true;
                txtDate.Visible = true;
                txtPrice.Visible = true;
                txtOnHand.Visible = true;

                lblISBN.Visible = true;
                lblAuthor.Visible = true;
                lblTitle.Visible = true;
                lblDate.Visible = true;
                lblOnHand.Visible = true;
                lblPrice.Visible = true;
            }
            Globals.store.rewindFiles();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            try
            {
                String ISBN = txtAddISBN.Text;
                String Author = txtAuthor.Text;
                String Title = txtTitle.Text;
                Decimal Price = Decimal.Parse(txtPrice.Text);
                int OnHand = Int32.Parse(txtOnHand.Text);
                DateTime transactionDate = DateTime.Parse(txtDate.Text);
                if (Globals.store.checkForDuplicateRecord(ISBN, Author, transactionDate, Title, Price, OnHand))
                {
                    MessageBox.Show("Duplicate Record was found");
                }
                MessageBox.Show("HERE");
            }
            catch
            {
                MessageBox.Show("Please check input, syntax error");
            }
            Globals.store.rewindFiles();

        }
    }
}
