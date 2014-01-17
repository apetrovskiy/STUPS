/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/16/2014
 * Time: 2:40 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    /// <summary>
    /// Description of ExtensionMethods.
    /// </summary>
    public static class ExtensionMethods
    {
        public static System.Collections.Generic.Dictionary<string, object> ConvertHashtableToDictionary(
            this Hashtable hashtable)
        {
            // 20130318
            //System.Collections.Generic.Dictionary<string, string> dict = 
            //    new System.Collections.Generic.Dictionary<string, string>();
            System.Collections.Generic.Dictionary<string, object> dict =
                new System.Collections.Generic.Dictionary<string, object>();
            
            // this.WriteVerbose(this, hashtable.Keys.Count.ToString());
            
            foreach (string key1 in hashtable.Keys) {
                
                string keyUpper = key1.ToUpper();

                // this.WriteVerbose(this, "found key: " + keyUpper);
                
                // 20130318
                //dict.Add(keyUpper, hashtable[key1].ToString());
                // 20130506
                //dict.Add(keyUpper, hashtable[key1]);
                var rawData = hashtable[key1];
                dict.Add(keyUpper, rawData);
                
//                this.WriteVerbose(
//                    this,
//                    "added to the dictionary: " +
//                    keyUpper +
//                    " = " +
//                    dict[keyUpper].ToString());
            }
            
//            foreach (string key2 in hashtable.Keys.Cast<string>().ToList().Any<string>(k => dict.Add(k.ToUpper(), hashtable[k.ToUpper()]))) {
//                
//            }
            
            return dict;
        }
    }
}
