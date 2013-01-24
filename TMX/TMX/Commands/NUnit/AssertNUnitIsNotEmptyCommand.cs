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
    /// Description of AssertNUnitIsNotEmptyCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Assert, "NUnitIsNotEmpty")]
    //public class AssertNUnitIsNotEmptyCommand : AssertionsCmdletBase
    internal class AssertNUnitIsNotEmptyCommand : AssertionsCmdletBase
    {
        public AssertNUnitIsNotEmptyCommand()
        {
        }
    }
}
