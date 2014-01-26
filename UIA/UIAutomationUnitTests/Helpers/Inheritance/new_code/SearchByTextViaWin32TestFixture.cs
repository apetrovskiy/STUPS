/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/3/2013
 * Time: 10:50 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.Inheritance
{
    // using System;
    // using System.Collections;
    // using System.Collections.Generic;
    // using System.Collections.ObjectModel;
    // using System.Windows.Automation;
    // using UIAutomation;
    using MbUnit.Framework;// using Xunit;
    // using System.Linq;
    
    /// <summary>
    /// Description of SearchByTextViaWin32TestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class SearchByTextViaWin32TestFixture
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
