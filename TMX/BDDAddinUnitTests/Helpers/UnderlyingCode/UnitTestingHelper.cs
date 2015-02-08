/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/26/2012
 * Time: 11:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace BddAddinUnitTests
{
    using System;
    using Tmx;
    using PSTestLib;
    // using Tmx.Core;
    
    //using NBehave.Fluent.Framework.MbUnit;
//    using NBehave.Narrator.Framework;
    //using NBehave.Spec.MbUnit;
    using System.Linq;
//    using System.Xml.Linq;
    
    
//    using NBehave.Narrator.Framework.Hooks;
    //using MbUnit.Framework;
//    using System.Linq.Expressions;
    // using NBehave.Fluent.Framework;
    // using NBehave.Fluent.Framework.Extensions;
    
    /// <summary>
    /// Description of UnitTestingHelper.
    /// </summary>
    public static class UnitTestingHelper
    {
        public static void PrepareUnitTestDataStore()
        {
            PSCmdletBase.UnitTestMode = true;
            
//            if (null != Tmx.CommonCmdletBase.UnitTestOutput && 0 < Tmx.CommonCmdletBase.UnitTestOutput.Count) {
//                Tmx.CommonCmdletBase.UnitTestOutput.Clear();
//            }
            if (0 < UnitTestOutput.Count)
                UnitTestOutput.Clear();

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
            /*
            var cmdlet = new BDDFeatureCmdletBase();
            cmdlet.FeatureName = featureName;
            cmdlet.AsA = asA;
            cmdlet.IWant = iWant;
            cmdlet.SoThat = soThat;
            
            var command = new BDDNewFeatureCommand(cmdlet);
            command.Execute();
            */
			
            // temporarily
            // 20150129
            
            var cmdlet = new BddFeatureCmdletBase {
				FeatureName = featureName,
				AsA = asA,
				IWant = iWant,
				SoThat = soThat
			};
            
            var command = new BddNewFeatureCommand(cmdlet);
            command.Execute();
            
            //return ((NBehave.Narrator.Framework.Feature)CommonCmdletBase.UnitTestOutput[CommonCmdletBase.UnitTestOutput.Count - 1]);
Console.WriteLine("GetNewBDDSuite: 0001");
try {
    Console.WriteLine(((NBehave.Narrator.Framework.Feature)(object)UnitTestOutput.LastOutput[0]));
}
catch (Exception e00) {
    Console.WriteLine(e00.Message);
    Console.WriteLine(e00.GetType().Name);
}
try {
    Console.WriteLine(((NBehave.Narrator.Framework.Feature)(object)UnitTestOutput.Count));
}
catch (Exception e01) {
    Console.WriteLine(e01.Message);
    Console.WriteLine(e01.GetType().Name);
}
try {
    Console.WriteLine(((NBehave.Narrator.Framework.Feature)(object)UnitTestOutput.LastOutput[0]));
}
catch (Exception e02) {
    Console.WriteLine(e02.Message);
    Console.WriteLine(e02.GetType().Name);
}
            return ((NBehave.Narrator.Framework.Feature)(object)UnitTestOutput.LastOutput[0]);
        }
    }
}
