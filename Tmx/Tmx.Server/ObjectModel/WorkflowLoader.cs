/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/24/2014
 * Time: 5:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.ObjectModel
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Core.Types.Remoting;
    using Tmx.Interfaces.Exceptions;
    using Tmx.Interfaces.Remoting;
    using Tmx.Interfaces.Server;

    /// <summary>
    /// Description of WorkflowLoader.
    /// </summary>
    public class WorkflowLoader
    {
        const string TaskElementId = "id";
        const string TaskElementAfterTask = "afterTask";
        const string TaskElementIsActive = "isActive";
        const string TaskElementIsCritical = "isCritical";
        const string TaskElementName = "name";
        const string TaskElementRule = "rule";
        const string TaskElementStoryId = "storyId";
        const string TaskElementTaskType = "taskType";
        const string TaskElementTaskRuntimeType = "taskRuntimeType";
        const string TaskElementTimeLimit = "timelimit";
        const string TaskElementRetryCount = "retryCount";
        
        const string TaskElementAction = "action";
        const string TaskElementBeforeAction = "beforeAction";
        const string TaskElementAfterAction = "afterAction";
        const string TaskElementCode = "code";
        const string TaskElementParameters = "parameters";

        ITestWorkflow _workflow;

        // /// <exception cref="WorkflowLoadingException">Server failed to load the workflow. </exception>
        public virtual bool Load(string pathToWorkflowFile)
        {
            try {
                if (!File.Exists(pathToWorkflowFile))
                    throw new WorkflowLoadingException("There is no such file '" + pathToWorkflowFile + "'.");
                var pathToCopiedWorkflowFile = CopyWorkflowFileToStorage(pathToWorkflowFile);
                ImportXdocument(XDocument.Load(pathToCopiedWorkflowFile));
            }
            catch (Exception eImportDocument) {
                // TODO: AOP
                // Trace.TraceError("Load(string pathToWorkflowFile)");
                throw new WorkflowLoadingException(
                    "Unable to load an XML workflow from the file '" +
                    pathToWorkflowFile +
                    "'. " + 
                    eImportDocument.Message, eImportDocument);
            }
            return true;
        }

        string CopyWorkflowFileToStorage(string pathToWorkflowFile)
        {
            var workflowFileName = pathToWorkflowFile.Substring(pathToWorkflowFile.LastIndexOf(ServerConstants.WorkflowLoader_BackSlashe, StringComparison.Ordinal) + 1);
            var workflowsDirectoryPath = (new TmxServerRootPathProvider()).GetRootPath() + ServerConstants.WorkflowLoader_FileSystemPath_Workflows;
            var workflowCopiedPath = workflowsDirectoryPath + ServerConstants.WorkflowLoader_BackSlashe + workflowFileName;
            try
            {
                if (!Directory.Exists(workflowsDirectoryPath)) return pathToWorkflowFile;
                File.Copy(pathToWorkflowFile, workflowCopiedPath, true);
            }
            catch
            {
                return pathToWorkflowFile;
            }
            try
            {
                File.Copy(pathToWorkflowFile.ToLower().Replace(ServerConstants.WorkflowLoader_FileExtension_Xml, ServerConstants.WorkflowLoader_FileExtension_Html),
                    workflowsDirectoryPath + ServerConstants.WorkflowLoader_BackSlashe + workflowFileName.ToLower().Replace(ServerConstants.WorkflowLoader_FileExtension_Xml, ServerConstants.WorkflowLoader_FileExtension_Html), true);
            }
            catch
            {
            }
            try
            {
                File.Copy(pathToWorkflowFile.ToLower().Replace(ServerConstants.WorkflowLoader_FileExtension_Xml, ServerConstants.WorkflowLoader_FileExtension_Htm), workflowsDirectoryPath + ServerConstants.WorkflowLoader_BackSlashe + workflowFileName.ToLower().Replace(ServerConstants.WorkflowLoader_FileExtension_Xml, ServerConstants.WorkflowLoader_FileExtension_Htm), true);
            }
            catch
            {
            }
            return workflowCopiedPath;
        }

        public virtual void Reload(string pathToWorkflowFile)
        {
            // TODO: write code
        }
        
        public virtual Guid ImportXdocument(XContainer xDocument)
        {
            var workflowId = GetWorkflowId(xDocument);
            SetParametersPageName(xDocument);
            /*
            var tasks = from task in xDocument.Descendants(WorkflowXmlConstants.TaskNode)
                        where task.Element(taskElement_isActive).Value == "1"
                        select task;
            var importedTasks = tasks.Select(tsk => GetNewTestTask(tsk, workflowId));
            AddTasksToCommonPool(importedTasks);
            return workflowId;
            */
            var tasks = from task in xDocument.Descendants(WorkflowXmlConstants.TaskNode)
                let element = task.Element(TaskElementIsActive)
                where element != null && element.Value == "1"
                        select task;
            var importedTasks = tasks.Select(tsk => GetNewTestTask(tsk, workflowId));
            AddTasksToCommonPool(importedTasks);
            return workflowId;
        }

        Guid GetWorkflowId(XContainer xDocument)
        {
            var workflowElement = xDocument.Descendants(WorkflowXmlConstants.WorkflowNode).FirstOrDefault();
            if (null == workflowElement)
                throw new WorkflowLoadingException("There's no workflow element in the document");
            var nameAttribute = workflowElement.Attribute(WorkflowXmlConstants.NameAttribute);
            var workflowName = null != nameAttribute ? nameAttribute.Value : "unnamed workflow";

            // 20150312
            // rejected
            // workflowElement.SetAttributeValue("path", pathToWorkflowFile);

            return AddWorkflow(workflowName, xDocument);
        }

        Guid AddWorkflow(string name, XContainer xDocument)
        {
            var testLabName = xDocument.Descendants(WorkflowXmlConstants.TestLabNode).FirstOrDefault().Value;

            var testLab = string.IsNullOrEmpty(testLabName) ? 
                GetFirstTestLab() :
                GetOrCreateTestLab(testLabName);

            _workflow = new TestWorkflow(testLab) { Name = name };
            WorkflowCollection.AddWorkflow(_workflow);
            return _workflow.Id;
        }
        
        ITestLab GetFirstTestLab()
        {
            return TestLabCollection.TestLabs.First();
        }
        
        ITestLab GetOrCreateTestLab(string testLabName)
        {
            var testLab = TestLabCollection.TestLabs.FirstOrDefault(tl => tl.Name.ToLower() == testLabName.ToLower());
            if (null != testLab)
                return testLab;
            testLab = new TestLab { Name = testLabName };
            TestLabCollection.TestLabs.Add(testLab);
            return testLab;
        }
        
        void SetParametersPageName(XContainer xDocument)
        {
            var parametersPageName = xDocument.Descendants(WorkflowXmlConstants.ParametersPageNode).FirstOrDefault().Value;
            if (string.IsNullOrEmpty(parametersPageName) || parametersPageName.Substring(0, 1) == "." || !File.Exists(new TmxServerRootPathProvider().GetRootPath() + "/workflows/" + parametersPageName + ".html"))
                parametersPageName = UrlList.ViewTestWorkflowParameters_DefaultPage;
            _workflow.ParametersPageName = parametersPageName;
        }
        
        internal virtual void AddTasksToCommonPool(IEnumerable<ITestTask> importedTasks)
        {
            TaskPool.Tasks.AddRange(importedTasks);
        }
        
        internal virtual ITestTask GetNewTestTask(XContainer taskNode, Guid workflowId)
        {
            return new TestTask {
                Action = GetActionCode(taskNode, TaskElementAction),
                ActionParameters = GetActionParameters(taskNode, TaskElementAction),
                AfterAction = GetActionCode(taskNode, TaskElementAfterAction),
                AfterActionParameters = GetActionParameters(taskNode, TaskElementAfterAction),
                BeforeAction = GetActionCode(taskNode, TaskElementBeforeAction),
                BeforeActionParameters = GetActionParameters(taskNode, TaskElementBeforeAction),
                TaskFinished = false,
                // ExpectedResult
                Id = ConvertTestTaskElementValue(taskNode, TaskElementId),
                AfterTask = ConvertTestTaskElementValue(taskNode, TaskElementAfterTask),
                IsActive = "1" == GetTestTaskElementValue(taskNode, TaskElementIsActive),
                IsCritical = "1" == GetTestTaskElementValue(taskNode, TaskElementIsCritical),
                Name = GetTestTaskElementValue(taskNode, TaskElementName),
                // PreviousTaskId
                RetryCount = ConvertTestTaskElementValue(taskNode, TaskElementRetryCount),
                Rule = GetTestTaskElementValue(taskNode, TaskElementRule),
                TaskStatus = TestTaskStatuses.New,
                StoryId = GetTestTaskElementValue(taskNode, TaskElementStoryId),
                // TaskResult
                TaskType = GetTestTaskType(GetTestTaskElementValue(taskNode, TaskElementTaskType)),
                TaskRuntimeType = GetTaskRuntimeType(GetTestTaskElementValue(taskNode, TaskElementTaskRuntimeType)),
                TimeLimit = ConvertTestTaskElementValue(taskNode, TaskElementTimeLimit),
                WorkflowId = workflowId
            };
        }
        
        internal virtual string GetActionCode(XContainer taskNode, string elementName)
        {
            var actionNode = taskNode.Element(elementName);
            return GetTestTaskElementValue(actionNode, TaskElementCode);
        }
        
        internal virtual IDictionary<string, string> GetActionParameters(XContainer taskNode, string elementName)
        {
            var resultDict = new Dictionary<string, string>();
            var nodeParameters = taskNode.Element(elementName);
            try {
                nodeParameters = nodeParameters.Element(TaskElementParameters);
                if (null == nodeParameters) return resultDict;
                foreach (var parameterNode in nodeParameters.Elements())
                    resultDict.Add(parameterNode.Name.LocalName, parameterNode.Value.ToString());
            }
            catch {}
            return resultDict;
        }
        
        internal virtual int ConvertTestTaskElementValue(XContainer taskNode, string elementName)
        {
            return Convert.ToInt32(string.Empty == GetTestTaskElementValue(taskNode, elementName) ? "0" : GetTestTaskElementValue(taskNode, elementName));
        }
        
        internal virtual string GetTestTaskElementValue(XContainer taskNode, string elementName)
        {
            try {
                return taskNode.Element(elementName).Value ?? string.Empty;
            }
            catch {
                // TODO: AOP
                Trace.TraceInformation("getTestTaskElementValue(XContainer taskNode, string elementName)");
                // throw new WrongTaskDataException("failed to read the value of element '" + elementName + "'");
                return string.Empty;
            }
        }

        /// <exception cref="WrongTaskDataException">Failed to read the taskType element</exception>
        internal virtual TestTaskExecutionTypes GetTestTaskType(string taskTypeStringValue)
        {
            switch (taskTypeStringValue.ToUpper()) {
                case "RDP":
                    return TestTaskExecutionTypes.RemoteApp;
                case "PSREMOTING":
                    return TestTaskExecutionTypes.PsRemoting;
                case "INLINE":
                case "":
                    return TestTaskExecutionTypes.Inline;
                case "SSH":
                    return TestTaskExecutionTypes.Ssh;
                default:
                    throw new WrongTaskDataException("Failed to read the taskType element");
            }
        }
        
        internal virtual TestTaskRuntimeTypes GetTaskRuntimeType(string taskRuntimeTypeStringValue)
        {
            switch (taskRuntimeTypeStringValue.ToUpper()) {
                case "POWERSHELL":
                    return TestTaskRuntimeTypes.Powershell;
                case "NUNIT":
                    return TestTaskRuntimeTypes.Nunit;
                case "XUNIT":
                    return TestTaskRuntimeTypes.Xunit;
                case "MBUNIT":
                    return TestTaskRuntimeTypes.Mbunit;
                default:
                    // 20141211
                    // temporary
                    // TODO: change the behavior
                    return TestTaskRuntimeTypes.Powershell;
            }
        }
    }
}