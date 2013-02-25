/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 2/25/2013
 * Time: 7:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of XMLDataEntry.
    /// </summary>
    public class XMLDataEntry : IXMLDataEntry
    {
        public XMLDataEntry(string xpath, string value)
        {
            this.XPath = xpath;
            this.Value = value;
        }
        
        public string XPath { get; set; }
        public string Value { get; set; }
        public XMLComparisonResults Result { get; internal set; }
    }
}
