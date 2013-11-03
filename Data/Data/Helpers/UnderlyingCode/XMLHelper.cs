/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 7:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data
{
    using System;
    using System.Management.Automation;
    using System.Collections;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.XPath;
    using System.Linq;
    using System.Linq.Expressions;
    
    using Autofac;
    
    /// <summary>
    /// Description of XMLHelper.
    /// </summary>
    public static class XMLHelper
    {
        public static void CreateXMLComparer(XMLCmdletBase cmdlet)
        {
            cmdlet.WriteVerbose(cmdlet, "creating an XMLComparer object");
            
            List<Autofac.Core.Parameter> listOfParameters =
                new List<Autofac.Core.Parameter>();
            listOfParameters.Add(new NamedParameter("dataEntryCollection", (new List<IXMLDataEntry>())));
            
            IXMLComparer comparer =
                DataFactory.Container.ResolveNamed<IXMLComparer>(
                    "simple",
                    listOfParameters);
            
            cmdlet.WriteVerbose(cmdlet, "An XMLComparer object has been created");

            cmdlet.WriteObject(cmdlet, comparer);
        }
        
        public static void AddDataToXMLComparer(XMLCmdletBase cmdlet, IXMLComparer comparer, string xpath, string value)
        {
            cmdlet.WriteVerbose(cmdlet, "creating a List object");
            
            List<Autofac.Core.Parameter> listOfParameters =
                new List<Autofac.Core.Parameter>();
            listOfParameters.Add(new NamedParameter("xpath", xpath));
            listOfParameters.Add(new NamedParameter("value", value));
            
            cmdlet.WriteVerbose(cmdlet, "creating an XMLDataEntry object");
            
            IXMLDataEntry dataEntry =
                DataFactory.Container.ResolveNamed<IXMLDataEntry>(
                    "full",
                    listOfParameters);
            
            cmdlet.WriteVerbose(cmdlet, "adding an XMLDataEntry object to the comparer");
            
            comparer.DataEntryCollection.Add(dataEntry);
            
            cmdlet.WriteVerbose(cmdlet, "an XMLDataEntry object has been added to the comparer");
            
            cmdlet.WriteObject(cmdlet, comparer);
        }
        
        public static void LoadXMLFile(XMLCmdletBase cmdlet, IXMLComparer comparer, string path)
        {
            bool result = false;
            
            if (System.IO.File.Exists(path)) { // ??
                
                result =
                    comparer.LoadXmlFile(path);
                
            }
            
            if (result) {
                cmdlet.WriteObject(cmdlet, comparer);
            } else {
                cmdlet.WriteError(
                    cmdlet,
                    "Failed to load file '" +
                    path +
                    "'.",
                    "FaileToLoadFile",
                    ErrorCategory.InvalidData,
                    true);
            }
        }
    }
}
