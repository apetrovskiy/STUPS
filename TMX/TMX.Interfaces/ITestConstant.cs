/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/4/2012
 * Time: 12:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using System;
    
    /// <summary>
    /// Description of ITestConstant.
    /// </summary>
    public interface ITestConstant
    {
        int ConstantId { get; set; }
        string ConstantName { get; set; }
        object ConstantValue { get; set; }
        Type ConstantType { get; set; }
        string ConstantTag { get; set; }
        int BucketId { get; set; }
    }
}
