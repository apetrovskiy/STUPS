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
    using Client;
    using Logic.ObjectModel.Objects;
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
            var clientSettings = ClientSettings.Instance;
            clientSettings.ResetData();
            WorkflowCollection.Workflows.Clear();
            TestRunQueue.TestRuns.Clear();
            TestLabCollection.TestLabs.Clear();
            var testLabCollection = new TestLabCollection();
            
            Preferences.ClientRegistrationSleepIntervalMilliseconds = 0;
            Preferences.ReceivingTaskSleepIntervalMilliseconds = 0;
        }
    }
}
