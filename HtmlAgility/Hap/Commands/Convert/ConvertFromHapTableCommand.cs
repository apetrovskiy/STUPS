/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/12/2014
 * Time: 8:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Hap.Commands
{
    using System;
    using System.Management.Automation;
	using HtmlAgilityPack;
	using Hap.Helpers.Commands.Convert;
    
    /// <summary>
    /// Description of ConvertFromHapTableCommand.
    /// </summary>
    [Cmdlet(VerbsData.ConvertFrom, "HapTable")]
    // [OutputType(typeof
    public class ConvertFromHapTableCommand : CommonCmdletBase
    {
        [Parameter(Mandatory = true,
                   Position = 0,
                   ValueFromPipeline = true)]
        public HtmlNode InputObject { get; set; }
        
        protected override void ProcessRecord()
        {
            var command = new ConvertFromTableCommand(this);
            command.Execute();
        }
    }
}
