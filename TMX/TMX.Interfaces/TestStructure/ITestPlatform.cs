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
	using Tmx.Interfaces.Internal;
    
    /// <summary>
    /// Description of ITestPlatform.
    /// </summary>
    public interface ITestPlatform : ISystemInfo
    {
        string Name { get; set; }
        string Id { get; set; }
        string Description { get; set; }

        string OperatingSystem { get; set; }
        string Version { get; set; }
        string Architecture { get; set; }
    }
}
