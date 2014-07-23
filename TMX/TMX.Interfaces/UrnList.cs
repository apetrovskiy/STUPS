/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2014
 * Time: 10:15 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server
{
    using System;
    
    /// <summary>
    /// Description of UrnList.
    /// </summary>
    public static class UrnList
    {
        public static string TestStructure_Root = "/Results";
        public static string TestStructure_Suites = "/suites/";
        public static string TestStructure_Scenarios = "/scenarios/";
        
        public static string TestClients_Root = "/Clients";
        public static string TestClients_Clients = "/";
        public static string TestClients_Client = "/{id:int}";
        
        public static string TestTasks_Root = "/Tasks";
        // public static string TestTasks_Current = "/current";
        public static string TestTasks_CurrentClient = "/{id:int}";
        public static string TestTasks_Task = "/{id:int}";
    }
}
