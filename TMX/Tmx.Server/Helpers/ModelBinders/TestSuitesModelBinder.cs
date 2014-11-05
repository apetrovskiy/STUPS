/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/5/2014
 * Time: 5:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Helpers.ModelBinders
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Nancy;
    using Nancy.ModelBinding;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestSuitesModelBinder.
    /// </summary>
    public class TestSuitesModelBinder : IModelBinder
    {
        // object Bind(NancyContext context, Type modelType, object instance, BindingConfig configuration, params string[] blackList);
        // public object Bind(NancyContext context, Type modelType, object instance = null, params string[] blackList)
        public object Bind(NancyContext context, Type modelType, object instance, BindingConfig configuration, params string[] blackList)
        {
            using (var sr = new StreamReader(context.Request.Body))
            {
                var json = sr.ReadToEnd();
                // you now you have the raw json from the request body
                // you can simply deserialize it below or do some custom deserialization
                if (!json.Contains("suites"))
                {
                    var suitesList = new Nancy.Json.JavaScriptSerializer().Deserialize<List<ITestSuite>>(json);
                    return suitesList;
                }
                else
                {
                    return ProcessListOfTestSuites(json);
                }
            }
        }

        public List<ITestSuite> ProcessListOfTestSuites(string json)
        {
            // your implementation here or something
            return new List<ITestSuite>();
        }
        
        // bool CanBind(Type modelType);
        public bool CanBind(Type modelType)
        {
            return modelType == typeof(List<ITestSuite>);
        }
    }
}
