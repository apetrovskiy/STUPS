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
    /// Description of GetBDDCurrentScenarioDataCommand_ParamCheck.
    /// </summary>
    [TestFixture]
    public class GetBDDCurrentScenarioDataCommand_ParamCheck
    {
        public GetBDDCurrentScenarioDataCommand_ParamCheck()
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
        [Category("Get-BDDCurrentScenarioData")]
        public void GetBDDCurrentScenarioData_Happy_path()
        {
//            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
//                "New-BDDFeature -FeatureName name -Asa user -IWant that -SoThat do;");
        }
    }
}
