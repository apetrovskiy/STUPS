/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/30/2013
 * Time: 4:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    /// <summary>
    /// Description of ClickSettings.
    /// </summary>
    public struct ClickSettings
    {
        public bool RightClick { get; set; }
        public bool MidClick { get; set; }
        public bool Alt { get; set; }
        public bool Shift { get; set; }
        public bool Ctrl { get; set; }
        public bool inSequence { get; set; }
        public bool DoubleClick { get; set; }
        public int DoubleClickInterval { get; set; }
        public int RelativeX { get; set; }
        public int RelativeY { get; set; }
    }
}
