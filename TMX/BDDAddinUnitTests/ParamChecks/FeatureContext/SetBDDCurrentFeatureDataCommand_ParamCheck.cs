/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/27/2012
 * Time: 11:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace BDDAddinUnitTests.CheckCmdletParameters.FeatureContext
{
    using System;
    using Tmx;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of SetBDDCurrentFeatureDataCommand_ParamCheck.
    /// </summary>
    [TestFixture]
    public class SetBDDCurrentFeatureDataCommand_ParamCheck
    {
        public SetBDDCurrentFeatureDataCommand_ParamCheck()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspaceForParamChecks();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
        }
        
        [Test]
        [Ignore]
        [Category("Fast")]
        [Category("Set-BDDCurrentFeatureData")]
        public void SetBDDCurrentFeatureData_Happy_path()
        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "New-BDDFeature -FeatureName name -Asa user -IWant that -SoThat do;");
        }
    }
}
