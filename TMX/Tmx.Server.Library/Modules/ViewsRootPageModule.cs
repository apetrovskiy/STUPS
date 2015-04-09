/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/3/2014
 * Time: 5:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Library.Modules
{
    using Nancy;
    using Tmx.Interfaces.Server;

    /// <summary>
    /// Description of ViewsRootPageModule.
    /// </summary>
    public class ViewsRootPageModule : NancyModule
    {
        public ViewsRootPageModule()
        {
            Get[UrlList.ViewRootPage_Root] = _ => View[UrlList.ViewRootPage_RootPageName];
            Get[UrlList.ViewRootPage_ScriptsFolder] = _ => null;
        }
    }
}
