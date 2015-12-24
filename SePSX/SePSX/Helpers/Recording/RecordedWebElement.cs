/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/7/2012
 * Time: 8:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using PSTestLib;
    using System.Drawing;

    /// <summary>
    /// Description of RecordedElement.
    /// </summary>
    public class RecordedWebElement : IRecordedElementItem //, IRecordedWebElement
    {
        public RecordedWebElement()
        {
            ItemType = RecordingTypes.Element;
            UserData =
                new System.Collections.Generic.Dictionary<string, object>();
        }

        public bool Root { get; set; }
        public bool Final { get; set; }
        public RecordingTypes ItemType { get; set; }
        //public string UserData { get; set; }
        public System.Collections.Generic.Dictionary<string, object> UserData { get; set; }

//        public void aaa() {
//            IWebElement element = null;
//            //element.Size
//        }
        // IWebElement
        public bool Displayed { get; set; }
        public bool Enabled { get; set; }
        public Point Location { get; set; }
        public bool Selected { get; set; }
        public Size Size { get; set; }
        public string TagName { get; set; }
        public string Text { get; set; }
        
        // search properties
        public string Id { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public string CssSelector { get; set; }
        public string XPath { get; set; }
    }
}
