/*
 * Created by SharpDevelop.
 * User: alexa_000
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
				// Action
				// AfterAction
				// BeforeAction
				Completed = false,
				// ExpectedResult
				Id = getTestTaskElementValueInt(taskNode, taskElement_id),
				IsActive = "1" == getTestTaskElementValueString(taskNode, taskElement_isActive),
				IsCritical = "1" == getTestTaskElementValueString(taskNode, taskElement_isCritical),
				Name = getTestTaskElementValueString(taskNode, taskElement_name),
				// PreviousTaskId
				// RetryCount
				Rule = getTestTaskElementValueString(taskNode, taskElement_rule),
				Status = TestTaskStatuses.New,
				StoryId = getTestTaskElementValueString(taskNode, taskElement_storyId),
				// TaskResult
				TaskType = getTestTaskType(taskNode.Element(taskElement_taskType).Value),
				Timeout = getTestTaskElementValueInt(taskNode, taskElement_timeout)
			};
		}

		int getTestTaskElementValueInt(XContainer taskNode, string elementValue)
		{
			int result = 0;
			result = Convert.ToInt32(taskNode.Element(elementValue).Value);
			return result;
		}
		
		string getTestTaskElementValueString(XContainer taskNode, string elementValue)
		{
			string result = taskNode.Element(elementValue).Value;
			return result;
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
