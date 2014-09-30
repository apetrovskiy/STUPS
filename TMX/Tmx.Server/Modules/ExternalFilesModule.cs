/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/5/2014
 * Time: 9:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    using System.IO;
    using System.Linq;
	using Nancy;
	using Nancy.ModelBinding;
	using Tmx.Interfaces.Server;
    
    /// <summary>
    /// Description of ExternalFilesModule.
    /// </summary>
    public class ExternalFilesModule : NancyModule
    {
        public ExternalFilesModule() : base(UrnList.ExternalFiles_Root)
        {
            Post[UrnList.ExternalFilesUploadPoint] = _ => {
                var dict = Request.Form.ToDictionary();
                var destinationPath = dict["destinationPath"];
                var relativePath = dict["relativePath"];
                
                if (null == Request.Files || !Request.Files.Any()) return HttpStatusCode.BadRequest;
                var fileValue = Request.Files.First().Value;
                if (null == fileValue) return HttpStatusCode.BadRequest;
                var fileName = Request.Files.First().Name;
                var actualBytes = new byte[fileValue.Length];
                fileValue.Read(actualBytes, 0, (int)fileValue.Length);
                writeFile(destinationPath, relativePath, actualBytes);
                return HttpStatusCode.NoContent;
            };
        }

        void writeFile(string destinationPath, string relativePath, byte[] actualBytes)
        {
            var subDirPath = destinationPath + '\\' + relativePath;
            subDirPath = subDirPath.Substring(0, subDirPath.LastIndexOf('\\'));
            try {
                Directory.CreateDirectory(subDirPath);
            }
            catch {}
            
            using (var writer = new BinaryWriter(File.Open(destinationPath + '\\' + relativePath, FileMode.Create))) {
                writer.Write(actualBytes);
            }
        }
    }
}
