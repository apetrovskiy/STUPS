/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/18/2012
 * Time: 6:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TLAddinUnitTests
{
    using System;
    using TMX;
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
            
            //if (null != TMX.CommonCmdletBase.UnitTestOutput && 0 < TMX.CommonCmdletBase.UnitTestOutput.Count) {
            if (0 < PSTestLib.UnitTestOutput.Count) {
                //TMX.CommonCmdletBase.UnitTestOutput.Clear();
                PSTestLib.UnitTestOutput.Clear();
            }
            
            TLAddinData.CurrentTestLinkConnection = null;
            
            
        }
    }
}
