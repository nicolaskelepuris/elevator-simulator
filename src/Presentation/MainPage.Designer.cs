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
            this.internoTerreo = new System.Windows.Forms.Button();
            this.interno1 = new System.Windows.Forms.Button();
            this.interno3 = new System.Windows.Forms.Button();
            this.interno2 = new System.Windows.Forms.Button();
            this.interno4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.interno4);
            this.panel1.Controls.Add(this.interno2);
            this.panel1.Controls.Add(this.interno3);
            this.panel1.Controls.Add(this.interno1);
            this.panel1.Controls.Add(this.internoTerreo);
            this.panel1.Location = new System.Drawing.Point(31, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 386);
            this.panel1.TabIndex = 0;
            // 
            // internoTerreo
            // 
            this.internoTerreo.Location = new System.Drawing.Point(118, 286);
            this.internoTerreo.Name = "internoTerreo";
            this.internoTerreo.Size = new System.Drawing.Size(92, 71);
            this.internoTerreo.TabIndex = 1;
            this.internoTerreo.Text = "Térreo";
            this.internoTerreo.UseVisualStyleBackColor = true;
            // 
            // interno1
            // 
            this.interno1.Location = new System.Drawing.Point(17, 204);
            this.interno1.Name = "interno1";
            this.interno1.Size = new System.Drawing.Size(92, 71);
            this.interno1.TabIndex = 3;
            this.interno1.Text = "1";
            this.interno1.UseVisualStyleBackColor = true;
            // 
            // interno3
            // 
            this.interno3.Location = new System.Drawing.Point(17, 104);
            this.interno3.Name = "interno3";
            this.interno3.Size = new System.Drawing.Size(92, 71);
            this.interno3.TabIndex = 4;
            this.interno3.Text = "3";
            this.interno3.UseVisualStyleBackColor = true;
            // 
            // interno2
            // 
            this.interno2.Location = new System.Drawing.Point(230, 204);
            this.interno2.Name = "interno2";
            this.interno2.Size = new System.Drawing.Size(92, 71);
            this.interno2.TabIndex = 5;
            this.interno2.Text = "2";
            this.interno2.UseVisualStyleBackColor = true;
            // 
            // interno4
            // 
            this.interno4.Location = new System.Drawing.Point(230, 104);
            this.interno4.Name = "interno4";
            this.interno4.Size = new System.Drawing.Size(92, 71);
            this.interno4.TabIndex = 6;
            this.interno4.Text = "4";
            this.interno4.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.Button interno4;
        private System.Windows.Forms.Button interno2;
        private System.Windows.Forms.Button interno3;
        private System.Windows.Forms.Button interno1;
        private System.Windows.Forms.Button internoTerreo;
        private System.Windows.Forms.Label label1;
    }
}

