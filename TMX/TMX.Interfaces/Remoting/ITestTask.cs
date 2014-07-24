/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/10/2014
 * Time: 6:02 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;
namespace Tmx.Interfaces.Remoting
{
	/// <summary>
	/// Description of ITestTask.
	/// </summary>
	public interface ITestTask
	{
		int Id { get; set; }
		// int Order { get; set; }
		int PreviousTaskId { get; set; }
		bool On { get; set; }
		bool Completed { get; set; }
		int Timeout { get; set; }
		int RetryCount { get; set; }
		bool IsCritical { get; set; }
		
		TestTaskExecutionTypes TaskType { get; set; }
		string Rule { get; set; }
		
		string Name { get; set; }
		string StoryId { get; set; }
		ITestTaskAction[] BeforeAction { get; set; }
		ITestTaskAction[] Action { get; set; }
		ITestTaskAction[] AfterAction { get; set; }
		// string[] ExpectedResult { get; set; } // ?
		// List<object> ExpectedResult { get; set; }
		// object[] ExpectedResult { get; set; }
		string[] ExpectedResult { get; set; }
		
		TestTaskStatuses Status { get; set; }
		// List<object> TaskResult { get; set; }
		// object[] TaskResult { get; set; }
		string[] TaskResult { get; set; }
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
