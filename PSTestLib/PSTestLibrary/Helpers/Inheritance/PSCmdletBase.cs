/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/16/2012
 * Time: 6:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using System;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    using System.Collections;
    using System.Collections.ObjectModel;
    
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of PSCmdletBase.
    /// </summary>
    public abstract class PSCmdletBase : PSCmdlet //, ICommonCmdletBase
    {
        public PSCmdletBase()
        {
        }
        
        #region Parameters
            #region Actions
        [Parameter(Mandatory = false)]
        public ScriptBlock[] OnSuccessAction { get; set; }
        [Parameter(Mandatory = false)]
        public ScriptBlock[] OnErrorAction { get; set; }
        [Parameter(Mandatory = false)]
        public virtual SwitchParameter OnErrorScreenShot { get; set; }
        [Parameter(Mandatory = false)]
        internal ScriptBlock[] EventAction { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] OnSleepAction { get; set; }
            #endregion Actions
            #region Testing
        [Parameter(Mandatory = false)]
        public virtual string TestResultName { get; set; }
        [Parameter(Mandatory = false)]
        public virtual string TestResultId { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter TestPassed { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter KnownIssue { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter TestLog { get; set; }
            #endregion Testing
//        // 20120208
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Highlight { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter HighlightParent { get; set; }
////        [Parameter(Mandatory = false)]
////        public SwitchParameter HighlightFirstChild { get; set; }
        #endregion Parameters
        
        #region Properties
        protected AutomationElement EventSource { get; set; }
        protected AutomationEventArgs EventArgs { get; set; }
        
        //public static System.Collections.Generic.List<object> UnitTestOutput { get; set; }
        //public static UnitTestOutputClass UnitTestOutput { get; set; }
        #endregion Properties
        
        public static bool UnitTestMode { get; set; }
        
        private static bool CmdletParametersCheckingOn { get; set; }
        public static void SetCmdletParametersCheckingOn(bool check)
        {
            CmdletParametersCheckingOn = check;
        }
        protected void CheckCmdletParameters()
        {
            if (CmdletParametersCheckingOn) {
                Exception eExit =
                    new Exception("Parameters checked");
                throw eExit;
            }
        }
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
        }
        
        // 20130430
        //protected abstract void WriteLog(string logRecord);
        protected abstract void WriteLog(LogLevels logLevel, string logRecord);
        
        public static bool EnableTrace { get; set; }
        
//        protected abstract bool WriteObjectMethod010CheckOutputObject(object outputObject);
//        protected abstract void WriteObjectMethod020Highlight(PSCmdletBase cmdlet, object outputObject);
//        protected abstract void WriteObjectMethod030RunScriptBlocks(PSCmdletBase cmdlet, object outputObject);
//        protected abstract void WriteObjectMethod040SetTestResult(PSCmdletBase cmdlet, object outputObject);
//        protected abstract void WriteObjectMethod045OnSuccessScreenshot(PSCmdletBase cmdlet, object outputObject);
//        protected abstract void WriteObjectMethod050OnSuccessDelay(PSCmdletBase cmdlet, object outputObject);
//        protected abstract void WriteObjectMethod060OutputResult(PSCmdletBase cmdlet, object outputObject);
//        protected abstract void WriteObjectMethod070Report(PSCmdletBase cmdlet, object outputObject);
//        protected abstract void WriteObjectMethod080ReportFailure();
        
        protected abstract bool CheckSingleObject(PSCmdletBase cmdlet, object outputObject);
        protected abstract void BeforeWriteSingleObject(PSCmdletBase cmdlet, object outputObject);
        protected abstract void WriteSingleObject(PSCmdletBase cmdlet, object outputObject);
        protected abstract void AfterWriteSingleObject(PSCmdletBase cmdlet, object outputObject);
        protected abstract void BeforeWriteCollection(PSCmdletBase cmdlet, object[] outputObjectCollection);
        protected abstract void BeforeWriteCollection(PSCmdletBase cmdlet, System.Collections.Generic.List<object> outputObjectCollection);
        protected abstract void BeforeWriteCollection(PSCmdletBase cmdlet, ArrayList outputObjectCollection);
        protected abstract void BeforeWriteCollection(PSCmdletBase cmdlet, IList outputObjectCollection);
        protected abstract void BeforeWriteCollection(PSCmdletBase cmdlet, IEnumerable outputObjectCollection);
        protected abstract void BeforeWriteCollection(PSCmdletBase cmdlet, ICollection outputObjectCollection);
        protected abstract void BeforeWriteCollection(PSCmdletBase cmdlet, Hashtable outputObjectCollection);
        protected abstract void AfterWriteCollection(PSCmdletBase cmdlet, object[] outputObjectCollection);
        protected abstract void AfterWriteCollection(PSCmdletBase cmdlet, System.Collections.Generic.List<object> outputObjectCollection);
        protected abstract void AfterWriteCollection(PSCmdletBase cmdlet, ArrayList outputObjectCollection);
        protected abstract void AfterWriteCollection(PSCmdletBase cmdlet, IList outputObjectCollection);
        protected abstract void AfterWriteCollection(PSCmdletBase cmdlet, IEnumerable outputObjectCollection);
        protected abstract void AfterWriteCollection(PSCmdletBase cmdlet, ICollection outputObjectCollection);
        protected abstract void AfterWriteCollection(PSCmdletBase cmdlet, Hashtable outputObjectCollection);
        
        public void WriteObject(PSCmdletBase cmdlet, object outputObject)
        {
            if (PSCmdletBase.UnitTestMode) {
                
                UnitTestOutput.CheckInitialized();

                UnitTestOutput.StartAddingOutput();

            }

            cmdlet.WriteVerbose(cmdlet, "outputting the object");
            
            this.writeSingleObject(cmdlet, outputObject);

        }
        
        public virtual void WriteObject(PSCmdletBase cmdlet, object[] outputObjectCollection)
        {
            BeforeWriteCollection(cmdlet, outputObjectCollection);
            
            if (PSCmdletBase.UnitTestMode) {

                UnitTestOutput.CheckInitialized();

                UnitTestOutput.StartAddingOutput();

            }

            for (int i = 0; i < outputObjectCollection.Length; i++) {

                this.writeSingleObject(cmdlet, outputObjectCollection[i]);

            }
            
            AfterWriteCollection(cmdlet, outputObjectCollection);
        }
        
        public virtual void WriteObject(PSCmdletBase cmdlet, System.Collections.Generic.List<object> outputObjectCollection)
        {
            BeforeWriteCollection(cmdlet, outputObjectCollection);
            
            if (PSCmdletBase.UnitTestMode) {
                
                UnitTestOutput.CheckInitialized();

                UnitTestOutput.StartAddingOutput();
            }
            // 20121117
            //for (int i = 0; i < outputObjectCollection.Count; i++) {
            foreach (var item in outputObjectCollection) {
                this.writeSingleObject(cmdlet, item);
            }
            //}
            
            AfterWriteCollection(cmdlet, outputObjectCollection);
        }
       
        public virtual void WriteObject(PSCmdletBase cmdlet, ArrayList outputObjectCollection)
        {
            BeforeWriteCollection(cmdlet, outputObjectCollection);
            
            if (PSCmdletBase.UnitTestMode) {
                
                UnitTestOutput.CheckInitialized();

                //UnitTestOutput.Add(outputObjectCollection);
                
                UnitTestOutput.StartAddingOutput();
            }

            for (int i = 0; i < outputObjectCollection.Count; i++) {
                this.WriteObject(cmdlet, outputObjectCollection[i]);
            }
            
            AfterWriteCollection(cmdlet, outputObjectCollection);
        }
        
        // 20121112
        public virtual void WriteObject(PSCmdletBase cmdlet, IList outputObjectCollection)
        {
            BeforeWriteCollection(cmdlet, outputObjectCollection);
            
            if (PSCmdletBase.UnitTestMode) {

                UnitTestOutput.CheckInitialized();

                UnitTestOutput.StartAddingOutput();
            }

            foreach (object item in outputObjectCollection) {
                this.writeSingleObject(cmdlet, item);
            }
            
            AfterWriteCollection(cmdlet, outputObjectCollection);
        }
        
        // 20121112
        public virtual void WriteObject(PSCmdletBase cmdlet, IEnumerable outputObjectCollection)
        {
            BeforeWriteCollection(cmdlet, outputObjectCollection);
            
            if (PSCmdletBase.UnitTestMode) {
                
                UnitTestOutput.CheckInitialized();

                UnitTestOutput.StartAddingOutput();
            }
            IEnumerator en = outputObjectCollection.GetEnumerator();
            while (en.MoveNext()) {
                this.writeSingleObject(cmdlet, en.Current);
            }
            
            AfterWriteCollection(cmdlet, outputObjectCollection);
        }
        
        // 20121112
        public virtual void WriteObject(PSCmdletBase cmdlet, string outputObject)
        {
            if (PSCmdletBase.UnitTestMode) {
                
                UnitTestOutput.CheckInitialized();

                UnitTestOutput.StartAddingOutput();
            }
            this.writeSingleObject(cmdlet, outputObject);
        }
        
        public virtual void WriteObject(PSCmdletBase cmdlet, ICollection outputObjectCollection)
        {
            BeforeWriteCollection(cmdlet, outputObjectCollection);
            
            if (PSCmdletBase.UnitTestMode) {
                
                UnitTestOutput.CheckInitialized();

                UnitTestOutput.StartAddingOutput();
            }
            foreach (var outputObject in outputObjectCollection) {
this.WriteVerbose(this, "something to output!!!!!!!!!!1");
                //WriteObject(cmdlet, outputObject);
                this.writeSingleObject(cmdlet, outputObject);
            }
            
            AfterWriteCollection(cmdlet, outputObjectCollection);
        }
        
        public virtual void WriteObject(PSCmdletBase cmdlet, Hashtable outputObjectCollection)
        {
            BeforeWriteCollection(cmdlet, outputObjectCollection);
            
            if (PSCmdletBase.UnitTestMode) {
                
                UnitTestOutput.CheckInitialized();

                UnitTestOutput.StartAddingOutput();
            }
            this.writeSingleObject(cmdlet, outputObjectCollection);
            
            AfterWriteCollection(cmdlet, outputObjectCollection);
        }
        
        private void writeSingleObject(PSCmdletBase cmdlet, object outputObject)
        {
            //if (WriteObjectMethod010CheckOutputObject(outputObject)) {
            if (CheckSingleObject(cmdlet, outputObject)) {
                
                cmdlet.WriteVerbose(cmdlet, "the output object is not null");

//                WriteObjectMethod020Highlight(cmdlet, outputObject);
//
//                WriteObjectMethod030RunScriptBlocks(cmdlet, outputObject);
//
//                WriteObjectMethod040SetTestResult(cmdlet, outputObject);
//
//                WriteObjectMethod045OnSuccessScreenshot(cmdlet, outputObject);
//
//                WriteObjectMethod050OnSuccessDelay(cmdlet, outputObject);
                
                BeforeWriteSingleObject(cmdlet, outputObject);

                //WriteSingleObject(cmdlet, outputObject);
                
                try {

                    if (PSCmdletBase.UnitTestMode) {

                        UnitTestOutput.Add(outputObject);

                    } else {

//                        WriteObjectMethod060OutputResult(cmdlet, outputObject);
                        WriteSingleObject(cmdlet, outputObject);

                    }
                }
                catch {}
                
                
                //WriteObjectMethod060OutputResult(cmdlet, outputObject);

                AfterWriteSingleObject(cmdlet, outputObject);

//                WriteObjectMethod070Report(cmdlet, outputObject);

                //WriteObjectMethod080ReportFailure();
            
            } else {

            }
        }
        



        protected abstract void WriteErrorMethod010RunScriptBlocks(PSCmdletBase cmdlet);
        protected abstract void WriteErrorMethod020SetTestResult(PSCmdletBase cmdlet, ErrorRecord errorRecord);
        protected abstract void WriteErrorMethod030ChangeTimeoutSettings(PSCmdletBase cmdlet, bool terminating);
        protected abstract void WriteErrorMethod040AddErrorToErrorList(PSCmdletBase cmdlet, ErrorRecord errorRecord);
        protected abstract void WriteErrorMethod045OnErrorScreenshot(PSCmdletBase cmdlet);
        protected abstract void WriteErrorMethod050OnErrorDelay(PSCmdletBase cmdlet);
        protected abstract void WriteErrorMethod060OutputError(PSCmdletBase cmdlet, ErrorRecord errorRecord, bool terminating);
        protected abstract void WriteErrorMethod070Report(PSCmdletBase cmdlet);
        
        //protected abstract void BeforeWriteError(PSCmdletBase cmdlet, ErrorRecord errorRecord);
        //protected abstract void WriteErrorObject(PSCmdletBase cmdlet, ErrorRecord errorRecord);
        //protected abstract void AfterWriteError(PSCmdletBase cmdlet, ErrorRecord errorRecord);
        
        public void WriteError(PSCmdletBase cmdlet, ErrorRecord errorRecord, bool terminating)
        {
            // run error script blocks
            WriteErrorMethod010RunScriptBlocks(cmdlet);;
            
            // add test result detail
            
            // close test result
            WriteErrorMethod020SetTestResult(cmdlet, errorRecord);
            
            // set the Turbo timeout
            WriteErrorMethod030ChangeTimeoutSettings(cmdlet, terminating);
            
            // write to the Error list
            WriteErrorMethod040AddErrorToErrorList(cmdlet, errorRecord);
            
            // on error screenshot
            WriteErrorMethod045OnErrorScreenshot(cmdlet);
            
            // on error sleep
            WriteErrorMethod050OnErrorDelay(cmdlet);
            
            
            //BeforeWriteError(cmdlet, errorRecord);
            
            // output the error
            
            //WriteErrorObject(cmdlet, errorRecord);
            
            WriteErrorMethod060OutputError(cmdlet, errorRecord, terminating);
            
            
            //AfterWriteError(cmdlet, errorRecord);
            
            // ? ? ? ? 
            WriteErrorMethod070Report(cmdlet); //, outputObject);
        }
        
        public void WriteError(PSCmdletBase cmdlet, string message, string errorId, ErrorCategory category, bool terminating)
        {
            ErrorRecord err = 
                new ErrorRecord(
                    new Exception(message),
                    errorId,
                    category,
                    null);
            err.ErrorDetails = 
                new ErrorDetails(message);
            WriteError(cmdlet, err, terminating);
        }
        
        // temporary
        public void WriteVerbose(PSCmdletBase cmdlet, string text)
        {
            // 20121117
            //if (!this.UnitTestMode) {
            if (!UnitTestMode) {
                try {
                string cmdletName = "? : ";
    
                if (null != cmdlet) {
    
                    try {
    
                        cmdletName = 
                            CmdletSignature(cmdlet);
    
                        cmdlet.WriteVerbose(cmdletName + text);
    
                    }
                    catch {
                        cmdlet.WriteVerbose(cmdletName + "failed");
                    }
                } else {
                    try {
                        cmdlet.WriteVerbose(cmdletName + text);
                    }
                    catch {}
                }
                
                // WriteLog(reportString);
                
                    // 20130430
                    WriteLog(LogLevels.Trace, text);
                }
                catch (Exception eNotUsed) {
                    // ??
                }
            }
        }
        
        public void WriteVerbose(PSCmdletBase cmdlet, object obj)
        {

            string cmdletName = "? : ";
            string objectString = string.Empty;
            try {
                objectString = obj.ToString();
            }
            catch {}

            if (null != cmdlet) {

                try {

                    cmdletName = 
                        CmdletSignature(cmdlet);

                    cmdlet.WriteVerbose(cmdletName + objectString);
                }
                catch {
                    cmdlet.WriteVerbose(cmdletName + "failed");
                }
            } else {
                cmdlet.WriteVerbose(cmdletName + objectString);
            }
        }
        
        public void WriteTrace(PSCmdletBase cmdlet, object obj)
        {
            if (EnableTrace) {
                Console.WriteLine(obj);
            }
        }
        
        protected string GetGeneratedTestResultNameByPosition(
            string initialString, 
            int? position)
        {
            string result = string.Empty;
            
            if (!initialString.Contains("|")) {
                result = initialString;
            } else {
                try {
                    string[] results = 
                        initialString.Split('|');
                    result = results[(int)(position - 1)].Trim();
                }
                catch {
                    
                }
            }
            
            return result;
        }
        
            #region Cmdlet Signature
        //protected string CmdletName(PSCmdletBase cmdlet)
        public string CmdletName(PSCmdletBase cmdlet)
        {
            string result = String.Empty;
            if (null == cmdlet) return result;
            result = 
                cmdlet.GetType().Name;
            // 20130501
//            if (result.Contains("Se")) {
//                result = 
//                    result.Replace("Se", "-Se");
//            } else 
            if (result.Contains("UIA")) {
                result = 
                    result.Replace("UIA", "-UIA");
            } else if (result.Contains("TMX")) {
                result = 
                    result.Replace("TMX", "-TMX");
            } else if (result.Contains("AWS")) {
                result = 
                    result.Replace("AWS", "-AWS");
            } else if (result.Contains("ESXi")) {
                result = 
                    result.Replace("ESXi", "-ESXi");
            }
            else if (result.Contains("TAMS")) {
                result = 
                    result.Replace("TAMS", "-TAMS");
            }
            // 20130501
            else if (result.Contains("Dt")) {
                result = 
                    result.Replace("Dt", "-Dt");
            }
            else if (result.Contains("Tu")) {
                result = 
                    result.Replace("Tu", "-Tu");
            }
            else if (result.Contains("Se")) {
                result = 
                    result.Replace("Se", "-Se");
            }
            result = 
                result.Replace("Command", "");
            return result;
        }
            
        protected string CmdletSignature(PSCmdletBase cmdlet)
        {
            string result = this.CmdletName(cmdlet);
            result += ": ";
            return result;
        }
            #endregion Cmdlet Signature
        
        #region utilities
        public string ConvertObjectArrayToString(object[] array)
        {
            string result = string.Empty;
            
            if (null == array || 0 == array.Length) {
                return result;
            }
            
            foreach (var element in array) {
                
                result += " ";
                result += element.ToString();
            }
            
            return result;
        }
        
        protected string ConvertHashtableToString(Hashtable hashtable)
        {
            string result = string.Empty;
            
            if (null == hashtable || 0 == hashtable.Count) {
                return result;
            }
            
            result += "@{";
            
            foreach (var key in hashtable.Keys) {
                
                result += key.ToString() + "=" + hashtable[key].ToString() + ";";
            }
            
            result += "}";
            
            return result;
        }
        
        protected string ConvertHashtablesArrayToString(Hashtable[] hashtables)
        {
            string result = string.Empty;
            
            if (null == hashtables || 0 == hashtables.Length) {
                return result;
            }
            
            foreach (Hashtable hashtable in hashtables) {
                
                result += ",";
                result +=
                    this.ConvertHashtableToString(hashtable);
            }
            
            result = result.Substring(1);
            
            return result;
        }
        #endregion utilities
        
        // 20130318
        //protected System.Collections.Generic.Dictionary<string, string> ConvertHashtableToDictionary(
        protected System.Collections.Generic.Dictionary<string, object> ConvertHashtableToDictionary(
            Hashtable hashtable)
        {
            // 20130318
            //System.Collections.Generic.Dictionary<string, string> dict = 
            //    new System.Collections.Generic.Dictionary<string, string>();
            System.Collections.Generic.Dictionary<string, object> dict =
                new System.Collections.Generic.Dictionary<string, object>();
            
            this.WriteVerbose(this, hashtable.Keys.Count.ToString());
            
            foreach (string key1 in hashtable.Keys) {
                
                string keyUpper = key1.ToUpper();

                this.WriteVerbose(this, "found key: " + keyUpper);
                
                // 20130318
                //dict.Add(keyUpper, hashtable[key1].ToString());
                // 20130506
                //dict.Add(keyUpper, hashtable[key1]);
                var rawData = hashtable[key1];
                dict.Add(keyUpper, rawData);
                
                this.WriteVerbose(
                    this,
                    "added to the dictionary: " +
                    keyUpper +
                    " = " +
                    dict[keyUpper].ToString());
            }
            
            return dict;
        }
        
        protected void runTwoScriptBlockCollections(
            ScriptBlock[] scriptblocksSet1,
            ScriptBlock[] scriptblocksSet2,
            // 20130318
            //PSCmdletBase cmdlet)
            PSCmdletBase cmdlet,
            object[] parameters)
        {
            cmdlet.WriteVerbose(cmdlet, "preparing scriptblocks");
            
            System.Collections.Generic.List<ScriptBlock> scriptblocks =
                new System.Collections.Generic.List<ScriptBlock>();

            try {
                if (scriptblocksSet1 != null &&
                    scriptblocksSet1.Length > 0) {
    
                    foreach (ScriptBlock sb in scriptblocksSet1) {
    
                        scriptblocks.Add(sb);
                    }
                }
    
                if (scriptblocksSet2 != null &&
                    scriptblocksSet2.Length > 0) {
    
                    foreach (ScriptBlock sb in scriptblocksSet2) {
    
                        scriptblocks.Add(sb);
                    }
                }
                
//                if (null == scriptblocks || 0 == scriptblocks.Count) {
//                    
//                    cmdlet.WriteVerbose(cmdlet, "there is no any StopAction scriptblock");
//                    
//                    //throw new Exception("There are no StopAction scriptblocks, define at least one");
//                    cmdlet.WriteError(
//                        cmdlet,
//                        "There are no StopAction scriptblocks, define at least one",
//                        "NoStopActionScripblocks",
//                        ErrorCategory.InvalidArgument,
//                        true);
//                }
                
                cmdlet.WriteVerbose(cmdlet, "scriptblocks were prepared");
            }
            catch (Exception eScriptblocksPreparation) {
                
                cmdlet.WriteVerbose(cmdlet, "Scriptblocks are not going to be run");
                
                cmdlet.WriteVerbose(cmdlet, eScriptblocksPreparation.Message);
                
                cmdlet.WriteError(
                    cmdlet,
                    eScriptblocksPreparation.Message,
                    "ScriptblocksNotPrepared",
                    ErrorCategory.InvalidOperation,
                    true);
            }

            // 20130318
            //runScriptBlocks(scriptblocks, cmdlet, false);
            // 20130319
            try {
                
                cmdlet.WriteVerbose(cmdlet, "running scriptblocks");
                
                runScriptBlocks(scriptblocks, cmdlet, false, parameters);
                
                cmdlet.WriteVerbose(cmdlet, "Scriptblocks finished successfully");
            }
            catch (Exception eScriptBlocks) {
                
                cmdlet.WriteVerbose(cmdlet, "Scriptblocks failed");
                
                cmdlet.WriteVerbose(cmdlet, eScriptBlocks.Message);
                
                cmdlet.WriteError(
                    cmdlet,
                    eScriptBlocks.Message,
                    "ScriptblocksFailed",
                    ErrorCategory.InvalidResult,
                    true);
            }
        }
        
        // 20120816
        public void runScriptBlocks(
            System.Collections.Generic.List<ScriptBlock> scriptblocks,
            PSCmdletBase cmdlet,
            // 20130318
            //bool eventHandlers)
            bool eventHandlers,
            object[] parameters)
        {
            try {

                if (scriptblocks != null &&
                    scriptblocks.Count > 0) {
                    
                    cmdlet.WriteVerbose(cmdlet, "there are " + scriptblocks.Count.ToString() + " scriptblock(s) to run");
                    
                    foreach (ScriptBlock sb in scriptblocks) {

                        if (sb != null) {

                            try {
                                if (eventHandlers) {

                                    cmdlet.WriteVerbose(cmdlet, "run event handler");
                                    
                                    runScriptBlock runner = new runScriptBlock(runSBEvent);

                                    runner(sb, cmdlet.EventSource, cmdlet.EventArgs);

                                } else {
                                    
                                    cmdlet.WriteVerbose(cmdlet, "run action with parameters");

                                    // 20130318
                                    //runScriptBlock runner = new runScriptBlock(runSBAction);
                                    //runner(sb, cmdlet.EventSource, cmdlet.EventArgs);
                                    runScriptBlockWithParameters runnerWithParams = new runScriptBlockWithParameters(runSBActionWithParams);
                                    
                                    cmdlet.WriteVerbose(cmdlet, "the scriptblock runner has been created");
                                    
                                    // 20130606
                                    try {
                                        cmdlet.WriteVerbose(cmdlet, "listing parameters");
                                        if (null == parameters || 0 == parameters.Length) {
                                            cmdlet.WriteVerbose(cmdlet, "there are no parameters");
                                        } else {
                                            foreach (var singleParam in parameters) {
                                                cmdlet.WriteVerbose(cmdlet, singleParam);
                                            }
                                        }
                                    }
                                    catch (Exception eListParameters) {
                                        cmdlet.WriteVerbose(cmdlet, eListParameters.Message);
                                    }
                                    
                                    runnerWithParams(sb, parameters);
                                    
                                    cmdlet.WriteVerbose(cmdlet, "the scripblock runner has finished");
                                }
                            } catch (Exception eInner) {

                                // 20130318
//                                ErrorRecord err = 
//                                    new ErrorRecord(
//                                        eInner,
//                                        "InvokeException",
//                                        ErrorCategory.OperationStopped,
//                                        sb);
//                                err.ErrorDetails = 
//                                    new ErrorDetails("Error in " +
//                                                     sb.ToString());
//                                WriteError(this, err, false);
                                
//                                this.WriteError(
//                                    this,
//                                    "Error in " +
//                                    sb.ToString() +
//                                    ". " +
//                                    eInner.Message,
//                                    "InvokeException",
//                                    ErrorCategory.OperationStopped,
//                                    // 20130318
//                                    //false);
//                                    true);
                                    
                                    // 20130606
                                    cmdlet.WriteVerbose(cmdlet, eInner.Message);
                                    //throw;
                                    throw new Exception("Failed to run scriptblock");
                            }
                        }
                    }
                }
            } catch (Exception eOuter) {
                // 20130318
//                WriteError(this, 
//                           new ErrorRecord(eOuter, "runScriptBlocks", ErrorCategory.InvalidArgument, null),
//                           true);
                
//                this.WriteError(
//                    this,
//                    eOuter.Message,
//                    "runScriptBlocks",
//                    ErrorCategory.InvalidArgument,
//                    true);
                    
                // 20130606
                cmdlet.WriteVerbose(cmdlet, eOuter.Message);
                //throw;
                throw new Exception("Failed to run scriptblocks");
            }
        }
        //#endregion Invoke-UIAScript
        
        
        protected virtual void SaveEventInput(
            AutomationElement src,
            AutomationEventArgs e,
            string programmaticName,
            bool infoAdded)
        {
            
        }
        
        #region Event delegate
        private void runSBEvent(ScriptBlock sb, 
                                AutomationElement src,
                                AutomationEventArgs e)
        {
            
            // inform the Wait-UIAEventRaised cmdlet
            SaveEventInput(
                src,
                e,
                e.EventId.ProgrammaticName,
                true);
//            try {
//                CurrentData.LastEventSource = src; // as AutomationElement;
//                CurrentData.LastEventArgs = e; // as AutomationEventArgs;
//                CurrentData.LastEventType = e.EventId.ProgrammaticName;
//                CurrentData.LastEventInfoAdded = true;
//            }
//            catch {
//                //WriteVerbose(this, "failed to register an event in the collection");
//            }
            
            // 20120206 Collection<PSObject >  psObjects = null;
            try {
                System.Management.Automation.Runspaces.Runspace.DefaultRunspace =
                    RunspaceFactory.CreateRunspace();
                try {
                    System.Management.Automation.Runspaces.Runspace.DefaultRunspace.Open();
                } catch (Exception e1) {
                    // 20130318
//                    ErrorRecord err = 
//                        new ErrorRecord(e1,
//                                        "ErrorOnOpeningRunspace",
//                                        ErrorCategory.InvalidOperation,
//                                        sb);
//                    err.ErrorDetails = 
//                        new ErrorDetails(
//                            "Unable to run a scriptblock:\r\n" + 
//                            sb.ToString());
//                    WriteError(this, err, false);
                    
                    this.WriteError(
                        this,
                        "Unable to run a scriptblock:\r\n" + 
                        sb.ToString() +
                        "." +
                        e1.Message,
                        "ErrorOnOpeningRunspace",
                        ErrorCategory.InvalidOperation,
                        // 20130318
                        //false);
                        true);
                }
                try {
                    System.Collections.Generic.List<object> inputParams = 
                        new System.Collections.Generic.List<object>();
                    inputParams.Add(src);
                    inputParams.Add(e);
                    object[] inputParamsArray = inputParams.ToArray();
                    // psObjects = 
                        sb.InvokeReturnAsIs(inputParamsArray);
                        // sb.Invoke(inputParamsArray);
                    
                } catch (Exception e2) {
                    // 20130318
//                    ErrorRecord err = 
//                        new ErrorRecord(e2,
//                                        "ErrorInOpenedRunspace",
//                                        ErrorCategory.InvalidOperation,
//                                        sb);
//                    err.ErrorDetails = 
//                        new ErrorDetails("Unable to run a scriptblock");
//                    WriteError(this, err, true);
                    
                    this.WriteError(
                        this,
                        "Unable to run a scriptblock." + 
                        e2.Message,
                        "ErrorInOpenedRunspace",
                        ErrorCategory.InvalidOperation,
                        true);
                }
// psObjects =
// sb.Invoke();
            } catch (Exception eOuter) {
                // 20130318
//                ErrorRecord err = 
//                    new ErrorRecord(eOuter,
//                                    "ErrorInInvokingScriptBlock", //"ErrorinCreatingRunspace",
//                                    ErrorCategory.InvalidOperation,
//                                    System.Management.Automation.Runspaces.Runspace.DefaultRunspace);
//                err.ErrorDetails = 
//                    new ErrorDetails("Unable to issue the following command:\r\n" + 
//                                     "System.Management.Automation.Runspaces.Runspace.DefaultRunspace = RunspaceFactory.CreateRunspace();" +
//                                     "\r\nException raised is\r\n" +
//                                     eOuter.Message);
                
                this.WriteError(
                    this,
                    "Unable to issue the following command:\r\n" + 
                     "System.Management.Automation.Runspaces.Runspace.DefaultRunspace = RunspaceFactory.CreateRunspace();" +
                     "\r\nException raised is\r\n" +
                     eOuter.Message,
                    "ErrorInInvokingScriptBlock",
                    ErrorCategory.InvalidOperation,
                    true);
            }
        }
        #endregion Event delegate
        
        
        #region Action delegate
        private void runSBAction(ScriptBlock sb, 
                                 AutomationElement src,
                                 AutomationEventArgs e)
        {
            Collection<PSObject> psObjects = null;
            try {
                psObjects =
                    sb.Invoke();
// int counter = 0;
// foreach (PSObject pso in psObjects) {
//  //if pso.
// counter++;
// WriteVerbose("result " + counter.ToString() + ":");
// WriteVerbose(pso.ToString());
//  //WriteObject(pso.TypeNames
// foreach ( string typeName in pso.TypeNames) {
// WriteVerbose(typeName);
// }
// }
            } catch (Exception eOuter) {
                // 20130318
//                ErrorRecord err = 
//                    new ErrorRecord(eOuter,
//                                    "ErrorInInvokingScriptBlock",
//                                    ErrorCategory.InvalidOperation,
//                                    System.Management.Automation.Runspaces.Runspace.DefaultRunspace);
//                err.ErrorDetails = 
//                    new ErrorDetails(
//                        "Unable to issue the following command:\r\n" +
//                        sb.ToString() + 
//                        "\r\nThe exception raised is\r\n" + 
//                        eOuter.Message);
//                                     //"System.Management.Automation.Runspaces.Runspace.DefaultRunspace = RunspaceFactory.CreateRunspace();");
//                WriteError(err);
                
                this.WriteError(
                    this,
                    "Unable to issue the following command:\r\n" +
                    sb.ToString() + 
                    "\r\nThe exception raised is\r\n" + 
                    eOuter.Message,
                    "ErrorInInvokingScriptBlock",
                    ErrorCategory.InvalidOperation,
                    // 20130318
                    //false);
                    true);
            }
        }
        #endregion Action delegate
        
        #region Action delegate
        private void runSBActionWithParams(
            ScriptBlock sb,
            object[] parameters)
        {
            Collection<PSObject> psObjects = null;
            try {
                
                this.WriteVerbose(
                    this,
                    "select whether a scripblock has parameters or doesn't");
                
                if (null == parameters || 0 == parameters.Length) {
                    
                    this.WriteVerbose(
                        this,
                        "without parameters");
                    
                    psObjects =
                        sb.Invoke();

                } else {

                    this.WriteVerbose(
                        this,
                        "with parameters");
                    
                    psObjects =
                        sb.Invoke(parameters);

                }
                
                this.WriteVerbose(
                    this,
                    "scriptblock has been fired successfully");

            } catch (Exception eOuter) {

                // 20130318
//                ErrorRecord err = 
//                    new ErrorRecord(eOuter,
//                                    "ErrorInInvokingScriptBlock",
//                                    ErrorCategory.InvalidOperation,
//                                    System.Management.Automation.Runspaces.Runspace.DefaultRunspace);
//                err.ErrorDetails = 
//                    new ErrorDetails(
//                        "Unable to issue the following command:\r\n" +
//                        sb.ToString() + 
//                        "\r\nThe exception raised is\r\n" + 
//                        eOuter.Message);
//                                     //"System.Management.Automation.Runspaces.Runspace.DefaultRunspace = RunspaceFactory.CreateRunspace();");
//                WriteError(err);
                
                // 20130606
//                this.WriteVerbose(
//                    this,
//                    eOuter.InnerException.Message);
                
                this.WriteError(
                    this,
                    "Unable to issue the following command:\r\n" +
                    sb.ToString() + 
                    "\r\nThe exception raised is\r\n" + 
                    eOuter.Message,
                    "ErrorInInvokingScriptBlock",
                    ErrorCategory.InvalidOperation,
                    // 20130318
                    //false);
                    true);

            }
        }
        #endregion Action delegate
    }
    
    #region Action delegate
    delegate void runScriptBlock(ScriptBlock sb, 
                                 AutomationElement src, 
                                 AutomationEventArgs e);
    #endregion Action delegate
    
    #region Action delegate
    delegate void runScriptBlockWithParameters(
        ScriptBlock sb,
        object[] parameters);
    #endregion Action delegate
}