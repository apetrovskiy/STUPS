/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/21/2013
 * Time: 10:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Collections.Generic;
    using PSTestLib;
    
    /// <summary>
    /// Description of LogHelper.
    /// </summary>
    public class LogHelper
    {
        internal List<LogEntry> Entries = new List<LogEntry>();
        
        public void Log(LogLevels level, string message)
        {
            // ?
            LogEntry entry = new LogEntry(level, message);
            Entries.Add(entry);
        }
    }
}
