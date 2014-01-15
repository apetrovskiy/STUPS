/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/27/2012
 * Time: 11:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace BDDAddinUnitTests.CheckCmdletParameters.ScenarioContext
{
    using System;
    using TMX;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of SetBDDCurrentScenarioDataCommand_ParamCheck.
    /// </summary>
    [TestFixture]
    public class SetBDDCurrentScenarioDataCommand_ParamCheck
    {
        public SetBDDCurrentScenarioDataCommand_ParamCheck()
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
        [Category("Set-BDDCurrentScenarioData")]
        public void SetBDDCurrentScenarioData_Happy_path()
        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "New-BDDFeature -FeatureName name -Asa user -IWant that -SoThat do;");
        }
    }
}
