/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/29/2014
 * Time: 6:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Logic.ObjectModel.ServerControl
{
    using System;
    using System.Linq;
    using Nancy;

    /// <summary>
    /// Description of TmxServerRootPathProvider.
    /// </summary>
    public class TmxServerRootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            var serverAssembly = (AppDomain.CurrentDomain.GetAssemblies().First(asm => asm.FullName.Contains("Tmx.Server")));
            return serverAssembly.Location.Substring(0, serverAssembly.Location.LastIndexOf('\\'));
        }
    }
}
