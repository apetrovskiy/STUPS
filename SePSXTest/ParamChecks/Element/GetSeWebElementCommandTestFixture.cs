/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2012
 * Time: 10:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    
    using OpenQA.Selenium.Remote;
    
    /// <summary>
    /// Description of GetSeWebElementCommand.
    /// </summary>
    [TestFixture]
    public class GetSeWebElementCommandTestFixture // GetCmdletBase
    {
        public GetSeWebElementCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspaceForParamChecks();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        [Test]
        [Ignore]
        public void Need_Code()
        {
            
        }
    }
}
