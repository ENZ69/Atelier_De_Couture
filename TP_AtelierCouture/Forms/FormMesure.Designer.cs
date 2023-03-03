namespace TP_AtelierCouture.Forms
{
    partial class FormMesure
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
            this.pnFemme = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnFemme
            // 
            this.pnFemme.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnFemme.Location = new System.Drawing.Point(12, 287);
            this.pnFemme.Name = "pnFemme";
            this.pnFemme.Size = new System.Drawing.Size(776, 119);
            this.pnFemme.TabIndex = 0;
            // 
            // FormMesure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnFemme);
            this.Name = "FormMesure";
            this.Text = "FormMesure";
            this.Load += new System.EventHandler(this.FormMesure_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnFemme;
    }
}