/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/5/2012
 * Time: 1:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Linq;

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

    //
    //
    //
    //
    
    //using OpenQA.Selenium.Remote;
    
    using PSTestLib;
    using System.Management.Automation;
    
//    using OpenQA.Selenium.Interactions;
//    using OpenQA.Selenium.Support.PageObjects;
//    
//    using OpenQA.Selenium.Support.UI;
//    
//    using System.Windows.Forms;
//    
//    using System.Management.Automation.Runspaces;

    #endregion using
    
    /// <summary>
    /// Description of Recorder.
    /// </summary>
    public static class Recorder
    {
        static Recorder()
        {
        }
        
        #region Recorder
            #region constants

        
        
        //internal const string constAuxElementClicked = 
        public const string ConstAuxElementClicked = 
            @"recclicked";
        //internal const string constAuxElementTypedIn = 
        public const string ConstAuxElementTypedIn = 
            @"rectypedin";
        //internal const string constAuxElementSelected = 
        public const string ConstAuxElementSelected = 
            @"recselected";
        //internal const string constAuxElementData = 
        public const string ConstAuxElementData = 
            @"recdata";
        
        public const string CodeGenGetElement = "\r\nGet-SeWebElement";
        public const string CodeGenElementClick = " | Invoke-SeWebElementClick;";
        public const string CodeGenIdParameter = " -Id '";
        public const string CodeGenNameParameter = " -Name '";
        public const string CodeGenClassParameter = " -Class '";
        public const string CodeGenTagParameter = " -Tag '";
        public const string CodeGenNameComment = "\r\n\t# -Name '";
        public const string CodeGenClassComment = "\r\n\t# -Class '";
        public const string CodeGenTagComment = "\r\n\t# -Tag '";
        
            #endregion constants
        
        internal static List<IRecordedCodeSequence> RecordingCollection = 
            new List<IRecordedCodeSequence>();
        
        internal static bool CodeSequenceCompleted { get; set; }
        
        private static ILanguagePackage SelectLanguage(RecorderLanguages languageCode)
        {
            ILanguagePackage languagePackage = null;
            
            switch (languageCode) {
                case RecorderLanguages.PowerShell:
                    languagePackage = new PsLanguage();
                    break;
                case RecorderLanguages.CSharp:
                    languagePackage = new CsLanguage();
                    break;
                case RecorderLanguages.Java:
                    languagePackage = new JavaLanguage();
                    break;
                default:
                    //throw new Exception("Invalid value for RecorderLanguages");
                    languagePackage = new PsLanguage();
                    break;
            }
            
            return languagePackage;
        }
        
        public static void RecordActions(TranscriptCmdletBase cmdlet, IJsRecorder jsRecorder, RecorderLanguages languageCode) //, bool waitForElement)
        {
            var startTime = DateTime.Now;

            RecordingCollection = 
                new List<IRecordedCodeSequence>();
            IRecordedCodeSequence codeSequence =
                new RecordedCodeSequence();
            var codeString = string.Empty;

            var currentWindowHandles =
                //CurrentData.CurrentWebDriver.WindowHandles;
                new ReadOnlyCollection<string>((new List<string>()));

            if (null != CurrentData.CurrentWebDriver &&
                null != CurrentData.CurrentWebDriver.WindowHandles) {

                currentWindowHandles = CurrentData.CurrentWebDriver.WindowHandles;
            }

            do {

                jsRecorder.MakeJsInjection(cmdlet);

                try {

                    var scriptResults = jsRecorder.GetRecordedResults();
                        
                    if (null != scriptResults) { // && scriptResults is object[] && 0 < ((object[])scriptResults).Length) {
                        foreach (var singleResult in scriptResults) {

                            codeSequence =
                                RecordCodeSequence(
                                    cmdlet,
                                    RecordingCollection,
                                    singleResult,
                                    codeSequence);

                            if (CodeSequenceCompleted) {

                                NotifyCodeGathered();
                                
                                codeString =
                                    ConvertCodeSequenceToCode(
                                        codeSequence,
                                        SelectLanguage(languageCode),
                                        codeString);
Console.WriteLine("codeString:");
Console.WriteLine(codeString);
                                CodeSequenceCompleted = false;
                            }
                            
                            if (null != (singleResult as IWebElement)) {

                                var resultElement = 
                                    singleResult as IWebElement;

                                if (IsNotFakeWebElement(resultElement)) {
                                    cmdlet.WriteVerbose(cmdlet, "element is not a fake");

                                    if (cmdlet.PassThru) {

                                        cmdlet.WriteVerbose(cmdlet, "outputting the object");
                                        cmdlet.WriteObject(cmdlet, resultElement);
                                        
                                    } else if (Preferences.Highlight) {

                                        cmdlet.WriteVerbose(cmdlet, "highlighting the object");
                                        SeHelper.Highlight(resultElement);
                                        
                                    }
                                } 
                            } 
#region commented 20101031
//                            else if (null != (singleResult as ReadOnlyCollection<object>)){
////Console.WriteLine("0010: singleResult type is " + singleResult.GetType().Name);
//                                RecordedData recData = new RecordedData();
//                                ReadOnlyCollection<object> elementData = singleResult as ReadOnlyCollection<object>;
////Console.WriteLine("0012: Count = " + elementData.Count.ToString());
//
////try { Console.WriteLine("000001: " + elementData); } catch {}
////try { cmdlet.WriteObject(cmdlet, "000002: " + elementData); } catch {}
////try { Console.WriteLine("000003: " + elementData[0]); } catch {}
////try { cmdlet.WriteObject("000004: " + elementData[0]); } catch {}
////if (0 < elementData.Count) {
////    foreach (var item1 in elementData) {
////        cmdlet.WriteObject(cmdlet, item1.GetType().Name);
////        cmdlet.WriteObject(cmdlet, item1);
////    }
////}
//
////                                Dictionary<string, object> elementData2 = singleResult as Dictionary<string, object>;
////if (null != elementData2) {
////    Console.WriteLine("0012-2: Count = " + elementData2.Keys.Count.ToString());
////                                foreach (KeyValuePair<string, object> elementDataItem in elementData) {
////    Console.WriteLine("elementDataItem[elementDataItem.Keys[]] = " + elementDataItem.Key + "\t" + elementDataItem.Value.ToString());
////                                }
////}
////                                foreach (var elementDataItem in elementData) {
////Console.WriteLine("0015");
////                                        //recData.UserData.Add(elementData.
////                                    Console.WriteLine(elementDataItem);
////                                }
//                                //}
//                            } 
#endregion commented 20101031
                            else {

                                cmdlet.WriteObject(cmdlet, "singleResult is not IWebElement");
                                cmdlet.WriteObject(cmdlet, "else: " + singleResult);
                                //cmdlet.WriteObject(cmdlet, singleResult);
                                
                                
                            }
                        } // foreach (var singleResult in scriptResults) {
                    } // if (null != scriptResults) {
                }
                catch (Exception eRec) {
                    Console.WriteLine(eRec.Message);
                }
                
#region commented - the previous version
//                ReadOnlyCollection<IWebElement> scriptResult = null;
//                //System.Collections.ArrayList scriptResultOther = null;
//                object[] scriptResultOther = null;
//                
//                try {
//                    var scriptResultUndefined = 
//                        ((IJavaScriptExecutor)CurrentData.CurrentWebDriver).ExecuteScript(
//                            JSRecorder.constRecorderGetElement,
//                            (new string[] { string.Empty } ));
////                        (ReadOnlyCollection<IWebElement>)((IJavaScriptExecutor)CurrentData.CurrentWebDriver).ExecuteScript(
////                            JSRecorder.constRecorderGetElement,
////                            (new string[] { string.Empty } ));
//                    
//                    scriptResult = scriptResultUndefined as ReadOnlyCollection<IWebElement>;
//                    scriptResultOther = scriptResultUndefined as object[];
//                    
//                    if (null == scriptResult && null == scriptResultOther ) {
//                        cmdlet.WriteVerbose(cmdlet, "scriptResult == null");
//                    } else {
//                        cmdlet.WriteVerbose(cmdlet, "scriptResult != null");
//                        if (null != scriptResult && 0 == scriptResult.Count) {
//                            cmdlet.WriteVerbose(cmdlet, "scriptResult.Count == 0");
//                        } else if (null != scriptResultOther && 0 == scriptResultOther.Length) {
//                            cmdlet.WriteVerbose(cmdlet, "scriptResultOther.Count == 0");
//                        } else {
//                            cmdlet.WriteVerbose(cmdlet, "scriptResult.Count == " + scriptResult.Count.ToString());
//                            
//                            foreach (IWebElement resultElement in scriptResult) {
//                                codeSequence =
//                                    Recorder.RecordCodeSequence(
//                                        cmdlet,
//                                        recordingCollection,
//                                        resultElement,
//                                        codeSequence);
//
//                                if (Recorder.isNotFakeWebElement(resultElement)) {
//                                    cmdlet.WriteVerbose(cmdlet, "element is not a fake");
//
//                                    if (cmdlet.PassThru) {
//                                        
//                                        cmdlet.WriteVerbose(cmdlet, "outputting the object");
//                                        cmdlet.WriteObject(cmdlet, resultElement);
//                                        
//                                    } else if (Preferences.Highlight) {
//                                        
//                                        cmdlet.WriteVerbose(cmdlet, "highlighting the object");
//                                        SeHelper.Highlight(resultElement);
//                                        
//                                    }
//                                } 
//                            }
//                            
//                            // 20121012
//                            scriptResult = null; // ??
//                        }
//                    }
//                }
//                catch (Exception eRecording) {
//Console.WriteLine("eRecording: " + eRecording.Message);
//                    if (eRecording.Message.Contains("Element does not exist in cache")) {
//                        CurrentData.CurrentWebDriver.Navigate().Refresh();
//                    }
//                }
//                //
//                //
//                //
//                //
#endregion commented - the previous version
                
                cmdlet.WriteVerbose(cmdlet, "startTime = " + startTime.ToString());
                
                if ((DateTime.Now - startTime).TotalSeconds > 
                    (cmdlet.Timeout / 1000) &&
                    cmdlet.Wait) {
                    cmdlet.WriteVerbose(cmdlet, "Time spent: " + (DateTime.Now - startTime).TotalSeconds + " seconds");
                    
                    cmdlet.Wait = false;
                }
                
                SleepAndRunScriptBlocks(cmdlet);
                
                /*
                if (Preferences.TranscriptCleanRecordedDuringSleep) {
                    SeHelper.CleanRecordedDuringSleep(cmdlet);
                }
                */
               
               GoToNewlyOpenedWindowhandle(currentWindowHandles);
               

            } while (cmdlet.Wait);
            
            //SeHelper.ExitRecording(cmdlet);
            
            // store the last code sequence
            StoreCodeSequenceInCollection(
                cmdlet,
                RecordingCollection,
                codeSequence);
            
        }
        
        private static void GoToNewlyOpenedWindowhandle(
           ReadOnlyCollection<string> currentWindowHandles)
        {
            if (null != CurrentData.CurrentWebDriver.WindowHandles && 
                currentWindowHandles.Count < CurrentData.CurrentWebDriver.WindowHandles.Count) {
                
                var newWindowhandle = string.Empty;
                // go to a newly opened window handle
                foreach (var  windowhandle in CurrentData.CurrentWebDriver.WindowHandles) {
                    
                    if (!currentWindowHandles.Contains(windowhandle)) {
                        newWindowhandle = windowhandle;
                        break;
                    }
                    
                }
                
                currentWindowHandles = CurrentData.CurrentWebDriver.WindowHandles;
                CurrentData.CurrentWebDriver.SwitchTo().Window(newWindowhandle);
                
            }
        }
        
        internal static void NotifyCodeGathered()
        {
            //throw new NotImplementedException();
        }
        
        internal static bool IsNotFakeWebElement(IWebElement resultElement)
        {
            var result = false;
            
            if (null == resultElement) {
                return result;
            }

            if (resultElement.TagName != ConstAuxElementClicked &&
                resultElement.TagName != ConstAuxElementData &&
                resultElement.TagName != ConstAuxElementSelected &&
                resultElement.TagName != ConstAuxElementTypedIn) {
                result = true;
            }
            return result;
        }
        
        
        /// <summary>
        /// Checks the uniqueness of the record and adds to the collection.
        /// </summary>
        /// <param name="recordedElement"></param>
        internal static void StoreCodeSequenceInCollection(
            TranscriptCmdletBase cmdlet,
            List<IRecordedCodeSequence> recordings,
            IRecordedCodeSequence codeSequence)
        {
            cmdlet.WriteVerbose(cmdlet, "StoreCodeSequenceInCollection");
            if (null != recordings) { //  && 0 < recordings.Count) { // :)

                if (CheckCodeSequenceNovelty(cmdlet, recordings, codeSequence)) {

                    cmdlet.WriteVerbose(cmdlet, "adding code sequence to the collection");
                    recordings.Add(codeSequence);
                    
                }
            } 

        }
        
        internal static bool CheckCodeSequenceNovelty(
            TranscriptCmdletBase cmdlet,
            List<IRecordedCodeSequence> recordings, 
            IRecordedCodeSequence codeSequence)
        {
            var result = false;
            
            if (null == recordings) {
                return result;
            }
            if (null == codeSequence) {
                return result;
            }
            if (0 == codeSequence.Items.Count) {
                return result;
            }
            if (0 == recordings.Count) {
                return true;
            }
            
            var lastCollectedCodeSeq = 
                recordings[recordings.Count - 1];
            
            if (lastCollectedCodeSeq.Items.Count == codeSequence.Items.Count) {
                
                for (var i = 0; i < codeSequence.Items.Count; i++) {

                    if (codeSequence.Items[i].ItemType == lastCollectedCodeSeq.Items[i].ItemType) {
                        
                        switch (codeSequence.Items[i].GetType().Name) {
                            case "RecordedWebElement":
                                var eltWebToBeAdded =
                                    (codeSequence.Items[i] as RecordedWebElement);
                                var eltWebThatAlreadyCollected =
                                    (lastCollectedCodeSeq.Items[i] as RecordedWebElement);
                                if (null != eltWebToBeAdded && null != eltWebThatAlreadyCollected) {
                                    /*
                                    foreach (string key in eltWebToBeAdded.UserData.Keys)
                                    {
                                        if (eltWebToBeAdded.UserData[key] != eltWebThatAlreadyCollected.UserData[key])
                                        {
                                            return true;
                                        }
                                    }
                                    */

                                    if (eltWebToBeAdded.UserData.Keys.Any(key => eltWebToBeAdded.UserData[key] != eltWebThatAlreadyCollected.UserData[key]))
                                    {
                                        return true;
                                    }
                                }
                                break;
                            case "RecordedAction":
                                var eltActToBeAdded =
                                    (codeSequence.Items[i] as RecordedAction);
                                var eltActThatAlreadyCollected =
                                    (lastCollectedCodeSeq.Items[i] as RecordedAction);
                                if (null != eltActToBeAdded && null != eltActThatAlreadyCollected) {
                                    /*
                                    foreach (string key in eltActToBeAdded.UserData.Keys)
                                    {
                                        if (eltActToBeAdded.UserData[key] != eltActThatAlreadyCollected.UserData[key])
                                        {
                                            return true;
                                        }
                                    }
                                    */

                                    if (eltActToBeAdded.UserData.Keys.Any(key => eltActToBeAdded.UserData[key] != eltActThatAlreadyCollected.UserData[key]))
                                    {
                                        return true;
                                    }
                                }
                                break;
                            case "RecordedData":
                                var eltDataToBeAdded =
                                    (codeSequence.Items[i] as RecordedData);
                                var eltDataThatAlreadyCollected =
                                    (lastCollectedCodeSeq.Items[i] as RecordedData);
                                if (null != eltDataToBeAdded && null != eltDataThatAlreadyCollected) {
                                    /*
                                    foreach (string key in eltDataToBeAdded.UserData.Keys)
                                    {
                                        if (eltDataToBeAdded.UserData[key] != eltDataThatAlreadyCollected.UserData[key])
                                        {
                                            return true;
                                        }
                                    }
                                    */

                                    if (eltDataToBeAdded.UserData.Keys.Any(key => eltDataToBeAdded.UserData[key] != eltDataThatAlreadyCollected.UserData[key]))
                                    {
                                        return true;
                                    }
                                }
                                break;
                            default:
                                
                                break;
                        }

#region commented 20121031
//                        RecordedWebElement elementToBeAdded =
//                            (codeSequence.Items[i] as RecordedWebElement);
//                        RecordedWebElement elementThatAlreadyCollected =
//                            (lastCollectedCodeSeq.Items[i] as RecordedWebElement);
//                        if (null != elementToBeAdded && null != elementThatAlreadyCollected) {
//
//                            if (elementToBeAdded.UserData != elementThatAlreadyCollected.UserData) {
//Console.WriteLine("return here!");
//                                return true;
//                            }
//                        } else {
//                            RecordedAction actionToBeAdded =
//                                (codeSequence.Items[i] as RecordedAction);
//                            RecordedAction actionThatAlreadyCollected =
//                                (lastCollectedCodeSeq.Items[i] as RecordedAction);
//                            if (null != actionToBeAdded && null != actionThatAlreadyCollected) {
//
//                                if (actionToBeAdded.UserData != actionThatAlreadyCollected.UserData) {
//
//                                    foreach (string key in actionToBeAdded.UserData.Keys) {
//                                        if (actionToBeAdded.UserData[key] != actionThatAlreadyCollected.UserData[key]) {
//Console.WriteLine("return here! 2");
//                                            return true;
//                                        }
//                                    }
//                                }
//                            }
//                        } // else
#endregion commented 20121031
                    } else { // if (codeSequence.Items[i].ItemType == lastCollectedCodeSeq.Items[i].ItemType) {
                        return true;
                    }
                } // for (int i = 0; i < codeSequence.Items.Count; i++) {
                
            } else { // if (lastCollectedCodeSeq.Items.Count == codeSequence.Items.Count) {
                return true;
            }
            //}
            
            return result;
        }
        
        internal static IRecordedCodeSequence RecordCodeSequence(
            TranscriptCmdletBase cmdlet,
            List<IRecordedCodeSequence> recordingCollection,
            object resultElement,
            IRecordedCodeSequence codeSequence)
        {
            RecordedWebElement elementItem = null;
            RecordedAction actionItem = null;
            RecordedData dataItem = null;
            
            var resultWebElement =
                resultElement as IWebElement;
            //RecordedData resultDataCollection =
            //    resultElement as RecordedData;
            var resultDataCollection =
                resultElement as ReadOnlyCollection<object>;
            
            if (null == codeSequence) {
                
                codeSequence = new RecordedCodeSequence();
            }
            
            if (null == resultElement) {
                
                return codeSequence;
            }
//Console.WriteLine(@"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ resultElement.GetType().Name = " + resultElement.GetType().Name);
            if (null != resultWebElement) {

                if (IsNotFakeWebElement(resultWebElement)) {

                    codeSequence =
                        RecordWebItem(cmdlet, codeSequence, resultWebElement, elementItem);
    
                } else { // if (Recorder.isNotFakeWebElement(resultWebElement)) {

                    codeSequence =
                        RecordActionItem(cmdlet, codeSequence, resultWebElement, actionItem);
    
                } // else
                
                
            }

            if (null != resultDataCollection) {
Console.WriteLine(@"////////////////////////////////////////////////////////// null != resultDataCollection " + resultDataCollection.GetType().Name);
                codeSequence =
                    RecordDataItem(cmdlet, codeSequence, resultDataCollection, dataItem);
            }

            cmdlet.WriteVerbose(cmdlet, "RecordCodeSequence");

            return codeSequence;
        }
        

        internal static IRecordedCodeSequence RecordWebItem(
            TranscriptCmdletBase cmdlet,
            IRecordedCodeSequence codeSequence, 
            IWebElement resultWebElement, 
            RecordedWebElement elementItem)
        {
            
            if (null == codeSequence) {
                codeSequence = new RecordedCodeSequence();
            }
            if (null == resultWebElement) {
                return codeSequence;
            }
            
            try {
                
                // the previous code sequence should be added to the collection
                // any new web element must start with new code line
                if (0 < codeSequence.Items.Count) {
                    
                    codeSequence.ReadyToProduceCode = true;
                    
                    StoreCodeSequenceInCollection(
                        cmdlet,
                        RecordingCollection,
                        codeSequence);
                    codeSequence = new RecordedCodeSequence();
                }

                elementItem = new RecordedWebElement();
                elementItem.UserData.Add("Displayed", resultWebElement.Displayed);
                elementItem.UserData.Add("Enabled", resultWebElement.Enabled);
                elementItem.UserData.Add("Location", resultWebElement.Location);
                elementItem.UserData.Add("Selected", resultWebElement.Selected);
                elementItem.UserData.Add("Size", resultWebElement.Size);
                elementItem.UserData.Add("TagName", resultWebElement.TagName);
                elementItem.UserData.Add("Text", resultWebElement.Text);
                elementItem.UserData.Add("code", CodeGenGetElement);
                    
                    // temporarily or not
                    //elementItem.Id = resultWebElement.GetAttribute("id");
                    //elementItem.Name = resultWebElement.GetAttribute("name");
                    //elementItem.ClassName = resultWebElement.GetAttribute("class");
                    
                    // CSS
                    
                    // XPath // 20121031 - not here !!!

                elementItem.Final = false;
                    //elementItem.ItemType = RecordingTypes.Element;
                elementItem.Root = true; // ??
                codeSequence.Items.Add(elementItem); // 20121031

            }
            catch (Exception eElementItem) {
Console.WriteLine("not a fake item exception: " + eElementItem.Message);
            }
            
            return codeSequence;
        }
        
        internal static IRecordedCodeSequence RecordActionItem(
            TranscriptCmdletBase cmdlet, 
            IRecordedCodeSequence codeSequence, 
            IWebElement resultWebElement, 
            RecordedAction actionItem)
        {
            if (null == codeSequence) {
                codeSequence = new RecordedCodeSequence();
            }
            if (null == resultWebElement) {
                return codeSequence;
            }
            
            actionItem = new RecordedAction();
            var elementId = string.Empty;
            var elementName = string.Empty;
            var elementClass = string.Empty;
            var elementTagName = string.Empty;
            var elementText = string.Empty;
            
            try {
            
                switch (resultWebElement.TagName) {
                    case ConstAuxElementClicked:
                        actionItem.UserData.Add("code", CodeGenElementClick);
                        break;
                        
#region temporaly commented
//                            case Recorder.constAuxElementData:
//                                try { elementId = resultWebElement.GetAttribute("id"); } catch {}
//                                try { elementName = resultWebElement.GetAttribute("name"); } catch {}
//                                try { elementClass = resultWebElement.GetAttribute("class"); } catch {}
//                                try { elementTagName = resultWebElement.TagName; } catch {}
//                                try { elementText = resultWebElement.Text; } catch {}
//                                if (string.Empty != elementId && "null" != elementId) {
//                                    actionItem.UserData.Add("code", codeGenIdParameter + elementId + "'");
//                                    actionItem.UserData.Add("comment1", codeGenNameComment + elementName + "'");
//                                    actionItem.UserData.Add("comment2", codeGenClassComment + elementClass + "'");
//                                    actionItem.UserData.Add("comment3", codeGenTagParameter + elementTagName + "'");
////    Console.WriteLine("\"code\" added 2");
//                                } else if (string.Empty != elementName && "null" != elementName) {
//                                    actionItem.UserData.Add("code", codeGenNameParameter + elementName + "'");
//                                    actionItem.UserData.Add("comment1", codeGenClassComment + elementClass + "'");
//                                    actionItem.UserData.Add("comment2", codeGenTagParameter + elementTagName + "'");
////    Console.WriteLine("\"code\" added 3");
//                                } else if (string.Empty != elementClass && "null" != elementClass) {
//                                    actionItem.UserData.Add("code", codeGenClassParameter + elementClass + "'");
//                                    actionItem.UserData.Add("comment1", codeGenTagParameter + elementTagName + "'");
////    Console.WriteLine("\"code\" added 4");
//                                } else if (string.Empty != elementTagName && "null" != elementTagName) {
//                                    actionItem.UserData.Add("code", codeGenTagParameter + elementTagName + "'");
//                                }
//                                break;
//                    case Recorder.constAuxElementSelected:
//                        actionItem.UserData.Add(@"code", @" | Invoke-SeWebElementClick");
//                        break;
#endregion temporaly commented

                    case ConstAuxElementTypedIn:
                        var typedInData = string.Empty;
                        if (null != (typedInData = resultWebElement.GetAttribute("text"))) {
                            
                            // ??
                            
                        } else if (null != (typedInData = resultWebElement.GetAttribute("value"))) {
                            
                            // ??
                        }
                        actionItem.UserData.Add("code", @" | Set-SeWebElementKeys '" + typedInData + "'");
                        break;
                    case ConstAuxElementSelected:
                        // TBD
                        break;
                    case ConstAuxElementData:
                        // nothing to do
                        break;
                }
            }
            catch (Exception eActionItem) {
Console.WriteLine("a fake item exception: " + eActionItem.Message);
            }
            
            // ??
            actionItem.Final = true;
            //
            
            if (codeSequence.ContainsDataItem()) {
                codeSequence.ReadyToProduceCode = true;
            }

            try {
                if (0 == codeSequence.Items.Count) {

                    codeSequence.Items.Add(actionItem);
                } else if (null == (codeSequence.Items[codeSequence.Items.Count - 1] as IRecordedActionItem)) {

                    codeSequence.Items.Add(actionItem);
                } else if (null != ((IRecordedActionItem)codeSequence.Items[codeSequence.Items.Count - 1]).UserData) {
                    if (actionItem.UserData["code"] !=
                        ((IRecordedActionItem)codeSequence.Items[codeSequence.Items.Count - 1]).UserData["code"]) {

                        codeSequence.Items.Add(actionItem);
                    }
                }
            }
            catch (Exception eEliminatingDuplication) {

                codeSequence.Items.Add(actionItem); // ??
            }

            return codeSequence;
        }
        
        internal static IRecordedCodeSequence RecordDataItem(
            TranscriptCmdletBase cmdlet,
            IRecordedCodeSequence codeSequence, 
            ReadOnlyCollection<object> resultDataCollection,
            RecordedData dataItem)
        {
            
            if (null == codeSequence) {
                codeSequence = new RecordedCodeSequence();
            }
            
            //if (null == resultDataCollection || 0 == resultDataCollection.UserData.Count) {
            if (null == resultDataCollection || 0 == resultDataCollection.Count) {
                return codeSequence;
            }
            
            dataItem = new RecordedData();

//int dictionariesCounter = 0;

            var keyKey = string.Empty;
            var keyValue = string.Empty;
            //codeSequence.Items.Add(resultDataCollection);
            foreach (Dictionary<string, object> data in resultDataCollection) {
                try {
                    keyKey = data["key"].ToString();
                } catch {}
                try {
                    if (string.Empty != keyKey) {
                        
                        dataItem.UserData.Add(keyKey, data["value"]);
                        
                    }
                    
                    keyKey = string.Empty;
                    keyValue = string.Empty;
                    
                } catch {}
            }
                
            codeSequence.Items.Add(dataItem);
            
            if (codeSequence.ContainsDataItem()) {
                codeSequence.ReadyToProduceCode = true;
            }

            return codeSequence;
        }
        
        internal static void WriteRecordingsToFile(TranscriptCmdletBase cmdlet, string fileName)
        {
            
//            System.IO.StreamWriter writer0001 = 
//                new System.IO.StreamWriter(@"C:\1\__writer0001__.txt");
//            for (int i = 0; i < Recorder.recordingCollection.Count; i++) {
//                for (int j = 0; j < Recorder.recordingCollection[i].Items.Count; j++) {
//                    
//                    RecordedWebElement webE = Recorder.recordingCollection[i].Items[j] as RecordedWebElement;
//                    RecordedAction actE = Recorder.recordingCollection[i].Items[j] as RecordedAction;
//                    RecordedData dataE = Recorder.recordingCollection[i].Items[j] as RecordedData;
//                    
//                    if (null != webE) {
//                        foreach (string webKey in webE.UserData.Keys) {
//                            writer0001.WriteLine("\r\n" + webKey + "\t" + webE.UserData[webKey]);
//                        }
//                        writer0001.Flush();
//                    } else if (null != actE) {
//                        foreach (string actKey in actE.UserData.Keys) {
//                            writer0001.WriteLine("\r\n" + actKey + "\t" + actE.UserData[actKey]);
//                        }
//                        writer0001.Flush();
//                    } else if (null != dataE) {
//                        foreach (string dataKey in dataE.UserData.Keys) {
//                            writer0001.WriteLine("\r\n" + dataKey + "\t" + dataE.UserData[dataKey]);
//                        }
//                        writer0001.Flush();
//                    } else {
//                        writer0001.WriteLine("\r\nother");
//                        writer0001.Flush();
//                    }
//                }
//            }
//            writer0001.Flush();
//            writer0001.Close();
            
            cmdlet.WriteVerbose(cmdlet, "WriteRecordingsToFile");

            var commonData = string.Empty;
                
            //foreach (IRecordedCodeSequence codeSequence in recordingCollection) {
            foreach (var codeSequence in RecordingCollection) {
                
                commonData =
                    ConvertCodeSequenceToCode(codeSequence, (new PsLanguage()), commonData);
Console.WriteLine("<<<<<<<<<<<<<<<<<<< written >>>>>>>>>>>>>>>>>>>>>");
            }
            
            if (string.Empty != commonData) {
Console.WriteLine("<<<<<<<<<<<<<<<<<<< string.Empty != commonData >>>>>>>>>>>>>>>>>>>>>");
                try {
                    using (var writer = new System.IO.StreamWriter(fileName)) {
Console.WriteLine("<<<<<<<<<<<<<<<<<<< writing to the file >>>>>>>>>>>>>>>>>>>>>");
                        writer.WriteLine(commonData);
                        writer.Flush();
                        writer.Close();
Console.WriteLine("<<<<<<<<<<<<<<<<<<< written to the file >>>>>>>>>>>>>>>>>>>>>");
                    }
                }
                catch (Exception eOutputFileProblem) {
Console.WriteLine("<<<<<<<<<<<<<<<<<<< error >>>>>>>>>>>>>>>>>>>>>");
                    cmdlet.WriteError(
                        cmdlet,
                        "Couldn't save data to the file '" + 
                        fileName + 
                        "'. " +
                        eOutputFileProblem.Message,
                        "FailedToSaveData",
                        ErrorCategory.InvalidArgument,
                        true);
                }
            } else {
Console.WriteLine("<<<<<<<<<<<<<<<<<<< error2 >>>>>>>>>>>>>>>>>>>>>");
                cmdlet.WriteError(
                    cmdlet,
                    "Nothing was recorded",
                    "NoRecords",
                    ErrorCategory.InvalidData,
                    false);
            }
            
Console.WriteLine("FINISHED!!!!!!!!");

        }
        
        internal static string ConvertCodeSequenceToCode(
            IRecordedCodeSequence codeSequence,
            ILanguagePackage languagePackage,
            string commonData)
        {
            
            var webCode = string.Empty;
            var actCode = string.Empty;
            var dataCode = string.Empty;
            
            codeSequence.Header.Add(languagePackage.RegionOpen);
            
            foreach (var recordedItem in codeSequence.Items) {

                var recordedData = string.Empty;
                var additionalData = string.Empty;
                
                var webElement = recordedItem as RecordedWebElement;
                var actionElement = recordedItem as RecordedAction;
                var dataElement = recordedItem as RecordedData;

                
                //codeSequence.Data.Add(languagePackage.SingleLineComment);
                
                //if (null != (recordedItem as RecordedWebElement)) {
                if (null != webElement) {
                    //additionalData +=
                    //    "\r\n\r\n#region element's properties";
                    //codeSequence.Data.Add(languagePackage.SingleLineComment);
                    additionalData +=
                        languagePackage.SingleLineComment;
                    additionalData +=
                        //"\r\n# Displayed = ";
                        "Displayed = ";
                    additionalData +=
                        //(recordedItem as RecordedWebElement).Displayed.ToString();
                        //webElement.Displayed;
                        webElement.UserData["Displayed"];
                    additionalData +=
                        languagePackage.Separator;
                    additionalData +=
                        "Enabled = ";
                    additionalData +=
                        //(recordedItem as RecordedWebElement).Enabled.ToString();
                        //webElement.Enabled;
                        webElement.UserData["Enabled"];
                    additionalData +=
                        languagePackage.Separator;
                    additionalData +=
                        "Location = ";
                    additionalData +=
                        //(recordedItem as RecordedWebElement).Location.ToString();
                        //webElement.Location;
                        webElement.UserData["Location"];
                    additionalData +=
                        languagePackage.Separator;
                    additionalData +=
                        "Selected = ";
                    additionalData +=
                        //(recordedItem as RecordedWebElement).Selected.ToString();
                        //webElement.Selected;
                        webElement.UserData["Selected"];
                    additionalData +=
                        languagePackage.Separator;
                    additionalData +=
                        "Size = ";
                    additionalData +=
                        //(recordedItem as RecordedWebElement).Size.ToString();
                        //webElement.Size;
                        webElement.UserData["Size"];
                    additionalData +=
                        languagePackage.Separator;
                    additionalData +=
                        "TagName = ";
                    additionalData +=
                        //(recordedItem as RecordedWebElement).TagName;
                        //webElement.TagName;
                        webElement.UserData["TagName"];

                    codeSequence.Data.Add(additionalData);
                    additionalData = string.Empty;
                    
                    var tempTextData =
                        //(recordedItem as RecordedWebElement).Text;
                        //webElement.Text;
                        webElement.UserData["Text"].ToString();

                    if (null != tempTextData && string.Empty != tempTextData) {// && tempTextData.Contains("\r\n")) {
                        
                        if (tempTextData.Contains("\r\n")) {

                            additionalData +=
                                //"\r\n# Text = \r\n@\"\r\n";
                                languagePackage.HereStringOpen;
                            additionalData +=
                                tempTextData;
                            additionalData +=
                                //"\r\n\"@";
                                languagePackage.HereStringClose;
                        } else {
                            additionalData +=
                        languagePackage.SingleLineComment;
                            additionalData +=
                                "\r\nText = ";
                            additionalData +=
                                tempTextData;
                        }
                        
                        codeSequence.Data.Add(additionalData);
                        additionalData = string.Empty;
                    }
                    
//                    recordedData +=
//                        //(recordedItem as RecordedWebElement).UserData["code"];
//                        webElement.UserData["code"];

// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// here should be better code generation for new cmdlets
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    codeSequence.Code.Add(webElement.UserData["code"].ToString());

                //} else if (null != (recordedItem as RecordedAction)) {
                } else if (null != actionElement) {

//                    recordedData +=
//                        //((RecordedAction)recordedItem).UserData["code"];
//                        actionElement.UserData["code"];
                    
                    codeSequence.Code.Add(actionElement.UserData["code"].ToString());
                    
                //} else if (null != (recordedItem as RecordedData)) {
                } else if (null != dataElement) {

                    additionalData +=
                        "\r\n#";
                    //foreach (string key in (recordedItem as RecordedData).UserData.Keys) {
                    foreach (var key in dataElement.UserData.Keys) {
//Console.WriteLine("dataItem's key = " + key);
                        if ("XPath" == key) {
//Console.WriteLine("XPath = ");
                            additionalData +=
                                "XPath = ";
var sTemp = "XPath = ";
//Console.WriteLine("dataElement.UserData[key].GetType().Name = " + dataElement.UserData[key].GetType().Name);
                            //foreach (var xpathPart in ((ReadOnlyCollection<object>)((RecordedData)recordedItem).UserData[key])) {
                            foreach (var xpathPart in ((ReadOnlyCollection<object>)dataElement.UserData[key])) {
                                additionalData +=
                                    "/";
sTemp += "/";
                                additionalData +=
                                    xpathPart;
sTemp += xpathPart;
                            }
                            
                            codeSequence.Code.Add("\"" + additionalData + "\"");
                            
                            additionalData +=
                                ";";
Console.WriteLine(sTemp);
                        } else {
var sTemp2 = string.Empty;
                            additionalData +=
                                " ";
                            additionalData +=
                                key;
sTemp2 += key;
                            additionalData +=
                                " = ";
sTemp2 += " = ";
                            additionalData +=
                                //(recordedItem as RecordedData).UserData[key];
                                dataElement.UserData[key];
sTemp2 += dataElement.UserData[key];
Console.WriteLine(sTemp2);
                            additionalData +=
                                ";";
                        }
                    }
                    
                    additionalData +=
                        "\r\n#endregion element's properties";
                    
                } else {
Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< unused element !!!!!!!!!!!!!!!!!!!!! >>>>>>>>>>>>>>");
                }
                
                commonData += 
                    additionalData;
                commonData +=
                    recordedData;
                
            }
            
            
            commonData +=
                codeSequence.Header;
            foreach (var dataString in codeSequence.Data) {
                commonData +=
                    dataString;
            }
            foreach (var codeString in codeSequence.Code) {
                commonData +=
                    codeString;
            }
            return commonData;
        }
        #endregion Recorder
        
        private static void SleepAndRunScriptBlocks(TranscriptCmdletBase cmdlet)
        {
            // 20130318
            //cmdlet.RunOnTranscriptIntervalScriptBlocks(cmdlet);
            cmdlet.RunOnTranscriptIntervalScriptBlocks(cmdlet, null);
            System.Threading.Thread.Sleep(Preferences.TranscriptInterval);
        }
    }
}
