/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/1/2013
 * Time: 2:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest.Commands.Logging
{
    using System;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of NewTMXLoggerCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class NewTMXLoggerCommandTestFixture
    {
        public NewTMXLoggerCommandTestFixture()
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
