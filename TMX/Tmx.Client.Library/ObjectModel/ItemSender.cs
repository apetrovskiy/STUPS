/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/18/2014
 * Time: 9:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client.Library.ObjectModel
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using Interfaces.Server;
    using Helpers;
    using Spring.Http;
    using Spring.Rest.Client;

    /// <summary>
    /// Description of ItemSender.
    /// </summary>
    public class ItemSender
    {
        readonly IRestOperations _restTemplate;
        
        public ItemSender(RestRequestCreator requestCreator)
        {
            _restTemplate = requestCreator.GetRestTemplate();
        }
        
        public virtual bool SendFileSystemHierarchy(string sourcePath, string destinationPath, bool recurse, bool force)
        {
            if (Directory.Exists(sourcePath))
                return SendHierarchy(sourcePath, destinationPath, recurse, force);
            return File.Exists(sourcePath) && SendSingleFile(sourcePath.Substring(0, sourcePath.LastIndexOf('\\') + 1), sourcePath, destinationPath, force);
        }
        
        bool SendHierarchy(string sourcePath, string destinationPath, bool recurse, bool force)
        {
            // http://msdn.microsoft.com/en-us/library/bb513869.aspx
            var rootDirectory = new DirectoryInfo(sourcePath);
            return WalkIntoDirectory(rootDirectory, sourcePath, destinationPath, force);
        }
        
        bool WalkIntoDirectory(DirectoryInfo rootDirectory, string sourcePath, string destinationPath, bool force)
        {
            var files = GetFiles(rootDirectory);
            if (null != files)
                foreach (var file in files)
                    SendSingleFile(sourcePath, file.FullName, destinationPath, force);
            
            var subDirs = GetSubDirectories(rootDirectory);
            if (null != subDirs)
                foreach (var dir in subDirs)
                    WalkIntoDirectory(dir, sourcePath, destinationPath, force);
            
            return true;
        }
        
        FileInfo[] GetFiles(DirectoryInfo rootDirectory)
        {
            try {
                return rootDirectory.GetFiles("*.*");
            } catch (UnauthorizedAccessException eUnauthorizedAccessFiles) {
                // TODO: AOP
                Trace.TraceError("FileInfo[] getFiles(DirectoryInfo rootDirectory)");
                Trace.TraceError(eUnauthorizedAccessFiles.Message);
                return null;
            } catch (DirectoryNotFoundException eDirectoryNotFoundFiles) {
                // TODO: AOP
                Trace.TraceError("FileInfo[] getFiles(DirectoryInfo rootDirectory)");
                Trace.TraceError(eDirectoryNotFoundFiles.Message);
                return null;
            }
        }
        
        DirectoryInfo[] GetSubDirectories(DirectoryInfo rootDirectory)
        {
            try {
                return rootDirectory.GetDirectories();
            } catch (UnauthorizedAccessException) {
                // TODO: AOP
                Trace.TraceError("DirectoryInfo[] getSubDirectories(DirectoryInfo rootDirectory)");
                return null;
            } catch (DirectoryNotFoundException) {
                // TODO: AOP
                Trace.TraceError("DirectoryInfo[] getSubDirectories(DirectoryInfo rootDirectory)");
                return null;
            }
        }
        
        bool SendSingleFile(string sourceFolderPath, string sourceFilePath, string destinationPath, bool force)
        {
            var fileContentAndPaths = new Dictionary<string, object> {
                { "file", new HttpEntity(new FileInfo(sourceFilePath)) },
                { "relativePath", new HttpEntity(sourceFilePath.Substring(sourceFolderPath.Length)) },
                { "destinationPath", new HttpEntity(destinationPath) }
            };
            var fileUploadResponse = _restTemplate.PostForMessage(UrlList.ExternalFiles_Root + UrlList.ExternalFilesUploadPoint_relPath, fileContentAndPaths);
            return HttpStatusCode.Created == fileUploadResponse.StatusCode;
        }
    }
}
