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
    using Core.Types.Remoting;
    using Interfaces.Remoting;
    using Logic.ObjectModel;
    using Logic.ObjectModel.Objects;
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
        public void ShouldAddNoTasksToTheCommonPoolOnAddingEmptyTaskCollection()
        {
            GivenThereAreTasksInCommonPool();
            WhenAddedFakeImportedTasks();
            ThenNumberOfCommonTasksIncreasedBy(0);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldAdd8TasksToTheCommonPoolOnAddingATaskCollection()
        {
            GivenThereAreTasksInCommonPool();
            WhenImportingTasks(TestConstants.Workflow01);
            ThenNumberOfCommonTasksIncreasedBy(10);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldAddAWorkflowToTheCollection()
        {
            GivenThereAreTasksInCommonPool();
            var workflowId = WhenImportingTasks(TestConstants.Workflow01);
            ThenNumberOfCommonTasksIncreasedBy(10);
            ThenWorkflowHasBeenAdded(workflowId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldAddTasksWithWorkflowId()
        {
            GivenThereAreTasksInCommonPool();
            var workflowId = WhenImportingTasks(TestConstants.Workflow01);
            ThenNumberOfCommonTasksIncreasedBy(10);
            ThenWorkflowHasBeenAdded(workflowId);
            ThenThereAreNumberOfTasksForSelectedWorkflow(10, workflowId);
        }
        
        [MbUnit.Framework.Ignore][NUnit.Framework.Ignore]
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        public void ShouldAddNoTasksIfNoValidPathProvided()
        {
            GivenThereAreTasksInCommonPool();
            var workflowId = WhenImportingTasks(TestConstants.XmlPath + "wrong_path.xml");
            ThenNumberOfCommonTasksIncreasedBy(10);
            ThenWorkflowHasBeenAdded(workflowId);
            ThenThereAreNumberOfTasksForSelectedWorkflow(10, workflowId);
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_replace_workflow_on_adding_one_with_the_same_name()
//        {
//            // GivenThereAreTasksInCommonPool();
//            GIVEN_ThereIsWorkflow();
//            var workflowId = WhenImportingTasks(TestConstants.Workflow01);
//            ThenNumberOfCommonTasksIncreasedBy(10);
//            ThenWorkflowHasBeenAdded(workflowId);
//            ThenThereAreNumberOfTasksForSelectedWorkflow(10, workflowId);
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
        void GivenThereAreTasksInCommonPool()
        {
            // 20150904
            TaskPool.Tasks.Add(new TestTask { Name = "task001", Id = 10, WorkflowId = new Guid() });
            TaskPool.Tasks.Add(new TestTask { Name = "task002", Id = 20, WorkflowId = new Guid() });
            // TaskPool.Tasks.Add(new TestTask (TestTaskRuntimeTypes.Powershell) { Name = "task001", Id = 10, WorkflowId = new Guid() });
            // TaskPool.Tasks.Add(new TestTask (TestTaskRuntimeTypes.Powershell) { Name = "task002", Id = 20, WorkflowId = new Guid() });
        }
        
        void WhenAddedFakeImportedTasks(params ITestTask[] tasks)
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
            workflowLoader.ImportXdocumentAndCreateWorkflowAndTasks(xDoc, workflowLoader.AddWorkflowAndReturnWorkflowId(xDoc, string.Empty));
        }
        
        Guid WhenImportingTasks(string path)
        {
            var workflowLoader = new WorkflowLoader();
            workflowLoader.Load(path);
            return WorkflowCollection.Workflows.Last().Id;
        }
        
        void ThenNumberOfCommonTasksIncreasedBy(int number)
        {
            Assert.Equal(2 + number, TaskPool.Tasks.Count);
        }
        
        void ThenWorkflowHasBeenAdded(Guid workflowId)
        {
            Assert.Equal(true, WorkflowCollection.Workflows.Any(workflow => workflow.Id == workflowId));
        }
        
        void ThenThereAreNumberOfTasksForSelectedWorkflow(int numberOfTasks, Guid workflowId)
        {
            Assert.Equal(numberOfTasks, TaskPool.Tasks.Count(task => task.WorkflowId == workflowId));
        }
    }
}
