/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/6/2012
 * Time: 5:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
    using MbUnit.Framework;
    //using NUnit.Framework;
    using SePSX;
//    using PSTestLib;
//    using OpenQA.Selenium;
//    using System.Drawing;
//    using System.Collections.ObjectModel;
    
	/// <summary>
	/// Description of Settings.
	/// </summary>
	public static class Settings
	{
		static Settings()
		{
		}
		
		public static void CleanUpRecordingCollection()
		{
			if (null != Recorder.recordingCollection) {
				Recorder.recordingCollection.Clear();
			}
		}
	}
}
