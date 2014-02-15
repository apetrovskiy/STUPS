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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Management.Automation;
    using NLog;
    using NLog.Targets;
    using NLog.Config;
    using PSTestLib;
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of LogHelper.
    /// </summary>
    public class LogHelper
    {
        internal List<LogEntry> Entries = new List<LogEntry>();
        
        private bool _alreadyInitialized;
        
        public LogHelper(string logPath)
        {
            if (_alreadyInitialized) return;
            LogPath = logPath;
            Preferences.LogPath = LogPath;
            Init();
        }
        
        public LogHelper()
        {
            if (_alreadyInitialized) return;
            Init();
        }
        
        public string LogPath
        {
            get {
                var myFileTarget = (FileTarget)LogManager.Configuration.FindTargetByName("file");
                return myFileTarget.FileName.ToString();
            }
            set {
                var myFileTarget = (FileTarget)LogManager.Configuration.FindTargetByName("file");
                myFileTarget.FileName = value;
                // Preferences.LogPath = value;
            }
        }
        
        public void Log(LogLevels level, string message)
        {
            // ?
            var entry = new LogEntry(level, message);
            Entries.Add(entry);
        }
        
        public void LogCmdlet(CommonCmdletBase cmdlet)
        {
            Info(GetObjectPropertiesInfo(cmdlet));
        }
        
        internal string GetObjectPropertiesInfo(CommonCmdletBase cmdlet)
        {
            string result = string.Empty;
            
            // http://stackoverflow.com/questions/2281972/how-to-get-a-list-of-properties-with-a-given-attribute
            foreach (PropertyInfo propertyInfo in cmdlet.GetType()
                     .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                     .Where(p => p.GetCustomAttributes(typeof(MyAttribute), true).Length != 0)) {
                
                result += GetPropertyString(cmdlet, propertyInfo);
            }
            
            result = cmdlet.CmdletName(cmdlet) + result;
            
            return result;
        }
        
        internal string GetPropertyString(CommonCmdletBase cmdlet, PropertyInfo propertyInfo)
        {
            string result = string.Empty;
            
            if (null == propertyInfo) return result;
            
            object tempResult = string.Empty;
            try {
                tempResult = propertyInfo.GetValue(cmdlet, null) ?? string.Empty;
            } catch (Exception) {
                
                return string.Empty;
            }
            
            if (string.IsNullOrEmpty(tempResult.ToString())) return result;
            
            result += " -";
            result += propertyInfo.Name;
            result += " ";
            
            string tempString = string.Empty;
            
            switch (tempResult.GetType().Name) {
                case "String":
                    result += "\"";
                    result += tempResult;
                    result += "\"";
                    return result;
                case "String[]":
                    tempString = string.Empty;
                    foreach (string singleElement in tempResult as IEnumerable) {
                        tempString += ",";
                        tempString += singleElement;
                    }
                    if (0 < tempString.Length) tempString = tempString.Substring(1);
                    result += tempString;
                    return result;
                case "IUiElement":
                    var convertCmdlet =
                        new ConvertToUiaSearchCriteriaCommand {
                        Full = true
                    };
                    // result += "\r\n\t";
                    result += convertCmdlet.ConvertElementToSearchCriteria((IUiElement)tempResult);
                    // result += "\r\n\t";
                    return result;
                case "IUiElement[]":
                    var convertCmdlet2 =
                        new ConvertToUiaSearchCriteriaCommand {
                        Full = true
                    };
                    foreach (IUiElement element in tempResult as IUiElement[]) {
                        // result += "\r\n\t";
                        result += convertCmdlet2.ConvertElementToSearchCriteria(element);
                        // result += "\r\n\t";
                    }
                    return result;
                case "Int32":
                    result += tempResult.ToString();
                    return result;
                case "SwitchParameter":
                    bool tempBool = (SwitchParameter)tempResult;
					result += tempBool ? "$true" : "$false";
                    return result;
                case "Hashtable":
                    result += ConvertHashtableToString((Hashtable)tempResult);
                    return result;
                case "Hashtable[]":
                    tempString = string.Empty;
                    foreach (Hashtable hashtable in (tempResult as Hashtable[])) {
                        tempString += ",";
                        tempString += ConvertHashtableToString(hashtable);
                    }
                    if (0 < tempString.Length) tempString = tempString.Substring(1);
                    result += tempString;
                    return result;
                default:
                    result += tempResult.ToString();
                    return result;
            }
        }
        
        internal string ConvertHashtableToString(Hashtable hashtable)
        {
            string result = string.Empty;
            
            if (null == hashtable) return result;
            if (0 == hashtable.Keys.Count) return "@{}";
            
            result += "@{";
            foreach (string key in hashtable.Keys) {
                result += key;
                result += "=";
                object value = hashtable[key];
                if (value is string || value is int) {
                    result += "\"";
                    result += value.ToString();
                    result += "\"";
                }
                if (value is Boolean) {
                    if ((bool)value) result += "$true";
                    if (!(bool)value) result += "$false";
                }
                result += ";";
            }
            result += "}";
            
            return result;
        }
        
        // ==============================================================================================
        
        public static NLog.Logger UiaLogger = null;
        
        internal void Init()
        {
            var config = new LoggingConfiguration();

            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);

            fileTarget.FileName =
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) +
                @"\UIA.log";
            //fileTarget.Layout = "${date:format=HH\\:MM\\:ss}: ${message}";
            //fileTarget.Layout = "[${date:format=DD/MM/YYYY HH\\:mm\\:ss}] [${}] ${message}";
            //"${longdate}|${level:uppercase=true}|${logger}|${message}";
            //fileTarget.Layout = "${longdate}|${level:uppercase=true}|${message}";
            fileTarget.Layout = "[${longdate}] [${level:uppercase=true}] ${message}";
            //fileTarget.Encoding = "iso-8859-2";
            fileTarget.Encoding = System.Text.Encoding.Unicode;

            var rule = new LoggingRule("*", NLog.LogLevel.Info, fileTarget);
            config.LoggingRules.Add(rule);

            LogManager.Configuration = config;

            UiaLogger = LogManager.GetLogger("UIA");
            
            _alreadyInitialized = true;
        }
        
        public static void Fatal(string message)
        {
            UiaLogger.Fatal(message);
        }
        
        public static void Error(string message)
        {
            UiaLogger.Error(message);
        }
        
        public static void Warn(string message)
        {
            UiaLogger.Warn(message);
        }
        
        public static void Info(string message)
        {
            UiaLogger.Info(message);
        }
        
        public static void Debug(string message)
        {
            UiaLogger.Debug(message);
        }
        
        public static void Trace(string message)
        {
            UiaLogger.Trace(message);
        }
    }
}
