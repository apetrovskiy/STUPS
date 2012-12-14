/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/3/2012
 * Time: 11:21 AM
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
    
    /// <summary>
    /// Description of RecorderComponentsTestFixture.
    /// </summary>
    [TestFixture]
    public class RecorderComponentsTestFixture
    {
        public RecorderComponentsTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
        }
        
        [Test] //[Test(Description="The UserData collection")]
        [Category("Fast")]
        public void IRecordedElementItem_Constructor()
        {
            IRecordedElementItem recAction = new RecordedWebElement();
            //NUnit.Framework.Assert.NotNull(recAction.UserData);
            Assert.IsNotNull(recAction.UserData);
        }
        
        [Test] //[Test(Description="The UserData collection")]
        [Category("Fast")]
        public void RecordedWebElement_Constructor()
        {
            RecordedWebElement recAction = new RecordedWebElement();
            //NUnit.Framework.Assert.NotNull(recAction.UserData);
            Assert.IsNotNull(recAction.UserData);
        }
        
        [Test] //[Test(Description="The UserData collection")]
        [Category("Fast")]
        public void IRecordedAction_Constructor()
        {
            IRecordedActionItem recAction = new RecordedAction();
            //NUnit.Framework.Assert.NotNull(recAction.UserData);
            Assert.IsNotNull(recAction.UserData);
        }
        
        [Test] //[Test(Description="The UserData collection")]
        [Category("Fast")]
        public void RecordedAction_Constructor()
        {
            RecordedAction recAction = new RecordedAction();
            //NUnit.Framework.Assert.NotNull(recAction.UserData);
            Assert.IsNotNull(recAction.UserData);
        }
        
        [Test] //[Test(Description="The UserData collection")]
        [Category("Fast")]
        public void IRecordedData_Constructor()
        {
            IRecordedDataItem recData = new RecordedData();
            //NUnit.Framework.Assert.NotNull(recData.UserData);
            Assert.IsNotNull(recData.UserData);
        }
        
        [Test] //[Test(Description="The UserData collection")]
        [Category("Fast")]
        public void RecordedData_Constructor()
        {
            RecordedData recData = new RecordedData();
            //NUnit.Framework.Assert.NotNull(recData.UserData);
            Assert.IsNotNull(recData.UserData);
        }
        
        [Test] //[Test(Description="The CodeSequence.Items collection")]
        [Category("Fast")]
        public void IRecordedCodeSequence_Constructor()
        {
            IRecordedCodeSequence codeSequence = new RecordedCodeSequence();
            //NUnit.Framework.Assert.NotNull(codeSequence.Items);
            Assert.IsNotNull(codeSequence.Items);
        }
        
        [Test] //[Test(Description="The CodeSequence.Items collection")]
        [Category("Fast")]
        public void RecordedCodeSequence_Constructor()
        {
            RecordedCodeSequence codeSequence = new RecordedCodeSequence();
            //NUnit.Framework.Assert.NotNull(codeSequence.Items);
            Assert.IsNotNull(codeSequence.Items);
        }
        
        
        [TearDown]
        public void DisposeRunspace()
        {
            Settings.CleanUpRecordingCollection();
        }
    }
}
