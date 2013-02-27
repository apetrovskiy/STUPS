/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 6:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of IXMLDataEntry.
    /// </summary>
    public interface IXMLDataEntry
    {
        string XPath { get; set; }
        string Value { get; set; }
        XMLComparisonResults Result { get; }
    }
}
