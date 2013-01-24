/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/15/2012
 * Time: 2:36 AM
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
    /// Description of FakeCapabilities.
    /// </summary>
    public class FakeCapabilities : ICapabilities
    {
        public FakeCapabilities()
        {
        }
        
        public bool IsJavaScriptEnabled { get; set; }
        public string Version { get; set; }
        public Platform Platform { get; set; }
        public string BrowserName { get; set; }
        
        public object GetCapability(string name)
        {
            return (new FakeCapabilities());
        }
        
        public bool HasCapability(string name)
        {
            return true;
        }
    }
}
