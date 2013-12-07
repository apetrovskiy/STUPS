/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    //using System.Linq;
    
    /// <summary>
    /// Description of SearchTmxTestSuiteCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Search, "TmxTestSuite", DefaultParameterSetName = "Common")]
    public class SearchTmxTestSuiteCommand : SearchCmdletBase
    {
        public SearchTmxTestSuiteCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new SwitchParameter OrderByDateTime { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TmxHelper.SearchForSuitesPS(this);
        }
    }
}
