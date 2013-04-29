/*
 * Created by SharpDevelop.
 * User: APetrovsky
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
    
    /// <summary>
    /// Description of Logger.
    /// </summary>
    public static class Logger
    {
        static Logger()
        {
Console.WriteLine("creating logger");
            //NLogger = LogManager.GetLogger("TMX");
Console.WriteLine("logger has been created");
            
            //LogManager.Configuration.AddTarget
            Target target = new FileTarget();
            target.Name = "TMX";
            LogManager.Configuration.AddTarget("TMX", target);
            //NLogger = LogManager.
            
        }
        
        public static NLog.Logger NLogger { get; set; }
    }
}
