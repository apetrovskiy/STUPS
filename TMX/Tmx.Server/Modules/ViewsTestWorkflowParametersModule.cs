/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 11/28/2014
 * Time: 2:25 AM
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
    /// Description of ViewsTestWorkflowParametersModule.
    /// </summary>
    public class ViewsTestWorkflowParametersModule : NancyModule
    {
        public ViewsTestWorkflowParametersModule() : base(UrlList.ViewTestWorkflowParameters_Root)
        {
            Get["{parametersPage}"] = parameters => View[parameters.parametersPage];
        }
    }
}
