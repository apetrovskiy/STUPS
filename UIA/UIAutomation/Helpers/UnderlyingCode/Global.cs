/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 01.12.2011
 * Time: 4:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.IO;
    
    internal static class Global
    {
        internal static bool GTranscript = false;
        // 20120206 internal static System.DateTime GLastTime;
        internal static System.Drawing.Rectangle GRectangle;
    
        internal static void _PaintRectangle(
            System.Windows.Automation.AutomationElement element)
        {
            if (element == null) {
                return;
            }
            if (element.Current.NativeWindowHandle < 1) {
                return;
            }
            try {
                // on an element
                System.IntPtr ptr =
                    new System.IntPtr(element.Current.NativeWindowHandle);
                
                System.Drawing.Graphics g = 
                    System.Drawing.Graphics.FromHwnd(ptr);
                System.Drawing.SolidBrush brush = 
                    new System.Drawing.SolidBrush(System.Drawing.Color.HotPink);
                System.Drawing.Pen pen = 
                    new System.Drawing.Pen(brush, 10);
                System.Drawing.Rectangle GRectangle = 
                    new System.Drawing.Rectangle(
                        0,
                        0,
                        ((int)element.Current.BoundingRectangle.Width),
                        ((int)element.Current.BoundingRectangle.Height));
                g.DrawRectangle(pen, GRectangle);
            } catch { return; }
        }
    
        internal static void _MinimizeRectangle()
        {
            Global.GRectangle.X = 1;
            Global.GRectangle.Y     = 1;
            Global.GRectangle.Width = 1;
            Global.GRectangle.Height = 1;
        }
    
        #region Log
        private static System.IO.StreamWriter LogStream { get; set; }
        private static System.IO.Stream Stream { get; set; }
        
        internal static void CreateLogFile()
        {
            if (Preferences.Log) {
                try {
                    Stream = 
                        System.IO.File.Open(
                            Preferences.LogPath,
                            FileMode.OpenOrCreate | FileMode.Append,
                            FileAccess.Write,
                            FileShare.Write);
                    LogStream = 
                        new StreamWriter(Stream);
                } catch {
                    Preferences.LogPath = 
                        "'" +
                        System.Environment.GetEnvironmentVariable(
                            "TEMP",
                            EnvironmentVariableTarget.User) + 
                            @"\UIAutomation_" +
                            //UIAHelper.GetTimedFileName() +
                        PSTestLib.PSTestHelper.GetTimedFileName() +
                            ".log" +
                            "'";
                    try {
                        Stream =
                            System.IO.File.Open(
                                Preferences.LogPath,
                                FileMode.OpenOrCreate | FileMode.Append,
                                FileAccess.Write,
                                FileShare.Write);
                        LogStream = 
                            new StreamWriter(Stream);
                    } 
                    catch {
                        Preferences.Log = false;
                    }
                }
            }
        }
        
        internal static void CloseLogFile()
        {
            if (Preferences.Log) {
                if (LogStream != null) {
                    try {
                        LogStream.Flush();
                        LogStream.Close();
                    } 
                    catch { }
                    LogStream = null;
                }
            }
        }
        
        internal static void WriteToLogFile(string record)
        {
            if (Preferences.Log) {
                if (System.IO.File.Exists(Preferences.LogPath)) {
                    if (LogStream == null) {
                        Stream = 
                            System.IO.File.Open(
                                Preferences.LogPath,
                                FileMode.OpenOrCreate | FileMode.Append,
                                FileAccess.Write,
                                FileShare.Write);
                        LogStream = 
                            new StreamWriter(Stream);
                    }
                    // 20130216
                    System.DateTime now = System.DateTime.Now;
                    string dateAndTime = 
                        now.ToShortDateString() + 
                        " " +
                        //System.DateTime.Now.ToShortTimeString();
                        now.ToLongTimeString() +
                        " " +
                        now.Millisecond;
                    LogStream.WriteLine(dateAndTime + "\t" + record);
                    //  //  // LogStream.Flush();
                    //  // 
                }
            }
        }
        #endregion Log
    }
}