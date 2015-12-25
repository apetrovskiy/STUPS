/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/22/2014
 * Time: 7:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Core;
    using Interfaces;
    using Interfaces.TestStructure;
    using Xunit;
    using Assert = Xunit.Assert;
    using TestSuite = Interfaces.TestSuite;

    /// <summary>
    /// Description of ImportExportTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ImportExportTestFixture
    {
        public ImportExportTestFixture()
        {
            // TestSettings.PrepareModuleTests();
        }

        [MbUnit.Framework.SetUp]
        [NUnit.Framework.SetUp]
        public void SetUp()
        {
            // TestSettings.PrepareModuleTests();
        }

        [MbUnit.Framework.Test]
        [NUnit.Framework.Test]
        [Fact]
        public void ShouldImportExportedData()
        {
            var sourceTestPlatforms = new List<ITestPlatform>();
            var sourceTestSuites = new List<ITestSuite>();
            
            var xDoc = GivenExportedTestResults();
            var platforms = WhenImportingTestPlatforms(xDoc);
            var suites = WhenImportingTestResults(xDoc);
            var testResultsImporter = new TestResultsImporter();
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites);
            ThenThereAreNPlatformsInXdocument(2, sourceTestPlatforms);
            ThenThereAreNSuitesInXdocument(2, sourceTestSuites);

            ThenTestResultNStatusIs(suites, "1", TestStatuses.Passed);
            ThenTestResultNStatusIs(sourceTestSuites, "2", TestStatuses.Passed);
            ThenTestResultNStatusIs(sourceTestSuites, "3", TestStatuses.Failed);
            ThenTestResultNStatusIs(sourceTestSuites, "4", TestStatuses.KnownIssue);
            ThenTestResultNStatusIs(sourceTestSuites, "5", TestStatuses.NotRun);
        }

        [MbUnit.Framework.Test]
        [NUnit.Framework.Test]
        [Fact]
        public void ShouldImportExportedTwoDataSets()
        {
            var sourceTestPlatforms = new List<ITestPlatform>();
            var sourceTestSuites = new List<ITestSuite>();
            
            var xDoc = GivenExportedTestResults();
            var platforms01 = WhenImportingTestPlatforms(xDoc);
            var suites01 = WhenImportingTestResults(xDoc);
            var testResultsImporter = new TestResultsImporter();
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms01);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites01);
            
            xDoc = GivenExportedTestResults();
            var platforms02 = WhenImportingTestPlatforms(xDoc);
            var suites02 = WhenImportingTestResults(xDoc);
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms02);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites02);
            
            ThenThereAreNPlatformsInXdocument(4, sourceTestPlatforms);
            ThenThereAreNSuitesInXdocument(4, sourceTestSuites);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldImportExportedDataTwiceWithoutDuplication()
        {
            var sourceTestPlatforms = new List<ITestPlatform>();
            var sourceTestSuites = new List<ITestSuite>();
            
            var xDoc = GivenExportedTestResults();
            var platforms = WhenImportingTestPlatforms(xDoc);
            var suites = WhenImportingTestResults(xDoc);
            var testResultsImporter = new TestResultsImporter();
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites);
            
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites);
            
            ThenThereAreNPlatformsInXdocument(2, sourceTestPlatforms);
            ThenThereAreNSuitesInXdocument(2, sourceTestSuites);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldImportExportedDataThriceWithoutDuplication()
        {
            var sourceTestPlatforms = new List<ITestPlatform>();
            var sourceTestSuites = new List<ITestSuite>();
            
            var xDoc = GivenExportedTestResults();
            var platforms = WhenImportingTestPlatforms(xDoc);
            var suites = WhenImportingTestResults(xDoc);
            var testResultsImporter = new TestResultsImporter();
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites);
            
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites);
            
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites);
            
            ThenThereAreNPlatformsInXdocument(2, sourceTestPlatforms);
            ThenThereAreNSuitesInXdocument(2, sourceTestSuites);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldImportExportedDataWithDuplicatesThriceWithoutDuplication()
        {
            var sourceTestPlatforms = new List<ITestPlatform>();
            var sourceTestSuites = new List<ITestSuite>();
            
            var xDoc = GivenExportedTestResults();
            var platforms = WhenImportingTestPlatforms(xDoc);
            var suites = WhenImportingTestResults(xDoc);
            var testResultsImporter = new TestResultsImporter();
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites);
            
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites);
            
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites);
            
            ThenThereAreNPlatformsInXdocument(2, sourceTestPlatforms);
            ThenThereAreNSuitesInXdocument(2, sourceTestSuites);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////// filtering ////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldImportExportedDataWithExclusion()
        {
            var sourceTestPlatforms = new List<ITestPlatform>();
            var sourceTestSuites = new List<ITestSuite>();
            TestData.ExcludeList = new List<string> {"03"};

            var xDoc = GivenExportedTestResults();
            var platforms = WhenImportingTestPlatforms(xDoc);
            var suites = WhenImportingTestResults(xDoc);
            var testResultsImporter = new TestResultsImporter();
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites);
            ThenThereAreNPlatformsInXdocument(2, sourceTestPlatforms);
            ThenThereAreNSuitesInXdocument(2, sourceTestSuites);

            ThenTestResultNStatusIs(suites, "1", TestStatuses.Passed);
            ThenTestResultNStatusIs(sourceTestSuites, "2", TestStatuses.Passed);
            /*
            ThenTestResultNStatusIs(sourceTestSuites, "3", TestStatuses.Failed);
            ThenTestResultNStatusIs(sourceTestSuites, "4", TestStatuses.KnownIssue);
            ThenTestResultNStatusIs(sourceTestSuites, "5", TestStatuses.NotRun);
            */
            ThenTestResultNStatusIs(sourceTestSuites, "3", TestStatuses.KnownIssue);
            ThenTestResultNStatusIs(sourceTestSuites, "4", TestStatuses.KnownIssue);
            ThenTestResultNStatusIs(sourceTestSuites, "5", TestStatuses.NotRun);
        }
        
        XDocument GivenExportedTestResults()
        {
            var listPlatforms = new List<ITestPlatform> {
                new TestPlatform { Id = "1", Name = "p1" },
                new TestPlatform { Id = "2", Name = "p2" }
            };
            var listSuites = new List<ITestSuite> {
                AddTestSuiteWithOneScenario(listPlatforms[0]),
                AddTestSuiteWithOneScenario(listPlatforms[1])
                };
            var testResultsExporter = new TestResultsExporter();
            return testResultsExporter.GetTestResultsAsXdocument(
                new SearchCmdletBaseDataObject {
                    FilterAll = true
                },
                listSuites,
                listPlatforms);
        }
        
        XDocument GivenExportedTestResultsWithDuplicates()
        {
            var listPlatforms = new List<ITestPlatform> {
                new TestPlatform { Id = "1", Name = "p1" },
                new TestPlatform { Id = "2", Name = "p2" }
            };
            var listSuites = new List<ITestSuite> {
                AddTestSuiteWithTwoScenarios(listPlatforms[0]),
                AddTestSuiteWithTwoScenarios(listPlatforms[1])
                };
            var testResultsExporter = new TestResultsExporter();
            return testResultsExporter.GetTestResultsAsXdocument(
                new SearchCmdletBaseDataObject {
                    FilterAll = true
                },
                listSuites,
                listPlatforms);
        }
        
        List<ITestPlatform> WhenImportingTestPlatforms(XDocument xDoc)
        {
            var testResultsImporter = new TestResultsImporter();
            return testResultsImporter.ImportTestPlatformFromXdocument(xDoc);
        }
        
        List<ITestSuite> WhenImportingTestResults(XDocument xDoc)
        {
            var testResultsImporter = new TestResultsImporter();
            return testResultsImporter.ImportTestResultsFromXdocument(xDoc);
        }
        
        void ThenThereAreNPlatformsInXdocument(int number, List<ITestPlatform> platforms)
        {
            Assert.Equal(number, platforms.Count);
        }
        
        void ThenThereAreNSuitesInXdocument(int number, List<ITestSuite> suites)
        {
            Assert.Equal(number, suites.Count);
        }

        ITestSuite AddTestSuiteWithOneScenario(ITestPlatform platform)
        {
            const string suiteId = "1";
            var suiteUniqueId = Guid.NewGuid();
            const string scenarioId = "1";
            var scenarioUniqueId = Guid.NewGuid();
            
            return new TestSuite {
                Id = suiteId,
                Name = "s01",
                PlatformId = platform.Id,
                PlatformUniqueId = platform.UniqueId,
                UniqueId = suiteUniqueId,
                TestScenarios = new List<ITestScenario> {
                    new TestScenario {
                        Id = scenarioId,
                        Name = "sc01",
                        PlatformId = platform.Id,
                        PlatformUniqueId = platform.UniqueId,
                        SuiteId = suiteId,
                        SuiteUniqueId = suiteUniqueId,
                        UniqueId = scenarioUniqueId,
                        TestResults = new List<ITestResult> {
                            new TestResult {
                                Id = "1",
                                Name = "tr01",
                                PlatformId = platform.Id,
                                PlatformUniqueId = platform.UniqueId,
                                enStatus = TestStatuses.Passed,
                                SuiteId = suiteId,
                                SuiteUniqueId = suiteUniqueId,
                                ScenarioId = scenarioId,
                                ScenarioUniqueId = scenarioUniqueId
                            },
                            new TestResult {
                                Id = "2",
                                Name = "tr02",
                                PlatformId = platform.Id,
                                PlatformUniqueId = platform.UniqueId,
                                enStatus = TestStatuses.Passed,
                                SuiteId = suiteId,
                                SuiteUniqueId = suiteUniqueId,
                                ScenarioId = scenarioId,
                                ScenarioUniqueId = scenarioUniqueId
                                    ,
                                Origin = TestResultOrigins.Logical
                            },
                            new TestResult {
                                Id = "3",
                                Name = "tr03",
                                PlatformId = platform.Id,
                                PlatformUniqueId = platform.UniqueId,
                                enStatus = TestStatuses.Failed,
                                SuiteId = suiteId,
                                SuiteUniqueId = suiteUniqueId,
                                ScenarioId = scenarioId,
                                ScenarioUniqueId = scenarioUniqueId
                                    ,
                                Origin = TestResultOrigins.Technical
                            },
                            new TestResult {
                                Id = "4",
                                Name = "tr04",
                                PlatformId = platform.Id,
                                PlatformUniqueId = platform.UniqueId,
                                enStatus = TestStatuses.KnownIssue,
                                SuiteId = suiteId,
                                SuiteUniqueId = suiteUniqueId,
                                ScenarioId = scenarioId,
                                ScenarioUniqueId = scenarioUniqueId
                            },
                            new TestResult {
                                Id = "5",
                                Name = "tr05",
                                PlatformId = platform.Id,
                                PlatformUniqueId = platform.UniqueId,
                                enStatus = TestStatuses.NotRun,
                                SuiteId = suiteId,
                                SuiteUniqueId = suiteUniqueId,
                                ScenarioId = scenarioId,
                                ScenarioUniqueId = scenarioUniqueId
                            }
                        }
                    }
                }
            };
        }
        
        ITestSuite AddTestSuiteWithTwoScenarios(ITestPlatform platform)
        {
            return new TestSuite {
                Id = "1",
                Name = "s01",
                PlatformId = platform.Id,
                PlatformUniqueId = platform.UniqueId,
                TestScenarios = new List<ITestScenario> {
                    new TestScenario {
                        Id = "1",
                        Name = "sc01",
                        PlatformId = platform.Id,
                        PlatformUniqueId = platform.UniqueId,
                        TestResults = new List<ITestResult> {
                            new TestResult {
                                Id = "1",
                                Name = "tr01",
                                PlatformId = platform.Id,
                                PlatformUniqueId = platform.UniqueId,
                                enStatus = TestStatuses.Passed
                            },
                            new TestResult {
                                Id = "2",
                                Name = "tr02",
                                PlatformId = platform.Id,
                                PlatformUniqueId = platform.UniqueId,
                                enStatus = TestStatuses.Passed
                            }
                        }
                    },
                    new TestScenario {
                        Id = "1",
                        Name = "sc01",
                        PlatformId = platform.Id,
                        PlatformUniqueId = platform.UniqueId,
                        TestResults = new List<ITestResult> {
                            new TestResult {
                                Id = "1",
                                Name = "tr01",
                                PlatformId = platform.Id,
                                PlatformUniqueId = platform.UniqueId,
                                enStatus = TestStatuses.Passed
                            },
                            new TestResult {
                                Id = "2",
                                Name = "tr02",
                                PlatformId = platform.Id,
                                PlatformUniqueId = platform.UniqueId,
                                enStatus = TestStatuses.Passed
                            }
                        }
                    }
                }
            };
        }

        void ThenTestResultNStatusIs(List<ITestSuite> suites, string id, TestStatuses status)
        {
            Assert.Equal(status, suites[0].TestScenarios[0].TestResults.First(testResult => testResult.Id == id).enStatus);
        }
    }
}
