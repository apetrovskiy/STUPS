//using System;
//using NBehave.Narrator.Framework;
////using NUnit.Framework;
//using MbUnit.Framework;
//
//namespace BDDAddin
//{
//    [TestFixture]
//    public class Embedded
//    {
//        [Test]
//        public void Should_Run_feature_file()
//        {
//            @"..\..\Gherkin\simple.feature".ExecuteFile(GetType().Assembly);
//        }
//        
//        [Test]
//        public void Should_Run_feature_text()
//        {
//            @"Feature: a small example with tables and examples
//                As a [role]
//                I want [feature]
//                So that [benefit]
//                
//            Scenario: Add item to list
//                Given an empty list
//                When I add foo to list
//                Then the list should contain foo
//            ".ExecuteText(GetType().Assembly);
//        }
//    }
//}