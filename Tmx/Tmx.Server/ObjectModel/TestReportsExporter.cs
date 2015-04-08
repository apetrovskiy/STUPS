/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2014
 * Time: 6:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.ObjectModel
{
    using System;
    using System.IO;
    using DotLiquid;
    using Internal;
    using Modules;
    using Nancy.TinyIoc;

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

        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public virtual string GetReportPage(Guid testRunId, string templateName)
        {
            var model = ServerObjectFactory.Resolve<ViewsTestRunsModule>().CreateTestRunReportsModel(testRunId);
            var template = GetTemplate(templateName);
            return template.Render(Hash.FromAnonymousObject(new { @Model = model }));
        }
        
        Template GetTemplate(string templateName)
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
