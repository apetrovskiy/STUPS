/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/24/2014
 * Time: 5:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Tmx.Interfaces.Exceptions;
    using Core.Types.Remoting;
    using Tmx.Interfaces.Remoting;
    using Tmx.Interfaces.Server;
    using Helpers;
    
    /// <summary>
    /// Description of WorkflowLoader.
    /// </summary>
    public class WorkflowLoader
    {
        const string taskElement_id = "id";
        const string taskElement_afterTask = "afterTask";
        const string taskElement_isActive = "isActive";
        const string taskElement_isCritical = "isCritical";
        const string taskElement_name = "name";
        const string taskElement_rule = "rule";
        const string taskElement_storyId = "storyId";
        const string taskElement_taskType = "taskType";
        const string taskElement_taskRuntimeType = "taskRuntimeType";
        const string taskElement_timeLimit = "timelimit";
        const string taskElement_retryCount = "retryCount";
        
        const string taskElement_action = "action";
        const string taskElement_beforeAction = "beforeAction";
        const string taskElement_afterAction = "afterAction";
        const string taskElement_code = "code";
        const string taskElement_parameters = "parameters";

        // 20150312
        ITestWorkflow _workflow;

        // /// <exception cref="WorkflowLoadingException">Server failed to load the workflow. </exception>
        public virtual bool Load(string pathToWorkflowFile)
        {
            try {
                if (!File.Exists(pathToWorkflowFile))
                    throw new WorkflowLoadingException("There is no such file '" + pathToWorkflowFile + "'.");
                // 20150312
                // ImportXdocument(XDocument.Load(pathToWorkflowFile));
                // ImportXdocument(XDocument.Load(pathToWorkflowFile), pathToWorkflowFile);
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
        
        // 20150312
        public virtual Guid ImportXdocument(XContainer xDocument)
        // public virtual Guid ImportXdocument(XContainer xDocument, string pathToWorkflowFile)
        {
            // 20150312
            var workflowId = GetWorkflowId(xDocument);
            // pathToWorkflowFile = pathToWorkflowFile.Substring(0, pathToWorkflowFile.LastIndexOf(@"\", StringComparison.Ordinal));
            // var workflowId = GetWorkflowId(xDocument, pathToWorkflowFile);
            // 20150312
            // setParametersPageName(workflowId, xDocument);
            SetParametersPageName(xDocument);
            
            var tasks = from task in xDocument.Descendants(WorkflowXmlConstants.TaskNode)
                        where task.Element(taskElement_isActive).Value == "1"
                        select task;
            var importedTasks = tasks.Select(tsk => GetNewTestTask(tsk, workflowId));
            AddTasksToCommonPool(importedTasks);
            return workflowId;
        }

        // 20150312
        Guid GetWorkflowId(XContainer xDocument)
        // Guid GetWorkflowId(XContainer xDocument, string pathToWorkflowFile)
        {
            var workflowElement = xDocument.Descendants(WorkflowXmlConstants.WorkflowNode).FirstOrDefault();
            if (null == workflowElement)
                throw new WorkflowLoadingException("There's no workflow element in the document");
            var nameAttribute = workflowElement.Attribute(WorkflowXmlConstants.NameAttribute);
            var workflowName = null != nameAttribute ? nameAttribute.Value : "unnamed workflow";

            // 20150312
            // rejected
            // workflowElement.SetAttributeValue("path", pathToWorkflowFile);

            // 20150312
            return AddWorkflow(workflowName, xDocument);
            // return AddWorkflow(workflowName, xDocument, pathToWorkflowFile);
        }

        // 20150312
        Guid AddWorkflow(string name, XContainer xDocument)
        // Guid AddWorkflow(string name, XContainer xDocument, string pathToWorkflowFile)
        {
            var testLabName = xDocument.Descendants(WorkflowXmlConstants.TestLabNode).FirstOrDefault().Value;

            var testLab = string.IsNullOrEmpty(testLabName) ? 
                getFirstTestLab() :
                getOrCreateTestLab(testLabName);

            // 20150312
            // var workflow = new TestWorkflow(testLab) { Name = name };
            // _workflow = new TestWorkflow(testLab) { Name = name, Path = pathToWorkflowFile };
            _workflow = new TestWorkflow(testLab) { Name = name };
            // 20150312
            // WorkflowCollection.AddWorkflow(workflow);
            WorkflowCollection.AddWorkflow(_workflow);
            // 20150312
            // return workflow.Id;
            return _workflow.Id;
        }
        
        ITestLab getFirstTestLab()
        {
            return TestLabCollection.TestLabs.First();
        }
        
        ITestLab getOrCreateTestLab(string testLabName)
        {
            var testLab = TestLabCollection.TestLabs.FirstOrDefault(tl => tl.Name.ToLower() == testLabName.ToLower());
            if (null != testLab)
                return testLab;
            testLab = new TestLab { Name = testLabName };
            TestLabCollection.TestLabs.Add(testLab);
            return testLab;
        }
        
        // 20150312
        // void setParametersPageName(Guid workflowId, XContainer xDocument)
        void SetParametersPageName(XContainer xDocument)
        {
            // 20150115
            // WorkflowCollection.Workflows.FirstOrDefault(wfl => wfl.Id == workflowId).ParametersPageName = xDocument.Descendants(WorkflowXmlConstants.ParametersPageNode).FirstOrDefault().Value;
            
//            var parameterspageName = xDocument.Descendants(WorkflowXmlConstants.ParametersPageNode).FirstOrDefault().Value;
//            Trace.TraceInformation("is null or empty? {0}", string.IsNullOrEmpty(parameterspageName));
//            Trace.TraceInformation("does start with dot? {0}", parameterspageName.Substring(0, 1) == ".");
//            Trace.TraceInformation("does file exist? {0}", File.Exists(new TmxServerRootPathProvider().GetRootPath() + "/workflows/" + parameterspageName + ".html"));
            
            var parametersPageName = xDocument.Descendants(WorkflowXmlConstants.ParametersPageNode).FirstOrDefault().Value;
            if (string.IsNullOrEmpty(parametersPageName) || parametersPageName.Substring(0, 1) == "." || !File.Exists(new TmxServerRootPathProvider().GetRootPath() + "/workflows/" + parametersPageName + ".html"))
                parametersPageName = UrlList.ViewTestWorkflowParameters_DefaultPage;
            // 20150312
            // WorkflowCollection.Workflows.FirstOrDefault(wfl => wfl.Id == workflowId).ParametersPageName = parameterspageName;
            _workflow.ParametersPageName = parametersPageName;
        }
        
        internal virtual void AddTasksToCommonPool(IEnumerable<ITestTask> importedTasks)
        {
            TaskPool.Tasks.AddRange(importedTasks);
        }
        
        internal virtual ITestTask GetNewTestTask(XContainer taskNode, Guid workflowId)
        {
            return new TestTask {
                Action = GetActionCode(taskNode, taskElement_action),
                ActionParameters = GetActionParameters(taskNode, taskElement_action),
                AfterAction = GetActionCode(taskNode, taskElement_afterAction),
                AfterActionParameters = GetActionParameters(taskNode, taskElement_afterAction),
                BeforeAction = GetActionCode(taskNode, taskElement_beforeAction),
                BeforeActionParameters = GetActionParameters(taskNode, taskElement_beforeAction),
                TaskFinished = false,
                // ExpectedResult
                Id = ConvertTestTaskElementValue(taskNode, taskElement_id),
                AfterTask = ConvertTestTaskElementValue(taskNode, taskElement_afterTask),
                IsActive = "1" == GetTestTaskElementValue(taskNode, taskElement_isActive),
                IsCritical = "1" == GetTestTaskElementValue(taskNode, taskElement_isCritical),
                Name = GetTestTaskElementValue(taskNode, taskElement_name),
                // PreviousTaskId
                RetryCount = ConvertTestTaskElementValue(taskNode, taskElement_retryCount),
                Rule = GetTestTaskElementValue(taskNode, taskElement_rule),
                TaskStatus = TestTaskStatuses.New,
                StoryId = GetTestTaskElementValue(taskNode, taskElement_storyId),
                // TaskResult
                TaskType = GetTestTaskType(GetTestTaskElementValue(taskNode, taskElement_taskType)),
                TaskRuntimeType = GetTaskRuntimeType(GetTestTaskElementValue(taskNode, taskElement_taskRuntimeType)),
                TimeLimit = ConvertTestTaskElementValue(taskNode, taskElement_timeLimit),
                WorkflowId = workflowId
            };
        }
        
        internal virtual string GetActionCode(XContainer taskNode, string elementName)
        {
            var actionNode = taskNode.Element(elementName);
            return GetTestTaskElementValue(actionNode, taskElement_code);
        }
        
        internal virtual IDictionary<string, string> GetActionParameters(XContainer taskNode, string elementName)
        {
            var resultDict = new Dictionary<string, string>();
            var nodeParameters = taskNode.Element(elementName);
            try {
                nodeParameters = nodeParameters.Element(taskElement_parameters);
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