/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/5/2013
 * Time: 10:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests
{
    using System;
    using System.Windows.Automation;
    using PSTestLib;
    using UIAutomation;
    using MbUnit.Framework;
    using Ninject.MockingKernel;
    using Ninject.MockingKernel.NSubstitute;
    using Ninject.MockingKernel.Moq;
    using NSubstitute;
    using Moq;
    
    /// <summary>
    /// Description of GetAutomationElementsViaWildcards_FindAllTestFixture.
    /// </summary>
    [TestFixture]
    public class GetAutomationElementsViaWildcards_FindAllTestFixture
    {
        //private readonly NSubstituteMockingKernel kernel;
        private readonly MoqMockingKernel kernel;
        
        public GetAutomationElementsViaWildcards_FindAllTestFixture()
        {
            //this.kernel = new NSubstituteMockingKernel();
            this.kernel = new MoqMockingKernel();
            
            kernel.Bind<IMySuperWrapper>().ToMock();
            kernel.Bind<IMySuperCollection>().ToMock();
            
//            kernel.Bind(x => x.FromAssembliesMatching("UIAutomation*")
//                            .SelectAllClasses()
//                            .BindDefaultInterfaces());

//            kernel.Bind(x => x.FromAssembliesMatching("UIAutomation*")
//                            .SelectAllClasses()
//                            .BindDefaultInterfaces());

//            kernel.Bind(x => x.FromAssembliesMatching("UIAutomation*")
//                            .SelectAllInterfaces()
//                            .EndingWith("Factory")
//                            .BindToFactory());
        }
        
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [Test]
        public void aaaa()
        {
            GetControlCollectionCmdletBase cmdlet = new GetControlCollectionCmdletBase();
            cmdlet.Timeout = 20;
            cmdlet.AutomationId = "1";
            
            IMySuperWrapper element = kernel.GetMock<IMySuperWrapper>().Object;
            
            AndCondition condition =
                new AndCondition(
                    new PropertyCondition(
                        AutomationElement.ClassNameProperty,
                        "aaa"),
                    new PropertyCondition(
                        AutomationElement.HelpTextProperty,
                        "bbb"));
            
            cmdlet.GetAutomationElementsViaWildcards_FindAll(
                cmdlet,
                element, //IMySuperWrapper inputObject,
                condition, //AndCondition conditions,
                false, //bool caseSensitive,
                false, //bool onlyOneResult,
                false); //bool onlyTopLevel
            
            
Console.WriteLine("000000-0000-0-0001");
            
        }
        
        [TearDown]
        public void TearDown()
        {
            kernel.Reset();
        }
        
//        private GetControlCollectionCmdletBase getClass(
//            
//            string name, string automationId, string )
//        {
//            return new GetControlCollectionCmdletBase();
//        }
//        
//        [Test]
//        [Description("GetControlCollectionCmdletBase.GetAutomationElementsViaWildcards_FindAll(x6)")]
//        [Category("Fast")]
//        public void Nothing_to_compare()
//        {
//            Assert.AreEqual(
//                false,
//                getClass().elementOfPossibleControlType(
//                    null,
//                    null));
//        }
    }
}
