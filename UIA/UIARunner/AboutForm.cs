/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/9/2012
 * Time: 11:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace UiaRunner
{
    /// <summary>
    /// Description of AboutForm.
    /// </summary>
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
        void BtnOkClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
