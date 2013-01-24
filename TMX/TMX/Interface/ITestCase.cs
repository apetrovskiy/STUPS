/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/4/2012
 * Time: 12:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ITestCase.
    /// </summary>
    public interface ITestCase
    {
        int TestCaseId { get; set; }
        string TestCaseName { get; set; }
        string TestCaseNumber { get; set; }
        ScriptBlock BeforeCode { get; set; }
        ScriptBlock MainCode { get; set; }
        ScriptBlock AfterCode { get; set; }
        string TestCaseTag { get; set; }
    }
}
