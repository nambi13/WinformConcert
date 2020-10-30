namespace WindowsFormsApplication1
{
    partial class AccueilEve
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
            this.Reservation = new System.Windows.Forms.Button();
            this.Historique = new System.Windows.Forms.Button();
            this.Courbe = new System.Windows.Forms.Button();
            this.Utiliser_Presse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Reservation
            // 
            this.Reservation.Location = new System.Drawing.Point(26, 24);
            this.Reservation.Name = "Reservation";
            this.Reservation.Size = new System.Drawing.Size(75, 23);
            this.Reservation.TabIndex = 0;
            this.Reservation.Text = "Reservation";
            this.Reservation.UseVisualStyleBackColor = true;
            this.Reservation.Click += new System.EventHandler(this.Reservation_Click);
            // 
            // Historique
            // 
            this.Historique.Location = new System.Drawing.Point(121, 24);
            this.Historique.Name = "Historique";
            this.Historique.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Historique.Size = new System.Drawing.Size(75, 23);
            this.Historique.TabIndex = 1;
            this.Historique.Text = "Historique des billes";
            this.Historique.UseVisualStyleBackColor = true;
            this.Historique.Click += new System.EventHandler(this.Historique_Click);
            // 
            // Courbe
            // 
            this.Courbe.Location = new System.Drawing.Point(221, 24);
            this.Courbe.Name = "Courbe";
            this.Courbe.Size = new System.Drawing.Size(75, 23);
            this.Courbe.TabIndex = 2;
            this.Courbe.Text = "Courbe";
            this.Courbe.UseVisualStyleBackColor = true;
            this.Courbe.Click += new System.EventHandler(this.Courbe_Click);
            // 
            // Utiliser_Presse
            // 
            this.Utiliser_Presse.Location = new System.Drawing.Point(331, 23);
            this.Utiliser_Presse.Name = "Utiliser_Presse";
            this.Utiliser_Presse.Size = new System.Drawing.Size(75, 23);
            this.Utiliser_Presse.TabIndex = 3;
            this.Utiliser_Presse.Text = "Preese";
            this.Utiliser_Presse.UseVisualStyleBackColor = true;
            this.Utiliser_Presse.Click += new System.EventHandler(this.Utiliser_Presse_Click);
            // 
            // AccueilEve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 262);
            this.Controls.Add(this.Utiliser_Presse);
            this.Controls.Add(this.Courbe);
            this.Controls.Add(this.Historique);
            this.Controls.Add(this.Reservation);
            this.Name = "AccueilEve";
            this.Text = "AccueilEve";
            this.Load += new System.EventHandler(this.AccueilEve_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Reservation;
        private System.Windows.Forms.Button Historique;
        private System.Windows.Forms.Button Courbe;
        private System.Windows.Forms.Button Utiliser_Presse;
    }
}