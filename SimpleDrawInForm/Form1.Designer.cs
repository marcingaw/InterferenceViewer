namespace SimpleDrawInForm
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonR = new System.Windows.Forms.Button();
            this.buttonG = new System.Windows.Forms.Button();
            this.buttonB = new System.Windows.Forms.Button();
            this.waveFadeRate = new System.Windows.Forms.TrackBar();
            this.buttonReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.waveFadeRate)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonR
            // 
            this.buttonR.Location = new System.Drawing.Point(0, 0);
            this.buttonR.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonR.Name = "buttonR";
            this.buttonR.Size = new System.Drawing.Size(23, 19);
            this.buttonR.TabIndex = 0;
            this.buttonR.Text = "R";
            this.buttonR.UseVisualStyleBackColor = true;
            this.buttonR.Click += new System.EventHandler(this.buttonR_Click);
            // 
            // buttonG
            // 
            this.buttonG.Location = new System.Drawing.Point(0, 24);
            this.buttonG.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonG.Name = "buttonG";
            this.buttonG.Size = new System.Drawing.Size(23, 19);
            this.buttonG.TabIndex = 1;
            this.buttonG.Text = "G";
            this.buttonG.UseVisualStyleBackColor = true;
            this.buttonG.Click += new System.EventHandler(this.buttonG_Click);
            // 
            // buttonB
            // 
            this.buttonB.Location = new System.Drawing.Point(0, 47);
            this.buttonB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(23, 19);
            this.buttonB.TabIndex = 2;
            this.buttonB.Text = "B";
            this.buttonB.UseVisualStyleBackColor = true;
            this.buttonB.Click += new System.EventHandler(this.buttonB_Click);
            // 
            // waveFadeRate
            // 
            this.waveFadeRate.Dock = System.Windows.Forms.DockStyle.Right;
            this.waveFadeRate.LargeChange = 3;
            this.waveFadeRate.Location = new System.Drawing.Point(555, 0);
            this.waveFadeRate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.waveFadeRate.Minimum = 1;
            this.waveFadeRate.Name = "waveFadeRate";
            this.waveFadeRate.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.waveFadeRate.Size = new System.Drawing.Size(45, 366);
            this.waveFadeRate.TabIndex = 3;
            this.waveFadeRate.Value = 1;
            this.waveFadeRate.Scroll += new System.EventHandler(this.waveFadeRate_Scroll);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReset.Location = new System.Drawing.Point(0, 343);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(51, 23);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.waveFadeRate);
            this.Controls.Add(this.buttonB);
            this.Controls.Add(this.buttonG);
            this.Controls.Add(this.buttonR);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.waveFadeRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonR;
        private System.Windows.Forms.Button buttonG;
        private System.Windows.Forms.Button buttonB;
        private System.Windows.Forms.TrackBar waveFadeRate;
        private System.Windows.Forms.Button buttonReset;
    }
}

