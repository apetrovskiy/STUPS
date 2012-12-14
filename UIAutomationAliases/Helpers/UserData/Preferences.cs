/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/18/2012
 * Time: 4:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationAliases
{
    using System;
    using System.Management.Automation;
    
    using System.Reflection;
    using System.Reflection.Emit;
    
    /// <summary>
    /// Description of Preferences.
    /// </summary>
    public static class Preferences
    {
        static Preferences()
        {
        }
        
        public static void SetLanguagePack(LanguagePacks langPackId)
        {
            switch (langPackId) {
                case LanguagePacks.En_US:
                    //Activator.CreateInstance(new System.typ
                    //LanguagePack = (LanguagePack)(new LanguagePack_En_US());
                    break;
                case LanguagePacks.Ru_ru:
                    //LanguagePack.LanguagePack = (LanguagePack)(new LanguagePack_Ru_ru());
                    break;
                default:
                    throw new Exception("Invalid value for LanguagePacks");
            }
        }
        
        public static string temp { get; set; }
    }
    
//    [AttributeUsage (Inherited = True)]
//    Attribute MyCmdletAttribute : CmdletAttribute
//    {
//        string _SpecialName;
//        public string SpecialName
//        { 
//            get { return _SpecialName; }
//            set { _SpecialName = value; }
//        }
//    }
    
//    [System.AttributeUsage(System.AttributeTargets.Class |
//                           System.AttributeTargets.Struct)
//    ]
//    public class Author : CmdletAttribute //System.Attribute
//    {
//        private string name;
//        public double version;
//    
//        public Author(string name)
//        {
//            this.name = name;
//            version = 1.0;
//        }
//    }
}
