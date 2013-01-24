/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/15/2012
 * Time: 7:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using Meyn.TestLink;
    
    /// <summary>
    /// Description of TestLinkFactory.
    /// </summary>
    public static class TestLinkFactory
    {
//        public TestLinkFactory()
//        {
//        }
        
//        public static TestLink GetTestLinkInstance(
//            TLSConnectCmdletBase cmdlet) //,
//            //string url,
//            //string apikey)
//        {
//            
//            string url = 
//                "http://" +
//                cmdlet.Server +
//                "/testlink/lib/api/xmlrpc.php";
//            
//            string apikey = cmdlet.ApiKey;
//            
//            if (null == url || string.Empty == url) {
//                cmdlet.WriteVerbose(cmdlet, "Wrong parameter: Server");
//                return null;
//            }
//            
//            if (null == apikey || string.Empty == apikey) {
//                cmdlet.WriteVerbose(cmdlet, "Wrong parameter: Apikey");
//                return null;
//            }
//            
//            try {
//                
//                cmdlet.WriteVerbose(cmdlet, "Trying to connect to " + url);
//                
//                TestLink testLink =
//                    new TestLink(
//                        apikey,
//                        url);
//                
//                cmdlet.WriteVerbose(cmdlet, "testing the availability of TestLink");
//                testLink.SayHello();
//                
//                cmdlet.WriteVerbose(cmdlet, "testing the api key");
//                testLink.checkDevKey(apikey);
//                
//                return testLink;
//                
//            }
//            catch (UriFormatException eUriFormat) {
//                cmdlet.WriteVerbose(cmdlet, "Wrong Uri: " + eUriFormat.Message);
//                return null;
//            }
//            catch (TestLinkException eTestLinkNative) {
//                cmdlet.WriteVerbose(cmdlet, "Wrong Apikey: " + eTestLinkNative.Message);
//                return null;
//            }
//            catch (Exception eTestLInk) {
//                cmdlet.WriteVerbose(cmdlet, "Something went wrong: " + eTestLInk.Message);
//                return null;
//            }
//        }
    }
}
