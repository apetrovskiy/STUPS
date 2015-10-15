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

    /// <summary>
    /// Description of FakeLocatable.
    /// </summary>
    public class FakeLocatable : ILocatable
    {
        public FakeLocatable()
        {
        }
        
        public Point LocationOnScreenOnceScrolledIntoView {
            get {
                throw new NotImplementedException();
            }
        }
        
        public OpenQA.Selenium.Interactions.Internal.ICoordinates Coordinates {
            get {
                throw new NotImplementedException();
            }
        }
    }
}
