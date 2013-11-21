/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/18/2012
 * Time: 5:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of PSTestHelper.
    /// </summary>
    public static class PSTestHelper
    {
        static PSTestHelper()
        {
        }
        
        internal static string GetZeroesLine(int desiredLength)
        {
            string result = string.Empty;
            for (int i = 0; i < desiredLength; i++) {
                result += "0";
            }
            return result;
        }
        
        internal static string AddLeadingZeroes(string inputString, int desiredLength)
        {
            if (string.IsNullOrEmpty(inputString)) return GetZeroesLine(desiredLength);
            int neededNumberOfZeroes = desiredLength - inputString.Length;
            if (0 < neededNumberOfZeroes) {
                return (GetZeroesLine(neededNumberOfZeroes) + inputString);
            } else {
                return inputString;
            }
        }
        
        public static string GetTimedFileName()
        {
            string result = 
                AddLeadingZeroes(System.DateTime.Now.Year.ToString(), 4) +
                AddLeadingZeroes(System.DateTime.Now.Month.ToString(), 2) +
                AddLeadingZeroes(System.DateTime.Now.Day.ToString(), 2) +
                AddLeadingZeroes(System.DateTime.Now.Hour.ToString(), 2) +
                AddLeadingZeroes(System.DateTime.Now.Minute.ToString(), 2) +
                AddLeadingZeroes(System.DateTime.Now.Second.ToString(), 2) +
                AddLeadingZeroes(System.DateTime.Now.Millisecond.ToString(), 3);
            return result;
        }
    }
}
