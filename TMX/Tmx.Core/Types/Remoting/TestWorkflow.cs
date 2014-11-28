/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/8/2014
 * Time: 9:07 PM
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
    /// Description of TestWorkflow.
    /// </summary>
    public class TestWorkflow : ITestWorkflow
    {
        ITestLab _testLab;
        
        public TestWorkflow(ITestLab testLab)
        {
            Id = Guid.NewGuid();
            _testLab = testLab;
        }
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid TestLabId {
            get { return _testLab.Id; }
        }
        
        public void SetTestLab(ITestLab testLab)
        {
            _testLab = testLab;
        }
        
		public string ParametersPageName { get; set; }
    }
}
