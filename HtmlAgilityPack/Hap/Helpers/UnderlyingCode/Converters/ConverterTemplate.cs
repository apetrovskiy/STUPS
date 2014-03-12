/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/12/2014
 * Time: 8:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Hap
{
    using System;
	using System.Collections.Generic;
    
    /// <summary>
    /// Description of ConverterTemplate.
    /// </summary>
    public abstract class ConverterTemplate
    {
//        public virtual List<TConvertTo> Convert<TConvertFrom, TConvertTo>(TConvertFrom sourceElement)
//        {
//            var resultList = new List<TConvertTo>();
//            
//            return resultList;
//        }
        
        public virtual IEnumerable<TConvertTo> Convert<TConvertFrom, TConvertTo>(TConvertFrom sourceElement)
        {
            var result = new TConvertTo[] {};
            
            return result;
        }
    }
}
