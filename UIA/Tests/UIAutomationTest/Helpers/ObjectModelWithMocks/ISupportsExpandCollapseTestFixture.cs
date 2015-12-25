/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/8/2014
 * Time: 2:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Helpers.ObjectModelWithMocks
{
    using System;
    using System.Windows.Automation;
    using UIAutomation;
    using UIAutomationUnitTests;
    using System.Collections;
    using System.Threading;
    
    /// <summary>
    /// Description of ISupportsExpandCollapseTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsExpandCollapseTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            #region commented
            // the current 3
            // CurrentData.ResetData();
            
            // FakeFactory.InitForPowerShell();
            // MiddleLevelCode.PrepareRunspace();
            
            // the current 4
            // the current 6
            // FakeFactory.InitForPowerShell();
            #endregion commented
            
            try {
                MiddleLevelCode.DisposeRunspace();
            } catch (Exception) {
                
                // throw;
            }
            
            MiddleLevelCode.PrepareRunspace();
            
            // the current 2
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.CurrentData]::ResetData());");
            #region commented
            // the current 4
//            FakeFactory.InitForPowerShell();
//            MiddleLevelCode.PrepareRunspace();
            
            // the current 6
            #endregion commented
            FakeFactory.InitForPowerShell();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
            // MiddleLevelCode.DisposeRunspace();
            
            #region commented
            // CurrentData.ResetData();
            // the current
            // FakeFactory.Reset();
            
            // the current 5 (exp)
            // CurrentData.ResetData();
            
            // MiddleLevelCode.DisposeRunspace();
            #endregion commented
        }
        
        #region commented
        /*
        $rootNode = Get-UiaWindow -n *win*full* | Get-UiaTree | Get-UiaTreeItem
        $rootNode | Get-UiaTreeItemCheckedState ### ?
        
        $rootNode.ExpandCollapseState
        $rootNode.Expand()
        $rootNode.Collapse()
        */
        
        // ComboBox
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [MbUnit.Framework.Category("Slow")]
//        [MbUnit.Framework.Category("WinForms")]
//        [MbUnit.Framework.Category("Control")]
//        public void Invoke_ComboBox_Expand()
//        {
//            string expectedResult = "b2";
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsFull, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"(Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaComboBox -AutomationId comboBox1).Expand() " + 
//                @" | Get-UiaListItem -Name b2 | Read-UiaControlName;",
//                expectedResult);
//        }
        
        // TreeItem
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [MbUnit.Framework.Category("Slow")]
//        [MbUnit.Framework.Category("WinForms")]
//        [MbUnit.Framework.Category("Control")]
//        public void Invoke_TreeItem_Expand()
//        {
//            string expectedResult = "Invoked";
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsFull, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = (Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaTreeItem -Name Node0).Expand();" + 
//                @"Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaList -AutomationId listBox1 | " + 
//                @"Get-UiaListItem -Name " + 
//                expectedResult +
//                @" | Read-UiaControlName;",
//                expectedResult);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [MbUnit.Framework.Category("Slow")]
//        [MbUnit.Framework.Category("ISupportsExpandCollapse")]
//        public void TreeItem_ExpandCollapseState_Expanded()
//        {
//            string expectedResult = "Expanded";
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsFull, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = (Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaTreeItem -Name Node0).Expand(); " + 
//                @"(Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaTreeItem -Name Node0).ExpandCollapseState; ",
//                expectedResult);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [MbUnit.Framework.Category("Slow")]
//        [MbUnit.Framework.Category("ISupportsExpandCollapse")]
//        public void TreeItem_ExpandCollapseState_Collapsed()
//        {
//            string expectedResult = "Collapsed";
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsFull, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = (Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaTreeItem -Name Node0).Collapse(); " + 
//                @"(Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaTreeItem -Name Node0).ExpandCollapseState; ",
//                expectedResult);
//        }
        
        #endregion commented
        
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Ignore][NUnit.Framework.Ignore("")]
        public void ExpandCollapseState_Expanded()
        {
            // Arrange
            const ExpandCollapseState expectedValue = ExpandCollapseState.Expanded;
            var element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
            
            #region commented
//if (null == element) {
//    Console.WriteLine("null == element");
//} else {
//    Console.WriteLine("null != element");
//    try {
//        Console.WriteLine(element.ExpandCollapseState.ToString());
//    } catch (Exception e) {
//        Console.WriteLine(e.Message);
//        // throw;
//    }
//}
//var pattern = FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue });
//if (null == pattern) {
//    Console.WriteLine("null == pattern");
//} else {
//    Console.WriteLine("null != pattern");
//    try {
//        Console.WriteLine(pattern.Current.ExpandCollapseState.ToString());
//    } catch (Exception e2) {
//        Console.WriteLine(e2.Message);
//        // throw;
//    }
//}
            #endregion commented
            
            // Act
            // Assert
            var data = new object[] { @"$input | %{ $_.ExpandCollapseState; }", new [] { element }, expectedValue.ToString() };
            Thread thread = new Thread(RunTest);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start(data);
            
            #region commented
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                // @"$input | %{ $_.ExpandCollapseState; }",
//                @"[System.EventHandler]$handler = { $input | %{ $_.ExpandCollapseState; } }; $handler.Invoke();",
//                null, //new [] { element },
//                expectedValue.ToString());
            #endregion commented
        }
        
        public static void RunTest(object data)
        {
            var dataArray = data as object[];
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                dataArray[0].ToString(),
                dataArray[1] as IEnumerable,
                dataArray[2].ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Ignore][NUnit.Framework.Ignore("")]
        public void ExpandCollapseState_Collapsed()
        {
            // Arrange
            ExpandCollapseState expectedValue = ExpandCollapseState.Collapsed;
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
            
            #region commented
//if (null == element) {
//    Console.WriteLine("null == element");
//} else {
//    Console.WriteLine("null != element");
//    try {
//        Console.WriteLine(element.ExpandCollapseState.ToString());
//    } catch (Exception e) {
//        Console.WriteLine(e.Message);
//        // throw;
//    }
//}
//var pattern = FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue });
//if (null == pattern) {
//    Console.WriteLine("null == pattern");
//} else {
//    Console.WriteLine("null != pattern");
//    try {
//        Console.WriteLine(pattern.Current.ExpandCollapseState.ToString());
//    } catch (Exception e2) {
//        Console.WriteLine(e2.Message);
//        // throw;
//    }
//}
            #endregion commented
            
            // Act
            // Assert
            var data = new object[] { @"$input | %{ $_.ExpandCollapseState; }", new [] { element }, expectedValue.ToString() };
            Thread thread = new Thread(RunTest);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start(data);
            
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                // @"$input | %{ $_.ExpandCollapseState; }",
//                @"[System.EventHandler]$handler = { $input | %{ $_.ExpandCollapseState; } }; $handler.Invoke();",
//                null, //new [] { element },
//                expectedValue.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Ignore][NUnit.Framework.Ignore("")]
        public void ExpandCollapseState_LeafNode()
        {
            // Arrange
            ExpandCollapseState expectedValue = ExpandCollapseState.LeafNode;
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
            #region commented
//if (null == element) {
//    Console.WriteLine("null == element");
//} else {
//    Console.WriteLine("null != element");
//    try {
//        Console.WriteLine(element.ExpandCollapseState.ToString());
//    } catch (Exception e) {
//        Console.WriteLine(e.Message);
//        // throw;
//    }
//}
//var pattern = FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue });
//if (null == pattern) {
//    Console.WriteLine("null == pattern");
//} else {
//    Console.WriteLine("null != pattern");
//    try {
//        Console.WriteLine(pattern.Current.ExpandCollapseState.ToString());
//    } catch (Exception e2) {
//        Console.WriteLine(e2.Message);
//        // throw;
//    }
//}
            #endregion commented
            
            // Act
            // Assert
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$input | %{ $_.ExpandCollapseState; }",
                // @"$input | %{ $_.GetSourceElement().ExpandCollapseState; }",
                new [] { element },
                // new [] { (element as IUiElement).GetSourceElement() },
                expectedValue.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Ignore][NUnit.Framework.Ignore("")]
        public void ExpandCollapseState_PartiallyExpanded()
        {
            // Arrange
            ExpandCollapseState expectedValue = ExpandCollapseState.PartiallyExpanded;
            ISupportsExpandCollapsePattern element =
                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue }) }) as ISupportsExpandCollapsePattern;
            
            #region commented
//if (null == element) {
//    Console.WriteLine("null == element");
//} else {
//    Console.WriteLine("null != element");
//    try {
//        Console.WriteLine(element.ExpandCollapseState.ToString());
//    } catch (Exception e) {
//        Console.WriteLine(e.Message);
//        // throw;
//    }
//}
//var pattern = FakeFactory.GetExpandCollapsePattern(new PatternsData() { ExpandCollapsePattern_ExpandCollapseState = expectedValue });
//if (null == pattern) {
//    Console.WriteLine("null == pattern");
//} else {
//    Console.WriteLine("null != pattern");
//    try {
//        Console.WriteLine(pattern.Current.ExpandCollapseState.ToString());
//    } catch (Exception e2) {
//        Console.WriteLine(e2.Message);
//        // throw;
//    }
//}
            #endregion commented
            
            // Act
            // Assert
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$input | %{ $_.ExpandCollapseState; }",
                // @"$input | %{ $_.GetSourceElement().ExpandCollapseState; }",
                new [] { element },
                // new [] { (element as IUiElement).GetSourceElement() },
                expectedValue.ToString());
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ExpandCollapse_Collapse()
//        {
//            // Arrange
//            ExpandCollapseState expectedValue = ExpandCollapseState.Collapsed;
//            ISupportsExpandCollapsePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsExpandCollapsePattern;
//            
//            // Act
//            element.Collapse();
//            try {
//                (element as IUiElement).GetCurrentPattern<IExpandCollapsePattern>(ExpandCollapsePattern.Pattern).Received().Collapse();
//                element.ExpandCollapseState.Returns(expectedValue);
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.ExpandCollapseState);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        public void ExpandCollapse_Expand()
//        {
//            // Arrange
//            ExpandCollapseState expectedValue = ExpandCollapseState.Expanded;
//            ISupportsExpandCollapsePattern element =
//                FakeFactory.GetAutomationElementForMethodsOfObjectModel(
//                    new IBasePattern[] { FakeFactory.GetExpandCollapsePattern(new PatternsData()) }) as ISupportsExpandCollapsePattern;
//            
//            // Act
//            element.Expand();
//            try {
//                (element as IUiElement).GetCurrentPattern<IExpandCollapsePattern>(ExpandCollapsePattern.Pattern).Received().Expand();
//                element.ExpandCollapseState.Returns(expectedValue);
//            }
//            catch {}
//            
//            // Assert
//            Assert.AreEqual(expectedValue, element.ExpandCollapseState);
//        }
    }
}
