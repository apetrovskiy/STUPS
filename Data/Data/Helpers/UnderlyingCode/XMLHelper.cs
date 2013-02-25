/*
 * Created by SharpDevelop.
 * User: APetrovsky
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
    
    using Autofac;
    
    /// <summary>
    /// Description of XMLHelper.
    /// </summary>
    public static class XMLHelper
    {
        static XMLHelper()
        {
        }
        
        public static void CreateXMLComparer(XMLCmdletBase cmdlet)
        {
            cmdlet.WriteVerbose(cmdlet, "creating an XMLComparer object");
            
            List<Autofac.Core.Parameter> listOfParameters =
                new List<Autofac.Core.Parameter>();
            listOfParameters.Add(new NamedParameter("xPathCollection", (new List<IXMLDataEntry>())));
            
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
            
            comparer.XPathCollection.Add(dataEntry);
            
            cmdlet.WriteVerbose(cmdlet, "an XMLDataEntry object has been added to the comparer");
            
            cmdlet.WriteObject(cmdlet, comparer);
        }
    }
}
