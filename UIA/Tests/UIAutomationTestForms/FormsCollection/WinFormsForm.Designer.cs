/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12.12.2011
 * Time: 12:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace UIAutomationTestForms
{
    partial class WinFormsForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing" > true if managed resources should be disposed; otherwise, false.</param > 
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
            this.SuspendLayout();
            //  // WinFormsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Name = "WinFormsForm";
            this.Text = "WinFormsForm";
            
            //if (this.FormName != string.Empty){
                this.Name = this.FormName;
            //}
            //if (this.FormTitle != string.Empty){
                this.Text = this.FormTitle;
            //}
            
            this.Shown += new System.EventHandler(this.WinFormsFormShown);
            this.ResumeLayout(false);
        }
    }
}
