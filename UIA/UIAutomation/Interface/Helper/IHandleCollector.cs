/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/19/2014
 * Time: 1:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of IHandleCollector.
    /// </summary>
    public interface IHandleCollector
    {
        List<IntPtr> CollectRecursively(IUiElement containerElement, string name, int level);
//        List<IntPtr> Collect(IUiElement containerElement, string name);
        List<IUiElement> GetElementsFromHandles(List<IntPtr> pointers);
    }
}
