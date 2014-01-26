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
    using MbUnit.Framework;// using Xunit;
    // using NSubstitute;
    
    /// <summary>
    /// Description of GetUiaButtonCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class GetUiaButtonCommandTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
    }
}
