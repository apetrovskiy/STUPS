/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 23/01/2012
 * Time: 10:57 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of ReadAndConvertCmdletBase.
    /// </summary>
    public class ReadAndConvertCmdletBase : HasControlInputCmdletBase
    {
        #region Constructor
        public ReadAndConvertCmdletBase()
        {
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new SwitchParameter PassThru { get; set; }
        #endregion Parameters
    }
}
