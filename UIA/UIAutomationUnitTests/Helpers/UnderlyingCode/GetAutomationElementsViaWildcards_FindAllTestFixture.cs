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
    using Ninject;
    using Ninject.MockingKernel;
    //using Ninject.MockingKernel.NSubstitute;
    using Ninject.MockingKernel.Moq;
    //using NSubstitute;
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
            
//            kernel.Bind<IMySuperWrapper>().ToMock(); //.WithConstructorArgument("element", ObjectsFactory.GetMySuperWrapper(AutomationElement.RootElement));
//            kernel.Bind<IMySuperCollection>().ToMock();
//            kernel.Bind<IMySuperWrapperInformation>().ToMock();
            
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
        [Ignore("just a probe")]
        public void aaaa()
        {
            GetControlCollectionCmdletBase cmdlet = new GetControlCollectionCmdletBase();
            cmdlet.Timeout = 20;
            cmdlet.AutomationId = "1";
            cmdlet.ControlType = new string[] { "Button" };
            
            var childElementMock = kernel.GetMock<IMySuperWrapper>();
            //MySuperWrapper childElement = childElementMock.Object as MySuperWrapper;
            var childElement = this.kernel.Get<IMySuperWrapper>();
            //childElementMock.SetupProperty(p => p.Current);
            
//                var mockingKernel = new MoqMockingKernel();
//                var serviceMock = mockingKernel.GetMock<IService>();
//                serviceMock.Setup(m => m.GetGreetings()).Returns("World");
//                var sut = mockingKernel.Get<MyClass>();
//                Assert.AreEqual("Hello World", sut.SayHello());   
            
            //IMySuperWrapper element = kernel.GetMock<IMySuperWrapper>().Object;
            var elementMock = this.kernel.GetMock<IMySuperWrapper>();
            //elementMock.SetupProperty(p => p.Current); //..Returns(ObjectsFactory.GetMySuperWrapperInformation(AutomationElement.RootElement.Current));
            
            AndCondition condition =
                new AndCondition(
                    new PropertyCondition(
                        AutomationElement.ClassNameProperty,
                        "aaa"),
                    new PropertyCondition(
                        AutomationElement.HelpTextProperty,
                        "bbb"));
            
            elementMock.Setup(m => m.FindAll(TreeScope.Descendants, condition))
                // 20131119
                //.Returns( new MySuperCollection(new MySuperWrapper[] { (MySuperWrapper)childElement, (MySuperWrapper)childElement, (MySuperWrapper)childElement }));
                .Returns( ObjectsFactory.GetMySuperCollection(new MySuperWrapper[] { (MySuperWrapper)childElement, (MySuperWrapper)childElement, (MySuperWrapper)childElement }));
            
            //var element = elementMock.Object;
            var element = this.kernel.Get<IMySuperWrapper>();
            
            cmdlet.InputObject = new IMySuperWrapper[] { element };
            
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
