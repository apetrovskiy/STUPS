/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/20/2012
 * Time: 11:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Navigation
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of SwitchSeToWindowCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class SwitchSeToWindowCommandTestFixture
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
