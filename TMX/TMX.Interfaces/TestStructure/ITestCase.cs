/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/4/2012
 * Time: 12:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.TestStructure
{
    using System;
    using Remoting;

    // using System.Management.Automation;
    
    /// <summary>
    /// Description of ITestCase.
    /// </summary>
    public interface ITestCase
    {
        // int DbId { get; set; }
        int UniqueId { get; set; }
        //int TestCaseId { get; set; }
        string TestCaseId { get; set; }
        string TestCaseName { get; set; }
        // 20130617
        //string TestCaseNumber { get; set; }
        //ScriptBlock[] AlternateBeforeTest { get; set; }
        // 20141211
        // ScriptBlock[] TestCode { get; set; }
        ICodeBlock[] TestCode { get; set; }
        //ScriptBlock[] AlternateAfterTest { get; set; }
        string TestCaseTag { get; set; }
        object[] TestCodeParameters { get; set; }
    }
}
