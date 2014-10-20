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
    public sealed class ClientSettings
    {
        private static readonly ClientSettings instance = new ClientSettings();
        
        static ClientSettings()
        {
        }
        
        private ClientSettings()
        {
        }
        
        public static ClientSettings Instance
        {
            get { return instance; }
        }
        
        public string ServerUrl { get; set; }
        public int ClientId { get; set; }
        public bool StopImmediately { get; set; }
        public IEnumerable<string> TaskResult { get; set; }
        // 20141020
        public ITestTask CurrentTask { get; set; }
        // public ITestTaskProxy CurrentTask { get; set; }
        // 20141001
        public ITestClient CurrentClient { get; set; }
        
        public void ResetData()
        {
			ClientId = 0;
			ServerUrl = string.Empty;
			StopImmediately = false;
			TaskResult = new string[] {};
			CurrentTask = null;
			// 20141001
			CurrentClient = null;
        }
        
        public void AddTaskResult(string[] results)
        {
            TaskResult = null == TaskResult ? results : TaskResult.Concat(results);
        }
    }
}
