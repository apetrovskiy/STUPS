/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.TestManagement.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    //using Microsoft.TeamFoundation
    using System.Net;
    using System.Collections.Specialized;
    
    /// <summary>
    /// Description of TFHelper.
    /// </summary>
    internal class TFHelper
    {
        public TFHelper()
        {
        }
        
        public static void ConnectTFServer(TFSCmdletBase cmdlet, string url, ICredentials credentials)
        {
            try
            {
                Uri uri =
                    //new Uri("http://10.30.37.86:8080/tfs");
                    new Uri(url);
                TfsConfigurationServer tfsServer =
                    new TfsConfigurationServer(
                        uri,
                        credentials);
                CurrentData.CurrentServer = tfsServer;
                
                cmdlet.WriteObject(cmdlet, tfsServer);
            }
//            catch (TeamFoundationServerUnauthorizedException ex)
//            {
//                // handle access denied
//            }
//            catch (TeamFoundationServiceUnavailableException ex)
//            {
//                // handle service unavailable
//            }
            catch (WebException ex)
            {
                // handle other web exception
            }
//            tfsServer.GetTeamProjectCollection
//Console.WriteLine(tfsServer.Name);
//Console.WriteLine(tfsServer.Uri.Host);
//Console.WriteLine(tfsServer.Uri.Port.ToString());
        }
        
        public static void OpenProjectCollection(TFSCmdletBase cmdlet, string name)
        {
            try
            {
//                var projectCollectionUri =
//                    //new Uri("http://tfs2010:8080/tfs/MyCollection");
//                    new Uri(url);
                
                var projectCollectionUri =
                    new Uri(
                        CurrentData.CurrentServer.Uri.OriginalString +
                        "/" +
                        name);
                
                var projectCollection =
                    //TfsTeamProjectCollectionFactory.GetTeamProjectCollection(projectCollectionUri, new UICredentialsProvider());
                    TfsTeamProjectCollectionFactory.GetTeamProjectCollection(projectCollectionUri);
                //projectCollection..ConfigurationServer = CurrentServer;
                projectCollection.EnsureAuthenticated();
                
                CurrentData.CurrentCollection = projectCollection;
                
                cmdlet.WriteObject(cmdlet, projectCollection);
            }
//            catch (TeamFoundationServerUnauthorizedException ex)
//            {
//                // handle access denied
//            }
//            catch (TeamFoundationServiceUnavailableException ex)
//            {
//                // handle service unavailable
//            }
            catch (WebException ex)
            {
                // handle other web exception
            }
            
        }
        
        public static void OpenProject(TFSCmdletBase cmdlet, string name)
        {
Console.WriteLine("00003");
            //throw new NotImplementedException();
            try {
                ITestManagementService testMgmtSvc =
                    (ITestManagementService)CurrentData.CurrentCollection.GetService(typeof(ITestManagementService));
                WorkItemStore store =
                    (WorkItemStore)CurrentData.CurrentCollection.GetService(typeof(WorkItemStore));
                ITestManagementTeamProject project =
                    //((ITestManagementService)CurrentData.CurrentCollection).GetTeamProject(name);
                    testMgmtSvc.GetTeamProject(name);
if (null == project) {
    Console.WriteLine("null");
} else {
    Console.WriteLine("not null");
    Console.WriteLine(project.IsValid.ToString());
}
Console.WriteLine(project);

                CurrentData.CurrentProject = project;
                
                cmdlet.WriteObject(cmdlet, project);
                
            }
            catch (Exception eOpenProject) {
                Console.WriteLine(eOpenProject.Message);
            }
        }
        
        public static void NewTestPlan(TFSCmdletBase cmdlet, string name)
        {
            //throw new NotImplementedException();
            try {
                ITestPlan testPlan =
                    CurrentData.CurrentProject.TestPlans.Create();
                testPlan.Name = name;
                testPlan.Save();
                
                CurrentData.CurrentTestPlan = testPlan;
                
                cmdlet.WriteObject(cmdlet, testPlan);
                
            }
            catch (Exception eNewTestPlan) {
                Console.WriteLine(eNewTestPlan.Message);
            }
        }
        
        public static ITestPlan GetTestPlan(TFSCmdletBase cmdlet, string name) // ??
        {
            throw new NotImplementedException();
        }
        
        public static ITestPlan OpenTestPlan(TFSCmdletBase cmdlet, string name)
        {
            throw new NotImplementedException();
        }
        
        public static void AddTestSuite(TFSCmdletBase cmdlet, string name)
        {
            //throw new NotImplementedException();
            try {
                //CurrentData.CurrentProject.TestPlans.
                //ITestSuiteEntry testSuite =
//                ITestSuiteBase testSuite =
//                    new stat
//                    CurrentData.CurrentTestPlan.RootSuite.Entries.Add("asdf");

//                string[] areas = full_area.Split('\\');
//                string full_path = string.Empty;
                IStaticTestSuite suite =// null;
                    CurrentData.CurrentProject.TestSuites.CreateStatic();
//                string current_area = string.Empty;
                
                suite.Title = name;
                //CurrentData.CurrentTestPlan.RootSuite.Entries.Add(suite);
                //ITestSuiteEntryCollection suites =
                //var suites =
                
                //CurrentData.CurrentTestPlan.RootSuite.Entries.Add(suite);
                

//                for (int i = 0; i < areas.Length; i++)
//                {
//                    if (!string.IsNullOrEmpty(areas[i]))
//                    {
//                        string area = areas[i].RemoveBadChars();
//                        current_area += area;
//
//                        //The first item, find it and assigned to suite object.
//                        if (i == 1)
//                        {
//                            ITestSuiteEntryCollection collection = CurrentData.CurrentTestPlan.RootSuite.Entries;
//                            suite = TestHelper.FindSuite(collection, area);
//                            if (suite.Id == 0)
//                            {
//                                suite.Title = area;
//                                TestHelper.AddTests(suite, current_area);
//                                CurrentData.CurrentTestPlan.RootSuite.Entries.Add(suite);
//                            }
//                        }
//                        else
//                        {
//                            ITestSuiteEntryCollection collection = suite.Entries;
//                            //* collection - Perform search only under the suite.Entries  - Duplicate items allowed. 
//                            IStaticTestSuite subSuite = TestHelper.FindSuite(collection, area);
//
//                            if (subSuite.Id == 0)
//                            {//Cannot find Test Suite
//                                subSuite.Title = area;
//                                suite.Entries.Add(subSuite);
//                                //After creating the Test Suite - Add the related TestCases based on the Area Path.
//                                TestHelper.AddTests(subSuite, current_area);
//                            }
//
//                            suite = subSuite;
//                        }
//                        current_area += "\\";
//                        CurrentData.CurrentTestPlan.Save();
//                    }
//                }
                CurrentData.CurrentTestPlan.Save();
                    
            }
            catch (Exception eAddTestSuite) {
                Console.WriteLine(eAddTestSuite.Message);
            }
        }
        
        public static IStaticTestSuite GetTestSuite(TFSCmdletBase cmdlet, string name)
        {
            throw new NotImplementedException();
        }
        
        public static IStaticTestSuite OpenTesSuite(TFSCmdletBase cmdlet, string name)
        {
            throw new NotImplementedException();
        }
        
        public static void AddTestSubSuite(TFSCmdletBase cmdlet, string name)
        {
            throw new NotImplementedException();
        }
        
        public static void GetTestSubSuite(TFSCmdletBase cmdlet, string name)
        {
            throw new NotImplementedException();
        }
        
        public static void OpenTestSubSuite(TFSCmdletBase cmdlet, string name)
        {
            throw new NotImplementedException();
        }
        
        public static void AddTestCase(TFSCmdletBase cmdlet, string name)
        {
            throw new NotImplementedException();
        }
        
        public static void GetTestCase(TFSCmdletBase cmdlet, string name)
        {
            throw new NotImplementedException();
        }
        
        public static void OpenTestCase(TFSCmdletBase cmdlet, string name)
        {
            throw new NotImplementedException();
        }
        

    }
}
