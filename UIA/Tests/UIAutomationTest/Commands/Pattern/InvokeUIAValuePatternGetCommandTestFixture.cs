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
    /// <summary>
    /// Description of InvokeUiaValuePatternInvokeCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Invoke-UiaValuePatternInvokeCommand test")]
    public class InvokeUiaValuePatternInvokeCommandTestFixture
    {
        public InvokeUiaValuePatternInvokeCommandTestFixture()
        {
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
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
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
