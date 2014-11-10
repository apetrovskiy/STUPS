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
    using Tmx.Core.Types.Remoting;
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
            // 20141030
            CommonData = new CommonData();
        }
        
        public static ClientSettings Instance
        {
            get { return instance; }
        }
        
        public string ServerUrl { get; set; }
        public Guid ClientId { get; set; }
        public bool StopImmediately { get; set; }
        public IEnumerable<string> TaskResult { get; set; }
        // 20141020 squeezing a task to its proxy
        public ITestTask CurrentTask { get; set; }
        // public ITestTaskProxy CurrentTask { get; set; }
        // public ITestTaskCodeProxy CurrentTask { get; set; }
        // 20141001
        public ITestClient CurrentClient { get; set; }
        
        public void ResetData()
        {
			ClientId = Guid.Empty;
			ServerUrl = string.Empty;
			StopImmediately = false;
			TaskResult = new string[] {};
			CurrentTask = null;
			CurrentClient = null;
        }
        
        public void AddTaskResult(string[] results)
        {
            TaskResult = null == TaskResult ? results : TaskResult.Concat(results);
        }
        
        // 20141030
        public ICommonData CommonData { get; set; }
        // public Guid TestRunId { get; set; }
    }
}
