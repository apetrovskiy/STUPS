//using System.Security.AccessControl;
//using PSTestLib;

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
    using System.Net;
    using System.Collections.Specialized;
    using Meyn.TestLink;
    using System.Management.Automation;
    using System.Linq;
    
    /// <summary>
    /// Description of TLHelper.
    /// </summary>
    internal static class TLHelper
    {
//        public TLHelper()
//        {
//        }
        
        
        public static void ConnectTLServer(
            TLSConnectCmdletBase cmdlet)
        {
            string server = cmdlet.Server;

            if (null != server && string.Empty != server) {

                string connectionString =
                    "http://" +
                    server +
                    "/testlink/lib/api/xmlrpc.php";

                cmdlet.WriteVerbose(cmdlet, "Trying to connect to " + connectionString);

                string apikey = cmdlet.ApiKey;
                
                if (null != apikey && string.Empty != apikey) {

                    TLHelper.ConnectTestLink(
                        cmdlet,
                        (new TestLink(apikey, connectionString)));
                    
                    if (null == TLAddinData.CurrentTestLinkConnection) {
                        cmdlet.WriteError(
                            cmdlet,
                            "Unable to connect to " +
                            "server " +
                            cmdlet.Server +
                            ".",
                            "UnableToConnect",
                            ErrorCategory.InvalidResult,
                            true);
                    }
                    
                    cmdlet.WriteObject(cmdlet, TLAddinData.CurrentTestLinkConnection);
                    
                } else {
                    
                    cmdlet.WriteVerbose(cmdlet, "Wrong parameter: Apikey");
                    cmdlet.WriteError(
                        cmdlet,
                        "The Apikey parameter is wrong.",
                        "WrongParameterApikey",
                        ErrorCategory.InvalidArgument,
                        true);
                }
                
            } else {
                
                cmdlet.WriteVerbose(cmdlet, "Wrong parameter: Server");
                cmdlet.WriteError(
                    cmdlet,
                    "The Server parameter is wrong.",
                    "WrongParameterServer",
                    ErrorCategory.InvalidArgument,
                    true);
            }

        }
        
        internal static ITestLinkExtra ConnectTestLink(
            TLSConnectCmdletBase cmdlet,
            ITestLinkExtra testLinkObject)
        {
            try {
                
                cmdlet.WriteVerbose(cmdlet, "testing the availability of TestLink");
                testLinkObject.SayHello();
                
                cmdlet.WriteVerbose(cmdlet, "testing the api key");
                testLinkObject.checkDevKey(cmdlet.ApiKey);
                
                TLAddinData.CurrentTestLinkConnection =
                    testLinkObject;
                return testLinkObject;
                
            }
            catch (UriFormatException eUriFormat) {
                cmdlet.WriteVerbose(cmdlet, "Wrong Uri: " + eUriFormat.Message);
                return null;
            }
            catch (TestLinkException eTestLinkNative) {
                cmdlet.WriteVerbose(cmdlet, "Wrong Apikey: " + eTestLinkNative.Message);
                return null;
            }
            catch (Exception eTestLInk) {
                cmdlet.WriteVerbose(cmdlet, "Something went wrong: " + eTestLInk.Message);
                return null;
            }
        }
        
        public static void GetProjectCollection(TLSCmdletBase cmdlet)
        {
            try {
                
                cmdlet.WriteVerbose(cmdlet, "GetProjectCollection: getting list of projects");
                System.Collections.Generic.List<TestProject> listProjects =
                    TLAddinData.CurrentTestLinkConnection.GetProjects();
                
                cmdlet.WriteVerbose(cmdlet, "GetProjectCollection: outputting projects");
                cmdlet.WriteObject(cmdlet, listProjects);
                
                // 20130131
                if (null != listProjects && 0 < listProjects.Count) {
                    cmdlet.WriteVerbose(cmdlet, "GetProjectCollection: settiing the current test project");
                    TLAddinData.CurrentTestProject =
                        listProjects[listProjects.Count -1];
                }
            }
            catch (Exception eProjectCollection) {
                cmdlet.WriteError(
                    cmdlet,
                    "Unable to get the list of projects. " +
                    eProjectCollection.Message,
                    "UnableToGetProjects",
                    ErrorCategory.InvalidResult,
                    true);
            }
        }
        
        internal static Meyn.TestLink.TestProject[] GetProjectsByName(TLSCmdletBase cmdlet, string[] projectNames)
        {
            System.Collections.Generic.List<Meyn.TestLink.TestProject> resultList =
                new System.Collections.Generic.List<Meyn.TestLink.TestProject>();
            
            string projectNameNow = string.Empty;
            
            try {
                
                cmdlet.WriteVerbose(cmdlet, "iterating through the project names collection");
                foreach (string name in projectNames) {
                    
                    cmdlet.WriteVerbose(cmdlet, name);
                    projectNameNow = name;
                    
                    cmdlet.WriteVerbose(cmdlet, "getting project '" + projectNameNow + "'.");
                    TestProject testProject =
                        TLAddinData.CurrentTestLinkConnection.GetProject(projectNameNow);
                    
                    if (null != testProject) {
                        TLAddinData.CurrentTestProject = testProject;
                        cmdlet.WriteVerbose(cmdlet, "got the project '" + testProject.name + "'.");
                    }
                    resultList.Add(TLAddinData.CurrentTestProject);
                }
                
            }
            catch (Exception eProject) {
                cmdlet.WriteError(
                    cmdlet,
                    "Unable to get the project '" +
                    projectNameNow +
                    "'. " +
                    eProject.Message,
                    "UnableToGetProject",
                    ErrorCategory.InvalidResult,
                    true);
            }

            Meyn.TestLink.TestProject[] resultArray =
                resultList.ToArray();

            return resultArray;
        }
        
        internal static Meyn.TestLink.TestProject[] GetProjectsById(TLSCmdletBase cmdlet, string[] projectIds)
        {
            System.Collections.Generic.List<Meyn.TestLink.TestProject> resultList =
                new System.Collections.Generic.List<Meyn.TestLink.TestProject>();

            string projectIdNow = string.Empty;
            
            try {

                cmdlet.WriteVerbose(cmdlet, "collecting all projects");
                System.Collections.Generic.List<Meyn.TestLink.TestProject> projectsList =
                    TLAddinData.CurrentTestLinkConnection.GetProjects();

                cmdlet.WriteVerbose(cmdlet, "iterating through the project colection");
                foreach (Meyn.TestLink.TestProject testProject in projectsList) {

                    cmdlet.WriteVerbose(cmdlet, "iterating through the project ids colection");
                    foreach (string id in projectIds) {

                        if (Convert.ToInt32(id) == testProject.id) {

                            TLAddinData.CurrentTestProject = testProject;
                            cmdlet.WriteVerbose(cmdlet, "got the project '" + testProject.name + "'.");

                            resultList.Add(testProject);
                        }
                    }
                }
                
            }
            catch (Exception eProject) {
                cmdlet.WriteError(
                    cmdlet,
                    "Unable to get the project by id. " +
                    eProject.Message,
                    "UnableToGetProject",
                    ErrorCategory.InvalidResult,
                    true);
            }

            Meyn.TestLink.TestProject[] resultArray =
                resultList.ToArray();

            return resultArray;
        }
        
        public static void GetProjectByName(TLSCmdletBase cmdlet, string[] projectNames)
        {
            cmdlet.WriteObject(
                cmdlet,
                TLHelper.GetProjectsByName(
                    cmdlet,
                    projectNames));
        }
        
        public static void GetProjectById(TLSCmdletBase cmdlet, string[] projectIds)
        {

            cmdlet.WriteObject(
                cmdlet,
                TLHelper.GetProjectsById(
                    cmdlet,
                    projectIds));

        }
        
        public static void NewTestPlan(
            TLSCmdletBase cmdlet, 
            string testPlanName,
            string testPlanNotes,
            bool active)
        {
            try {

                string description = string.Empty;
                if (null != testPlanNotes && string.Empty != testPlanNotes) {
                    description = testPlanNotes;
                }
                
                GeneralResult result =
                    TLAddinData.CurrentTestLinkConnection.CreateTestPlan(
                        testPlanName,
                        TLAddinData.CurrentTestProject.name,
                        description,
                        //activePlan);
                        active);
                
                if (result.status) {
                    TLAddinData.CurrentTestPlan =
                        TLAddinData.CurrentTestLinkConnection.getTestPlanByName(
                            TLAddinData.CurrentTestProject.name,
                            testPlanName);
                }
                cmdlet.WriteObject(cmdlet, TLAddinData.CurrentTestPlan);
                
            }
            catch (Exception eNewTestPlan) {
                cmdlet.WriteError(
                    cmdlet,
                    "Couldn't create a test plan '" +
                    testPlanName +
                    "'. " +
                    eNewTestPlan.Message,
                    "" +
                    "CouldNotCreateTestPlan",
                    ErrorCategory.InvalidResult,
                    true);
            }
        }
        
        public static void GetTestPlans(TLSCmdletBase cmdlet, Meyn.TestLink.TestProject[] testProjects)
        {
            try {
                
                for (int i = 0; i < testProjects.Length; i++) {
                    
                    if (null == testProjects[i]) {
                        if (null != TLAddinData.CurrentTestProject) {
                            testProjects[i] = TLAddinData.CurrentTestProject;
                        } else {
                            cmdlet.WriteError(
                                cmdlet,
                                "You must specify a test project.",
                                "NoTestProjectSpecified",
                                ErrorCategory.InvalidArgument,
                                true);
                        }
                    }
                    
                    System.Collections.Generic.List<TestPlan> listTestPlans =
                        TLAddinData.CurrentTestLinkConnection.GetProjectTestPlans(
                            testProjects[i].id);

                    foreach (TestPlan tplan in listTestPlans) {

                        TLAddinData.CurrentTestPlan =
                            tplan;

                    }

                    cmdlet.WriteObject(cmdlet, listTestPlans);
                
                }
                
            }
            catch (Exception eGetTestPlans) {
                cmdlet.WriteError(
                    cmdlet,
                    "Couldn't get test plans. " +
                    eGetTestPlans.Message,
                    "" +
                    "CouldNotCreateTestPlan",
                    ErrorCategory.InvalidResult,
                    true);
            }
        }
        
        public static void GetTestPlan(TLSCmdletBase cmdlet, Meyn.TestLink.TestProject[] testProjects, string[] testPlanNames)
        {
            string testPlanNameNow = string.Empty;
            
            try {
                
//                if (null == testProjects || 0 == testProjects.Length) {
//                    if (null != TLAddinData.CurrentTestProject) {
//                        testProjects = new Meyn.TestLink.TestProject[1];
//                        testProjects[0] = TLAddinData.CurrentTestProject;
//                    }
//                }
                
                if (null == testProjects || 0 == testProjects.Length) {
                    //cmdlet.WriteObject(cmdlet, null); // ??
                    return;
                }
                
                foreach (Meyn.TestLink.TestProject testProject in testProjects) {
                    foreach (string name in testPlanNames) {
                        
                        testPlanNameNow = name;
                    
                        cmdlet.WriteVerbose(
                            cmdlet, 
                            "Trying to get test plan '" +
                            testPlanNameNow +
                            "' from the project '" + 
                            testProject.name +
                            "'.");
                        
                        TestPlan testPlan =
                            TLAddinData.CurrentTestLinkConnection.getTestPlanByName(
                                testProject.name,
                                testPlanNameNow);
                        
                        if (null != testPlan) {
                        
                            TLAddinData.CurrentTestPlan = testPlan;
        
                            cmdlet.WriteObject(cmdlet, testPlan);
                        }
                    
                    }
                }
            }
            catch (Exception eGetTestPlan) {
                cmdlet.WriteError(
                    cmdlet,
                    "Couldn't get test plan '" +
                    testPlanNameNow +
                    "'. " +
                    eGetTestPlan.Message,
                    "" +
                    "CouldNotCreateTestPlan",
                    ErrorCategory.InvalidResult,
                    true);
            }
        }
        
        public static void AddTestSuite(TLSCmdletBase cmdlet, string[] name)
        {
            //
        }
        
        //public static IStaticTestSuite OpenTesSuite(TLSCmdletBase cmdlet, string name)
//        public static object OpenTesSuite(TLSCmdletBase cmdlet, string name)
//        {
//            throw new NotImplementedException();
//        }
        
        public static void AddTestSubSuite(TLSCmdletBase cmdlet, string[] name)
        {
            throw new NotImplementedException();
        }
        
//        public static void GetTestSubSuite(TLSCmdletBase cmdlet, string name)
//        {
//            throw new NotImplementedException();
//        }
        
//        public static void OpenTestSubSuite(TLSCmdletBase cmdlet, string name)
//        {
//            throw new NotImplementedException();
//        }
        
        public static void AddTestCase(
            TLSCmdletBase cmdlet, 
            string name,
            string authorLogin,
            int suiteId,
            int testProjectId,
            string summary,
            string[] keyword,
            int order,
            bool checkDuplicatedName,
            Meyn.TestLink.ActionOnDuplicatedName actionDuplicatedName,
            int executionType,
            int importance)
        {
            string keywords = string.Empty;
            if (null != keyword && 0 < keyword.Length) {
                foreach (string singleKeyword in keyword) {
                    keywords += singleKeyword;
                }
            }
            
            if (null == TLAddinData.CurrentTestProject) {
                //
Console.WriteLine("!!!");
                //
            }
            
            if (null == actionDuplicatedName) {
                actionDuplicatedName = ActionOnDuplicatedName.CreateNewVersion;
            }
            
            TLAddinData.CurrentTestLinkConnection.CreateTestCase(
                authorLogin,
                suiteId,
                name,
                testProjectId,
                summary,
                keywords,
                order,
                checkDuplicatedName,
                actionDuplicatedName,
                executionType,
                importance);
            //
            
            //TLAddinData.CurrentTestLinkConnection.ReportTCResult
        }
        
        public static void GetTestCaseForTestSuite(TLSCmdletBase cmdlet, Meyn.TestLink.TestSuite testSuite, string[] name)
        {
//            System.Collections.Generic.List<Meyn.TestLink.TestCase> testCases =
//                TLAddinData.CurrentTestLinkConnection.GetTestCasesForTestSuite(testSuite.id, true);
//            
//            cmdlet.WriteObject(cmdlet, testCases);
        }
//        
        public static void GetTestCaseForTestPlan(TLSCmdletBase cmdlet, Meyn.TestLink.TestPlan testPlan, string[] name)
        {
//            System.Collections.Generic.List<Meyn.TestLink.TestCase> testCases =
//                TLAddinData.CurrentTestLinkConnection.GetTestCasesForTestPlan(testPlan.id);
//            
//            cmdlet.WriteObject(cmdlet, testPlan);
        }
        
//        public static void OpenTestCase(TLSCmdletBase cmdlet, string name)
//        {
//            throw new NotImplementedException();
//        }

        public static void AddBuild(
            TLSCmdletBase cmdlet,
            TestPlan[] testPlans,
            string buildName,
            string buildNote)
        {
            
            try {
                
                for (int j = 0; j < testPlans.Length; j++) {

                    string description = string.Empty;

                    if (null != buildNote && string.Empty != buildNote) {

                        description = buildNote;
                    }

                    GeneralResult result = 
                        TLAddinData.CurrentTestLinkConnection.CreateBuild(
                            testPlans[j].id,
                            buildName,
                            description);
                    
                    if (result.status) {

                        cmdlet.WriteObject(
                            cmdlet,
                            TLAddinData.CurrentTestLinkConnection.GetLatestBuildForTestPlan(testPlans[j].id));

                    }
                    
                }
                
            }
            catch (Exception eAddBuild) {
                cmdlet.WriteError(
                    cmdlet,
                    "Couldn't create a build '" +
                    buildName +
                    "'. " +
                    eAddBuild.Message,
                    "" +
                    "CouldNotCreateBuild",
                    ErrorCategory.InvalidResult,
                    true);
            }
        }
                
        public static void GetBuild(
            TLSCmdletBase cmdlet,
            TestPlan[] testPlans,
            string[] buildNames)
        {
            string testPlanNameNow = string.Empty;
            
            WildcardOptions options =
                WildcardOptions.IgnoreCase |
                WildcardOptions.Compiled;
            
            try {

                foreach (Meyn.TestLink.TestPlan testPlan in testPlans) {
                    
                    testPlanNameNow = testPlan.name;
                    
                    System.Collections.Generic.List<Meyn.TestLink.Build> buildsList = 
                        TLAddinData.CurrentTestLinkConnection.GetBuildsForTestPlan(testPlan.id);
                    
                    if (null == buildNames || 0 == buildNames.Length) {
                        cmdlet.WriteObject(
                            cmdlet,
                            buildsList);
                    } else {
                        
                        foreach (Meyn.TestLink.Build build in buildsList) {
                            
                            foreach (string buildName in buildNames) {
                                
                                if ((new WildcardPattern(buildName, options)).IsMatch(build.name)) {
                                    
                                    cmdlet.WriteObject(
                                        cmdlet,
                                        build);
                                    
                                }
                            }
                            
                        }
                        
                    }
                }
                
            }
            catch (Exception eGetBuild) {
                cmdlet.WriteError(
                    cmdlet,
                    "Couldn't get builds from  '" +
                    testPlanNameNow +
                    "'. " +
                    eGetBuild.Message,
                    "" +
                    "CouldNotGetBuild",
                    ErrorCategory.InvalidResult,
                    true);
            }
        }
        
        internal static bool checkTestPlan(Meyn.TestLink.TestPlan[] inputObjects)
        {
            bool result = false;
            
            
            if (null == inputObjects) {

                if (null != TLAddinData.CurrentTestPlan) {
                    inputObjects = new Meyn.TestLink.TestPlan[1];
                    inputObjects[0] = TLAddinData.CurrentTestPlan;
                    result = true;
                }
            }
            
            return result;
        }
        
        public static void GetTestSuiteFromProject(TLTestSuiteCmdletBase cmdlet, Meyn.TestLink.TestProject[] testProjects)
        {
            string testProjectNameNow = string.Empty;
            
            try {
                foreach (Meyn.TestLink.TestProject testProject in testProjects) {
                    
                    testProjectNameNow = testProject.name;
                    cmdlet.WriteVerbose(
                        cmdlet, 
                        "getting suites from the test project '" +
                        testProjectNameNow +
                        "'.");
                    
                    System.Collections.Generic.List<Meyn.TestLink.TestSuite> list =
                        TLAddinData.CurrentTestLinkConnection.GetFirstLevelTestSuitesForTestProject(testProject.id);
                    
                    cmdlet.WriteVerbose(cmdlet, "There have been found " + list.Count.ToString() + " test suites.");
                    
                    foreach (Meyn.TestLink.TestSuite testSuiteFound in list) {
                        TLAddinData.CurrentTestSuite = testSuiteFound;
                    }
                    
                    cmdlet.WriteObject(cmdlet, list);
                }
            }
            catch (Exception eTestProject) {
                cmdlet.WriteError(
                    cmdlet,
                    "Failed to get suites from the project '" + 
                    testProjectNameNow +
                    "'. " +
                    eTestProject.Message,
                    "FailedToGetSuites",
                    ErrorCategory.InvalidResult,
                    true);
            }
        }
        
        public static void GetTestSuiteFromTestPlan(TLTestSuiteCmdletBase cmdlet, Meyn.TestLink.TestPlan[] testPlans)
        {
            string testPlanNameNow = string.Empty;
            
            try {
                foreach (Meyn.TestLink.TestPlan testPlan in testPlans) {
                    
                    testPlanNameNow = testPlan.name;
                    cmdlet.WriteVerbose(
                        cmdlet, 
                        "getting suites from the test plan '" +
                        testPlanNameNow +
                        "'.");
                    
                    System.Collections.Generic.List<Meyn.TestLink.TestSuite> list =
                        TLAddinData.CurrentTestLinkConnection.GetTestSuitesForTestPlan(testPlan.id);
                    
                    cmdlet.WriteVerbose(cmdlet, "There have been found " + list.Count.ToString() + " test suites.");
                    
                    foreach (Meyn.TestLink.TestSuite testSuiteFound in list) {
                        TLAddinData.CurrentTestSuite = testSuiteFound;
                    }
                    
                    cmdlet.WriteObject(cmdlet, list);
                }
            }
            catch (Exception eTestPlan) {
                cmdlet.WriteError(
                    cmdlet,
                    "Failed to get suites from the test plan '" + 
                    testPlanNameNow +
                    "'. " +
                    eTestPlan.Message,
                    "FailedToGetSuites",
                    ErrorCategory.InvalidResult,
                    true);
            }
        }
        
        public static void GetTestSuiteFromTestSuite(TLTestSuiteCmdletBase cmdlet, Meyn.TestLink.TestSuite[] testSuites)
        {
            string testSuiteNameNow = string.Empty;
            
            try {
                foreach (Meyn.TestLink.TestSuite testSuite in testSuites) {
                    
                    testSuiteNameNow = testSuite.name;
                    cmdlet.WriteVerbose(
                        cmdlet, 
                        "getting suites from the test suite '" +
                        testSuiteNameNow +
                        "'.");
                    
                    System.Collections.Generic.List<Meyn.TestLink.TestSuite> list =
                        TLAddinData.CurrentTestLinkConnection.GetTestSuitesForTestSuite(testSuite.id);
                    
                    cmdlet.WriteVerbose(cmdlet, "There have been found " + list.Count.ToString() + " test suites.");
                    
                    foreach (Meyn.TestLink.TestSuite testSuiteFound in list) {
                        TLAddinData.CurrentTestSuite = testSuiteFound;
                    }
                    
                    cmdlet.WriteObject(cmdlet, list);
                }
            }
            catch (Exception eTestSuite) {
                cmdlet.WriteError(
                    cmdlet,
                    "Failed to get suites from the test suite '" + 
                    testSuiteNameNow +
                    "'. " +
                    eTestSuite.Message,
                    "FailedToGetSuites",
                    ErrorCategory.InvalidResult,
                    true);
            }
        }
        
        public static void GetTestSuite(TLSCmdletBase cmdlet, string[] suiteNames)
        {
            System.Collections.Generic.List<string> testSuiteNames =
                new System.Collections.Generic.List<string>();
            foreach (string suiteName in suiteNames) {
                testSuiteNames.Add(suiteName);
            }
            
            System.Collections.Generic.List<Meyn.TestLink.TestSuite> testSuites =
                new System.Collections.Generic.List<Meyn.TestLink.TestSuite>();
            
            // getting test projects
            System.Collections.Generic.List<TestProject> testProjects =
                TLAddinData.CurrentTestLinkConnection.GetProjects();
            
            // getting first level test suites
            if (null != testProjects && 0 < testProjects.Count) {
                
                cmdlet.WriteVerbose(
                    cmdlet,
                    "Found " +
                    testProjects.Count.ToString() +
                    " projects.");
                
                foreach (TestProject testProject in testProjects) {
                    
                    cmdlet.WriteVerbose(
                        cmdlet,
                        "getting first level test suites from the project '" +
                        testProject.name +
                        ",.");
                    System.Collections.Generic.List<Meyn.TestLink.TestSuite> firstLevelTestSuites =
                        TLAddinData.CurrentTestLinkConnection.GetFirstLevelTestSuitesForTestProject(testProject.id);
                    
                    if (null != firstLevelTestSuites && 0 < firstLevelTestSuites.Count) {
                        
                        cmdlet.WriteVerbose(
                            cmdlet,
                            "There are " +
                            firstLevelTestSuites.Count.ToString() +
                            " first-level test suites in the project '" +
                            testProject.name +
                            "'.");
                        
                        foreach (string  testSuiteName in testSuiteNames) {
                            System.Collections.Generic.List<Meyn.TestLink.TestSuite> suitesThatMatch =
                                firstLevelTestSuites.FindAll(s => s.name == testSuiteName);
                            if (null != suitesThatMatch && 0 < suitesThatMatch.Count) {
                                
                                cmdlet.WriteVerbose(
                                    cmdlet,
                                    "There are " +
                                    suitesThatMatch.Count.ToString() +
                                    " first-level test suites that match names.");
                                
                                testSuites.AddRange(suitesThatMatch);
                            }
                        }
                        
                        // getting down-level test suites
                        foreach (Meyn.TestLink.TestSuite firstLevelTestSuite in firstLevelTestSuites) {
                            
                            cmdlet.WriteVerbose(
                                cmdlet,
                                "getting down-level test suites from the test suite '" +
                                firstLevelTestSuite.name +
                                "'.");
                            
                            System.Collections.Generic.List<Meyn.TestLink.TestSuite> downLevelTestSuites =
                                TLAddinData.CurrentTestLinkConnection.GetTestSuitesForTestSuite(firstLevelTestSuite.id);
                            
                            if (null != downLevelTestSuites && 0 < downLevelTestSuites.Count) {
                                
                                cmdlet.WriteVerbose(
                                    cmdlet,
                                    "There are " +
                                    downLevelTestSuites.Count.ToString() + 
                                    " down-level test suites in the first-level test suite '" +
                                    firstLevelTestSuite.name +
                                    "'.");
                                
                                foreach (string testSuiteName in testSuiteNames) {
                                    System.Collections.Generic.List<Meyn.TestLink.TestSuite> dlSuitesThatMatch =
                                        downLevelTestSuites.FindAll(d => d.name == testSuiteName);
                                    if (null != dlSuitesThatMatch && 0 < dlSuitesThatMatch.Count) {
                                        
                                        cmdlet.WriteVerbose(
                                            cmdlet,
                                            "There are " +
                                            dlSuitesThatMatch.Count.ToString() +
                                            " down-level test suites that match names.");
                                        
                                        testSuites.AddRange(dlSuitesThatMatch);
                                    }
                                }
                                
                            }
                            
                        }
                        
                    }
                    
                }
                
            }
            
            
            // outputting the test suites collections
            cmdlet.WriteObject(cmdlet, testSuites);
        }
        
        internal static void NewUser(
            TLSCmdletBase cmdlet,
            string login,
            string password,
            string firstName,
            string lastName,
            string email,
            string role,
            string locale,
            bool active,
            bool disabled)
        {
            //TLAddinData.CurrentTestLinkConnection.
        }
    }
}
