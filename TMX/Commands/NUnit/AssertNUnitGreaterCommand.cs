/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 21/02/2012
 * Time: 09:12 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AssertNUnitGreaterCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Assert, "NUnitGreater")]
    //public class AssertNUnitGreaterCommand : AssertionsCmdletBase
    internal class AssertNUnitGreaterCommand : AssertionsCmdletBase
    {
        public AssertNUnitGreaterCommand()
        {
        }
    }
}
