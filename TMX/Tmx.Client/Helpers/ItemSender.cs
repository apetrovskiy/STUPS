/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/18/2014
 * Time: 9:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
	using System;
	using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Spring.Http;
	using Spring.Rest.Client;
    using Tmx.Interfaces.Server;
	
    /// <summary>
    /// Description of ItemSender.
    /// </summary>
    public class ItemSender
    {
	    // volatile RestTemplate _restTemplate;
	    readonly RestTemplate _restTemplate;
	    
	    public ItemSender(RestRequestCreator requestCreator)
	    {
	    	_restTemplate = requestCreator.GetRestTemplate();
	    }
	    
	    public virtual bool SendFileSystemHierarchy(string sourcePath, string destinationPath, bool recurse, bool force)
	    {
            if (Directory.Exists(sourcePath))
                return sendHierarchy(sourcePath, destinationPath, recurse, force);
            return File.Exists(sourcePath) && sendSingleFile(sourcePath.Substring(0, sourcePath.LastIndexOf('\\') + 1), sourcePath, destinationPath, force);
	    }
	    
        bool sendHierarchy(string sourcePath, string destinationPath, bool recurse, bool force)
        {
            // http://msdn.microsoft.com/en-us/library/bb513869.aspx
            var rootDirectory = new DirectoryInfo(sourcePath);
            return walkIntoDirectory(rootDirectory, sourcePath, destinationPath, force);
        }
        
        bool walkIntoDirectory(DirectoryInfo rootDirectory, string sourcePath, string destinationPath, bool force)
        {
            var files = getFiles(rootDirectory);
            if (null != files)
                foreach (var file in files)
                    sendSingleFile(sourcePath, file.FullName, destinationPath, force);
            
            var subDirs = getSubDirectories(rootDirectory);
            if (null != subDirs)
                foreach (var dir in subDirs)
                    walkIntoDirectory(dir, sourcePath, destinationPath, force);
            
            return true;
        }
        
        FileInfo[] getFiles(DirectoryInfo rootDirectory)
        {
            try {
                return rootDirectory.GetFiles("*.*");
            } catch (UnauthorizedAccessException eUnauthorizedAccessFiles) {
                return null;
            } catch (DirectoryNotFoundException eDirectoryNotFoundFiles) {
                return null;
            }
        }
        
        DirectoryInfo[] getSubDirectories(DirectoryInfo rootDirectory)
        {
            try {
                return rootDirectory.GetDirectories();
            } catch (UnauthorizedAccessException eUnauthorizedAccessDirs) {
                return null;
            } catch (DirectoryNotFoundException eDirectoryNotFoundDirs) {
                return null;
            }
        }
        
        bool sendSingleFile(string sourceFolderPath, string sourceFilePath, string destinationPath, bool force)
        {
            var fileContentAndPaths = new Dictionary<string, object> {
                { "file", new HttpEntity(new FileInfo(sourceFilePath)) },
                { "relativePath", new HttpEntity(sourceFilePath.Substring(sourceFolderPath.Length)) },
                { "destinationPath", new HttpEntity(destinationPath) }
            };
            var fileUploadResponse = _restTemplate.PostForMessage(UrnList.ExternalFiles_Root + UrnList.ExternalFilesUploadPoint, fileContentAndPaths);
            return HttpStatusCode.Created == fileUploadResponse.StatusCode;
        }
    }
}
