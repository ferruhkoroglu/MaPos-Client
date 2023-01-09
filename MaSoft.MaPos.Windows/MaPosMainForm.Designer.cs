namespace MaSoft.MaPos.Windows
{
    partial class MaPosMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaPosMainForm));
            this.mainTileControl1 = new MaSoft.MaPos.Windows.mainTileControl();
            this.SuspendLayout();
            // 
            // mainTileControl1
            // 
            this.mainTileControl1.BackColor = System.Drawing.Color.Black;
            this.mainTileControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTileControl1.Location = new System.Drawing.Point(0, 0);
            this.mainTileControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mainTileControl1.Name = "mainTileControl1";
            this.mainTileControl1.Padding = new System.Windows.Forms.Padding(2);
            this.mainTileControl1.Size = new System.Drawing.Size(1124, 805);
            this.mainTileControl1.TabIndex = 0;
            // 
            // MaPosMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 805);
            this.Controls.Add(this.mainTileControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.ShowIcon = false;
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("MaPosMainForm.IconOptions.SvgImage")));
            this.Name = "MaPosMainForm";
            this.Text = "MaPos Adisyon Çözümleri";
            this.ResumeLayout(false);

        }

        #endregion

        private mainTileControl mainTileControl1;
    }
}