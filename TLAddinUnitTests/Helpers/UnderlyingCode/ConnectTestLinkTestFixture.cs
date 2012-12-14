/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/15/2012
 * Time: 9:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TLAddinUnitTests
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using Moq;
    //using Autofac;
    //using Autofac.Builder;
    using TMX;
    using Meyn.TestLink;
    using CookComputing.XmlRpc;
    
    /// <summary>
    /// Description of ConnectTestLinkTestFixture.
    /// </summary>
    [TestFixture]
    //[Parallelizable]
    public class ConnectTestLinkTestFixture
    {
        public ConnectTestLinkTestFixture()
        {
        }
        
//        private string apiKeyRight = "aaa"; // "56238b86d143acaef5b2175ce840e132";
//        private string apiKeyWrong = "wrong api key";
//        private string urlRight = "http://1.2.3.4/testlink/lib/api/xmlrpc.php";
//        private string urlWrong = "wrong url";
        
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        private void createTestLinkInstance(
           string apiKey,
           string url)
        {
            
            //TLAddinData.CurrentTestLinkConnection = null;

            TLSConnectCmdletBase cmdlet = new TLSConnectCmdletBase();
            cmdlet.Server = url;
            cmdlet.ApiKey = apiKey;
      
#region commented
//            //var testLinkMock = new Mock<TestLink>(apiKey, url);
//            var testLinkMock = new Mock<TestLink>(apiKey, url).As<ITestLinkExtra>();
//            testLinkMock.Setup(t => t.checkDevKey(apiKeyRight)).Returns(true);
//            testLinkMock.Setup(t => t.checkDevKey(apiKeyWrong))
//                .Throws(new TestLinkException("2000:(checkDevKey) - Can not authenticate client: invalid developer key"));
//            testLinkMock.Setup(t => t.checkDevKey(string.Empty))
//                .Throws(new TestLinkException("Devkey is empty. You must supply a development key"));
//            
//            if (urlRight == url) {
//                testLinkMock.Setup(t => t.SayHello()).Returns(() => string.Empty);
//            } else if (urlWrong == url) {
//                testLinkMock.Setup(t => t.SayHello())
//                    .Throws(new UriFormatException("Invalid URI: The format of the URI could not be determined."));
//            } else if (string.Empty == url) {
//                testLinkMock.Setup(t => t.SayHello())
//                    .Throws(new XmlRpcMissingUrl("Proxy XmlRpcUrl attribute or Url property not set."));
//            }
//
//#region experiments
////            TestLink testLink =
////                new FakeTestLink(
////                    cmdlet.ApiKey,
////                    cmdlet.Server);
//            
////            var builder = new ContainerBuilder();
////            builder.RegisterType<TestLink>().As<TestLink>()
////                .WithParameter(
////                    new NamedParameter("apiKey", cmdlet.ApiKey))
////                .WithParameter(
////                    new NamedParameter("url", cmdlet.Server));
////            var container = builder.Build(ContainerBuildOptions.ExcludeDefaultModules);
////            TestLink testLink = container.Resolve<TestLink>();
//#endregion experiments            
//
//            TLHelper.ConnectTestLink(
//                cmdlet,
//                testLinkMock.Object);
#endregion commented

            TLHelper.ConnectTestLink(
                cmdlet,
                FakeTestLinkFactory.GetTestLink(apiKey, url));
        }
        
        [Test] //, Parallelizable]
        public void Server_Empty()
        {
            createTestLinkInstance(
                FakeTestLinkFactory.TestLinkApiKeyRight, 
                string.Empty);
            Assert.IsNull(TLAddinData.CurrentTestLinkConnection);
        }
        
        [Test] //, Parallelizable]
        public void Apikey_Empty()
        {
            createTestLinkInstance(
                string.Empty, 
                FakeTestLinkFactory.TestLinkUrlRight);
            Assert.IsNull(TLAddinData.CurrentTestLinkConnection);
        }
        
        [Test] //, Parallelizable]
        public void Server_Wrong()
        {
            createTestLinkInstance(
                FakeTestLinkFactory.TestLinkApiKeyRight, 
                FakeTestLinkFactory.TestLinkUrlWrong);
            Assert.IsNull(TLAddinData.CurrentTestLinkConnection);
        }
        
        [Test] //, Parallelizable]
        public void Apikey_Wrong()
        {
            createTestLinkInstance(
                FakeTestLinkFactory.TestLinkApiKeyWrong, 
                FakeTestLinkFactory.TestLinkUrlRight);
            Assert.IsNull(TLAddinData.CurrentTestLinkConnection);
        }
        
        [Test] //, Parallelizable]
        public void Apikey_Right_Server_Right()
        {
            createTestLinkInstance(
                FakeTestLinkFactory.TestLinkApiKeyRight, 
                FakeTestLinkFactory.TestLinkUrlRight);
            Assert.IsNotNull(TLAddinData.CurrentTestLinkConnection);
        }
    }
}
