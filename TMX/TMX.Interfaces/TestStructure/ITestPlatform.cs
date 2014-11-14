/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/25/2013
 * Time: 11:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.TestStructure
{
    using System;
    using System.Xml.Serialization;
	using Tmx.Interfaces.Internal;
    
    /// <summary>
    /// Description of ITestPlatform.
    /// </summary>
    public interface ITestPlatform : ISystemInfo
    {
        [XmlAttribute]
        Guid UniqueId { get; set; }
        [XmlAttribute]
        string Name { get; set; }
        [XmlAttribute]
        string Id { get; set; }
        [XmlAttribute]
        string Description { get; set; }
        
        [XmlAttribute]
        string OperatingSystem { get; set; }
        [XmlAttribute]
        string Version { get; set; }
        [XmlAttribute]
        string Architecture { get; set; }
    }
}
