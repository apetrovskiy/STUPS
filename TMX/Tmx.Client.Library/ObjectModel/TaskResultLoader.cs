/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/5/2014
 * Time: 5:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
    //using System;
    using System.Diagnostics;
    using Interfaces;
    
    /// <summary>
    /// Description of TaskResultLoader.
    /// </summary>
    public class TaskResultLoader
    {
        public virtual void AddTaskResults(string[] results)
        {
            Trace.TraceInformation("AddTaskResults(string[] results).1");
            
            var clientSettings = ClientSettings.Instance;
            
            Trace.TraceInformation("AddTaskResults(string[] results).2");
            
            var addTaskResultsDelegate = new AddTaskResults(clientSettings.AddTaskResult);
            
            Trace.TraceInformation("AddTaskResults(string[] results).3");
            
            addTaskResultsDelegate(results);
            
            Trace.TraceInformation("AddTaskResults(string[] results).4");
        }
    }
}
