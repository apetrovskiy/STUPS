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
    using System.Management.Automation;
    using System.Collections;

    /// <summary>
    /// Description of GetCmdletBase.
    /// </summary>
    public class GetCmdletBase : HasTimeoutCmdletBase
    {
        #region Parameters
        [UiaParameter][Parameter(Mandatory = false)]
        internal new SwitchParameter PassThru { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false)]
//        [UiaParameterNotUsed][Parameter(Mandatory = false,
//                   ParameterSetName = "Win32")]
//        [UiaParameterNotUsed][Parameter(Mandatory = false,
//                   ParameterSetName = "UIAuto")]
        //[UiaParameterNotUsed][Parameter(Mandatory = false,
        //           ParameterSetName = "Window")]
        //[UiaParameterNotUsed][Parameter(Mandatory = false,
        //           ParameterSetName = "First")]
        // 20130228
        //[UiaParameterNotUsed][Parameter(Mandatory = false,
        //           ParameterSetName = "SearchCriteria")]
        public Hashtable[] SearchCriteria { get; set; }
        #endregion Parameters
        
        // protected internal List<IUiElement> GetFilteredElementsCollection(GetCmdletBase cmdlet, List<IUiElement> elementCollection)
//        protected internal List<IUiElement> GetFilteredElementsCollection(List<IUiElement> elementCollection)
//        {
//            List<IUiElement> resultCollection = new List<IUiElement>();
//            
//            
//            
//            return resultCollection;
//        }
    }
}
