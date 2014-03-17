/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/29/2013
 * Time: 8:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    // 20140317
    // turning off the logger
//    using NLog;
//    using NLog.Targets;
//    using NLog.Config;
    using PSTestLib;
    
    /// <summary>
    /// Description of Logger.
    /// </summary>
//    public static class Logger
//    {
//        static Logger()
//        {
//            Init();
//        }
//        
//        public static string LogPath
//        {
//            get {
//                FileTarget myFileTarget = (FileTarget)LogManager.Configuration.FindTargetByName("file");
//                return myFileTarget.FileName.ToString();
//            }
//            set {
//                FileTarget myFileTarget = (FileTarget)LogManager.Configuration.FindTargetByName("file");
//                myFileTarget.FileName = value;
//            }
//        }
//        
//        public static LogLevels LogLevel
//        {
////            get {
////                FileTarget myFileTarget = (FileTarget)LogManager.Configuration.FindTargetByName("file");
////                NLog.LogLevel levels = null;
////                foreach (LoggingRule rule in LogManager.Configuration.LoggingRules) {
////                    
////                    if (rule.Targets.Contains(myFileTarget)) {
////                        //return rule.Levels;
////                        //levels = rule.Levels;
////                        break;
////                    }
////                }
////                
////                //
////            }
//            set {
//                FileTarget myFileTarget = (FileTarget)LogManager.Configuration.FindTargetByName("file");
//                LogManager.Configuration.LoggingRules.Clear();
//                LoggingRule rule = null;
//                switch (value) {
//                    case LogLevels.Fatal:
//                        rule = new LoggingRule("*", NLog.LogLevel.Fatal, myFileTarget);
//                        break;
//                    case LogLevels.Error:
//                        rule = new LoggingRule("*", NLog.LogLevel.Error, myFileTarget);
//                        break;
//                    case LogLevels.Warn:
//                        rule = new LoggingRule("*", NLog.LogLevel.Warn, myFileTarget);
//                        break;
//                    case LogLevels.Info:
//                        rule = new LoggingRule("*", NLog.LogLevel.Info, myFileTarget);
//                        break;
//                    case LogLevels.Debug:
//                        rule = new LoggingRule("*", NLog.LogLevel.Debug, myFileTarget);
//                        break;
//                    case LogLevels.Trace:
//                        rule = new LoggingRule("*", NLog.LogLevel.Trace, myFileTarget);
//                        break;
//                    //default:
//                    //    throw new Exception("Invalid value for LogLevels");
//                }
//                LogManager.Configuration.LoggingRules.Add(rule);
//                
//                TmxLogger = LogManager.GetLogger("TMX");
//            }
//        }
//        
//        // 20130506
//        //internal static NLog.Logger TmxLogger = null;
//        public static NLog.Logger TmxLogger = null;
//        
//        internal static void Init()
//        {
//            LoggingConfiguration config = new LoggingConfiguration();
//
//            FileTarget fileTarget = new FileTarget();
//            config.AddTarget("file", fileTarget);
//
//            fileTarget.FileName =
//                System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) +
//                @"\TMX.log";
//            //fileTarget.Layout = "${date:format=HH\\:MM\\:ss}: ${message}";
//            //fileTarget.Layout = "[${date:format=DD/MM/YYYY HH\\:mm\\:ss}] [${}] ${message}";
//            //"${longdate}|${level:uppercase=true}|${logger}|${message}";
//            //fileTarget.Layout = "${longdate}|${level:uppercase=true}|${message}";
//            fileTarget.Layout = "[${longdate}] [${level:uppercase=true}] ${message}";
//            //fileTarget.Encoding = "iso-8859-2";
//            fileTarget.Encoding = System.Text.Encoding.Unicode;
//
//            LoggingRule rule = new LoggingRule("*", NLog.LogLevel.Info, fileTarget);
//            config.LoggingRules.Add(rule);
//
//            LogManager.Configuration = config;
//
//            TmxLogger = LogManager.GetLogger("TMX");
//        }
//        
//        public static void Fatal(string message)
//        {
//            TmxLogger.Fatal(message);
//        }
//        
//        public static void Error(string message)
//        {
//            TmxLogger.Error(message);
//        }
//        
//        public static void Warn(string message)
//        {
//            TmxLogger.Warn(message);
//        }
//        
//        public static void Info(string message)
//        {
//            TmxLogger.Info(message);
//        }
//        
//        public static void Debug(string message)
//        {
//            TmxLogger.Debug(message);
//        }
//        
//        public static void Trace(string message)
//        {
//            TmxLogger.Trace(message);
//        }
//    }
}
