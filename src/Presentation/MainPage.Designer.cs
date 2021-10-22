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
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 441);
            this.Controls.Add(this.panel1);
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

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
    }
}

