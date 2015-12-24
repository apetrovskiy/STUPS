/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 8:21 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
namespace UIAutomationTestForms
{
    partial class WinFormsTripled
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        
        private System.Windows.Forms.Button btnSecondForm;
        
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
            
//            this.button1 = new System.Windows.Forms.Button();
//            this.SuspendLayout();
//            // 
//            // button1
//            // 
//            this.button1.Location = new System.Drawing.Point(43, 32);
//            this.button1.Name = "button1";
//            this.button1.Size = new System.Drawing.Size(71, 27);
//            this.button1.TabIndex = 0;
//            this.button1.Text = "button1";
//            this.button1.UseVisualStyleBackColor = true;
//            this.button1.Click += new System.EventHandler(this.Button1Click);
//            // 
//            // MainForm
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(284, 261);
//            this.Controls.Add(this.button1);
//            this.Name = "MainForm";
//            this.Text = "formTest";
//            this.Load += new System.EventHandler(this.MainFormLoad);
//            this.Shown += new System.EventHandler(this.MainFormShown);
//            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.MainFormControlAdded);
//            this.ResumeLayout(false);
            
            this.btnSecondForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSecondForm
            // 
            //this.btnSecondForm.Location = new System.Drawing.Point(40, 40);
            this.btnSecondForm.Location = new System.Drawing.Point(100, 100);
            this.btnSecondForm.Name = "btnSecondForm";
            this.btnSecondForm.Size = new System.Drawing.Size(71, 27);
            this.btnSecondForm.TabIndex = 0;
            this.btnSecondForm.Text = "The second form";
            this.btnSecondForm.Visible = true;
            this.btnSecondForm.Enabled = true;
            //this.btnSecondForm.Left = 100;
            //this.btnSecondForm.Top = 100;
            this.btnSecondForm.UseVisualStyleBackColor = true;
            this.btnSecondForm.Click += new System.EventHandler(this.btnSecondFormClick);
            
            // 
            // WinFormsTripled
            // 
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            
            this.Controls.Add(this.btnSecondForm);
            
            //this.Load += new System.EventHandler(this.WinFormsTripledLoad);
            //this.Shown += new System.EventHandler(this.WinFormsTripledShown);
            //this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.WinFormsTripledControlAdded);
            
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "WinFormsTripled";
            this.Name = "WinFormsTripled";
            
            
            this.ResumeLayout(false);
        }
    }
}
