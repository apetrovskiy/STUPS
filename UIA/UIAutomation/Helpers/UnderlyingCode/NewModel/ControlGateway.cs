/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/18/2014
 * Time: 12:36 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of ControlGateway.
    /// </summary>
    public abstract class ControlGateway
    {
    	// public SingleControlSearcherData SearchData { get; set; }
    	// public virtual SearcherTemplateData SearchData { get; set; }
    	public virtual ControlSearcherTemplateData SearchData { get; set; }
    	
        // public virtual List<IUiElement> GetElements(SearcherTemplateData data)
        public virtual List<IUiElement> GetElements(ControlSearcherTemplateData data)
        {
            return new List<IUiElement>();
        }
    }
}
