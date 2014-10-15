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
	using System.Xml.Linq;
	using Tmx.Core.Types.Remoting;
	using Tmx.Interfaces.Remoting;
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
    	    GIVEN_ThereAreTasksInCommonPool();
    	    WHEN_AddedImportedTasks();
    	    THEN_NumberOfCommonTasksIncreasedBy(0);
    	}
    	
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_one_task_to_the_common_pool_on_imporing_one_task()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
//    	
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_all_tasks_to_the_common_pool_on_importing_several_tasks()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
//    	
//    	// ==========================================================================================
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_one_task_to_one_client_pool()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
//    	
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_all_tasks_to_one_client_pool()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
//    	
//    	// ==========================================================================================
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_one_task_to_all_client_pools()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
//    	
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_all_tasks_to_all_client_pools()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
//    	
//    	// ==========================================================================================
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_no_tasks_to_not_matching_client_pools()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
//    	
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_one_task_to_matching_client_pools()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
//    	
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_all_tasks_to_matching_client_pools()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
    	// ==========================================================================================
    	void GIVEN_ThereAreTasksInCommonPool()
    	{
    	    TaskPool.Tasks.Add(new TestTask { Name = "task001", Id = 10 });
    	    TaskPool.Tasks.Add(new TestTask { Name = "task002", Id = 20 });
    	}
    	
    	void WHEN_AddedImportedTasks(params ITestTask[] tasks)
    	{
    	    var workflowLoader = new WorkflowLoader();
    	    // workflowLoader.ImportXdocument(new XDocument());
    	    var xDoc = new XDocument();
    	    var workflowElement = new XElement("workflow");
    	    workflowElement.Add(new XAttribute("name", "some name"));
    	    xDoc.Add(workflowElement);
    	    workflowLoader.ImportXdocument(xDoc);
    	}
    	
    	void THEN_NumberOfCommonTasksIncreasedBy(int number)
    	{
    	    Xunit.Assert.Equal(2 + number, TaskPool.Tasks.Count);
    	}
    }
}
