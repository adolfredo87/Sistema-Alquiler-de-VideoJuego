namespace Presentacion.Plantilla
{
    partial class FrmPlantilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlantilla));
            this.GrupBox = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // GrupBox
            // 
            this.GrupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GrupBox.BackColor = System.Drawing.Color.Transparent;
            this.GrupBox.Location = new System.Drawing.Point(12, 12);
            this.GrupBox.Name = "GrupBox";
            this.GrupBox.Size = new System.Drawing.Size(458, 308);
            this.GrupBox.TabIndex = 0;
            this.GrupBox.TabStop = false;
            this.GrupBox.Text = "GrupBox";
            // 
            // FrmPlantilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(482, 365);
            this.Controls.Add(this.GrupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmPlantilla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPlantilla";
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox GrupBox;

    }
}

