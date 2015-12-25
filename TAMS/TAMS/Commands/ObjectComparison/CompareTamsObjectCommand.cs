/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/6/2013
 * Time: 7:44 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TAMS.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of CompareTamsObjectCommand.
    /// </summary>
    [Cmdlet(VerbsData.Compare, "TamsObject")]
    public class CompareTamsObjectCommand : ObjectComparisonCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        [AllowNull()]
        public object ReferenceObject { get; set; }
        
        [Parameter(Mandatory = true,
                  ValueFromPipeline = true,
                  Position = 1)]
        [AllowNull()]
        public object[] DifferenceObject { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            CheckCmdletParameters();
            
            TamsCompareObjectCommand command =
                new TamsCompareObjectCommand(this);
            command.Execute();
        }
    }
}
