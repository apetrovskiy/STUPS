/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/14/2014
 * Time: 2:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Helpers.Control
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    /// <summary>
    /// Description of ModulesLoader.
    /// </summary>
    // TODO: to template method
    public class ModulesLoader
    {
        string _path;
        
        public ModulesLoader(string path)
        {
            _path = path;
        }
        
        public void Load()
        {
            if (!Directory.Exists(_path)) return;
            try {
                var dir = new DirectoryInfo(_path);
                var files = dir.GetFiles(@"Nancy*.dll");
                if (null == files || !files.Any()) return;
                Assembly.LoadFrom(_path + @"\Nancy.dll");
                foreach (var probablyAssembly in files) {
Console.WriteLine("loading modules 00007");
                    try {
Console.WriteLine("loading " + probablyAssembly.FullName);
                        Assembly.LoadFrom(probablyAssembly.FullName);
Console.WriteLine("loading modules 00008");
                    }
                    catch (Exception e1) {
Console.WriteLine(e1.Message);
                    }
                }
                
            }
            catch (Exception e2) {
Console.WriteLine(e2.Message);
            }
        }
    }
}
