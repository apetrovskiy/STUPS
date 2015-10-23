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
    using System.IO;
    using System.Drawing;

    internal static class Global
    {
        internal static bool GTranscript = false;
        // 20120206 internal static System.DateTime GLastTime;
        internal static Rectangle GRectangle;
    
//        internal static void _PaintRectangle(
//            IUiElement element)
//        {
//            if (element == null) {
//                return;
//            }
//            if (element.Current.NativeWindowHandle < 1) {
//                return;
//            }
//            try {
//                // on an element
//                var ptr =
//                    new IntPtr(element.Current.NativeWindowHandle);
//                
//                Graphics g = 
//                    Graphics.FromHwnd(ptr);
//                var brush = 
//                    new SolidBrush(Color.HotPink);
//                var pen = 
//                    new Pen(brush, 10);
//                var GRectangle = 
//                    new Rectangle(
//                        0,
//                        0,
//                        ((int)element.Current.BoundingRectangle.Width),
//                        ((int)element.Current.BoundingRectangle.Height));
//                g.DrawRectangle(pen, GRectangle);
//                
//                /*
//                IntPtr ptr =
//                    new IntPtr(element.Current.NativeWindowHandle);
//                
//                Graphics g = 
//                    Graphics.FromHwnd(ptr);
//                SolidBrush brush = 
//                    new SolidBrush(Color.HotPink);
//                Pen pen = 
//                    new Pen(brush, 10);
//                Rectangle GRectangle = 
//                    new Rectangle(
//                        0,
//                        0,
//                        ((int)element.Current.BoundingRectangle.Width),
//                        ((int)element.Current.BoundingRectangle.Height));
//                g.DrawRectangle(pen, GRectangle);
//                */
//            } catch { return; }
//        }
    
//        internal static void _MinimizeRectangle()
//        {
//            GRectangle.X = 1;
//            GRectangle.Y     = 1;
//            GRectangle.Width = 1;
//            GRectangle.Height = 1;
//        }
    
        #region Log
        private static StreamWriter LogStream { get; set; }
        private static Stream Stream { get; set; }
        
//        internal static void CreateLogFile()
//        {
//            if (!Preferences.Log) return;
//            try {
//                Stream = 
//                    File.Open(
//                        Preferences.LogPath,
//                        FileMode.OpenOrCreate | FileMode.Append,
//                        FileAccess.Write,
//                        FileShare.Write);
//                LogStream = 
//                    new StreamWriter(Stream);
//            } catch {
//                Preferences.LogPath = 
//                    "'" +
//                    Environment.GetEnvironmentVariable(
//                        "TEMP",
//                        EnvironmentVariableTarget.User) + 
//                    @"\UIAutomation_" +
//                    //UiaHelper.GetTimedFileName() +
//                    PSTestHelper.GetTimedFileName() +
//                    ".log" +
//                    "'";
//                try {
//                    Stream =
//                        File.Open(
//                            Preferences.LogPath,
//                            FileMode.OpenOrCreate | FileMode.Append,
//                            FileAccess.Write,
//                            FileShare.Write);
//                    LogStream = 
//                        new StreamWriter(Stream);
//                } 
//                catch {
//                    Preferences.Log = false;
//                }
//            }
//
//            /*
//            if (Preferences.Log) {
//                try {
//                    Stream = 
//                        System.IO.File.Open(
//                            Preferences.LogPath,
//                            FileMode.OpenOrCreate | FileMode.Append,
//                            FileAccess.Write,
//                            FileShare.Write);
//                    LogStream = 
//                        new StreamWriter(Stream);
//                } catch {
//                    Preferences.LogPath = 
//                        "'" +
//                        System.Environment.GetEnvironmentVariable(
//                            "TEMP",
//                            EnvironmentVariableTarget.User) + 
//                            @"\UIAutomation_" +
//                            //UiaHelper.GetTimedFileName() +
//                        PSTestLib.PSTestHelper.GetTimedFileName() +
//                            ".log" +
//                            "'";
//                    try {
//                        Stream =
//                            System.IO.File.Open(
//                                Preferences.LogPath,
//                                FileMode.OpenOrCreate | FileMode.Append,
//                                FileAccess.Write,
//                                FileShare.Write);
//                        LogStream = 
//                            new StreamWriter(Stream);
//                    } 
//                    catch {
//                        Preferences.Log = false;
//                    }
//                }
//            }
//            */
//        }

//        internal static void CloseLogFile()
//        {
//            if (!Preferences.Log) return;
//            if (LogStream == null) return;
//            try {
//                LogStream.Flush();
//                LogStream.Close();
//            } 
//            catch { }
//            LogStream = null;
//
//            /*
//            if (Preferences.Log) {
//                if (LogStream != null) {
//                    try {
//                        LogStream.Flush();
//                        LogStream.Close();
//                    } 
//                    catch { }
//                    LogStream = null;
//                }
//            }
//            */
//        }

//        internal static void WriteToLogFile(string record)
//        {
//            if (!Preferences.Log) return;
//            if (!File.Exists(Preferences.LogPath)) return;
//            if (LogStream == null) {
//                Stream = 
//                    File.Open(
//                        Preferences.LogPath,
//                        FileMode.OpenOrCreate | FileMode.Append,
//                        FileAccess.Write,
//                        FileShare.Write);
//                LogStream = 
//                    new StreamWriter(Stream);
//            }
//            // 20130216
//            DateTime now = DateTime.Now;
//            string dateAndTime = 
//                now.ToShortDateString() + 
//                " " +
//                //System.DateTime.Now.ToShortTimeString();
//                now.ToLongTimeString() +
//                " " +
//                now.Millisecond;
//            LogStream.WriteLine(dateAndTime + "\t" + record);
//            //  //  // LogStream.Flush();
//            //  // 
//
//            /*
//            if (System.IO.File.Exists(Preferences.LogPath)) {
//                if (LogStream == null) {
//                    Stream = 
//                        System.IO.File.Open(
//                            Preferences.LogPath,
//                            FileMode.OpenOrCreate | FileMode.Append,
//                            FileAccess.Write,
//                            FileShare.Write);
//                    LogStream = 
//                        new StreamWriter(Stream);
//                }
//                // 20130216
//                System.DateTime now = System.DateTime.Now;
//                string dateAndTime = 
//                    now.ToShortDateString() + 
//                    " " +
//                    //System.DateTime.Now.ToShortTimeString();
//                    now.ToLongTimeString() +
//                    " " +
//                    now.Millisecond;
//                LogStream.WriteLine(dateAndTime + "\t" + record);
//                //  //  // LogStream.Flush();
//                //  // 
//            }
//            */
//
//            /*
//            if (Preferences.Log) {
//                if (System.IO.File.Exists(Preferences.LogPath)) {
//                    if (LogStream == null) {
//                        Stream = 
//                            System.IO.File.Open(
//                                Preferences.LogPath,
//                                FileMode.OpenOrCreate | FileMode.Append,
//                                FileAccess.Write,
//                                FileShare.Write);
//                        LogStream = 
//                            new StreamWriter(Stream);
//                    }
//                    // 20130216
//                    System.DateTime now = System.DateTime.Now;
//                    string dateAndTime = 
//                        now.ToShortDateString() + 
//                        " " +
//                        //System.DateTime.Now.ToShortTimeString();
//                        now.ToLongTimeString() +
//                        " " +
//                        now.Millisecond;
//                    LogStream.WriteLine(dateAndTime + "\t" + record);
//                    //  //  // LogStream.Flush();
//                    //  // 
//                }
//            }
//            */
//        }

        #endregion Log
    }
}