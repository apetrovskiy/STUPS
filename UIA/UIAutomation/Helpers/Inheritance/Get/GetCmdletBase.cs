/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 29.11.2011
 * Time: 14:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    
    using System.Collections;

    /// <summary>
    /// Description of GetCmdletBase.
    /// </summary>
    public class GetCmdletBase : HasTimeoutCmdletBase
    {
        #region Constructor
        public GetCmdletBase()
        {
            //this.WriteVerbose(this, "constructor");
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new SwitchParameter PassThru { get; set; }
        
        [Parameter(Mandatory = false)]
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "Win32")]
//        [Parameter(Mandatory = false,
//                   ParameterSetName = "UIAuto")]
        //[Parameter(Mandatory = false,
        //           ParameterSetName = "Window")]
        //[Parameter(Mandatory = false,
        //           ParameterSetName = "First")]
        public Hashtable[] SearchCriteria { get; set; }
        #endregion Parameters
                
        // 20120828
        protected ArrayList getFiltredElementsCollection(GetCmdletBase cmdlet, ArrayList elementCollection)
        {
            ArrayList resultCollection = new ArrayList();
            
            
            
            
            return resultCollection;
        }
        
    }
}
