/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/15/2012
 * Time: 9:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TlAddinUnitTests
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using Moq;
    //using Autofac;
    //using Autofac.Builder;
    using Tmx;
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

            TLSConnectCmdletBase cmdlet = new TLSConnectCmdletBase();
            cmdlet.Server = url;
            cmdlet.ApiKey = apiKey;
      
            TLHelper.ConnectTestLink(
                cmdlet,
                FakeTestLinkFactory.GetTestLink(apiKey, url));
        }
        
        [Test] //, Parallelizable]
        [Category("Fast")]
        public void Server_Empty()
        {
            createTestLinkInstance(
                FakeTestLinkFactory.TestLinkApiKeyRight, 
                string.Empty);
            Assert.IsNull(TLAddinData.CurrentTestLinkConnection);
        }
        
        [Test] //, Parallelizable]
        [Category("Fast")]
        public void Apikey_Empty()
        {
            createTestLinkInstance(
                string.Empty, 
                FakeTestLinkFactory.TestLinkUrlRight);
            Assert.IsNull(TLAddinData.CurrentTestLinkConnection);
        }
        
        [Test] //, Parallelizable]
        [Category("Fast")]
        public void Server_Wrong()
        {
            createTestLinkInstance(
                FakeTestLinkFactory.TestLinkApiKeyRight, 
                FakeTestLinkFactory.TestLinkUrlWrong);
            Assert.IsNull(TLAddinData.CurrentTestLinkConnection);
        }
        
        [Test] //, Parallelizable]
        [Category("Fast")]
        public void Apikey_Wrong()
        {
            createTestLinkInstance(
                FakeTestLinkFactory.TestLinkApiKeyWrong, 
                FakeTestLinkFactory.TestLinkUrlRight);
            Assert.IsNull(TLAddinData.CurrentTestLinkConnection);
        }
        
        [Test] //, Parallelizable]
        [Category("Fast")]
        public void Apikey_Right_Server_Right()
        {
            createTestLinkInstance(
                FakeTestLinkFactory.TestLinkApiKeyRight, 
                FakeTestLinkFactory.TestLinkUrlRight);
            Assert.IsNotNull(TLAddinData.CurrentTestLinkConnection);
        }
    }
}
