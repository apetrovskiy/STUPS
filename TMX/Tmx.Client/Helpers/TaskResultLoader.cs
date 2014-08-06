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
    using System;
	using Tmx.Interfaces;
    
    /// <summary>
    /// Description of TaskResultLoader.
    /// </summary>
    public class TaskResultLoader
    {
        public void AddTaskResults(string[] results)
        {
            // ClientSettings.AddTaskResult(results);
            
//if (null != results) {
//	Console.WriteLine("null != results");
//	foreach (var element in results) {
//		Console.WriteLine(element);
//	}
//} else {
//	Console.WriteLine("null == results");
//}
            
            var addTaskResultsDelegate = new AddTaskResults(ClientSettings.AddTaskResult);
            addTaskResultsDelegate(results);
        }
    }
}
