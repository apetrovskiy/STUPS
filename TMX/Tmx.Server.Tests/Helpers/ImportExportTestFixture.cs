/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/22/2014
 * Time: 7:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Tests.Helpers
{
    using System;
    using System.Linq;
	using System.Xml.Linq;
	using Tmx.Core.Types.Remoting;
	using Tmx.Interfaces.Remoting;
	using Xunit;
    
    /// <summary>
    /// Description of ImportExportTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ImportExportTestFixture
    {
        public ImportExportTestFixture()
        {
            // TestSettings.PrepareModuleTests();
        }
        
    	[MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
    	public void SetUp()
    	{
    	    // TestSettings.PrepareModuleTests();
    	}
    	
    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
    	public void Should_import_exported_data()
    	{
    	    GIVEN_exported_test_results();
    	    WHEN_AddedFakeImportedTasks();
    	    THEN_NumberOfCommonTasksIncreasedBy(0);
    	}
    	
    	
    }
}
