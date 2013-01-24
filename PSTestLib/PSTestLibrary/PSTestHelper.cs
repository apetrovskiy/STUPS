/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/18/2012
 * Time: 5:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace PSTestLib
{
    /// <summary>
    /// Description of PSTestHelper.
    /// </summary>
    public static class PSTestHelper
    {
        static PSTestHelper()
        {
        }
        
        public static string GetTimedFileName()
        {
            string result = 
                System.DateTime.Now.Year.ToString() +
                System.DateTime.Now.Month.ToString() +
                System.DateTime.Now.Day.ToString() +
                System.DateTime.Now.Hour.ToString() +
                System.DateTime.Now.Minute.ToString() +
                System.DateTime.Now.Second.ToString() +
                System.DateTime.Now.Millisecond.ToString();
            return result;
        }
    }
}
