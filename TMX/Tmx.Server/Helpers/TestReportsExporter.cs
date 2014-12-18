/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2014
 * Time: 6:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server
{
    using System;
    using System.IO;
    using DotLiquid;
    using Nancy.TinyIoc;
    using Tmx.Interfaces.TestStructure;
    using Tmx.Server.Modules;
    
    /// <summary>
    /// Description of TestReportsExporter.
    /// </summary>
    public class TestReportsExporter
    {
        readonly string _basePath;
        
        public TestReportsExporter(string basePath)
        {
            _basePath = basePath;
        }
        
        public virtual string GetReportPage(Guid testRunId, string templateName)
        {
            // dynamic model = TinyIoCContainer.Current.Resolve<ViewsTestRunsModule>().CreateTestRunReportsModel(testRunId);
            var model = TinyIoCContainer.Current.Resolve<ViewsTestRunsModule>().CreateTestRunReportsModel(testRunId);
            
Console.WriteLine("test run id = {0}", testRunId);
            
Console.WriteLine("is model null? {0}", null == model);
            
            var template = getTemplate(templateName);
            
Console.WriteLine("is template null? {0}", null == template);
foreach (ITestSuite suite in model.Suites) {
    Console.WriteLine(suite.Name);
}
            
            return template.Render(Hash.FromAnonymousObject(new { @Model = model }));
        }
        
        Template getTemplate(string templateName)
        {
            Template template;
            
            using (var reader = new StreamReader(_basePath + templateName)) {
                var templateSource = reader.ReadToEnd();
                template = Template.Parse(templateSource);
                reader.Close();
            }
            return template;
        }
    }
}
