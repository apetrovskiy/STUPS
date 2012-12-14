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
	
	public interface IJSRecorder
	{
		void CleanRecordedDuringSleep(TranscriptCmdletBase cmdlet);
		void StopRecording(TranscriptCmdletBase cmdlet);
		void MakeJSInjection(TranscriptCmdletBase cmdlet);
		IEnumerable GetRecordedResults();
	}
}
