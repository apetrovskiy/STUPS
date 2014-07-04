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
    using MbUnit.Framework;using NUnit.Framework;
    using PSTestLib;
    using TMX;
	using TMX.Interfaces;
    
    /// <summary>
    /// Description of OpenTmxTestSuiteCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class OpenTmxTestSuiteCommandTestFixture
    {
        public OpenTmxTestSuiteCommandTestFixture()
        {
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; New-TmxTestSuite -Name suite2; Open-TmxTestSuite -Name suite1")]
        [MbUnit.Framework.Category("Fast")]
        public void OpenTestSuite_Name()
        {
            string expectedResultName = "suite name";
            string expectedResultId = string.Empty;
            UnitTestingHelper.GetNewTestSuite(expectedResultName, expectedResultId, string.Empty);
            UnitTestingHelper.GetNewTestSuite("any suite", string.Empty, string.Empty);
            UnitTestingHelper.GetExistingTestSuite(expectedResultName, expectedResultId);
            MbUnit.Framework.Assert.AreEqual(
                expectedResultName,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; New-TmxTestSuite -Name suite2; Open-TmxTestSuite -Name suite0")]
        [MbUnit.Framework.Category("Fast")]
        public void OpenTestSuite_WrongName()
        {
            string expectedResultName = "suite name";
            string expectedResultId = string.Empty;
            UnitTestingHelper.GetNewTestSuite("wrong name", expectedResultId, string.Empty);
            UnitTestingHelper.GetNewTestSuite("any suite", string.Empty, string.Empty);
            UnitTestingHelper.GetExistingTestSuite(expectedResultName, expectedResultId);
            MbUnit.Framework.Assert.AreNotEqual(
                expectedResultName,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1 -Id id1; New-TmxTestSuite -Name suite2 -Id id2; Open-TmxTestSuite -Id id1")]
        [MbUnit.Framework.Category("Fast")]
        public void OpenTestSuite_Id()
        {
            string expectedResultName = string.Empty;
            string expectedResultId = "suite id";
            UnitTestingHelper.GetNewTestSuite(string.Empty, expectedResultId, string.Empty);
            UnitTestingHelper.GetNewTestSuite(string.Empty, "any id", string.Empty);
            UnitTestingHelper.GetExistingTestSuite(expectedResultName, expectedResultId);
            MbUnit.Framework.Assert.AreEqual(
                expectedResultId,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1 -Id id1; New-TmxTestSuite -Name suite2 -Id id2; Open-TmxTestSuite -Id id0")]
        [MbUnit.Framework.Category("Fast")]
        public void OpenTestSuite_WrongId()
        {
            string expectedResultName = string.Empty;
            string expectedResultId = "suite id";
            UnitTestingHelper.GetNewTestSuite(string.Empty, "wrong id", string.Empty);
            UnitTestingHelper.GetNewTestSuite(string.Empty, "any id", string.Empty);
            UnitTestingHelper.GetExistingTestSuite(expectedResultName, expectedResultId);
            MbUnit.Framework.Assert.AreNotEqual(
                expectedResultId,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Id);
        }
    }
}
