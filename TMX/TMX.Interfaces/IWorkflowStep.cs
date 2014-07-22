/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/8/2013
 * Time: 6:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;

    /// <summary>
    /// Description of IWorkflowStep.
    /// </summary>
    public interface IWorkflowStep
    {
        //int DbId { get; set; }
        //string Name { get; }
        //string Id { get; }
        
        int Order { get; set; }
        // section name
        string TestName { get; set; }
        bool IsActive { get; set; }
        string HostRole { get; set; }
        bool IsCriticalPoint { get; set; }
        string UserStory { get; set; }
        // test cases
        int Timeout { get; set; }
        List<string> InputParameters { get; set; }
        List<string> OutputParameters { get; set; }
        Hashtable SpecialParameters { get; set; }
        
        
//            <section_name>Installation of SPCR</section_name>
//            <test_name>Running the setup wizard (SPCR)</test_name>
//            <active>0</active>
//            <host_role>console</host_role>
//            <order>20</order>
//            <critical_point>1</critical_point>
//            <user_story></user_story>
//            <testcases></testcases>
//            <timeout>300</timeout>
//            <setup_parameters>
//                <do_install>1</do_install>
//                <clear_product_data>1</clear_product_data>
//                <!--<uninstall_name>%netwrix%sharepoint%</uninstall_name>-->
//                <uninstall_name>%netwrix%</uninstall_name>
//                <acronym>SPCR</acronym>
//                <version>2.0</version>
//                <path_to_distrib>\\njvms42\Builds_to_test</path_to_distrib>
//                <DISTRIB_NAME>spcrfull_setup.msi</DISTRIB_NAME>
//                <code>SPCR</code>
//            </setup_parameters>
//            <return_values>
//                <a>path_tp_package</a>
//            </return_values>
    }
}
