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
    using System.Linq;
    using System.Management.Automation;
    using Tmx.Client;
    using Tmx.Core;
    using Tmx.Commands;
    
    /// <summary>
    /// Description of GetTestCommonDataCommand.
    /// </summary>
    // TODO: fix it 20141030
    class GetCommonDataItemCommand : TmxCommand
    {
        internal GetCommonDataItemCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (GetTmxCommonDataItemCommand)Cmdlet;
            try {
                // cmdlet.WriteObject(ClientSettings.Instance.CommonData.Data[cmdlet.Key]);
                const WildcardOptions options = WildcardOptions.IgnoreCase | WildcardOptions.Compiled;
                var pattern = new WildcardPattern(cmdlet.Key, options);
                
                ClientSettings.Instance.CommonData.Data.Keys
                    // .Where(key => pattern.IsMatch(key))
                    .Where(pattern.IsMatch)
                    .ToList()
                    .ForEach(key => cmdlet.WriteObject(ClientSettings.Instance.CommonData.Data[key]));
            }
            catch (Exception e) {
                throw new Exception("Failed to get value with key '" + cmdlet.Key + "'. " + e.Message);
            }
        }
    }
}
