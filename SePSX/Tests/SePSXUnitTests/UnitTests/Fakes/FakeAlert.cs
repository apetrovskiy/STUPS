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
    /// Description of FakeAlert.
    /// </summary>
    public class FakeAlert : IAlert
    {
        public FakeAlert()
        {
        }

        public void SetAuthenticationCredentials(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public string Text {
            get {
                throw new NotImplementedException();
            }
        }
        
        public void Dismiss()
        {
            throw new NotImplementedException();
        }
        
        public void Accept()
        {
            throw new NotImplementedException();
        }
        
        public void SendKeys(string keysToSend)
        {
            throw new NotImplementedException();
        }
    }
}
