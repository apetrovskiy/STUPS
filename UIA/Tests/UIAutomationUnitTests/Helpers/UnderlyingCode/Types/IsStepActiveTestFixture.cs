/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/27/2014
 * Time: 1:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.UnderlyingCode.Types
{
    using System.Collections;
    using System.Windows.Automation;
    using UIAutomation;
    using Xunit;
    
    /// <summary>
    /// Description of IsStepActiveTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class IsStepActiveTestFixture
    {
        public IsStepActiveTestFixture()
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
        #endregion helpers
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void NoneCriteria_NoneElements()
        {
            // Arrange
            
            // Act
            bool result = RealCodeCaller.GetResult_IsStepActive(
                new Hashtable[] {
                    null
                },
                AutomationFactory.GetUiEltCollection(new IUiElement[] { null })
               );
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(false, result);
            Assert.Equal(false, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void NoneCriteria_OneElement()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementExpected(ControlType.Button, "aaaa", string.Empty, string.Empty, string.Empty);
            
            // Act
            bool result = RealCodeCaller.GetResult_IsStepActive(
                new Hashtable[] {
                    null
                },
                AutomationFactory.GetUiEltCollection(new[] { element })
               );
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(false, result);
            Assert.Equal(false, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void NoneCriteria_ThreeElements()
        {
            // Arrange
            var element = FakeFactory.GetAutomationElementExpected(ControlType.Button, "aaaa", string.Empty, string.Empty, string.Empty);
            
            // Act
            bool result = RealCodeCaller.GetResult_IsStepActive(
                new Hashtable[] {
                    null
                },
                AutomationFactory.GetUiEltCollection(
                    new IUiElement[] {
                        FakeFactory.GetAutomationElementExpected(ControlType.Button, "aaaa", string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElementExpected(ControlType.Button, "aaaa", string.Empty, string.Empty, string.Empty),
                        FakeFactory.GetAutomationElementExpected(ControlType.Button, "aaaa", string.Empty, string.Empty, string.Empty)
                    }
                   )
               );
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(false, result);
            Assert.Equal(false, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void OneCriterion_NoneElements()
        {
            // Arrange
            var hashtable = new Hashtable();
            hashtable.Add("NAME", "*aaa*");
            
            // Act
            bool result = RealCodeCaller.GetResult_IsStepActive(
                new Hashtable[] {
                    hashtable
                },
                AutomationFactory.GetUiEltCollection(new IUiElement[] { null })
               );
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(false, result);
            Assert.Equal(false, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void OneCriterion_OneElement_Match_Name()
        {
            // Arrange
            var hashtable = new Hashtable();
            hashtable.Add("NAME", "*aaa*");
            var element = FakeFactory.GetAutomationElementExpected(ControlType.Button, "aaaa", string.Empty, string.Empty, string.Empty);
            
            // Act
            bool result = RealCodeCaller.GetResult_IsStepActive(
                new Hashtable[] {
                    hashtable
                },
                AutomationFactory.GetUiEltCollection(new[] { element })
               );
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(true, result);
            Assert.Equal(true, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void OneCriterion_OneElement_NoMatch_Name()
        {
            // Arrange
            var hashtable = new Hashtable();
            hashtable.Add("NAME", "*aaa*");
            var element = FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "bbbb", string.Empty, string.Empty, string.Empty);
            
            // Act
            bool result = RealCodeCaller.GetResult_IsStepActive(
                new Hashtable[] {
                    hashtable
                },
                AutomationFactory.GetUiEltCollection(new[] { element })
               );
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(false, result);
            Assert.Equal(false, result);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        // [Ignore]
        [MbUnit.Framework.Ignore]
        [NUnit.Framework.Ignore("")]
        public void OneCriterion_OneElement_Match_AutomationIdWrongTyped()
        {
            // Arrange
            var hashtable = new Hashtable();
            hashtable.Add("AUTOMAITONID", "*aaa*");
            var element = FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, "aaaa", string.Empty, string.Empty);
            
            // Act
            bool result = RealCodeCaller.GetResult_IsStepActive(
                new Hashtable[] {
                    hashtable
                },
                AutomationFactory.GetUiEltCollection(new[] { element })
               );
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(false, result);
            Assert.Equal(false, result);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        // [Ignore]
        [MbUnit.Framework.Ignore]
        [NUnit.Framework.Ignore("")]
        public void OneCriterion_OneElement_NoMatch_AutomationIdWrongTyped()
        {
            // Arrange
            var hashtable = new Hashtable();
            hashtable.Add("AUTOMAITONID", "*aaa*");
            var element = FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, "bbbb", string.Empty, string.Empty);
            
            // Act
            bool result = RealCodeCaller.GetResult_IsStepActive(
                new Hashtable[] {
                    hashtable
                },
                AutomationFactory.GetUiEltCollection(new[] { element })
               );
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(false, result);
            Assert.Equal(false, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void OneCriterion_OneElement_Match_AutomationId()
        {
            // Arrange
            var hashtable = new Hashtable();
            hashtable.Add("AUTOMATIONID", "*aaa*");
            var element = FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, "aaaa", string.Empty, string.Empty);
            
            // Act
            bool result = RealCodeCaller.GetResult_IsStepActive(
                new Hashtable[] {
                    hashtable
                },
                AutomationFactory.GetUiEltCollection(new[] { element })
               );
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(true, result);
            Assert.Equal(true, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void OneCriterion_OneElement_NoMatch_AutomationId()
        {
            // Arrange
            var hashtable = new Hashtable();
            hashtable.Add("AUTOMATIONID", "*aaa*");
            var element = FakeFactory.GetAutomationElementNotExpected(ControlType.Button, string.Empty, "bbbb", string.Empty, string.Empty);
            
            // Act
            bool result = RealCodeCaller.GetResult_IsStepActive(
                new Hashtable[] {
                    hashtable
                },
                AutomationFactory.GetUiEltCollection(new[] { element })
               );
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(false, result);
            Assert.Equal(false, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void OneCriterion_OneElement_Match_ClassName()
        {
            // Arrange
            var hashtable = new Hashtable();
            hashtable.Add("class", "*aaa*");
            var element = FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, "aaaa", string.Empty);
            
            // Act
            bool result = RealCodeCaller.GetResult_IsStepActive(
                new Hashtable[] {
                    hashtable
                },
                AutomationFactory.GetUiEltCollection(new[] { element })
               );
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(true, result);
            Assert.Equal(true, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void OneCriterion_OneElement_NoMatch_ClassName()
        {
            // Arrange
            var hashtable = new Hashtable();
            hashtable.Add("class", "*aaa*");
            var element = FakeFactory.GetAutomationElementExpected(ControlType.Button, string.Empty, string.Empty, "bbbb", string.Empty);
            
            // Act
            bool result = RealCodeCaller.GetResult_IsStepActive(
                new Hashtable[] {
                    hashtable
                },
                AutomationFactory.GetUiEltCollection(new[] { element })
               );
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(false, result);
            Assert.Equal(false, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void OneCriterion_ThreeElements_Match_Name()
        {
            // Arrange
            var hashtable = new Hashtable();
            hashtable.Add("NAME", "*aaa*");
            
            // Act
            bool result = RealCodeCaller.GetResult_IsStepActive(
                new Hashtable[] {
                    hashtable
                },
                AutomationFactory.GetUiEltCollection(new[] {
                                                         FakeFactory.GetAutomationElementExpected(ControlType.Button, "aaaa", string.Empty, string.Empty, string.Empty),
                                                         FakeFactory.GetAutomationElementExpected(ControlType.Edit, "aaaa", string.Empty, string.Empty, string.Empty),
                                                         FakeFactory.GetAutomationElementExpected(ControlType.TreeItem, "aaaa", string.Empty, string.Empty, string.Empty)
                                                     })
               );
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(true, result);
            Assert.Equal(true, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void OneCriterion_ThreeElements_NoMatch_Name()
        {
            // Arrange
            var hashtable = new Hashtable();
            hashtable.Add("NAME", "*aaa*");
            
            // Act
            bool result = RealCodeCaller.GetResult_IsStepActive(
                new Hashtable[] {
                    hashtable
                },
                AutomationFactory.GetUiEltCollection(new[] {
                                                         FakeFactory.GetAutomationElementExpected(ControlType.Button, "bbbb", string.Empty, string.Empty, string.Empty),
                                                         FakeFactory.GetAutomationElementExpected(ControlType.Edit, "bbbb", string.Empty, string.Empty, string.Empty),
                                                         FakeFactory.GetAutomationElementExpected(ControlType.TreeItem, "bbbb", string.Empty, string.Empty, string.Empty)
                                                     })
               );
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(false, result);
            Assert.Equal(false, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ThreeCriteria_NoneElements()
        {
            // Arrange
            var hashtable = new Hashtable();
            hashtable.Add("NAME", "*aaa*");
            hashtable.Add("AUTOMATIONID", "*id*");
            hashtable.Add("CLASS", "cl*ss");
            
            // Act
            bool result = RealCodeCaller.GetResult_IsStepActive(
                new Hashtable[] {
                    hashtable
                },
                AutomationFactory.GetUiEltCollection(new IUiElement[] { null })
               );
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(false, result);
            Assert.Equal(false, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ThreeCriteria_OneElement_Match_NameAutomationIdClassName()
        {
            // Arrange
            var hashtable = new Hashtable();
            hashtable.Add("NAME", "*aaa*");
            hashtable.Add("AUTOMATIONID", "*id*");
            hashtable.Add("CLASS", "cl*ss");
            var element = FakeFactory.GetAutomationElementExpected(ControlType.Button, "aaaa", "auId", "class", string.Empty);
            
            // Act
            bool result = RealCodeCaller.GetResult_IsStepActive(
                new Hashtable[] {
                    hashtable
                },
                AutomationFactory.GetUiEltCollection(new[] { element })
               );
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(true, result);
            Assert.Equal(true, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ThreeCriteria_OneElement_NoMatch_NameAutomationIdClassName()
        {
            // Arrange
            var hashtable = new Hashtable();
            hashtable.Add("NAME", "*aaa*");
            hashtable.Add("AUTOMATIONID", "*id*");
            hashtable.Add("CLASS", "cl*ss");
            var element = FakeFactory.GetAutomationElementNotExpected(ControlType.Button, "bbbb", "auId", "class", string.Empty);
            
            // Act
            bool result = RealCodeCaller.GetResult_IsStepActive(
                new Hashtable[] {
                    hashtable
                },
                AutomationFactory.GetUiEltCollection(new[] { element })
               );
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(false, result);
            Assert.Equal(false, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ThreeCriteria_ThreeElements_Match_NameAutomaitonIdClassName()
        {
            // Arrange
            var hashtable = new Hashtable();
            hashtable.Add("NAME", "*aaa*");
            hashtable.Add("AUTOMATIONID", "*id*");
            hashtable.Add("CLASS", "cl*ss");
            
            // Act
            bool result = RealCodeCaller.GetResult_IsStepActive(
                new Hashtable[] {
                    hashtable
                },
                AutomationFactory.GetUiEltCollection(
                    new[] {
                        FakeFactory.GetAutomationElementExpected(ControlType.Button, "aaaa", "auId", "class", string.Empty),
                        FakeFactory.GetAutomationElementExpected(ControlType.Button, "aaaaaa", "Id", "cl____ss", string.Empty),
                        FakeFactory.GetAutomationElementExpected(ControlType.Button, "aaabbb", "iDrweqrqw", @"cl/ss", string.Empty)
                    })
               );
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(true, result);
            Assert.Equal(true, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ThreeCriteria_ThreeElements_NoMatch_NameAutomaitonIdClassName()
        {
            // Arrange
            var hashtable = new Hashtable();
            hashtable.Add("NAME", "*aaa*");
            hashtable.Add("AUTOMATIONID", "*id*");
            hashtable.Add("CLASS", "cl*ss");
            
            // Act
            bool result = RealCodeCaller.GetResult_IsStepActive(
                new Hashtable[] {
                    hashtable
                },
                AutomationFactory.GetUiEltCollection(
                    new[] {
                        FakeFactory.GetAutomationElementExpected(ControlType.Button, "aa1aa", "auId", "clas", string.Empty),
                        FakeFactory.GetAutomationElementExpected(ControlType.Button, "aa2aa3aa", "Id", "cl____s", string.Empty),
                        FakeFactory.GetAutomationElementExpected(ControlType.Button, "a4a5abbb", "iDrweqrqw", @"/ss", string.Empty)
                    })
               );
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(false, result);
            Assert.Equal(false, result);
        }
    }
}
