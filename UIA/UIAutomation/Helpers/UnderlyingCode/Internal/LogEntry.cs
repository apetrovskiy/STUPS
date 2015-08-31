/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/21/2013
 * Time: 10:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    // using NLog;
    using PSTestLib;
    
    /// <summary>
    /// Description of LogEntry.
    /// </summary>
    public class LogEntry
    {
        public LogEntry(LogLevels level, string message)
        {
            DateTime = DateTime.Now;
            LogLevel = level;
            Message = message;
        }
        
        public DateTime DateTime { get; set; }
        public LogLevels LogLevel { get; set; }
        public string Message { get; set; }
    }
}
