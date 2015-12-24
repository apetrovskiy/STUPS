/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 7:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data
{
    public enum XMLComparisonResults
    {
        /// <summary>
        /// Indicates taht the value to compare equals to data in the file.
        /// </summary>
        Success,
        /// <summary>
        /// Indicates that there is no such an entry an XPath value is provided for.
        /// </summary>
        NoSuchEntry,
        /// <summary>
        /// Indicates that there was an exception raised on accessing an entry in the file.
        /// </summary>
        WrongData,
        /// <summary>
        /// Indicates that there is no such data in an entry XPath led to.
        /// </summary>
        NoSuchData
    }
    
}
