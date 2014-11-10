/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/3/2014
 * Time: 5:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    using Nancy;
    using Tmx.Interfaces.Server;
    
    /// <summary>
    /// Description of RootPageModule.
    /// </summary>
    public class ViewsRootPageModule : NancyModule
    {
        public ViewsRootPageModule()
        {
            Get[UrnList.ViewRootPage_Root] = _ => View[UrnList.ViewRootPage_RootPageName];
            Get[UrnList.ViewRootPage_ScriptsFolder] = _ => null;
        }
    }
}
