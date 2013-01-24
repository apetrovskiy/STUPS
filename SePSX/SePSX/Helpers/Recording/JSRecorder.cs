/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/5/2012
 * Time: 5:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
	#region using
	using System;
	using OpenQA.Selenium;
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
	using System.Drawing;

	//
	//
//    using System.Windows.Automation;
	//
	//

	//using OpenQA.Selenium.Remote;

	using PSTestLib;
	using System.Management.Automation;

	#endregion using
	
	/// <summary>
	/// Description of ScriptRunner.
	/// </summary>
	public class JSRecorder : IJSRecorder
	{
		public JSRecorder()
		{
		}
		
		#region constants
        internal static string constRecorderInjectScript =
            @"if (null == document.flagRecorgingHooks && 1 !== document.flagRecorgingHooks) {
                //document.title = ""INSERT"";
                	function setHooks(excludeTags) {
                	    window.excludeList = new Array(excludeTags); 
                		window.recordings = new Array();
                		var scriptElement = document.createElement('script');
                		scriptElement.type = 'text/javascript';
                		scriptElement.innerHTML = '<!--\r\nfunction reportElement(event) { try { var elt = document.elementFromPoint(event.clientX, event.clientY); if (-1 != window.excludeList.indexOf(elt.tagName)) { return; } if (0 < window.recordings.length && elt === window.recordings[window.recordings.length - 1]) { return; } window.recordings.push(elt); } catch (err) {  } } \r\n//-->';
                		document.getElementsByTagName(""head"")[0].appendChild(scriptElement);
                //		document.getElementsByTagName(""html"")[0].setAttribute(""onmouseover"", ""reportElement(event)"");
                		document.getElementsByTagName(""html"")[0].setAttribute(""onmousemove"", ""reportElement(event)"");
                		var scriptElement = document.createElement('script');
                		scriptElement.type = 'text/javascript';
                		scriptElement.innerHTML = '<!--\r\nfunction reportClick(event) { try { var elt = document.elementFromPoint(event.clientX, event.clientY); if (-1 != window.excludeList.indexOf(elt.tagName)) { return; } window.recordings.push(window.elementClicked); } catch (err) {  } } \r\n//-->';
                		document.getElementsByTagName(""head"")[0].appendChild(scriptElement);
                		document.getElementsByTagName(""html"")[0].setAttribute(""onclick"", ""reportClick(event)"");
                		var scriptElement = document.createElement('script');
                		scriptElement.type = 'text/javascript';
                		scriptElement.innerHTML = '<!--\r\nfunction cleanRecordings() { window.recordings = null; setHooks(); } \r\n//-->';
                		document.getElementsByTagName(""head"")[0].appendChild(scriptElement);
                		document.getElementsByTagName(""html"")[0].setAttribute(""onload"", ""cleanRecordings()"");
                
                		window.elementClicked = document.getElementsByTagName('html')[0].appendChild(document.createElement(""recClicked""));
                		
                		document.flagRecorgingHooks = 1;
                	}
                	setHooks(arguments[0]);
                }";

        internal static string constRecorderGetElement =
            @"if (null != window.recordings && 0 < window.recordings.length) {
            	var collected = window.recordings.slice(0, window.recordings.length - 1);
            	window.recordings.splice(0, window.recordings.length - 1);
            	return collected;
            }";
        
        internal static string constRecorderCleanRecordings = 
            @"window.recordings = new Array();";
        
        internal static string constRecorderExitRecording =
            //@"document.getElementsByTagName(""html"")[0].setAttribute(""onmouseover"", """");";
            @"document.getElementsByTagName(""html"")[0].setAttribute(""onmouseover"", """");";
        
        internal static string constRecorderCheckInjection =
            @"if ((null == document.flagRecorgingHooks) || (1 !== document.flagRecorgingHooks) || (null == window.recordings)) {
            	""0"";
            } else {
            	""1"";
            }";
		#endregion constants

		public void CleanRecordedDuringSleep(TranscriptCmdletBase cmdlet)
		{
			cmdlet.WriteVerbose(cmdlet, "cleaning colelcted during the sleep");
			SeHelper.ExecuteJavaScript(cmdlet, (new OpenQA.Selenium.IWebDriver[] { CurrentData.CurrentWebDriver }), JSRecorder.constRecorderCleanRecordings, (new string[] { string.Empty }), false);
			cmdlet.WriteVerbose(cmdlet, "cleaned");
		}

		public void StopRecording(TranscriptCmdletBase cmdlet)
		{
			cmdlet.WriteVerbose(cmdlet, "exit recording");

			SeHelper.ExecuteJavaScript(cmdlet, (new OpenQA.Selenium.IWebDriver[] { CurrentData.CurrentWebDriver }), JSRecorder.constRecorderExitRecording, (new string[] { string.Empty }), false);
			cmdlet.WriteVerbose(cmdlet, "exited");
		}

		public void MakeJSInjection(TranscriptCmdletBase cmdlet)
		{
			try {
				cmdlet.WriteVerbose(cmdlet, "checking injection");
				var result = SeHelper.ExecuteJavaScript(cmdlet, (new OpenQA.Selenium.IWebDriver[] { CurrentData.CurrentWebDriver }), JSRecorder.constRecorderCheckInjection, (new string[] { string.Empty }), false);
				if (result) {
					cmdlet.WriteVerbose(cmdlet, "inserting injection");

					SeHelper.ExecuteJavaScript(cmdlet, (new OpenQA.Selenium.IWebDriver[] { CurrentData.CurrentWebDriver }), JSRecorder.constRecorderInjectScript, (new string[] { Preferences.TranscriptExcludeList }), false);
					cmdlet.WriteVerbose(cmdlet, "injection inserted");
				}
			} catch (Exception eGetInjectionCode) {
				cmdlet.WriteVerbose(cmdlet, "test for existing injection: " + eGetInjectionCode.Message);
			}
		}

		public IEnumerable GetRecordedResults()
		{
			var scriptResults = ((IJavaScriptExecutor)CurrentData.CurrentWebDriver).ExecuteScript(JSRecorder.constRecorderGetElement, (new string[] { string.Empty })) as IEnumerable;
			return scriptResults;
		}
	}
}
