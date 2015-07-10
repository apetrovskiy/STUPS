/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/24/2014
 * Time: 5:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Logic.ObjectModel
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Core;
    using Core.Types.Remoting;
    using Internal;
    using Objects;
    using ServerControl;
    using Tmx.Interfaces.Exceptions;
    using Tmx.Interfaces.Remoting;
    using Tmx.Interfaces.Server;

    /// <summary>
    /// Description of WorkflowLoader.
    /// </summary>
    public class WorkflowLoader
    {
        ITestWorkflow _workflow;

        // /// <exception cref="WorkflowLoadingException">Server failed to load the workflow. </exception>
        public virtual bool Load(string pathToWorkflowFile)
        {
            try {
                if (!File.Exists(pathToWorkflowFile))
                    throw new WorkflowLoadingException("There is no such file '" + pathToWorkflowFile + "'.");
                var pathToCopiedWorkflowFile = CopyWorkflowFileToStorage(pathToWorkflowFile);
                // ImportXdocument(XDocument.Load(pathToCopiedWorkflowFile));
                // ImportXdocument(pathToCopiedWorkflowFile);
                ImportXdocumentAndCreateWorkflowAndTasks(XDocument.Load(pathToCopiedWorkflowFile), pathToCopiedWorkflowFile);
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
            var workflowFileName = pathToWorkflowFile.Substring(pathToWorkflowFile.LastIndexOf(LogicConstants.WorkflowLoader_BackSlashe, StringComparison.Ordinal) + 1);
            var workflowsDirectoryPath = (new TmxServerRootPathProvider()).GetRootPath() + LogicConstants.WorkflowLoader_FileSystemPath_Workflows;
            var workflowCopiedPath = workflowsDirectoryPath + LogicConstants.WorkflowLoader_BackSlashe + workflowFileName;
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
                // File.Copy(pathToWorkflowFile.ToLower().Replace((string)LogicConstants.WorkflowLoader_FileExtension_Xml, LogicConstants.WorkflowLoader_FileExtension_Html),
                //     workflowsDirectoryPath + LogicConstants.WorkflowLoader_BackSlashe + workflowFileName.ToLower().Replace((string)LogicConstants.WorkflowLoader_FileExtension_Xml, LogicConstants.WorkflowLoader_FileExtension_Html), true);
                File.Copy(pathToWorkflowFile.ToLower().Replace(LogicConstants.WorkflowLoader_FileExtension_Xml, LogicConstants.WorkflowLoader_FileExtension_Html),
                    workflowsDirectoryPath + LogicConstants.WorkflowLoader_BackSlashe + workflowFileName.ToLower().Replace(LogicConstants.WorkflowLoader_FileExtension_Xml, LogicConstants.WorkflowLoader_FileExtension_Html), true);
            }
            catch
            {
            }
            try
            {
                // File.Copy(pathToWorkflowFile.ToLower().Replace((string)LogicConstants.WorkflowLoader_FileExtension_Xml, LogicConstants.WorkflowLoader_FileExtension_Htm), workflowsDirectoryPath + LogicConstants.WorkflowLoader_BackSlashe + workflowFileName.ToLower().Replace((string)LogicConstants.WorkflowLoader_FileExtension_Xml, LogicConstants.WorkflowLoader_FileExtension_Htm), true);
                File.Copy(pathToWorkflowFile.ToLower().Replace(LogicConstants.WorkflowLoader_FileExtension_Xml, LogicConstants.WorkflowLoader_FileExtension_Htm), workflowsDirectoryPath + LogicConstants.WorkflowLoader_BackSlashe + workflowFileName.ToLower().Replace(LogicConstants.WorkflowLoader_FileExtension_Xml, LogicConstants.WorkflowLoader_FileExtension_Htm), true);
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
        
        // public virtual void ImportXdocument(XContainer xDocument)
        public virtual void ImportXdocumentAndCreateWorkflowAndTasks(XContainer xDocument, string pathToWorkflowFile)
        {
            // var workflowId = GetWorkflowId(xDocument);
            // var xDocument = XDocument.Parse(pathToWorkflowFile);
            // var workflowId = GetWorkflowId(xDocument);
            var workflowId = AddWorkflowAndReturnWorkflowId(xDocument, pathToWorkflowFile);
            SetParametersPageName(xDocument);
            var tasks = from task in xDocument.Descendants(LogicConstants.WorkflowLoader_TestWorkflow_TaskNode)
                let element = task.Element(LogicConstants.WorkflowLoader_TaskElementIsActive)
                where element != null && element.Value == "1"
                        select task;
            var importedTasks = tasks.Select(tsk => GetNewTestTask(tsk, workflowId));
            AddTasksToCommonPool(importedTasks);
            AddWorkflowDefaults(xDocument, workflowId);
        }
        
        // Guid GetWorkflowId(XContainer xDocument)
        Guid AddWorkflowAndReturnWorkflowId(XContainer xDocument, string pathToWorkflowFile)
        {
            var workflowElement = xDocument.Descendants(LogicConstants.WorkflowLoader_TestWorkflow_WorkflowNode).FirstOrDefault();
            if (null == workflowElement)
                throw new WorkflowLoadingException("There's no workflow element in the document");
            var nameAttribute = workflowElement.Attribute(LogicConstants.WorkflowLoader_TestWorkflow_NameAttribute);
            var workflowName = null != nameAttribute ? nameAttribute.Value : "unnamed workflow";

            // return AddWorkflow(workflowName, xDocument);
            return AddWorkflow(workflowName, xDocument, pathToWorkflowFile);
        }

        // Guid AddWorkflow(string name, XContainer xDocument)
        Guid AddWorkflow(string name, XContainer xDocument, string pathToWorkflowFile)
        {
            var testLabName = xDocument.Descendants(LogicConstants.WorkflowLoader_TestWorkflow_TestLabNode).FirstOrDefault().Value;

            var testLab = string.IsNullOrEmpty(testLabName) ? 
                GetFirstTestLab() :
                GetOrCreateTestLab(testLabName);

            // _workflow = new TestWorkflow(testLab) { Name = name };
            _workflow = new TestWorkflow(testLab) { Name = name, Path = pathToWorkflowFile};
            // 20150708
            // if there already is a workflow with the same name
            // merge the new one with the existing
            bool replace = false || WorkflowCollection.Workflows.Any(wfl => wfl.Name == _workflow.Name && wfl.Path == _workflow.Path);
            
            if (replace)
                WorkflowCollection.MergeWorkflow(_workflow);
            else
                WorkflowCollection.AddWorkflow(_workflow);
            
            // 20150708
            // WorkflowCollection.AddWorkflow(_workflow);
            ServerObjectFactory.Resolve<TestWorkflowCollectionMethods>().SetDefaultWorkflow();
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
            var parametersPageName = xDocument.Descendants(LogicConstants.WorkflowLoader_TestWorkflow_ParametersPageNode).FirstOrDefault().Value;
            if (string.IsNullOrEmpty(parametersPageName) || parametersPageName.Substring(0, 1) == "." || !File.Exists(new TmxServerRootPathProvider().GetRootPath() + "/workflows/" + parametersPageName + ".html"))
                parametersPageName = UrlList.ViewTestWorkflowParameters_DefaultPage;
            _workflow.ParametersPageName = parametersPageName;
        }
        
        internal virtual void AddTasksToCommonPool(IEnumerable<ITestTask> importedTasks)
        {
            TaskPool.Tasks.AddRange(importedTasks);
        }

        void AddWorkflowDefaults(XContainer xDocument, Guid workflowId)
        {
            var currentWorkflow = WorkflowCollection.Workflows.First(wfl => workflowId == wfl.Id);
            currentWorkflow.DefaultData = GetDefaultData(xDocument);
        }

        internal virtual ITestTask GetNewTestTask(XContainer taskNode, Guid workflowId)
        {
            return new TestTask {
                Action = GetActionCode(taskNode, LogicConstants.WorkflowLoader_TaskElementAction),
                ActionParameters = GetActionParameters(taskNode, LogicConstants.WorkflowLoader_TaskElementAction),
                AfterAction = GetActionCode(taskNode, LogicConstants.WorkflowLoader_TaskElementAfterAction),
                AfterActionParameters = GetActionParameters(taskNode, LogicConstants.WorkflowLoader_TaskElementAfterAction),
                BeforeAction = GetActionCode(taskNode, LogicConstants.WorkflowLoader_TaskElementBeforeAction),
                BeforeActionParameters = GetActionParameters(taskNode, LogicConstants.WorkflowLoader_TaskElementBeforeAction),
                TaskFinished = false,
                // ExpectedResult
                Id = ConvertTestTaskElementValue(taskNode, LogicConstants.WorkflowLoader_TaskElementId),
                AfterTask = ConvertTestTaskElementValue(taskNode, LogicConstants.WorkflowLoader_TaskElementAfterTask),
                IsActive = "1" == GetTestTaskElementValue(taskNode, LogicConstants.WorkflowLoader_TaskElementIsActive),
                IsCritical = "1" == GetTestTaskElementValue(taskNode, LogicConstants.WorkflowLoader_TaskElementIsCritical),
                Name = GetTestTaskElementValue(taskNode, LogicConstants.WorkflowLoader_TaskElementName),
                // PreviousTaskId
                RetryCount = ConvertTestTaskElementValue(taskNode, LogicConstants.WorkflowLoader_TaskElementRetryCount),
                Rule = GetTestTaskElementValue(taskNode, LogicConstants.WorkflowLoader_TaskElementRule),
                TaskStatus = TestTaskStatuses.New,
                StoryId = GetTestTaskElementValue(taskNode, LogicConstants.WorkflowLoader_TaskElementStoryId),
                // TaskResult
                TaskType = GetTestTaskType(GetTestTaskElementValue(taskNode, LogicConstants.WorkflowLoader_TaskElementTaskType)),
                TaskRuntimeType = GetTaskRuntimeType(GetTestTaskElementValue(taskNode, LogicConstants.WorkflowLoader_TaskElementTaskRuntimeType)),
                TimeLimit = ConvertTestTaskElementValue(taskNode, LogicConstants.WorkflowLoader_TaskElementTimeLimit),
                WorkflowId = workflowId
            };
        }
        
        internal virtual string GetActionCode(XContainer taskNode, string elementName)
        {
            var actionNode = taskNode.Element(elementName);
            return GetTestTaskElementValue(actionNode, LogicConstants.WorkflowLoader_TaskElementCode);
        }
        
        internal virtual IDictionary<string, string> GetActionParameters(XContainer taskNode, string elementName)
        {
            var resultDict = new Dictionary<string, string>();
            var nodeParameters = taskNode.Element(elementName);
            try {
                nodeParameters = nodeParameters.Element(LogicConstants.WorkflowLoader_TaskElementParameters);
                if (null == nodeParameters) return resultDict;
                foreach (var parameterNode in nodeParameters.Elements())
                    resultDict.Add(parameterNode.Name.LocalName, parameterNode.Value);
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
                // return taskNode.Element(elementName).Value ?? string.Empty;
                return taskNode.Element(elementName).Value;
            }
            catch {
                // TODO: AOP
                Trace.TraceInformation("getTestTaskElementValue(XContainer taskNode, string elementName)");
                // throw new WrongTaskDataException("failed to read the value of element '" + elementName + "'");
                return string.Empty;
            }
        }
        
        /// <exception cref="Tmx.Interfaces.Exceptions.WrongTaskDataException">Failed to read the taskType element</exception>
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
        
        ICommonData GetDefaultData(XContainer xDocument)
        {
            Trace.TraceInformation("loading default data");
            // this is done before in this class
            //if (null == workflowElement)
            //    throw new WorkflowLoadingException("There's no workflow element in the document");
            var defaultData =
                from defaultDataItem in xDocument.Descendants(LogicConstants.WorkflowLoader_TestWorkflow_DefaultsDataNode)
                select defaultDataItem;
            
            var commonDataCollection = new CommonData();
            var defaultParameterValue = new XAttribute(LogicConstants.WorkflowLoader_TestWorkflow_DefaultsDataParameterValue, string.Empty);
            
            foreach (var xElement in defaultData.Elements(LogicConstants.WorkflowLoader_TestWorkflow_DefaultsDataParameterNode))
                commonDataCollection.AddOrUpdateDataItem(
                    new CommonDataItem {
                        Key = xElement.Attribute(LogicConstants.WorkflowLoader_TestWorkflow_DefaultsDataParameterName).Value,
                        Value = (xElement.Attribute(LogicConstants.WorkflowLoader_TestWorkflow_DefaultsDataParameterValue) ?? defaultParameterValue).Value
                    });
            
            return commonDataCollection;
        }
    }
}