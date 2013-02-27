/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 6:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of IXMLComparer.
    /// </summary>
    public interface IXMLComparer
    {
        List<IXMLDataEntry> DataEntryCollection { get; set; }
        bool LoadXmlFile(string path);
        bool CompareData();
    }
}
