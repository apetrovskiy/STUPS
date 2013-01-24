/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 21/02/2012
 * Time: 09:09 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AssertNUnitIsFalseCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Assert, "NUnitIsFalse")]
    //public class AssertNUnitIsFalseCommand : AssertionsCmdletBase
    internal class AssertNUnitIsFalseCommand : AssertionsCmdletBase
    {
        public AssertNUnitIsFalseCommand()
        {
        }
    }
}
