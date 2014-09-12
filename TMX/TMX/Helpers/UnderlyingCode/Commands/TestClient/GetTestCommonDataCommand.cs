/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/12/2014
 * Time: 6:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using Tmx.Core;
    using Tmx.Commands;
    
    /// <summary>
    /// Description of GetTestCommonDataCommand.
    /// </summary>
    class GetTestCommonDataCommand : TmxCommand
    {
        internal GetTestCommonDataCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (GetTmxTestCommonDataCommand)Cmdlet;
            try {
                cmdlet.WriteObject(CommonData.Data[cmdlet.Key]);
            }
            catch (Exception e) {
                throw new Exception("Failed to get value with key '" + cmdlet.Key + "'. " + e.Message);
            }
        }
    }
}
