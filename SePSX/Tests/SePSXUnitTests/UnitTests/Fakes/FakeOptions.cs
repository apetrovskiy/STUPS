/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/15/2012
 * Time: 2:38 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
    using OpenQA.Selenium;

    /// <summary>
    /// Description of FakeOptions.
    /// </summary>
    public class FakeOptions : IOptions
    {
    	ILogs logs;
    	
        public FakeOptions()
        {
        	// logs = new log
        }
        
        public ICookieJar Cookies {
            get {
                throw new NotImplementedException();
            }
        }
        
        public IWindow Window {
            get {
                throw new NotImplementedException();
            }
        }

        public ILogs Logs { get { return logs; } }

        public ITimeouts Timeouts()
        {
            throw new NotImplementedException();
        }
    }
}
