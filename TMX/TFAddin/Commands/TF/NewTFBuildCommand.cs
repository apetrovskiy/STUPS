/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/9/2013
 * Time: 4:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of NewTFBuildCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TFBuild")]
    public class NewTFBuildCommand : TFBuildCmdletBase
    {
        public NewTFBuildCommand()
        {
        }
    }
}
