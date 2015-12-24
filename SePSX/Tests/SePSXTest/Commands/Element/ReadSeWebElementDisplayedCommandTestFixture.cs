/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2012-08-01
 * Time: 15:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Element
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of ReadSeWebElementDisplayedCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class ReadSeWebElementDisplayedCommandTestFixture
    {
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
