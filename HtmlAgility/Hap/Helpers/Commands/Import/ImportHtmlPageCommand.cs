/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/12/2014
 * Time: 7:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Hap.Helpers.Commands.Import
{
    using System;
    using Hap.Commands;
    
	/// <summary>
	/// Description of ImportPageCommand.
	/// </summary>
    public class ImportHtmlPageCommand : HapCommand
	{
        public ImportHtmlPageCommand(CommonCmdletBase cmdlet) : base (cmdlet)
		{
		}
        
        public override void Execute()
        {
            var cmdlet = (ImportHapHtmlPageCommand)this.Cmdlet;
            var data = new PageImporterData { Url = cmdlet.Url, StringInput = cmdlet.InputObject, Path = cmdlet.Path };
            var pageImporter = new PageImporter(data);
            
//            var node = pageImporter.GetFromDataProvided();
//            node.
            
            cmdlet.WriteObject(pageImporter.GetFromDataProvided());
        }
	}
}
