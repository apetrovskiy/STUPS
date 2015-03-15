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
    /// Description of WinFormsOuter.
    /// </summary>
    public partial class WinFormsOuter : Form
    {
        public WinFormsOuter()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
        void BtnForm2Click(object sender, EventArgs e)
        {
            WinFormsMedium mediumForm = new WinFormsMedium();
            mediumForm.Show();
        }
    }
}
