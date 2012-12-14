/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 30.11.2011
 * Time: 11:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of StopUIATranscriptCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "UIATranscript")]
    //[OutputType(new[]{ typeof(object) })]
    // public class StopUIATranscriptCommand : TranscriptCmdletBase
    internal class StopUIATranscriptCommand : TranscriptCmdletBase
    {
        #region Constructor
        public StopUIATranscriptCommand()
        {
        }
        #endregion Constructor
        
        #region Parameters
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            Global.GTranscript = false;
            
            
        }
    }
    
    /// <summary>
    /// Description of StopUIARecorderCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "UIARecorder")]
    //[OutputType(new[]{ typeof(object) })]
    // public class StopUIARecorderCommand : StopUIATranscriptCommand
    internal class StopUIARecorderCommand : StopUIATranscriptCommand
    { public StopUIARecorderCommand() { } }
}
