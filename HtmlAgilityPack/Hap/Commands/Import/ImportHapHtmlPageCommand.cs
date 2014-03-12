/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/12/2014
 * Time: 7:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Hap.Commands
{
	using System;
	using System.Management.Automation;
    using HtmlAgilityPack;
	using Hap.Helpers.Commands.Import;
	
	/// <summary>
	/// Description of ImportHapPageCommand.
	/// </summary>
	[Cmdlet(VerbsData.Import, "HapHtmlPage")]
    [OutputType(typeof(HtmlNode))]
	public class ImportHapHtmlPageCommand : CommonCmdletBase
	{
		[Parameter(Mandatory = true,
                   ValueFromPipeline = true,
                   ParameterSetName = "FromString")]
        public string InputObject { get; set; }
        
        [Parameter(Mandatory = true,
                   ParameterSetName = "FromFile")]
        public string Path { get; set; }
        
        [Parameter(Mandatory = true,
                   ParameterSetName = "FromWeb")]
        public string Url { get; set; }
		
		protected override void ProcessRecord()
		{
            var command = new ImportHtmlPageCommand(this);
            command.Execute();
		}
	}
}
