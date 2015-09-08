/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/13/2014
 * Time: 9:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting
{
    public enum TestTaskStatuses
    {
        New = 0,
        Running = 1,
        CompletedSuccessfully = 2,
        ExecutionFailed = 3,
        Canceled = 4,
        FailedByTestResults = 5
    }
    
    public enum TestTaskExecutionTypes
    {
        Inline = 0,
        RemoteApp = 1,
        PsRemoting = 2,
        Ssh = 10
    }
    
    public enum TestTaskRuntimeTypes
    {
        Powershell = 0,
        Nunit = 1,
        Mbunit = 2,
        Xunit = 3
    }
    
    public enum ServerControlCommands
    {
        LoadConfiguraiton = 0,
        ResetFull = 1,
        Stop = 2,
        ResetClients = 3,
        ResetAllocatedTasks = 4,
        ResetLoadedTasks = 5,
        ResetWorkflows = 6 // ,
//        ExportTestResults = 7
    }
    
    public enum TestClientStatuses
    {
        Running = 0,
        NoTasks = 1
    }
    
    public enum TestRunStatuses
    {
        Running = 0,
        Pending = 1,
        Scheduled = 2,
        Finished = 3,
        InterruptedOnTaskFailure = 4,
        Cancelled = 5,
        Cancelling = 6,
        InterruptedOnCriticalTask = 7
    }
    
    public enum TestRunStartTypes
    {
        Immediately = 0,
        Scheduled = 1
    }
    
    public enum TestLabStatuses
    {
        Free = 0,
        Busy = 1
    }
}