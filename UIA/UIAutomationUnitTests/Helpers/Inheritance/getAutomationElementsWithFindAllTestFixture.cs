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
    using System.Collections;
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;
    using System.Linq;
    
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
        
        #region helpers
        private ArrayList getResultArrayList(GetControlCollectionCmdletBase cmdlet, IMySuperWrapper element, Condition condition)
        /*
        private ArrayList getResultArrayList(GetControlCollectionCmdletBase cmdlet, IMySuperWrapper element, AndCondition condition)
        */
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
        #endregion helpers
        
        #region no parameters
        [Test]
        public void Get0_NoParam()
        {
            // Arrange
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(null, string.Empty, string.Empty, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "", false, true) as AndCondition;
                /*
                cmdlet.GetControlConditions((GetControlCmdletBase)cmdlet, "", false, true) as AndCondition;
                */
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new MySuperWrapper [] {
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(0, resultList);
        }
        
        [Test]
        public void Get3of3_NoParam()
        {
            // Arrange
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(null, string.Empty, string.Empty, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "", false, true) as AndCondition;
                /*
                cmdlet.GetControlConditions((GetControlCmdletBase)cmdlet, "", false, true) as AndCondition;
                */
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, "aaa", string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Custom, "bcd", string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.TabItem, "zzz", string.Empty, string.Empty, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(3, resultList);
        }
        #endregion no parameters
        
        #region ControlType
        [Test]
        public void Get0_byControlType()
        {
            // Arrange
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, string.Empty, string.Empty, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "Button", false, true) as AndCondition;
                /*
                cmdlet.GetControlConditions((GetControlCmdletBase)cmdlet, "Button", false, true) as AndCondition;
                */
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new MySuperWrapper [] {
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(0, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ControlType == ControlType.Button);
            /*
            Assert.ForAll<IMySuperWrapper>(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ControlType == ControlType.Button);
            */
        }
        
        [Test]
        public void Get0of3_byControlType()
        {
            // Arrange
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, string.Empty, string.Empty, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "Button", false, true) as AndCondition;
                /*
                cmdlet.GetControlConditions((GetControlCmdletBase)cmdlet, "Button", false, true) as AndCondition;
                */

            //            Condition[] conds = condition.GetConditions();
//            foreach (Condition cond in conds) {
//Console.WriteLine(cond.GetType().Name);
//                try { Console.WriteLine((cond as PropertyCondition).Property.ProgrammaticName + " = " + (cond as PropertyCondition).Value.ToString()); } catch {}
//                try { Console.WriteLine((cond as AndCondition).ToString()); } catch {}
//                try { Console.WriteLine((cond as OrCondition).ToString()); } catch {}
//            }
            
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Calendar, string.Empty, string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.ComboBox, string.Empty, string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Group, string.Empty, string.Empty, string.Empty, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(0, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ControlType == ControlType.Button);
            /*
            Assert.ForAll<IMySuperWrapper>(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ControlType == ControlType.Button);
            */
        }
        
        [Test]
        public void Get1of3_byControlType()
        {
            // Arrange
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, string.Empty, string.Empty, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "Button", false, true) as AndCondition;
            
//            Condition[] conds = condition.GetConditions();
//            foreach (Condition cond in conds) {
//                Console.WriteLine(cond.GetType().Name);
//                try { Console.WriteLine((cond as PropertyCondition).Property.ProgrammaticName + " = " + (cond as PropertyCondition).Value.ToString()); } catch {}
//            }
            
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.DataGrid, string.Empty, string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.DataItem, string.Empty, string.Empty, string.Empty, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(1, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ControlType == ControlType.Button);
        }
        
        [Test]
        public void Get3of3_byControlType()
        {
            // Arrange
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, string.Empty, string.Empty, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "Button", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(3, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ControlType == ControlType.Button);
        }
        #endregion ControlType
        
        #region Name
        [Test]
        public void Get0_byName()
        {
            // Arrange
            const string name = "aaa";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(null, name, string.Empty, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new MySuperWrapper [] {
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(0, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.Name == name);
        }
        
        [Test]
        public void Get0of3_byName()
        {
            // Arrange
            const string name = "aaa";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(null, name, string.Empty, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Custom, "second name", string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.CheckBox, "third name", string.Empty, string.Empty, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(0, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.Name == name);
        }
        
        [Test]
        public void Get1of3_byName()
        {
            // Arrange
            const string name = "aaa";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(null, name, string.Empty, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Tab, "other name", string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Image, name, string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(1, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.Name == name);
        }
        
        [Test]
        public void Get3of3_byName()
        {
            // Arrange
            const string name = "aaa";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(null, name, string.Empty, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Custom, name, string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Hyperlink, name, string.Empty, string.Empty, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(3, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.Name == name);
        }
        #endregion Name
        
        #region AutomationId
        [Test]
        public void Get0_byAutomationId()
        {
            // Arrange
            const string automationId = "aua";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(null, string.Empty, automationId, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new MySuperWrapper [] {
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(0, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.AutomationId == automationId);
        }
        
        [Test]
        public void Get0of3_byAutomationId()
        {
            // Arrange
            const string automationId = "aua";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(null, string.Empty, automationId, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, "au01", string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, "au02", string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, "au03", string.Empty, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(0, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.AutomationId == automationId);
        }
        
        [Test]
        public void Get1of3_byAutomationId()
        {
            // Arrange
            const string automationId = "aua";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(null, string.Empty, automationId, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, "au01", string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, automationId, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, "au03", string.Empty, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(1, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.AutomationId == automationId);
        }
        
        [Test]
        public void Get3of3_byAutomationId()
        {
            // Arrange
            const string automationId = "aua";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(null, string.Empty, automationId, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, automationId, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, automationId, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, automationId, string.Empty, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(3, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.AutomationId == automationId);
        }
        #endregion AutomationId
        
        #region Class
        [Test]
        public void Get0_byClass()
        {
            // Arrange
            string className = "abc";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(null, string.Empty, string.Empty, className, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new MySuperWrapper [] {
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(0, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ClassName == className);
        }
        
        [Test]
        public void Get0of3_byClass()
        {
            // Arrange
            const string className = "abc";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(null, string.Empty, string.Empty, className, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, "first class", string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, "second class", string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, "third class", string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(0, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ClassName == className);
        }
        
        [Test]
        public void Get1of3_byClass()
        {
            // Arrange
            const string className = "abc";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(null, string.Empty, string.Empty, className, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, "first class", string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, className, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, "third class", string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(1, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ClassName == className);
        }
        
        [Test]
        public void Get3of3_byClass()
        {
            // Arrange
            string className = "abc";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(null, string.Empty, string.Empty, className, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, className, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, className, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, className, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(3, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ClassName == className);
        }
        #endregion Class
        
        #region Value
        [Test]
        [Ignore]
        public void Get0_byValue()
        {
            // Arrange
            const string txtValue = "val";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(null, string.Empty, string.Empty, string.Empty, txtValue);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new MySuperWrapper [] {
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(0, resultList);
            Assert.ForAll(
                resultList
                .Cast<IMySuperWrapper>()
                .ToList<IMySuperWrapper>(), x =>
                {
                    ValuePattern valuePattern = x.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                    return valuePattern != null && valuePattern.Current.Value == txtValue;
                });
            /*
            Assert.ForAll(
                resultList
                .Cast<IMySuperWrapper>()
                .ToList<IMySuperWrapper>(), x => (x.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern).Current.Value == txtValue);
            */
        }
        
        [Test]
        [Ignore]
        public void Get0of3_byValue()
        {
            // Arrange
            string txtValue = "val";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(null, string.Empty, string.Empty, string.Empty, txtValue);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, "value1"),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, "value2"),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, "value3")
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(0, resultList);
            Assert.ForAll(
                resultList
                .Cast<IMySuperWrapper>()
                .ToList<IMySuperWrapper>(), x =>
                {
                    ValuePattern valuePattern = x.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                    return valuePattern != null && valuePattern.Current.Value == txtValue;
                });
            /*
            Assert.ForAll(
                resultList
                .Cast<IMySuperWrapper>()
                .ToList<IMySuperWrapper>(), x => (x.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern).Current.Value == txtValue);
            */
        }
        
        [Test]
        [Ignore]
        public void Get1of3_byValue()
        {
            // Arrange
            const string txtValue = "val";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(null, string.Empty, string.Empty, string.Empty, txtValue);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, "value1"),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, txtValue),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, "value3")
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(1, resultList);
            Assert.ForAll(
                resultList
                .Cast<IMySuperWrapper>()
                .ToList<IMySuperWrapper>(), x =>
                {
                    ValuePattern valuePattern = x.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                    return valuePattern != null && valuePattern.Current.Value == txtValue;
                });
            /*
            Assert.ForAll(
                resultList
                .Cast<IMySuperWrapper>()
                .ToList<IMySuperWrapper>(), x => (x.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern).Current.Value == txtValue);
            */
        }
        
        [Test]
        [Ignore]
        public void Get3of3_byValue()
        {
            // Arrange
            string txtValue = "val";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(null, string.Empty, string.Empty, string.Empty, txtValue);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, txtValue),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, txtValue),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, string.Empty, txtValue)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(3, resultList);
            Assert.ForAll(
                resultList
                .Cast<IMySuperWrapper>()
                .ToList<IMySuperWrapper>(), x =>
                {
                    ValuePattern valuePattern = x.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                    return valuePattern != null && valuePattern.Current.Value == txtValue;
                });
            /*
            Assert.ForAll(
                resultList
                .Cast<IMySuperWrapper>()
                .ToList<IMySuperWrapper>(), x => (x.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern).Current.Value == txtValue);
            */
        }
        #endregion Value
        
        #region ControlType + Name
        [Test]
        public void Get0_byControlTypeName()
        {
            // Arrange
            const string name = "aaa";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, name, string.Empty, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "Button", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new MySuperWrapper [] {
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(0, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.Name == name);
        }
        
        [Test]
        public void Get0of4_byControlTypeName()
        {
            // Arrange
            const string name = "aaa";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, name, string.Empty, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "Button", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, "second name", string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.DataGrid, name, string.Empty, string.Empty, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(0, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.Name == name);
        }
        
        [Test]
        public void Get1of4_byControlTypeName()
        {
            // Arrange
            string name = "aaa";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, name, string.Empty, string.Empty, string.Empty);
            AndCondition condition =
                //cmdlet.GetControlConditions((GetControlCmdletBase)cmdlet, "Button", false, true) as AndCondition;
                cmdlet.GetControlConditions(cmdlet, "Button", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, "other name", string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, "third name", string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Group, name, string.Empty, string.Empty, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(1, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.Name == name);
        }
        
        [Test]
        public void Get3of3_byControlTypeName()
        {
            // Arrange
            string name = "aaa";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, name, string.Empty, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "Button", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, name, string.Empty, string.Empty, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(3, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.Name == name);
        }
        #endregion ControlType + Name
        
        #region ControlType + AutomationId
        [Test]
        public void Get0_byControlTypeAutomationId()
        {
            // Arrange
            const string automaitonId = "aua2";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, string.Empty, automaitonId, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "Button", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new MySuperWrapper [] {
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(0, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.AutomationId == automaitonId);
        }
        
        [Test]
        public void Get0of4_byControlTypeAutomationId()
        {
            // Arrange
            const string automaitonId = "aua2";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, string.Empty, automaitonId, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "Button", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, "au01", string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, "au02", string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, "au03", string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Custom, string.Empty, automaitonId, string.Empty, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(0, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.AutomationId == automaitonId);
        }
        
        [Test]
        public void Get1of4_byControlTypeAutomationId()
        {
            // Arrange
            string automaitonId = "aua2";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, string.Empty, automaitonId, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "Button", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, "au01", string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, automaitonId, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, "au03", string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.DataGrid, string.Empty, automaitonId, string.Empty, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(1, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.AutomationId == automaitonId);
        }
        
        [Test]
        public void Get3of3_byControlTypeAutomationId()
        {
            // Arrange
            string automaitonId = "aua2";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, string.Empty, automaitonId, string.Empty, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "Button", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, automaitonId, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, automaitonId, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, automaitonId, string.Empty, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(3, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.AutomationId == automaitonId);
        }
        #endregion ControlType + AutomationId
        
        #region ControlType + Class
        [Test]
        public void Get0_byControlTypeClass()
        {
            // Arrange
            const string className = "aca02";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, string.Empty, string.Empty, className, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "Button", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new MySuperWrapper [] {
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(0, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ClassName == className);
        }
        
        [Test]
        public void Get0of4_byControlTypeClass()
        {
            // Arrange
            const string className = "aca02";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, string.Empty, string.Empty, className, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "Button", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, "cl01", string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, "cl02", string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, "cl03", string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.HeaderItem, string.Empty, string.Empty, className, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(0, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ClassName == className);
        }
        
        [Test]
        public void Get1of4_byControlTypeClass()
        {
            // Arrange
            const string className = "aca02";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, string.Empty, string.Empty, className, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "Button", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, "cl01", string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, className, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, "cl03", string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Document, string.Empty, string.Empty, className, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(1, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ClassName == className);
        }
        
        [Test]
        public void Get3of3_byControlTypeClass()
        {
            // Arrange
            const string className = "aca02";
            var cmdlet =
                FakeFactory.Get_GetControlCollectionCmdletBase(ControlType.Button, string.Empty, string.Empty, className, string.Empty);
            AndCondition condition =
                cmdlet.GetControlConditions(cmdlet, "Button", false, true) as AndCondition;
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    new [] {
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, className, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, className, string.Empty),
                        FakeFactory.GetAutomationElement(ControlType.Button, string.Empty, string.Empty, className, string.Empty)
                    },
                    condition
                   );
            
            // Act
            ArrayList resultList = getResultArrayList(cmdlet, element, condition);
            
            // Assert
            Assert.Count(3, resultList);
            Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ClassName == className);
        }
        #endregion ControlType + Class
        
        #region ControlType + Value
        #endregion ControlType + Value
    }
}
