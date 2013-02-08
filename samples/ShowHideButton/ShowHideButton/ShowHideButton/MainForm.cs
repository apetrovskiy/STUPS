/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 15.02.2012
 * Time: 10:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ShowHideButton
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BtnShowHideClick(object sender, EventArgs e)
		{
			if (this.btnHalfHidden.Visible){
				this.btnHalfHidden.Visible = false;
				this.btnShowHide.Text = "Show";
			} else {
				this.btnHalfHidden.Visible = true;
				this.btnShowHide.Text = "Hide";
			}
		}
	}
}
