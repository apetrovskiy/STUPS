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
        
        private ArrayList getResultArrayList(GetControlCollectionCmdletBase cmdlet, IMySuperWrapper element, AndCondition condition)
        {
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
            
            return resultList;
        }
        
        [Test]
        public void Get0_byControlTypeName()
        {
            // Arrange
            string name = "aaa";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, name, string.Empty, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions((GetControlCmdletBase)cmdlet, "Button", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new MySuperWrapper [] {
//                        FakeFactory.GetAutomationElement(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
//                        FakeFactory.GetAutomationElement(ControlType.Button, "second name", string.Empty, string.Empty, string.Empty),
//                        FakeFactory.GetAutomationElement(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty)
                    }
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(0, resultList);
            Assert.ForAll<IMySuperWrapper>(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.Name == name);
        }
        
        [Test]
        public void Get0of3_byControlTypeName()
        {
            // Arrange
            string name = "aaa";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, name, string.Empty, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions((GetControlCmdletBase)cmdlet, "Button", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, "second name", string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty)
                    }
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(0, resultList);
            Assert.ForAll<IMySuperWrapper>(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.Name == name);
        }
        
        [Test]
        public void Get1of3_byControlTypeName()
        {
            // Arrange
            string name = "aaa";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, name, string.Empty, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions((GetControlCmdletBase)cmdlet, "Button", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty)
                    }
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(1, resultList);
            Assert.ForAll<IMySuperWrapper>(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.Name == name);
        }
        
        [Test]
        public void Get3of3_byControlTypeName()
        {
            // Arrange
            string name = "aaa";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, name, string.Empty, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions((GetControlCmdletBase)cmdlet, "Button", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, string.Empty, string.Empty)
                    }
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(3, resultList);
            Assert.ForAll<IMySuperWrapper>(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.Name == name);
        }

    }
}
