/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/28/2014
 * Time: 2:25 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Web.Modules
{
    using Interfaces.Server;
    using Nancy;

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
