/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 11:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TestConstantCmdletBase.
    /// </summary>
    public class TestConstantCmdletBase : DatabaseCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = false)]
        public string ConstantName { get; set; }
        #endregion Parameters
    }
}
