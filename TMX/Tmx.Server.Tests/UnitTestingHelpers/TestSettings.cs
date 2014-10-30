/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2014
 * Time: 10:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Tests
{
    using System;
	using Tmx.Client;
	using PSTestLib;
    using Tmx.Core;
    
    /// <summary>
    /// Description of TestSettings.
    /// </summary>
    public static class TestSettings
    {
		public static void PrepareModuleTests()
		{
			PSCmdletBase.UnitTestMode = true;
			if (0 < UnitTestOutput.Count)
				UnitTestOutput.Clear();
			TestData.ResetData();
			ClientsCollection.Clients.Clear();
			// 20141015
//			ClientsCollection.MaxUsedClientId = 0;
			TaskPool.Tasks.Clear();
			TaskPool.TasksForClients.Clear();
			// ClientSettings.ResetData();
			var clientSettings = ClientSettings.Instance;
			clientSettings.ResetData();
			// 20141030
			// CommonData.Data.Clear();
			// 20141023
			WorkflowCollection.Workflows.Clear();
			// 20141026
			TestRunQueue.TestRuns.Clear();
			TestLabCollection.TestLabs.Clear();
			var testLabCollection = new TestLabCollection();
			
			Preferences.ClientRegistrationSleepIntervalMilliseconds = 0;
			Preferences.ReceivingTaskSleepIntervalMilliseconds = 0;
		}
    }
}
