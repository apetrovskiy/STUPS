/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/11/2012
 * Time: 12:31 AM
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
            SpyModes currentMode = SpyModes.seleniumSpy;
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
//                        break;
                }
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // 20121003
            //Application.Run(new SpyForm());
            Application.Run(new SpyForm(currentMode));
        }
        
    }
}
