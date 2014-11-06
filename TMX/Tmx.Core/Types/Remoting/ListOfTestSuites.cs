/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/6/2014
 * Time: 2:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core.Types.Remoting
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;
    using Tmx.Interfaces;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of ListOfTestSuites.
    /// </summary>
    public class ListOfTestSuites : List<ITestSuite>, IXmlSerializable
    {
        public ListOfTestSuites() : base() { }
        
        public System.Xml.Schema.XmlSchema GetSchema() { return null; }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("suites");
            while (reader.IsStartElement("suite"))
            {
                Type type = Type.GetType(reader.GetAttribute("AssemblyQualifiedName"));
                var serial = new XmlSerializer(type);

                reader.ReadStartElement("suite");
                this.Add((ITestSuite)serial.Deserialize(reader));
                reader.ReadEndElement(); //ITestSuite
            }
            reader.ReadEndElement(); //suites
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (ITestSuite suite in this)
            {
                writer.WriteStartElement("suite");
                writer.WriteAttributeString("AssemblyQualifiedName", suite.GetType().AssemblyQualifiedName);
                var xmlSerializer = new XmlSerializer(suite.GetType());
                xmlSerializer.Serialize(writer, suite);
                writer.WriteEndElement();
            }
        }
    }
}
