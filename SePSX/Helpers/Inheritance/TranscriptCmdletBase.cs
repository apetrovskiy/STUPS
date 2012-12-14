/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/7/2012
 * Time: 6:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TranscriptCmdletBase.
    /// </summary>
    public class TranscriptCmdletBase : CommonCmdletBase
    {
        public TranscriptCmdletBase()
        {
            this.PassThru = false;
            this.Language = RecorderLanguages.PowerShell;
        }
        
        
        #region Parameters
        [Parameter(Mandatory = false,
                   Position = 0)]
        public string FileName { get; set; }
        
        // duplicated 20121007
        [Alias("Milliseconds")]
        [Parameter(Mandatory = false)]
        public int Timeout { get; set; }
        [Parameter(Mandatory = false)]
        public int Seconds {
            get { return Timeout / 1000; }
            set{ Timeout = value * 1000; }
        }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] OnSleepAction { get; set; }
        
        
        [Parameter(Mandatory = false)]
        //public virtual SwitchParameter PassThru { get; set; }
        public SwitchParameter PassThru { get; set; }
        
        
        [Parameter(Mandatory = false)]
        public RecorderLanguages Language { get; set; }
        #endregion Parameters
        
        
        //internal bool Wait { get; set; }
        public bool Wait { get; set; }
    }
}
