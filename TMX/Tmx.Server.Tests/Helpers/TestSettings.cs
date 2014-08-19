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
			TaskPool.Tasks.Clear();
			TaskPool.TasksForClients.Clear();
			// ClientSettings.ResetData();
			var clientSettings = ClientSettings.Instance;
			clientSettings.ResetData();
			
			Preferences.ClientRegistrationSleepIntervalMilliseconds = 0;
			Preferences.ReceivingTaskSleepIntervalMilliseconds = 0;
		}
    }
}
