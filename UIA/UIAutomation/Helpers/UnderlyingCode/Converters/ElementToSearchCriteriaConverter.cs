/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/5/2014
 * Time: 10:20 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of ElementToSearchCriteriaConverter.
    /// </summary>
    public class ElementToSearchCriteriaConverter : ConverterTemplate
    {
        public override List<Hashtable> Convert<IUiElement, Hashtable>(IEnumerable<IUiElement> elements)
        {
            var resultList = new List<Hashtable>();
            
            return resultList;
        }
    }
}
