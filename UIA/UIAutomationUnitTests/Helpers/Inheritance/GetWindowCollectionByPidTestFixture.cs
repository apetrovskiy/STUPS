/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/28/2014
 * Time: 5:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.Inheritance
{
    using System;
    
    using System.Collections.Generic;
    using System.Windows.Automation;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using MbUnit.Framework;using Xunit;
    using UIAutomation;

    /// <summary>
    /// Description of GetWindowCollectionByPidTestFixture.
    /// </summary>
    [TestFixture]
    public class GetWindowCollectionByPidTestFixture
    {
        public GetWindowCollectionByPidTestFixture()
        {
            FakeFactory.Init();
        }
        
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
        private void TestParametersAgainstCollection(
            IEnumerable<int> processIds,
            IEnumerable<IUiElement> collection,
            int expectedNumberOfElements)
        {
            // Arrange
            IUiElement rootElement =
                FakeFactory.GetElement_ForFindAll(
                    collection,
                    null);
            
            // Act
            List<IUiElement> resultList =
                RealCodeCaller.GetResultList_GetWindowCollectionByPid(
                    rootElement,
                    processIds,
                    false,
                    false,
                    // new[] { string.Empty },
                    null,
                    string.Empty,
                    string.Empty);
            
//if (null == resultList) {
//    Console.WriteLine("null == resultList");
//} else {
//    Console.WriteLine("null != resultList");
//    if (0 == resultList.Count) {
//        Console.WriteLine("0 == resultList.Count");
//    } else {
//        Console.WriteLine("0 != resultList.Count");
//        Console.WriteLine(resultList.Count.ToString());
//    }
//}
            
            // Assert
            MbUnit.Framework.Assert.Count(expectedNumberOfElements, resultList);
            Xunit.Assert.Equal(expectedNumberOfElements, resultList.Count);
//            string[] controlTypeNames;
//            switch (selector) {
//                case UIAutomationUnitTests.Helpers.Inheritance.UsualWildcardRegex.Wildcard:
//                    const WildcardOptions options = WildcardOptions.IgnoreCase;
//                    WildcardPattern namePattern = new WildcardPattern(name, options);
//                    WildcardPattern automationIdPattern = new WildcardPattern(automationId, options);
//                    WildcardPattern classNamePattern = new WildcardPattern(className, options);
//                    WildcardPattern txtValuePattern = new WildcardPattern(txtValue, options);
//                    
//                    if (!string.IsNullOrEmpty(name)) {
//                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => namePattern.IsMatch(x.Current.Name));
//                        resultList.All(x => namePattern.IsMatch(x.Current.Name));
//                    }
//                    if (!string.IsNullOrEmpty(automationId)) {
//                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => automationIdPattern.IsMatch(x.Current.AutomationId));
//                        resultList.All(x => automationIdPattern.IsMatch(x.Current.AutomationId));
//                    }
//                    if (!string.IsNullOrEmpty(className)) {
//                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => classNamePattern.IsMatch(x.Current.ClassName));
//                        resultList.All(x => classNamePattern.IsMatch(x.Current.ClassName));
//                    }
//                    controlTypeNames =
//                        controlTypes.Select(ct => null != ct ? ct.ProgrammaticName.Substring(12) : string.Empty).ToArray();
//                    if (null != controlType) {
//                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => controlTypeNames.Contains(x.Current.ControlType.ProgrammaticName.Substring(12)));
//                        resultList.All(x => controlTypeNames.Contains(x.Current.ControlType.ProgrammaticName.Substring(12)));
//                    }
//                    
//                    if (!string.IsNullOrEmpty(txtValue)) {
//                        MbUnit.Framework.Assert.ForAll(
//                            resultList
//                            .Cast<IUiElement>()
//                            .ToList<IUiElement>(), x =>
//                            {
//                                IValuePattern valuePattern = x.GetCurrentPattern<IValuePattern>(ValuePattern.Pattern) as IValuePattern;
//                                return valuePattern != null && txtValuePattern.IsMatch(valuePattern.Current.Value);
//                            });
//                        
//                        resultList.All(
//                            x => {
//                                IValuePattern valuePattern = x.GetCurrentPattern<IValuePattern>(ValuePattern.Pattern) as IValuePattern;
//                                return valuePattern != null && txtValuePattern.IsMatch(valuePattern.Current.Value);
//                            });
//                    }
//                    break;
//                case UIAutomationUnitTests.Helpers.Inheritance.UsualWildcardRegex.Regex:
//                    if (!string.IsNullOrEmpty(name)) {
//                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => Regex.IsMatch(x.Current.Name, name));
//                        resultList.All(x => Regex.IsMatch(x.Current.Name, name));
//                    }
//                    if (!string.IsNullOrEmpty(automationId)) {
//                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => Regex.IsMatch(x.Current.AutomationId, automationId));
//                        resultList.All(x => Regex.IsMatch(x.Current.AutomationId, automationId));
//                    }
//                    if (!string.IsNullOrEmpty(className)) {
//                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => Regex.IsMatch(x.Current.ClassName, className));
//                        resultList.All(x => Regex.IsMatch(x.Current.ClassName, className));
//                    }
//                    controlTypeNames =
//                        controlTypes.Select(ct => null != ct ? ct.ProgrammaticName.Substring(12) : string.Empty).ToArray();
//                    if (null != controlType) {
//                        MbUnit.Framework.Assert.ForAll(resultList.Cast<IUiElement>().ToList<IUiElement>(), x => controlTypeNames.Contains(x.Current.ControlType.ProgrammaticName.Substring(12)));
//                        resultList.All(x => controlTypeNames.Contains(x.Current.ControlType.ProgrammaticName.Substring(12)));
//                    }
//                    if (!string.IsNullOrEmpty(txtValue)) {
//                        MbUnit.Framework.Assert.ForAll(
//                            resultList
//                            .Cast<IUiElement>()
//                            .ToList<IUiElement>(), x =>
//                            {
//                                IValuePattern valuePattern = x.GetCurrentPattern<IValuePattern>(ValuePattern.Pattern) as IValuePattern;
//                                return valuePattern != null && Regex.IsMatch(valuePattern.Current.Value, txtValue);
//                            });
//                        Xunit.Assert.True(
//                            resultList.All(
//                                x => {
//                                    IValuePattern valuePattern = x.GetCurrentPattern<IValuePattern>(ValuePattern.Pattern) as IValuePattern;
//                                    return valuePattern != null && Regex.IsMatch(valuePattern.Current.Value, txtValue);
//                                })
//                           );
//                    }
//                    break;
//            }
        }
        #endregion helpers
        
        [Test][Fact]
        public void Get0of1()
        {
            // Arrange
            const int pid = 555;
            TestParametersAgainstCollection(
                new[] { pid },
                new IUiElement[] {
                    FakeFactory.GetAutomationElementNotExpected(
                        new ElementData {
                            Current_ProcessId = 1,
                            Current_ControlType = ControlType.Window
                        })
                },
               0);
        }
        
        [Test][Fact]
        public void Get1of1()
        {
            // Arrange
            const int pid = 555;
            TestParametersAgainstCollection(
                new[] { pid },
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(
                        new ElementData {
                            Current_ProcessId = pid,
                            Current_ControlType = ControlType.Window
                        })
                },
               1);
        }
        
        [Test][Fact]
        public void Get0of3()
        {
            // Arrange
            const int pid = 555;
            TestParametersAgainstCollection(
                new[] { pid },
                new IUiElement[] {
                    FakeFactory.GetAutomationElementNotExpected(
                        new ElementData {
                            Current_ProcessId = 2,
                            Current_ControlType = ControlType.Window
                        }),
                    FakeFactory.GetAutomationElementNotExpected(
                        new ElementData {
                            Current_ProcessId = 3,
                            Current_ControlType = ControlType.Window
                        }),
                    FakeFactory.GetAutomationElementNotExpected(
                        new ElementData {
                            Current_ProcessId = 4,
                            Current_ControlType = ControlType.Window
                        })
                },
               0);
        }
        
        [Test][Fact]
        public void Get1of3()
        {
            // Arrange
            const int pid = 555;
            TestParametersAgainstCollection(
                new[] { pid },
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(
                        new ElementData {
                            Current_ProcessId = pid,
                            Current_ControlType = ControlType.Window
                        }),
                    FakeFactory.GetAutomationElementNotExpected(
                        new ElementData {
                            Current_ProcessId = 3,
                            Current_ControlType = ControlType.Window
                        }),
                    FakeFactory.GetAutomationElementNotExpected(
                        new ElementData {
                            Current_ProcessId = 4,
                            Current_ControlType = ControlType.Window
                        })
                },
               1);
        }
        
        [Test][Fact]
        public void Get3of3_TheSamePid()
        {
            // Arrange
            const int pid01 = 111;
            // const int pid02 = 222;
            // const int pid03 = 333;
            TestParametersAgainstCollection(
                new[] { pid01 }, //, pid02, pid03 },
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(
                        new ElementData {
                            Current_ProcessId = pid01,
                            Current_ControlType = ControlType.Window
                        }),
                    FakeFactory.GetAutomationElementExpected(
                        new ElementData {
                            Current_ProcessId = pid01, //pid02,
                            Current_ControlType = ControlType.Window
                        }),
                    FakeFactory.GetAutomationElementExpected(
                        new ElementData {
                            Current_ProcessId = pid01, // pid03,
                            Current_ControlType = ControlType.Window
                        })
                },
               3);
        }
        
        [Test]// [Fact]
        [Ignore]
        public void Get3of3_DifferentPids()
        {
            // Arrange
            const int pid01 = 111;
            const int pid02 = 222;
            const int pid03 = 333;
            TestParametersAgainstCollection(
                new[] { pid01, pid02, pid03 },
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(
                        new ElementData {
                            Current_ProcessId = pid01,
                            Current_ControlType = ControlType.Window
                        }),
                    FakeFactory.GetAutomationElementExpected(
                        new ElementData {
                            Current_ProcessId = pid02,
                            Current_ControlType = ControlType.Window
                        }),
                    FakeFactory.GetAutomationElementExpected(
                        new ElementData {
                            Current_ProcessId = pid03,
                            Current_ControlType = ControlType.Window
                        })
                },
               3);
        }
    }
}
