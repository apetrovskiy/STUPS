/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/1/2013
 * Time: 2:06 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxUnitTests.Commands.Logging
{
    using System;
    using MbUnit.Framework;using NUnit.Framework;
    using PSTestLib;
    using Tmx;
    
    /// <summary>
    /// Description of NewTmxLoggerCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class NewTmxLoggerCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
        }
    }
}
