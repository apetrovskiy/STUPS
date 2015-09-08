/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/8/2012
 * Time: 3:04 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of RestoreTmxTestResultsCommand.
    /// </summary>
    [Cmdlet(VerbsData.Restore, "TmxTestResults")]
    [OutputType(typeof(bool))]
    public class RestoreTmxTestResultsCommand : TestResultCmdletBase
    {
    }
}
