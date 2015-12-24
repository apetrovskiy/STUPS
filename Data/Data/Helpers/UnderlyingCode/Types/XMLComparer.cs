/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 6:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data
{
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of XMLComparer.
    /// </summary>
    public class XMLComparer : IXMLComparer
    {
        public XMLComparer(List<IXMLDataEntry> dataEntryCollection)
        {
            this.DataEntryCollection = dataEntryCollection;
        }
        
        public List<IXMLDataEntry> DataEntryCollection { get; set; }
        public List<IXMLDataEntry> LoadedDataCollection { get; set; }
        
        public bool LoadXmlFile(string path)
        {
            bool result = false;
            
            // check the file's existense
            if (!System.IO.File.Exists(path)) {
                
                return result;
                
            }
            
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
