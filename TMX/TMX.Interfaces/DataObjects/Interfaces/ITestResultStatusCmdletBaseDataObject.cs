﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/20/2014
 * Time: 9:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using TestStructure;

    /// <summary>
    /// Description of ITestResultStatusCmdletBaseDataObject.
    /// </summary>
    public interface ITestResultStatusCmdletBaseDataObject : ICommonDataObject
    {
        string Id { get; set; }
        TestStatuses TestResultStatus { get; set; }
        TestResultOrigins TestOrigin { get; set; }
    }
}
