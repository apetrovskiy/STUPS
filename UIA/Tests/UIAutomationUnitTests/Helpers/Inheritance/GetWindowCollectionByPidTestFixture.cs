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
    using System.Collections.Generic;
    using System.Windows.Automation;
    using System.Linq;
    using Xunit;
    using UIAutomation;

    /// <summary>
    /// Description of GetWindowCollectionByPidTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class GetWindowCollectionByPidTestFixture
    {
        public GetWindowCollectionByPidTestFixture()
        {
            FakeFactory.Init();
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
        }
        
        #region helpers
        private void TestParametersAgainstCollection(
            IEnumerable<int> processIds,
            IEnumerable<string> names,
            string automationId,
            string className,
            IEnumerable<IUiElement> collection,
            int expectedNumberOfElements)
        {
            // Arrange
            IUiElement rootElement =
                FakeFactory.GetElement_ForFindAll(
                    collection,
                    null);
            
            var windowSearcherData =
                new WindowSearcherData {
                ProcessIds = processIds.ToArray(),
                Name = new[] { string.Empty },
                AutomationId = automationId,
                Class = className,
                First = false,
                Recurse = false
            };
            
            // Act
            List<IUiElement> resultList =
                RealCodeCaller.GetResultList_GetWindowCollectionByPid(
                    rootElement,
                    windowSearcherData);
            
            // Assert
            MbUnit.Framework.Assert.Count(expectedNumberOfElements, resultList);
            Assert.Equal(expectedNumberOfElements, resultList.Count);
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
        
        #region no recursion
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0of1_NoRecurison()
        {
            // Arrange
            const int pid = 555;
            TestParametersAgainstCollection(
                new[] { pid },
                null,
                string.Empty,
                string.Empty,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementNotExpected(
                        new ElementData {
                            Current_ProcessId = 1,
                            Current_ControlType = ControlType.Window
                        })
                },
               0);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get1of1_NoRecurison()
        {
            // Arrange
            const int pid = 555;
            TestParametersAgainstCollection(
                new[] { pid },
                null,
                string.Empty,
                string.Empty,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(
                        new ElementData {
                            Current_ProcessId = pid,
                            Current_ControlType = ControlType.Window
                        })
                },
               1);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0of3_NoRecurison()
        {
            // Arrange
            const int pid = 555;
            TestParametersAgainstCollection(
                new[] { pid },
                null,
                string.Empty,
                string.Empty,
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
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get1of3_NoRecurison()
        {
            // Arrange
            const int pid = 555;
            TestParametersAgainstCollection(
                new[] { pid },
                null,
                string.Empty,
                string.Empty,
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
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get3of3_NoRecurison_TheSamePid()
        {
            // Arrange
            const int pid01 = 111;
            TestParametersAgainstCollection(
                new[] { pid01 },
                null,
                string.Empty,
                string.Empty,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(
                        new ElementData {
                            Current_ProcessId = pid01,
                            Current_ControlType = ControlType.Window
                        }),
                    FakeFactory.GetAutomationElementExpected(
                        new ElementData {
                            Current_ProcessId = pid01,
                            Current_ControlType = ControlType.Window
                        }),
                    FakeFactory.GetAutomationElementExpected(
                        new ElementData {
                            Current_ProcessId = pid01,
                            Current_ControlType = ControlType.Window
                        })
                },
               3);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        // [Ignore]
        [MbUnit.Framework.Ignore]
        [NUnit.Framework.Ignore("")]
        public void Get3of3_NoRecurison_DifferentPids()
        {
            // Arrange
            const int pid01 = 111;
            const int pid02 = 222;
            const int pid03 = 333;
            TestParametersAgainstCollection(
                new[] { pid01, pid02, pid03 },
                null,
                string.Empty,
                string.Empty,
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
        #endregion no recursion
        
        #region recursion
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0of1_Name()
        {
            // Arrange
            const int pid = 555;
            TestParametersAgainstCollection(
                new[] { pid },
                new string[] { "aaaa" },
                string.Empty,
                string.Empty,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementNotExpected(
                        new ElementData {
                            Current_ProcessId = 1,
                            Current_ControlType = ControlType.Window
                        })
                },
               0);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        // [Ignore]
        [MbUnit.Framework.Ignore]
        [NUnit.Framework.Ignore("")]
        public void Get1of1_Name()
        {
            // Arrange
            const int pid = 555;
            TestParametersAgainstCollection(
                new[] { pid },
                new string[] { "aaaa" },
                string.Empty,
                string.Empty,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(
                        new ElementData {
                            Current_ProcessId = pid,
                            Current_ControlType = ControlType.Window
                        })
                },
               1);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0of1_AutomaitonId()
        {
            // Arrange
            const int pid = 555;
            TestParametersAgainstCollection(
                new[] { pid },
                null,
                "auId",
                string.Empty,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementNotExpected(
                        new ElementData {
                            Current_ProcessId = 1,
                            Current_ControlType = ControlType.Window
                        })
                },
               0);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        // [Ignore]
        [MbUnit.Framework.Ignore]
        [NUnit.Framework.Ignore("")]
        public void Get1of1_AutomaitonId()
        {
            // Arrange
            const int pid = 555;
            TestParametersAgainstCollection(
                new[] { pid },
                null,
                "auId",
                string.Empty,
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(
                        new ElementData {
                            Current_ProcessId = pid,
                            Current_ControlType = ControlType.Window
                        })
                },
               1);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Get0of1_ClassName()
        {
            // Arrange
            const int pid = 555;
            TestParametersAgainstCollection(
                new[] { pid },
                null,
                string.Empty,
                "class",
                new IUiElement[] {
                    FakeFactory.GetAutomationElementNotExpected(
                        new ElementData {
                            Current_ProcessId = 1,
                            Current_ControlType = ControlType.Window
                        })
                },
               0);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        // [Ignore]
        [MbUnit.Framework.Ignore]
        [NUnit.Framework.Ignore("")]
        public void Get1of1_ClassName()
        {
            // Arrange
            const int pid = 555;
            TestParametersAgainstCollection(
                new[] { pid },
                null,
                string.Empty,
                "class",
                new IUiElement[] {
                    FakeFactory.GetAutomationElementExpected(
                        new ElementData {
                            Current_ProcessId = pid,
                            Current_ControlType = ControlType.Window
                        })
                },
               1);
        }
        #endregion recursion
    }
}
