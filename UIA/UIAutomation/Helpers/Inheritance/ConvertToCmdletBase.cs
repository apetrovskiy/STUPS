/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08/12/2011
 * Time: 01:45 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// The ConvertCmdletBase class is the base for the ConvertFrom- and ConvertTo- cmdlets.
    /// </summary>
    public class ConvertCmdletBase : ReadAndConvertCmdletBase
    {
        #region Constructor
        public ConvertCmdletBase()
        {
            Delimiter = ',';
            
            // temporary!!!
            SelectedOnly = false;
        }
        #endregion Constructor

        #region Parameters
        [Parameter(Mandatory = false)]
        public char Delimiter { get; set; }
        
        // temporary!!!
        [Parameter(Mandatory = false)]
        public SwitchParameter SelectedOnly { get; set; }
        #endregion Parameters
    }
}
