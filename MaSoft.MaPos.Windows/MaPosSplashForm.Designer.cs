using System.Drawing;
using System.Threading;

namespace MaSoft.MaPos.Windows {
    partial class MaPosSplashForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaPosSplashForm));
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).BeginInit();
            this.panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // marqueeProgressBarControl1
            // 
            resources.ApplyResources(this.marqueeProgressBarControl1, "marqueeProgressBarControl1");
            this.marqueeProgressBarControl1.Properties.Appearance.BorderColor = ((System.Drawing.Color)(resources.GetObject("marqueeProgressBarControl1.Properties.Appearance.BorderColor")));
            this.marqueeProgressBarControl1.Properties.LookAndFeel.SkinName = "Office 2013";
            this.marqueeProgressBarControl1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.marqueeProgressBarControl1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.marqueeProgressBarControl1.Properties.ProgressPadding = new System.Windows.Forms.Padding(0);
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            // 
            // labelControl2
            // 
            resources.ApplyResources(this.labelControl2, "labelControl2");
            // 
            // pictureEdit1
            // 
            resources.ApplyResources(this.pictureEdit1, "pictureEdit1");
            this.pictureEdit1.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pictureEdit1.Properties.Appearance.BackColor")));
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            // 
            // panelControl
            // 
            this.panelControl.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelControl.Appearance.BackColor")));
            this.panelControl.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this.panelControl, "panelControl");
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelControl1.Appearance.BackColor")));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this.panelControl1, "panelControl1");
            // 
            // labelDemoText
            // 
            this.labelDemoText.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelDemoText.Appearance.Font")));
            this.labelDemoText.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("labelDemoText.Appearance.ForeColor")));
            this.labelDemoText.Appearance.Options.UseFont = true;
            this.labelDemoText.Appearance.Options.UseForeColor = true;
            resources.ApplyResources(this.labelDemoText, "labelDemoText");
            // 
            // pictureEdit2
            // 
            resources.ApplyResources(this.pictureEdit2, "pictureEdit2");
            this.pictureEdit2.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pictureEdit2.Properties.Appearance.BackColor")));
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            // 
            // labelProductText
            // 
            this.labelProductText.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelProductText.Appearance.Font")));
            this.labelProductText.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("labelProductText.Appearance.ForeColor")));
            this.labelProductText.Appearance.Options.UseFont = true;
            this.labelProductText.Appearance.Options.UseForeColor = true;
            // 
            // MaPosSplashForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MaPosSplashForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaPosSplashForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).EndInit();
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
