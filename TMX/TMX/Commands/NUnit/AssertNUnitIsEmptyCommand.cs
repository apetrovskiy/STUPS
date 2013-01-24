/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 21/02/2012
 * Time: 09:11 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AssertNUnitIsEmptyCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Assert, "NUnitIsEmpty")]
    //public class AssertNUnitIsEmptyCommand : AssertionsCmdletBase
    internal class AssertNUnitIsEmptyCommand : AssertionsCmdletBase
    {
        public AssertNUnitIsEmptyCommand()
        {
        }
    }
}
