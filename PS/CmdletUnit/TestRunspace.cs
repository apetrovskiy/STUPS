/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 07/12/2011
 * Time: 09:09 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace CmdletUnitTest
{
    using System;
    using System.Diagnostics;
    using System.Management.Automation;
//    using System.Management.Automation.Runspaces;
    
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of TestRunspace.
    /// </summary>
    // 20140108
    // public static class TestRunspace
    public class TestRunspace
    {
        
        private static bool showCode = true;

        // 20130130
        // [STAThread]
        public static bool InitializeRunspace(string command)
        {
            return PSRunner.Runner.InitializeRunspace(command);
        }
        
        // 20140108
        // [STAThread]
        public static System.Collections.ObjectModel.Collection<PSObject> RunPSCode(string codeSnippet)
        {
            return PSRunner.Runner.RunPSCode(codeSnippet, showCode);
        }
        
        // 20140108
        // [STAThread]
        public static bool CloseRunspace()
        {
            return PSRunner.Runner.CloseRunspace();
        }
        
        public static void RunAndGetTheException(
            string codeSnippet, 
            string exceptionType,
            string message)
        {
            //reportRunningCode(codeSnippet);

            try{

                System.Collections.ObjectModel.Collection<PSObject> coll =
                    PSRunner.Runner.RunPSCode(codeSnippet, showCode);
                
                Assert.Fail();
            }
            catch (Exception ee) {

                Assert.AreEqual(exceptionType, ee.GetType().Name);

                if (!ee.Message.Contains(message)) {

                    Assert.Fail("Exception description does not match: " + ee.Message);

                }
            }

            PSRunner.Runner.FinishRunningCode();
        }
        
        /// <summary>
        /// Throws an exception if all parameters and their values are okay.
        /// </summary>
        /// <param name="codeSnippet"></param>
        public static void RunAndCheckCmdletParameters_ParamsAccepted(string codeSnippet)
        {
            RunAndGetTheException(
                codeSnippet,
                // 20130207
                //"CmdletInvocationException",
                "AssertionFailureException",
                //"Parameters checked");
                "An assertion failed.");
        }
        
        public static void RunAndCheckCmdletParameters_ParamsOK_CmdletException(string codeSnippet)
        {
            RunAndGetTheException(
                codeSnippet,
                // 20130207
                "CmdletInvocationException",
                //"AssertionFailureException",
                "Parameters checked");
        }
        
        // 20130918
        public static void RunAndCheckCmdletParameters_ParamsBinding_ValidationException(string codeSnippet)
        {
            RunAndGetTheException(
                codeSnippet,
                "ParameterBindingValidationException",
                "Cannot bind argument to parameter 'InputObject' because it is null.");
        }
        
        public static void RunAndCheckCmdletParameters_ParameterMissing(string codeSnippet)
        {
            RunAndGetTheException(
                codeSnippet,
                "ParameterBindingException",
                "Cannot process command because of one or more missing mandatory parameters:");
        }
        
        public static void RunAndEvaluateAreEqual1(string codeSnippet)
        {
            RunAndEvaluateAreEqual(codeSnippet, "1");
        }
        
        public static void RunAndEvaluateIsNull(string codeSnippet)
        {
            //reportRunningCode(codeSnippet);
            System.Collections.ObjectModel.Collection<PSObject> coll =
                PSRunner.Runner.RunPSCode(codeSnippet, showCode);
            Assert.IsNull(coll);
            PSRunner.Runner.FinishRunningCode();
        }
        
        public static void RunAndEvaluateIsEmpty(string codeSnippet)
        {
            //reportRunningCode(codeSnippet);
            System.Collections.ObjectModel.Collection<PSObject> coll =
                PSRunner.Runner.RunPSCode(codeSnippet, showCode);
            Assert.IsEmpty(coll);
            PSRunner.Runner.FinishRunningCode();
        }
        
        public static void RunAndEvaluateIsTrue(
            string codeSnippet,
            string strValue)
        {
            //reportRunningCode(codeSnippet);
            System.Collections.ObjectModel.Collection<PSObject> coll =
                PSRunner.Runner.RunPSCode(codeSnippet, showCode);
            Assert.IsTrue(coll[0].ToString() == strValue);
            PSRunner.Runner.FinishRunningCode();
        }
        
        // 20140107
        public static void RunAndEvaluateAreEqual(
            string codeSnippet,
            string strValue)
        {
            //reportRunningCode(codeSnippet);
            // 20140107
            // System.Collections.ObjectModel.Collection<PSObject> coll =
            //     PSRunner.Runner.RunPSCode(codeSnippet, showCode);
            // if (null != coll && 0 < coll.Count) {
            //     Assert.AreEqual(strValue, coll[0].ToString());
            // } else {
            //     Assert.Fail();
            // }
            // PSRunner.Runner.FinishRunningCode();
            RunAndEvaluateAreEqual(codeSnippet, null, strValue);
        }
        
        // 20140107
        public static void RunAndEvaluateAreEqual(
            string codeSnippet,
            IEnumerable inputData,
            string strValue)
        {
            //reportRunningCode(codeSnippet);
            System.Collections.ObjectModel.Collection<PSObject> coll;
            if (null == inputData) {
                coll = PSRunner.Runner.RunPSCode(codeSnippet, showCode);
            } else {
                coll = PSRunner.Runner.RunPSCode(codeSnippet, showCode, inputData);
            }
            
            if (null != coll && 0 < coll.Count) {
                Assert.AreEqual(strValue, coll[0].ToString());
            } else {
                Assert.Fail();
            }
            
            PSRunner.Runner.FinishRunningCode();
        }
        
        public static void RunAndEvaluateAreEqual(
            string codeSnippet,
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> strValues)
        {
            //reportRunningCode(codeSnippet);
            System.Collections.ObjectModel.Collection<PSObject> coll =
                PSRunner.Runner.RunPSCode(codeSnippet, showCode);
            Assert.AreEqual(strValues, coll);
            PSRunner.Runner.FinishRunningCode();
        }
        
        public static void RunAndCompareTwoOutputs(
            string codeSnippet,
            List<int> sourceIndices,
            List<int> targetIndices)
        {
            //reportRunningCode(codeSnippet);
            System.Collections.ObjectModel.Collection<PSObject> coll =
                PSRunner.Runner.RunPSCode(codeSnippet, showCode);
            List<object> sourceList = new List<object>();
            foreach (int i in sourceIndices) {
                sourceList.Add(coll[i]);
            }
            List<object> targetList = new List<object>();
            foreach (int i in targetIndices) {
                targetList.Add(coll[i]);
            }
            Assert.AreEqual(sourceList, targetList);
            PSRunner.Runner.FinishRunningCode();
        }
        
//        private static void reportRunningCode(string codeSnippet)
//        {
//            finishRunningCode();
//            Console.WriteLine(codeSnippet);
//        }
        
//        private static void finishRunningCode()
//        {
//            Console.WriteLine("# ==  ==  ==  ==  ==  ==  ==  ==  ==  == Running code: ==  ==  ==  ==  ==  ==  ==  ==  ==  == =");
//        }
    }
}