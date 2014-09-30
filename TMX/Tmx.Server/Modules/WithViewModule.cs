/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 9/30/2014
 * Time: 8:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    using Nancy;
    using Nancy.ModelBinding;
    
    /// <summary>
    /// Description of WithViewModule.
    /// </summary>
    public class WithViewModule : NancyModule
    {
        public WithViewModule() : base("/probe")
        {
            Get["/"] = parameters => {
                // return @"<html><head></head><body>Hello there @Model</body></html>";
                return View["test.htm"];
            };
        }
    }
}
