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
    using System.Collections.Generic;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of IWorkflow.
    /// </summary>
    public interface IWorkflow
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        Guid TestLabId { get; }
        // void SetTestLab(ITestLab testLab);
    }
}
