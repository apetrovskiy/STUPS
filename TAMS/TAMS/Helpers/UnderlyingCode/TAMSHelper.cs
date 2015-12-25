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
    using Microsoft.Test.LeakDetection;
    using Microsoft.Test.ObjectComparison;
    
    /// <summary>
    /// Description of TAMSHelper.
    /// </summary>
    public static class TAMSHelper
    {
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
            if (null == referenceObject) {
                cmdlet.WriteObject(cmdlet, false);
                return;
            }
            
            // right is null
            if (null == differenceObjects) {
                cmdlet.WriteObject(cmdlet, false);
                return;
            }
            
            if (null != differenceObjects && 0 < differenceObjects.Length) {
                
                ObjectGraphFactory factory = new PublicPropertyObjectGraphFactory();
                ObjectGraphFactoryMap map = new ObjectGraphFactoryMap(true);
                GraphNode referenceGraph = factory.CreateObjectGraph(referenceObject, map);
                
                foreach (var differenceObject in differenceObjects) {
                    
                    cmdlet.WriteVerbose(cmdlet, "comparing " + referenceObject + " and " + differenceObject);

                    GraphNode differenceGraph = factory.CreateObjectGraph(differenceObject, map);
                    ObjectGraphComparer comparer = new ObjectGraphComparer();
                    bool result = comparer.Compare(referenceGraph, differenceGraph);
                    
                    cmdlet.WriteObject(cmdlet, result);
                }
            }
        }
        #endregion Object Comparison
    }
}
