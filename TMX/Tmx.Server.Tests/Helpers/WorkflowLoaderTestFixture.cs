/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/8/2014
 * Time: 5:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Tests.Helpers
{
    using System;
	using Xunit;
    
    /// <summary>
    /// Description of WorkflowLoaderTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class WorkflowLoaderTestFixture
    {
        public WorkflowLoaderTestFixture()
        {
            TestSettings.PrepareModuleTests();
        }
        
    	[MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
    	public void SetUp()
    	{
    	    TestSettings.PrepareModuleTests();
    	}
    	
    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
    	public void Should_add_no_tasks_to_the_common_pool_on_adding_empty_task_collection()
    	{
    	    Xunit.Assert.Equal(0, 1);
    	}
    	
    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
    	public void Should_add_one_task_to_the_common_pool_on_imporing_one_task()
    	{
    	    Xunit.Assert.Equal(0, 1);
    	}
    	
    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
    	public void Should_add_all_tasks_to_the_common_pool_on_importing_several_tasks()
    	{
    	    Xunit.Assert.Equal(0, 1);
    	}
    	
    	// ==========================================================================================
    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
    	public void Should_add_one_task_to_one_client_pool()
    	{
    	    Xunit.Assert.Equal(0, 1);
    	}
    	
    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
    	public void Should_add_all_tasks_to_one_client_pool()
    	{
    	    
    	}
    	
    	// ==========================================================================================
    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
    	public void Should_add_one_task_to_all_client_pools()
    	{
    	    Xunit.Assert.Equal(0, 1);
    	}
    	
    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
    	public void Should_add_all_tasks_to_all_client_pools()
    	{
    	    
    	}
    	
    	// ==========================================================================================
    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
    	public void Should_add_no_tasks_to_not_matching_client_pools()
    	{
    	    Xunit.Assert.Equal(0, 1);
    	}
    	
    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
    	public void Should_add_one_task_to_matching_client_pools()
    	{
    	    Xunit.Assert.Equal(0, 1);
    	}
    	
    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
    	public void Should_add_all_tasks_to_matching_client_pools()
    	{
    	    Xunit.Assert.Equal(0, 1);
    	}
    }
}
