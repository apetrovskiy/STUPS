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
    using System.Management.Automation;
    using MbUnit.Framework;using NUnit.Framework;
    using PSTestLib;
    using Tmx;
    // using Tmx.Core;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of NewTmxTestSuiteCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class NewTmxTestSuiteCommandTestFixture
    {
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
        [MbUnit.Framework.Description("New-TmxTestSuite -Name name")]
        [MbUnit.Framework.Category("Fast")]
        public void NewTestSuite_Name()
        {
            const string expectedResultName = "suite name";
            UnitTestingHelper.GetNewTestSuite(expectedResultName, string.Empty, string.Empty);
            MbUnit.Framework.Assert.AreEqual(
                expectedResultName,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name name -Description description")]
        [MbUnit.Framework.Category("Fast")]
        public void NewTestSuite_Name_Description()
        {
            const string expectedResultName = "suite name";
            const string expectedResultDescr = "descr";
            UnitTestingHelper.GetNewTestSuite(expectedResultName, string.Empty, expectedResultDescr);
            MbUnit.Framework.Assert.AreEqual(
                expectedResultName,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedResultDescr,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Description);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name name -Id id")]
        [MbUnit.Framework.Category("Fast")]
        public void NewTestSuite_Name_Id()
        {
            const string expectedResultName = "suite name";
            const string expectedResultId = "suite id";
            UnitTestingHelper.GetNewTestSuite(expectedResultName, expectedResultId, string.Empty);
            MbUnit.Framework.Assert.AreEqual(
                expectedResultName,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedResultId,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name name -Id id -Description description")]
        [MbUnit.Framework.Category("Fast")]
        public void NewTestSuite_Name_Id_Description()
        {
            const string expectedResultName = "suite name";
            const string expectedResultId = "suite id";
            const string expectedResultDescr = "descr";
            UnitTestingHelper.GetNewTestSuite(expectedResultName, expectedResultId, expectedResultDescr);
            MbUnit.Framework.Assert.AreEqual(
                expectedResultName,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedResultId,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Id);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedResultDescr,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Description);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name name; New-TmxTestSuite -Name name")]
        [MbUnit.Framework.Category("Fast")]
        public void NewTestSuite_Name_Duplicated()
        {
            const string expectedResultName = "suite name";
            UnitTestingHelper.GetNewTestSuite(expectedResultName, string.Empty, string.Empty);
            UnitTestingHelper.GetNewTestSuite(expectedResultName, string.Empty, string.Empty);
            
            // checks the first test suite
            MbUnit.Framework.Assert.AreEqual(
                expectedResultName,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.PreviousOutput[0]).Name);
            
            // checks the second test suite
            MbUnit.Framework.Assert.AreEqual(
                expectedResultName,
                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name name -Id id; New-TmxTestSuite -Name name -Id id")]
        [MbUnit.Framework.Category("Fast")]
        public void NewTestSuite_Name_Duplicated_Id_Duplicated()
        {
            const string expectedResultName = "suite name";
            const string expectedResultId = "suite id";
            UnitTestingHelper.GetNewTestSuite(expectedResultName, expectedResultId, string.Empty);
            UnitTestingHelper.GetNewTestSuite(expectedResultName, expectedResultId, string.Empty);
            
            // checks the first test suite
            MbUnit.Framework.Assert.AreEqual(
                // 20140715
                // expectedResultName,
                @"Couldn't create a test suite",
                //((ITestSuite)CommonCmdletBase.UnitTestOutput[CommonCmdletBase.UnitTestOutput.Count - 1]).Name);
                // 20140715
                // ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
                ((ErrorRecord)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Exception.Message);
            
            // checks how many test suites
            Console.WriteLine("Output in the UnitTestOutput object");
            MbUnit.Framework.Assert.AreEqual( // this is a technical solution
                // 20140715
                2,
                UnitTestOutput.Count);
            
            Console.WriteLine("Test Suites counter");
            MbUnit.Framework.Assert.AreEqual( // this is a logical solution
                1,
                TestData.TestSuites.Count);
        }
    }
}
