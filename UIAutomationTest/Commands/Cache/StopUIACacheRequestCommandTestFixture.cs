/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/12/2012
 * Time: 12:00 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Cache
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of StopUIACacheRequestCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="1")]
    public class StopUIACacheRequestCommandTestFixture
    {
        public StopUIACacheRequestCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.CurrentData]::ResetData());");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
