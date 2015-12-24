//using System.Collections.Generic;
//using System.Linq;
//using NBehave.Narrator.Framework;
////using NUnit.Framework;
//using MbUnit.Framework;
//
//namespace BddAddin
//{
//    public class Contact
//    {
//        public string Name {get; set; }
//        public string Country {get; set; }
//    }
//
//    [ActionSteps]
//    public class TablesSteps
//    {
//        [Given("a list of contacts:")]
//        public void Contacts(List<Contact> contacts)
//        {
//            ScenarioContext.Current.Add("contacts", contacts);
//        }
//
//        [When("I search for contacts from $country")]
//        public void Search(string country)
//        {
//            var contacts = ScenarioContext.Current.Get<List<Contact>>("contacts");
//            var found = contacts.Where(_=>_.Country == country).ToList();
//            ScenarioContext.Current.Add("found", found);
//        }
//
//        [Then("I should find:")]
//        public void ContactsFound(List<Contact> expected)
//        {    
//            var found = ScenarioContext.Current.Get<List<Contact>>("found");
//            CollectionAssert.AreEquivalent(expected, found);
//        }
//    }
//}