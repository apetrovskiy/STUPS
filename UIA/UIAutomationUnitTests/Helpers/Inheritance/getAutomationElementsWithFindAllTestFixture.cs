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
            FakeFactory.Init();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        [Test]
        public void TestPrototype_InputIsCollectionOfThree()
        {
            string name = "aaa";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, name, string.Empty, string.Empty, string.Empty);
            // 20131118
            // object -> Condition
            AndCondition condition =
            //Condition condition =
                // 20131118
                // object -> Condition
                //cmdlet.GetControlConditions((GetControlCmdletBase)cmdlet, "Button", false, true); // as AndCondition;
                cmdlet.GetControlConditions((GetControlCmdletBase)cmdlet, "Button", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, string.Empty, string.Empty)
                    }
                   );
            
            GetControlCollectionCmdletBase cmdletDerived = new GetControlCollectionCmdletBase();
            
            ArrayList resultList =
                cmdletDerived.getAutomationElementsWithFindAll(
                    element,
                    cmdlet.Name,
                    cmdlet.AutomationId,
                    cmdlet.Class,
                    cmdlet.Value,
                    cmdlet.ControlType,
                    condition,
                    false,
                    false,
                    false);
            
//            if (null == resultList) {
//                Console.WriteLine("null == resultList");
//            } else {
//                if (0 == resultList.Count) {
//                    Console.WriteLine("0 == resultList.Count");
//                }
//            }
//            foreach (IMySuperWrapper nnn in resultList) {
//                Console.WriteLine("finally: " + nnn.Current.Name);
//            }
            
            Assert.ForAll<IMySuperWrapper>(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.Name == name);
        }
    }
}
