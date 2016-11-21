namespace HandleFile
{
    partial class Form1
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
            this.btnWriteToFile = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.txtReadFileName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rchReadFileDate = new System.Windows.Forms.RichTextBox();
            this.rchWFiledate = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnWriteToFile
            // 
            this.btnWriteToFile.Location = new System.Drawing.Point(178, 66);
            this.btnWriteToFile.Name = "btnWriteToFile";
            this.btnWriteToFile.Size = new System.Drawing.Size(75, 23);
            this.btnWriteToFile.TabIndex = 0;
            this.btnWriteToFile.Text = "Write To file";
            this.btnWriteToFile.UseVisualStyleBackColor = true;
            this.btnWriteToFile.Click += new System.EventHandler(this.btnWriteToFile_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(32, 66);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(100, 20);
            this.txtFilename.TabIndex = 1;
            // 
            // txtReadFileName
            // 
            this.txtReadFileName.Location = new System.Drawing.Point(32, 258);
            this.txtReadFileName.Name = "txtReadFileName";
            this.txtReadFileName.Size = new System.Drawing.Size(100, 20);
            this.txtReadFileName.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Read File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rchReadFileDate
            // 
            this.rchReadFileDate.Location = new System.Drawing.Point(32, 284);
            this.rchReadFileDate.Name = "rchReadFileDate";
            this.rchReadFileDate.Size = new System.Drawing.Size(221, 106);
            this.rchReadFileDate.TabIndex = 6;
            this.rchReadFileDate.Text = "";
            // 
            // rchWFiledate
            // 
            this.rchWFiledate.Location = new System.Drawing.Point(32, 95);
            this.rchWFiledate.Name = "rchWFiledate";
            this.rchWFiledate.Size = new System.Drawing.Size(221, 106);
            this.rchWFiledate.TabIndex = 7;
            this.rchWFiledate.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 401);
            this.Controls.Add(this.rchWFiledate);
            this.Controls.Add(this.rchReadFileDate);
            this.Controls.Add(this.txtReadFileName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.btnWriteToFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWriteToFile;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.TextBox txtReadFileName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rchReadFileDate;
        private System.Windows.Forms.RichTextBox rchWFiledate;
    }
}

