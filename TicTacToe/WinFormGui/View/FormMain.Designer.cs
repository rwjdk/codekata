namespace WinFormGui.View
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelGameId = new System.Windows.Forms.Label();
            this.buttonHost = new System.Windows.Forms.Button();
            this.buttonJoin = new System.Windows.Forms.Button();
            this.numericUpDownGameId = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonTopLeft = new System.Windows.Forms.Button();
            this.buttonTopCenter = new System.Windows.Forms.Button();
            this.buttonTopRight = new System.Windows.Forms.Button();
            this.buttonMiddleLeft = new System.Windows.Forms.Button();
            this.buttonMiddleCenter = new System.Windows.Forms.Button();
            this.buttonMiddleRight = new System.Windows.Forms.Button();
            this.buttonBottomLeft = new System.Windows.Forms.Button();
            this.buttonBottomCenter = new System.Windows.Forms.Button();
            this.buttonBottomRight = new System.Windows.Forms.Button();
            this.labelWhoAreYou = new System.Windows.Forms.Label();
            this.labelWhosTurnIsIt = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCommunicationChannel = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGameId)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelGameId
            // 
            this.labelGameId.AutoSize = true;
            this.labelGameId.Location = new System.Drawing.Point(16, 41);
            this.labelGameId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGameId.Name = "labelGameId";
            this.labelGameId.Size = new System.Drawing.Size(71, 17);
            this.labelGameId.TabIndex = 0;
            this.labelGameId.Text = "Game ID: ";
            // 
            // buttonHost
            // 
            this.buttonHost.Location = new System.Drawing.Point(297, 38);
            this.buttonHost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonHost.Name = "buttonHost";
            this.buttonHost.Size = new System.Drawing.Size(100, 25);
            this.buttonHost.TabIndex = 1;
            this.buttonHost.Text = "Host";
            this.buttonHost.UseVisualStyleBackColor = true;
            this.buttonHost.Click += new System.EventHandler(this.buttonHost_Click);
            // 
            // buttonJoin
            // 
            this.buttonJoin.Location = new System.Drawing.Point(405, 38);
            this.buttonJoin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonJoin.Name = "buttonJoin";
            this.buttonJoin.Size = new System.Drawing.Size(100, 25);
            this.buttonJoin.TabIndex = 2;
            this.buttonJoin.Text = "Join";
            this.buttonJoin.UseVisualStyleBackColor = true;
            this.buttonJoin.Click += new System.EventHandler(this.buttonJoin_Click);
            // 
            // numericUpDownGameId
            // 
            this.numericUpDownGameId.Location = new System.Drawing.Point(129, 38);
            this.numericUpDownGameId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownGameId.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numericUpDownGameId.Name = "numericUpDownGameId";
            this.numericUpDownGameId.Size = new System.Drawing.Size(160, 22);
            this.numericUpDownGameId.TabIndex = 3;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.Controls.Add(this.buttonTopLeft, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.buttonTopCenter, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.buttonTopRight, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.buttonMiddleLeft, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.buttonMiddleCenter, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.buttonMiddleRight, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.buttonBottomLeft, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.buttonBottomCenter, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.buttonBottomRight, 2, 2);
            this.tableLayoutPanel.Location = new System.Drawing.Point(16, 142);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(485, 448);
            this.tableLayoutPanel.TabIndex = 4;
            // 
            // buttonTopLeft
            // 
            this.buttonTopLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTopLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTopLeft.Location = new System.Drawing.Point(4, 4);
            this.buttonTopLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonTopLeft.Name = "buttonTopLeft";
            this.buttonTopLeft.Size = new System.Drawing.Size(153, 141);
            this.buttonTopLeft.TabIndex = 0;
            this.buttonTopLeft.UseVisualStyleBackColor = true;
            this.buttonTopLeft.Click += new System.EventHandler(this.ClickCell);
            // 
            // buttonTopCenter
            // 
            this.buttonTopCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTopCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTopCenter.Location = new System.Drawing.Point(165, 4);
            this.buttonTopCenter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonTopCenter.Name = "buttonTopCenter";
            this.buttonTopCenter.Size = new System.Drawing.Size(153, 141);
            this.buttonTopCenter.TabIndex = 1;
            this.buttonTopCenter.UseVisualStyleBackColor = true;
            this.buttonTopCenter.Click += new System.EventHandler(this.ClickCell);
            // 
            // buttonTopRight
            // 
            this.buttonTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTopRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTopRight.Location = new System.Drawing.Point(326, 4);
            this.buttonTopRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonTopRight.Name = "buttonTopRight";
            this.buttonTopRight.Size = new System.Drawing.Size(155, 141);
            this.buttonTopRight.TabIndex = 2;
            this.buttonTopRight.UseVisualStyleBackColor = true;
            this.buttonTopRight.Click += new System.EventHandler(this.ClickCell);
            // 
            // buttonMiddleLeft
            // 
            this.buttonMiddleLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMiddleLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMiddleLeft.Location = new System.Drawing.Point(4, 153);
            this.buttonMiddleLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonMiddleLeft.Name = "buttonMiddleLeft";
            this.buttonMiddleLeft.Size = new System.Drawing.Size(153, 141);
            this.buttonMiddleLeft.TabIndex = 3;
            this.buttonMiddleLeft.UseVisualStyleBackColor = true;
            this.buttonMiddleLeft.Click += new System.EventHandler(this.ClickCell);
            // 
            // buttonMiddleCenter
            // 
            this.buttonMiddleCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMiddleCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMiddleCenter.Location = new System.Drawing.Point(165, 153);
            this.buttonMiddleCenter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonMiddleCenter.Name = "buttonMiddleCenter";
            this.buttonMiddleCenter.Size = new System.Drawing.Size(153, 141);
            this.buttonMiddleCenter.TabIndex = 4;
            this.buttonMiddleCenter.UseVisualStyleBackColor = true;
            this.buttonMiddleCenter.Click += new System.EventHandler(this.ClickCell);
            // 
            // buttonMiddleRight
            // 
            this.buttonMiddleRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMiddleRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMiddleRight.Location = new System.Drawing.Point(326, 153);
            this.buttonMiddleRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonMiddleRight.Name = "buttonMiddleRight";
            this.buttonMiddleRight.Size = new System.Drawing.Size(155, 141);
            this.buttonMiddleRight.TabIndex = 5;
            this.buttonMiddleRight.UseVisualStyleBackColor = true;
            this.buttonMiddleRight.Click += new System.EventHandler(this.ClickCell);
            // 
            // buttonBottomLeft
            // 
            this.buttonBottomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBottomLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBottomLeft.Location = new System.Drawing.Point(4, 302);
            this.buttonBottomLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBottomLeft.Name = "buttonBottomLeft";
            this.buttonBottomLeft.Size = new System.Drawing.Size(153, 142);
            this.buttonBottomLeft.TabIndex = 6;
            this.buttonBottomLeft.UseVisualStyleBackColor = true;
            this.buttonBottomLeft.Click += new System.EventHandler(this.ClickCell);
            // 
            // buttonBottomCenter
            // 
            this.buttonBottomCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBottomCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBottomCenter.Location = new System.Drawing.Point(165, 302);
            this.buttonBottomCenter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBottomCenter.Name = "buttonBottomCenter";
            this.buttonBottomCenter.Size = new System.Drawing.Size(153, 142);
            this.buttonBottomCenter.TabIndex = 7;
            this.buttonBottomCenter.UseVisualStyleBackColor = true;
            this.buttonBottomCenter.Click += new System.EventHandler(this.ClickCell);
            // 
            // buttonBottomRight
            // 
            this.buttonBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBottomRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBottomRight.Location = new System.Drawing.Point(326, 302);
            this.buttonBottomRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBottomRight.Name = "buttonBottomRight";
            this.buttonBottomRight.Size = new System.Drawing.Size(155, 142);
            this.buttonBottomRight.TabIndex = 8;
            this.buttonBottomRight.UseVisualStyleBackColor = true;
            this.buttonBottomRight.Click += new System.EventHandler(this.ClickCell);
            // 
            // labelWhoAreYou
            // 
            this.labelWhoAreYou.AutoSize = true;
            this.labelWhoAreYou.Location = new System.Drawing.Point(417, 112);
            this.labelWhoAreYou.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWhoAreYou.Name = "labelWhoAreYou";
            this.labelWhoAreYou.Size = new System.Drawing.Size(13, 17);
            this.labelWhoAreYou.TabIndex = 5;
            this.labelWhoAreYou.Text = "-";
            // 
            // labelWhosTurnIsIt
            // 
            this.labelWhosTurnIsIt.AutoSize = true;
            this.labelWhosTurnIsIt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWhosTurnIsIt.Location = new System.Drawing.Point(19, 98);
            this.labelWhosTurnIsIt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWhosTurnIsIt.Name = "labelWhosTurnIsIt";
            this.labelWhosTurnIsIt.Size = new System.Drawing.Size(21, 29);
            this.labelWhosTurnIsIt.TabIndex = 6;
            this.labelWhosTurnIsIt.Text = "-";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(125, 66);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(66, 17);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "- Status -";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Communication";
            // 
            // comboBoxCommunicationChannel
            // 
            this.comboBoxCommunicationChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCommunicationChannel.FormattingEnabled = true;
            this.comboBoxCommunicationChannel.Items.AddRange(new object[] {
            "File",
            "SignalR"});
            this.comboBoxCommunicationChannel.Location = new System.Drawing.Point(129, 5);
            this.comboBoxCommunicationChannel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxCommunicationChannel.Name = "comboBoxCommunicationChannel";
            this.comboBoxCommunicationChannel.Size = new System.Drawing.Size(375, 24);
            this.comboBoxCommunicationChannel.TabIndex = 8;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 599);
            this.Controls.Add(this.comboBoxCommunicationChannel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelWhosTurnIsIt);
            this.Controls.Add(this.labelWhoAreYou);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.numericUpDownGameId);
            this.Controls.Add(this.buttonJoin);
            this.Controls.Add(this.buttonHost);
            this.Controls.Add(this.labelGameId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TicTacToe";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGameId)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGameId;
        private System.Windows.Forms.Button buttonHost;
        private System.Windows.Forms.Button buttonJoin;
        private System.Windows.Forms.NumericUpDown numericUpDownGameId;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button buttonTopLeft;
        private System.Windows.Forms.Button buttonTopCenter;
        private System.Windows.Forms.Button buttonTopRight;
        private System.Windows.Forms.Button buttonMiddleLeft;
        private System.Windows.Forms.Button buttonMiddleCenter;
        private System.Windows.Forms.Button buttonMiddleRight;
        private System.Windows.Forms.Button buttonBottomLeft;
        private System.Windows.Forms.Button buttonBottomCenter;
        private System.Windows.Forms.Button buttonBottomRight;
        private System.Windows.Forms.Label labelWhoAreYou;
        private System.Windows.Forms.Label labelWhosTurnIsIt;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxCommunicationChannel;
    }
}

