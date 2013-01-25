/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/25/2013
 * Time: 9:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests
{
    using System;
    using UIAutomation;
    using UIAutomation.Commands;
    using PSTestLib;
    
    /// <summary>
    /// Description of UnitTestingHelper.
    /// </summary>
    public static class UnitTestingHelper
    {
        static UnitTestingHelper()
        {
        }
        
        public static void PrepareUnitTestDataStore()
        {
            PSCmdletBase.UnitTestMode = true;
            
            if (0 < PSTestLib.UnitTestOutput.Count) {

                PSTestLib.UnitTestOutput.Clear();
            }
            
            UIAutomation.CurrentData.ResetData();
            
        }
    }
}
