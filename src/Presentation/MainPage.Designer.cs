namespace Presentation
{
    partial class MainPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.currentFloorBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inner4 = new System.Windows.Forms.Button();
            this.inner2 = new System.Windows.Forms.Button();
            this.inner3 = new System.Windows.Forms.Button();
            this.inner1 = new System.Windows.Forms.Button();
            this.innerGround = new System.Windows.Forms.Button();
            this.externalUpGround = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.externalDown1 = new System.Windows.Forms.Button();
            this.externalUp1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.externalDown2 = new System.Windows.Forms.Button();
            this.externalUp2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.externalDown3 = new System.Windows.Forms.Button();
            this.externalUp3 = new System.Windows.Forms.Button();
            this.externalDown4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.currentFloorBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.inner4);
            this.panel1.Controls.Add(this.inner2);
            this.panel1.Controls.Add(this.inner3);
            this.panel1.Controls.Add(this.inner1);
            this.panel1.Controls.Add(this.innerGround);
            this.panel1.Location = new System.Drawing.Point(31, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 386);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Andar atual";
            // 
            // currentFloorBox
            // 
            this.currentFloorBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.currentFloorBox.Location = new System.Drawing.Point(118, 45);
            this.currentFloorBox.Name = "currentFloorBox";
            this.currentFloorBox.ReadOnly = true;
            this.currentFloorBox.Size = new System.Drawing.Size(102, 23);
            this.currentFloorBox.TabIndex = 8;
            this.currentFloorBox.Text = "0";
            this.currentFloorBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.MinimumSize = new System.Drawing.Size(300, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Painel Interno";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inner4
            // 
            this.inner4.Location = new System.Drawing.Point(230, 104);
            this.inner4.Name = "inner4";
            this.inner4.Size = new System.Drawing.Size(92, 71);
            this.inner4.TabIndex = 6;
            this.inner4.Text = "4";
            this.inner4.UseVisualStyleBackColor = true;
            this.inner4.Click += new System.EventHandler(this.inner4_Click);
            // 
            // inner2
            // 
            this.inner2.Location = new System.Drawing.Point(230, 204);
            this.inner2.Name = "inner2";
            this.inner2.Size = new System.Drawing.Size(92, 71);
            this.inner2.TabIndex = 5;
            this.inner2.Text = "2";
            this.inner2.UseVisualStyleBackColor = true;
            this.inner2.Click += new System.EventHandler(this.inner2_Click);
            // 
            // inner3
            // 
            this.inner3.Location = new System.Drawing.Point(17, 104);
            this.inner3.Name = "inner3";
            this.inner3.Size = new System.Drawing.Size(92, 71);
            this.inner3.TabIndex = 4;
            this.inner3.Text = "3";
            this.inner3.UseVisualStyleBackColor = true;
            this.inner3.Click += new System.EventHandler(this.inner3_Click);
            // 
            // inner1
            // 
            this.inner1.Location = new System.Drawing.Point(17, 204);
            this.inner1.Name = "inner1";
            this.inner1.Size = new System.Drawing.Size(92, 71);
            this.inner1.TabIndex = 3;
            this.inner1.Text = "1";
            this.inner1.UseVisualStyleBackColor = true;
            this.inner1.Click += new System.EventHandler(this.inner1_Click);
            // 
            // innerGround
            // 
            this.innerGround.Location = new System.Drawing.Point(118, 286);
            this.innerGround.Name = "innerGround";
            this.innerGround.Size = new System.Drawing.Size(92, 71);
            this.innerGround.TabIndex = 1;
            this.innerGround.Text = "Térreo";
            this.innerGround.UseVisualStyleBackColor = true;
            this.innerGround.Click += new System.EventHandler(this.innerGround_Click);
            // 
            // externalUpGround
            // 
            this.externalUpGround.Location = new System.Drawing.Point(412, 390);
            this.externalUpGround.Name = "externalUpGround";
            this.externalUpGround.Size = new System.Drawing.Size(75, 23);
            this.externalUpGround.TabIndex = 1;
            this.externalUpGround.Text = "Subir";
            this.externalUpGround.UseVisualStyleBackColor = true;
            this.externalUpGround.Click += new System.EventHandler(this.externalUpGround_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(426, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Térreo";
            // 
            // externalDown1
            // 
            this.externalDown1.Location = new System.Drawing.Point(525, 390);
            this.externalDown1.Name = "externalDown1";
            this.externalDown1.Size = new System.Drawing.Size(75, 23);
            this.externalDown1.TabIndex = 3;
            this.externalDown1.Text = "Descer";
            this.externalDown1.UseVisualStyleBackColor = true;
            this.externalDown1.Click += new System.EventHandler(this.externalDown1_Click);
            // 
            // externalUp1
            // 
            this.externalUp1.Location = new System.Drawing.Point(525, 364);
            this.externalUp1.Name = "externalUp1";
            this.externalUp1.Size = new System.Drawing.Size(75, 23);
            this.externalUp1.TabIndex = 4;
            this.externalUp1.Text = "Subir";
            this.externalUp1.UseVisualStyleBackColor = true;
            this.externalUp1.Click += new System.EventHandler(this.externalUp1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(553, 346);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "1";
            // 
            // externalDown2
            // 
            this.externalDown2.Location = new System.Drawing.Point(633, 391);
            this.externalDown2.Name = "externalDown2";
            this.externalDown2.Size = new System.Drawing.Size(75, 23);
            this.externalDown2.TabIndex = 6;
            this.externalDown2.Text = "Descer";
            this.externalDown2.UseVisualStyleBackColor = true;
            this.externalDown2.Click += new System.EventHandler(this.externalDown2_Click);
            // 
            // externalUp2
            // 
            this.externalUp2.Location = new System.Drawing.Point(633, 364);
            this.externalUp2.Name = "externalUp2";
            this.externalUp2.Size = new System.Drawing.Size(75, 23);
            this.externalUp2.TabIndex = 7;
            this.externalUp2.Text = "Subir";
            this.externalUp2.UseVisualStyleBackColor = true;
            this.externalUp2.Click += new System.EventHandler(this.externalUp2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(660, 346);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "2";
            // 
            // externalDown3
            // 
            this.externalDown3.Location = new System.Drawing.Point(417, 284);
            this.externalDown3.Name = "externalDown3";
            this.externalDown3.Size = new System.Drawing.Size(75, 23);
            this.externalDown3.TabIndex = 9;
            this.externalDown3.Text = "Descer";
            this.externalDown3.UseVisualStyleBackColor = true;
            this.externalDown3.Click += new System.EventHandler(this.externalDown3_Click);
            // 
            // externalUp3
            // 
            this.externalUp3.Location = new System.Drawing.Point(417, 255);
            this.externalUp3.Name = "externalUp3";
            this.externalUp3.Size = new System.Drawing.Size(75, 23);
            this.externalUp3.TabIndex = 11;
            this.externalUp3.Text = "Subir";
            this.externalUp3.UseVisualStyleBackColor = true;
            this.externalUp3.Click += new System.EventHandler(this.externalUp3_Click);
            // 
            // externalDown4
            // 
            this.externalDown4.Location = new System.Drawing.Point(525, 284);
            this.externalDown4.Name = "externalDown4";
            this.externalDown4.Size = new System.Drawing.Size(75, 23);
            this.externalDown4.TabIndex = 12;
            this.externalDown4.Text = "Descer";
            this.externalDown4.UseVisualStyleBackColor = true;
            this.externalDown4.Click += new System.EventHandler(this.externalDown4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-289, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(553, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(452, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "3";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 441);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.externalDown4);
            this.Controls.Add(this.externalUp3);
            this.Controls.Add(this.externalDown3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.externalUp2);
            this.Controls.Add(this.externalDown2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.externalUp1);
            this.Controls.Add(this.externalDown1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.externalUpGround);
            this.Controls.Add(this.panel1);
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button inner4;
        private System.Windows.Forms.Button inner2;
        private System.Windows.Forms.Button inner3;
        private System.Windows.Forms.Button inner1;
        private System.Windows.Forms.Button innerGround;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox currentFloorBox;
        private System.Windows.Forms.Button externalUpGround;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button externalDown1;
        private System.Windows.Forms.Button externalUp1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button externalDown2;
        private System.Windows.Forms.Button externalUp2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button externalDown3;
        private System.Windows.Forms.Button externalUp3;
        private System.Windows.Forms.Button externalDown4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

