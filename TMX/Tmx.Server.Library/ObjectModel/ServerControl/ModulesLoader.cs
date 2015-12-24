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
        readonly string _fileNameTemplate;
        readonly bool _recurse;
        
        public ModulesLoader(string path, string fileNameTemplate, bool recurse)
        {
            _path = path;
            _fileNameTemplate = fileNameTemplate;
            _recurse = recurse;
        }

        public void Load()
        {
            RecursivelyLoad(_path);
            AppDomainAssemblyTypeScanner.UpdateTypes();
        }

        // public void Load()
        void RecursivelyLoad(string path)
        {
            // 20150826
            // if (!Directory.Exists(_path)) return;
            if (!Directory.Exists(path)) return;
            try {
                // 20150826
                // var dir = new DirectoryInfo(_path);
                var dir = new DirectoryInfo(path);
                // var files = dir.GetFiles(@"Nancy.ViewEngines*.dll");
                var files = dir.GetFiles(_fileNameTemplate);
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
                
                // 20150617
                if (_recurse)
                {
                    var subDirs = dir.GetDirectories();
                    // if (!subDirs.Any()) return;
                    if (subDirs.Any())
                        foreach (var subDir in subDirs)
                            RecursivelyLoad(subDir.FullName);
                }

                // AppDomainAssemblyTypeScanner.UpdateTypes();
            }
            catch {}
        }
    }
}
