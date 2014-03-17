/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/12/2014
 * Time: 8:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Hap.Helpers.Commands.Convert
{
    using System;
	using HtmlAgilityPack;
	using PSTestLib;
	using Hap.Commands;
    
    /// <summary>
    /// Description of ConvertFromTableCommand.
    /// </summary>
    public class ConvertFromTableCommand : HapCommand //: AbstractCommand
    {
        public ConvertFromTableCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet = (ConvertFromHapTableCommand)this.Cmdlet;
            var converter = new FromHtmlNodeToCsvConverter();
            cmdlet.WriteObject(converter.Convert<HtmlNode, SmartString>(cmdlet.InputObject));
        }
    }
}
