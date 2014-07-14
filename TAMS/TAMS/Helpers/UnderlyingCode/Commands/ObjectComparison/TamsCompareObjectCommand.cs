/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/6/2013
 * Time: 8:00 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TAMS
{
    using System;
    using System.Management.Automation;
    using TAMS.Commands;
    //using System.Collections;
    //using System.Diagnostics;
    
    /// <summary>
    /// Description of TamsCompareObjectCommand.
    /// </summary>
    internal class TamsCompareObjectCommand : TamsCommand
    {
        internal TamsCompareObjectCommand(TAMS.CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (CompareTamsObjectCommand)Cmdlet;
            
            TAMSHelper.CompareObjects(
                cmdlet,
                cmdlet.ReferenceObject,
                cmdlet.DifferenceObject);
        }
    }
}
