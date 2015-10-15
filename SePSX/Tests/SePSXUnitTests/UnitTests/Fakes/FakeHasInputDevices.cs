/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/15/2012
 * Time: 2:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using OpenQA.Selenium;

    /// <summary>
    /// Description of FakeHasInputDevices.
    /// </summary>
    public class FakeHasInputDevices : IHasInputDevices
    {
        public FakeHasInputDevices()
        {
        }
        
        public IMouse Mouse { get; set; }
        public IKeyboard Keyboard { get; set; }
    }
}
