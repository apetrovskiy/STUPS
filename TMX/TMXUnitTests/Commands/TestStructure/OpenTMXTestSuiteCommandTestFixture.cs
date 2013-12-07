/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 11:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxUnitTests.Commands.TestStructure
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using TMX;
    
    /// <summary>
    /// Description of OpenTmxTestSuiteCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class OpenTmxTestSuiteCommandTestFixture
    {
        public OpenTmxTestSuiteCommandTestFixture()
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
        [Description("New-TmxTestSuite -Name suite1; New-TmxTestSuite -Name suite2; Open-TmxTestSuite -Name suite1")]
        [Category("Fast")]
        public void OpenTestSuite_Name()
        {
            string expectedResultName = "suite name";
            string expectedResultId = string.Empty;
            UnitTestingHelper.GetNewTestSuite(expectedResultName, expectedResultId, string.Empty);
            UnitTestingHelper.GetNewTestSuite("any suite", string.Empty, string.Empty);
            UnitTestingHelper.GetExistingTestSuite(expectedResultName, expectedResultId);
            Assert.AreEqual(
                expectedResultName,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite1; New-TmxTestSuite -Name suite2; Open-TmxTestSuite -Name suite0")]
        [Category("Fast")]
        public void OpenTestSuite_WrongName()
        {
            string expectedResultName = "suite name";
            string expectedResultId = string.Empty;
            UnitTestingHelper.GetNewTestSuite("wrong name", expectedResultId, string.Empty);
            UnitTestingHelper.GetNewTestSuite("any suite", string.Empty, string.Empty);
            UnitTestingHelper.GetExistingTestSuite(expectedResultName, expectedResultId);
            Assert.AreNotEqual(
                expectedResultName,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite1 -Id id1; New-TmxTestSuite -Name suite2 -Id id2; Open-TmxTestSuite -Id id1")]
        [Category("Fast")]
        public void OpenTestSuite_Id()
        {
            string expectedResultName = string.Empty;
            string expectedResultId = "suite id";
            UnitTestingHelper.GetNewTestSuite(string.Empty, expectedResultId, string.Empty);
            UnitTestingHelper.GetNewTestSuite(string.Empty, "any id", string.Empty);
            UnitTestingHelper.GetExistingTestSuite(expectedResultName, expectedResultId);
            Assert.AreEqual(
                expectedResultId,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Id);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite1 -Id id1; New-TmxTestSuite -Name suite2 -Id id2; Open-TmxTestSuite -Id id0")]
        [Category("Fast")]
        public void OpenTestSuite_WrongId()
        {
            string expectedResultName = string.Empty;
            string expectedResultId = "suite id";
            UnitTestingHelper.GetNewTestSuite(string.Empty, "wrong id", string.Empty);
            UnitTestingHelper.GetNewTestSuite(string.Empty, "any id", string.Empty);
            UnitTestingHelper.GetExistingTestSuite(expectedResultName, expectedResultId);
            Assert.AreNotEqual(
                expectedResultId,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Id);
        }
    }
}
