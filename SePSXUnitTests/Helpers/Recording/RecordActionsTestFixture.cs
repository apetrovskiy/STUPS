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
    using System;
    using MbUnit.Framework;
    //using NUnit.Framework;
    using SePSX;
    using PSTestLib;
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
            
            TranscriptCmdletBase cmdlet = new TranscriptCmdletBase();
            cmdlet.Timeout = 10;

            IJSRecorder recorder = new FakeJSGenerator(listOfItems);

            Recorder.RecordActions(cmdlet, recorder, cmdlet.Language);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActions test")]
        [Category("Fast")]
        public void One_WebElement()
        {
            string expectedResult = "a";
            IWebElement webElement = 
                new FakeWebElement(expectedResult, "text");
            System.Collections.Generic.List<object> list =
                 new System.Collections.Generic.List<object>();
            list.Add(webElement);

            runRecordActions(list);

            Assert.AreEqual(
                expectedResult,
                ((RecordedWebElement)Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items[
                	Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items.Count - 1]).UserData["TagName"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActions test")]
        [Category("Fast")]
        public void Two_WebElements_the_Last()
        {
            string expectedResult = "a";
            IWebElement webElement = 
                new FakeWebElement("button", "OK");
            System.Collections.Generic.List<object> list =
                 new System.Collections.Generic.List<object>();
            list.Add(webElement);
            
            webElement = 
                new FakeWebElement(expectedResult, "text");
            list.Add(webElement);
            
            runRecordActions(list);
            
            Assert.AreEqual(
                expectedResult,
                ((RecordedWebElement)Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items[
                	Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items.Count - 1]).UserData["TagName"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActions test")]
        [Category("Fast")]
        public void Two_WebElements_the_First()
        {
            string expectedResult = "a";
            IWebElement webElement = 
                new FakeWebElement(expectedResult, "text");
            System.Collections.Generic.List<object> list =
                 new System.Collections.Generic.List<object>();
            list.Add(webElement);
            
            webElement = 
                new FakeWebElement("button", "OK");
            list.Add(webElement);
            
            runRecordActions(list);
            
            Assert.AreEqual(
                expectedResult,
                ((RecordedWebElement)Recorder.recordingCollection[Recorder.recordingCollection.Count - 2].Items[
                    Recorder.recordingCollection[Recorder.recordingCollection.Count - 2].Items.Count - 1]).UserData["TagName"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActions test")]
        [Category("Fast")]
        public void WebElement_and_action_the_Last()
        {
            string expectedResult = Recorder.codeGenElementClick;
            IWebElement webElement = 
                new FakeWebElement("button", "OK");
            System.Collections.Generic.List<object> list =
                 new System.Collections.Generic.List<object>();
            list.Add(webElement);
            
            webElement = 
                new FakeWebElement(Recorder.constAuxElementClicked, "");
            list.Add(webElement);
            
            runRecordActions(list);
            
            Assert.AreEqual(
                expectedResult,
                ((RecordedAction)Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items[
                	Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items.Count - 1]).UserData["code"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActions test")]
        [Category("Fast")]
        public void WebElement_and_action_the_First()
        {
            string expectedResult = Recorder.codeGenGetElement;
            IWebElement webElement = 
                new FakeWebElement("a", "text");
            System.Collections.Generic.List<object> list =
                 new System.Collections.Generic.List<object>();
            list.Add(webElement);
            
            webElement = 
                new FakeWebElement("recclicked", "");
            list.Add(webElement);
            
            runRecordActions(list);

            Assert.AreEqual(
                expectedResult,
                ((RecordedWebElement)Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items[
                	Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items.Count - 2]).UserData["code"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActions test")]
        [Category("Fast")]
        public void WebElement_and_data_the_Last()
        {
            string expectedResult = "textData";
            IWebElement webElement = 
                new FakeWebElement("button", "OK");
            System.Collections.Generic.List<object> list =
                 new System.Collections.Generic.List<object>();
            list.Add(webElement);
            
//            System.Collections.Generic.List<object> list1 =
//                new System.Collections.Generic.List<object>();
//            Dictionary<string, object> dict1 =
//                new Dictionary<string, object>();
//            dict1.Add("code", expectedResult);
//            list1.Add(dict1);
//            ReadOnlyCollection<object> dataItem =
//                new ReadOnlyCollection<object>(list1);
            
            
            
            System.Collections.Generic.List<object> list1 =
                new System.Collections.Generic.List<object>();
            Dictionary<string, object> dict1 =
                new Dictionary<string, object>();
            //dict1.Add("code", expectedResult);
            dict1.Add("key", "code");
            list1.Add(dict1);
            Dictionary<string, object> dict2 =
                new Dictionary<string, object>();
            dict2.Add("value", expectedResult);
            list1.Add(dict2);
            ReadOnlyCollection<object> dataItem =
                new ReadOnlyCollection<object>(list1);
            
            list.Add(dataItem);
            
            runRecordActions(list);
            
            Assert.AreEqual(
                expectedResult,
                ((RecordedData)Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items[
                	Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items.Count - 1]).UserData["code"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActions test")]
        [Category("Fast")]
        public void WebElement_and_data_the_First()
        {
            string expectedResult = Recorder.codeGenGetElement;
            IWebElement webElement = 
                new FakeWebElement("a", "text");
            System.Collections.Generic.List<object> list =
                 new System.Collections.Generic.List<object>();
            list.Add(webElement);
            
            System.Collections.Generic.List<object> list1 = 
                new System.Collections.Generic.List<object>();
            Dictionary<string, object> dict1 = new Dictionary<string, object>();
            dict1.Add("key1", "data1");
            list1.Add(dict1);
            Dictionary<string, object> dict2 = new Dictionary<string, object>();
            dict2.Add("key2", "data2");
            list.Add(dict2);
            ReadOnlyCollection<object> dataItem =
                new ReadOnlyCollection<object>(list1);
            
            
            list.Add(dataItem);
            
            runRecordActions(list);

            Assert.AreEqual(
                expectedResult,
                ((RecordedWebElement)Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items[
                	Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items.Count - 2]).UserData["code"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActions test")]
        [Category("Fast")]
        public void WebElement_and_action_and_data_the_Last()
        {
            string expectedResult = "textData";
            IWebElement webElement = 
                new FakeWebElement("button", "OK");
            System.Collections.Generic.List<object> list =
                 new System.Collections.Generic.List<object>();
            list.Add(webElement);
            
            webElement = 
                new FakeWebElement(Recorder.constAuxElementClicked, "");
            list.Add(webElement);
            
//            System.Collections.Generic.List<object> list1 =
//                new System.Collections.Generic.List<object>();
//            Dictionary<string, object> dict1 =
//                new Dictionary<string, object>();
//            dict1.Add("code", expectedResult);
//            list1.Add(dict1);
//            ReadOnlyCollection<object> dataItem =
//                new ReadOnlyCollection<object>(list1);
            
            
            System.Collections.Generic.List<object> list1 =
                new System.Collections.Generic.List<object>();
            Dictionary<string, object> dict1 =
                new Dictionary<string, object>();
            //dict1.Add("code", expectedResult);
            dict1.Add("key", "code");
            list1.Add(dict1);
            Dictionary<string, object> dict2 =
                new Dictionary<string, object>();
            dict2.Add("value", expectedResult);
            list1.Add(dict2);
            ReadOnlyCollection<object> dataItem =
                new ReadOnlyCollection<object>(list1);
            
            list.Add(dataItem);
            
            runRecordActions(list);
            
            Assert.AreEqual(
                expectedResult,
                ((RecordedData)Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items[
                	Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items.Count - 1]).UserData["code"]);
        }
        
        [Test] //[Test(Description="The Recorder.RecordActions test")]
        [Category("Fast")]
        public void WebElement_and_action_and_data_the_First()
        {
            string expectedResult = Recorder.codeGenGetElement;
            IWebElement webElement = 
                new FakeWebElement("a", "text");
            System.Collections.Generic.List<object> list =
                 new System.Collections.Generic.List<object>();
            list.Add(webElement);
            
            webElement = 
                new FakeWebElement("recclicked", "");
            list.Add(webElement);

            System.Collections.Generic.List<object> list1 =
                new System.Collections.Generic.List<object>();
            Dictionary<string, object> dict1 =
                new Dictionary<string, object>();
            //dict1.Add("code", expectedResult);
            dict1.Add("key", "code");
            list1.Add(dict1);
            Dictionary<string, object> dict2 =
                new Dictionary<string, object>();
            dict2.Add("value", expectedResult);
            list1.Add(dict2);
            ReadOnlyCollection<object> dataItem =
                new ReadOnlyCollection<object>(list1);
            
            list.Add(dataItem);
//Console.WriteLine("00005");
            runRecordActions(list);
//Console.WriteLine("00006");
            
//            foreach (var aaaa in ((RecordedData)Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items[
//                Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items.Count - 1]).UserData.Keys) {
//                Console.WriteLine(aaaa);
//            }
            

            Assert.AreEqual(
                expectedResult,
                ((RecordedWebElement)Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items[
                	Recorder.recordingCollection[Recorder.recordingCollection.Count - 1].Items.Count - 3]).UserData["code"]);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            Settings.CleanUpRecordingCollection();
        }
    }
}
