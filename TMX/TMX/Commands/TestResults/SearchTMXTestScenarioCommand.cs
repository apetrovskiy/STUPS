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
    /// Description of SearchTMXTestScenarioCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Search, "TMXTestScenario", DefaultParameterSetName = "Common")]
    public class SearchTMXTestScenarioCommand : SearchCmdletBase
    {
        public SearchTMXTestScenarioCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new SwitchParameter OrderByDateTime { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TMXHelper.SearchForScenariosPS(this);
        }
    }
}
