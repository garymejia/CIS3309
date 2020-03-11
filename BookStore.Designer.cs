namespace BookStore
{
    partial class BookStore
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtAccessID = new System.Windows.Forms.TextBox();
            this.btnFindMe = new System.Windows.Forms.Button();
            this.lblBookWorm = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAccessID
            // 
            this.txtAccessID.Location = new System.Drawing.Point(102, 373);
            this.txtAccessID.Name = "txtAccessID";
            this.txtAccessID.Size = new System.Drawing.Size(100, 20);
            this.txtAccessID.TabIndex = 0;
            // 
            // btnFindMe
            // 
            this.btnFindMe.Location = new System.Drawing.Point(342, 369);
            this.btnFindMe.Name = "btnFindMe";
            this.btnFindMe.Size = new System.Drawing.Size(75, 23);
            this.btnFindMe.TabIndex = 1;
            this.btnFindMe.Text = "Find Me";
            this.btnFindMe.UseVisualStyleBackColor = true;
            this.btnFindMe.Click += new System.EventHandler(this.btnFindMe_Click);
            // 
            // lblBookWorm
            // 
            this.lblBookWorm.AutoSize = true;
            this.lblBookWorm.Location = new System.Drawing.Point(120, 124);
            this.lblBookWorm.Name = "lblBookWorm";
            this.lblBookWorm.Size = new System.Drawing.Size(63, 13);
            this.lblBookWorm.TabIndex = 3;
            this.lblBookWorm.Text = "Book Worm";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(134, 22);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(52, 13);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "Welcome";
            // 
            // BookStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblBookWorm);
            this.Controls.Add(this.btnFindMe);
            this.Controls.Add(this.txtAccessID);
            this.Name = "BookStore";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAccessID;
        private System.Windows.Forms.Button btnFindMe;
        private System.Windows.Forms.Label lblBookWorm;
        private System.Windows.Forms.Label lblWelcome;
    }
}

