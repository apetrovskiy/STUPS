/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/4/2012
 * Time: 12:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Recording
{
    using System;
    using MbUnit.Framework;
    //using NUnit.Framework;
    using SePSX;
    using PSTestLib;
//    using OpenQA.Selenium;
//    using System.Drawing;
//    using System.Collections.ObjectModel;
    
    /// <summary>
    /// Description of ExitRecordingTestFixtrure.
    /// </summary>
    [TestFixture]
    public class ExitRecordingTestFixtrure
    {
        public ExitRecordingTestFixtrure()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
        }
        
        
        [TearDown]
        public void DisposeRunspace()
        {
            Settings.CleanUpRecordingCollection();
        }
        
        [Test]
        [Category("Fast")]
        [Ignore]
        public void Need_Code()
        {
        }
    }
}
