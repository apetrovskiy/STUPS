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
	using System.Collections.ObjectModel;
	using System.Management.Automation;
	using Tmx.Interfaces.Remoting;
	
    /// <summary>
    /// Description of TaskRunner.
    /// </summary>
    public class TaskRunner
    {
        public void Run(ITestTask task)
        {
            var runnerWithParams = new runScriptBlockWithParameters(runSBActionWithParams);
            if (string.Empty != task.BeforeAction)
                runnerWithParams(ScriptBlock.Create(task.BeforeAction), task.BeforeActionParameters.ToArray());
            if (string.Empty != task.Action)
                runnerWithParams(ScriptBlock.Create(task.Action), task.ActionParameters.ToArray());
            if (string.Empty != task.AfterAction)
                runnerWithParams(ScriptBlock.Create(task.AfterAction), task.AfterActionParameters.ToArray());
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
