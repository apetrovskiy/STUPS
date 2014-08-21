/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2014
 * Time: 10:15 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Interfaces.Server
{
    using System;
    
    /// <summary>
    /// Description of UrnList.
    /// </summary>
    public static class UrnList
    {
        public const string TestStructure_Root = "/Results";
        public const string TestStructure_Suites = "/suites/";
        public const string TestStructure_Scenarios = "/scenarios/";
        public const string TestStructure_Results = "/testResults/";
        
        public const string TestClients_Root = "/Clients";
        public const string TestClients_Clients = "/";
        public const string TestClients_ClientById = "/{id:int}";
        public static string TestClientRegistrationPoint = TestClients_Root + TestClients_Clients;
        
        public const string TestTasks_Root = "/Tasks";
        public const string TestTasks_CurrentClient = "/{id:int}";
        public const string TestTasks_Task = "/{id:int}";
        // public static string TestTasks_CurrentTask = "/currentTask/{id:int}";
        private const string TestTasks_CurrentTask = "/currentTask";
        public static string CurrentTaskForClientById = TestTasks_Root + TestTasks_CurrentTask;
        public static string CurrentTaskOfCurrentClient = TestTasks_CurrentTask + TestTasks_CurrentClient;
    }
}
