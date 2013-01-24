/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 11:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
using System.Management.Automation;

namespace UIAutomationTest.Commands.Transcript
{
    /// <summary>
    /// Description of StopUIATranscriptCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Stop-UIATranscriptCommand test")]
    public class StopUIATranscriptCommandTestFixture
    {
        public StopUIATranscriptCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
