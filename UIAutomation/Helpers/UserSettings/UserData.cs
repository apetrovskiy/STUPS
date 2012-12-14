/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/12/2012
 * Time: 12:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    
    /// <summary>
    /// Description of UserData.
    /// </summary>
    public static class UserData
    {
        //public UserData()
        static UserData()
        {
            UserDictionary = new System.Collections.Generic.Dictionary<string, object>();
        }
        
        public static System.Collections.Generic.Dictionary<string, object> UserDictionary = null;
    }
}
