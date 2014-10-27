/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2014
 * Time: 10:15 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Server
{
    using System;
    
    /// <summary>
    /// Description of UrnList.
    /// </summary>
    public static class UrnList
    {
        // TestResultsModule
        public const string TestStructure_Root = "/api/results";
        public const string TestResultsPostingPoint_relPath = "/";
        public const string TestStructure_Suites = "/suites/";
        public const string TestStructure_Scenarios = "/scenarios/";
        public const string TestStructure_Results = "/testResults/";
        public static string TestResultsPostingPoint_absPath = TestStructure_Root + TestResultsPostingPoint_relPath;
        
        // TestClientsModule
        public const string TestClients_Root = "/api/clients";
        public const string TestClientRegistrationPoint_relPath = "/";
        const string TestClients_ClientById_relPath = "/{id:int}";
        public static string TestClientRegistrationPoint_absPath = TestClients_Root + TestClientRegistrationPoint_relPath;
        public static string TestClientDeregistrationPoint_relPath = TestClients_ClientById_relPath;
        public static string TestClientQueryPoint_relPath = TestClients_ClientById_relPath;
        public static string TestClient_Status_relPath = TestClients_ClientById_relPath + "/status";
        public static string TestClientStatusPoint_absPath = TestClients_Root + TestClient_Status_relPath;
        
        // TestTasksModule
        public const string TestTasks_Root = "/api/tasks";
        public const string TestTasks_CurrentTaskForClientById_relPath = "/{id:int}";
        public const string TestTasks_Task = "/{id:int}";
        const string _testTasks_CurrentTask = "/currentTask";
        public static string CurrentTaskForClientById = TestTasks_Root + _testTasks_CurrentTask;
        public static string CurrentTaskOfCurrentClient_relPath = _testTasks_CurrentTask + TestTasks_CurrentTaskForClientById_relPath;
        public static string TestTasks_AllDesignated_relPath = "/";
        public static string TestTasks_AllLoaded_relPath = "/loaded";
        
        // TestWorkflowsModule
        public const string TestWorkflows_Root = "/api/workflows";
        public const string TestWorkflows_GetByWorkflowId_relPath = "/{id:int}";
        public static string TestWorkflowById = TestWorkflows_Root + TestWorkflows_GetByWorkflowId_relPath;
        public const string TestWorkflows_All_relPath = "/";
        public static string TestWorkflowLoadAll_absPath = TestWorkflows_Root + TestWorkflows_All_relPath;
        
        // TestDataModule
        public const string TestData_Root = "/api/data";
        public const string TestData_CommonData_relPath = "/";
        public static string CommonDataLoadingPoint_absPath = TestData_Root + TestData_CommonData_relPath;
        
        // ExternalFilesModule
        public const string ExternalFiles_Root = "/api/files";
        public static string ExternalFilesUploadPoint_relPath = "/";
        
        // ServerControlModule
        public const string ServerControl_Root = "/api/serverControl";
        public const string ServerControlPoint_relPath = "/";
        public const string ServerControlPoint_absPath = ServerControl_Root + ServerControlPoint_relPath;
        
        // TestRunsModule
        public const string TestRuns_Root = "/api/testRuns";
        public const string TestRunsControlPoint_relPath = "/";
        public const string TestRunsControlPoint_absPath = TestRuns_Root + TestRunsControlPoint_relPath;
        public const string TestRuns_One_relPath = "/{id:int}";
        public const string TestRuns_One_absPath = TestRuns_Root + TestRuns_One_relPath;
        public const string TestRuns_ByName_relPath = "/{name}";
        public const string TestRuns_ByName_absPath = TestRuns_Root + TestRuns_ByName_relPath;
        
        // ViewsTestRunsModule
//        public const string TestRunsViews_Root = "/testRuns";
//        public const string TestRunsViews_OverviewPageName = "TestRuns.liquid";
        
        // ViewsRootPageModule
        public const string RootPage_Root = "/";
        public const string RootPage_RootPageName = "index.htm";
        public const string RootPage_ScriptsFolder = "Scripts/";
        
        // ViewsTestStatusModule
        public const string TestStatusViews_Root = "/status";
        public const string TestStatusViews_ClientsPageName = "/clients.htm";
        public static string TestStatusViews_ClientsPage = "/clients"; // + TestStatusViews_ClientsPageName;
        public const string TestStatusViews_TasksPageName = "tasks.htm";
        public static string TestStatusViews_TasksPage = "/tasks"; // + TestStatusViews_TasksPageName;
        public const string TestStatusViews_TestRunsPageName = "TestRuns.liquid";
        public static string TestStatusViews_TestRunsPage = "/TestRuns"; // + TestStatusViews_TestRunsPageName;
        
        // ViewsTestResultsModule
        public const string TestResultsViews_Root = "/results";
        public const string TestResultsViews_OverviewPageName = "overview.htm";
        public static string TestResultsViews_OverviewPage = "/" + TestResultsViews_OverviewPageName;
        public const string TestResultsViews_OverviewNewPageName = "overview.liquid";
        public static string TestResultsViews_OverviewNewPage = "/overview";
    }
}
