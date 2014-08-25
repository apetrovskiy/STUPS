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
	using System.Linq;
	using System.Xml.Linq;
	using TMX.Interfaces.Exceptions;
	using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.Types.Remoting;
	
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
		const string taskElement_timeout = "timeout";
		const string taskElement_retryCount = "retryCount";
		
		const string taskElement_action = "action";
		const string taskElement_beforeAction = "beforeAction";
		const string taskElement_afterAction = "afterAction";
		const string taskElement_code = "code";
		const string taskElement_parameters = "parameters";
		
		public bool LoadWorkflow(string pathToWorkflowFile)
		{
            try {
                if (!System.IO.File.Exists(pathToWorkflowFile)) {
                    throw new Exception(
                        "There is no such file '" +
                        pathToWorkflowFile +
                        "'.");
                }
                
                var doc = XDocument.Load(pathToWorkflowFile);
                var tasks = from task in doc.Descendants("task")
                    where task.Element(taskElement_isActive).Value == "1"
                    select task;
                
//				foreach (var singleTask in tasks)
//					TaskPool.Tasks.Add(getNewTestTask(singleTask));
                
//                foreach (var singleTask in tasks.Select(t => getNewTestTask(t)))
//					// TaskPool.Tasks.Add(getNewTestTask(singleTask));
//                    TaskPool.Tasks.Add(singleTask);
                
                var importedTasks = tasks.Select(t => getNewTestTask(t));
                TaskPool.Tasks.AddRange(importedTasks);
                
                if (0 == ClientsCollection.Clients.Count) return true;
                
                var taskSorter = new TaskSelector();
                foreach (var clientId in ClientsCollection.Clients.Select(client => client.Id)) {
                    TaskPool.TasksForClients.AddRange(taskSorter.SelectTasksForClient(clientId));
                }
                
            }
            catch (Exception eImportDocument) {
                throw new Exception(
                    "Unable to load an XML workflow from the file '" +
                    pathToWorkflowFile +
                    "'. " + 
                    eImportDocument.Message);
            }
			
			return true;
		}

		ITestTask getNewTestTask(XContainer taskNode)
		{
			return new TestTask {
		        // Action = getCollection(taskNode, taskElement_action),
		        // Action = getAction(taskNode, taskElement_action),
		        Action = getActionCode(taskNode, taskElement_action),
		        // ActionParameters = getActionParameters(taskNode, taskElement_action),
		        ActionParameters = getActionParameters(taskNode, taskElement_action),
				AfterAction = getActionCode(taskNode, taskElement_afterAction),
				AfterActionParameters = getActionParameters(taskNode, taskElement_afterAction),
				BeforeAction = getActionCode(taskNode, taskElement_beforeAction),
				BeforeActionParameters = getActionParameters(taskNode, taskElement_beforeAction),
				TaskFinished = false,
				// ExpectedResult
				Id = convertTestTaskElementValue(taskNode, taskElement_id),
				AfterTask = convertTestTaskElementValue(taskNode, taskElement_afterTask),
				IsActive = "1" == getTestTaskElementValue(taskNode, taskElement_isActive),
				IsCritical = "1" == getTestTaskElementValue(taskNode, taskElement_isCritical),
				Name = getTestTaskElementValue(taskNode, taskElement_name),
				// PreviousTaskId
				RetryCount = convertTestTaskElementValue(taskNode, taskElement_retryCount),
				Rule = getTestTaskElementValue(taskNode, taskElement_rule),
				TaskStatus = TestTaskStatuses.New,
				StoryId = getTestTaskElementValue(taskNode, taskElement_storyId),
				// TaskResult
				TaskType = getTestTaskType(taskNode.Element(taskElement_taskType).Value),
				Timeout = convertTestTaskElementValue(taskNode, taskElement_timeout)
			};
		}
		
		string getActionCode(XContainer taskNode, string elementName)
		{
		    var actionNode = taskNode.Element(elementName);
		    return getTestTaskElementValue(actionNode, taskElement_code);
		}
		
		List<object> getActionParameters(XContainer taskNode, string elementName)
		{
		    // var resultDictionary = new Dictionary<string, object>();
		    var resultList = new List<object>();
		    var nodeParameters = taskNode.Element(elementName);
		    try {
                nodeParameters = nodeParameters.Element(taskElement_parameters);
                if (null == nodeParameters) return resultList;
                foreach (var parameterNode in nodeParameters.Elements())
                    resultList.Add(parameterNode.Value);
		    }
		    catch {}
		    return resultList;
		}
		
		int convertTestTaskElementValue(XContainer taskNode, string elementName)
		{
			return Convert.ToInt32(string.Empty == getTestTaskElementValue(taskNode, elementName) ? "0" : getTestTaskElementValue(taskNode, elementName));
		}
		
		string getTestTaskElementValue(XContainer taskNode, string elementName)
		{
			try {
				return taskNode.Element(elementName).Value ?? string.Empty;
			}
			catch {
				// throw new WrongTaskDataException("failed to read the value of element '" + elementName + "'");
				return string.Empty;
			}
		}
		
		TestTaskExecutionTypes getTestTaskType(string taskTypeStringValue)
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
	}
}
