/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/8/2012
 * Time: 3:04 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of RestoreTMXTestResultsCommand.
    /// </summary>
    [Cmdlet(VerbsData.Restore, "TMXTestResults")]
    [OutputType(typeof(bool))]
    public class RestoreTMXTestResultsCommand : TestResultsCmdletBase
    {
        public RestoreTMXTestResultsCommand()
        {
        }
    }
}
