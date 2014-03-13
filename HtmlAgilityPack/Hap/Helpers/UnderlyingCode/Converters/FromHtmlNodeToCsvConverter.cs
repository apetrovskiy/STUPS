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
//	using System.Collections;
	using System.Collections.Generic;
    using System.Linq;
//	using HtmlAgilityPack;
    
    /// <summary>
    /// Description of FromHtnlNodeToCsvConverter.
    /// </summary>
    public class FromHtmlNodeToCsvConverter : ConverterTemplate
    {
//        public override IEnumerable<Hashtable> Convert<HtmlNode, Hashtable>(HtmlNode sourceElement)
//        {
//            var result = new Hashtable[] {};
//            
//            return result;
//        }
        
        public override IEnumerable<SmartString> Convert<HtmlNode, SmartString>(HtmlNode sourceElement)
        {
            var result = new SmartString[] {};
            
            // sourceElement.ChildNodes
            var rowItems = (sourceElement as HtmlAgilityPack.HtmlNode).ChildNodes.Where<HtmlAgilityPack.HtmlNode>(headerItem => headerItem.Name == "tr");
            
            foreach (HtmlAgilityPack.HtmlNode rowItem in rowItems) {
                foreach (HtmlAgilityPack.HtmlNode cellItem in rowItem.ChildNodes.Where<HtmlAgilityPack.HtmlNode>(item => item.Name == "td")) {
                    // Console.WriteLine(cellItem.InnerText);
                    Console.WriteLine(cellItem.InnerHtml);
                }
            }
            
            return result;
        }
    }
}
