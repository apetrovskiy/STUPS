/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;
    using Interfaces;
    //using System.Linq;
    
    /// <summary>
    /// Description of SearchTmxTestSuiteCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Search, "TmxTestSuite", DefaultParameterSetName = "Common")]
    public class SearchTmxTestSuiteCommand : SearchCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new SwitchParameter OrderByDateTime { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            CheckCmdletParameters();
            
            var dataObject = new SearchCmdletBaseDataObject {
                Descending = Descending,
                FilterAll = FilterAll,
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
                OrderByFailRate = OrderByFailRate,
                OrderById = OrderById,
                OrderByName = OrderByName,
                OrderByPassRate = OrderByPassRate,
                OrderByTimeSpent = OrderByTimeSpent
            };
            
            WriteObject(TmxHelper.SearchForSuitesPS(dataObject), true);
        }
    }
}
