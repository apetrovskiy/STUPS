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
    using System;
    using System.Management.Automation;
	using TMX.Interfaces;
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
            
			// 20140720
            // TmxHelper.SearchForTestResultsPS(this);
            var dataObject = new SearchTmxTestResultDataObject {
                OrderByFailRate = this.OrderByFailRate,
                OrderByPassRate = this.OrderByPassRate,
                FilterAll = this.FilterAll,
                Descending = this.Descending,
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
                OrderById = this.OrderById,
                OrderByName = this.OrderByName,
                OrderByTimeSpent = this.OrderByTimeSpent
            };
            
            // 20140722
            // TmxHelper.SearchForTestResultsPS(dataObject);
            WriteObject(TmxHelper.SearchForTestResultsPS(dataObject), true);
        }
    }
}
