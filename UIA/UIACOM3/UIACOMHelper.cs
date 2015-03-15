/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/18/2012
 * Time: 10:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIACOM3
{
	extern alias UIACOM;
	using System;
	using UIAComWrapperInternal;
	using System.Windows.Automation;
	using System.Windows.Forms;
	
	/// <summary>
	/// Description of UIACOMHelper.
	/// </summary>
	public static class UIACOMHelper
	{
		static UIACOMHelper()
		{
		}
		
        public static System.Windows.Automation.AutomationElement GetAutomationElementFromPoint()
        {
            System.Windows.Automation.AutomationElement result = 
                null;
            try {
                //element = 
                result = 
                    AutomationElement.FromPoint(new System.Windows.Point(
                        Cursor.Position.X, 
                        Cursor.Position.Y));
                //result = element;
            } 
            catch { }
            return result;
        }
	}
}
