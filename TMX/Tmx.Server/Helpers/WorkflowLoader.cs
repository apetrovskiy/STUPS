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
                    select task;
                
				foreach (var singleTask in tasks)
					TaskPool.Tasks.Add(getNewTestTask(singleTask));
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
		        Action = getTestTaskElementValue(taskNode, taskElement_action),
		        // ActionParameters = new object
				// AfterAction
				// BeforeAction
				Completed = false,
				// ExpectedResult
				Id = convertTestTaskElementValue(taskNode, taskElement_id),
				IsActive = "1" == getTestTaskElementValue(taskNode, taskElement_isActive),
				IsCritical = "1" == getTestTaskElementValue(taskNode, taskElement_isCritical),
				Name = getTestTaskElementValue(taskNode, taskElement_name),
				// PreviousTaskId
				RetryCount = convertTestTaskElementValue(taskNode, taskElement_retryCount),
				Rule = getTestTaskElementValue(taskNode, taskElement_rule),
				Status = TestTaskStatuses.New,
				StoryId = getTestTaskElementValue(taskNode, taskElement_storyId),
				// TaskResult
				TaskType = getTestTaskType(taskNode.Element(taskElement_taskType).Value),
				Timeout = convertTestTaskElementValue(taskNode, taskElement_timeout)
			};
		}
		
		ITestTaskAction[] getCollection(XContainer taskNode, string taskElement_action)
		{
			// TODO: read real test action(s)
			return new[] { new TestTaskAction { Code = "dir" } };
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
