/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/27/2012
 * Time: 11:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace BddAddinUnitTests.CheckCmdletParameters.Bdd
{
    using System;
    using Tmx;
    using MbUnit.Framework;

    /// <summary>
    /// Description of NewBDDFeatureCommand_ParamCheck.
    /// </summary>
    [TestFixture]
    public class NewBDDFeatureCommand_ParamCheck
    {
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
        [Category("Fast")]
        [Category("New-BDDFeature -FeatureName name -AsA user -IWant that -SoThat do;")]
        public void NewBDDFeature_Happy_path()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
                "New-BDDFeature -FeatureName name -AsA user -IWant that -SoThat do;");
        }
    }
}
