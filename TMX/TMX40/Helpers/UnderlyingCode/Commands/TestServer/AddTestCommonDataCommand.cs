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
	using Tmx.Commands;
	
    /// <summary>
    /// Description of AddTestCommonDataCommand.
    /// </summary>
    class AddCommonDataItemCommand : TmxCommand
    {
        internal AddCommonDataItemCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (AddTmxCommonDataItemCommand)Cmdlet;
            try {
                CommonData.Data.Add(cmdlet.Key, cmdlet.Value);
                cmdlet.WriteObject(true);
            }
            catch (Exception e) {
                throw new Exception("Failed to add value with key '" + cmdlet.Key + "'. " + e.Message);
            }
        }
    }
}
