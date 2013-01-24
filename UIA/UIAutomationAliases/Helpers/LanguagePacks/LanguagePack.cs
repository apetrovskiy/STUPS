/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/18/2012
 * Time: 4:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationAliases
{
    using System;
    
    /// <summary>
    /// Description of LanguagePack.
    /// </summary>
    //public sealed class LanguagePack : ILanguagePack
    //public class LanguagePack : ILanguagePack
    public class LanguagePack : ILanguagePack
    {
//        private static LanguagePack instance = new LanguagePack();
//        
//        public static LanguagePack Instance {
//            get {
//                return instance;
//            }
//        }
//        
//        private LanguagePack()
//        {
//        }
        
//        static LanguagePack()
//        {
//        }
        
        //public static Instance { set { this = value; } }
        
        public string Button { get {return @"Button";} }
        public string Calendar { get {return @"Calendar";} }
        public string Custom { get {return @"Custom";} }
        public string Edit { get {return @"Edit";} }
    }
}
