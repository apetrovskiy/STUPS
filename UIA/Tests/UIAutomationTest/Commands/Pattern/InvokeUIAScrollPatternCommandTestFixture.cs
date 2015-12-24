/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/20/2012
 * Time: 12:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Pattern
{
    using System;
    using MbUnit.Framework;using NUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUiaScrollPatternCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Invoke-UiaScrollPatternCommand test")]
    public class InvokeUiaScrollPatternCommandTestFixture
    {
        public InvokeUiaScrollPatternCommandTestFixture()
        {
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
