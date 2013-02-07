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
    /// Description of GetBDDCurrentFeatureTitleCommand_ParamCheck.
    /// </summary>
    [TestFixture]
    public class GetBDDCurrentFeatureTitleCommand_ParamCheck
    {
        public GetBDDCurrentFeatureTitleCommand_ParamCheck()
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
        [Category("Get-BDDCurrentFeatureTitle")]
        public void GetBDDCurrentFeatureTitle_Happy_path()
        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "New-BDDFeature -FeatureName name -Asa user -IWant that -SoThat do;");
        }
    }
}
