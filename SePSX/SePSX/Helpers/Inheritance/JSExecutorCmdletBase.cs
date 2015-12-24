/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/21/2012
 * Time: 11:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System.Management.Automation;

    /// <summary>
    /// Description of JSExecutorCmdletBase.
    /// </summary>
    public class JsExecutorCmdletBase : HasWebDriverInputCmdletBase
    {
        public JsExecutorCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        public string ScriptCode { get; set; }
        
        [Parameter(Mandatory = false)]
        public string[] ArgumentList { get; set; }
        #endregion Parameters
    }
}
