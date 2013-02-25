/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 2/25/2013
 * Time: 6:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of XMLComparer.
    /// </summary>
    public class XMLComparer : IXMLComparer
    {
        public XMLComparer(List<IXMLDataEntry> xPathCollection)
        {
            this.XPathCollection = xPathCollection;
        }
        
        public List<IXMLDataEntry> XPathCollection { get; set; }
        
        public bool LoadXmlFile(string path)
        {
            bool result = false;
            
            // check the file's existense
            
            
            // read the file data to memory
            
            return result;
        }
        
        public bool CompareData()
        {
            bool result = false;
            
            // comapre XPath collection
            
            return result;
        }
    }
}
