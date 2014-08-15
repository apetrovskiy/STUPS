/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2014
 * Time: 11:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
	using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of ClientSettings.
    /// </summary>
    // public static class ClientSettings
    public class ClientSettings
    {
        // public static string ServerUrl { get; set; }
        volatile static string _ServerUrl;
        public static string ServerUrl
        {
            get { return _ServerUrl; }
            set { _ServerUrl = value; }
        }
        // public static int ClientId { get; set; }
        volatile static int _clientId;
        public static int ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }
        // public static bool StopImmediately { get; set; }
        volatile static bool _stopImmediately;
        public static bool StopImmediately
        {
            get { return _stopImmediately; }
            set { _stopImmediately = value; }
        }
        // public static string[] TaskResult { get; set; }
        // public static IEnumerable<string> TaskResult { get; set; }
        volatile static IEnumerable<string> _taskResult;
        public static IEnumerable<string> TaskResult
        {
            get{ return _taskResult; }
            set { _taskResult = value; }
        }
        
        public static void ResetData()
        {
			ClientId = 0;
			ServerUrl = string.Empty;
			StopImmediately = false;
			TaskResult = new string[] {};
        }
        
//        public static void SetTaskResult(string[] results)
//        {
//            TaskResult = results;
//        }
        
        public static void AddTaskResult(string[] results)
        {
            TaskResult = null == TaskResult ? results : TaskResult.Concat(results);
        }
    }
}
