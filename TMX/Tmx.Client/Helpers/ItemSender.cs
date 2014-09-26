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
	    
	    public virtual bool SendFileSystemHierarchy(string sourcePath, string destinationPath, bool recurse)
	    {
	        var result = false;
	        
	        // TODO: cycle
	        
	        result = sendSingleFile(sourcePath);
	        
	        return result;
	    }
	    
        bool sendSingleFile(string sourcePath)
        {
            var partsOfFile = new Dictionary<string, object>();
            var fileHttpEntity = new HttpEntity(new FileInfo(sourcePath));
            partsOfFile.Add("file", fileHttpEntity);
            var pathHttpEntity = new HttpEntity(sourcePath.Substring(0, sourcePath.LastIndexOf('\\') + 1));
            partsOfFile.Add("path", pathHttpEntity);
            var fileUploadResponse = _restTemplate.PostForMessage(UrnList.ExternalFiles_Root, partsOfFile);
            return HttpStatusCode.Created == fileUploadResponse.StatusCode;
//                var restTemplate04 = new RestTemplate();
//                var parts04 = new Dictionary<string, object>();
//                var entity04 = new HttpEntity(new FileInfo(args[0]));
//                parts04.Add("data", entity04);
//                
//                var entity041 = new HttpEntity(args[0].Substring(0, args[0].LastIndexOf('\\') + 1));
//                parts04.Add("path", entity041);
//                
//                // HttpResponseMessage result04 = restTemplate04.PostForMessage("http://localhost:12340/probe4/", parts04);
//                HttpResponseMessage result04 = restTemplate04.PostForMessage("http://localhost:12340/probe4/", parts04);
        }
    }
}
