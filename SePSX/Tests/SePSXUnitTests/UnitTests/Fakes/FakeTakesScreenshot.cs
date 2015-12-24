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

    /// <summary>
    /// Description of FakeTakesScreenshot.
    /// </summary>
    public class FakeTakesScreenshot : ITakesScreenshot
    {
        public FakeTakesScreenshot()
        {
        }
        
        public Screenshot GetScreenshot()
        {
            throw new NotImplementedException();
        }
    }
}
