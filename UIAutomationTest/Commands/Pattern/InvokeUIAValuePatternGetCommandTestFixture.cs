/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 11:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Pattern
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUIAValuePatternInvokeCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Invoke-UIAValuePatternInvokeCommand test")]
    public class InvokeUIAValuePatternInvokeCommandTestFixture
    {
        public InvokeUIAValuePatternInvokeCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        // Calendar
        // ComboBox
        // Custom
        // DataItem
        // Edit
        // Hyperlink
        // ListItem
        // ProgressBar
        // Slider
        // Spinner
        // Text
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
