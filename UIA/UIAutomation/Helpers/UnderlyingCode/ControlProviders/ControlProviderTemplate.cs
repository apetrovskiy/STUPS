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
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of ControlGateway.
    /// </summary>
    public abstract class ControlProviderTemplate
    {
        public virtual ControlSearcherTemplateData SearchData { get; set; }
        internal virtual SearcherTemplateData SearcherData { get; set; }
        internal virtual List<IUiElement> ResultCollection { get; set; }
        internal abstract List<IUiElement> FilterElements(SingleControlSearcherData controlSearcherData, List<IUiElement> initialCollection);
        internal abstract List<IUiElement> LoadElements(SingleControlSearcherData controlSearcherData);
        
        public virtual List<IUiElement> GetElements(ControlSearcherTemplateData data)
        {
            ResultCollection = new List<IUiElement>();
            
            SingleControlSearcherData controlSearcherData = null;
            if (null != data) {
                controlSearcherData = data.ConvertControlSearcherTemplateDataToSingleControlSearcherData();
                SearchData = data;
            }
            if (null == controlSearcherData) {
                controlSearcherData = SearchData.ConvertControlSearcherTemplateDataToSingleControlSearcherData();
                
            }
            if (null == controlSearcherData) return ResultCollection;
            
            if (!string.IsNullOrEmpty(controlSearcherData.ContainsText)) {
                controlSearcherData.Name = controlSearcherData.Value = controlSearcherData.ContainsText;
            }
            
            ResultCollection = FilterElements(controlSearcherData, LoadElements(controlSearcherData));
            
            return ResultCollection;
        }
        
//        public virtual ControlSearcherTemplateData SearchData { get; set; }
//        
//        public virtual List<IUiElement> GetElements(ControlSearcherTemplateData data)
//        {
//            return new List<IUiElement>();
//        }
    }
}
