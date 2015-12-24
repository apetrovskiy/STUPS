//using NBehave.Narrator.Framework;
//using NBehave.Spec.NUnit;
//
//namespace BddAddin
//{
//    [ActionSteps]
//    public class ExamplesSteps
//    {
//        int _cucumbers;
//        
//        [Given("there are $start cucumbers")]
//        public void GivenCucumbers(int start)
//        {
//            _cucumbers = start;
//        }
//
//        [When("I eat $x cucumbers")]
//        public void EatCucumbers(int x)
//        {
//            _cucumbers -=x;
//        }
//
//        [Then("I should have $y cucumbers")]
//        public void CucumbersLeft(int y)
//        {
//            _cucumbers.ShouldEqual(y);
//        }
//    }
//}