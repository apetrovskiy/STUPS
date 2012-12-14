/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/18/2012
 * Time: 4:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationAliases
{
    using System;
    
    /// <summary>
    /// Description of LanguagePack_En_US.
    /// </summary>
    public class LanguagePack_En_US : LanguagePack
    {
        public LanguagePack_En_US()
        {
        }
        
        // 20121120
        public new string Button { get {return @"Button";} }
        public new string Calendar { get {return @"Calendar";} }
        public new string Custom { get {return @"Custom";} }
        public new string Edit { get {return @"Edit";} }
    }
}
