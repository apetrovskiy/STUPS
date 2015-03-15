/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/11/2013
 * Time: 10:14 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTestForms
{
    partial class WinFormsMedium
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnForm3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnForm3
            // 
            this.btnForm3.Location = new System.Drawing.Point(18, 22);
            this.btnForm3.Name = "btnForm3";
            this.btnForm3.Size = new System.Drawing.Size(67, 25);
            this.btnForm3.TabIndex = 0;
            this.btnForm3.Text = "Form 3";
            this.btnForm3.UseVisualStyleBackColor = true;
            this.btnForm3.Click += new System.EventHandler(this.BtnForm3Click);
            // 
            // WinFormsMedium
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnForm3);
            this.Name = "WinFormsMedium";
            this.Text = "WinFormsMedium";
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.Button btnForm3;
    }
}
