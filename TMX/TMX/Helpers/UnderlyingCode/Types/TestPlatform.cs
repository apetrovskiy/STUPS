/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/25/2013
 * Time: 11:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    //using System.Collections.Generic;
    //using System.Management.Automation;
    //using System.Collections;
    //using System.Linq;
    //using System.Linq.Expressions;
    
    /// <summary>
    /// Description of TestPlatform.
    /// </summary>
    public class TestPlatform : ITestPlatform
    {
        public TestPlatform()
        {
        }
        
        public string Name { get; set; }
        public string Id { get; set; }

        public string OperatingSystem { get; set; }
        public string Version { get; set; }
    }
}
