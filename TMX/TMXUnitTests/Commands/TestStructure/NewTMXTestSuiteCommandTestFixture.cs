/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 7:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxUnitTests.Commands.TestStructure
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using TMX;
	using TMX.Interfaces;
    
    /// <summary>
    /// Description of NewTmxTestSuiteCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class NewTmxTestSuiteCommandTestFixture
    {
        public NewTmxTestSuiteCommandTestFixture()
        {
        }
        
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name name")]
        [Category("Fast")]
        public void NewTestSuite_Name()
        {
            string expectedResultName = "suite name";
            UnitTestingHelper.GetNewTestSuite(expectedResultName, string.Empty, string.Empty);
            Assert.AreEqual(
                expectedResultName,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name name -Description description")]
        [Category("Fast")]
        public void NewTestSuite_Name_Description()
        {
            string expectedResultName = "suite name";
            string expectedResultDescr = "descr";
            UnitTestingHelper.GetNewTestSuite(expectedResultName, string.Empty, expectedResultDescr);
            Assert.AreEqual(
                expectedResultName,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
            
            Assert.AreEqual(
                expectedResultDescr,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Description);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name name -Id id")]
        [Category("Fast")]
        public void NewTestSuite_Name_Id()
        {
            string expectedResultName = "suite name";
            string expectedResultId = "suite id";
            UnitTestingHelper.GetNewTestSuite(expectedResultName, expectedResultId, string.Empty);
            Assert.AreEqual(
                expectedResultName,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
            
            Assert.AreEqual(
                expectedResultId,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Id);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name name -Id id -Description description")]
        [Category("Fast")]
        public void NewTestSuite_Name_Id_Description()
        {
            string expectedResultName = "suite name";
            string expectedResultId = "suite id";
            string expectedResultDescr = "descr";
            UnitTestingHelper.GetNewTestSuite(expectedResultName, expectedResultId, expectedResultDescr);
            Assert.AreEqual(
                expectedResultName,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
            
            Assert.AreEqual(
                expectedResultId,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Id);
            
            Assert.AreEqual(
                expectedResultDescr,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Description);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name name; New-TmxTestSuite -Name name")]
        [Category("Fast")]
        /// <summary>
        /// Allows duplicated names if ids are generated.
        /// </summary>
        public void NewTestSuite_Name_Duplicated()
        {
            string expectedResultName = "suite name";
            UnitTestingHelper.GetNewTestSuite(expectedResultName, string.Empty, string.Empty);
            UnitTestingHelper.GetNewTestSuite(expectedResultName, string.Empty, string.Empty);
            
            // checks the first test suite
            Assert.AreEqual(
                expectedResultName,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.PreviousOutput[0]).Name);
            
            // checks the second test suite
            Assert.AreEqual(
                expectedResultName,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name name -Id id; New-TmxTestSuite -Name name -Id id")]
        [Category("Fast")]
        /// <summary>
        /// Disallows duplicated names if ids are the same.
        /// </summary>
        public void NewTestSuite_Name_Duplicated_Id_Duplicated()
        {
            string expectedResultName = "suite name";
            string expectedResultId = "suite id";
            UnitTestingHelper.GetNewTestSuite(expectedResultName, expectedResultId, string.Empty);
            UnitTestingHelper.GetNewTestSuite(expectedResultName, expectedResultId, string.Empty);
            
Console.WriteLine("00000000000000003");
            
            // checks the first test suite
            Assert.AreEqual(
                expectedResultName,
                //((ITestSuite)CommonCmdletBase.UnitTestOutput[CommonCmdletBase.UnitTestOutput.Count - 1]).Name);
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
            
Console.WriteLine("00000000000000004");
            
            // checks how many test suites
            Console.WriteLine("Output in the UnitTestOutput object");
            Assert.AreEqual( // this is a technical solution
                1,
                PSTestLib.UnitTestOutput.Count);
            
Console.WriteLine("00000000000000005");
            
            Console.WriteLine("Test Suites counter");
            Assert.AreEqual( // this is a logical solution
                1,
                TMX.TestData.TestSuites.Count);
        }
    }
}
