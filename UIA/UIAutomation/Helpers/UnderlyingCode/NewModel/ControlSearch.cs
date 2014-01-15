/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/15/2014
 * Time: 1:06 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of ControlSearch.
    /// </summary>
    public class ControlSearch : SearchTemplate
    {
        public override string TimeoutExpirationInformation { get; set; }
        
        public override void OnSleepAction()
        {
            
        }
        
        public override void BeforeSearchHook()
        {
            
        }
        
        public override void AfterSearchHook()
        {
            
        }
        
        public override List<IUiElement> SearchForElements(SearchTemplateData data)
        {
            return new List<IUiElement>();
        }
    }
}
