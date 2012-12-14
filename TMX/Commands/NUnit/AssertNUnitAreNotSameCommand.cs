/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 21/02/2012
 * Time: 09:08 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AssertNUnitAreNotSameCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Assert, "NUnitAreNotSame")]
    //public class AssertNUnitAreNotSameCommand : AssertionsCmdletBase
    internal class AssertNUnitAreNotSameCommand : AssertionsCmdletBase
    {
        public AssertNUnitAreNotSameCommand()
        {
        }
    }
}
