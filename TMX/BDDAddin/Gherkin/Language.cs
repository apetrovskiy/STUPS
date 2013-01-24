//using System.Collections.Generic;
//using NBehave.Narrator.Framework;
//
//namespace BDDAddin
//{
//	[ActionSteps]
//	public class LanguageSteps
//	{
//		// You should also try to put these attributes on the step methods in Simple.cs
//		// You can have multiple step attributes on one method
//		
//		[Given("en tom lista")]
//		public void EmptyList()
//		{
//			ScenarioContext.Current.Add("list", new List<string>());
//		}
//
//        [When("jag lägger till $x till listan")]
//        public void AddToList(string x)
//        {
//            var list = ScenarioContext.Current.Get<List<string>>("list");
//            list.Add(x);
//        }
//
//        [Then("ska listan innehålla $y")]
//        public void ListShouldContain(string y)
//        {
//            var list = ScenarioContext.Current.Get<List<string>>("list");
//            NUnit.Framework.CollectionAssert.Contains(list, y);              
//        }
//	}
//}