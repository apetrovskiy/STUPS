/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/9/2012
 * Time: 6:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AddTLTestCaseCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TLTestCase")]
    public class AddTLTestCaseCommand : TLTestCaseCmdletBase
    {
        public AddTLTestCaseCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   ParameterSetName = "ByName")]
        public new string Name { get; set; }
        
        [Parameter(Mandatory = false)]
        public string AuthorLogin { get; set; }
        
        [Parameter(Mandatory = true,
                   ValueFromPipeline = true,
                   ParameterSetName = "ByName")]
        public Meyn.TestLink.TestSuite InputObject { get; set; }
        
        [Parameter(Mandatory = false)]
        public string Summary { get; set; }
        
        [Parameter(Mandatory = false)]
        public string[] Keyword { get; set; }
        
        [Parameter(Mandatory = false)]
        public int Order { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter CheckDuplicatedName { get; set; }
        
        [Parameter(Mandatory = false)]
        public Meyn.TestLink.ActionOnDuplicatedName ActionDuplicatedName { get; set; }
        
        [Parameter(Mandatory = false)]
        public int ExecutionType { get; set; }
        
        [Parameter(Mandatory = false)]
        public int Importance { get; set; }
//                        "authorLogin",
//                suiteId,
//                testCaseName,
//                testProjectId,
//                summary,
//                keywords,
//                OrderedDictionary,
//                checkDuplicatedname,
//                actionDuplicatedName,
//                executionType,
//                importnce);


        [Parameter(Mandatory = false,
                   ParameterSetName = "ById")]
        internal new string[] Id { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            TLSrvAddTestCaseCommand command =
                new TLSrvAddTestCaseCommand(this);
            command.Execute();
        }
    }
}
