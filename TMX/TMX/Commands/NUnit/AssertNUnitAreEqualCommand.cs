/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 21/02/2012
 * Time: 09:06 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of AssertNUnitAreEqualCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Assert, "NUnitAreEqual")]
    //public class AssertNUnitAreEqualCommand : AssertionsCmdletBase
    internal class AssertNUnitAreEqualCommand : AssertionsCmdletBase
    {
        public AssertNUnitAreEqualCommand()
        {
        }
    }
}
