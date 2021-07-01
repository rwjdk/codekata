namespace Tennis.WinForm.View
{
    partial class FormNumberOfSets
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
            this.button1Set = new System.Windows.Forms.Button();
            this.button3Set = new System.Windows.Forms.Button();
            this.button5Set = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1Set
            // 
            this.button1Set.Location = new System.Drawing.Point(12, 12);
            this.button1Set.Name = "button1Set";
            this.button1Set.Size = new System.Drawing.Size(75, 23);
            this.button1Set.TabIndex = 0;
            this.button1Set.Text = "1";
            this.button1Set.UseVisualStyleBackColor = true;
            this.button1Set.Click += new System.EventHandler(this.button1Set_Click);
            // 
            // button3Set
            // 
            this.button3Set.Location = new System.Drawing.Point(93, 12);
            this.button3Set.Name = "button3Set";
            this.button3Set.Size = new System.Drawing.Size(75, 23);
            this.button3Set.TabIndex = 1;
            this.button3Set.Text = "3";
            this.button3Set.UseVisualStyleBackColor = true;
            this.button3Set.Click += new System.EventHandler(this.button3Set_Click);
            // 
            // button5Set
            // 
            this.button5Set.Location = new System.Drawing.Point(174, 12);
            this.button5Set.Name = "button5Set";
            this.button5Set.Size = new System.Drawing.Size(75, 23);
            this.button5Set.TabIndex = 2;
            this.button5Set.Text = "5";
            this.button5Set.UseVisualStyleBackColor = true;
            this.button5Set.Click += new System.EventHandler(this.button5Set_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(255, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Cancel";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FormNumberOfSets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 45);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.button5Set);
            this.Controls.Add(this.button3Set);
            this.Controls.Add(this.button1Set);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormNumberOfSets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Number of Sets?";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1Set;
        private System.Windows.Forms.Button button3Set;
        private System.Windows.Forms.Button button5Set;
        private System.Windows.Forms.Button buttonExit;
    }
}