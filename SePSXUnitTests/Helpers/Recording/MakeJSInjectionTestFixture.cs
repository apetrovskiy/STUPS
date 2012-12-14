/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/4/2012
 * Time: 12:28 PM
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
    
    /// <summary>
    /// Description of MakeJSInjectionTestFixture.
    /// </summary>
    [TestFixture]
    public class MakeJSInjectionTestFixture
    {
        public MakeJSInjectionTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            //MiddleLevelCode.PrepareRunspace();
            //Recorder.recordingCollection.Clear();
        }
        
        
        
        [TearDown]
        public void DisposeRunspace()
        {
            Settings.CleanUpRecordingCollection();
        }
        
        [Test]
        [Ignore]
        public void Need_Code()
        {
        }
    }
}
