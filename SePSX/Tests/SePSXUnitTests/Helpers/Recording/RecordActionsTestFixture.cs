/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/4/2012
 * Time: 12:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Recording
{
    using MbUnit.Framework;
    //using NUnit.Framework;
    using SePSX;
    using OpenQA.Selenium;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of RecordActionsTestFixture.
    /// </summary>
    [TestFixture]
    public class RecordActionsTestFixture
    {
        public RecordActionsTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
        }
        
        private void runRecordActions(System.Collections.Generic.List<object> listOfItems)
        {
            IWebDriver webDriver = new FakeWebDriver();
            CurrentData.CurrentWebDriver = webDriver;
            
            var cmdlet = new TranscriptCmdletBase();
            cmdlet.Timeout = 10;

            IJsRecorder recorder = new FakeJSGenerator(listOfItems);

            Recorder.RecordActions(cmdlet, recorder, cmdlet.Language);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActions test")]
        [Category("Fast")]
        public void One_WebElement()
        {
            const string expectedResult = "a";
            IWebElement webElement = 
                new FakeWebElement(expectedResult, "text");
            var list = new List<object>();
            list.Add(webElement);

            runRecordActions(list);

            Assert.AreEqual(
                expectedResult,
                ((RecordedWebElement)Recorder.RecordingCollection[Recorder.RecordingCollection.Count - 1].Items[
                    Recorder.RecordingCollection[Recorder.RecordingCollection.Count - 1].Items.Count - 1]).UserData["TagName"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActions test")]
        [Category("Fast")]
        public void Two_WebElements_the_Last()
        {
            const string expectedResult = "a";
            IWebElement webElement = 
                new FakeWebElement("button", "OK");
            var list = new List<object>();
            list.Add(webElement);
            
            webElement = 
                new FakeWebElement(expectedResult, "text");
            list.Add(webElement);
            
            runRecordActions(list);
            
            Assert.AreEqual(
                expectedResult,
                ((RecordedWebElement)Recorder.RecordingCollection[Recorder.RecordingCollection.Count - 1].Items[
                    Recorder.RecordingCollection[Recorder.RecordingCollection.Count - 1].Items.Count - 1]).UserData["TagName"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActions test")]
        [Category("Fast")]
        public void Two_WebElements_the_First()
        {
            const string expectedResult = "a";
            IWebElement webElement = 
                new FakeWebElement(expectedResult, "text");
            var list = new List<object>();
            list.Add(webElement);
            
            webElement = 
                new FakeWebElement("button", "OK");
            list.Add(webElement);
            
            runRecordActions(list);
            
            Assert.AreEqual(
                expectedResult,
                ((RecordedWebElement)Recorder.RecordingCollection[Recorder.RecordingCollection.Count - 2].Items[
                    Recorder.RecordingCollection[Recorder.RecordingCollection.Count - 2].Items.Count - 1]).UserData["TagName"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActions test")]
        [Category("Fast")]
        public void WebElement_and_action_the_Last()
        {
            const string expectedResult = Recorder.CodeGenElementClick;
            IWebElement webElement = 
                new FakeWebElement("button", "OK");
            var list = new List<object>();
            list.Add(webElement);
            
            webElement = 
                new FakeWebElement(Recorder.ConstAuxElementClicked, "");
            list.Add(webElement);
            
            runRecordActions(list);
            
            Assert.AreEqual(
                expectedResult,
                ((RecordedAction)Recorder.RecordingCollection[Recorder.RecordingCollection.Count - 1].Items[
                    Recorder.RecordingCollection[Recorder.RecordingCollection.Count - 1].Items.Count - 1]).UserData["code"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActions test")]
        [Category("Fast")]
        public void WebElement_and_action_the_First()
        {
            const string expectedResult = Recorder.CodeGenGetElement;
            IWebElement webElement = 
                new FakeWebElement("a", "text");
            var list = new List<object>();
            list.Add(webElement);
            
            webElement = 
                new FakeWebElement("recclicked", "");
            list.Add(webElement);
            
            runRecordActions(list);

            Assert.AreEqual(
                expectedResult,
                ((RecordedWebElement)Recorder.RecordingCollection[Recorder.RecordingCollection.Count - 1].Items[
                    Recorder.RecordingCollection[Recorder.RecordingCollection.Count - 1].Items.Count - 2]).UserData["code"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActions test")]
        [Category("Fast")]
        public void WebElement_and_data_the_Last()
        {
            const string expectedResult = "textData";
            IWebElement webElement = 
                new FakeWebElement("button", "OK");
            var list = new List<object>();
            list.Add(webElement);
            
//            System.Collections.Generic.List<object> list1 =
//                new System.Collections.Generic.List<object>();
//            Dictionary<string, object> dict1 =
//                new Dictionary<string, object>();
//            dict1.Add("code", expectedResult);
//            list1.Add(dict1);
//            ReadOnlyCollection<object> dataItem =
//                new ReadOnlyCollection<object>(list1);
            
            
            
            var list1 = new List<object>();
            var dict1 = new Dictionary<string, object>();
            //dict1.Add("code", expectedResult);
            dict1.Add("key", "code");
            list1.Add(dict1);
            var dict2 = new Dictionary<string, object>();
            dict2.Add("value", expectedResult);
            list1.Add(dict2);
            var dataItem = new ReadOnlyCollection<object>(list1);
            
            list.Add(dataItem);
            
            runRecordActions(list);
            
            Assert.AreEqual(
                expectedResult,
                ((RecordedData)Recorder.RecordingCollection[Recorder.RecordingCollection.Count - 1].Items[
                    Recorder.RecordingCollection[Recorder.RecordingCollection.Count - 1].Items.Count - 1]).UserData["code"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActions test")]
        [Category("Fast")]
        public void WebElement_and_data_the_First()
        {
            const string expectedResult = Recorder.CodeGenGetElement;
            IWebElement webElement = 
                new FakeWebElement("a", "text");
            var list = new List<object>();
            list.Add(webElement);
            
            var list1 = new List<object>();
            var dict1 = new Dictionary<string, object>();
            dict1.Add("key1", "data1");
            list1.Add(dict1);
            var dict2 = new Dictionary<string, object>();
            dict2.Add("key2", "data2");
            list.Add(dict2);
            var dataItem = new ReadOnlyCollection<object>(list1);
            
            
            list.Add(dataItem);
            
            runRecordActions(list);

            Assert.AreEqual(
                expectedResult,
                ((RecordedWebElement)Recorder.RecordingCollection[Recorder.RecordingCollection.Count - 1].Items[
                    Recorder.RecordingCollection[Recorder.RecordingCollection.Count - 1].Items.Count - 2]).UserData["code"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActions test")]
        [Category("Fast")]
        public void WebElement_and_action_and_data_the_Last()
        {
            const string expectedResult = "textData";
            IWebElement webElement = 
                new FakeWebElement("button", "OK");
            var list = new List<object>();
            list.Add(webElement);
            
            webElement = new FakeWebElement(Recorder.ConstAuxElementClicked, "");
            list.Add(webElement);
            
//            System.Collections.Generic.List<object> list1 =
//                new System.Collections.Generic.List<object>();
//            Dictionary<string, object> dict1 =
//                new Dictionary<string, object>();
//            dict1.Add("code", expectedResult);
//            list1.Add(dict1);
//            ReadOnlyCollection<object> dataItem =
//                new ReadOnlyCollection<object>(list1);
            
            
            var list1 = new List<object>();
            var dict1 = new Dictionary<string, object>();
            //dict1.Add("code", expectedResult);
            dict1.Add("key", "code");
            list1.Add(dict1);
            var dict2 = new Dictionary<string, object>();
            dict2.Add("value", expectedResult);
            list1.Add(dict2);
            var dataItem = new ReadOnlyCollection<object>(list1);
            
            list.Add(dataItem);
            
            runRecordActions(list);
            
            Assert.AreEqual(
                expectedResult,
                ((RecordedData)Recorder.RecordingCollection[Recorder.RecordingCollection.Count - 1].Items[
                    Recorder.RecordingCollection[Recorder.RecordingCollection.Count - 1].Items.Count - 1]).UserData["code"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActions test")]
        [Category("Fast")]
        public void WebElement_and_action_and_data_the_First()
        {
            const string expectedResult = Recorder.CodeGenGetElement;
            IWebElement webElement = new FakeWebElement("a", "text");
            var list = new List<object>();
            list.Add(webElement);
            
            webElement = new FakeWebElement("recclicked", "");
            list.Add(webElement);

            var list1 = new List<object>();
            var dict1 = new Dictionary<string, object>();
            //dict1.Add("code", expectedResult);
            dict1.Add("key", "code");
            list1.Add(dict1);
            var dict2 = new Dictionary<string, object>();
            dict2.Add("value", expectedResult);
            list1.Add(dict2);
            var dataItem = new ReadOnlyCollection<object>(list1);
            
            list.Add(dataItem);
            runRecordActions(list);
            
//            foreach (var aaaa in ((RecordedData)Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items[
//                Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items.Count - 1]).UserData.Keys) {
//                Console.WriteLine(aaaa);
//            }
            
            Assert.AreEqual(
                expectedResult,
                ((RecordedWebElement)Recorder.RecordingCollection[Recorder.RecordingCollection.Count - 1].Items[
                    Recorder.RecordingCollection[Recorder.RecordingCollection.Count - 1].Items.Count - 3]).UserData["code"]);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            Settings.CleanUpRecordingCollection();
        }
    }
}
