/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/2/2014
 * Time: 8:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Helpers.Control
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    
    /// <summary>
    /// Description of PluginsLoader.
    /// </summary>
    public class PluginsLoader
    {
        string _path;
        
        public PluginsLoader(string path)
        {
            _path = path;
        }
        
        public void Load()
        {
            if (!Directory.Exists(_path)) return;
            try {
                var dir = new DirectoryInfo(_path);
                var files = dir.GetFiles("*.dll");
                if (null == files || !files.Any()) return;
                foreach (var probablyAssembly in files) {
                    try {
                        Assembly.LoadFrom(probablyAssembly.FullName);
                    }
                    catch {}
                }
            }
            catch {}
        }
    }
}
