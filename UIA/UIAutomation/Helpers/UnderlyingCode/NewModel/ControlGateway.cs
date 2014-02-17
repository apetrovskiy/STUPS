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
        public virtual List<IUiElement> GetElements(SearcherTemplateData data)
        {
            return new List<IUiElement>();
        }
    }
}
