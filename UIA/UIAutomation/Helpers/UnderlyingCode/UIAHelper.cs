/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 28/11/2011
 * Time: 08:00 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET;
    using System;
    using System.IO;
    using System.Windows.Automation;
    using System.Drawing;
    using System.Windows;
    using System.Windows.Forms;
    using System.Management.Automation;
    using System.Runtime.InteropServices;
    using System.Drawing.Imaging;
    
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    using PSTestLib;
    
    using Commands;
    using System.Threading;
    using TMX;

    /// <summary>
    /// Description of UiaHelper.
    /// </summary>
    
    public static class UiaHelper
    {
        
        private static Highlighter _highlighter = null;
        private static Highlighter _highlighterParent = null;
        //private static Highlighter highlighterFirstChild = null;
        private static Highlighter _highlighterCheckedControl = null;
        private static Banner _banner = null;
        private static IUiElement _element = null;
        
        // 20131204
        private static string _errorMessageInTheGatheringCycle = String.Empty;
        private static bool _errorInTheGatheringCycle = false;
        private static string _errorMessageInTheInnerCycle = String.Empty;
        private static bool _errorInTheInnerCycle = false;
        
        // 20131204
        // private static List<IntPtr> GetControlByNameViaWin32Recursively(
        internal static List<IntPtr> GetControlByNameViaWin32Recursively(
            PSCmdletBase cmdlet,
            IntPtr containerHandle,
            string name,
            int level)
        {
            IntPtr resultHandle = IntPtr.Zero;
            IntPtr controlHandle = IntPtr.Zero;
            
            List<IntPtr> controlHandles = new List<IntPtr>();
            List<IntPtr> tempControlHandles = new List<IntPtr>();
            
//            cmdlet.WriteVerbose(cmdlet, "name = " + name);
//            
//            cmdlet.WriteVerbose(cmdlet, "using null instead of name");
//            cmdlet.WriteVerbose(cmdlet, "test >>>>>>>>>>>>>>>>>>>>>>>>>");
//            try{ cmdlet.WriteVerbose(cmdlet, "name = " + UiElement.FromHandle(controlHandle).Current.Name); } catch {}
//            try{ cmdlet.WriteVerbose(cmdlet, "automationid = " + UiElement.FromHandle(controlHandle).Current.AutomationId); } catch {}
//            try{ cmdlet.WriteVerbose(cmdlet, "class = " + UiElement.FromHandle(controlHandle).Current.ClassName); } catch {}
//            try{ cmdlet.WriteVerbose(cmdlet, "control type = " + UiElement.FromHandle(controlHandle).Current.ControlType.ProgrammaticName); } catch {}
            
            // search at this level
            do {
//                cmdlet.WriteVerbose(
//                    cmdlet,
//                    "performing the search at level " + level.ToString());
                // 20131130
                // using null instead of name
                controlHandle =
                    NativeMethods.FindWindowEx(containerHandle, controlHandle, null, null);

                if (controlHandle == IntPtr.Zero) continue;
                controlHandles.Add(controlHandle);
                    
                    
//                cmdlet.WriteVerbose(
//                    cmdlet,
//                    "performing the recursive search at level " + (level + 1).ToString());
                    
                tempControlHandles =
                    GetControlByNameViaWin32Recursively(cmdlet, controlHandle, name, level + 1);
                //break;
                if (null == tempControlHandles || 0 == tempControlHandles.Count) continue;
                controlHandles.AddRange(tempControlHandles);
                /*
                foreach (IntPtr oneMoreHandle in tempControlHandles) {
                    controlHandles.Add(oneMoreHandle);
                }
                */

            } while (controlHandle != IntPtr.Zero);
            
            return controlHandles;
        }
        
//        internal static List<IUiElement> GetControlByNameViaWin32(
//            GetControlCmdletBase cmdlet,
//            IUiElement containerElement,
//            // 20131129
//            // string controlTitle)
//            string controlTitle,
//            string controlValue)
//        {
//            List<IUiElement> resultCollection = new List<IUiElement>();
//            
//            cmdlet.WriteVerbose(cmdlet, "checking the container control");
//
//            if (null == containerElement) { return resultCollection; }
//            cmdlet.WriteVerbose(cmdlet, "checking the Name parameter");
//            
//            controlTitle = string.IsNullOrEmpty(controlTitle) ? "*" : controlTitle;
//            // 20131129
//            controlValue = string.IsNullOrEmpty(controlValue) ? "*" : controlValue;
//            
//            try {
//                IntPtr containerHandle =
//                    new IntPtr(containerElement.Current.NativeWindowHandle);
//                if (containerHandle == IntPtr.Zero){
//                    cmdlet.WriteVerbose(cmdlet, "The container control has no handle");
//
//                    return resultCollection;
//                }
//                
//                List<IntPtr> handlesCollection =
//                    GetControlByNameViaWin32Recursively(cmdlet, containerHandle, controlTitle, 1);
//                
//                const WildcardOptions options =
//                    WildcardOptions.IgnoreCase |
//                    WildcardOptions.Compiled;
//                
//                WildcardPattern wildcardName =
//                    new WildcardPattern(controlTitle, options);
//                // 20131129
//                WildcardPattern wildcardValue =
//                    new WildcardPattern(controlValue, options);
//                
//                if (null == handlesCollection || 0 == handlesCollection.Count) return resultCollection;
//                cmdlet.WriteVerbose(cmdlet, "handles.Count = " + handlesCollection.Count.ToString());
//                
//                foreach (IntPtr controlHandle in handlesCollection) {
//                    try {
//                        cmdlet.WriteVerbose(cmdlet, "checking a handle");
//                        if (IntPtr.Zero == controlHandle) continue;
//                        cmdlet.WriteVerbose(cmdlet, "the handle is not null");
//                        
//                        IUiElement tempElement =
//                            UiElement.FromHandle(controlHandle);
//                        cmdlet.WriteVerbose(cmdlet, "adding the handle to the collection");
//                                
//                        cmdlet.WriteVerbose(cmdlet, controlTitle);
//                        cmdlet.WriteVerbose(cmdlet, tempElement.Current.Name);
//
//                        if (IsMatchWildcardPattern(cmdlet, resultCollection, tempElement, wildcardName, tempElement.Current.Name)) continue;
//                        // 20131129
//                        if (IsMatchWildcardPattern(cmdlet, resultCollection, tempElement, wildcardName, tempElement.Current.AutomationId)) continue;
//                        if (IsMatchWildcardPattern(cmdlet, resultCollection, tempElement, wildcardName, tempElement.Current.ClassName)) continue;
//                        try {
//                            string elementValue =
//                                (tempElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern).Current.Value;
//                            // 20131129
//                            if (IsMatchWildcardPattern(cmdlet, resultCollection, tempElement, wildcardName, elementValue)) continue;
//                            if (IsMatchWildcardPattern(cmdlet, resultCollection, tempElement, wildcardValue, elementValue)) continue;
//                        }
//                        catch { //(Exception eValuePattern) {
//                        }
//                    }
//                    catch (Exception eGetAutomationElementFromHandle) {
//                        cmdlet.WriteVerbose(cmdlet, eGetAutomationElementFromHandle.Message);
//                    }
//                }
//                return resultCollection;
//            } catch (Exception eWin32Control) {
//                cmdlet.WriteVerbose(cmdlet, "UiaHelper.GetControlByName() failed");
//                cmdlet.WriteVerbose(cmdlet, eWin32Control.Message);
//                return resultCollection;
//            }
//        }
        
//        private static bool IsMatchWildcardPattern(
//            PSCmdletBase cmdlet,
//            IList resultCollection,
//            IUiElement elementInput,
//            WildcardPattern wcPattern,
//            string dataToCheck)
//        {
//            bool result = false;
//            
//            if (string.IsNullOrEmpty(dataToCheck)) {
//                return result;
//            }
//            
//            if (!wcPattern.IsMatch(dataToCheck)) return result;
//            
//            result = true;
//            cmdlet.WriteVerbose(cmdlet, "name '" + dataToCheck + "' matches!");
//            resultCollection.Add(elementInput);
//            // 20131129
//            // result = true;
//            
//            return result;
//        }
        
        internal static void Highlight(IUiElement element)
        {
            try { if (_highlighter != null) { _highlighter.Dispose(); } } catch {}
            try { if (_highlighterParent != null) { _highlighterParent.Dispose(); } } catch {}
            //try { if (highlighterFirstChild != null) { highlighterFirstChild.Dispose(); } } catch {}
            
            if ((element as IUiElement) != null) {
                
                _highlighter =
                    new Highlighter(
                        element.Current.BoundingRectangle.Height,
                        element.Current.BoundingRectangle.Width,
                        element.Current.BoundingRectangle.X,
                        element.Current.BoundingRectangle.Y,
                        element.Current.NativeWindowHandle,
                        Highlighters.Element,
                        Preferences.HighlighterColor);
            }
            if (!Preferences.HighlightParent) return;
            
            IUiElement parent =
                // 20131204
                // GetParent(element);
                element.GetParent();
                
            _highlighterParent =
                new Highlighter(
                    parent.Current.BoundingRectangle.Height,
                    parent.Current.BoundingRectangle.Width,
                    parent.Current.BoundingRectangle.X,
                    parent.Current.BoundingRectangle.Y,
                    parent.Current.NativeWindowHandle,
                    Highlighters.Parent,
                    Preferences.HighlighterColorParent);
        }
        
        internal static void HighlightCheckedControl(IUiElement element)
        {
            try { if (_highlighterCheckedControl != null) { _highlighterCheckedControl.Dispose(); } } catch {}
            
            if ((element as IUiElement) != null) {

                _highlighterCheckedControl =
                    new Highlighter(
                        element.Current.BoundingRectangle.Height,
                        element.Current.BoundingRectangle.Width,
                        element.Current.BoundingRectangle.X,
                        element.Current.BoundingRectangle.Y,
                        element.Current.NativeWindowHandle,
                        Highlighters.Element,
                        Preferences.HighlighterColorCheckedControl);
            }
        }
        
        internal static void HideHighlighters()
        {
            try {
                _highlighter.Dispose();
                _highlighterParent.Dispose();
            }
            catch {}
        }
        
        public static void ShowBanner(string message)
        {
            try { if (null != _banner) { _banner.Dispose(); } } catch {}
            
            _banner =
                new Banner(
                    Preferences.BannerLeft,
                    Preferences.BannerTop,
                    Preferences.BannerWidth,
                    Preferences.BannerHeight,
                    message);
        }
        
        internal static void HideBanner()
        {
            if (null == _banner) return;
            try {
                _banner.Hide();
            }
            catch {}
            _banner.Dispose();
        }
        
        public static void AppendBanner(string message)
        {
            if (null != _banner) {
                
                _banner.AppendMessage(message);
                
            } else {
            
                _banner =
                    new Banner(
                        Preferences.BannerLeft,
                        Preferences.BannerTop,
                        Preferences.BannerWidth,
                        Preferences.BannerHeight,
                        message);
                
            }
        }
        
        public static void ClearBanner()
        {
            if (null != _banner) {
                
                _banner.Message = string.Empty;
            }
        }
        
        private static string GetTimedFileNameForScreenShot()
        {
            string result =
                Preferences.ScreenShotFolder +
                @"\" +
                PSTestHelper.GetTimedFileName();
            return result;
        }
        
        public static void GetScreenshotOfCmdletInput(
            HasControlInputCmdletBase cmdlet,
            string description,
            bool save,
            int Left,
            int Top,
            int Height,
            int Width,
            string path,
            ImageFormat format)
        {
            if (null == cmdlet.InputObject || !cmdlet.InputObject.Any()) {
                
                cmdlet.WriteVerbose(cmdlet, "(null == cmdlet.InputObject || 0 == cmdlet.InputObject.Length)");
                
                // 20131126
                //cmdlet.InputObject = new UiElement[] { (UiElement)UiElement.RootElement };
                cmdlet.InputObject = new[] { UiElement.RootElement };
            }
            
            cmdlet.WriteVerbose(
                cmdlet,
                "input array consists of " + cmdlet.InputObject.Count().ToString() + " objects");
            
            foreach (IUiElement inputObject in cmdlet.InputObject) {
                
                cmdlet.WriteVerbose(cmdlet, "calculating the size");
                int absoluteX = 0;
                int absoluteY = 0;
                int absoluteWidth =
                    Screen.PrimaryScreen.Bounds.Width;
                int absoluteHeight =
                    Screen.PrimaryScreen.Bounds.Height;
                
                if (inputObject == null) {
                    if (Left > 0) { absoluteX = Left; }
                    if (Top > 0) { absoluteY = Top; }
                    if (Height > 0) { absoluteHeight = Height; }
                    if (Width > 0) { absoluteWidth = Width; }
                }
                
                cmdlet.WriteVerbose(cmdlet, "X = " + absoluteX.ToString());
                cmdlet.WriteVerbose(cmdlet, "Y = " + absoluteY.ToString());
                cmdlet.WriteVerbose(cmdlet, "Height = " + absoluteHeight.ToString());
                cmdlet.WriteVerbose(cmdlet, "Width = " + absoluteWidth.ToString());

                if (inputObject != null && (int)inputObject.Current.ProcessId > 0) {
                    
                    absoluteX = (int)inputObject.Current.BoundingRectangle.X + Left;
                    absoluteY = (int)inputObject.Current.BoundingRectangle.Y + Top;
                    absoluteHeight = (int)inputObject.Current.BoundingRectangle.Height + Height;
                    absoluteWidth = (int)inputObject.Current.BoundingRectangle.Width + Width;
                }
                
                if (Height == 0) {Height = Screen.PrimaryScreen.Bounds.Height; }
                if (Width == 0) {Width = Screen.PrimaryScreen.Bounds.Width; }
                
                if (inputObject != null && (int)inputObject.Current.ProcessId > 0) {
                    
                    try {
                        
                        inputObject.SetFocus();
                    }
                    catch {
                        // ??

                    }
                }
                
                GetScreenshotOfSquare(
                    cmdlet,
                    description,
                    save,
                    absoluteX,
                    absoluteY,
                    absoluteHeight,
                    absoluteWidth,
                    path,
                    format);
            }
        }
        
        public static void GetScreenshotOfAutomationElement(
            PSCmdletBase cmdlet,
            IUiElement element,
            string description,
            bool save,
            int Left,
            int Top,
            int Height,
            int Width,
            string path,
            ImageFormat format)
        {
            
            cmdlet.WriteVerbose(cmdlet, "hiding highlighter if it's been used");
            
            try {
                
            if (Preferences.HideHighlighterOnScreenShotTaking &&
                ! Preferences.ShowExecutionPlan) {
                
                HideHighlighters();
            }
            
            cmdlet.WriteVerbose(cmdlet, "calculating the size");
            int absoluteX = 0;
            int absoluteY = 0;
            int absoluteWidth =
                Screen.PrimaryScreen.Bounds.Width;
            int absoluteHeight =
                Screen.PrimaryScreen.Bounds.Height;
            
            if (null == element) {
                if (Left > 0) { absoluteX = Left; }
                if (Top > 0) { absoluteY = Top; }
                if (Height > 0) { absoluteHeight = Height; }
                if (Width > 0) { absoluteWidth = Width; }
            }
            cmdlet.WriteVerbose(cmdlet, "X = " + absoluteX.ToString());
            cmdlet.WriteVerbose(cmdlet, "Y = " + absoluteY.ToString());
            cmdlet.WriteVerbose(cmdlet, "Height = " + absoluteHeight.ToString());
            cmdlet.WriteVerbose(cmdlet, "Width = " + absoluteWidth.ToString());

            if (null != element && 0 < (int)element.Current.ProcessId) {
                absoluteX = (int)element.Current.BoundingRectangle.X + Left;
                absoluteY = (int)element.Current.BoundingRectangle.Y + Top;
                absoluteHeight = (int)element.Current.BoundingRectangle.Height + Height;
                absoluteWidth = (int)element.Current.BoundingRectangle.Width + Width;
            }
            
            if (0 == Height) {Height = Screen.PrimaryScreen.Bounds.Height; }
            if (0 == Width) {Width = Screen.PrimaryScreen.Bounds.Width; }

            if (element != null && (int)element.Current.ProcessId > 0) {
                
                try {
                    
                    element.SetFocus();
                }
                catch {
                    // ??

                }
            }
            
            GetScreenshotOfSquare(
                cmdlet,
                description,
                save,
                absoluteX,
                absoluteY,
                absoluteHeight,
                absoluteWidth,
                path,
                format);
            }
            catch {}
        }
        
        [STAThread]
        public static void GetScreenshotOfSquare(//HasTimeoutCmdletBase cmdlet,
                                                 PSCmdletBase cmdlet,
                                                 string description,
                                                 bool save,
                                                 int absoluteX, //int Left, //, = 0,
                                                 int absoluteY, //int Top, // = 0,
                                                 int absoluteHeight, //int Height, // = 0,
                                                 int absoluteWidth, //int Width,
                                                 string path, //)// = 0) //, int monitor)
                                                 ImageFormat format)
        {
            Image myImage =
                new Bitmap(absoluteWidth,
                           absoluteHeight);
            
            Graphics gr1 = Graphics.FromImage(myImage);
            IntPtr dc1 = gr1.GetHdc();
            
            // for now, the primary display only
            IntPtr desktopHandle = NativeMethods.GetDesktopWindow();
            IntPtr dc2 = NativeMethods.GetWindowDC(desktopHandle);
            // IntPtr dc2 = GetWindowDC(GetDesktopWindow());
            NativeMethods.BitBlt(dc1, 0, 0, absoluteWidth,
                                 absoluteHeight, dc2, absoluteX, absoluteY, 13369376);
            gr1.ReleaseHdc(dc1);
            //  // 
            NativeMethods.ReleaseDC(desktopHandle, dc2);
            //  // 
            if (save) {
                if (!string.IsNullOrEmpty(description) &&
                    description.Length > 0) {
                    
                    description =
                        "_" +
                        description;
                }
                
                string fileName = string.Empty;
                if (!string.IsNullOrEmpty(path) &&
                    path.Length > 0 &&
                    path != @"\") { // && ! System.IO.File.Exists(path)) {
                    
                    if (File.Exists(path)) {
                        
                        cmdlet.WriteError(
                            cmdlet,
                            "File '" +
                            path +
                            "' already exists",
                            "FileAlreadyExists",
                            ErrorCategory.InvalidArgument,
                            true);
                    }
                    
                    fileName = path;
                } else {
                    
                    if (cmdlet is SaveUiaScreenshotCommand) {
                        
                        fileName =
                            GetTimedFileNameForScreenShot() +
                            description +
                            GetFileExtensionByImageType(format);
                        
                    } else {  // ??
                        
                        fileName =
                            GetTimedFileNameForScreenShot() +
                            description +
                            GetFileExtensionByImageType(format);
                        
                    }
                }
                
                myImage.Save(fileName, format);
                
                TmxHelper.AddTestResultScreenshotDetail(fileName);
            } else {
                
                cmdlet.WriteObject(cmdlet, myImage);
            }
            //  //  //
            // ReleaseDC(desktopHandle, dc2);  //// ??
            //  // 
            
            //} // 20120823
            
            
        }  //// ??
        
        private static string GetFileExtensionByImageType(ImageFormat format)
        {
            string result = string.Empty;
            
            switch (format.ToString().ToUpper()) {
                case "BMP":
                    result = ".bmp";
                    break;
                case "EMF":
                    result = ".emf";
                    break;
                case "EXIF":
                    result = ".exif";
                    break;
                case "GIF":
                    result = ".gif";
                    break;
                case "ICON":
                    result = ".ico";
                    break;
                case "JPEG":
                    result = ".jpg";
                    break;
                case "MEMORYBMP":
                    result = ".mbmp";
                    break;
                case "PNG":
                    result = ".png";
                    break;
                case "TIFF":
                    result = ".tif";
                    break;
                case "WMF":
                    result = ".wmf";
                    break;
                    //default:
                    //
                    //	break;
            }
            
            
            return result;
        }
        
        #region Start-UiaTranscript
        
        // 20131204
//        private static string _errorMessageInTheGatheringCycle = String.Empty;
//        private static bool _errorInTheGatheringCycle = false;
//        private static string _errorMessageInTheInnerCycle = String.Empty;
//        private static bool _errorInTheInnerCycle = false;
        
        /// <summary>
        ///
        /// </summary>
        /// <param name="cmdlet"></param>
        internal static void ProcessingTranscript(TranscriptCmdletBase cmdlet)
        {
            Global.GTranscript = true;
            int counter = 0;
            
            cmdlet.OddRootElement =
                UiElement.RootElement;

            cmdlet.StartDate =
                DateTime.Now;
            do
            {
                // 20131108
                // refactoring
                // experimental
                counter++;
                // 20131114
                //bool res = ProcessingTranscriptOnce(cmdlet, counter);
                bool res = ProcessingTranscriptOnce(cmdlet, counter, Cursor.Position);
                if (!res) break;
                
            } while (Global.GTranscript);
        }
        
        //internal static bool ProcessingTranscriptOnce(TranscriptCmdletBase cmdlet,
        /// <summary>
        ///
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="counter"></param>
        /// <returns></returns>
        public static bool ProcessingTranscriptOnce(
            TranscriptCmdletBase cmdlet,
            // 20131114
            //int counter)
            int counter,
            System.Drawing.Point mousePoint)
        {
            cmdlet.RunOnSleepScriptBlocks(cmdlet, null);
            Thread.Sleep(Preferences.TranscriptInterval);
            while (cmdlet.Paused) {
                Thread.Sleep(Preferences.TranscriptInterval);
            }
            counter++;
            
            try {
                // use Windows forms mouse code instead of WPF
                // 20131114
                // System.Drawing.Point mouse = System.Windows.Forms.Cursor.Position;
                // 20131109
                //System.Windows.Automation.AutomationElement element =
                //    System.Windows.Automation.AutomationElement.FromPoint(
                //        new System.Windows.Point(mouse.X, mouse.Y));
                IUiElement element =
                    UiElement.FromPoint(
                        // 20131114
                        //new System.Windows.Point(mouse.X, mouse.Y));
                        new System.Windows.Point(mousePoint.X, mousePoint.Y));
                if (element != null && (int)element.Current.ProcessId > 0)
                {
                    ProcessingElement(cmdlet, element);
                }
                if (_errorInTheGatheringCycle) {
                    cmdlet.WriteDebug(cmdlet, "An error is in the control hierarchy gathering cycle");
                    cmdlet.WriteDebug(cmdlet, _errorMessageInTheGatheringCycle);
                    _errorInTheGatheringCycle = false;
                }
            } catch (Exception eUnknown) {
                cmdlet.WriteDebug(cmdlet, eUnknown.Message);
            }
            DateTime nowDate = DateTime.Now;
            return !((nowDate - cmdlet.StartDate).TotalSeconds > cmdlet.Timeout / 1000);
        }
        
        #region working with an element
        //private static void processingElement(TranscriptCmdletBase cmdlet, AutomationElement element)
        /// <summary>
        ///
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="element"></param>
        public static bool ProcessingElement(
            TranscriptCmdletBase cmdlet,
            IUiElement element)
            // 20120618 UiaCOMWrapper
            //UiaCOM::System.Windows.Automation.AutomationElement element)
        {
            bool result = false;
            // UiaHelper.Highlight(element);
            try {
                CacheRequest cacheRequest = new CacheRequest
                {
                    AutomationElementMode = AutomationElementMode.Full,
                    TreeFilter = Automation.RawViewCondition
                };
                //cacheRequest.AutomationElementMode = AutomationElementMode.None;
                cacheRequest.Add(AutomationElement.NameProperty);
                cacheRequest.Add(AutomationElement.AutomationIdProperty);
                cacheRequest.Add(AutomationElement.ClassNameProperty);
                cacheRequest.Add(AutomationElement.ControlTypeProperty);
                cacheRequest.Add(AutomationElement.ProcessIdProperty);
                cacheRequest.Add(DockPattern.Pattern);
                cacheRequest.Add(ExpandCollapsePattern.Pattern);
                cacheRequest.Add(GridItemPattern.Pattern);
                cacheRequest.Add(GridPattern.Pattern);
                cacheRequest.Add(InvokePattern.Pattern);
                //                try {
                //                    cacheRequest.Add(ItemContainerPattern.Pattern);
                //                }
                //                catch {}
                cacheRequest.Add(MultipleViewPattern.Pattern);
                cacheRequest.Add(RangeValuePattern.Pattern);
                cacheRequest.Add(ScrollItemPattern.Pattern);
                cacheRequest.Add(ScrollPattern.Pattern);
                cacheRequest.Add(SelectionItemPattern.Pattern);
                cacheRequest.Add(SelectionPattern.Pattern);
                //                try {
                //                    cacheRequest.Add(SynchronizedInputPattern.Pattern);
                //                }
                //                catch {}
                cacheRequest.Add(TableItemPattern.Pattern);
                cacheRequest.Add(TablePattern.Pattern);
                cacheRequest.Add(TextPattern.Pattern);
                cacheRequest.Add(TogglePattern.Pattern);
                cacheRequest.Add(TransformPattern.Pattern);
                cacheRequest.Add(ValuePattern.Pattern);
                //                try {
                //                    cacheRequest.Add(VirtualizedItemPattern.Pattern);
                //                }
                //                catch {}
                cacheRequest.Add(WindowPattern.Pattern);
                // cache patterns?
                
                // cacheRequest.Activate();
                cacheRequest.Push();
                
                try{
                    element.FindFirst(TreeScope.Element, System.Windows.Automation.Condition.TrueCondition);
                }
                catch {
                }
                // element.GetUpdatedCache(cacheRequest);
                
                // if (lastRecordedItem.Count == 0 || element != lastRecordedItem[0]) {
                try {
                    // lastRecordedItem = new System.Collections.ArrayList();
                    cmdlet.WriteVerbose(cmdlet, "getting ControlType");
                    
                    // 20130207
                    string elementControlType =
                        // 20131204
                        // GetElementControlTypeString(element);
                        element.GetElementControlTypeString();
                    if (string.IsNullOrEmpty(elementControlType)) {
                        return result;
                    }
                    
                    string elementVerbosity = String.Empty; // ?

                    elementVerbosity =
                        "Get-Uia" + elementControlType;
                    
                    // collecting the element's properties for parameters
                    bool hasName = false;
                    elementVerbosity +=
                        // 20131204
                        // GetElementPropertyString(cmdlet, element, "AutomationId", null, ref hasName);
                        element.GetElementPropertyString(cmdlet, "AutomationId", null, ref hasName);
                    if (!cmdlet.NoClassInformation) {
                        elementVerbosity +=
                            // 20131204
                            // GetElementPropertyString(cmdlet, element, "Class", null, ref hasName);
                            element.GetElementPropertyString(cmdlet, "Class", null, ref hasName);
                    }
                    elementVerbosity +=
                        // 20131204
                        // GetElementPropertyString(cmdlet, element, "Name", null, ref hasName);
                        element.GetElementPropertyString(cmdlet, "Name", null, ref hasName);
                    try {
                        IMySuperValuePattern pattern =
                            // 20131208
                            // element.GetCurrentPattern(ValuePattern.Pattern) as IMySuperValuePattern;
                            // element.GetCurrentPattern<IMySuperValuePattern, ValuePattern>(ValuePattern.Pattern) as IMySuperValuePattern;
                            element.GetCurrentPattern<IMySuperValuePattern>(ValuePattern.Pattern);
                        elementVerbosity +=
                            // 20131204
                            // GetElementPropertyString(cmdlet, element, "Value", pattern, ref hasName);
                            element.GetElementPropertyString(cmdlet, "Value", pattern, ref hasName);
                    }
                    catch {}
                    if (hasName) {
                        elementVerbosity +=
                            // 20131204
                            // GetElementPropertyString(cmdlet, element, "Win32", null, ref hasName);
                            element.GetElementPropertyString(cmdlet, "Win32", null, ref hasName);
                    }
                    cmdlet.WriteVerbose(cmdlet,
                                        "the concatenated result is: " +
                                        elementVerbosity);
                    // collected
                    
                    if (cmdlet.LastRecordedItem.Count == 0 || elementVerbosity != cmdlet.LastRecordedItem[0].ToString()) {
                        
                        if (!cmdlet.NoEvents) {
                            cmdlet.WriteVerbose(cmdlet, "unsubscribe events");
                            UnsubscribeFromEventsDuringRecording(cmdlet); // thePreviouslyUsedElement);
                            cmdlet.WriteVerbose(cmdlet, "events were unsubscribed");
                        }
                        
                        try{
                            Highlight(element);
                        }
                        catch {
                        }
                        
                        cmdlet.LastRecordedItem = new List<string>();
                        string strElementPatterns = String.Empty;
                        
                        // if (WriteCurrentPattern) {
                        // strElementPatterns = String.Empty;
string strInfo = string.Empty;
strInfo += element.GetSourceElement().Current.Name;
AutomationPattern[] ppps = element.GetSourceElement().GetSupportedPatterns();
foreach (AutomationPattern pppp in ppps) {
    strInfo += pppp.ProgrammaticName;
}
                        try {
                            // 20131209
                            // AutomationPattern[] elementPatterns =
                            //     element.GetSupportedPatterns();
                            IBasePattern[] elementPatterns =
                                element.GetSupportedPatterns();
                                // element.GetSourceElement().GetSupportedPatterns().ConvertAutomationPatternToBasePattern(element);
strInfo += "01";
                            
                            if (!cmdlet.NoEvents) {
strInfo += " 02";
                                SubscribeToEventsDuringRecording(cmdlet, element, elementPatterns);
strInfo += " 03";
                            }
                            
                            if (cmdlet.WriteCurrentPattern) {
strInfo += " 04";
                                // 20131209
                                // foreach (AutomationPattern ptrn in elementPatterns)
                                foreach (IBasePattern ptrn in elementPatterns)
                                {
strInfo += " 05";
                                    strElementPatterns += "\r\n\t\t#";
if (null == ptrn.SourcePattern) {
    strInfo += " ";
    strInfo += ptrn.GetType().Name;
    strInfo += " is null";
}
                                    strElementPatterns +=
                                        // 20131209
                                        // ptrn.ProgrammaticName.Replace("Identifiers.Pattern", "");
                                        // 20131210
                                        // (ptrn.SourcePattern as AutomationPattern).ProgrammaticName.Replace("Identifiers.Pattern", "");
                                        (ptrn.SourcePattern as AutomationPattern).ProgrammaticName.Replace("Identifiers.Pattern", string.Empty);
strInfo += " 06";
                                    strElementPatterns += ": use the ";
                                    
                                    string tempControlNameForCmdlet =
                                        "-UIA" +
                                        elementControlType;
strInfo += " 07";
                                    
                                    // 20131209
                                    // switch (ptrn.ProgrammaticName.Replace("Identifiers.Pattern", "")) {
                                    // 20131210
                                    // switch ((ptrn as AutomationPattern).ProgrammaticName.Replace("Identifiers.Pattern", "")) {
                                    // switch ((ptrn.SourcePattern as AutomationPattern).ProgrammaticName.Replace("Identifiers.Pattern", "")) {
                                    switch ((ptrn.SourcePattern as AutomationPattern).ProgrammaticName.Replace("Identifiers.Pattern", string.Empty)) {
                                        case "InvokePattern":
                                            strElementPatterns +=
                                                "Invoke" + tempControlNameForCmdlet + "Click";
                                            break;
                                        case "ValuePattern":
                                            strElementPatterns +=
                                                "Set" + tempControlNameForCmdlet + "Text, Get" + tempControlNameForCmdlet + "Text";
                                            break;
                                        case "RangeValuePattern":
                                            strElementPatterns +=
                                                "Set" + tempControlNameForCmdlet + "RangeValue, Get" + tempControlNameForCmdlet + "RangeValue";
                                            break;
                                        case "SelectionItemPattern":
                                            string tempName = string.Empty;
                                            try {
                                                if (element.Current.Name.Length > 0) {
                                                    tempName = element.Current.Name;
                                                }
                                            }
                                            catch {
                                                if (element.Cached.Name.Length > 0) {
                                                    tempName = element.Cached.Name;
                                                }
                                            }
                                            strElementPatterns +=
                                                "Invoke" +
                                                tempControlNameForCmdlet +
                                                "SelectItem -ItemName '" +
                                                tempName +
                                                "', Get" +
                                                tempControlNameForCmdlet +
                                                "SelectionItemState";
                                            break;
                                        case "SelectionPattern":
                                            strElementPatterns +=
                                                "Get" + tempControlNameForCmdlet + "Selection";
                                            break;
                                        case "ExpandCollapsePattern":
                                            strElementPatterns +=
                                                "Invoke" +
                                                tempControlNameForCmdlet +
                                                "Expand, Invoke" +
                                                tempControlNameForCmdlet +
                                                "Collapse";
                                            break;
                                        case "TogglePattern":
                                            strElementPatterns +=
                                                "Invoke" +
                                                tempControlNameForCmdlet +
                                                "Toggle, Get" +
                                                tempControlNameForCmdlet +
                                                "ToggleState";
                                            break;
                                        case "TransformPattern":
                                            strElementPatterns +=
                                                "Invoke" +
                                                tempControlNameForCmdlet +
                                                "TransformMove, Invoke" +
                                                tempControlNameForCmdlet +
                                                "TransformResize, Invoke" +
                                                tempControlNameForCmdlet +
                                                "TransformRotate";
                                            break;
                                        case "WindowPattern":
                                            strElementPatterns +=
                                                "Invoke" + tempControlNameForCmdlet + "WindowState";
                                            break;
                                            //                                                case "Pattern":
                                            //                                                    strElementPatterns +=
                                            //                                                        "Invoke" + tempControlNameForCmdlet + "Click";
                                            //                                                    break;
                                    }
                                    strElementPatterns += " cmdlet(s)";
                                }
                                if (strElementPatterns.Length == 0) {
                                    strElementPatterns += "\r\n\t\t# no supported pattterns";
                                }
                            }
                            strElementPatterns += "\r\n";
                        } catch (Exception ePatterns) {
                                                                Exception ePatterns2 =
                                                                    new Exception("Patterns:\r\n" +
                                                                                  ePatterns.Message +
                                                                                  "\r\n" +
                                                                                  strInfo);
                            throw(ePatterns2);
                            //return result;
                            // ErrorRecord
                            // 20120126
                            //                                    if (element == null) { // ||
                            //                                        //(element != null && element.Cached != null) ||
                            //                                        //(element != null && (int)element.Current.ProcessId == 0)) {
                            //                                        // continue;
                            //                                        return;
                            //                                    }
                        }
                        //}
                        cmdlet.LastRecordedItem.Add(elementVerbosity);
                        try { cmdlet.WriteVerbose(elementVerbosity); }
                        catch {
                            return result;
                        }
                        
                        if (element == null) { return result; } // 20120306
                        try{
                            // 20131204
                            // collectAncestors(cmdlet, element);
                            element.CollectAncestors(cmdlet, ref _errorMessageInTheInnerCycle, ref _errorInTheInnerCycle);
                        }
                        catch { //(Exception eCollecingAncestors) {
                            //                                Exception eCollecingAncestors2 =
                            //                                    new Exception("Collecting ancestors:\r\n" +
                            //                                                  eCollecingAncestors.Message);
                            //throw(eCollecingAncestors2);
                            //return result;
                        }

                        if (!_errorInTheInnerCycle) {
                            if (cmdlet.LastRecordedItem.Count > 0) {
                                cmdlet.Recording.Add(cmdlet.LastRecordedItem);
                                if (cmdlet.WriteCurrentPattern) {
                                    cmdlet.RecordingPatterns.Add(strElementPatterns);
                                }
                            }
                        }
                        // inTheOutercycle:
                        
                        cmdlet.thePreviouslyUsedElement = element;
                        
                    }
                } catch (Exception eGatheringCycle) {
                    _errorInTheGatheringCycle = true;
                    _errorMessageInTheGatheringCycle =
                        eGatheringCycle.Message;
                    //throw (eGatheringCycle);
                    Exception eGatheringCycle2 =
                        new Exception(
                            "Gathering cycle\r\n" +
                            eGatheringCycle.Message);
                    throw (eGatheringCycle2);
                }
                cacheRequest.Pop();
                result = true;
                return result;
                
            } catch (Exception eUnknown) {
                try {cmdlet.WriteDebug(cmdlet, eUnknown.Message); }
                catch {}
                //throw (eUnknown);
                Exception eUnknown2 =
                    new Exception(
                        "Unknown\r\n" +
                        eUnknown.Message);
                throw (eUnknown2);
            }
        }

//        /// <summary>
//        /// Retrieves such element's properties as AutomationId, Name, Class(Name) and Value
//        /// </summary>
//        /// <param name="cmdlet">cmdlet to report</param>
//        /// <param name="element">The element properties taken from</param>
//        /// <param name="propertyName">The name of property</param>
//        /// <param name="pattern">an object of the ValuePattern type</param>
//        /// <param name="hasName">an object has Name</param>
//        /// <returns></returns>
//        // 20131109
//        //private static string getElementPropertyString(TranscriptCmdletBase cmdlet, AutomationElement element, string propertyName, ValuePattern pattern, ref bool hasName)
//        private static string GetElementPropertyString(
//            PSCmdletBase cmdlet,
//            /*
//            TranscriptCmdletBase cmdlet,
//            */
//            IUiElement element,
//            string propertyName,
//            // 20131124
//            // ValuePattern -> IMySuperValuePattern
//            //ValuePattern pattern,
//            IMySuperValuePattern pattern,
//            ref bool hasName)
//        {
//            cmdlet.WriteVerbose(cmdlet, "getting " + propertyName);
//            string tempString = string.Empty;
//            try {
//                
//                switch (propertyName) {
//                    case "Name":
//                        if (0 < element.Current.Name.Length) {
//                            tempString = element.Current.Name;
//                            hasName = true;
//                        }
//                        break;
//                    case "AutomationId":
//                        if (0 < element.Current.AutomationId.Length) {
//                            tempString = element.Current.AutomationId;
//                        }
//                        break;
//                    case "Class":
//                        if (0 < element.Current.ClassName.Length) {
//                            tempString = element.Current.ClassName;
//                        }
//                        break;
//                    case "Value":
//                        if (!string.IsNullOrEmpty(pattern.Current.Value)) {
//                            tempString = pattern.Current.Value;
//                            hasName = true;
//                        }
//                        break;
//                    case "Win32":
//                        if (0 < element.Current.NativeWindowHandle) {
//                            tempString = ".";
//                        }
//                        break;
//                    default:
//                        
//                    	break;
//                }
//            } catch {
//                switch (propertyName) {
//                    case "Name":
//                        if (0 < element.Cached.Name.Length) {
//                            tempString = element.Cached.Name;
//                            hasName = true;
//                        }
//                        break;
//                    case "AutomationId":
//                        if (0 < element.Cached.AutomationId.Length) {
//                            tempString = element.Cached.AutomationId;
//                        }
//                        break;
//                    case "Class":
//                        if (0 < element.Cached.ClassName.Length) {
//                            tempString = element.Cached.ClassName;
//                        }
//                        break;
//                    case "Value":
//                        if (!string.IsNullOrEmpty(pattern.Cached.Value)) {
//                            tempString = pattern.Cached.Value;
//                            hasName = true;
//                        }
//                        break;
//                    case "Win32":
//                        if (0 < element.Cached.NativeWindowHandle) {
//                            tempString = ".";
//                        }
//                        break;
//                    default:
//                        
//                    	break;
//                }
//            }
//            if (string.IsNullOrEmpty(tempString)) {
//                return string.Empty;
//            } else {
//                if ("Win32" == propertyName) {
//                    tempString =
//                        " -" + propertyName;
//                } else {
//                    tempString =
//                        " -" + propertyName + " '" + tempString + "'";
//                }
//                return tempString;
//            }
//        }

//        /// <summary>
//        /// Retrievs an element's ControlType property as a string.
//        /// </summary>
//        /// <param name="element">AutomationElement</param>
//        /// <returns>string</returns>
//        // 20131109
//        //private static string getElementControlTypeString(AutomationElement element)
//        private static string GetElementControlTypeString(IUiElement element)
//        {
//            string elementControlType = String.Empty;
//            try {
//                elementControlType = element.Current.ControlType.ProgrammaticName;
//            } catch {
//                elementControlType = element.Cached.ControlType.ProgrammaticName;
//            }
//            if (string.Empty != elementControlType && 0 < elementControlType.Length) {
//                elementControlType = elementControlType.Substring(elementControlType.IndexOf('.') + 1);
//            }
//            //string elementVerbosity = String.Empty;
//            //if (string.Empty == elementControlType || 0 == elementControlType.Length) {
//            //    return result;
//            //}
//            return elementControlType;
//        }
        #endregion working with an element
        
        #region collect ancestors
        // 20131109
        //internal static AutomationElement GetParent(AutomationElement element)
//        internal static IUiElement GetParent(IUiElement element)
//        {
//            // 20131109
//            //AutomationElement result = null;
//            IUiElement result = null;
//            
//            TreeWalker walker =
//                new TreeWalker(
//                    System.Windows.Automation.Condition.TrueCondition);
//            
//            try {
//                result = AutomationFactory.GetUiElement(walker.GetParent(element.GetSourceElement()));
//            }
//            catch {}
//            
//            return result;
//        }
        
//        internal static IUiElement GetFirstChild(IUiElement element)
//        {
//            IUiElement result = null;
//            
//            TreeWalker walker =
//                new TreeWalker(
//                    System.Windows.Automation.Condition.TrueCondition);
//            
//            try {
//                result = AutomationFactory.GetUiElement(walker.GetFirstChild(element.GetSourceElement()));
//            }
//            catch {}
//            
//            return result;
//        }
        
//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="cmdlet"></param>
//        /// <param name="element"></param>
//        // private static void collectAncestors(TranscriptCmdletBase cmdlet, IUiElement element)
//        public static void collectAncestors(this IUiElement element, TranscriptCmdletBase cmdlet)
//        {
//            TreeWalker walker =
//                new TreeWalker(
//                    System.Windows.Automation.Condition.TrueCondition);
//            // 20131109
//            //System.Windows.Automation.AutomationElement testparent;
//
//            try
//            {
//                // commented out 201206210
//                //testparent =
//                //    walker.GetParent(element);
//                IUiElement testParent = element;
//
//                while (testParent != null && (int)testParent.Current.ProcessId > 0) {
//                    
//                    testParent =
//                        AutomationFactory.GetUiElement(walker.GetParent(testParent.GetSourceElement()));
//                    
//                    if (testParent == null || (int) testParent.Current.ProcessId <= 0) continue;
//                    if (testParent == cmdlet.OddRootElement)
//                    { testParent = null; }
//                    else{
//                        string parentControlType =
//                            // getControlTypeNameOfAutomationElement(testparent, element);
//                            // testparent.Current.ControlType.ProgrammaticName.Substring(
//                            // element.Current.ControlType.ProgrammaticName.IndexOf('.') + 1);
//                            //  // experimental
//                            testParent.Current.ControlType.ProgrammaticName.Substring(
//                                testParent.Current.ControlType.ProgrammaticName.IndexOf('.') + 1);
//                        //  // if (parentControlType.Length == 0) {
//                        // break;
//                        //}
//                            
//                        // in case this element is an upper-level Pane
//                        // residing directrly under the RootElement
//                        // change type to window
//                        // i.e. Get-UiaPane - >  Get-UiaWindow
//                        // since Get-UiaPane is unable to get something more than
//                        // a window's child pane control
//                        if (parentControlType == "Pane" || parentControlType == "Menu") {
//                            
//                            // 20131109
//                            //if (walker.GetParent(testParent) == cmdlet.rootElement) {
//                            // 20131112
//                            //if ((new UiElement(walker.GetParent(testParent.SourceElement))) == cmdlet.oddRootElement) {
//                            // 20131118
//                            // property to method
//                            //if (ObjectsFactory.GetUiElement(walker.GetParent(testParent.SourceElement)) == cmdlet.oddRootElement) {
//                            if (AutomationFactory.GetUiElement(walker.GetParent(testParent.GetSourceElement())) == cmdlet.OddRootElement) {
//                                parentControlType = "Window";
//                            }
//                        }
//                            
//                        string parentVerbosity =
//                            @"Get-Uia" + parentControlType;
//                        try {
//                            if (testParent.Current.AutomationId.Length > 0) {
//                                parentVerbosity += (" -AutomationId '" + testParent.Current.AutomationId + "'");
//                            }
//                        }
//                        catch {
//                        }
//                        if (!cmdlet.NoClassInformation) {
//                            try {
//                                if (testParent.Current.ClassName.Length > 0) {
//                                    parentVerbosity += (" -Class '" + testParent.Current.ClassName + "'");
//                                }
//                            }
//                            catch {
//                            }
//                        }
//                        try {
//                            if (testParent.Current.Name.Length > 0) {
//                                parentVerbosity += (" -Name '" + testParent.Current.Name + "'");
//                            }
//                        }
//                        catch {
//                        }
//
//                        if (cmdlet.LastRecordedItem[cmdlet.LastRecordedItem.Count - 1].ToString() == parentVerbosity)
//                            continue;
//                        cmdlet.LastRecordedItem.Add(parentVerbosity);
//                        cmdlet.WriteVerbose(parentVerbosity);
//                    }
//                }
//            }
//            catch (Exception eErrorInTheInnerCycle) {
//                cmdlet.WriteDebug(cmdlet, eErrorInTheInnerCycle.Message);
//                _errorMessageInTheInnerCycle =
//                    eErrorInTheInnerCycle.Message;
//                _errorInTheInnerCycle = true;
//            }
//        }
        
//        // 20131109
//        //public static void CollectAncestors(TranscriptCmdletBase cmdlet, AutomationElement element)
//        public static void CollectAncestors(TranscriptCmdletBase cmdlet, IUiElement element)
//        {
//            collectAncestors(cmdlet, element);
//        }
        #endregion collect ancestors
        
        #region Subscribe to events during the recording session
        /// <summary>
        ///
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="element"></param>
        /// <param name="supportedPatterns"></param>
        internal static void SubscribeToEventsDuringRecording(HasControlInputCmdletBase cmdlet,
                                                              // 20131109
                                                              //AutomationElement element,
                                                              IUiElement element,
                                                              // 20131209
                                                              // AutomationPattern[] supportedPatterns)
                                                              IBasePattern[] supportedPatterns)
        {
            try { // experimental
                
                if (element == null) { return; }
                if (supportedPatterns == null ||
                    supportedPatterns.Length < 1) { return; }
                try {
                    
                    // cache requiest object for collecting properties
                    CacheRequest cacheRequest = null;
                    
                    try {
                        cacheRequest = new CacheRequest
                        {
                            AutomationElementMode = AutomationElementMode.None,
                            TreeFilter = Automation.RawViewCondition
                        };
                        cacheRequest.Add(AutomationElement.NameProperty);
                        // cacheRequest.Add(AutomationElement.AutomationIdProperty);
                        cacheRequest.Add(AutomationElement.ControlTypeProperty);
                        // cacheRequest.Add(AutomationElement.ClassNameProperty);
                        // cacheRequest.Push();
                        cacheRequest.Activate();
                        // element.FindFirst(TreeScope.Element, Condition.TrueCondition);
                    } catch (Exception eCacheRequest) {
                        cmdlet.WriteVerbose(cmdlet, "Cache request failed for " + element.Current.Name);
                        cmdlet.WriteVerbose(cmdlet, eCacheRequest.Message);
                    }
                    
                    // 20131209
                    // foreach (AutomationPattern pattern in supportedPatterns) {
                    foreach (IBasePattern pattern in supportedPatterns) {
                        try {
                            if (element == null) { break; }
                            cmdlet.AutomationEventHandler =
                                cmdlet.OnUIRecordingAutomationEvent;
                            // 20131209
                            // switch (pattern.ProgrammaticName) {
                            // 20131210
                            // switch ((pattern as AutomationPattern).ProgrammaticName) {
                            switch ((pattern.SourcePattern as AutomationPattern).ProgrammaticName) {
                                case "SelectionItemPatternIdentifiers.Pattern":
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             SelectionItemPattern.ElementAddedToSelectionEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             SelectionItemPattern.ElementRemovedFromSelectionEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             SelectionItemPattern.ElementSelectedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    break;
                                case "SelectionPatternIdentifiers.Pattern":
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             SelectionPattern.InvalidatedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    break;
                                case "InvokePatternIdentifiers.Pattern":
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             InvokePattern.InvokedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    break;
                                case "AutomationElementIdentifiers.Pattern":
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             AutomationElement.AsyncContentLoadedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             AutomationElement.LayoutInvalidatedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             AutomationElement.MenuClosedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             AutomationElement.MenuOpenedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             AutomationElement.ToolTipClosedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             AutomationElement.ToolTipOpenedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             AutomationElement.AutomationFocusChangedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             AutomationElement.AutomationPropertyChangedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             AutomationElement.StructureChangedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    break;
                                case "TextPatternIdentifiers.Pattern":
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             TextPattern.TextChangedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             TextPattern.TextSelectionChangedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    break;
                                case "WindowPatternIdentifiers.Pattern":
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             WindowPattern.WindowOpenedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             WindowPattern.WindowClosedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    break;
                            }
                        }
                        catch {
                            cmdlet.WriteVerbose(cmdlet,
                                                "Unable to register an " +
                                                // 20131209
                                                // pattern.ProgrammaticName +
                                                // 20131210
                                                // (pattern as AutomationPattern).ProgrammaticName +
                                                (pattern.SourcePattern as AutomationPattern).ProgrammaticName +
                                                " event for " +
                                                element.Current.Name);
                        }
                        //  // finish our cache request
                        // cacheRequest.Pop();
                    }
                    
                    // finish our cache request
                    cacheRequest.Pop();
                    
                }
                catch { return; }  // ??????????
                cmdlet.ElementToSubscribe = element; // ???????????????
                
                
            }
            catch (Exception eUnknown) {
                // WriteVerbose("!!!!!subscribeEvents " + eUnknown.Message);
                cmdlet.WriteDebug(cmdlet, eUnknown.Message);
            } // experimental
        }
        #endregion Subscribe to events during the recording session
        
        #region Unsubscribe from events during the recording session
        /// <summary>
        ///  /// </summary>
        /// <param name="cmdlet"></param>
        private static void UnsubscribeFromEventsDuringRecording(TranscriptCmdletBase cmdlet)
        {
            try
            {
                if (cmdlet.SubscribedEvents == null || cmdlet.SubscribedEvents.Count <= 0 ||
                    cmdlet.thePreviouslyUsedElement == null) return;
                for (int i = 0; i < cmdlet.SubscribedEvents.Count; i++) {
                    Automation.RemoveAutomationEventHandler(
                        // 20131202
                        // (AutomationEvent)cmdlet.SubscribedEventsIds[i],
                        cmdlet.SubscribedEventsIds[i],
                        cmdlet.thePreviouslyUsedElement.GetSourceElement(),
                        // 20131202
                        // (AutomationEventHandler)cmdlet.SubscribedEvents[i]);
                        cmdlet.SubscribedEvents[i]);
                }
            }
            catch (Exception eUnknown) {
                cmdlet.WriteDebug(cmdlet, eUnknown.Message);
                return;
            }
        }
        #endregion Unsubscribe from events during the recording session
        
        #endregion Start-UiaTranscript
        
        /// <summary>
        ///  /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="handle"></param>
        /// <returns></returns>
        public static IUiElement GetAutomationElementFromHandle(
            PSCmdletBase cmdlet,
            int handle)
        {
            // 20131109
            //System.Windows.Automation.AutomationElement result =
            //    null;
            IUiElement result = null;
            
            if (handle == 0) {
                cmdlet.WriteVerbose(cmdlet, "handle == 0");
                return result;
            }
            try {
                //System.IntPtr pHwnd = IntPtr.Zero;
                IntPtr pHwnd = new IntPtr(handle);
                cmdlet.WriteVerbose(cmdlet, "getting the control");
                // 20131109
                //element =
                //    AutomationElement.FromHandle(pHwnd);
                // 20131112
                //element =
                //    new UiElement(AutomationElement.FromHandle(pHwnd));
                _element =
                    AutomationFactory.GetUiElement(AutomationElement.FromHandle(pHwnd));
                if (_element != null) {
                    cmdlet.WriteVerbose(cmdlet, _element.Current.Name);
                }
                result = _element;
            }
            catch (Exception e) {
                cmdlet.WriteVerbose(cmdlet, e.Message);
            }
            return result;
        }
        
        public static bool SetFocus(IntPtr hWnd)
        {
            bool result = false;
            try {
                result =
                    NativeMethods.SetForegroundWindow(hWnd);
            }
            catch {
                result = false;
            }
            return result;
        }
        
        // temporary!!!
        // internal static System.Windows.Automation.AutomationElement GetAutomationElementFromPoint()
        /// <summary>
        ///  /// </summary>
        /// <returns></returns>
        public static IUiElement GetAutomationElementFromPoint()
        {
            // 20131109
            //System.Windows.Automation.AutomationElement result =
            //    null;
            IUiElement result = null;
            
            try {
                _element =
                    // 20131109
                    //AutomationElement.FromPoint(new System.Windows.Point(
                    //    Cursor.Position.X,
                    //    Cursor.Position.Y));
                    UiElement.FromPoint(
                        new System.Windows.Point(
                            Cursor.Position.X,
                            Cursor.Position.Y));
                result = _element;
            }
            catch { }
            return result;
        }
        
        /// <summary>
        ///  /// </summary>
        /// <returns></returns>
        // 20131209
        // internal static AutomationPattern[] GetElementPatternsFromPoint()
        internal static IBasePattern[] GetElementPatternsFromPoint()
        {
            // 20131209
            // AutomationPattern[] result = null;
            IBasePattern[] result = null;
            GetAutomationElementFromPoint();
            result = _element.GetSupportedPatterns();
            return result;
        }
        
//        #region get the parent or an ancestor
//        /// <summary>
//        ///  /// </summary>
//        /// <param name="element"></param>
//        /// <param name="scope"></param>
//        /// <returns></returns>
//        internal static IUiElement[] GetParentOrAncestor(IUiElement element, TreeScope scope)
//        {
//            TreeWalker walker =
//                new TreeWalker(
//                    System.Windows.Automation.Condition.TrueCondition);
//            // 20131109
//            //System.Windows.Automation.AutomationElement testparent;
//            // 20131109
//            //System.Collections.Generic.List<AutomationElement> ancestors =
//            //    new System.Collections.Generic.List<AutomationElement>();
//            List<IUiElement> ancestors =
//                new List<IUiElement>();
//            
//            try {
//                
//                // 20131109
//                IUiElement testParent = AutomationFactory.GetUiElement(walker.GetParent(element.GetSourceElement()));
//                    
//                if (scope == TreeScope.Parent || scope == TreeScope.Ancestors) {
//                    
//                    if (testParent != UiElement.RootElement) {
//                        ancestors.Add(testParent);
//                    }
//                    
//                    if (testParent == UiElement.RootElement ||
//                        scope == TreeScope.Parent) {
//                        return ancestors.ToArray();
//                    }
//                }
//                while (testParent != null &&
//                       (int)testParent.Current.ProcessId > 0 &&
//                       testParent != UiElement.RootElement) {
//                    
//                    testParent =
//                        AutomationFactory.GetUiElement(walker.GetParent(testParent.GetSourceElement()));
//                    if (testParent != null &&
//                        (int)testParent.Current.ProcessId > 0 &&
//                        testParent != UiElement.RootElement) {
//                        
//                        ancestors.Add(testParent);
//                    }
//                }
//                return ancestors.ToArray();
//            } catch {
//                return ancestors.ToArray();
//            }
//        }
//        #endregion get the parent or an ancestor
        
//        #region get an ancestor with a handle
//        /// <summary>
//        ///  /// </summary>
//        /// <param name="element"></param>
//        /// <returns></returns>
//        internal static IUiElement GetAncestorWithHandle(IUiElement element)
//        {
//            TreeWalker walker =
//                new TreeWalker(
//                    System.Windows.Automation.Condition.TrueCondition);
//            
//            // 20131109
//            //System.Windows.Automation.AutomationElement testparent;
//
//            try {
//                
//                IUiElement testparent = AutomationFactory.GetUiElement(walker.GetParent(element.GetSourceElement()));
//                while (testparent != null &&
//                       testparent.Current.NativeWindowHandle == 0) {
//                    testparent =
//                        AutomationFactory.GetUiElement(walker.GetParent(testparent.GetSourceElement()));
//                    if (testparent != null &&
//                        (int)testparent.Current.ProcessId > 0 &&
//                        testparent.Current.NativeWindowHandle != 0) {
//                        
//                        return testparent;
//                    }
//                }
//                return testparent.Current.NativeWindowHandle != 0 ? testparent : null;
//                
//            } catch {
//                return null;
//            }
//        }
//        #endregion get an ancestor with a handle
        
        /// <summary>
        ///  /// </summary>
        /// <returns></returns>
        internal static object GetCurrentPatternFromPoint()
        {
            object result = null;
            GetAutomationElementFromPoint();
            result =
                GetCurrentPattern(ref _element,
                                  null);
            if (result != null) {
                // writer.WriteLine("GetCurrentPatternFromPoint: result = " + result.ToString());
                ////writer.WriteLine(GetCurrentPatternFromPoint: element.Current.ClassName);
            } else {
                // writer.WriteLine("GetCurrentPatternFromPoint: result = null");
            }
            // writer.Flush();
            return result;
        }
        
        /// <summary>
        ///
        /// </summary>
        /// <param name="patternName"></param>
        /// <returns></returns>
        internal static AutomationPattern GetPatternByName(string patternName)
        {
            AutomationPattern result = null;
            // normalize name
            patternName =
                patternName.Substring(0, patternName.Length - 7) +
                "Pattern";
            patternName.Replace("dock", "Dock"); // ??
            switch (patternName) {
                case "DockPattern":
                    result = DockPattern.Pattern;
                    break;
                case "ExpandCollapsePattern":
                    result = ExpandCollapsePattern.Pattern;
                    break;
                case "GridItemPattern":
                    result = GridItemPattern.Pattern;
                    break;
                case "GridPattern":
                    result = GridPattern.Pattern;
                    break;
                case "InvokePattern":
                    result = InvokePattern.Pattern;
                    break;
                case "MultipleViewPattern":
                    result = MultipleViewPattern.Pattern;
                    break;
                case "RangeValuePattern":
                    result = RangeValuePattern.Pattern;
                    break;
                case "ScrollItemPattern":
                    result = ScrollItemPattern.Pattern;
                    break;
                case "ScrollPattern":
                    result = ScrollPattern.Pattern;
                    break;
                case "SelectionItemPattern":
                    result = SelectionItemPattern.Pattern;
                    break;
                case "SelectionPattern":
                    result = SelectionPattern.Pattern;
                    break;
                case "TableItemPattern":
                    result = TableItemPattern.Pattern;
                    break;
                case "TablePattern":
                    result = TablePattern.Pattern;
                    break;
                case "TextPattern":
                    result = TextPattern.Pattern;
                    break;
                case "TogglePattern":
                    result = TogglePattern.Pattern;
                    break;
                case "TransformPattern":
                    result = TransformPattern.Pattern;
                    break;
                case "ValuePattern":
                    result = ValuePattern.Pattern;
                    break;
                case "WindowPattern":
                    result = WindowPattern.Pattern;
                    break;
                default:
                    result = null;
                    break;
            }
            return result;
        }
        
        /// <summary>
        ///
        /// </summary>
        /// <param name="element"></param>
        /// <param name="patternType"></param>
        /// <returns></returns>
        internal static object GetCurrentPattern(
            ref IUiElement element,
            AutomationPattern patternType)
        {
            object result =
                null;
            try {
                // 20131209
                // AutomationPattern[] supportedPatterns =
                //     element.GetSupportedPatterns();
                IBasePattern[] supportedPatterns =
                    element.GetSupportedPatterns();
                if (supportedPatterns == null ||
                    supportedPatterns.Length < 1)
                {
                    return result;
                }
                /*
                foreach (AutomationPattern ptrn in supportedPatterns.Where(ptrn => patternType.ProgrammaticName == ptrn.ProgrammaticName ||
                                                                                   patternType == null).Where(ptrn => element.TryGetCurrentPattern(
                                                                                       ptrn, out pattern)))
                {
                    object resPattern =
                        element.GetCurrentPattern(ptrn);
                    // as System.Windows.Automation.AutomationPattern;
                    result = resPattern;
                    return result;
                }
                */
                
                // 20131209
                // foreach (AutomationPattern ptrn in supportedPatterns.Where(ptrn => patternType.ProgrammaticName == ptrn.ProgrammaticName ||
                // 20131210
                // foreach (IBasePattern ptrn in supportedPatterns.Where(ptrn => patternType.ProgrammaticName == (ptrn as AutomationPattern).ProgrammaticName ||
                foreach (IBasePattern ptrn in supportedPatterns.Where(ptrn => patternType.ProgrammaticName == (ptrn.SourcePattern as AutomationPattern).ProgrammaticName ||
                                                                                   patternType == null))
                {
                    object pattern = null;
                    if (!element.TryGetCurrentPattern(
                        // 20131209
                        // ptrn, out pattern)) continue;
                        // 20131210
                        // (ptrn as AutomationPattern), out pattern)) continue;
                        (ptrn.SourcePattern as AutomationPattern), out pattern)) continue;
                    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//                    object resPattern =
//                        // 20131208
//                        // element.GetCurrentPattern(ptrn);
//                        element.GetCurrentPattern<(ptrn);
//                    // as System.Windows.Automation.AutomationPattern;
//                    result = resPattern;
                    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    object resPattern =
                        // 20131209
                        // element.GetCurrentPattern(ptrn);
                        // 20131210
                        // element.GetCurrentPattern((ptrn as AutomationPattern));
                        element.GetCurrentPattern((ptrn.SourcePattern as AutomationPattern));
                    return result;
                }

                /*
                foreach (System.Windows.Automation.AutomationPattern ptrn in supportedPatterns)
                {
                    if (patternType.ProgrammaticName == ptrn.ProgrammaticName ||
                        patternType == null) {
                        if (element.TryGetCurrentPattern(
                            ptrn, out pattern))
                        {
                            object resPattern =
                                element.GetCurrentPattern(ptrn);
                            // as System.Windows.Automation.AutomationPattern;
                            result = resPattern;
                            return result;
                        }
                    }
                }
                */
            } catch //(Exception ePatternProblem) {
                // 
            {

            }
            return result;
        }
        
        /// <summary>
        ///
        /// </summary>
        /// <param name="controlType"></param>
        /// <returns></returns>
        public static ControlType
            GetControlTypeByTypeName(string controlType)
        {
            string controlTypeInUpperCase = controlType.ToUpper();
            switch (controlTypeInUpperCase)
            {
                    case "BUTTON": { return ControlType.Button; }
                    case "CALENDAR": { return ControlType.Calendar; }
                    case "CHECKBOX": { return ControlType.CheckBox; }
                    case "COMBOBOX": { return ControlType.ComboBox; }
                    case "CUSTOM": { return ControlType.Custom; }
                    case "DATAGRID": { return ControlType.DataGrid; }
                    case "DATAITEM": { return ControlType.DataItem; }
                    case "DOCUMENT": { return ControlType.Document; }
                    case "EDIT": { return ControlType.Edit; }
                    case "GROUP": { return ControlType.Group; }
                    case "HEADER": { return ControlType.Header; }
                    case "HEADERITEM": { return ControlType.HeaderItem; }
                    case "HYPERLINK": { return ControlType.Hyperlink; }
                    case "IMAGE": { return ControlType.Image; }
                    case "LIST": { return ControlType.List; }
                    case "LISTITEM": { return ControlType.ListItem; }
                    case "MENU": { return ControlType.Menu; }
                    case "MENUBAR": { return ControlType.MenuBar; }
                    case "MENUITEM": { return ControlType.MenuItem; }
                    case "PANE": { return ControlType.Pane; }
                    case "PROGRESSBAR": { return ControlType.ProgressBar; }
                    case "RADIOBUTTON": { return ControlType.RadioButton; }
                    case "SCROLLBAR": { return ControlType.ScrollBar; }
                    case "SEPARATOR": { return ControlType.Separator; }
                    case "SLIDER": { return ControlType.Slider; }
                    case "SPINNER": { return ControlType.Spinner; }
                    case "SPLITBUTTON": { return ControlType.SplitButton; }
                    case "STATUSBAR": { return ControlType.StatusBar; }
                    case "TAB": { return ControlType.Tab; }
                    case "TABITEM": { return ControlType.TabItem; }
                    case "TABLE": { return ControlType.Table; }
                    case "TEXT": { return ControlType.Text; }
                    case "THUMB": { return ControlType.Thumb; }
                    case "TITLEBAR": { return ControlType.TitleBar; }
                    case "TOOLBAR": { return ControlType.ToolBar; }
                    case "TOOLTIP": { return ControlType.ToolTip; }
                    case "TREE": { return ControlType.Tree; }
                    case "TREEITEM": { return ControlType.TreeItem; }
                    case "WINDOW": { return ControlType.Window; }
                default:
                    // WriteVerbose(this, "there's no ControlType value.");
                    // 20131119
                    //ctrlType = null;
                    //break;
                    return null;
            }
            // 20131119
            //return ctrlType;
        }
        
        /// <summary>
        ///
        /// </summary>
        /// <param name="element"></param>
        /// <param name="strResultString"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        internal static bool GetHeaderItems(
            // 20131109
            //ref System.Windows.Automation.AutomationElement element,
            ref IUiElement element,
            out string strResultString,
            char delimiter)
        {
            IUiEltCollection headerItems =
                element.FindAll(
                    TreeScope.Descendants,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.HeaderItem));
            if (headerItems == null || headerItems.Count == 0) {
                // WriteVerbose(this, "no headers found");
                strResultString =
                    "no headers found";
                return false;
            }
            else {
                string headersRow = String.Empty;
                // foreach (System.Windows.Automation.AutomationElement elt in
                // headerItems)
                // 20131109
                int headersCounter = 0;
                foreach (IUiElement headerItem in headerItems) {
                    headersCounter++;
                    headersRow += '"';
                    // headersRow += elt.Current.Name;
                    headersRow +=
                        headerItem.Current.Name;
                    headersRow += '"';
                    if (headersCounter < (headerItems.Count)) {
                        headersRow += delimiter;
                    }
                }
//                for (int headersCounter = 0;
//                     headersCounter < headerItems.Count;
//                     headersCounter++)
//                {
//                    headersRow += '"';
//                    // headersRow += elt.Current.Name;
//                    headersRow +=
//                        headerItems[headersCounter].Current.Name;
//                    headersRow += '"';
//                    if (headersCounter < (headerItems.Count - 1)) {
//                        headersRow += delimiter;
//                    }
//                }
                
                /*
                // my refactoring
                for (int headersCounter = 0;
                     headersCounter < headerItems.Count;
                     headersCounter++)
                {
                    headersRow += '"';
                    // headersRow += elt.Current.Name;
                    headersRow +=
                        headerItems[headersCounter].Current.Name;
                    headersRow += '"';
                    if (headersCounter < (headerItems.Count - 1)) {
                        headersRow += delimiter;
                    }
                }
                */
                // output headers
                // WriteObject(headersRow);
                strResultString = headersRow;
                return true;
            }
        }
        
        /// <summary>
        ///  /// </summary>
        /// <param name="element"></param>
        /// <param name="strResultString"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        internal static bool GetHeaders(
            ref IUiElement element,
            out string strResultString,
            char delimiter)
        {
            IUiEltCollection headerItems =
                element.FindAll(
                    TreeScope.Descendants,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Header));
            if (headerItems == null || headerItems.Count == 0) {
                // WriteVerbose(this, "no headers found");
                strResultString =
                    "no headers found";
                return false;
            }
            else {
                string headersRow = String.Empty;
                // foreach (System.Windows.Automation.AutomationElement elt in
                // headerItems)
                // 20131109
                int headersCounter = 0;
                foreach (IUiElement headerItem in headerItems) {
                    
                    headersCounter++;
                    headersRow += '"';
                    // headersRow += elt.Current.Name;
                    headersRow +=
                        headerItem.Current.Name;
                    headersRow += '"';
                    if (headersCounter < (headerItems.Count)) {
                        headersRow += delimiter;
                    }
                }
                
//                for (int headersCounter = 0;
//                     headersCounter < headerItems.Count;
//                     headersCounter++)
//                {
//                    headersRow += '"';
//                    // headersRow += elt.Current.Name;
//                    headersRow +=
//                        headerItems[headersCounter].Current.Name;
//                    headersRow += '"';
//                    if (headersCounter < (headerItems.Count - 1)) {
//                        headersRow += delimiter;
//                    }
//                }
                
                
                /*
                // my refactoring
                for (int headersCounter = 0;
                     headersCounter < headerItems.Count;
                     headersCounter++)
                {
                    headersRow += '"';
                    // headersRow += elt.Current.Name;
                    headersRow +=
                        headerItems[headersCounter].Current.Name;
                    headersRow += '"';
                    if (headersCounter < (headerItems.Count - 1)) {
                        headersRow += delimiter;
                    }
                }
                */
                // output headers
                // WriteObject(headersRow);
                strResultString = headersRow;
                return true;
            }
        }
        
        /// <summary>
        ///  /// </summary>
        /// <param name="pattern"></param>
        /// <param name="columnsNumber"></param>
        /// <param name="rowsCounter"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        internal static string GetOutputStringUsingTableGridPattern<T>(
            T pattern,
            int columnsNumber,
            int rowsCounter,
            char delimiter)
        {
            // string result = String.Empty;
            string onerow = String.Empty;
            for (int columnsCounter = 0;
                 columnsCounter < columnsNumber;
                 columnsCounter++) {
                onerow += '"';
                object[] coordinates =
                { rowsCounter, columnsCounter };
                onerow +=
                    // 20131109
                    //((System.Windows.Automation.AutomationElement)
                    // 20131111
                    //((IUiElement)
                    // pattern.GetType().GetMethod(
                    //     "GetItem").Invoke(
                    //     pattern,
                    //     coordinates)).Current.Name;
                    // 20131112
//                    (new UiElement(
//                        ((System.Windows.Automation.AutomationElement)
//                        pattern.GetType().GetMethod(
//                            "GetItem").Invoke(
//                            pattern,
//                            coordinates)))).Current.Name;
                    (AutomationFactory.GetUiElement(
                        ((AutomationElement)
                        pattern.GetType().GetMethod(
                            "GetItem").Invoke(
                            pattern,
                            coordinates)))).Current.Name;
                //{ coordinates)).Current.Name;
                // pattern.GetType().InvokeMember(
                // "GetItem",
                // System.Reflection.BindingFlags.Public,
                // pattern.GetItem(
                // rowsCounter,
                // columnsCounter).Current.Name;
                onerow += '"';
                if (columnsCounter < (columnsNumber - 1)) {
                    onerow += delimiter;
                }
            }
            return onerow;
        }
        
        /// <summary>
        ///  /// </summary>
        /// <param name="control"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        internal static List<string>
            GetOutputStringUsingItemsValuePattern(
                IUiElement control,
                char delimiter)
        {
            List<string> rowsCollection =
                new List<string>();
            
            IUiEltCollection rows =
                control.FindAll(TreeScope.Children,
                                new PropertyCondition(
                                    AutomationElement.ControlTypeProperty,
                                    ControlType.Custom));
            if (rows.Count > 0) {
                
                foreach(IUiElement row in rows) {
                    
                    IUiEltCollection rowItems =
                        row.FindAll(TreeScope.Children,
                                    new PropertyCondition(
                                        AutomationElement.ControlTypeProperty,
                                        ControlType.Custom));
                    if (rowItems.Count <= 0) continue;
                    string onerow = String.Empty;
                    
                    // 20131109
                    int rowCounter = 0;
                    foreach (IUiElement rowItem in rowItems) {
                        
                        rowCounter++;
                        string strValue = String.Empty;
                        strValue += '"';
                        try
                        {
                            // 20131208
                            // ValuePattern valPattern = rowItem.GetCurrentPattern(ValuePattern.Pattern)
                            // ValuePattern valPattern = rowItem.GetCurrentPattern<IMySuperValuePattern, ValuePattern>(ValuePattern.Pattern)
                            //     as ValuePattern;
                            IMySuperValuePattern valPattern = rowItem.GetCurrentPattern<IMySuperValuePattern>(ValuePattern.Pattern);
                            strValue += valPattern.Current.Value;
                        }
                        catch {
                            // nothing to do
                        }
                        strValue += '"';
                        onerow += strValue;
                        if (rowCounter < rowItems.Count) {
                            onerow += delimiter;
                        }
                    }
//                    for (int i = 0; i < rowItems.Count; i++) {
//                        ValuePattern valPattern = null;
//                        string strValue = String.Empty;
//                        strValue += '"';
//                        try {
//                            valPattern =
//                                rowItems[i].GetCurrentPattern(ValuePattern.Pattern)
//                                    as ValuePattern;
//                            strValue += valPattern.Current.Value;
//                        } catch {
//                            // nothing to do
//                        }
//                        strValue += '"';
//                        onerow += strValue;
//                        if (i < (rowItems.Count - 1)) {
//                            onerow += delimiter;
//                        }
//                    }
                    
                    /*
                    // my refactoring
                    for (int i = 0; i < rowItems.Count; i++) {
                        ValuePattern valPattern = null;
                        string strValue = String.Empty;
                        strValue += '"';
                        try {
                            valPattern =
                                rowItems[i].GetCurrentPattern(ValuePattern.Pattern)
                                    as ValuePattern;
                            strValue += valPattern.Current.Value;
                        } catch {
                            // nothing to do
                        }
                        strValue += '"';
                        onerow += strValue;
                        if (i < (rowItems.Count - 1)) {
                            onerow += delimiter;
                        }
                    }
                    */
                    if (onerow.Length > 2) {
                        rowsCollection.Add(onerow);
                    }
                    // WriteObject(onerow);

                    /*
                    if (rowItems.Count > 0) {
                        string onerow = String.Empty;
                        for (int i = 0; i < rowItems.Count; i++) {
                            ValuePattern valPattern = null;
                            string strValue = String.Empty;
                            strValue += '"';
                            try {
                                valPattern =
                                    rowItems[i].GetCurrentPattern(ValuePattern.Pattern)
                                    as ValuePattern;
                                strValue += valPattern.Current.Value;
                            } catch {
                                // nothing to do
                            }
                            strValue += '"';
                            onerow += strValue;
                            if (i < (rowItems.Count - 1)) {
                                onerow += delimiter;
                            }
                        }
                        if (onerow.Length > 2) {
                            rowsCollection.Add(onerow);
                        }
                        // WriteObject(onerow);
                    }
                    */
                }
            } else {
                return rowsCollection;
            }
            return rowsCollection;
        }
        
        internal static void WriteEventToCollection(
            HasControlInputCmdletBase cmdlet,
            object handler)
            //System.Windows.Automation.AutomationEventHandler handler)
            //EventHandler handler)
        {
            try {
                if (CurrentData.Events.Count == Preferences.MaximumEventCount) {
                    CurrentData.Events.RemoveAt(0);
                }
                CurrentData.Events.Add(handler);
            }
            catch {
                cmdlet.WriteVerbose(cmdlet, "Unable to add an event handler ot the collection");
            }
        }
        
        private static string getSheridanTreeItemName(
            SheridanCmdletBase cmdlet,
            IntPtr hwndTreeItem)
        {
            string result = string.Empty;
            
            //Dim LabelEx As Integer = FindWindowEx()
            //Dim TextBoxEx As Integer = FindWindowEx(hwnd, 0, "MyAppTextBox", vbNullString)
            //Dim txtLength As Long = SendMessage(TextBoxEx, WM_GETTEXTLENGTH, CInt(0), CInt(0)) + 1
            long textLength =
                NativeMethods.SendMessage2(
                    hwndTreeItem,
                    NativeMethods.WM_GETTEXTLENGTH,
                    (IntPtr)0,
                    (IntPtr)1);
            //Dim txtBuff As New System.Text.StringBuilder(txtLength + 1)
            string textBuffer = string.Empty;
            //GetWindowText(hWnd, txtBuff , txtBuff .Capacity)
            NativeMethods.GetWindowText(hwndTreeItem, textBuffer, 255);
            //Dim txtValue As Long = SendMessage(TextBoxEx, WM_GETTEXT, txtLength, txtBuff)
            long textValue =
                NativeMethods.SendMessage2(
                    hwndTreeItem,
                    NativeMethods.WM_GETTEXT,
                    (IntPtr)textLength,
                    textBuffer);
            result = textBuffer.ToString();
            
            return result;
        }
        
        private static bool CompareSheridanTreeItemName(
            SheridanCmdletBase cmdlet,
            string neededName)
        {
            bool result = false;
            
            
            
            return result;
        }
        
        public static IUiElement GetSheridanTreeItemByName(
            SheridanCmdletBase cmdlet,
            IntPtr hwndTreeView,
            string treeItemName)
        {
            IUiElement resultElement = null;
            
            //IntPtr hwndTreeViewRoot = IntPtr.Zero;
            int hwndTreeViewRoot = 0; //IntPtr.Zero;

            if (IntPtr.Zero == hwndTreeView) return resultElement;
            // get the root
            hwndTreeViewRoot =
                NativeMethods.SendMessage(
                    (int)hwndTreeView,
                    NativeMethods.TVM_GETNEXTITEM,
                    NativeMethods.TVGN_ROOT,
                    IntPtr.Zero);
                
            Console.WriteLine(getSheridanTreeItemName(cmdlet, (IntPtr)hwndTreeViewRoot));
                
            //if (IntPtr.Zero == hwndTreeViewRoot) {
            if (0 == hwndTreeViewRoot) {
                return resultElement;
            }
                
            // search for a tree item recursively
            resultElement =
                GetSheridanTreeItemFromTreeNode(
                    cmdlet,
                    hwndTreeView,
                    (IntPtr)hwndTreeViewRoot,
                    treeItemName);

            /*
            if (IntPtr.Zero != hwndTreeView) {
                
                // get the root
                hwndTreeViewRoot =
                    NativeMethods.SendMessage(
                        (int)hwndTreeView,
                        NativeMethods.TVM_GETNEXTITEM,
                        NativeMethods.TVGN_ROOT,
                        IntPtr.Zero);
                
                Console.WriteLine(getSheridanTreeItemName(cmdlet, (IntPtr)hwndTreeViewRoot));
                
                //if (IntPtr.Zero == hwndTreeViewRoot) {
                if (0 == hwndTreeViewRoot) {
                    return resultElement;
                }
                
                // search for a tree item recursively
                resultElement =
                    getSheridanTreeItemFromTreeNode(
                        cmdlet,
                        hwndTreeView,
                        (IntPtr)hwndTreeViewRoot,
                        treeItemName);
            }
            */

            return resultElement;
        }
        
        private static IUiElement GetSheridanTreeItemFromTreeNode(
            CommonCmdletBase cmdlet,
            IntPtr hwndTreeView,
            IntPtr hwndTreeItem,
            string treeItemName)
        {
            IUiElement resultElement = null;
            
            //IntPtr resultHandle = IntPtr.Zero;
            int resultHandle = 0; //IntPtr.Zero;
            //IntPtr childHandle = IntPtr.Zero;

            do {
                
                try {
                    
                    // getting siblings
                    resultHandle =
                        NativeMethods.SendMessage(
                            (int)hwndTreeView,
                            NativeMethods.TVM_GETNEXTITEM,
                            NativeMethods.TVGN_NEXT,
                            hwndTreeItem);
                    
                    //if (IntPtr.Zero != resultHandle) {
                    if (0 == resultHandle) continue;
                    resultElement =
                        GetAutomationElementFromHandle(
                            (DiscoveryCmdletBase)cmdlet,
                            resultHandle);
                    if (treeItemName == resultElement.Current.Name) {
                        return resultElement;
                    }
                        
                    // gettting the first child
                    int childHandle = NativeMethods.SendMessage(
                        (int)hwndTreeView,
                        NativeMethods.TVM_GETNEXTITEM,
                        NativeMethods.TVGN_CHILD,
                        (IntPtr)resultHandle); //IntPtr.Zero;
                        
                    //if (IntPtr.Zero != childHandle) {
                    if (0 == childHandle) continue;
                    resultElement =
                        GetAutomationElementFromHandle(
                            (DiscoveryCmdletBase)cmdlet,
                            childHandle);
                    if (treeItemName == resultElement.Current.Name) {
                        return resultElement;
                    }
                            
                    // gettting children
                    resultElement =
                        GetSheridanTreeItemFromTreeNode(
                            cmdlet,
                            hwndTreeView,
                            (IntPtr)childHandle,
                            treeItemName);
                    if (treeItemName == resultElement.Current.Name) {
                        return resultElement;
                    }

                    /*
                    if (0 != childHandle) {
                            
                        resultElement =
                            GetAutomationElementFromHandle(
                                (DiscoveryCmdletBase)cmdlet,
                                childHandle);
                        if (treeItemName == resultElement.Current.Name) {
                            return resultElement;
                        }
                            
                        // gettting children
                        resultElement =
                            getSheridanTreeItemFromTreeNode(
                                cmdlet,
                                hwndTreeView,
                                (IntPtr)childHandle,
                                treeItemName);
                        if (treeItemName == resultElement.Current.Name) {
                            return resultElement;
                        }
                            
                    }
                    */

                    /*
                    if (0 != resultHandle) {
                        
                        resultElement =
                            GetAutomationElementFromHandle(
                                (DiscoveryCmdletBase)cmdlet,
                                resultHandle);
                        if (treeItemName == resultElement.Current.Name) {
                            return resultElement;
                        }
                        
                        // gettting the first child
                        childHandle =
                            NativeMethods.SendMessage(
                                (int)hwndTreeView,
                                NativeMethods.TVM_GETNEXTITEM,
                                NativeMethods.TVGN_CHILD,
                                (IntPtr)resultHandle);
                        
                        //if (IntPtr.Zero != childHandle) {
                        if (0 != childHandle) {
                            
                            resultElement =
                                GetAutomationElementFromHandle(
                                    (DiscoveryCmdletBase)cmdlet,
                                    childHandle);
                            if (treeItemName == resultElement.Current.Name) {
                                return resultElement;
                            }
                            
                            // gettting children
                            resultElement =
                                getSheridanTreeItemFromTreeNode(
                                    cmdlet,
                                    hwndTreeView,
                                    (IntPtr)childHandle,
                                    treeItemName);
                            if (treeItemName == resultElement.Current.Name) {
                                return resultElement;
                            }
                            
                        }
                    }
                    */

                }
                catch {}
                
                //} while (IntPtr.Zero != resultHandle);
            } while (0 != resultHandle);
            
            return resultElement;
        }
        
        // experimental
        #region experimental


//    [DllImport("user32")]
//    [return: MarshalAs(UnmanagedType.Bool)]
//    public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);

        internal static IEnumerable<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                NativeMethods.EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return result;
        }

        private static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            GCHandle gch = GCHandle.FromIntPtr(pointer);
            List<IntPtr> list = gch.Target as List<IntPtr>;
            if (list == null)
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
    
            list.Add(handle);            
            return true;
        }
        
        internal static List<IUiElement> EnumChildWindowsFromHandle(GetWindowCmdletBase cmdlet, IntPtr parentHandle)
        {
            IEnumerable<IntPtr> list =
                GetChildWindows(parentHandle);
            
            List<IUiElement> resultElements =
                new List<IUiElement>();
            
            ArrayList automationElements =
                new ArrayList();
            
            foreach (IntPtr handle in list) {
                
                try {
                    
                    IUiElement element =
                        GetAutomationElementFromHandle(cmdlet, handle.ToInt32());
                    
                    automationElements.Add(element);
                    
                }
                catch {}
            }
            
            if (null == cmdlet.Name || 0 == cmdlet.Name.Length) {
                cmdlet.Name = new string[] { "*" };
            }
            
            foreach (string windowName in cmdlet.Name) {
                
                resultElements.AddRange(
                    HasTimeoutCmdletBase.ReturnOnlyRightElements(
                        (HasTimeoutCmdletBase)cmdlet,
                        automationElements,
                        windowName,
                        cmdlet.AutomationId,
                        cmdlet.Class,
                        string.Empty,
                        new string[]{ "Window" },
                        false,
                        // 20131122
                        true));
            }
            
            //
            // extra?
            automationElements.Clear();
            //
            
            //};
            
            //return automationElements;
            return resultElements;
        }
        
        public static List<IUiElement> Enum1ChildWindows(IntPtr parentHandle)
        {
            
            //PSCmdletBase cmdlet = new GetUiaWindowCommand();
            GetWindowCmdletBase cmdlet = new GetWindowCmdletBase();
            List<IUiElement> resultList =
                EnumChildWindowsFromHandle(cmdlet, parentHandle);
            
            return resultList;
        }
        
        public static List<IUiElement> Enum2ChildWindows(IntPtr parentHandle)
        {
            
            //PSCmdletBase cmdlet = new GetUiaWindowCommand();
            GetWindowCmdletBase cmdlet = new GetWindowCmdletBase();
            List<IUiElement> resultList =
                EnumChildWindowsFromHandle(cmdlet, IntPtr.Zero);
            
            return resultList;
        }
        #endregion experimental
        
        public static Type[] GetSupportedInterfaces<T>(T element)
        {
            List<Type> supportedTypes = new List<Type>();
            
            if (element is AutomationElement) {
                foreach (AutomationPattern pattern in (element as AutomationElement).GetSupportedPatterns()) {
                    // always
                    supportedTypes.Add(typeof(ISupportsInvokePattern));
                    if (pattern == DockPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsDockPattern));
                    }
                    if (pattern == ExpandCollapsePattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsExpandCollapsePattern));
                    }
                    if (pattern == GridItemPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsGridItemPattern));
                    }
                    if (pattern == GridPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsGridPattern));
                    }
                    if (pattern == RangeValuePattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsRangeValuePattern));
                    }
                    if (pattern == SelectionItemPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsSelectionItemPattern));
                    }
                    if (pattern == SelectionPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsSelectionPattern));
                    }
                    if (pattern == ScrollItemPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsScrollItemPattern));
                    }
                    if (pattern == ScrollPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsScrollPattern));
                    }
                    if (pattern == TableItemPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsTableItemPattern));
                    }
                    if (pattern == TablePattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsTablePattern));
                    }
                    if (pattern == TextPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsTextPattern));
                    }
                    if (pattern == TogglePattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsTogglePattern));
                    }
                    if (pattern == TransformPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsTransformPattern));
                    }
                    if (pattern == ValuePattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsValuePattern));
                    }
                    if (pattern == WindowPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsWindowPattern));
                    }
                }
            }
            if (element is IUiElement) {
                foreach (IBasePattern pattern in (element as IUiElement).GetSupportedPatterns()) {
                    // always
                    supportedTypes.Add(typeof(ISupportsInvokePattern));
                    if (pattern is IMySuperDockPattern) {
                        supportedTypes.Add(typeof(ISupportsDockPattern));
                    }
                    if (pattern is IMySuperExpandCollapsePattern) {
                        supportedTypes.Add(typeof(ISupportsExpandCollapsePattern));
                    }
                    if (pattern is IMySuperGridItemPattern) {
                        supportedTypes.Add(typeof(ISupportsGridItemPattern));
                    }
                    if (pattern is IMySuperGridPattern) {
                        supportedTypes.Add(typeof(ISupportsGridPattern));
                    }
                    if (pattern is IMySuperRangeValuePattern) {
                        supportedTypes.Add(typeof(ISupportsRangeValuePattern));
                    }
                    if (pattern is IMySuperSelectionItemPattern) {
                        supportedTypes.Add(typeof(ISupportsSelectionItemPattern));
                    }
                    if (pattern is IMySuperSelectionPattern) {
                        supportedTypes.Add(typeof(ISupportsSelectionPattern));
                    }
                    if (pattern is IMySuperScrollItemPattern) {
                        supportedTypes.Add(typeof(ISupportsScrollItemPattern));
                    }
                    if (pattern is IMySuperScrollPattern) {
                        supportedTypes.Add(typeof(ISupportsScrollPattern));
                    }
                    if (pattern is IMySuperTableItemPattern) {
                        supportedTypes.Add(typeof(ISupportsTableItemPattern));
                    }
                    if (pattern is IMySuperTablePattern) {
                        supportedTypes.Add(typeof(ISupportsTablePattern));
                    }
                    if (pattern is IMySuperTextPattern) {
                        supportedTypes.Add(typeof(ISupportsTextPattern));
                    }
                    if (pattern is IMySuperTogglePattern) {
                        supportedTypes.Add(typeof(ISupportsTogglePattern));
                    }
                    if (pattern is IMySuperTransformPattern) {
                        supportedTypes.Add(typeof(ISupportsTransformPattern));
                    }
                    if (pattern is IMySuperValuePattern) {
                        supportedTypes.Add(typeof(ISupportsValuePattern));
                    }
                    if (pattern is IMySuperWindowPattern) {
                        supportedTypes.Add(typeof(ISupportsWindowPattern));
                    }
                }
            }
            
            return supportedTypes.ToArray();
        }
    }
    
    #region experimental
    public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
    #endregion experimental
}