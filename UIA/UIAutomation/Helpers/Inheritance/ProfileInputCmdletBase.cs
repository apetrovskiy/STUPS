/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/12/2012
 * Time: 11:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
namespace UIAutomation
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ProfileInputCmdletBase.
    /// </summary>
    public class ProfileInputCmdletBase : ProfileCmdletBase
    {
        #region Parameters
        [UiaParameter][Parameter(Mandatory = true,
                   ParameterSetName = "Input",
                   ValueFromPipeline = true,
                   Position = 0)]
        public Profile InputObject { get; set; }
        #endregion Parameters
    }
}
