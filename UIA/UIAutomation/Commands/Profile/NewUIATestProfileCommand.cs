/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/12/2012
 * Time: 8:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of NewUIATestProfileCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "UIATestProfile")]
    public class NewUIATestProfileCommand : ProfileCmdletBase
    {
        public NewUIATestProfileCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            Profile profile = new Profile(this.Name);
            
            Profile checkProfile = 
                CurrentData.GetProfile(profile.Name);
            
            if (checkProfile == null) {
                CurrentData.Profiles.Add(profile);
                WriteObject(this, profile);
            } else {
                // 20130323
//                ErrorRecord err = 
//                    new ErrorRecord(
//                        new Exception("The profile already exists"),
//                        "ProfileAlreadyExists",
//                        ErrorCategory.InvalidArgument,
//                        profile);
//                err.ErrorDetails = 
//                    new ErrorDetails("The profile already exists");
//                WriteError(this, err, true);
                
                this.WriteError(
                    this,
                    "The profile already exists",
                    "ProfileAlreadyExists",
                    ErrorCategory.InvalidArgument,
                    true);
            }
        }
    }
}
