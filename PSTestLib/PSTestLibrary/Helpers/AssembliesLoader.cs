/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/2/2014
 * Time: 8:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib.Helpers
{
    using System.IO;
    using System.Linq;
    using System.Reflection;
    
    /// <summary>
    /// Description of AssembliesLoader.
    /// </summary>
    // TODO: to template method
    public class AssembliesLoader
    {
        readonly string _path;
        readonly string _fileNameTemplate;
        readonly bool _recurse;

        public AssembliesLoader(string path, string fileNameTemplate, bool recurse)
        {
            _path = path;
            _fileNameTemplate = fileNameTemplate;
            _recurse = recurse;
        }
        
        public void Load()
        {
            RecursivelyLoad(_path);
        }
        
        void RecursivelyLoad(string path)
        {
            if (!Directory.Exists(path)) return;
            try {
                var dir = new DirectoryInfo(path);
                var files = dir.GetFiles(_fileNameTemplate);
                if (!files.Any()) return;
                foreach (var probablyAssembly in files)
                    try
                    {
                        Assembly.LoadFrom(probablyAssembly.FullName);
                        // 20150617
                        // AppDomainAssemblyTypeScanner.AddAssembliesToScan(assembly.FullName);
                    }
                    catch
                    {
                    }

                if (!_recurse) return;
                var subDirs = dir.GetDirectories();
                if (!subDirs.Any()) return;
                foreach (var subDir in subDirs)
                    RecursivelyLoad(subDir.FullName);
            }
            catch {}
        }
    }
}
