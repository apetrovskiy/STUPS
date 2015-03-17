/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/10/2014
 * Time: 10:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Responses.Negotiation;
    using Tmx.Core.Types.Remoting;
    using Tmx.Interfaces.Remoting;
    using Tmx.Interfaces.Server;
    using Tmx.Core;
    
    /// <summary>
    /// Description of TestDataModule.
    /// </summary>
    public class TestDataModule : NancyModule
    {
        public TestDataModule() : base(UrlList.TestData_Root)
        {
            // TODO: fix it 20141030
            Get[UrlList.TestData_CommonData_relPath] = parameters => ReturnCommonData(parameters.id);
            
            Get[UrlList.TestData_CommonData_relPath + "{key}"] = parameters => {
                var commonData = TestRunQueue.TestRuns.First(testRun => testRun.Id == parameters.id).Data.Data;
                string key = parameters.key;
                return (null == commonData[key]) ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : Negotiate.WithModel(commonData[key]).WithStatusCode(HttpStatusCode.OK);
            };
            
            Post[UrlList.TestData_CommonData_relPath] = parameters => {
                var commonDataItem = this.Bind<CommonDataItem>();
                return AddCommonDataItem(commonDataItem, parameters.id);
            };
            
            // TODO: delete
        }
        // TODO: fix it 20141030
        Negotiator ReturnCommonData(Guid testRunId)
        {
            var commonData = TestRunQueue.TestRuns.First(testRun => testRun.Id == testRunId).Data.Data;
            return null != commonData ? Negotiate.WithModel(commonData) : Negotiate.WithStatusCode(HttpStatusCode.NotFound);
        }
        
        HttpStatusCode AddCommonDataItem(ICommonDataItem commonDataItem, Guid testRunId)
        {
            TestRunQueue.TestRuns.First(testRun => testRun.Id == testRunId).Data.AddOrUpdateDataItem(commonDataItem);
            return HttpStatusCode.Created;
        }
    }
}
