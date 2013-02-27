/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/20/2012
 * Time: 10:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace MoqCmdlets
{
    using System;
    using System.Management.Automation;
    using Moq;
    
    /// <summary>
    /// Description of MoqHelper.
    /// </summary>
    public static class MoqHelper
    {
        static MoqHelper()
        {
        }
        
        public static void CreateMock<T>(
            CommonCmdletBase cmdlet, 
            ref T mockedType, 
            params object[] args) where T : class
        {
//            var tt = typeof(mockedType);
//            
//            Mock<tt> mock;
//            
//            if (null != args) {
//                mock = new Mock<mockedType>(args);
//            } else {
//                mock = new Mock<mockedType>();
//            }
//            cmdlet.WriteObject(cmdlet, mock);
            //var aa = typeof(mockedType.Name);
            //Type aa = System.Type.GetType("System.Random");

            var mock = new Mock<T>();
            
Console.WriteLine("1");
            
            cmdlet.WriteObject(cmdlet, mock);
            
            
Console.WriteLine("2");
            
            cmdlet.WriteObject(cmdlet, mock.Object);
        }
    }
}
