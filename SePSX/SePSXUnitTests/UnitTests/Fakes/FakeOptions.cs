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
    using System.Drawing;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Description of FakeOptions.
    /// </summary>
    public class FakeOptions : IOptions
    {
        public FakeOptions()
        {
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
        
        public ITimeouts Timeouts()
        {
            throw new NotImplementedException();
        }
    }
}
