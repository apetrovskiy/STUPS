/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/10/2014
 * Time: 9:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
	using System;
	using Tmx.Core;
	using Tmx.Server;
	using Tmx.Commands;
	
    /// <summary>
    /// Description of AddTestCommonDataCommand.
    /// </summary>
    class AddTestCommonDataCommand : TmxCommand
    {
        internal AddTestCommonDataCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (AddTmxTestCommonDataCommand)Cmdlet;
            try {
                new CommonData();
                CommonData.Data.Add(cmdlet.Key, cmdlet.Value);
                cmdlet.WriteObject(true);
            }
            catch (Exception e) {
                throw new Exception("Failed to add value with name '" + cmdlet.Key + "'. " + e.Message);
            }
        }
    }
}
