/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 11:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;
    using Interfaces;
    
    /// <summary>
    /// Description of GetTmxTestConstantValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TmxTestConstantValue")]
    [OutputType(typeof(ITestConstant))]
    public class GetTmxTestConstantValueCommand: TestConstantCmdletBase
    {
    }
}
