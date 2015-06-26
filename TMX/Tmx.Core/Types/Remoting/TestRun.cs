/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/26/2014
 * Time: 10:57 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core.Types.Remoting
{
    using System;
    using System.Collections.Generic;
    using Interfaces.ExtensionMethods;
    using Interfaces.Remoting;
    using Interfaces.Remoting.Actions;
    using Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestRun.
    /// </summary>
    public class TestRun : ITestRun
    {
        ITestWorkflow _workflow;
        DateTime _finishTime;
        
        public TestRun()
        {
            Data = new CommonData();
            TestSuites = new List<ITestSuite>();
            TestPlatforms = new List<ITestPlatform> {
                new TestPlatform {
                    Id = TestData.DefaultPlatformId,
                    Name = TestData.DefaultPlatformName,
                    Description = "This platform has been created automatically"
                }
            };
            
            BeforeActions = new List<IAction>();
            AfterActions = new List<IAction>();
            CancelActions = new List<IAction>();
            FailureActions = new List<IAction>();
            
            Status = TestRunStatuses.Pending;
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICommonData Data { get; set; }
        public List<ITestSuite> TestSuites { get; set; }
        public List<ITestPlatform> TestPlatforms { get; set; }
        public Guid TestLabId {
            get { return _workflow.TestLabId; }
        }
        
        public TestRunStatuses Status { get; set; }
        public TestRunStartTypes StartType { get; set; }
        public Guid WorkflowId
        {
            get { return _workflow.Id; }
        }

        public void SetWorkflow(ITestWorkflow testWorkflow)
        {
            _workflow = testWorkflow;
        }
        
        public DateTime CreatedTime { get; set; }
        public DateTime StartTime { get; set; }
        
        public string GetTimeTaken()
        {
            /*
            TimeSpan resultSpan;
            if (DateTime.MinValue == StartTime)
                return string.Format("{0:00}:{1:00}:{2:00}", 0, 0, 0);
            if (DateTime.MinValue < _finishTime)
                resultSpan = _finishTime - StartTime;
            else
                resultSpan = DateTime.Now - StartTime;
            return string.Format("{0:00}:{1:00}:{2:00}", (int)resultSpan.TotalHours % 60, (int)resultSpan.TotalMinutes % 60, (int)resultSpan.TotalSeconds % 60);
            */
            // return GetTimeTaken(StartTime, _finishTime);
            return _finishTime.GetTimeTaken(StartTime);
        }

        //string GetTimeTaken(DateTime startTime, DateTime finishTime)
        //{
        //    TimeSpan resultSpan;
        //    if (DateTime.MinValue == startTime)
        //        return string.Format("{0:00}:{1:00}:{2:00}", 0, 0, 0);
        //    if (DateTime.MinValue < finishTime)
        //        resultSpan = finishTime - startTime;
        //    else
        //        resultSpan = DateTime.Now - startTime;
        //    return string.Format("{0:00}:{1:00}:{2:00}", (int)resultSpan.TotalHours % 60, (int)resultSpan.TotalMinutes % 60, (int)resultSpan.TotalSeconds % 60);
        //}

        public void SetFinishTime()
        {
            _finishTime = DateTime.Now;
        }
        
//        // 20141126
//        string GetTestLabName()
//        {
//            return testlabcollection
//        }
        
        public List<IAction> BeforeActions { get; set; }
        public List<IAction> AfterActions { get; set; }
        public List<IAction> CancelActions { get; set; }
        public List<IAction> FailureActions { get; set; }
    }
}
