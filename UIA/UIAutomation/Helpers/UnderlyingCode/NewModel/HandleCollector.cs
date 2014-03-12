/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/18/2014
 * Time: 10:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
//    using System.Windows.Automation;
//    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
//    using System.Management.Automation;
//    using PSTestLib;
    
//    using System.Globalization;
//    using System.Threading;
//    using System.Windows.Forms;
//    using System.Text.RegularExpressions;
    
    /// <summary>
    /// Description of HandleCollector.
    /// </summary>
    public class HandleCollector : IHandleCollector
    {
        public virtual List<IntPtr> CollectRecursively(
            IUiElement containerElement,
            string name,
            int level)
        {
            var resultHandle = IntPtr.Zero;
            var controlHandle = IntPtr.Zero;
            var controlHandles = new List<IntPtr>();
            var tempControlHandles = new List<IntPtr>();
            // 20140312
            // var containerHandle = new IntPtr(containerElement.Current.NativeWindowHandle);
            var containerHandle = new IntPtr(containerElement.GetCurrent().NativeWindowHandle);
            
            if (containerHandle == IntPtr.Zero) return controlHandles;
            
            // search at this level
            do {
                // using null instead of name
                controlHandle =
                    NativeMethods.FindWindowEx(containerHandle, controlHandle, null, null);
                
                if (controlHandle == IntPtr.Zero) continue;
                controlHandles.Add(controlHandle);
                
                tempControlHandles =
                    CollectRecursively(
                        UiElement.FromHandle(controlHandle),
                        name,
                        level + 1);
                
                if (null == tempControlHandles || 0 == tempControlHandles.Count) continue;
                controlHandles.AddRange(tempControlHandles);
                
            } while (controlHandle != IntPtr.Zero);
            
            return controlHandles;
        }
        
        public virtual List<IUiElement> GetElementsFromHandles(List<IntPtr> pointers)
        {
            return (from pointer in pointers where IntPtr.Zero != pointer select UiElement.FromHandle(pointer)).ToList();
        }
    }
}
