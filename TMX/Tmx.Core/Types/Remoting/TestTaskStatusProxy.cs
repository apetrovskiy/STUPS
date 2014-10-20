/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/20/2014
 * Time: 4:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core.Types.Remoting
{
    using System;
	using System.Collections.Generic;
	using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of TestTaskStatusProxy.
    /// </summary>
    public class TestTaskStatusProxy : ITestTaskStatusProxy
    {
        public int Id { get; set; }
        public TestTaskStatuses TaskStatus { get; set; }
        public bool TaskFinished { get; set; }
    }
}
