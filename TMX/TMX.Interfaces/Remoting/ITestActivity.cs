/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/10/2014
 * Time: 6:02 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Interfaces.Remoting
{
	/// <summary>
	/// Description of ITestActivity.
	/// </summary>
	public interface ITestActivity
	{
		int Id { get; set; }
		string Name { get; set; }
		ITestActivityAction[] Action { get; set; }
		string[] ExpectedResult { get; set; }
		int ExecutionType { get; set; }
		bool On { get; set; }
		string HostId { get; set; }
		TestActivityStatuses Status { get; set; }
		int Timeout { get; set; }
		int Retry { get; set; }
		bool IsCritical { get; set; }
		int Order { get; set; }
		TestActivityTypes ActivityType { get; set; }
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
