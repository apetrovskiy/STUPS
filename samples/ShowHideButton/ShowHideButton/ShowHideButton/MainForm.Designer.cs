/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 15.02.2012
 * Time: 10:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ShowHideButton
{
	partial class MainForm
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
			this.btnShowHide = new System.Windows.Forms.Button();
			this.btnHalfHidden = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnShowHide
			// 
			this.btnShowHide.Location = new System.Drawing.Point(34, 39);
			this.btnShowHide.Name = "btnShowHide";
			this.btnShowHide.Size = new System.Drawing.Size(75, 23);
			this.btnShowHide.TabIndex = 0;
			this.btnShowHide.Text = "Hide";
			this.btnShowHide.UseVisualStyleBackColor = true;
			this.btnShowHide.Click += new System.EventHandler(this.BtnShowHideClick);
			// 
			// btnHalfHidden
			// 
			this.btnHalfHidden.Location = new System.Drawing.Point(150, 39);
			this.btnHalfHidden.Name = "btnHalfHidden";
			this.btnHalfHidden.Size = new System.Drawing.Size(75, 23);
			this.btnHalfHidden.TabIndex = 1;
			this.btnHalfHidden.Text = "Button";
			this.btnHalfHidden.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.btnHalfHidden);
			this.Controls.Add(this.btnShowHide);
			this.Name = "MainForm";
			this.Text = "ShowHideButton";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btnHalfHidden;
		private System.Windows.Forms.Button btnShowHide;
	}
}
