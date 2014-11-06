/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/6/2014
 * Time: 2:27 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core.Types.Remoting
{
    using System;
    using System.Collections.Generic;
    using Tmx.Interfaces.Remoting;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestResultsHolder.
    /// </summary>
    public class TestResultsHolder : ITestResultsHolder
    {
        public TestResultsHolder()
        {
            Data = new List<ITestSuite>();
        }
        
        public List<ITestSuite> Data { get; set; }
    }
}
