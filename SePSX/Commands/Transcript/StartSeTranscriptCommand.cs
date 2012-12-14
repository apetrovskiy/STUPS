/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/25/2012
 * Time: 2:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands.Transcript
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of StartSeTranscriptCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeTranscript")]
    public class StartSeTranscriptCommand : TranscriptCmdletBase
    {
        public StartSeTranscriptCommand()
        {
            this.Wait = true;
        }
        
        protected override void BeginProcessing()
        {
            this.CheckParameters();
            
            bool highlightParent = Preferences.HighlightParent;
            Preferences.HighlightParent = false;
            //
            //
//            using (System.IO.StreamReader reader = 
//                new System.IO.StreamReader(
//                       @"C:\Projects\PS\STUPS\samples\spy_code.txt")) {
//                JSRecorder.constRecorderInjectScript = 
//                    reader.ReadToEnd();
//                reader.Close();
//            }
//            using (System.IO.StreamReader reader = 
//                   new System.IO.StreamReader(
//                       @"C:\Projects\PS\STUPS\samples\spy_getElement.txt")) {
//                JSRecorder.constRecorderGetElement = 
//                    reader.ReadToEnd();
//                reader.Close();
//            }
//            using (System.IO.StreamReader reader = 
//                   new System.IO.StreamReader(
//                       @"C:\Projects\PS\STUPS\samples\spy_clear.txt")) {
//                JSRecorder.constRecorderCleanRecordings = 
//                    reader.ReadToEnd();
//                reader.Close();
//            }
//            using (System.IO.StreamReader reader = 
//                new System.IO.StreamReader(
//                       @"C:\Projects\PS\STUPS\samples\spy_exit.txt")) {
//                JSRecorder.constRecorderExitRecording = 
//                    reader.ReadToEnd();
//                reader.Close();
//            }
//            using (System.IO.StreamReader reader = 
//                new System.IO.StreamReader(
//                       @"C:\Projects\PS\STUPS\samples\spy_check_injection.txt")) {
//                JSRecorder.constRecorderCheckInjection = 
//                    reader.ReadToEnd();
//                reader.Close();
//            }
//            this.WriteVerbose(JSRecorder.constRecorderInjectScript);
//            this.WriteVerbose(JSRecorder.constRecorderGetElement);
//            this.WriteVerbose(JSRecorder.constRecorderCleanRecordings);
//            this.WriteVerbose(JSRecorder.constRecorderExitRecording);
//            this.WriteVerbose(JSRecorder.constRecorderCheckInjection);
            
//            this.FileName = 
//                @"C:\1\testfile.txt";
            
            //
            //
            Recorder.RecordActions(this, (new JSRecorder()), this.Language);
            
            Recorder.WriteRecordingsToFile(this, this.FileName); //, );
            
            Preferences.HighlightParent = highlightParent;
        }
        
        protected override void StopProcessing()
        {
            this.Wait = false;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SeRecorder")]
    public class StartSeRecorderCommand : StartSeTranscriptCommand
    {
        public StartSeRecorderCommand()
        {
            
        }
    }
}
