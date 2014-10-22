/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/17/2014
 * Time: 9:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    using System.Collections.Generic;
    using Nancy;
    using Nancy.ModelBinding;
    
    /// <summary>
    /// Description of GlobalSettingsViewsModule.
    /// </summary>
    public class ViewsGlobalSettingsModule : NancyModule
    {
        public ViewsGlobalSettingsModule() : base("/settings")
        {
            Get["/global.htm"] = parameters => {
                var data = this.Bind<LoginModel>();
                return View["global.htm", data];
            };
            
            Get["/workflow.htm"] = parameters => {
                var listOfPosts = this.Bind<Posts>();
                return View["workflow.htm", listOfPosts];
            };
            
            Get["/list.htm"] = parameters => {
                var users = this.Bind<List<User>>();
                return View["list.htm", users];
            };
        }
    }
    
    public class LoginModel
    {
        public bool RememberMe;
    }
    
    public class Posts
    {
      public string[] Tags;
      public int[] Ints;
    }
    
    public class User
    {
       public string Name;
       public int Commits;
    }
}
