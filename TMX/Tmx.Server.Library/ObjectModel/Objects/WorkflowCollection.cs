/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/8/2014
 * Time: 9:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Library.ObjectModel.Objects
{
    using System.Collections.Generic;
    using Tmx.Interfaces.Remoting;

    /// <summary>
    /// Description of WorkflowCollection.
    /// </summary>
    public class WorkflowCollection
    {
        public static List<ITestWorkflow> Workflows = new List<ITestWorkflow>();
        
        public static void AddWorkflow(ITestWorkflow workflow)
        {
            Workflows.Add(workflow);
        }
    }
}
