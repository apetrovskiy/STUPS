//using System.Collections.Generic;
//using NBehave.Narrator.Framework;
//
//namespace BDDAddin
//{
//    [ActionSteps]
//    public class SimpleSteps
//    {
//        [Given("an empty list")]
//        public void EmptyList()
//        {
//            ScenarioContext.Current.Add("list", new List<string>());
//        }
//
//        [When("I add $x to list")]
//        public void AddToList(string x)
//        {
//            var list = ScenarioContext.Current.Get<List<string>>("list");
//            list.Add(x);
//        }
//
//        [Then("the list should contain $y")]
//        public void ListShouldContain(string y)
//        {
//            var list = ScenarioContext.Current.Get<List<string>>("list");
//            NUnit.Framework.CollectionAssert.Contains(list, y);              
//        }
//    }
//}