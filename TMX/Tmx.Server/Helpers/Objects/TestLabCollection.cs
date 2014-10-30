/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/29/2014
 * Time: 2:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server
{
    using System;
    using System.Collections.Generic;
    using Tmx.Core.Types.Remoting;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of TestLabCollection.
    /// </summary>
    public class TestLabCollection
    {
        public static List<ITestLab> TestLabs = new List<ITestLab>();
        
        public TestLabCollection()
        {
            // TestLabs.Add(new TestLab { Id = 1, Name = "default" });
            TestLabs.Add(new TestLab { Name = "default" });
        }
    }
}
