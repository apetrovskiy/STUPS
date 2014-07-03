/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/20/2012
 * Time: 5:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace ExampleExportTestResultsFromCSharp
{
    using System;
    using TMX;
    using TMX.Interfaces;
    using PSTestLib;
    
    class Program
    {
        /// <summary>
        /// This example demonstrates how to generate test results and
        /// store them to a database and to an XML file.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // these are our collections: test suites plus test results
            System.Collections.ArrayList stories = new System.Collections.ArrayList();
            System.Collections.ArrayList results = new System.Collections.ArrayList();

            Console.WriteLine("generating test data");
            // generating test data
            stories.Add(new TestStory("01", "story01"));
            results.Add(new TestResult("001", "test result 01", "bla-bla-bla", "01", "PASSED"));
            results.Add(new TestResult("002", "test result 02", "bla-bla-bla", "01", "PASSED"));
            results.Add(new TestResult("003", "test result 03", "bla-bla-bla", "01", "PASSED"));
            stories.Add(new TestStory("02", "story01"));
            results.Add(new TestResult("123", "test result 123", "bla-bla-bla", "02", "PASSED"));
            results.Add(new TestResult("456", "test result 456", "bla-bla-bla", "02", "PASSED"));
            results.Add(new TestResult("789", "test result 789", "bla-bla-bla", "02", "FAILED"));
            stories.Add(new TestStory("03", "story01"));
            results.Add(new TestResult("abc", "test result abc", "bla-bla-bla", "03", "FAILED"));
            results.Add(new TestResult("def", "test result def", "bla-bla-bla", "03", "FAILED"));
            results.Add(new TestResult("xyz", "test result xyz", "bla-bla-bla", "03", "PASSED"));
            Console.WriteLine("test data have been generated");
            
            Console.WriteLine("writing test data to library");
            
            // generating test scenarios for previously generated suites and test results
            foreach (TestStory story in stories) {
                
                // creating a new test suite == user story
                TMX.TmxHelper.NewTestSuite(
                    story.Name,
                    story.Id,
                    "platform",
                    "description",
                    null,
                    null);
                
                foreach (TestResult result in results) {
                    if (result.StoryId == story.Id) {
                        
                        AddScenarioCmdletBase cmdlet = 
                            new AddScenarioCmdletBase();
                            cmdlet.Id = result.Id;
                            cmdlet.Name = result.Name;
                            cmdlet.Description = "description";
                        
                        // adding a new test scenario to the test suite
                        // test scenario == name and id of th corresponding test result
                        TMX.TmxHelper.AddTestScenario(cmdlet);
                        
                        // create a test result with the same name and id as the test scenario has
                        TMX.TmxHelper.CloseTestResult(
                            result.Name,
                            result.Id,
                            true, // Passed
                            false, // not a KnownIssue
                            null,
                            null,
                            "description",
                            // 20130322
                            //false);
                            // 20130626
                            //false,
                            TestResultOrigins.Logical,
                            true);
                        
                    }
                }
            }
            Console.WriteLine("test data are ready");
            
            // creating a database
            Console.WriteLine("creating DB");
            TMX.SQLiteHelper.CreateDatabase(
                new TMX.DatabaseFileCmdletBase(),
                @"c:\1\1.db3",
                false,
                false,
                true);
            Console.WriteLine("DB created");
            
            // export test results to the DB
            Console.WriteLine("exporting test data to the DB");
            TMX.SQLiteHelper.BackupTestResults(
                //new PSCmdletBase(),
                new TMX.CommonCmdletBase(),
                TMX.TestData.CurrentResultsDB.Name);
                //TMX.TestData.CurrentResultsDB.Connection);
            
            // closing the database
            Console.WriteLine("closing the DB");
            TMX.SQLiteHelper.CloseDatabase(
                //new PSCmdletBase(),
                new TMX.CommonCmdletBase(),
                TMX.TestData.CurrentTestResult.Name);
            
            // export data to an XML sheet
            Console.WriteLine("export to XML");
            TMX.TmxHelper.ExportResultsToXML(
                (new ImportExportCmdletBase()),
                @"C:\1\export_file.xml");
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
    
    public class TestStory
    {
        public TestStory(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        
        public string Id { get; set; }
        public string Name { get; set; }
    }
    
    public class TestResult
    {
        public TestResult(string id, string name, string description, string storyId, string status)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.StoryId = storyId;
            this.Status = status;
        }
        
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StoryId { get; set; }
        public string Status { get; set; }
    }
}