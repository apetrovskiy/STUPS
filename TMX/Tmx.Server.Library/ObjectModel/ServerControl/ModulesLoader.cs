/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/14/2014
 * Time: 2:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Library.ObjectModel.ServerControl //.ObjectModel.ServerControl
{
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Nancy.Bootstrapper;

    /// <summary>
    /// Description of ModulesLoader.
    /// </summary>
    // TODO: to template method
    public class ModulesLoader
    {
        readonly string _path;
        
        public ModulesLoader(string path)
        {
            _path = path;
        }
        
        public void Load()
        {
            if (!Directory.Exists(_path)) return;
            try {
                var dir = new DirectoryInfo(_path);
                var files = dir.GetFiles(@"Nancy.ViewEngines*.dll");
                // 20150317
                // if (null == files || !files.Any()) return;
                if (!files.Any()) return;
                foreach (var probablyAssembly in files) {
                    try {
                        var assembly = Assembly.LoadFrom(probablyAssembly.FullName);
                        AppDomainAssemblyTypeScanner.AddAssembliesToScan(assembly.FullName);
                    }
                    catch {}
                }
                AppDomainAssemblyTypeScanner.UpdateTypes();
            }
            catch {}
        }
    }
}
