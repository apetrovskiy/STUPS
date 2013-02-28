/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 2/28/2013
 * Time: 2:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TMX.Helpers.Inheritance
{
    /// <summary>
    /// Description of MultipleNamesCmdletBase.
    /// </summary>
    public class MultipleNamesCmdletBase : TFSCmdletBase
    {
        public MultipleNamesCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false,
                   Position = 0)]
        [ValidateNotNullOrEmpty()]
        public new string[] Name { get; set; }
        #endregion Parameters
    }
}
