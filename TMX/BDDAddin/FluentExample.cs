//using System.Collections.Generic;
//using NBehave.Fluent.Framework.Extensions;
////using NBehave.Fluent.Framework.NUnit;
//using NBehave.Narrator.Framework;
////using NBehave.Spec.NUnit;
//using NBehave.Spec.MbUnit;
////using NUnit.Framework;
//using MbUnit.Framework;
//
//namespace BDDAddin
//{
//    public class FluentExample : ScenarioDrivenSpecBase
//    {
//        protected override Feature CreateFeature()
//        {
//            return new Feature("addition of two numbers")
//                .AddStory()
//                .AsA("user")
//                .IWant("my calculator to add number together")
//                .SoThat("I don't need to try and do it in my head");
//        }
//
//        [Test]
//        public void should_add_1_plus_1_correctly()
//        {
//            Feature.AddScenario()
//                .WithHelperObject<AddNumbers>()
//                .Given("I have entered 1 into the calculator")
//                .And("I have entered 1 into the calculator")
//                .When("I add the numbers")
//                .Then("the sum should be 2");
//        }
//    }
//    
//    [ActionSteps]
//    public class AddNumbers
//    {
//        private Calculator _calculator;
//
//        [BeforeScenario]
//        public void SetUp_scenario()
//        {
//            _calculator = new Calculator();
//        }
//
//        [Given(@"I have entered $number into the calculator")]
//        public void Enter_number(int number)
//        {
//            _calculator.Enter(number);
//        }
//
//        [When(@"I add the numbers")]
//        public void Add()
//        {
//            _calculator.Add();
//        }
//
//        [Then(@"the sum should be $result")]
//        public void Result(int result)
//        {
//            _calculator.Value().ShouldEqual(result);
//        }
//    }
//    
//    public class Calculator
//    {
//        private readonly Queue<int> _buffer = new Queue<int>();
//
//        public void Enter(int number)
//        {
//            _buffer.Enqueue(number);
//        }
//
//        public void Add()
//        {
//            _buffer.Enqueue(_buffer.Dequeue() + _buffer.Dequeue());
//        }
//
//        public int Value()
//        {
//            return _buffer.Peek();
//        }
//    }
//}