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
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    /// <summary>
    /// Description of WinFormsMedium.
    /// </summary>
    public partial class WinFormsMedium : Form
    {
        public WinFormsMedium()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
        void BtnForm3Click(object sender, EventArgs e)
        {
            WinFormsInner innerForm = new WinFormsInner();
            innerForm.Show();
        }
    }
}
