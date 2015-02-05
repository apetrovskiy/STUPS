/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 5:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace BddAddinUnitTests.Commands.Bdd
{
    using System;
    using System.Text.RegularExpressions;
    using MbUnit.Framework;
    using PSTestLib;
    //using Moq;
    //using Autofac;
    //using Autofac.Builder;
    using Tmx;
    
    /// <summary>
    /// Description of NewBddFeatureCommandTestFixture.
    /// </summary>
    public class NewBddFeatureCommandTestFixture
    {
        public NewBddFeatureCommandTestFixture()
        {
        }
        
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        
//PS C:\Users\Alexander> New-BDDFeature -FeatureName "feature 01" -AsA user -IWant "to buy a car" -SoThat "I go to the nea
//rest shop"
//
//
//Title      : feature 01
//Narrative  : As a user, I want to buy a car so that I go to the nearest shop
//Source     :
//SourceLine : 0
//Scenarios  : {}
//Background : Scenario:




        [Test]
        [Description("New-BDDFeature -FeatureName name -AsA user -IWant 'to buy' -SoThat 'I go'")]
        [Category("Fast")]
        public void NewFeature_FeatureName()
        {
            string expectedResultFeatureName = "suite name";
            string expectedResultAsA = "user";
            string expectedResultIWant = "to buy a car";
            string expectedResultSoThat = "I go to the car shop";
Console.WriteLine("NewFeature_FeatureName: 0001");
            NBehave.Narrator.Framework.Feature feature =
                UnitTestingHelper.GetNewBDDSuite(
                    expectedResultFeatureName,
                    expectedResultAsA,
                    expectedResultIWant,
                    expectedResultSoThat);
Console.WriteLine("NewFeature_FeatureName: 0002");
            Assert.AreEqual(
                expectedResultFeatureName,
                //((NBehave.Narrator.Framework.Feature)CommonCmdletBase.UnitTestOutput[CommonCmdletBase.UnitTestOutput.Count - 1]).Title);
                feature.Title);
Console.WriteLine("NewFeature_FeatureName: 0003");
            Assert.AreEqual(
                expectedResultAsA.ToUpper(),
                Regex.Match(feature.Narrative, @"(?<=([Aa][Ss][\s]+?[Aa][Nn]?[\s]+?)).*(?=([\,][\s]+?[Ii][\s]+?[Ww][Aa][Nn][Tt][\s]+?))").Value.ToUpper());
Console.WriteLine("NewFeature_FeatureName: 0004");
            Assert.AreEqual(
                expectedResultIWant.ToUpper(),
                Regex.Match(feature.Narrative, @"(?<=([Ii][\s]+?[Ww][Aa][Nn][Tt][\s]+?)).*(?=([\s]+?[Ss][Oo][\s]+?[Tt][Hh][Aa][Tt][\s]+?))").Value.ToUpper());
Console.WriteLine("NewFeature_FeatureName: 0005");
            Assert.AreEqual(
                expectedResultSoThat.ToUpper(),
                Regex.Match(feature.Narrative, @"(?<=([\s]+?[Ss][Oo][\s]+?[Tt][Hh][Aa][Tt][\s]+?)).*").Value.ToUpper());
        }
        
    }
}
