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
    using MbUnit.Framework;
    using NUnit.Framework;
    using Tmx.Core;
	using Tmx.Core.Types.Remoting;
    using Tmx.Interfaces;
	using Tmx.Interfaces.Remoting;
    using Tmx.Interfaces.TestStructure;
	using Xunit;
    
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
        
    	[MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
    	public void SetUp()
    	{
    	    // TestSettings.PrepareModuleTests();
    	}
    	
    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
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
    	}
    	
    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
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
    	
    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
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
    	
    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
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
    	
        XDocument GIVEN_exported_test_results()
        {
            var listPlatforms = new List<ITestPlatform> {
                new TestPlatform { Id = "1", Name = "p1" },
                new TestPlatform { Id = "2", Name = "p2" }
            };
            var listSuites = new List<ITestSuite> {
                addTestSuite(listPlatforms[0]),
                addTestSuite(listPlatforms[1])
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
            Xunit.Assert.Equal(number, platforms.Count);
        }
        
        void THEN_there_are_N_suites_in_xdocument(int number, List<ITestSuite> suites)
        {
            Xunit.Assert.Equal(number, suites.Count);
        }

        ITestSuite addTestSuite(ITestPlatform platform)
        {
            return new Tmx.Interfaces.TestSuite {
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
                                enStatus = TestResultStatuses.Passed
                            },
                            new TestResult {
                                Id = "2",
                                Name = "tr02",
                                PlatformId = platform.Id,
                                PlatformUniqueId = platform.UniqueId,
                                enStatus = TestResultStatuses.Passed
                            }
                        }
                    }
                }
            };
        }
    }
}
