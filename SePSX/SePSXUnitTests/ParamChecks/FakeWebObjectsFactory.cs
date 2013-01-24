/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/5/2012
 * Time: 8:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using Moq;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of FakeWebObjectsFactory.
    /// </summary>
    public static class FakeWebObjectsFactory
    {
        static FakeWebObjectsFactory()
        {
        }
        
        public static IWebElement GetFakeWebElement()
        {
            var mockWebElement =
                new Mock<IWebElement>();
            return mockWebElement.Object;
        }
    }
}
