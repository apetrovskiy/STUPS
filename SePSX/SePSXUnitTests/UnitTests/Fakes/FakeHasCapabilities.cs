/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/15/2012
 * Time: 2:37 AM
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
    /// Description of FakeHasCapabilities.
    /// </summary>
    public class FakeHasCapabilities : IHasCapabilities
    {
        public FakeHasCapabilities()
        {
        }
        
        public ICapabilities Capabilities {
            get {
                throw new NotImplementedException();
            }
        }
    }
}
