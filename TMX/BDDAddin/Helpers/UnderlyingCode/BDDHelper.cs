/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/24/2012
 * Time: 1:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using NBehave.Narrator.Framework.Hooks;
    using NBehave.Narrator.Framework; // not for Before/After Scenario, Before/After Run
    
    //using NBehave.Fluent.Framework.MbUnit;
    //using NBehave.Narrator.Framework;
    //using NBehave.Spec.MbUnit;
    using System.Linq;
    using System.Xml.Linq;
    
    
    //using NBehave.Narrator.Framework.Hooks;
    //using MbUnit.Framework;
    using System.Linq.Expressions;
    using NBehave.Fluent.Framework;
    using NBehave.Fluent.Framework.Extensions;
    
    /// <summary>
    /// Description of BDDHelper.
    /// </summary>
    public static class BDDHelper
    {
        static BDDHelper()
        {
        }
        
        public static void InvokeBeforeRunScriptblocks()
        {
            
        }
        
        public static void InvokeBeforeFeatureScriptblocks()
        {
            
        }
        
        public static void InvokeBeforeScenarioScriptblocks()
        {
            
        }
        
        public static void InvokeBeforeStepScriptblocks()
        {
            //FeatureContext.Current.FeatureTitle
            //FeatureContext.Current.Tags
            //ScenarioContext.Current.ScenarioTitle
            //ScenarioContext.Current.Tags
        }
        
        public static void InvokeAfterStepScriptblocks()
        {
            
        }
        
        public static void InvokeAfterScenarioScriptblocks()
        {
            
        }
                
        public static void InvokeAfterFeatureScriptblocks()
        {
            
        }
        
        public static void InvokeAfterRunScriptblocks()
        {
            
        }
        
        public static void CreateNewFeature(BDDFeatureCmdletBase cmdlet)
        {
            ScenarioProcessingClass scenarioClass =
                new ScenarioProcessingClass();

            scenarioClass.SetupFeature(
                cmdlet.FeatureName,
                cmdlet.AsA,
                cmdlet.IWant,
                cmdlet.SoThat);

            scenarioClass.MainSetup();
            
            BDDAddinData.Features.Add(scenarioClass);

            cmdlet.WriteObject(cmdlet, scenarioClass.FeatureCreated);
        }
        
        public static void AddScenario(BDDScenarioCmdletBase cmdlet)
        {
            ScenarioProcessingClass scenarioClass =
                BDDAddinData.GetFeature(
                    cmdlet.InputObject.Title,
                    cmdlet.InputObject.Narrative);
            
            if (null != scenarioClass) {
                scenarioClass.AddScenario(cmdlet);
            }
        }
    }
}
