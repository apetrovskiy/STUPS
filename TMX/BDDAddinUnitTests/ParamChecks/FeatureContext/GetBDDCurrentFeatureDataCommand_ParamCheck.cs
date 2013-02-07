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
    using TMX;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of GetBDDCurrentFeatureDataCommand_ParamCheck.
    /// </summary>
    [TestFixture]
    public class GetBDDCurrentFeatureDataCommand_ParamCheck
    {
        public GetBDDCurrentFeatureDataCommand_ParamCheck()
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
        [Category("Get-BDDCurrentFeatureData")]
        public void GetBDDCurrentFeatureData_Happy_path()
        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "New-BDDFeature -FeatureName name -Asa user -IWant that -SoThat do;");
        }
    }
}
