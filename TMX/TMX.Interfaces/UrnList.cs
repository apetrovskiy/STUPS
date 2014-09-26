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
        public const string TestStructure_Root = "/Results";
        public const string TestStructure_AllResults = "/";
        public const string TestStructure_Suites = "/suites/";
        public const string TestStructure_Scenarios = "/scenarios/";
        public const string TestStructure_Results = "/testResults/";
        public static string TestResultsPostingPoint = TestStructure_Root + TestStructure_AllResults;
        
        // TestClientsModule
        public const string TestClients_Root = "/Clients";
        public const string TestClients_Clients = "/";
        public const string TestClients_ClientById = "/{id:int}";
        public static string TestClientRegistrationPoint = TestClients_Root + TestClients_Clients;
        public static string TestClientDeregistrationPoint = TestClients_ClientById;
        public static string TestClientQueryPoint = TestClients_ClientById;
        
        // TestTasksModule
        public const string TestTasks_Root = "/Tasks";
        public const string TestTasks_CurrentTaskForClientById = "/{id:int}";
        public const string TestTasks_Task = "/{id:int}";
        // public static string TestTasks_CurrentTask = "/currentTask/{id:int}";
        private const string _testTasks_CurrentTask = "/currentTask";
        public static string CurrentTaskForClientById = TestTasks_Root + _testTasks_CurrentTask;
        public static string CurrentTaskOfCurrentClient = _testTasks_CurrentTask + TestTasks_CurrentTaskForClientById;
        public static string TestTasks_AllDesignated = "/";
        public static string TestTasks_AllLoaded = "/loaded";
        
        // TestDataModule
        public const string TestData_Root = "/Data";
        public const string TestData_CommonData = "/";
        public static string CommonDataLoadingPoint = TestData_Root + TestData_CommonData;
        
        // ExternalFilesModule
        public const string ExternalFiles_Root = "/Files";
        public static string ExternalFilesUploadPoint = "/";
        
        // ServerControlModule
        public const string ServerControl_Root = "/ServerControl";
        public const string ServerControlPoint = "/";
    }
}
