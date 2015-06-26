/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/10/2014
 * Time: 6:02 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of ITestTask.
    /// </summary>
    public interface ITestTask : ITestTaskResultProxy, ITestTaskStatusProxy, ITestTaskCodeProxy // ITestTaskProxy
    {
        int PreviousTaskId { get; set; }
        int AfterTask { get; set; }
        bool IsActive { get; set; }
        int RetryCount { get; set; }
        bool IsCritical { get; set; }
        string Rule { get; set; }
        string StoryId { get; set; }
        string[] ExpectedResult { get; set; }
        Guid WorkflowId { get; set; }
        Guid TestRunId { get; set; }
        string GetTimeTaken();
        void SetFinishTime();
    }
    
    /*
        <activity>
            <section_name>MSI UPGRADE: gathering of the real-life data</section_name>
            *<test_name>MSI UPGRADE: gathering of the real-life data</test_name>
            *<active>1</active>
            *<type>psremoting</type>
            *<host_role>console</host_role>
            *<order>180</order>
            *<critical_point>1</critical_point>
            <user_story>1000180</user_story>
            *<step_action></step_action>
            <console_pre_action></console_pre_action><console_post_action>1012-2</console_post_action>
            <testcases></testcases>
            *<expected_result></expected_result>
            *<retry>0</retry>
            *<timeout>3600</timeout>
            <parameters>
                <a>$true</a>
                <b>FSCR0001.xml,ADCR0001.xml,VMCR0001.xml,SPCR0001.xml,IUT0001.xml,FSCR0002.xml,ADCR0002.xml,VMCR0002.xml,SPCR0002.xml</b>
                <c>c:\tests</c>
            </parameters>
        </activity>
    */
}
