/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/18/2012
 * Time: 4:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationAliases
{
    using System;
    
    /// <summary>
    /// Description of ILanguagePack.
    /// </summary>
    public interface ILanguagePack
    {
        //LanguagePacks LanguagePack { get; set; }
        
        string Button { get; }
        string Calendar { get; }
        string Custom { get; }
        string Edit { get; }
    }
}
