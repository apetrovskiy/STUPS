/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/6/2013
 * Time: 7:44 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TAMS.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of CompareTamsObjectCommand.
    /// </summary>
    [Cmdlet(VerbsData.Compare, "TamsObject")]
    public class CompareTamsObjectCommand : ObjectComparisonCmdletBase
    {
        public CompareTamsObjectCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true)]
        public object ReferenceObject { get; set; }
        
        [Parameter(Mandatory = true,
                  ValueFromPipeline = true)]
        public object[] DifferenceObject { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            this.CheckCmdletParameters();
            
            TamsCompareObjectCommand command =
                new TamsCompareObjectCommand(this);
            command.Execute();
        }
    }
}
