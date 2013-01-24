/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/11/2012
 * Time: 1:50 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationSpy
{
    using System.Windows.Forms;
    
    /// <summary>
    /// Description of SpyForm.
    /// </summary>
    public partial class SpyForm : Form
    {
        public SpyForm()
        {
        }
        
        private void startSpying_Selenium()
        {
            System.Windows.Forms.MessageBox.Show("Please download SeleniumSpy from http://SePSX.CodePlex.com");
        }
    }
}
