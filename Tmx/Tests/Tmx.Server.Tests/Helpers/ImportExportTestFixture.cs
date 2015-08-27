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
    using MbUnit.Framework;
    using Xunit;
    using Assert = Xunit.Assert;
    using TestSuite = Interfaces.TestSuite;

    /// <summary>
    /// Description of ImportExportTestFixture.
    /// </summary>
    [TestFixture][NUnit.Framework.TestFixture]
    public class ImportExportTestFixture
    {
        public ImportExportTestFixture()
        {
            // TestSettings.PrepareModuleTests();
        }
        
        [SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            // TestSettings.PrepareModuleTests();
        }
        
        [Test][NUnit.Framework.Test][Fact]
        public void Should_import_exported_data()
        {
            var sourceTestPlatforms = new List<ITestPlatform>();
            var sourceTestSuites = new List<ITestSuite>();
            
            var xDoc = GIVEN_exported_test_results();
            var platforms = WHEN_importing_test_platforms(xDoc);
            var suites = WHEN_importing_test_results(xDoc);
            var testResultsImporter = new TestResultsImporter();
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites);
            THEN_there_are_N_platforms_in_xdocument(2, sourceTestPlatforms);
            THEN_there_are_N_suites_in_xdocument(2, sourceTestSuites);

            // 20150805
            // THEN_test_result_N_status_is(suites, "1", TestResultStatuses.Passed);
            THEN_test_result_N_status_is(suites, "1", TestStatuses.Passed);
            // 20150805
            // THEN_test_result_N_status_is(sourceTestSuites, "2", TestResultStatuses.Passed);
            THEN_test_result_N_status_is(sourceTestSuites, "2", TestStatuses.Passed);
            // 20150805
            // THEN_test_result_N_status_is(sourceTestSuites, "3", TestResultStatuses.Failed);
            THEN_test_result_N_status_is(sourceTestSuites, "3", TestStatuses.Failed);
            // 20150805
            // THEN_test_result_N_status_is(sourceTestSuites, "4", TestResultStatuses.KnownIssue);
            THEN_test_result_N_status_is(sourceTestSuites, "4", TestStatuses.KnownIssue);
            // 20150805
            // THEN_test_result_N_status_is(sourceTestSuites, "5", TestResultStatuses.NotTested);
            THEN_test_result_N_status_is(sourceTestSuites, "5", TestStatuses.NotRun);
        }
        
        [Test][NUnit.Framework.Test][Fact]
        public void Should_import_exported_two_data_sets()
        {
            var sourceTestPlatforms = new List<ITestPlatform>();
            var sourceTestSuites = new List<ITestSuite>();
            
            var xDoc = GIVEN_exported_test_results();
            var platforms01 = WHEN_importing_test_platforms(xDoc);
            var suites01 = WHEN_importing_test_results(xDoc);
            var testResultsImporter = new TestResultsImporter();
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms01);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites01);
            
            xDoc = GIVEN_exported_test_results();
            var platforms02 = WHEN_importing_test_platforms(xDoc);
            var suites02 = WHEN_importing_test_results(xDoc);
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms02);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites02);
            
            THEN_there_are_N_platforms_in_xdocument(4, sourceTestPlatforms);
            THEN_there_are_N_suites_in_xdocument(4, sourceTestSuites);
        }
        
        [Test][NUnit.Framework.Test][Fact]
        public void Should_import_exported_data_twice_without_duplication()
        {
            var sourceTestPlatforms = new List<ITestPlatform>();
            var sourceTestSuites = new List<ITestSuite>();
            
            var xDoc = GIVEN_exported_test_results();
            var platforms = WHEN_importing_test_platforms(xDoc);
            var suites = WHEN_importing_test_results(xDoc);
            var testResultsImporter = new TestResultsImporter();
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites);
            
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites);
            
            THEN_there_are_N_platforms_in_xdocument(2, sourceTestPlatforms);
            THEN_there_are_N_suites_in_xdocument(2, sourceTestSuites);
        }
        
        [Test][NUnit.Framework.Test][Fact]
        public void Should_import_exported_data_thrice_without_duplication()
        {
            var sourceTestPlatforms = new List<ITestPlatform>();
            var sourceTestSuites = new List<ITestSuite>();
            
            var xDoc = GIVEN_exported_test_results();
            var platforms = WHEN_importing_test_platforms(xDoc);
            var suites = WHEN_importing_test_results(xDoc);
            var testResultsImporter = new TestResultsImporter();
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites);
            
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites);
            
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites);
            
            THEN_there_are_N_platforms_in_xdocument(2, sourceTestPlatforms);
            THEN_there_are_N_suites_in_xdocument(2, sourceTestSuites);
        }
        
        [Test][NUnit.Framework.Test][Fact]
        public void Should_import_exported_data_with_duplicates_thrice_without_duplication()
        {
            var sourceTestPlatforms = new List<ITestPlatform>();
            var sourceTestSuites = new List<ITestSuite>();
            
            var xDoc = GIVEN_exported_test_results();
            var platforms = WHEN_importing_test_platforms(xDoc);
            var suites = WHEN_importing_test_results(xDoc);
            var testResultsImporter = new TestResultsImporter();
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites);
            
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites);
            
            testResultsImporter.MergeTestPlatforms(sourceTestPlatforms, platforms);
            testResultsImporter.MergeTestSuites(sourceTestSuites, suites);
            
            THEN_there_are_N_platforms_in_xdocument(2, sourceTestPlatforms);
            THEN_there_are_N_suites_in_xdocument(2, sourceTestSuites);
        }
        
        XDocument GIVEN_exported_test_results()
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
        
        XDocument GIVEN_exported_test_results_with_duplicates()
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
        
        List<ITestPlatform> WHEN_importing_test_platforms(XDocument xDoc)
        {
            var testResultsImporter = new TestResultsImporter();
            return testResultsImporter.ImportTestPlatformFromXdocument(xDoc);
        }
        
        List<ITestSuite> WHEN_importing_test_results(XDocument xDoc)
        {
            var testResultsImporter = new TestResultsImporter();
            return testResultsImporter.ImportTestResultsFromXdocument(xDoc);
        }
        
        void THEN_there_are_N_platforms_in_xdocument(int number, List<ITestPlatform> platforms)
        {
            Assert.Equal(number, platforms.Count);
        }
        
        void THEN_there_are_N_suites_in_xdocument(int number, List<ITestSuite> suites)
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
                                // 20150805
                                // enStatus = TestResultStatuses.Passed,
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
                                // 20150805
                                // enStatus = TestResultStatuses.Passed,
                                enStatus = TestStatuses.Passed,
                                SuiteId = suiteId,
                                SuiteUniqueId = suiteUniqueId,
                                ScenarioId = scenarioId,
                                ScenarioUniqueId = scenarioUniqueId
                            },
                            new TestResult {
                                Id = "3",
                                Name = "tr03",
                                PlatformId = platform.Id,
                                PlatformUniqueId = platform.UniqueId,
                                // 20150805
                                // enStatus = TestResultStatuses.Failed,
                                enStatus = TestStatuses.Failed,
                                SuiteId = suiteId,
                                SuiteUniqueId = suiteUniqueId,
                                ScenarioId = scenarioId,
                                ScenarioUniqueId = scenarioUniqueId
                            },
                            new TestResult {
                                Id = "4",
                                Name = "tr04",
                                PlatformId = platform.Id,
                                PlatformUniqueId = platform.UniqueId,
                                // 20150805
                                // enStatus = TestResultStatuses.KnownIssue,
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
                                // 20150805
                                // enStatus = TestResultStatuses.NotTested,
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
                                // 20150805
                                // enStatus = TestResultStatuses.Passed
                                enStatus = TestStatuses.Passed
                            },
                            new TestResult {
                                Id = "2",
                                Name = "tr02",
                                PlatformId = platform.Id,
                                PlatformUniqueId = platform.UniqueId,
                                // 20150805
                                // enStatus = TestResultStatuses.Passed
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
                                // 20150805
                                // enStatus = TestResultStatuses.Passed
                                enStatus = TestStatuses.Passed
                            },
                            new TestResult {
                                Id = "2",
                                Name = "tr02",
                                PlatformId = platform.Id,
                                PlatformUniqueId = platform.UniqueId,
                                // 20150805
                                // enStatus = TestResultStatuses.Passed
                                enStatus = TestStatuses.Passed
                            }
                        }
                    }
                }
            };
        }

        // 20150805
        // void THEN_test_result_N_status_is(List<ITestSuite> suites, string id, TestResultStatuses status)
        void THEN_test_result_N_status_is(List<ITestSuite> suites, string id, TestStatuses status)
        {
            Assert.Equal(status, suites[0].TestScenarios[0].TestResults.First(testResult => testResult.Id == id).enStatus);
        }
    }
}
