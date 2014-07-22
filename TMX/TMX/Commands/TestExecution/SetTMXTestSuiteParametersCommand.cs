/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/16/2013
 * Time: 2:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SetTmxTestSuiteParametersCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "TmxTestSuiteParameters")]
    public class SetTmxTestSuiteParametersCommand : InvokeTmxTestSuiteCommand
    {
        public SetTmxTestSuiteParametersCommand()
        {
            this.OnlySetParameters = true;
        }
    }
}
