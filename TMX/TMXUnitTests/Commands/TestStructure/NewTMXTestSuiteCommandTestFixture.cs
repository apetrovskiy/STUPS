/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 7:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXUnitTests.Commands.TestStructure
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using TMX;
    
    /// <summary>
    /// Description of NewTMXTestSuiteCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class NewTMXTestSuiteCommandTestFixture
    {
        public NewTMXTestSuiteCommandTestFixture()
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
        [Description("New-TMXTestSuite -Name name")]
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
        [Description("New-TMXTestSuite -Name name -Description description")]
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
        [Description("New-TMXTestSuite -Name name -Id id")]
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
        [Description("New-TMXTestSuite -Name name -Id id -Description description")]
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
        [Description("New-TMXTestSuite -Name name; New-TMXTestSuite -Name name")]
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
        [Description("New-TMXTestSuite -Name name -Id id; New-TMXTestSuite -Name name -Id id")]
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
            
            // checks the first test suite
            Assert.AreEqual(
                expectedResultName,
                //((ITestSuite)CommonCmdletBase.UnitTestOutput[CommonCmdletBase.UnitTestOutput.Count - 1]).Name);
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
            
            // checks how many test suites
            Assert.AreEqual( // this is a technical solution
                1,
                PSTestLib.UnitTestOutput.Count);
            Assert.AreEqual( // this is a logical solution
                1,
                TMX.TestData.TestSuites.Count);
        }
    }
}
