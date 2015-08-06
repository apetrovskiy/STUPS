/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/6/2014
 * Time: 2:27 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting
{
    using System.Collections.Generic;
    using TestStructure;

    /// <summary>
    /// Description of ITestResultsHolder.
    /// </summary>
    public interface ITestResultsHolder
    {
        List<ITestSuite> Data { get; set; }
    }
}
