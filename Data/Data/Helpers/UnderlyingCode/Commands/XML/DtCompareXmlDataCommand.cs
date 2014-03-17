/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 8:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data
{
    using System;
    using System.Management.Automation;
	using PSTestLib;
    using Data.Commands;
    
    /// <summary>
    /// Description of DtCompareXmlDataCommand.
    /// </summary>
    internal class DtCompareXmlDataCommand : AbstractCommand
    {
        internal DtCompareXmlDataCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (CompareDtXmlDataCommand)this.Cmdlet;
            
            //XMLHelper.CreateXMLComparer(cmdlet);
        }
    }
}
