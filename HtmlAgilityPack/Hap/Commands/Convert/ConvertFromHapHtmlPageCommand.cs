/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/13/2014
 * Time: 2:27 PM
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
    /// Description of ConvertFromHapHtmlPageCommand.
    /// </summary>
    [Cmdlet(VerbsData.ConvertFrom, "HapHtmlPage")]
    public class ConvertFromHapHtmlPageCommand : CommonCmdletBase
    {
        public ConvertFromHapHtmlPageCommand()
        {
        }
    }
}
