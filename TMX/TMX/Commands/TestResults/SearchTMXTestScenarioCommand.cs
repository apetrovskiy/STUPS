/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    //using System.Linq;
    
    /// <summary>
    /// Description of SearchTmxTestScenarioCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Search, "TmxTestScenario", DefaultParameterSetName = "Common")]
    public class SearchTmxTestScenarioCommand : SearchCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new SwitchParameter OrderByDateTime { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TmxHelper.SearchForScenariosPS(this);
        }
    }
}
