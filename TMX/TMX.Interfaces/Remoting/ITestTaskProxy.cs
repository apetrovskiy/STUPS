/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/20/2014
 * Time: 1:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of ITestTaskProxy.
    /// </summary>
    public interface ITestTaskProxy
    {
        int Id { get; set; }
        TestTaskStatuses TaskStatus { get; set; }
        int ClientId { get; set; }
    }
}
