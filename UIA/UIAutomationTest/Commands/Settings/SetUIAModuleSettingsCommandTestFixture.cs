/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/21/2012
 * Time: 12:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Settings
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;

    /// <summary>
    /// Description of SetUiaModuleSettingsCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Set-UiaModuleSettingsCommand test")]
    //public class SetUiaModuleSettingsCommand
    internal class SetUiaModuleSettingsCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
