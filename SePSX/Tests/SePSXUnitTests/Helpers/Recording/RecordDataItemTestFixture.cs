/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/4/2012
 * Time: 12:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Recording
{
    using MbUnit.Framework;
    //using NUnit.Framework;
    using SePSX;
    using PSTestLib;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of RecordDataItemTestFixture.
    /// </summary>
    [TestFixture]
    public class RecordDataItemTestFixture
    {
        public RecordDataItemTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
        }
        
        private IRecordedCodeSequence generateDataItem(
            IRecordedCodeSequence codeSequence,
            ReadOnlyCollection<object> dataCollection,
            RecordedData recordingItem)
        {
            IRecordedCodeSequence result =
                Recorder.RecordDataItem(
                    (new TranscriptCmdletBase()),
                    codeSequence,
                    dataCollection,
                    recordingItem);
            return result;
        }
        
        [Test] //[Test(Description="The Recorder.RecordDataItem test")]
        [Category("Fast")]
        public void CodeSequence_Null_RecordDataItem_Null()
        {
            IRecordedCodeSequence result = null;
            IRecordedCodeSequence codeSequence = null;
            int expectedResult = (new RecordedCodeSequence()).Items.Count;

            ReadOnlyCollection<object> dataCollection = null;
            result = 
                generateDataItem(
                    codeSequence,
                    dataCollection,
                    (new RecordedData()));
            Assert.AreEqual(expectedResult, result.Items.Count);
        }
        
        [Test] //[Test(Description="The Recorder.RecordDataItem test")]
        [Category("Fast")]
        public void RecordDataItem_DataCollection_Null()
        {
            IRecordedCodeSequence result = null;
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();

            ReadOnlyCollection<object> dataCollection = null;
            IRecordedCodeSequence expectedResult = codeSequence;
            result = 
                generateDataItem(
                    codeSequence,
                    dataCollection,
                    (new RecordedData()));
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test] //[Test(Description="The Recorder.RecordDataItem test")]
        [Category("Fast")]
        public void RecordDataItem_DataCollection_Empty()
        {
            IRecordedCodeSequence result = null;
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();

            List<object> list = 
                new List<object>();
            ReadOnlyCollection<object> dataCollection =
                new ReadOnlyCollection<object>(list);
            
            IRecordedCodeSequence expectedResult = codeSequence;
            result = 
                generateDataItem(
                    codeSequence,
                    dataCollection,
                    (new RecordedData()));
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test] //[Test(Description="The Recorder.RecordDataItem test")]
        [Category("Fast")]
        public void RecordDataItem_DataCollection_Not_Empty()
        {
            IRecordedCodeSequence result = null;
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            
            List<object> list = 
                new List<object>();
            Dictionary<string, object> dict1 = new Dictionary<string, object>();
            dict1.Add("key1", "data1");
            list.Add(dict1);
            Dictionary<string, object> dict2 = new Dictionary<string, object>();
            dict2.Add("key2", "data2");
            list.Add(dict2);
            ReadOnlyCollection<object> dataCollection =
                new ReadOnlyCollection<object>(list);
            
            result = 
                generateDataItem(
                    codeSequence,
                    dataCollection,
                    (new RecordedData()));
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            Settings.CleanUpRecordingCollection();
        }
    }
}
