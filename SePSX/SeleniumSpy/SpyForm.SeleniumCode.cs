/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/11/2012
 * Time: 12:52 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationSpy
{
    using System.Windows.Forms;

//    using System;
//    using System.Diagnostics;
    using SePSX;
    
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
            TranscriptCmdletBase cmdlet = 
                new TranscriptCmdletBase();
            
            
            cmdlet.PassThru = false;
            cmdlet.Wait = true;
            cmdlet.Seconds = 60 * 60 * 24;
            
            Recorder.RecordActions(cmdlet, (new JsRecorder()), cmdlet.Language);
            
            //
            //
            // write result to a file
            //
            //
            
        }
    }
}
