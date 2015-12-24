/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/2/2014
 * Time: 8:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

//namespace Tmx.Server //.ObjectModel.ServerControl
//{
//    using System;
//    using System.IO;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Reflection;
//    
//    /// <summary>
//    /// Description of AssembliesLoader.
//    /// </summary>
//    // TODO: to template method
//    public class AssembliesLoader
//    {
//        string _path;
//        
//        public AssembliesLoader(string path)
//        {
//            _path = path;
//        }
//        
//        public void Load()
//        {
//            recursivelyLoad(_path);
//        }
//        
//        void recursivelyLoad(string path)
//        {
//            if (!Directory.Exists(path)) return;
//            try {
//                var dir = new DirectoryInfo(path);
//                var files = dir.GetFiles("*.dll");
//                if (null == files || !files.Any()) return;
//                foreach (var probablyAssembly in files) {
//                    try {
//                        Assembly.LoadFrom(probablyAssembly.FullName);
//                    }
//                    catch {}
//                }
//                
//                var subDirs = dir.GetDirectories();
//                if (null != subDirs && subDirs.Any()) {
//                    foreach (var subDir in subDirs) {
//                        recursivelyLoad(subDir.FullName);
//                    }
//                }
//            }
//            catch {}
//        }
//    }
//}

//namespace Tmx.Server.Library.ObjectModel.ServerControl
//{
//}