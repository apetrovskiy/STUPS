/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/20/2014
 * Time: 9:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ISearchCmdletBaseDataObject.
    /// </summary>
    public interface ISearchCmdletBaseDataObject : ICommonDataObject
    {
        string Name { get; set; }
        string Id { get; set; }
        SwitchParameter FilterAll { get; set; }
        string FilterNameContains { get; set; }
        string FilterIdContains { get; set; }
        string FilterDescriptionContains { get; set; }
        SwitchParameter FilterPassed { get; set; }
        SwitchParameter FilterFailed { get; set; }
        SwitchParameter FilterNotTested { get; set; }
        SwitchParameter FilterPassedWithBadSmell { get; set; }
        SwitchParameter FilterOutAutomaticResults { get; set; }
        SwitchParameter FilterOutAutomaticAndTechnicalResults { get; set; }
        SwitchParameter OrderByTimeSpent { get; set; }
        SwitchParameter OrderByDateTime { get; set; }
        SwitchParameter OrderByName { get; set; }
        SwitchParameter OrderById { get; set; }
        SwitchParameter OrderByPassRate { get; set; }
        SwitchParameter OrderByFailRate { get; set; }
        SwitchParameter Descending { get; set; }
        SwitchParameter FilterNone { get; set; }
    }
}
