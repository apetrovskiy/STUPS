/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/25/2012
 * Time: 11:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of BDDCmdletBase.
    /// </summary>
    public class BDDCmdletBase : TMX.CommonCmdletBase
    {
        public BDDCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new string Name { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new string Id { get; set; }
        #endregion Parameters
        
        protected bool CheckInputFeature(NBehave.Narrator.Framework.Feature feature)
        {
            bool result = false;
            
            if (null == feature) {
                return result;
                //cmdlet.writeer
            }
            
            if (null == (feature as NBehave.Narrator.Framework.Feature)) {
                return result;
            }
            
            result = true;
            
            return result;
        }
    }
}
