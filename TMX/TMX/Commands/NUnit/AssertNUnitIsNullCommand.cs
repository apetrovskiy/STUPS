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
    /// Description of AssertNUnitIsNullCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Assert, "NUnitIsNull")]
    //public class AssertNUnitIsNullCommand : AssertionsCmdletBase
    internal class AssertNUnitIsNullCommand : AssertionsCmdletBase
    {
        public AssertNUnitIsNullCommand()
        {
        }
    }
}
