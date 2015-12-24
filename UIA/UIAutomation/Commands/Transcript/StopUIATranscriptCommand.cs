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
    using System.Management.Automation;

    /// <summary>
    /// Description of StopUiaTranscriptCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "UiaTranscript")]
    //[OutputType(new[]{ typeof(object) })]
    // public class StopUiaTranscriptCommand : TranscriptCmdletBase
    internal class StopUiaTranscriptCommand : TranscriptCmdletBase
    {
        #region Constructor
        public StopUiaTranscriptCommand()
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
    /// Description of StopUiaRecorderCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "UiaRecorder")]
    //[OutputType(new[]{ typeof(object) })]
    // public class StopUiaRecorderCommand : StopUiaTranscriptCommand
    internal class StopUiaRecorderCommand : StopUiaTranscriptCommand
    { public StopUiaRecorderCommand() { } }
}
