/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/6/2012
 * Time: 12:38 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Recording
{
    using MbUnit.Framework;
    //using NUnit.Framework;

//    using OpenQA.Selenium;
//    using System.Drawing;
//    using System.Collections.ObjectModel;
    
    /// <summary>
    /// Description of JSRecorderTestFixture.
    /// </summary>
    [TestFixture]
    public class JSRecorderTestFixture
    {
        public JSRecorderTestFixture()
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
