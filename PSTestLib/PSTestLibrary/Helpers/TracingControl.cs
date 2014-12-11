/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/11/2014
 * Time: 8:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    
    /// <summary>
    /// Description of TracingControl.
    /// </summary>
    public class TracingControl
    {
        readonly string _fileNamePrefix;
        static List<string> _initializedLogs = new List<string>();
        
        public TracingControl(string filenamePrefix)
        {
            _fileNamePrefix = filenamePrefix;
            setTracing();
        }
        
        void setTracing()
        {
            // if (_tracingAlreadyInitialized) return;
            if (_initializedLogs.Contains(_fileNamePrefix)) return;
            var fileStream = getFileStream(_fileNamePrefix);
            var listener = new TextWriterTraceListener(fileStream);
            listener.TraceOutputOptions = TraceOptions.DateTime;
            Trace.Listeners.Add(listener);
            Trace.AutoFlush = true;
            // _tracingAlreadyInitialized = true;
            _initializedLogs.Add(_fileNamePrefix);
        }
        
        FileStream getFileStream(string fileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + fileName + getCurrentDateTime() + ".log";
            var fileStream = new FileStream(filePath, FileMode.Append);
            return fileStream;
        }

        string getCurrentDateTime()
        {
            var now = DateTime.Now;
            return (string.Format("{0}{1}{2}{3}{4}{5}", now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second));
        }
    }
}
