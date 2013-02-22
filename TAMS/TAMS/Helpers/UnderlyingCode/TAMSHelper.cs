/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 2/22/2013
 * Time: 9:57 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TAMS
{
    using System;
    using System.Management.Automation;
    using Microsoft.Test.LeakDetection;
    
    /// <summary>
    /// Description of TAMSHelper.
    /// </summary>
    public static class TAMSHelper
    {
        static TAMSHelper()
        {
        }
        
        public static void GetMemoryShapshot(MemorySnapshotCmdletBase cmdlet, int[] processIds)
        {
            if (null != processIds && 0 < processIds.Length) {
                
                foreach (int processId in processIds) {
                    
                    MemorySnapshot snapshot = MemorySnapshot.FromProcess(processId);
                    
                    cmdlet.WriteObject(cmdlet, snapshot);
                }
            }
        }
    }
}
