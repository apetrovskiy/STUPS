///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 08.12.2011
// * Time: 11:17
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//
//namespace UIAutomationTest.Commands.Convert
//{
//    using System;
//    using MbUnit.Framework;using NUnit.Framework;
//    using System.Management.Automation;
//    /// <summary>
//    /// Description of ConvertFromUiaListCommandTestFixture.
//    /// </summary>
//    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="ConvertFrom-UiaListCommand test")]
//    public class ConvertFromUiaListCommandTestFixture
//    {
//        public ConvertFromUiaListCommandTestFixture()
//        {
//        }
//        
//        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
//        public void PrepareRunspace()
//        {
//            MiddleLevelCode.PrepareRunspace();
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="InputObject ProcessRecord test Null via pipeline")]
//        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("NoForms")]
//        public void TestPipelineInput()
//        {
//            string codeSnippet = 
//                @"if ( ($null | ConvertFrom-UiaList) ) { 1; }else{ 0; }";
//            System.Collections.ObjectModel.Collection<PSObject> coll = 
//                CmdletUnitTest.TestRunspace.RunPSCode(codeSnippet);
//            Assert.IsTrue(coll[0].ToString() == "0");
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="ProcessRecord test Null via parameter")]
//        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("NoForms")]
//        public void TestParameterInputNull()
//        {
//            string codeSnippet = 
//                @"if ((ConvertFrom-UiaList -InputObject $null)) { 1; }else{ 0; }";
//            System.Collections.ObjectModel.Collection<PSObject> coll =
//                CmdletUnitTest.TestRunspace.RunPSCode(codeSnippet);
//            Assert.IsNull(coll);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="ProcessRecord test Is Not AutomationElement")]
//        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("NoForms")]
//        public void TestParameterInputOtherType()
//        {
//            string codeSnippet = 
//                @"if ((ConvertFrom-UiaList -InputObject (New-Object System.Windows.forms.Label))) { 1; }else{ 0; }";
//            System.Collections.ObjectModel.Collection<PSObject> coll =
//                CmdletUnitTest.TestRunspace.RunPSCode(codeSnippet);
//            Assert.IsNull(coll);
//        }
//        
//        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
//        public void DisposeRunspace()
//        {
//            MiddleLevelCode.DisposeRunspace();
//        }
//        
//    }
//    
//    
//
//}