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
    using System;
    using System.Management.Automation;
	using TMX.Interfaces;
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
            
			// 20140721
			var dataObject = new SearchCmdletBaseDataObject {
                Descending = this.Descending,
                FilterAll = this.FilterAll,
                FilterDescriptionContains = this.FilterDescriptionContains,
                FilterFailed = this.FilterFailed,
                FilterIdContains = this.FilterIdContains,
                FilterNameContains = this.FilterNameContains,
                FilterNone = this.FilterNone,
                FilterNotTested = this.FilterNotTested,
                FilterOutAutomaticAndTechnicalResults = this.FilterOutAutomaticAndTechnicalResults,
                FilterOutAutomaticResults = this.FilterOutAutomaticResults,
                FilterPassed = this.FilterPassed,
                FilterPassedWithBadSmell = this.FilterPassedWithBadSmell,
                Id = this.Id,
                Name = this.Name,
                OrderByDateTime = this.OrderByDateTime,
                OrderByFailRate = this.OrderByFailRate,
                OrderById = this.OrderById,
                OrderByName = this.OrderByName,
                OrderByPassRate = this.OrderByPassRate,
                OrderByTimeSpent = this.OrderByTimeSpent
			};
			
            // TmxHelper.SearchForSuitesPS(this);
            // 20140722
            // TmxHelper.SearchForSuitesPS(dataObject);
            WriteObject(TmxHelper.SearchForSuitesPS(dataObject), true);
        }
    }
}
