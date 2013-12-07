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
    //using System;
    using System.Management.Automation;
//    using System.Windows.Automation;
    using System.Collections;
    using System.Collections.Generic;
//    using System.Linq;
//    using System.Linq.Expressions;

    /// <summary>
    /// Description of GetCmdletBase.
    /// </summary>
    public class GetCmdletBase : HasTimeoutCmdletBase
    {
        #region Constructor
        public GetCmdletBase()
        {
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
        // 20130228
        //[Parameter(Mandatory = false,
        //           ParameterSetName = "SearchCriteria")]
        public Hashtable[] SearchCriteria { get; set; }
        #endregion Parameters
        
        protected internal List<IUiElement> GetFilteredElementsCollection(GetCmdletBase cmdlet, List<IUiElement> elementCollection)
        {
            List<IUiElement> resultCollection = new List<IUiElement>();
            
            
            
            return resultCollection;
        }
    }
}
