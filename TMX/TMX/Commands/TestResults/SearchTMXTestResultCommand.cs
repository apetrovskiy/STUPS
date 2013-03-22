/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    //using System.Linq;
    
    /// <summary>
    /// Description of SearchTMXTestResultCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Search, "TMXTestResult", DefaultParameterSetName = "Common")]
    public class SearchTMXTestResultCommand : SearchCmdletBase
    {
        public SearchTMXTestResultCommand()
        {
            if (TestData.TestSuites.Count == 0) {
                TestData.InitTestData();
            }
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new SwitchParameter OrderByPassRate { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new SwitchParameter OrderByFailRate { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TMXHelper.SearchForTestResultsPS(this);
        }
    }
}
