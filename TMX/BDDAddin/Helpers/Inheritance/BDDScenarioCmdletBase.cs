/*
 * Created by SharpDevelop.
  * User: Alexander Petrovskiy
 * Date: 12/25/2012
 * Time: 11:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of BDDScenarioCmdletBase.
    /// </summary>
    public class BDDScenarioCmdletBase : BDDCmdletBase
    {
        public BDDScenarioCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   ValueFromPipeline = true)]
        public NBehave.Narrator.Framework.Feature InputObject { get; set; }
        
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty()]
        public string[] Given { get; set; }
        
//        [Parameter(Mandatory = true,
//                   Position = 0)]
//        [ValidateNotNullOrEmpty()]
//        public string[] AndGiven { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] GivenAction { get; set; }
        
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty()]
        public string[] When { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] WhenAction { get; set; }
        
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty()]
        public string[] Then { get; set; }
        
        [Parameter(Mandatory = false)]
        public ScriptBlock[] ThenAction { get; set; }
        #endregion Parameters
    }
}
