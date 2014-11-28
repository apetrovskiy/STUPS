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
    /// Description of UrlList.
    /// </summary>
    public static class UrlList
    {
        // TestResultsModule
        public const string TestResults_Root = TestRuns_Root;
        public const string TestResultsPostingPoint_relPath = "/{id:guid}/results/";
        public static string TestResultsPostingPoint_forClient_relPath = "/results/";
        // 20141031
        // postponed
//        public const string TestStructure_Suites = "/suites/";
//        public const string TestStructure_Scenarios = "/scenarios/";
//        public const string TestStructure_Results = "/testResults/";
        public static string TestResultsPostingPoint_absPath = TestResults_Root + TestResultsPostingPoint_relPath;
        
        #region 111
        // TestClientsModule
        public const string TestClients_Root = "/api/clients";
        public const string TestClientRegistrationPoint_relPath = "/";
        const string TestClients_ClientById_relPath = "/{id:guid}";
        public static string TestClientRegistrationPoint_absPath = TestClients_Root + TestClientRegistrationPoint_relPath;
        public static string TestClientDeregistrationPoint_relPath = TestClients_ClientById_relPath;
        public static string TestClientQueryPoint_relPath = TestClients_ClientById_relPath;
        public static string TestClient_Status_relPath = TestClients_ClientById_relPath + "/status";
        public static string TestClientStatusPoint_absPath = TestClients_Root + TestClient_Status_relPath;
        
        // TestTasksModule
        public const string TestTasks_Root = "/api/tasks";
        public const string TestTasks_CurrentTaskForClientById_relPath = "/{id:guid}";
        public const string TestTasks_Task = "/{id:int}";
        const string _testTasks_CurrentTask = "/currentTask";
        public static string CurrentTaskForClientById = TestTasks_Root + _testTasks_CurrentTask;
        public static string CurrentTaskOfCurrentClient_relPath = _testTasks_CurrentTask + TestTasks_CurrentTaskForClientById_relPath;
        public static string TestTasks_AllDesignated_relPath = "/";
        public static string TestTasks_AllLoaded_relPath = "/loaded";
        
        // TestWorkflowsModule
        public const string TestWorkflows_Root = "/api/workflows";
        public const string TestWorkflows_GetByWorkflowId_relPath = "/{id:guid}";
        public static string TestWorkflowById = TestWorkflows_Root + TestWorkflows_GetByWorkflowId_relPath;
        public const string TestWorkflows_All_relPath = "/";
        public static string TestWorkflowLoadAll_absPath = TestWorkflows_Root + TestWorkflows_All_relPath;
        #endregion 111
        // TestDataModule
        public static string TestData_Root = TestRuns_Root;
        public const string TestData_CommonData_relPath = "/{id:guid}/data/";
        public static string TestData_CommonData_forClient_relPath = "/data/";
        
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
        public const string TestRuns_One_relPath = "/{id:guid}";
        public const string TestRuns_One_absPath = TestRuns_Root + TestRuns_One_relPath;
        public const string TestRuns_ByName_relPath = "/{name}";
        public const string TestRuns_ByName_absPath = TestRuns_Root + TestRuns_ByName_relPath;
        public const string TestRuns_One_Cancel = TestRuns_One_relPath + "/cancelTestRun";
        
        // ViewsTestRunsModule
        public const string ViewTestRuns_Root = "/testRuns";
        public const string ViewTestRuns_NewTestRunPage = "/newTestRun";
        public const string ViewTestRuns_NewTestRunPageName = "newTestRun.liquid";
        
        public const string ViewTestRuns_TestRunsPage = "/TestRuns";
        public const string ViewTestRuns_TestRunsPageName = "TestRuns.liquid";
        
        public const string ViewTestRuns_ParametersPage = "/{id:guid}/testParameters";
        public const string ViewTestRuns_ParametersPageName = "testParameters.liquid";
        public const string ViewTestRuns_ClientsPage = "/{id:guid}/clients";
        public const string ViewTestRuns_ClientsPageName = "clients.liquid";
        public const string ViewTestRuns_TasksPage = "/{id:guid}/tasks";
        public const string ViewTestRuns_TasksPageName = "tasks.liquid";
        public const string ViewTestRuns_ResultsPage = "/{id:guid}/testResults";
        public const string ViewTestRuns_ResultsPageName = "testResults.liquid";
        
//        public const string ViewTestRuns_TestRun_CancelPage = "/{id:guid}/cancelTestRun";
//        public const string ViewTestRuns_TestRun_CancelPageName = "cancelTestRun.liquid";
        
        // ViewsRootPageModule
        public const string ViewRootPage_Root = "/";
        public const string ViewRootPage_RootPageName = "index.htm";
        public const string ViewRootPage_ScriptsFolder = "Scripts/";
        
        // ViewsTestStatusModule
        public const string ViewTestStatus_Root = "/status";
        public const string ViewTestStatus_All_ClientsPage = "/clients";
        public const string ViewTestStatus_All_ClientsPageName = "/clients.liquid";
        public const string ViewTestStatus_All_TasksPage = "/tasks";
        public const string ViewTestStatus_All_TasksPageName = "tasks.liquid";
//        public const string ViewTestStatus_TestRunsPage = "/TestRuns";
//        public const string ViewTestStatus_TestRunsPageName = "TestRuns.liquid";
        public const string ViewTestStatus_WorkflowsPage = "/workflows";
        public const string ViewTestStatus_WorkflowsPageName = "workflows.htm";
        public const string ViewTestStatus_TestLabsPage = "/testLabs";
        public const string ViewTestStatus_TestLabsPageName = "testLabs.liquid";
//        public const string ViewTestStatus_TestRun_CancelPage = "/{id:guid}/cancelTestRun";
//        public const string ViewTestStatus_TestRun_CancelPageName = "cancelTestRun.liquid";
        
        // ViewsTestResultsModule
        public const string ViewTestResults_Root = "/results";
        // deprecated
        public const string ViewTestResults_OverviewPageName = "overview.htm";
        // deprecated
        public static string ViewTestResults_OverviewPage = "/" + ViewTestResults_OverviewPageName;
        public static string ViewTestResults_OverviewNewPage = "/overview";
        public const string ViewTestResults_OverviewNewPageName = "overview.liquid";
        
        public const string ViewTestWorkflowParameters_Root = "/workflows";
        public const string ViewTestWorkflowParameters_DefaultPageName = "without_parameters.html";
    }
}
