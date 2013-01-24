/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/15/2012
 * Time: 2:39 AM
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
    /// Description of FakeTimeouts.
    /// </summary>
    public class FakeTimeouts : ITimeouts
    {
        public FakeTimeouts()
        {
        }
        
        public ITimeouts ImplicitlyWait(TimeSpan timeToWait)
        {
            throw new NotImplementedException();
        }
        
        public ITimeouts SetScriptTimeout(TimeSpan timeToWait)
        {
            throw new NotImplementedException();
        }
        
        public ITimeouts SetPageLoadTimeout(TimeSpan timeToWait)
        {
            throw new NotImplementedException();
        }
    }
}
