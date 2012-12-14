/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/12/2012
 * Time: 8:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetUIATestProfileCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATestProfile")]
    public class GetUIATestProfileCommand : ProfileInputCmdletBase
    {
        public GetUIATestProfileCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            Profile checkProfile = null;
            
            if (this.Name != null &&
                this.Name != string.Empty &&
                this.Name.Length > 0) {
                checkProfile = 
                    CurrentData.GetProfile(this.Name);
            } else if (this.InputObject != null &&
                this.InputObject is Profile) {
                checkProfile = 
                    this.InputObject;
            }
            
            WriteObject(this, checkProfile);
        }
    }
}
