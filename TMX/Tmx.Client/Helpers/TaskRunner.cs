/*
 * Created by SharpDevelop.
 * User: alexa_000
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
            // run scriptblock
            var runnerWithParams = new runScriptBlockWithParameters(runSBActionWithParams);
            var scriptblock = ScriptBlock.Create(task.Action);
            // runnerWithParams(sb, parameters);
            runnerWithParams(scriptblock, null);
//            var cmdletBase = new invoketmxtesttaskco
//					runScriptBlocks(scriptblocks, cmdlet, false, parameters);
        }
        
        #region Action delegate
        void runSBActionWithParams(
            ScriptBlock sb,
            object[] parameters)
        {
            Collection<PSObject> psObjects = null;
            try {
                
//				WriteVerbose(
//					this,
//					"select whether a scriptblock has parameters or doesn't");
                
				if (null == parameters || 0 == parameters.Length)
//					WriteVerbose(
//						this,
//						"without parameters");
                    psObjects =
                        sb.Invoke();
				else
//					WriteVerbose(
//						this,
//						"with parameters");
					psObjects =
                        sb.Invoke(parameters);
                
//				WriteVerbose(
//					this,
//					"scriptblock has been fired successfully");

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
                
//				WriteError(
//					this,
//					"Unable to issue the following command:\r\n" +
//					sb +
//					"\r\nThe exception raised is\r\n" +
//					eOuter.Message,
//					"ErrorInInvokingScriptBlock",
//					ErrorCategory.InvalidOperation,
//                    // 20130318
//                    //false);
//					true);
                
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
