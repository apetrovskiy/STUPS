/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/29/2012
 * Time: 4:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSRunner
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
//    using System.Diagnostics;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    using System.Threading;
    
    /// <summary>
    /// 
    /// </summary>
    public delegate void PSStateChangedEventHandler(string msg);
    
    /// <summary>
    /// 
    /// </summary>
    public delegate void PSDataArrivedEventHandler(object data);

    /// <summary>
    /// Description of Runner.
    /// </summary>
    public static class Runner
    {
        // ----------------- Variables ---------------------------
        /// <summary>
        /// 
        /// </summary>
        private static Runspace testRunSpace;
        /// <summary>
        /// 
        /// </summary>
        private static Pipeline pipeline;
        //pipeline.StateChanged += new System.EventHandler(PipelineStateChanged);
        //pipeline.StateChanged += new EventHandler<PipelineStateEventArgs>(pipeline_StateChanged);
        
        // ----------------- Properties --------------------------
//        public bool Active
//        {
//            get {return testRunSpace.ResetRunspaceState}
//        }
        
        // ------------------ Events -----------------------------
        
        public static event PSStateChangedEventHandler PSCodeRunning;
        public static event PSStateChangedEventHandler PSCodeCompleted;
        public static event PSStateChangedEventHandler PSErrorThrown;
        //public static event PSStateChangedEventHandler PSDisconnected;
        public static event PSStateChangedEventHandler PSCodeStopping;
        public static event PSStateChangedEventHandler PSCodeStopped;
        public static event PSStateChangedEventHandler PSCodeNotStarted;
        
        public static event PSDataArrivedEventHandler PSOutputArrived;
        public static event PSDataArrivedEventHandler PSErrorArrived;
        
        internal static void OnPSCodeRunning(string msg) //object sender, EventArgs e)
        {
			if (PSCodeRunning != null)
				PSCodeRunning(msg);
        }
        
        internal static void OnPSCodeCompleted(string msg)
        {
			if (PSCodeCompleted != null)
				PSCodeCompleted(msg);
        }
        
        internal static void OnPSErrorThrown(string msg)
        {
			if (PSErrorThrown != null)
				PSErrorThrown(msg);
        }
        
//        internal static void OnPSDisconnected(string msg)
//        {
//            if (PSDisconnected != null) {
//                PSDisconnected(msg);
//            }
//        }
        
        internal static void OnPSCodeStopping(string msg)
        {
			if (PSCodeStopping != null)
				PSCodeStopping(msg);
        }
        
        internal static void OnPSCodeStopped(string msg)
        {
			if (PSCodeStopped != null)
				PSCodeStopped(msg);
        }
        
        internal static void OnPSCodeNotStarted(string msg)
        {
			if (PSCodeNotStarted != null)
				PSCodeNotStarted(msg);
        }
        
        internal static void OnPSOutputArrived(object data)
        {
			if (PSOutputArrived != null)
				PSOutputArrived(data);
        }
        
        internal static void OnPSErrorArrived(object data)
        {
			if (PSErrorArrived != null)
				PSErrorArrived(data);
        }
        
        // ------------------ Methods ----------------------------

        public static bool InitializeRunspace(string command)
        {
            bool result = false;
            try {
                testRunSpace = null;
                testRunSpace = RunspaceFactory.CreateRunspace();
                testRunSpace.AvailabilityChanged += new EventHandler<RunspaceAvailabilityEventArgs>(runspace_AvailabilityChanged);
                testRunSpace.StateChanged += new EventHandler<RunspaceStateEventArgs>(runspace_StateChanged);
                testRunSpace.Open();
                // 20140722
                // pipeline = null;
                
                pipeline = testRunSpace.CreatePipeline(command);
                pipeline.StateChanged += new EventHandler<PipelineStateEventArgs>(pipeline_StateChanged);
                
//if (PipelineState.Running == pipeline.PipelineStateInfo.State) {
//    pipeline.Stop();
//}
                
                pipeline.Invoke();
                result = true;
            } 
            catch (Exception eInitRunspace) {
                // Console.WriteLine(eInitRunspace.Message);
                //result = false;
                throw (eInitRunspace);
            }
            return result;
        }
        
//        public static bool IitializeRunspaceAsync(string command)
//        {
//            bool result = false;
//            try {
//                testRunSpace = null;
//                testRunSpace = RunspaceFactory.CreateRunspace();
//                testRunSpace.AvailabilityChanged += new EventHandler<RunspaceAvailabilityEventArgs>(runspace_AvailabilityChanged);
//                testRunSpace.StateChanged += new EventHandler<RunspaceStateEventArgs>(runspace_StateChanged);
//                testRunSpace.OpenAsync();
//                //testRunSpace.Open();
//                pipeline =
//                    testRunSpace.CreatePipeline(command);
//                pipeline.StateChanged += new EventHandler<PipelineStateEventArgs>(pipeline_StateChanged);
//                pipeline.InvokeAsync();
//                result = true;
//            } 
//            catch (Exception eInitRunspace) {
//                Console.WriteLine(eInitRunspace.Message);
//                result = false;
//            }
//            return result;
//        }
        
        // 20140107
        public static System.Collections.ObjectModel.Collection<PSObject> RunPSCode(
            string codeSnippet,
            bool displayRunningCode)
        {
            return RunPSCode(codeSnippet, displayRunningCode, null);
        }
        
        public static System.Collections.ObjectModel.Collection<PSObject> RunPSCode(
            string codeSnippet,
            // 20140107
            // bool displayRunningCode)
            bool displayRunningCode,
            IEnumerable inputData)
        {
            // 20140107
            // System.Collections.ObjectModel.Collection<PSObject> result = null;
            System.Collections.ObjectModel.Collection<PSObject> resultObject;
            try {
                if (displayRunningCode) {
                    reportRunningCode(codeSnippet);
                }
                pipeline =
                    testRunSpace.CreatePipeline(codeSnippet);
                pipeline.StateChanged += new EventHandler<PipelineStateEventArgs>(pipeline_StateChanged);
                // 20140107
                // System.Collections.ObjectModel.Collection<PSObject> resultObject =
                //     pipeline.Invoke();
                if (null == inputData) {
                    resultObject = pipeline.Invoke();
                } else {
                    resultObject = pipeline.Invoke(inputData);
                }
                    //pipeline.InvokeAsync();
                //pipeline.Output.
                return resultObject;
            } 
            catch (Exception eRunspace) {
                throw(eRunspace); // 20120819 ON
                // 20140107
                // result = null;
                // resultObject = null;
            }
            // 20140107
            // return result;
            return resultObject;
        }
        
        public static bool RunPSCodeAsync(string codeSnippet)
        {
            bool result = false;
            try {
                pipeline = testRunSpace.CreatePipeline(codeSnippet);
                pipeline.StateChanged += new EventHandler<PipelineStateEventArgs>(pipeline_StateChanged);
                pipeline.InvokeAsync();
                
                var handles = new WaitHandle[2];
                handles[0] = pipeline.Output.WaitHandle;
                handles[1] = pipeline.Error.WaitHandle;
                pipeline.Input.Close();
                
                while (pipeline.PipelineStateInfo.State == PipelineState.Running) {
                    switch (WaitHandle.WaitAny(handles)) {
                        case 0:
                            while (pipeline.Output.Count > 0) {
                                //
                                OnPSOutputArrived(pipeline.Output.Read());
                            }
                            break;
                        case 1:
                            while (pipeline.Error.Count > 0) {
                                //
                                OnPSErrorArrived(pipeline.Error.Read());
                            }
                            break;
                        default:
                            
                        	break;
                    }
                }
                    //pipeline.InvokeAsync();
                //pipeline.Output.
                //return resultObject;
                result = true;
            } 
            catch (Exception) {
                //throw(eRunspace);
                //result = null;
                return result;
            }
            return result;
        }
        
        public static System.Collections.ObjectModel.Collection<PSObject> RunPSScript(string scriptCode)
        {
            System.Collections.ObjectModel.Collection<PSObject> result = null;
            try {
                pipeline = testRunSpace.CreatePipeline();
                pipeline.Commands.AddScript(scriptCode);
                pipeline.StateChanged += new EventHandler<PipelineStateEventArgs>(pipeline_StateChanged);
                System.Collections.ObjectModel.Collection<PSObject> resultObject =
                    pipeline.Invoke();
                    //pipeline.InvokeAsync();
                //pipeline.Output.
                return resultObject;
            } 
            catch (Exception) {
                //throw(eRunspace);
                result = null;
            }
            return result;
        }
        
        // 20120716
        //public static bool RunPSScriptAsync(string scriptCode)
        //public static bool RunPSScriptAsync(string scriptPath, string parameters)
        public static bool RunPSScriptAsync(string scriptCode) //, string parameters)
        {
            bool result = false;
            try {
                pipeline = testRunSpace.CreatePipeline();
                // 20120716
                pipeline.Commands.AddScript(scriptCode);
                //pipeline.Commands.Add(sc
                //Command script = new Command(scriptPath);
                //pipeline.Commands.Add(scriptPath);
                //pipeline.Input.Write(parameters);
//                if (parameters != null && parameters.Length > 0) {
//                    foreach (string param in parameters) {
//                        //script.Parameters.Add(
//                        CommandParameter cmdParam = 
//                            new CommandParameter(
//                    }
//                }
                //script.Parameters.Add
                //pipeline.Runspace.SessionStateProxy.
                //pipeline.
                pipeline.StateChanged += new EventHandler<PipelineStateEventArgs>(pipeline_StateChanged);
                pipeline.InvokeAsync();
                
                var handles = new WaitHandle[2];
                handles[0] = pipeline.Output.WaitHandle;
                handles[1] = pipeline.Error.WaitHandle;
                pipeline.Input.Close();
                
                while (pipeline.PipelineStateInfo.State == PipelineState.Running) {
                    switch (WaitHandle.WaitAny(handles)) {
                        case 0:
                            while (pipeline.Output.Count > 0) {
                                //
                                OnPSOutputArrived(pipeline.Output.Read());
                            }
                            break;
                        case 1:
                            while (pipeline.Error.Count > 0) {
                                //
                                OnPSErrorArrived(pipeline.Error.Read());
                            }
                            break;
                        default:
                            
                        	break;
                    }
                }
                    //pipeline.InvokeAsync();
                //pipeline.Output.
                //return resultObject;
                result = true;
            } 
            catch (Exception) {
                //throw(eRunspace);
                //result = null;
                return result;
            }
            return result;
        }
        
        public static void StopScript()
        {
            pipeline.Stop();
        }
        
        public static void StopScriptAsync()
        {
            pipeline.StopAsync();
        }
        
//        static void PipelineStateChanged() //PipelineStateEventArgs e)
//        {
//            System.Console.WriteLine("===================sdf================");
//            //System.Console.WriteLine(e.ToString());
//        }
        
        static void pipeline_StateChanged(object sender, PipelineStateEventArgs e)
        {
            if (e.PipelineStateInfo.State == PipelineState.Failed)
//                Console.WriteLine(e.PipelineStateInfo.Reason);
//                //Console.WriteLine("The pipeline has {0} error!", PsPipeline.Error.Count);
//                Console.WriteLine("The pipeline has {0} error!", pipeline.Error.Count);
                
                PSErrorThrown(e.PipelineStateInfo.Reason.Message);
            else if (e.PipelineStateInfo.State == PipelineState.Completed)
                OnPSCodeCompleted("");
//            } else if (e.PipelineStateInfo.State == PipelineState.Disconnected) {
//                OnPSDisconnected(e.PipelineStateInfo.Reason.Message);
            else if (e.PipelineStateInfo.State == PipelineState.NotStarted)
                OnPSCodeNotStarted(e.PipelineStateInfo.Reason.Message);
            else if (e.PipelineStateInfo.State == PipelineState.Running)
                OnPSCodeRunning("");
            else if (e.PipelineStateInfo.State == PipelineState.Stopped)
                OnPSCodeStopped(e.PipelineStateInfo.Reason.Message);
            else if (e.PipelineStateInfo.State == PipelineState.Stopping)
                OnPSCodeStopping("");
//            else {
//                Console.WriteLine("All OK");
//                Console.WriteLine("e.PipelineStateInfo.State = " + e.PipelineStateInfo.State.ToString());
//                Console.WriteLine("e.PipelineStateInfo.Reason.Message = " + e.PipelineStateInfo.Reason.Message);
//                Console.WriteLine(e.PipelineStateInfo.Reason);
//                Console.WriteLine("The pipeline has {0} error!", pipeline.Error.Count);
//            }
        }
        
        static void runspace_AvailabilityChanged(object sender, RunspaceAvailabilityEventArgs e)
        {
//            Console.WriteLine("RunspaceAvailability = " + e.RunspaceAvailability.ToString());
        }
        
        static void runspace_StateChanged(object sender, RunspaceStateEventArgs e)
        {
//            Console.WriteLine("RunspaceState = " + e.RunspaceStateInfo.ToString());
//            Console.WriteLine("e.RunspaceStateInfo.Reason.Message = " + e.RunspaceStateInfo.Reason.Message);
//            Console.WriteLine("e.RunspaceStateInfo.State = " + e.RunspaceStateInfo.State.ToString());
        }
        
        public static bool SetVariable(
            string variableName, 
            object variableValue)
        {
            bool result = false;
            try {
                testRunSpace.SessionStateProxy.SetVariable(
                    variableName,
                    variableValue);
                result = true;
            }
            catch {
            }
            return result;
        }
        
        public static object GetVariable(
            string variableName)
        {
            object result = null;
            
            try {
                result = 
                    testRunSpace.SessionStateProxy.GetVariable(
                        variableName);
            }
            catch {
            }
            
            return result;
        }
        
        public static bool CloseRunspace()
        {
            bool result = false;
            try {
                try {
                    pipeline.Stop();
                }
                catch (Exception) {
                    // Console.WriteLine(eClosingPipeline.Message);
                }
                
                testRunSpace.Close();
                
                testRunSpace.Dispose();
                
                testRunSpace = null;
                
                pipeline = null;
                
                result = true;
            }
            catch (Exception) {
                //
// Console.WriteLine("The runspace could not be disposed. {0}", eClosingRunspace.Message);
            }
            return result;
        }
        
//        public static bool ResetRunspace()
//        {
//            bool result = false;
//            try {
//                testRunSpace.ResetRunspaceState();
//                result = true;
//            }
//            catch {}
//            return result;
//        }
        
        static void reportRunningCode(string codeSnippet)
        {
            FinishRunningCode();
            Console.WriteLine(codeSnippet);
        }
        
        public static void FinishRunningCode()
        {
            Console.WriteLine("# ==  ==  ==  ==  ==  ==  ==  ==  ==  == Running code: ==  ==  ==  ==  ==  ==  ==  ==  ==  == =");
        }
    }
}