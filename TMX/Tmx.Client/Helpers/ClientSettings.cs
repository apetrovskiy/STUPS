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
//    public class ClientSettings
//    {
//        // public static string ServerUrl { get; set; }
//        volatile static string _ServerUrl;
//        public static string ServerUrl
//        {
//            get { return _ServerUrl; }
//            set { _ServerUrl = value; }
//        }
//        // public static int ClientId { get; set; }
//        volatile static int _clientId;
//        public static int ClientId
//        {
//            get { return _clientId; }
//            set { _clientId = value; }
//        }
//        // public static bool StopImmediately { get; set; }
//        volatile static bool _stopImmediately;
//        public static bool StopImmediately
//        {
//            get { return _stopImmediately; }
//            set { _stopImmediately = value; }
//        }
//        // public static string[] TaskResult { get; set; }
//        // public static IEnumerable<string> TaskResult { get; set; }
//        volatile static IEnumerable<string> _taskResult;
//        public static IEnumerable<string> TaskResult
//        {
//            get{ return _taskResult; }
//            set { _taskResult = value; }
//        }
//        
//        public static void ResetData()
//        {
////			ClientId = 0;
////			ServerUrl = string.Empty;
////			StopImmediately = false;
////			TaskResult = new string[] {};
//            _clientId = 0;
//            _ServerUrl = string.Empty;
//            _stopImmediately = false;
//            _taskResult = new string[] {};
//        }
//        
////        public static void SetTaskResult(string[] results)
////        {
////            TaskResult = results;
////        }
//        
//        public static void AddTaskResult(string[] results)
//        {
//            // TaskResult = null == TaskResult ? results : TaskResult.Concat(results);
//            _taskResult = null == _taskResult ? results : _taskResult.Concat(results);
//        }
//    }
//    
//    public sealed class Singleton
//    {
//        private static readonly Singleton instance = new Singleton();
//    
//        // Explicit static constructor to tell C# compiler
//        // not to mark type as beforefieldinit
//        static Singleton()
//        {
//        }
//    
//        private Singleton()
//        {
//        }
//    
//        public static Singleton Instance
//        {
//            get
//            {
//                return instance;
//            }
//        }
//    }
    
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
        
//        public string ServerUrl { get; set; }
//        public int ClientId { get; set; }
//        public bool StopImmediately { get; set; }
//        public IEnumerable<string> TaskResult { get; set; }
        volatile string _ServerUrl;
        public string ServerUrl
        {
            get { return _ServerUrl; }
            set { _ServerUrl = value; }
        }
        volatile int _clientId;
        public int ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }
        volatile bool _stopImmediately;
        public bool StopImmediately
        {
            get { return _stopImmediately; }
            set { _stopImmediately = value; }
        }
        volatile IEnumerable<string> _taskResult;
        public IEnumerable<string> TaskResult
        {
            get{ return _taskResult; }
            set { _taskResult = value; }
        }
        
        public void ResetData()
        {
//			ClientId = 0;
//			ServerUrl = string.Empty;
//			StopImmediately = false;
//			TaskResult = new string[] {};
            _clientId = 0;
            _ServerUrl = string.Empty;
            _stopImmediately = false;
            _taskResult = new string[] {};
        }
        
        public void AddTaskResult(string[] results)
        {
            // TaskResult = null == TaskResult ? results : TaskResult.Concat(results);
            _taskResult = null == _taskResult ? results : _taskResult.Concat(results);
        }
    }

//    public sealed class ClientSettings
//    {
//        private static ClientSettings instance = null;
//        private static readonly object padlock = new object();
//        
//        ClientSettings()
//        {
//        }
//        
//        public static ClientSettings Instance
//        {
//            get
//            {
//                lock (padlock)
//                {
//                    if (instance == null) {
//                        instance = new ClientSettings();
//                    }
//                    return instance;
//                }
//            }
//        }
//        
////        public string ServerUrl { get; set; }
////        public int ClientId { get; set; }
////        public bool StopImmediately { get; set; }
////        public IEnumerable<string> TaskResult { get; set; }
//        volatile string _ServerUrl;
//        public string ServerUrl
//        {
//            get { return _ServerUrl; }
//            set { _ServerUrl = value; }
//        }
//        volatile int _clientId;
//        public int ClientId
//        {
//            get { return _clientId; }
//            set { _clientId = value; }
//        }
//        volatile bool _stopImmediately;
//        public bool StopImmediately
//        {
//            get { return _stopImmediately; }
//            set { _stopImmediately = value; }
//        }
//        volatile IEnumerable<string> _taskResult;
//        public IEnumerable<string> TaskResult
//        {
//            get{ return _taskResult; }
//            set { _taskResult = value; }
//        }
//        
//        public void ResetData()
//        {
////			ClientId = 0;
////			ServerUrl = string.Empty;
////			StopImmediately = false;
////			TaskResult = new string[] {};
//            _clientId = 0;
//            _ServerUrl = string.Empty;
//            _stopImmediately = false;
//            _taskResult = new string[] {};
//        }
//        
//        public void AddTaskResult(string[] results)
//        {
//            // TaskResult = null == TaskResult ? results : TaskResult.Concat(results);
//            _taskResult = null == _taskResult ? results : _taskResult.Concat(results);
//        }
//    }
    
//    public sealed class ClientSettings
//    {
//        private ClientSettings()
//        {
//        }
//        
//        public static ClientSettings Instance { get { return Nested.instance; } }
//        
//        private class Nested
//        {
//            static Nested()
//            {
//            }
//            
//            internal static readonly ClientSettings instance = new ClientSettings();
//        }
//        
////        public string ServerUrl { get; set; }
////        public int ClientId { get; set; }
////        public bool StopImmediately { get; set; }
////        public IEnumerable<string> TaskResult { get; set; }
//        volatile string _ServerUrl;
//        public string ServerUrl
//        {
//            get { return _ServerUrl; }
//            set { _ServerUrl = value; }
//        }
//        volatile int _clientId;
//        public int ClientId
//        {
//            get { return _clientId; }
//            set { _clientId = value; }
//        }
//        volatile bool _stopImmediately;
//        public bool StopImmediately
//        {
//            get { return _stopImmediately; }
//            set { _stopImmediately = value; }
//        }
//        volatile IEnumerable<string> _taskResult;
//        public IEnumerable<string> TaskResult
//        {
//            get{ return _taskResult; }
//            set { _taskResult = value; }
//        }
//        
//        public void ResetData()
//        {
////			ClientId = 0;
////			ServerUrl = string.Empty;
////			StopImmediately = false;
////			TaskResult = new string[] {};
//            _clientId = 0;
//            _ServerUrl = string.Empty;
//            _stopImmediately = false;
//            _taskResult = new string[] {};
//        }
//        
//        public void AddTaskResult(string[] results)
//        {
//            // TaskResult = null == TaskResult ? results : TaskResult.Concat(results);
//            _taskResult = null == _taskResult ? results : _taskResult.Concat(results);
//        }
//    }
}
