/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 21/02/2012
 * Time: 09:13 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AssertNUnitLessOrEqualCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Assert, "NUnitLessOrEqual")]
    //public class AssertNUnitLessOrEqualCommand : AssertionsCmdletBase
    internal class AssertNUnitLessOrEqualCommand : AssertionsCmdletBase
    {
        public AssertNUnitLessOrEqualCommand()
        {
        }
    }
}
