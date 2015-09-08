/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;
    using Interfaces;
    //using System.Linq;
    
    /// <summary>
    /// Description of SearchTmxTestResultCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Search, "TmxTestResult", DefaultParameterSetName = "Common")]
    public class SearchTmxTestResultCommand : SearchCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new SwitchParameter OrderByPassRate { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new SwitchParameter OrderByFailRate { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            CheckCmdletParameters();
            
            var dataObject = new SearchTmxTestResultDataObject {
                OrderByFailRate = OrderByFailRate,
                OrderByPassRate = OrderByPassRate,
                FilterAll = FilterAll,
                Descending = Descending,
                FilterDescriptionContains = FilterDescriptionContains,
                FilterFailed = FilterFailed,
                FilterIdContains = FilterIdContains,
                FilterNameContains = FilterNameContains,
                FilterNone = FilterNone,
                FilterNotTested = FilterNotTested,
                FilterOutAutomaticAndTechnicalResults = FilterOutAutomaticAndTechnicalResults,
                FilterOutAutomaticResults = FilterOutAutomaticResults,
                FilterPassed = FilterPassed,
                FilterPassedWithBadSmell = FilterPassedWithBadSmell,
                Id = Id,
                Name = Name,
                OrderByDateTime = OrderByDateTime,
                OrderById = OrderById,
                OrderByName = OrderByName,
                OrderByTimeSpent = OrderByTimeSpent
            };
            
            WriteObject(TmxHelper.SearchForTestResultsPS(dataObject), true);
        }
    }
}
