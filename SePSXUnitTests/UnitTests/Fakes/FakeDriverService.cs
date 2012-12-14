/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/7/2012
 * Time: 9:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
    using SePSX;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.IE;
    
    /// <summary>
    /// Description of FakeDriverService.
    /// </summary>
    public class FakeDriverService : DriverService
    {
        protected FakeDriverService(
            string servicePath, 
            int port, 
            string driverServiceExecutableName, 
            Uri driverServiceDownloadUrl) : base (servicePath, port, driverServiceExecutableName, driverServiceDownloadUrl)
        {
            System.Uri u = new System.Uri("aaa");
        }
        
		/// <summary>
		///       Gets or sets the location of the log file written to by the ChromeDriver executable.
		///       </summary>
		public string LogPath { get; set; }
//		{
//			get
//			{
//				return this.logPath;
//			}
//			set
//			{
//				this.logPath = value;
//			}
//		}

		public static FakeDriverService CreateDefaultService()
		{
		    return new FakeDriverService(string.Empty, 0, string.Empty, new System.Uri("aaa"));
		}

		public static FakeDriverService CreateDefaultService(string driverPath)
		{
		    return new FakeDriverService(string.Empty, 0, string.Empty, new System.Uri("aaa"));
		}
    }
}
