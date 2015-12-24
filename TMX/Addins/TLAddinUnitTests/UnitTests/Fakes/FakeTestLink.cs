///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 11/15/2012
// * Time: 5:31 PM
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//
//namespace TlAddinUnitTests
//{
//    using System;
//    using Meyn.TestLink;
//    using Moq;
//    
//    using CookComputing.XmlRpc;
//    
//    /// <summary>
//    /// Description of FakeTestLink.
//    /// </summary>
//    public class FakeTestLink : TestLink
//    {
//        public FakeTestLink(string apiKey, string url) : base (apiKey, url)
//        {
//            // 
////            Console.WriteLine("the constructor with two parameters");
////            Console.WriteLine(apiKey);
////            Console.WriteLine(url);
//            
//            
//        }
//        
//        public FakeTestLink(string apiKey, string url, bool b) : base (apiKey, url, b)
//        {
//            // 
////            Console.WriteLine("the constructor with three parameters");
////            Console.WriteLine(apiKey);
////            Console.WriteLine(url);
////            Console.WriteLine(b.ToString());
//        }
//        
////        public TestLink(string apiKey, string url)
////            : this(apiKey, url, false)
////        {
////        }
////        ///// <summary>
////        ///// default constructor without URL. Uses default localhost url
////        ///// </summary>
////        ///// <param name="apiKey"></param>
////        //public TestLink(string apiKey) : this(apiKey, "", false) { }
////
////        ///// <summary>
////        ///// constructor with debug key
////        ///// </summary>
////        ///// <param name="apiKey"></param>
////        ///// <param name="log">if true then keep last request and last response</param>
////        //public TestLink(string apiKey, bool log): this(apiKey,"",log)
////        //{
////        //}
////        /// <summary>
////        /// constructor with URL and log flag
////        /// </summary>
////        /// <param name="apiKey">developer key as provided by testlink</param>
////        /// <param name="url">url of testlink API. Something like http://localhost/testlink/lib/api/xmlrpc.php </param>
////        /// <param name="log">enable capture of lastRequest and lastResponse for debugging</param>
////        public TestLink(string apiKey, string url, bool log)
////        {
////            devkey = apiKey;
////            proxy = XmlRpcProxyGen.Create<ITestLink>();
////            if (log)
////            {
////                proxy.RequestEvent += new XmlRpcRequestEventHandler(myHandler);
////                proxy.ResponseEvent += new XmlRpcResponseEventHandler(proxy_ResponseEvent);
////            }
////            if ((url != null) && (url != string.Empty))
////                proxy.Url = url;
////        }
//
//    }
//}
