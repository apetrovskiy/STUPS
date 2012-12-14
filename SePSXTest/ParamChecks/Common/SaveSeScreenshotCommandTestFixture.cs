/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/26/2012
 * Time: 8:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.CheckParameters
{
    using System;
    using SePSX; using MbUnit.Framework;
    using System.Runtime.InteropServices;
    
    /// <summary>
    /// Description of SaveSeScreenshotCommand.
    /// </summary>
    [TestFixture]
    public class SaveSeScreenshotCommandTestFixture
    {
        #region Constructor
        public SaveSeScreenshotCommandTestFixture()
        {
        }
        #endregion Constructor
        
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
    
    /// <summary>
    /// Description of GetSeScreenshotCommand.
    /// </summary>
    [TestFixture]
    public class GetSeScreenshotCommandTestFixture
    {
        public GetSeScreenshotCommandTestFixture()
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
