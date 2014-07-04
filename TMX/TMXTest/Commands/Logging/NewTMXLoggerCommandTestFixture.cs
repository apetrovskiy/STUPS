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
    using MbUnit.Framework;using NUnit.Framework;
    
    /// <summary>
    /// Description of NewTmxLoggerCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class NewTmxLoggerCommandTestFixture
    {
        public NewTmxLoggerCommandTestFixture()
        {
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
