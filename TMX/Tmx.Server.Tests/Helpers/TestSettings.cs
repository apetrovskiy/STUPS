/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2014
 * Time: 10:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Tests
{
    using System;
	using Tmx.Core;
	using PSTestLib;
	using Tmx.Server.Helpers.Objects;
    
    /// <summary>
    /// Description of TestSettings.
    /// </summary>
    public static class TestSettings
    {
		public static void PrepareModuleTests()
		{
			PSCmdletBase.UnitTestMode = true;
			if (0 < UnitTestOutput.Count)
				UnitTestOutput.Clear();
			TestData.ResetData();
			ClientsCollection.Clients.Clear();
		}
    }
}
