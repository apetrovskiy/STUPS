/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/5/2014
 * Time: 11:01 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of SearchCriteriaToElementConverter.
    /// </summary>
    public class SearchCriteriaToElementConverter : ConverterTemplate
    {
        public override List<IUiElement> Convert<Hashtable, IUiElement>(IEnumerable<Hashtable> hashtables)
        {
            var resultList = new List<IUiElement>();
            
            return resultList;
        }
    }
}
