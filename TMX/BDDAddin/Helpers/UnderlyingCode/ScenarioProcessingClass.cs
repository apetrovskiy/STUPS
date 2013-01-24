/*
 * Created by SharpDevelop.
  * User: Alexander Petrovskiy
 * Date: 12/26/2012
 * Time: 12:08 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    
    using System;
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
    /// Description of ScenarioProcessingClass.
    /// </summary>
    public class ScenarioProcessingClass : NBehave.Fluent.Framework.MbUnit.ScenarioDrivenSpecBase
    {
        public ScenarioProcessingClass()
        {
        }
        
        private string featureName;
        private string asA;
        private string iWant;
        private string soThat;
        
        internal NBehave.Narrator.Framework.Feature FeatureCreated
        {
            get { return base.Feature; }
        }
        
        public void SetupFeature(
            string featureName,
            string asA,
            string iWant,
            string soThat)
        {
            this.featureName = featureName;
            this.asA = asA;
            this.iWant = iWant;
            this.soThat = soThat;
        }
        
//        public void SetupFeature(
//            NBehave.Narrator.Framework.Feature feature)
//        {
//            base.Feature = feature;
//        }
        
        protected override NBehave.Narrator.Framework.Feature CreateFeature()
        {
            NBehave.Narrator.Framework.Feature featureTest =
                new NBehave.Narrator.Framework.Feature(this.featureName)
                .AddStory()
                .AsA(this.asA)
                .IWant(this.iWant)
                .SoThat(this.soThat);

            return featureTest;
        }
        
        public NBehave.Narrator.Framework.Feature GetFeature()
        {
            return this.Feature;
        }
        
        public NBehave.Narrator.Framework.Scenario AddScenario(
           BDDScenarioCmdletBase cmdlet)
        {
            IScenarioBuilderStartWithHelperObject scenarioObject =
                Feature.AddScenario();
            
            IGivenFragment fragmentGiven = null;
            if (null != cmdlet.Given && 0 < cmdlet.Given.Length) {
                int counterGiven = 0;
                foreach (string stepNameGiven in cmdlet.Given) {

                    if (0 == counterGiven) {
                        fragmentGiven =
                            scenarioObject.Given(stepNameGiven);
                    } else {
                        fragmentGiven =
                            fragmentGiven.And(stepNameGiven);
                    }
                    counterGiven++;
                }
            }
            
            
            fragmentGiven.And("aaaaaaaaaaaaaaaaaaaaaaaaa");
            
            IWhenFragment fragmentWhen = null;
            if (null != cmdlet.When && 0 < cmdlet.When.Length) {
                int counterWhen = 0;
                foreach (string stepNameWhen in cmdlet.When) {

                    if (0 == counterWhen) {
                        fragmentWhen =
                            fragmentGiven.When(stepNameWhen);
                    } else {
                        fragmentWhen =
                            fragmentWhen.And(stepNameWhen);
                    }
                    counterWhen++;
                }
            }
            
            
            fragmentWhen.And("bbbbbbbbbbbbbbbbbbbbbbbbb");
            
            IThenFragment fragmentThen = null;
            if (null != cmdlet.Then && 0 < cmdlet.Then.Length) {
                int counterThen = 0;
                foreach (string stepNameThen in cmdlet.Then) {

                    if (0 == counterThen) {
                        fragmentThen =
                            fragmentWhen.Then(stepNameThen);
                    } else {
                        fragmentThen =
                            fragmentThen.And(stepNameThen);
                    }
                    counterThen++;
                }
            }
            
            fragmentThen.And("cccccccccccccccccccccccccccc");
            
            return Feature.Scenarios[Feature.Scenarios.Count - 1];
        }
    }
}
