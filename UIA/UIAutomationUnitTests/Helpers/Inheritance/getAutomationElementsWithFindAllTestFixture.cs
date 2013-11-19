/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/17/2013
 * Time: 11:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.Inheritance
{
    using System;
    using System.Collections;
    using System.Windows.Automation;
    using PSTestLib;
    using UIAutomation;
    using MbUnit.Framework;
    using NSubstitute;
    using System.Linq;
    using System.Linq.Expressions;
    
    /// <summary>
    /// Description of getAutomationElementsWithFindAllTestFixture.
    /// </summary>
    [TestFixture]
    public class getAutomationElementsWithFindAllTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
            ObjectsFactory.InitUnitTests();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        private IMySuperWrapper getPreparedElement(int childrenCount, Condition condition)
        {
            IMySuperCollection descendants = ObjectsFactory.GetMySuperCollection(true);
            for (int i = 0; i < childrenCount; i++) {
                //descendants.SourceCollection.Add(new MySuperWrapper(AutomationElement.RootElement));
                //descendants.SourceCollection.Add(ObjectsFactory.GetMySuperWrapper(AutomationElement.RootElement));
                
                //var elt = ObjectsFactory.GetMySuperWrapper(AutomationElement.RootElement);
                //descendants.SourceCollection.Add(elt);
            }
            
            IMySuperWrapper element = Substitute.For<IMySuperWrapper>();
            element.FindAll(TreeScope.Descendants, Arg.Any<Condition>()).Returns(descendants);
            return element;
        }
        
        [Test]
        public void InputIsCollectionOfThree()
        {
            //CommonCmdletBase cmdlet = new CommonCmdletBase();
            GetControlCollectionCmdletBase cmdlet = new GetControlCollectionCmdletBase();
            cmdlet.Name = "aaa";
            // 20131118
            // object -> Condition
            AndCondition condition =
            //Condition condition =
                // 20131118
                // object -> Condition
                //cmdlet.GetControlConditions((GetControlCmdletBase)cmdlet, "Button", false, true); // as AndCondition;
                cmdlet.GetControlConditions((GetControlCmdletBase)cmdlet, "Button", false, true) as AndCondition;
            
//            AndCondition condition =
//                new AndCondition(
//                    new PropertyCondition(
//                        AutomationElement.NameProperty,
//                        "aaa"),
//                    new PropertyCondition(
//                        AutomationElement.ClassNameProperty,
//                        "bbb"));
            
            IMySuperWrapper element = getPreparedElement(3, condition);
            
            //GetControlCollectionCmdletBase cmdlet = new GetControlCollectionCmdletBase();
            ArrayList resultList =
                cmdlet.getAutomationElementsWithFindAll(
                    element,
                    "name",
                    "auId",
                    "class",
                    "value",
                    new string[] { "Button", "Text" },
                    condition,
                    false,
                    false,
                    false);
            
            //resultList.any
            //var rrr = resultList.AsQueryable();
            //rrr.Any(x => Console.WriteLine(x));
            //resultList.Any(x => Console.WriteLine(x));
            //resultList.fore
            foreach (IMySuperWrapper nnn in resultList) {
                Console.WriteLine(nnn.Current.ClassName);
            }
        }
        
//        [Test]
//        public void NewInfo()
//        {
//            IMySuperWrapperInformation info =
//                new MySuperWrapperInformation(AutomationElement.RootElement.Current);
//            Console.WriteLine("new Info");
//            Console.WriteLine(info.ClassName);
//            
//            IMySuperWrapper element =
//                ObjectsFactory.GetMySuperWrapper(AutomationElement.RootElement);
//            Console.WriteLine("get element");
//            Console.WriteLine(element.Current.ClassName);
//            
//            IMySuperWrapperInformation info2 =
//                ObjectsFactory.GetMySuperWrapperInformation(AutomationElement.RootElement.Current);
//            Console.WriteLine("new Info");
//            Console.WriteLine(info2.ClassName);
//        }
    }
}
