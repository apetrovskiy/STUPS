/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/26/2012
 * Time: 11:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace BDDAddinUnitTests
{
    using System;
    using Tmx;
    using Tmx.Commands;
    using PSTestLib;
	using Tmx.Core;
    
    //using NBehave.Fluent.Framework.MbUnit;
    using NBehave.Narrator.Framework;
    //using NBehave.Spec.MbUnit;
    using System.Linq;
    using System.Xml.Linq;
    
    
    using NBehave.Narrator.Framework.Hooks;
    //using MbUnit.Framework;
    using System.Linq.Expressions;
    using NBehave.Fluent.Framework;
    using NBehave.Fluent.Framework.Extensions;
    
    /// <summary>
    /// Description of UnitTestingHelper.
    /// </summary>
    public static class UnitTestingHelper
    {
        static UnitTestingHelper()
        {
        }
        
        public static void PrepareUnitTestDataStore()
        {
            PSCmdletBase.UnitTestMode = true;
            
//            if (null != Tmx.CommonCmdletBase.UnitTestOutput && 0 < Tmx.CommonCmdletBase.UnitTestOutput.Count) {
//                Tmx.CommonCmdletBase.UnitTestOutput.Clear();
//            }
            if (0 < PSTestLib.UnitTestOutput.Count) {
                PSTestLib.UnitTestOutput.Clear();
            }
            
            //TLAddinData.CurrentTestLinkConnection = null;
            
            TestData.ResetData();
            
        }
        
        public static NBehave.Narrator.Framework.Feature GetNewBDDSuite(
            string featureName,
            string asA,
            string iWant,
            string soThat)
        {
            //throw new NotImplementedException();
            
            
//            NewSuiteCmdletBase cmdlet =
//                new NewSuiteCmdletBase();
//            //cmdlet.UnitTestMode = true;
//            if (null != name && string.Empty != name) {
//                cmdlet.Name = name;
//            }
//            if (null != id && string.Empty != id) {
//                cmdlet.Id = id;
//            }
//            if (null != description && string.Empty != description) {
//                cmdlet.Description = description;
//            }
//            
//            TmxNewTestSuiteCommand command =
//                new TmxNewTestSuiteCommand(cmdlet);
//            command.Execute();
//            
//            return (ITestSuite)CommonCmdletBase.UnitTestOutput[CommonCmdletBase.UnitTestOutput.Count - 1];
            
            BDDFeatureCmdletBase cmdlet =
                new BDDFeatureCmdletBase();
            cmdlet.FeatureName = featureName;
            cmdlet.AsA = asA;
            cmdlet.IWant = iWant;
            cmdlet.SoThat = soThat;
            
            BDDNewFeatureCommand command =
                new BDDNewFeatureCommand(cmdlet);
            command.Execute();
            
            //return ((NBehave.Narrator.Framework.Feature)CommonCmdletBase.UnitTestOutput[CommonCmdletBase.UnitTestOutput.Count - 1]);
Console.WriteLine("GetNewBDDSuite: 0001");
try {
    Console.WriteLine(((NBehave.Narrator.Framework.Feature)(object)PSTestLib.UnitTestOutput.LastOutput[0]));
}
catch (Exception e00) {
    Console.WriteLine(e00.Message);
    Console.WriteLine(e00.GetType().Name);
}
try {
    Console.WriteLine(((NBehave.Narrator.Framework.Feature)(object)PSTestLib.UnitTestOutput.Count));
}
catch (Exception e01) {
    Console.WriteLine(e01.Message);
    Console.WriteLine(e01.GetType().Name);
}
try {
    Console.WriteLine(((NBehave.Narrator.Framework.Feature)(object)PSTestLib.UnitTestOutput.LastOutput[0]));
}
catch (Exception e02) {
    Console.WriteLine(e02.Message);
    Console.WriteLine(e02.GetType().Name);
}
            return ((NBehave.Narrator.Framework.Feature)(object)PSTestLib.UnitTestOutput.LastOutput[0]);
Console.WriteLine("GetNewBDDSuite: 0002");
        }
    }
}
