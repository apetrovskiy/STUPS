/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/26/2012
 * Time: 10:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System.Management.Automation;
    
    // 20120823
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Linq;
    
    /// <summary>
    /// Description of ConvertToUiaHashtableCommand.
    /// </summary>
    [Cmdlet(VerbsData.ConvertTo, "UiaHashtable")]
    public class ConvertToUiaHashtableCommand : ConvertCmdletBase
    {
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }

            foreach (var hashtable in InputObject.Select(inputObject => inputObject.ConvertToHashtable()))
                WriteObject(this, hashtable);
        }
    }
}
