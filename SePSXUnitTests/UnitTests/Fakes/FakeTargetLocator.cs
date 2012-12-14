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
    /// Description of FakeTargetLocator.
    /// </summary>
    public class FakeTargetLocator : ITargetLocator
    {
        public FakeTargetLocator()
        {
        }
        
        public IWebDriver Frame(int frameIndex)
        {
            throw new NotImplementedException();
        }
        
        public IWebDriver Frame(string frameName)
        {
            throw new NotImplementedException();
        }
        
        public IWebDriver Frame(IWebElement frameElement)
        {
            throw new NotImplementedException();
        }
        
        public IWebDriver Window(string windowName)
        {
            throw new NotImplementedException();
        }
        
        public IWebDriver DefaultContent()
        {
            throw new NotImplementedException();
        }
        
        public IWebElement ActiveElement()
        {
            throw new NotImplementedException();
        }
        
        public IAlert Alert()
        {
            throw new NotImplementedException();
        }
    }
}
