/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/26/2014
 * Time: 10:54 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting
{
    using System;
    
    /// <summary>
    /// Description of ITestWorkflow.
    /// </summary>
    public interface ITestWorkflow : IWorkflow
    {
        void SetTestLab(ITestLab testLab);
        string ParametersPageName { get; set; }
        string Path { get; set; }
        ICommonData DefaultData { get; set; }
        bool IsDefault { get; set; }
    }
}
