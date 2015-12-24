/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2013
 * Time: 1:40 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using Interfaces;
    
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
            ConstantName = constantName;
            ConstantValue = ConstantValue;
            ConstantType = ConstantType;
        }
        
        public TestConstant(
            string constantName, 
            object constantValue, 
            System.Type constantType,
            string constantTag,
            string description)
        {
            ConstantName = constantName;
            ConstantValue = ConstantValue;
            ConstantType = ConstantType;
            ConstantTag = constantTag;
            Description = description;
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
