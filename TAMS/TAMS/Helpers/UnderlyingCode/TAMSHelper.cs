/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
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
    using Microsoft.Test.ObjectComparison;
    
    /// <summary>
    /// Description of TAMSHelper.
    /// </summary>
    public static class TAMSHelper
    {
        static TAMSHelper()
        {
        }
        
        #region Memory Snapshot
        public static void GetMemoryShapshot(MemorySnapshotCmdletBase cmdlet, int[] processIds)
        {
            if (null != processIds && 0 < processIds.Length) {
                
                foreach (int processId in processIds) {
                    
                    MemorySnapshot snapshot = MemorySnapshot.FromProcess(processId);
                    
                    cmdlet.WriteObject(cmdlet, snapshot);
                }
            }
        }
        #endregion Memory Snapshot
        
        #region Object Comparison
        public static void CompareObjects(ObjectComparisonCmdletBase cmdlet, object referenceObject, object[] differenceObjects)
        {
            // left is null
            
            
            
            
            // right is null
            
            
            
            
            if (null != differenceObjects && 0 < differenceObjects.Length) {
                
                ObjectGraphFactory factory = new PublicPropertyObjectGraphFactory();
                GraphNode referenceGraph = factory.CreateObjectGraph(referenceObject, null);
                
                foreach (var differenceObject in differenceObjects) {
                    
                    GraphNode differenceGraph = factory.CreateObjectGraph(differenceObject, null);
                    ObjectGraphComparer comparer = new ObjectGraphComparer();
                    bool result = comparer.Compare(referenceGraph, differenceGraph);
                    
                    cmdlet.WriteObject(cmdlet, result);
                }
            }
            
        }
        #endregion Object Comparison
    }
}
