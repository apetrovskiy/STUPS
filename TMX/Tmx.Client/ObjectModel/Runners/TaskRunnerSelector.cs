/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/11/2014
 * Time: 6:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client.ObjectModel.Runners
{
    using System;
    using Tmx.Interfaces.Remoting;
    using Tmx.Client.ObjectModel;
    using Tmx.Client.ObjectModel.Runners;
    
    /// <summary>
    /// Description of TaskRunnerSelector.
    /// </summary>
    public class TaskRunnerSelector
    {
        public IRunnableClient GetRunnableClient(TestTaskRuntimeTypes runtimeType)
        {
            switch (runtimeType) {
                case TestTaskRuntimeTypes.Powershell:
                    return new PowerShellTaskRunner();
                case TestTaskRuntimeTypes.Nunit:
                    return new NunitTaskRunner();
                case TestTaskRuntimeTypes.Xunit:
                    return new XunitTaskRunner();
                case TestTaskRuntimeTypes.Mbunit:
                    return new MbUnitTaskRunner();
                default:
                    // return null; // ??
                    // 20141211
	               // temporary
	               // TODO: change the behavior
	               return new PowerShellTaskRunner();
            }
        }
    }
}
