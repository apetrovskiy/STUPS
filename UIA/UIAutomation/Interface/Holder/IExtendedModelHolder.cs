/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/4/2014
 * Time: 1:42 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    
    /// <summary>
    /// Description of IExtendedModelHolder.
    /// </summary>
    public interface IExtendedModelHolder : IHolder
    {
        void SetScope(classic.TreeScope scope);
        classic.TreeScope GetScope();
        // 20140210
        int Seconds { get; set; }
    }
}
