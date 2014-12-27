/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/6/2013
 * Time: 2:00 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    
    public interface IUiEltCollection : ICollection, IEnumerable, IDisposable
    {
        List<IUiElement> SourceCollection { get; }
        IUiElement this[int index] { get; }
        IUiEltCollection this[string infoString] { get; }
    }
}
