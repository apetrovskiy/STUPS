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
    using NLog;
    using NLog.Targets;
    using NLog.Config;
    
    /// <summary>
    /// Description of Logger.
    /// </summary>
    public static class Logger
    {
        static Logger()
        {
            Init();
        }
        
        public static string LogPath
        {
            //get { return logger.}
            set {
                FileTarget myFileTarget = (FileTarget)LogManager.Configuration.FindTargetByName("file");
                myFileTarget.FileName = value;
            }
        }
        
        internal static NLog.Logger TMXLogger = null;
        
        internal static void Init()
        {
            LoggingConfiguration config = new LoggingConfiguration();

            FileTarget fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);

            fileTarget.FileName =
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) +
                @"\TMX.log";
            //fileTarget.Layout = "${date:format=HH\\:MM\\:ss}: ${message}";
            //fileTarget.Layout = "[${date:format=DD/MM/YYYY HH\\:mm\\:ss}] [${}] ${message}";
            //"${longdate}|${level:uppercase=true}|${logger}|${message}";
            //fileTarget.Layout = "${longdate}|${level:uppercase=true}|${message}";
            fileTarget.Layout = "[${longdate}] [${level:uppercase=true}] ${message}";
            //fileTarget.Encoding = "iso-8859-2";
            fileTarget.Encoding = System.Text.Encoding.Unicode;

            LoggingRule rule = new LoggingRule("*", LogLevel.Info, fileTarget);
            config.LoggingRules.Add(rule);

            LogManager.Configuration = config;

            TMXLogger = LogManager.GetLogger("TMX");
        }
        
        public static void Fatal(string message)
        {
            TMXLogger.Fatal(message);
        }
        
        public static void Error(string message)
        {
            TMXLogger.Error(message);
        }
        
        public static void Warn(string message)
        {
            TMXLogger.Warn(message);
        }
        
        public static void Info(string message)
        {
            TMXLogger.Info(message);
        }
        
        public static void Debug(string message)
        {
            TMXLogger.Debug(message);
        }
        
        public static void Trace(string message)
        {
            TMXLogger.Trace(message);
        }
    }
}
