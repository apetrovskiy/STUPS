/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17/02/2012
 * Time: 07:05 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of ITestResultDetail.
    /// </summary>
    public interface ITestResultDetail
    {
        System.DateTime Timestamp { get; }
        string Name { get; }
        void AddTestResultDetail(TestResultDetailTypes detailType, string detail);
        void AddTestResultDetail(TestResultDetailTypes detailType, ErrorRecord detail);
        object GetDetail();
    }
}
