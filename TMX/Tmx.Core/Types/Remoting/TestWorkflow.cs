/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/8/2014
 * Time: 9:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core.Types.Remoting
{
    using System;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of TestWorkflow.
    /// </summary>
    public class TestWorkflow : IWorkflow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public WorkflowStatuses WorkflowStatus { get; set; }
    }
}
