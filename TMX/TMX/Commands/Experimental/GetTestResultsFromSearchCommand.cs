/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/3/2012
 * Time: 4:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    using System.Linq;
    using System.Xml.Linq;
    using Tmx.Core;
    using Tmx.Interfaces;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of GetTestResultsFromSearchCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TestResultsFromSearch")]
    internal class GetTestResultsFromSearchCommand : CommonCmdletBase
    {
        protected override void BeginProcessing()
        {
            CheckCmdletParameters();

            var cmdlet = new SearchCmdletBase {FilterAll = true};

            // 20140720
//            var dataObject = new SearchCmdletBaseDataObject {
//                FilterAll = true
//            };
            // 20140721
            var dataObject = new SearchCmdletBaseDataObject {
                Descending = cmdlet.Descending,
                FilterAll = cmdlet.FilterAll,
                FilterDescriptionContains = cmdlet.FilterDescriptionContains,
                FilterFailed = cmdlet.FilterFailed,
                FilterIdContains = cmdlet.FilterIdContains,
                FilterNameContains = cmdlet.FilterNameContains,
                FilterNone = cmdlet.FilterNone,
                FilterNotTested = cmdlet.FilterNotTested,
                FilterOutAutomaticAndTechnicalResults = cmdlet.FilterOutAutomaticAndTechnicalResults,
                FilterOutAutomaticResults = cmdlet.FilterOutAutomaticResults,
                FilterPassed = cmdlet.FilterPassed,
                FilterPassedWithBadSmell = cmdlet.FilterPassedWithBadSmell,
                Id = cmdlet.Id,
                Name = cmdlet.Name,
                OrderByDateTime = cmdlet.OrderByDateTime,
                OrderByFailRate = cmdlet.OrderByFailRate,
                OrderById = cmdlet.OrderById,
                OrderByName = cmdlet.OrderByName,
                OrderByPassRate = cmdlet.OrderByPassRate,
                OrderByTimeSpent = cmdlet.OrderByTimeSpent
            };
            // IOrderedEnumerable<TestSuite> suites =
            IOrderedEnumerable<ITestSuite> suites = TmxHelper.SearchForSuites(dataObject);
            
cmdlet.FilterNone = true;
            
            IOrderedEnumerable<ITestScenario> scenarios = TmxHelper.SearchForScenarios(dataObject);

            //cmdlet.FilterAll = false;
            //cmdlet.FilterPassedWithBadSmell = true;
//            cmdlet.FilterNone = true;
            
            IOrderedEnumerable<ITestResult> testResults = TmxHelper.SearchForTestResults(dataObject);
            
            // 20141124
//            XElement suitesElement = 
//                TmxHelper.CreateSuitesXElementWithParameters(
//                    suites,
//                    scenarios,
//                    testResults,
//                    (new XMLElementsNativeStruct()));
            
            var testResultsExporter = new TestResultsExporter();
            var suitesElement = testResultsExporter.CreateSuitesXElementWithParameters(
                suites,
                scenarios,
                testResults,
                (new XMLElementsNativeStruct()));
            
            WriteObject(this, suitesElement);

        }
    }
}
