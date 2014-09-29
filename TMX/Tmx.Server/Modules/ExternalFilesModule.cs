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
                
                // need path
                var fileValue = Request.Files.First().Value;
                var fileName = Request.Files.First().Name;
                var actualBytes = new byte[fileValue.Length];
                fileValue.Read(actualBytes, 0, (int)fileValue.Length);
                using (var writer = new BinaryWriter(File.Open(@"E:\20140905\dst\" + fileName, FileMode.Create))) {
                    writer.Write(actualBytes);
                }
                return HttpStatusCode.NoContent;
                
                return HttpStatusCode.NoContent;
            };
        }
    }
}
