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
    [MbUnit.Framework.TestFixture]
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
            
            // Assert
            MbUnit.Framework.Assert.Count(expectedNumberOfElements, resultList);
            Xunit.Assert.Equal(expectedNumberOfElements, resultList.Count);
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
