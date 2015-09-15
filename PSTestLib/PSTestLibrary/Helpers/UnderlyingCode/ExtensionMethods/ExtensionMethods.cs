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
        public static Dictionary<string, object> ConvertHashtableToDictionary(
            this Hashtable hashtable)
        {
            // 20130318
            //System.Collections.Generic.Dictionary<string, string> dict = 
            //    new System.Collections.Generic.Dictionary<string, string>();
            Dictionary<string, object> dict =
                new Dictionary<string, object>();
            
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

        public static string ConvertToString(this Hashtable hashtable)
        {
            var result = String.Empty;
            if (null == hashtable || 0 == hashtable.Count)
                return result;
            result += "@{";
            result = hashtable.Keys.Cast<object>().Aggregate(result, (current, key) => current + (key + "=" + hashtable[key] + ";"));
            result += "}";
            return result;
        }

        public static string ConvertToString(this IEnumerable<Hashtable> hashtables)
        {
            string result = string.Empty;

            var enumerable = hashtables as Hashtable[] ?? hashtables.ToArray();
            if (null == hashtables || !enumerable.Any()) {
                return result;
            }
            
            foreach (Hashtable hashtable in enumerable) {
                result += ",";
                // 20150915
                // result += ConvertHashtableToString(hashtable);
                result += hashtable.ConvertToString();
            }
            
            result = result.Substring(1);
            
            return result;
        }
    }
}
