/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/16/2013
 * Time: 12:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AddTestCaseCmdletBase.
    /// </summary>
    public class AddTestCaseCmdletBase : TestCaseCmdletBase
    {
        public AddTestCaseCmdletBase()
        {
        }
        
        #region Parameters
//        [Parameter(Mandatory = true,
//                   Position = 0)]
//        [ValidateNotNullOrEmpty()]
//        public new string Name { get; set; }

        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty()]
        public new string Name { get; set; }
        #endregion Parameters
    }
}
