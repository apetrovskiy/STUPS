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
    using MbUnit.Framework;
    //using NUnit.Framework;

//    using OpenQA.Selenium;
//    using System.Drawing;
//    using System.Collections.ObjectModel;
    
    /// <summary>
    /// Description of CleanRecordedDuringSleepTestFixture.
    /// </summary>
    [TestFixture]
    public class CleanRecordedDuringSleepTestFixture
    {
        public CleanRecordedDuringSleepTestFixture()
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
