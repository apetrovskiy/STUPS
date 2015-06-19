/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/2/2014
 * Time: 8:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

// namespace Tmx.Server //.ObjectModel.ServerControl
namespace PSTestLib.Helpers
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    /// <summary>
    /// Description of AssembliesLoader.
    /// </summary>
    // TODO: to template method
    public class AssembliesLoader
    {
        // 20150617
        readonly string _path;
        // 20150617
        readonly string _fileNameTemplate;
        readonly bool _recurse;

        // 20150617
        // public AssembliesLoader(string path)
        public AssembliesLoader(string path, string fileNameTemplate, bool recurse)
        {
            _path = path;
            // 20150617
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
                // 20150617
                // var files = dir.GetFiles("*.dll");
                var files = dir.GetFiles(_fileNameTemplate);
                // 20150617
                // if (null == files || !files.Any()) return;
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

                // 20150617
                if (!_recurse) return;
                var subDirs = dir.GetDirectories();
                // 20150617
                // if (null != subDirs && subDirs.Any()) {
                // if (!subDirs.Any()) return;
                if (!subDirs.Any()) return;
                foreach (var subDir in subDirs)
                    RecursivelyLoad(subDir.FullName);
            }
            catch {}
        }
    }
}
