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
    /// Description of FakeSearchContext.
    /// </summary>
    public class FakeSearchContext : ISearchContext
    {
        public FakeSearchContext()
        {
        }
        
        public IWebElement FindElement(By @by)
        {
            throw new NotImplementedException();
        }
        
        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            throw new NotImplementedException();
        }
    }
}
