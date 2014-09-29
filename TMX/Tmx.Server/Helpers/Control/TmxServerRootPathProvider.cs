/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/29/2014
 * Time: 6:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Helpers.Control
{
    using System;
    using Nancy;
    
    /// <summary>
    /// Description of TmxServerRootPathProvider.
    /// </summary>
    public class TmxServerRootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            return Environment.CurrentDirectory;
        }
    }
}
