/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/5/2014
 * Time: 5:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Commands.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;using Xunit;
    using System.Linq;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUIAControlContextMenuCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class InvokeUIAControlContextMenuCommandTestFixture
    {
        public InvokeUIAControlContextMenuCommandTestFixture()
        {
            FakeFactory.Init();
        }
        
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
