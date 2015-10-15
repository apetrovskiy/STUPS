/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/5/2012
 * Time: 11:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    #region using
    using System;
//    using OpenQA.Selenium.Firefox;
//    using OpenQA.Selenium.Chrome;
//    using OpenQA.Selenium.IE;

//    using OpenQA.Selenium.Safari;
//    //using OpenQA.Selenium.Opera;
//    using OpenQA.Selenium.Android;

//    using OpenQA.Selenium.Support;
//    using UIAutomation;
//    using OpenQA.Selenium.Remote;

//    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections;

    //
    //
//    using System.Windows.Automation;
    //
    //

    //using OpenQA.Selenium.Remote;
    using SePSX;

    #endregion using
    
    /// <summary>
    /// Description of JSFakeGenerator.
    /// </summary>
    public class FakeJSGenerator : IJsRecorder
    {
        public FakeJSGenerator()
        {
        }
        
        public FakeJSGenerator(List<object> listObjects)
        {
            this.allTypesOfObjects = listObjects;
        }
        
        private List<object> allTypesOfObjects;
        
        public void CleanRecordedDuringSleep(TranscriptCmdletBase cmdlet)
        {
            cmdlet.WriteVerbose(cmdlet, "cleaning colelcted during the sleep");
            SeHelper.ExecuteJavaScript(cmdlet, (new OpenQA.Selenium.IWebDriver[] { CurrentData.CurrentWebDriver }), JsRecorder.ConstRecorderCleanRecordings, (new string[] { string.Empty }), false);
            cmdlet.WriteVerbose(cmdlet, "cleaned");
        }

        public void StopRecording(TranscriptCmdletBase cmdlet)
        {
            cmdlet.WriteVerbose(cmdlet, "exit recording");

            SeHelper.ExecuteJavaScript(cmdlet, (new OpenQA.Selenium.IWebDriver[] { CurrentData.CurrentWebDriver }), JsRecorder.ConstRecorderExitRecording, (new string[] { string.Empty }), false);
            cmdlet.WriteVerbose(cmdlet, "exited");
        }

        public void MakeJsInjection(TranscriptCmdletBase cmdlet)
        {
            try {
                cmdlet.WriteVerbose(cmdlet, "checking injection");
                var result = SeHelper.ExecuteJavaScript(cmdlet, (new OpenQA.Selenium.IWebDriver[] { CurrentData.CurrentWebDriver }), JsRecorder.ConstRecorderCheckInjection, (new string[] { string.Empty }), false);
                if (result) {
                    cmdlet.WriteVerbose(cmdlet, "inserting injection");

                    SeHelper.ExecuteJavaScript(cmdlet, (new OpenQA.Selenium.IWebDriver[] { CurrentData.CurrentWebDriver }), JsRecorder.ConstRecorderInjectScript, (new string[] { SePSX.Preferences.TranscriptExcludeList }), false);
                    cmdlet.WriteVerbose(cmdlet, "injection inserted");
                }
            } catch (Exception eGetInjectionCode) {
                cmdlet.WriteVerbose(cmdlet, "test for existing injection: " + eGetInjectionCode.Message);
            }
        }

        public IEnumerable GetRecordedResults()
        {
            if (null != this.allTypesOfObjects && 0 < this.allTypesOfObjects.Count) {
                
                return (new ReadOnlyCollection<object>(this.allTypesOfObjects));
            } else {
                
                List<object> listToReturn = new List<object>();
                return (new ReadOnlyCollection<object>(listToReturn));
            }
        }
    }
}
