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
        static readonly List<string> InitializedLogs = new List<string>();
        
        public TracingControl(string filenamePrefix)
        {
            _fileNamePrefix = filenamePrefix;
            SetTracing();
        }
        
        void SetTracing()
        {
            if (InitializedLogs.Contains(_fileNamePrefix)) return;
            var fileStream = GetFileStream(_fileNamePrefix);
            var listener = new TextWriterTraceListener(fileStream) {TraceOutputOptions = TraceOptions.DateTime};
            Trace.Listeners.Add(listener);
            Trace.AutoFlush = true;
            InitializedLogs.Add(_fileNamePrefix);
        }
        
        FileStream GetFileStream(string fileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + fileName + GetCurrentDateTime() + ".log";
            var fileStream = new FileStream(filePath, FileMode.Append);
            return fileStream;
        }

        string GetCurrentDateTime()
        {
            var now = DateTime.Now;
            return (string.Format("{0}{1}{2}{3}{4}{5}", now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second));
        }
    }
}
