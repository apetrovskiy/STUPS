/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/5/2014
 * Time: 10:23 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of ConverterTemplate.
    /// </summary>
    public abstract class ConverterTemplate
    {
        public virtual List<TConvertTo> Convert<TConvertFrom, TConvertTo>(IEnumerable<TConvertFrom> items)
        {
            var resultList = new List<TConvertTo>();
            
            return resultList;
        }
    }
}
