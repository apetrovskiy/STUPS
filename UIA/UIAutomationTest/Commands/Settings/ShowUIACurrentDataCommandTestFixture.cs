/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/1/2012
 * Time: 8:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Settings
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;

    /// <summary>
    /// Description of ShowUiaCurrentDataCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Set-UiaCurrentDataCommand test")]
    public class ShowUiaCurrentDataCommandTestFixture
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
