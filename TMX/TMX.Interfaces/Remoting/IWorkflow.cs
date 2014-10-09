/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/8/2014
 * Time: 9:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting
{
    using System;
    
    /// <summary>
    /// Description of IWorkflow.
    /// </summary>
    public interface IWorkflow
    {
        int Id { get; set; }
        string Name { get; set; }
        WorkflowStatuses WorkflowStatus { get; set; }
    }
}
