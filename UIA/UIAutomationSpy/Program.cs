/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 24/02/2012
 * Time: 07:18 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationSpy
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Class with program entry point.
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// Program entry point.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            // 20121003
            SpyModes currentMode = SpyModes.uIAutomationSpy;
            if (null != args && 0 < args.Length) {
                switch (Convert.ToInt32(args[0].Trim())) {
                    case (int)SpyModes.uIAutomationSpy:
                        currentMode = SpyModes.uIAutomationSpy;
                        break;
                    case (int)SpyModes.seleniumSpy:
                        currentMode = SpyModes.seleniumSpy;
                        break;
//                    default:
//                        
//                    	break;
                }
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new SpyForm(currentMode));
        }
        
    }
}
