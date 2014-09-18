/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/28/2014
 * Time: 8:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Management.Automation;
	using Tmx.Interfaces.Remoting;
	
    /// <summary>
    /// Description of TaskRunner.
    /// </summary>
    public class TaskRunner
    {
        public virtual bool Run(ITestTask task)
        {
            // TODO: move to an aspect
            try {
                var runnerWithParams = new runScriptBlockWithParameters(runSBActionWithParams);
                var result = runScriptblockWithParameters(runnerWithParams, task.BeforeAction, task.BeforeActionParameters, task.PreviousTaskResult);
                if (!result) return result;
                result = runScriptblockWithParameters(runnerWithParams, task.Action, task.ActionParameters, task.PreviousTaskResult);
                return !result ? result : runScriptblockWithParameters(runnerWithParams, task.AfterAction, task.AfterActionParameters, task.PreviousTaskResult);
            }
            catch {
                return false;
            }
        }
        
        bool runScriptblockWithParameters(
            runScriptBlockWithParameters runnerWithParams,
            string code,
            IDictionary<string, string> parameters,
            IDictionary<string, string> previousTaskResults)
        {
            if (string.Empty == code)
                return false;
            var scriptblockParameters = 
                (null == previousTaskResults || 0 == previousTaskResults.Count) ? 
                new object[] {
                    new object[]{ },
                    parameters
                } :
                new object[] {
                    previousTaskResults,
                    parameters
                };
            
            try {
                runnerWithParams(ScriptBlock.Create(code), scriptblockParameters);
                return true;
            }
            catch {
                return false;
            }
        }
        
        #region Action delegate
        void runSBActionWithParams(
            ScriptBlock sb,
            object[] parameters)
        {
            Collection<PSObject> psObjects = null;
            try {
				if (null == parameters || 0 == parameters.Length)
                    psObjects = sb.Invoke();
				else
					psObjects = sb.Invoke(parameters);
            } catch (Exception eOuter) {
                throw new Exception(
                    "Unable to issue the following command:\r\n" +
                    sb +
                    "\r\nThe exception raised is\r\n" +
                    eOuter.Message);
            }
        }
        #endregion Action delegate
    }
    
    #region Action delegate
    delegate void runScriptBlockWithParameters(
        ScriptBlock sb,
        object[] parameters);
    #endregion Action delegate
}
