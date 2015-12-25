/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/10/2014
 * Time: 3:23 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
// using System;

namespace UIAutomationUnitTests.Commands.Get
{
    // using System.Windows.Automation;
    // using UIAutomation;
     // using Xunit;
    // using NSubstitute;
    
    /// <summary>
    /// Description of GetUiaButtonCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class GetUiaButtonCommandTestFixture
    {
        public GetUiaButtonCommandTestFixture()
        {
            FakeFactory.Init();
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
        }
    }
}
