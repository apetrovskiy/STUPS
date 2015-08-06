/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/5/2014
 * Time: 3:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core.Types.Remoting
{
    using Interfaces.Remoting;

    /// <summary>
    /// Description of TestResultsDataObject.
    /// </summary>
    public class TestResultsDataObject : ITestResultsDataObject
    {
        public string Data { get; set; }
        // public XDocument Doc { get; set; }
        // public List<ITestSuite> Data { get; set; }
    }
}
