/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/28/2013
 * Time: 12:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Collections;
    
    public interface ISupportsConversion
    {
        Hashtable ConvertToSearchCriteria();
    }
}
