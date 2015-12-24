/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/12/2014
 * Time: 8:39 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    
    /// <summary>
    /// Description of ISupportsCached.
    /// </summary>
    public interface ISupportsCached
    {
        IUiElementInformation Cached { get; }
        IUiElement CachedParent { get; }
        IUiEltCollection CachedChildren { get; }
    }
}
