/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 21/02/2012
 * Time: 09:10 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AssertNUnitIsNotNullCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Assert, "NUnitIsNotNull")]
    //public class AssertNUnitIsNotNullCommand : AssertionsCmdletBase
    internal class AssertNUnitIsNotNullCommand : AssertionsCmdletBase
    {
        public AssertNUnitIsNotNullCommand()
        {
        }
    }
}
