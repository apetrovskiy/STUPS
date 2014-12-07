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
        	// Get[UrnList.TestData_CommonData_relPath] = _ => returnCommonData();
        	Get[UrlList.TestData_CommonData_relPath] = parameters => returnCommonData(parameters.id);
        	
//        	Get[UrnList.TestData_CommonData_relPath + "{key}"] = parameters => {
//        	    string key = parameters.key;
//        	    /*
//        	    Console.WriteLine("requested key: " + key);
//        	    foreach (var k in CommonData.Data.Keys) {
//        	        Console.WriteLine("key: " + k + ", value: " + CommonData.Data[k]);
//        	    }
//        	    */
//        	    return (null == CommonData.Data[key]) ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : Negotiate.WithModel(CommonData.Data[key]).WithStatusCode(HttpStatusCode.OK);
//        	};
        	
        	Get[UrlList.TestData_CommonData_relPath + "{key}"] = parameters => {
        	    var commonData = TestRunQueue.TestRuns.First(testRun => testRun.Id == parameters.id).Data.Data;
        	    string key = parameters.key;
        	    return (null == commonData[key]) ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : Negotiate.WithModel(commonData[key]).WithStatusCode(HttpStatusCode.OK);
        	};
            
            Post[UrlList.TestData_CommonData_relPath] = parameters => {
                var commonDataItem = this.Bind<CommonDataItem>();
                /*
                foreach (var header in Request.Headers) {
                    Console.WriteLine(header.Key);
                    Console.WriteLine(header.Value);
                }
                */
                return addCommonDataItem(commonDataItem, parameters.id);
            };
            
            // TODO: delete
        }
        // TODO: fix it 20141030
        Negotiator returnCommonData(Guid testRunId)
        {
        	var commonData = TestRunQueue.TestRuns.First(testRun => testRun.Id == testRunId).Data.Data;
        	return null != commonData ? Negotiate.WithModel(commonData) : Negotiate.WithStatusCode(HttpStatusCode.NotFound);
        }
        
		HttpStatusCode addCommonDataItem(ICommonDataItem commonDataItem, Guid testRunId)
		{
            TestRunQueue.TestRuns.First(testRun => testRun.Id == testRunId).Data.AddOrUpdateDataItem(commonDataItem);
            return HttpStatusCode.Created;
		}
    }
}
