/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2013
 * Time: 1:40 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    using System.Collections.Generic;
	using TMX.Interfaces;
    
    /// <summary>
    /// Description of TestConstant.
    /// </summary>
    public class TestConstant : ITestConstant
    {
        public TestConstant(
            string constantName, 
            object constantValue, 
            System.Type constantType)
        {
            this.ConstantName = constantName;
            this.ConstantValue = ConstantValue;
            this.ConstantType = ConstantType;
        }
        
        public TestConstant(
            string constantName, 
            object constantValue, 
            System.Type constantType,
            string constantTag,
            string description)
        {
            this.ConstantName = constantName;
            this.ConstantValue = ConstantValue;
            this.ConstantType = ConstantType;
            this.ConstantTag = constantTag;
            this.Description = description;
        }
        
        public int ConstantId { get; set; }
        public string ConstantName { get; set; }
        public object ConstantValue { get; set; }
        public System.Type ConstantType { get; set; }
        public string ConstantTag { get; set; }
        public string Description { get; set; }
        public int BucketId { get; set; }
    }
}
