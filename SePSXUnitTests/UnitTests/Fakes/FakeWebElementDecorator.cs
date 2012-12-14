/*
 * Created by SharpDevelop.
 * User: shuran
 * Date: 12/13/2012
 * Time: 3:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
    using OpenQA.Selenium;
    using SePSX;
    
    /// <summary>
    /// Description of FakeWebElementDecorator.
    /// </summary>
    public class FakeWebElementDecorator : WebElementDecorator
    {
//        public FakeWebElementDecorator()
//        {
//        }
        
        public FakeWebElementDecorator(IWebElement realWebElement) : base() //(realWebElement)
        {
            
        }
    }
}
