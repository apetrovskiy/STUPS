/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 21/02/2012
 * Time: 09:07 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AssertNUnitAreNotEqualCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Assert, "NUnitAreNotEqual")]
    //public class AssertNUnitAreNotEqualCommand : AssertionsCmdletBase
    internal class AssertNUnitAreNotEqualCommand : AssertionsCmdletBase
    {
        public AssertNUnitAreNotEqualCommand()
        {
        }
    }
}
