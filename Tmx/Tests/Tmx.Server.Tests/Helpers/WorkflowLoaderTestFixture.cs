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
    using System.Linq;
    using System.Xml.Linq;
    using Library.ObjectModel;
    using Library.ObjectModel.Objects;
    using Core.Types.Remoting;
    using Interfaces.Remoting;
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
            WHEN_AddedFakeImportedTasks();
            THEN_NumberOfCommonTasksIncreasedBy(0);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_add_8_tasks_to_the_common_pool_on_adding_a_task_collection()
        {
            GIVEN_ThereAreTasksInCommonPool();
            WHEN_ImportingTasks(TestConstants.Workflow01);
            THEN_NumberOfCommonTasksIncreasedBy(10);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_add_a_workflow_to_the_collection()
        {
            GIVEN_ThereAreTasksInCommonPool();
            var workflowId = WHEN_ImportingTasks(TestConstants.Workflow01);
            THEN_NumberOfCommonTasksIncreasedBy(10);
            THEN_workflow_has_been_added(workflowId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_add_tasks_with_workflow_id()
        {
            GIVEN_ThereAreTasksInCommonPool();
            var workflowId = WHEN_ImportingTasks(TestConstants.Workflow01);
            THEN_NumberOfCommonTasksIncreasedBy(10);
            THEN_workflow_has_been_added(workflowId);
            THEN_there_are_number_of_tasks_for_selected_workflow(10, workflowId);
        }
        
        [MbUnit.Framework.Ignore][NUnit.Framework.Ignore]
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        public void Should_add_no_tasks_if_no_valid_path_provided()
        {
            GIVEN_ThereAreTasksInCommonPool();
            var workflowId = WHEN_ImportingTasks(TestConstants.XmlPath + "wrong_path.xml");
            THEN_NumberOfCommonTasksIncreasedBy(10);
            THEN_workflow_has_been_added(workflowId);
            THEN_there_are_number_of_tasks_for_selected_workflow(10, workflowId);
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_replace_workflow_on_adding_one_with_the_same_name()
//        {
//            // GIVEN_ThereAreTasksInCommonPool();
//            GIVEN_ThereIsWorkflow();
//            var workflowId = WHEN_ImportingTasks(TestConstants.Workflow01);
//            THEN_NumberOfCommonTasksIncreasedBy(10);
//            THEN_workflow_has_been_added(workflowId);
//            THEN_there_are_number_of_tasks_for_selected_workflow(10, workflowId);
//        }
        
//        [NUnit.Framework.Test]
//        public void test_loading_real_workflow_file()
//        {
//            // var pathToFile = @"\\172.28.1.111\C$\TestHome\Modules\Tmx40\workflows\Setup.xml";
//            var pathToFile = @"E:\20150617\Setup.xml";
//            var workflowLoader = new WorkflowLoader();
//            workflowLoader.Load(pathToFile);
//        }
        
        // ==========================================================================================
        void GIVEN_ThereAreTasksInCommonPool()
        {
            TaskPool.Tasks.Add(new TestTask { Name = "task001", Id = 10, WorkflowId = new Guid() });
            TaskPool.Tasks.Add(new TestTask { Name = "task002", Id = 20, WorkflowId = new Guid() });
        }
        
//        void GIVEN_ThereIsWorkflow()
//        {
//            WorkflowCollection
//        }
        
        void WHEN_AddedFakeImportedTasks(params ITestTask[] tasks)
        {
            var workflowLoader = new WorkflowLoader();
            var xDoc = new XDocument();
            var workflowElement = new XElement("workflow");
            workflowElement.Add(new XAttribute("name", "some name"));
            xDoc.Add(workflowElement);
            var testLabElement = new XElement("testLabName", "testlab");
            workflowElement.Add(testLabElement);
            var parametersPageElement = new XElement("parametersPage", "page");
            workflowElement.Add(parametersPageElement);
            // 20150312
            workflowLoader.ImportXdocument(xDoc);
            // workflowLoader.ImportXdocument(xDoc, string.Empty);
        }
        
        Guid WHEN_ImportingTasks(string path)
        {
            var workflowLoader = new WorkflowLoader();
            workflowLoader.Load(path);
            return WorkflowCollection.Workflows.Last().Id;
        }
        
        void THEN_NumberOfCommonTasksIncreasedBy(int number)
        {
            Assert.Equal(2 + number, TaskPool.Tasks.Count);
        }
        
        void THEN_workflow_has_been_added(Guid workflowId)
        {
            Assert.Equal(true, WorkflowCollection.Workflows.Any(wfl => wfl.Id == workflowId));
        }
        
        void THEN_there_are_number_of_tasks_for_selected_workflow(int numberOfTasks, Guid workflowId)
        {
            Assert.Equal(numberOfTasks, TaskPool.Tasks.Count(task => task.WorkflowId == workflowId));
        }
    }
}
