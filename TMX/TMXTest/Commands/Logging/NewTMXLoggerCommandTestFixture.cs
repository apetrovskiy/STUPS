/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/1/2013
 * Time: 2:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.Logging
{
    using System;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of NewTmxLoggerCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class NewTmxLoggerCommandTestFixture
    {
        public NewTmxLoggerCommandTestFixture()
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
