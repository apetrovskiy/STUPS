/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/11/2014
 * Time: 6:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client.ObjectModel.Runners
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Management.Automation;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of PowerShellTaskRunner.
    /// </summary>
    public class PowerShellTaskRunner : IRunnableClient
    {
        public bool RunBeforeAction(
            string code,
            IDictionary<string, string> parameters,
            IDictionary<string, string> previousTaskResults)
        {
            Trace.TraceInformation("RunBeforeAction");
            return runCode(code, parameters, previousTaskResults);
        }
        
        public bool RunMainAction(
            string code,
            IDictionary<string, string> parameters,
            IDictionary<string, string> previousTaskResults)
        {
            Trace.TraceInformation("RunMainAction");
            return runCode(code, parameters, previousTaskResults);
        }
        
        public bool RunAfterAction(
            string code,
            IDictionary<string, string> parameters,
            IDictionary<string, string> previousTaskResults)
        {
            Trace.TraceInformation("RunAfterAction");
            return runCode(code, parameters, previousTaskResults);
        }
        
        bool runCode(
            string code,
            IDictionary<string, string> parameters,
            IDictionary<string, string> previousTaskResults)
        {
            Trace.TraceInformation("runCode");
            var runnerWithParams = new runScriptBlockWithParameters(runSBActionWithParams);
            return runScriptblockWithParameters(runnerWithParams, code, parameters, previousTaskResults);
        }
        
        bool runScriptblockWithParameters(
            runScriptBlockWithParameters runnerWithParams,
            string code,
            IDictionary<string, string> parameters,
            IDictionary<string, string> previousTaskResults)
        {
            if (string.Empty == code) return true;
            
            var scriptblockParameters =
                new object[] {
                    previousTaskResults ?? new Dictionary<string, string>(),
                    parameters ?? new Dictionary<string, string>()
                };
            
            try {
                Trace.TraceInformation("runScriptblockWithParameters.1");
                runnerWithParams(ScriptBlock.Create(code), scriptblockParameters);
                Trace.TraceInformation("runScriptblockWithParameters.2");
                return true;
            }
            catch (Exception eOnRunningScriptblock) {
                // TODO: AOP
                Trace.TraceError("runScriptblockWithParameters");
                // 20141211
                Trace.TraceError(eOnRunningScriptblock.Message);
                return false;
            }
        }
        
        void runSBActionWithParams(ScriptBlock sb, object[] parameters)
        {
            Collection<PSObject> psObjects = null;
            try {
                Trace.TraceInformation("runSBActionWithParams.1");
                if (null == parameters || 0 == parameters.Length)
                    psObjects = sb.Invoke();
                else
                    psObjects = sb.Invoke(parameters);
                Trace.TraceInformation("runSBActionWithParams.2");
            } catch (Exception eOuter) {
                // TODO: AOP
                Trace.TraceError("runSBActionWithParams(ScriptBlock sb, object[] parameters)");
                Trace.TraceError(eOuter.Message);
                throw new Exception(
                    "Unable to issue the following command:\r\n" +
                    sb +
                    "\r\nThe exception raised is\r\n" +
                    eOuter.Message);
            }
        }
    }
    
    delegate void runScriptBlockWithParameters(ScriptBlock sb, object[] parameters);
}
