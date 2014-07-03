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
	using TMX.Interfaces;
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
        public TestPlatform(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }
        
        public virtual int DbId { get; set; }
        
        public virtual string Name { get; set; }
        public virtual string Id { get; set; }
        public virtual string Description { get; set; }

        public virtual string OperatingSystem { get; set; }
        public virtual string Version { get; set; }
        public virtual string Architecture { get; set; }
        public virtual string Language { get; set; }
    }
}
