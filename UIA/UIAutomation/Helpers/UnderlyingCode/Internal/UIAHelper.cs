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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using System.IO;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Drawing;
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
    using Tmx;

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
        
        internal static void Highlight(IUiElement element)
        {
            try { if (_highlighter != null) { _highlighter.Dispose(); } } catch {}
            try { if (_highlighterParent != null) { _highlighterParent.Dispose(); } } catch {}
            //try { if (highlighterFirstChild != null) { highlighterFirstChild.Dispose(); } } catch {}
            
            if ((element as IUiElement) != null) {
                
                _highlighter =
                    new Highlighter(
                        // 20140312
//                        element.Current.BoundingRectangle.Height,
//                        element.Current.BoundingRectangle.Width,
//                        element.Current.BoundingRectangle.X,
//                        element.Current.BoundingRectangle.Y,
//                        element.Current.NativeWindowHandle,
                        element.GetCurrent().BoundingRectangle.Height,
                        element.GetCurrent().BoundingRectangle.Width,
                        element.GetCurrent().BoundingRectangle.X,
                        element.GetCurrent().BoundingRectangle.Y,
                        element.GetCurrent().NativeWindowHandle,
                        Highlighters.Element,
                        Preferences.HighlighterColor);
            }
            if (!Preferences.HighlightParent) return;
            
            IUiElement parent =
                element.GetParent();
                
            _highlighterParent =
                new Highlighter(
                    // 20140312
//                    parent.Current.BoundingRectangle.Height,
//                    parent.Current.BoundingRectangle.Width,
//                    parent.Current.BoundingRectangle.X,
//                    parent.Current.BoundingRectangle.Y,
//                    parent.Current.NativeWindowHandle,
                    parent.GetCurrent().BoundingRectangle.Height,
                    parent.GetCurrent().BoundingRectangle.Width,
                    parent.GetCurrent().BoundingRectangle.X,
                    parent.GetCurrent().BoundingRectangle.Y,
                    parent.GetCurrent().NativeWindowHandle,
                    Highlighters.Parent,
                    Preferences.HighlighterColorParent);
        }
        
        internal static void HighlightCheckedControl(IUiElement element)
        {
            try { if (_highlighterCheckedControl != null) { _highlighterCheckedControl.Dispose(); } } catch {}
            
            if ((element as IUiElement) != null) {

                _highlighterCheckedControl =
                    new Highlighter(
                        // 20140312
//                        element.Current.BoundingRectangle.Height,
//                        element.Current.BoundingRectangle.Width,
//                        element.Current.BoundingRectangle.X,
//                        element.Current.BoundingRectangle.Y,
//                        element.Current.NativeWindowHandle,
                        element.GetCurrent().BoundingRectangle.Height,
                        element.GetCurrent().BoundingRectangle.Width,
                        element.GetCurrent().BoundingRectangle.X,
                        element.GetCurrent().BoundingRectangle.Y,
                        element.GetCurrent().NativeWindowHandle,
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
            ScreenshotRect relativeRect,
            string path,
            ImageFormat format)
        {
            if (null == cmdlet.InputObject || !cmdlet.InputObject.Any()) {
                
                cmdlet.WriteVerbose(cmdlet, "(null == cmdlet.InputObject || 0 == cmdlet.InputObject.Length)");
                
                cmdlet.InputObject = new[] { UiElement.RootElement };
            }
            
            cmdlet.WriteVerbose(
                cmdlet,
                "input array consists of " + cmdlet.InputObject.Count().ToString() + " objects");
            
            foreach (IUiElement inputObject in cmdlet.InputObject) {
                
                cmdlet.WriteVerbose(cmdlet, "calculating the size");
                ScreenshotRect absoluteRect =
                    new ScreenshotRect() {
                    Left = 0,
                    Top = 0,
                    Width = Screen.PrimaryScreen.Bounds.Width,
                    Height = Screen.PrimaryScreen.Bounds.Height
                };
                
                if (inputObject == null) {
                    if (relativeRect.Left > 0) { absoluteRect.Left = relativeRect.Left; }
                    if (relativeRect.Top > 0) { absoluteRect.Top = relativeRect.Top; }
                    if (relativeRect.Height > 0) { absoluteRect.Height = relativeRect.Height; }
                    if (relativeRect.Width > 0) { absoluteRect.Width = relativeRect.Width; }
                }
                
//                cmdlet.WriteVerbose(cmdlet, "X = " + absoluteX.ToString());
//                cmdlet.WriteVerbose(cmdlet, "Y = " + absoluteY.ToString());
//                cmdlet.WriteVerbose(cmdlet, "Height = " + absoluteHeight.ToString());
//                cmdlet.WriteVerbose(cmdlet, "Width = " + absoluteWidth.ToString());
                
                // 20140312
//                if (inputObject != null && (int)inputObject.Current.ProcessId > 0) {
//                    
//                    absoluteRect.Left = (int)inputObject.Current.BoundingRectangle.X + relativeRect.Left;
//                    absoluteRect.Top = (int)inputObject.Current.BoundingRectangle.Y + relativeRect.Top;
//                    absoluteRect.Height = (int)inputObject.Current.BoundingRectangle.Height + relativeRect.Height;
//                    absoluteRect.Width = (int)inputObject.Current.BoundingRectangle.Width + relativeRect.Width;
//                }
                if (inputObject != null && (int)inputObject.GetCurrent().ProcessId > 0) {
                    
                    absoluteRect.Left = (int)inputObject.GetCurrent().BoundingRectangle.X + relativeRect.Left;
                    absoluteRect.Top = (int)inputObject.GetCurrent().BoundingRectangle.Y + relativeRect.Top;
                    absoluteRect.Height = (int)inputObject.GetCurrent().BoundingRectangle.Height + relativeRect.Height;
                    absoluteRect.Width = (int)inputObject.GetCurrent().BoundingRectangle.Width + relativeRect.Width;
                }
                
                if (relativeRect.Height == 0) { relativeRect.Height = Screen.PrimaryScreen.Bounds.Height; }
                if (relativeRect.Width == 0) { relativeRect.Width = Screen.PrimaryScreen.Bounds.Width; }
                
                /*
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
                */
                
                // 20140312
                // if (inputObject != null && (int)inputObject.Current.ProcessId > 0) {
                if (inputObject != null && (int)inputObject.GetCurrent().ProcessId > 0) {
                    
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
                    absoluteRect,
                    path,
                    format);
            }
        }
        
        public static void GetScreenshotOfAutomationElement(
            PSCmdletBase cmdlet,
            IUiElement element,
            string description,
            bool save,
            ScreenshotRect relativeRect,
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
                // 20140111
                // 20140312
//                ScreenshotRect absoluteRect =
//                    new ScreenshotRect() {
//                    Left = 0,
//                    Top = 0,
//                    Width = Screen.PrimaryScreen.Bounds.Width,
//                    Height = Screen.PrimaryScreen.Bounds.Height
//                };
                var absoluteRect =
                    new ScreenshotRect() {
                    Left = 0,
                    Top = 0,
                    Width = Screen.PrimaryScreen.Bounds.Width,
                    Height = Screen.PrimaryScreen.Bounds.Height
                };
    //            int absoluteX = 0;
    //            int absoluteY = 0;
    //            int absoluteWidth =
    //                Screen.PrimaryScreen.Bounds.Width;
    //            int absoluteHeight =
    //                Screen.PrimaryScreen.Bounds.Height;
                
                /*
                int absoluteX = 0;
                int absoluteY = 0;
                int absoluteWidth =
                    Screen.PrimaryScreen.Bounds.Width;
                int absoluteHeight =
                    Screen.PrimaryScreen.Bounds.Height;
                */
                
                if (null == element) {
                    if (relativeRect.Left > 0) { absoluteRect.Left = relativeRect.Left; }
                    if (relativeRect.Top > 0) { absoluteRect.Top = relativeRect.Top; }
                    if (relativeRect.Height > 0) { absoluteRect.Height = relativeRect.Height; }
                    if (relativeRect.Width > 0) { absoluteRect.Width = relativeRect.Width; }
                    /*
                    if (Left > 0) { absoluteX = Left; }
                    if (Top > 0) { absoluteY = Top; }
                    if (Height > 0) { absoluteHeight = Height; }
                    if (Width > 0) { absoluteWidth = Width; }
                    */
                }
    //            cmdlet.WriteVerbose(cmdlet, "X = " + absoluteX.ToString());
    //            cmdlet.WriteVerbose(cmdlet, "Y = " + absoluteY.ToString());
    //            cmdlet.WriteVerbose(cmdlet, "Height = " + absoluteHeight.ToString());
    //            cmdlet.WriteVerbose(cmdlet, "Width = " + absoluteWidth.ToString());
                
                // 20140312
    //            if (null != element && 0 < (int)element.Current.ProcessId) {
    //                absoluteRect.Left = (int)element.Current.BoundingRectangle.X + relativeRect.Left;
    //                absoluteRect.Top = (int)element.Current.BoundingRectangle.Y + relativeRect.Top;
    //                absoluteRect.Height = (int)element.Current.BoundingRectangle.Height + relativeRect.Height;
    //                absoluteRect.Width = (int)element.Current.BoundingRectangle.Width + relativeRect.Width;
                if (null != element && 0 < (int)element.GetCurrent().ProcessId) {
                    absoluteRect.Left = (int)element.GetCurrent().BoundingRectangle.X + relativeRect.Left;
                    absoluteRect.Top = (int)element.GetCurrent().BoundingRectangle.Y + relativeRect.Top;
                    absoluteRect.Height = (int)element.GetCurrent().BoundingRectangle.Height + relativeRect.Height;
                    absoluteRect.Width = (int)element.GetCurrent().BoundingRectangle.Width + relativeRect.Width;
                    
                    /*
                    absoluteX = (int)element.Current.BoundingRectangle.X + Left;
                    absoluteY = (int)element.Current.BoundingRectangle.Y + Top;
                    absoluteHeight = (int)element.Current.BoundingRectangle.Height + Height;
                    absoluteWidth = (int)element.Current.BoundingRectangle.Width + Width;
                    */
                }
                
                if (0 == relativeRect.Height) { relativeRect.Height = Screen.PrimaryScreen.Bounds.Height; }
                if (0 == relativeRect.Width) { relativeRect.Width = Screen.PrimaryScreen.Bounds.Width; }
                
                // 20140312
                // if (element != null && (int)element.Current.ProcessId > 0) {
                    if (element != null && (int)element.GetCurrent().ProcessId > 0) {
                    
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
                    absoluteRect,
                    path,
                    format);
            }
            catch {}
        }
        
        public static void GetScreenshotOfSquare(PSCmdletBase cmdlet,
                                                 string description,
                                                 bool save,
                                                 ScreenshotRect absRect,
                                                 string path, //)// = 0) //, int monitor)
                                                 ImageFormat format)
        {
            Image myImage =
                new Bitmap(absRect.Width,
                           absRect.Height);
            
            Graphics gr1 = Graphics.FromImage(myImage);
            IntPtr dc1 = gr1.GetHdc();
            
            // for now, the primary display only
            IntPtr desktopHandle = NativeMethods.GetDesktopWindow();
            IntPtr dc2 = NativeMethods.GetWindowDC(desktopHandle);
            // IntPtr dc2 = GetWindowDC(GetDesktopWindow());
            NativeMethods.BitBlt(
                dc1,
                0,
                0,
                absRect.Width,
                absRect.Height,
                dc2,
                absRect.Left,
                absRect.Top,
                13369376);
            
            /*
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
            */
            
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
                    //    break;
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
            Point mousePoint)
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
                // 20140312
                // if (element != null && (int)element.Current.ProcessId > 0)
                if (element != null && (int)element.GetCurrent().ProcessId > 0)
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
                classic.CacheRequest cacheRequest = new classic.CacheRequest
                {
                    AutomationElementMode = classic.AutomationElementMode.Full,
                    // 20140130
                    // TODO:
                    TreeFilter = classic.Automation.RawViewCondition
                };
                //cacheRequest.AutomationElementMode = AutomationElementMode.None;
                cacheRequest.Add(classic.AutomationElement.NameProperty);
                cacheRequest.Add(classic.AutomationElement.AutomationIdProperty);
                cacheRequest.Add(classic.AutomationElement.ClassNameProperty);
                cacheRequest.Add(classic.AutomationElement.ControlTypeProperty);
                cacheRequest.Add(classic.AutomationElement.ProcessIdProperty);
                cacheRequest.Add(classic.DockPattern.Pattern);
                cacheRequest.Add(classic.ExpandCollapsePattern.Pattern);
                cacheRequest.Add(classic.GridItemPattern.Pattern);
                cacheRequest.Add(classic.GridPattern.Pattern);
                cacheRequest.Add(classic.InvokePattern.Pattern);
                //                try {
                //                    cacheRequest.Add(ItemContainerPattern.Pattern);
                //                }
                //                catch {}
                cacheRequest.Add(classic.MultipleViewPattern.Pattern);
                cacheRequest.Add(classic.RangeValuePattern.Pattern);
                cacheRequest.Add(classic.ScrollItemPattern.Pattern);
                cacheRequest.Add(classic.ScrollPattern.Pattern);
                cacheRequest.Add(classic.SelectionItemPattern.Pattern);
                cacheRequest.Add(classic.SelectionPattern.Pattern);
                //                try {
                //                    cacheRequest.Add(SynchronizedInputPattern.Pattern);
                //                }
                //                catch {}
                cacheRequest.Add(classic.TableItemPattern.Pattern);
                cacheRequest.Add(classic.TablePattern.Pattern);
                cacheRequest.Add(classic.TextPattern.Pattern);
                cacheRequest.Add(classic.TogglePattern.Pattern);
                cacheRequest.Add(classic.TransformPattern.Pattern);
                cacheRequest.Add(classic.ValuePattern.Pattern);
                //                try {
                //                    cacheRequest.Add(VirtualizedItemPattern.Pattern);
                //                }
                //                catch {}
                cacheRequest.Add(classic.WindowPattern.Pattern);
                // cache patterns?
                
                // cacheRequest.Activate();
                cacheRequest.Push();
                
                try{
                    element.FindFirst(classic.TreeScope.Element, classic.Condition.TrueCondition);
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
                        IValuePattern pattern =
                            // 20131208
                            // element.GetCurrentPattern(classic.ValuePattern.Pattern) as IValuePattern;
                            // element.GetCurrentPattern<IValuePattern, ValuePattern>(classic.ValuePattern.Pattern) as IValuePattern;
                            element.GetCurrentPattern<IValuePattern>(classic.ValuePattern.Pattern);
                        if (null != pattern) {
                            elementVerbosity +=
                                // 20131204
                                // GetElementPropertyString(cmdlet, element, "Value", pattern, ref hasName);
                                element.GetElementPropertyString(cmdlet, "Value", pattern, ref hasName);
                        }
                    }
                    catch (Exception) {
                    }
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
                        try {
                            // 20131209
                            // AutomationPattern[] elementPatterns =
                            //     element.GetSupportedPatterns();
                            IBasePattern[] elementPatterns =
                                element.GetSupportedPatterns();
                            
                                // element.GetSourceElement().GetSupportedPatterns().ConvertAutomationPatternToBasePattern(element);
                     
                               
                            if (!cmdlet.NoEvents) {
                                SubscribeToEventsDuringRecording(cmdlet, element, elementPatterns);
                            }
                            
                            if (cmdlet.WriteCurrentPattern) {
                                // 20131209
                                // foreach (AutomationPattern ptrn in elementPatterns)
                                foreach (IBasePattern ptrn in elementPatterns)
                                {
                                    strElementPatterns += "\r\n\t\t#";
                                    strElementPatterns +=
                                        // 20131209
                                        // ptrn.ProgrammaticName.Replace("Identifiers.Pattern", "");
                                        // 20131210
                                        // (ptrn.SourcePattern as AutomationPattern).ProgrammaticName.Replace("Identifiers.Pattern", "");
                                        // 20131227
                                        // (ptrn.GetSourcePattern() as AutomationPattern).ProgrammaticName.Replace("Identifiers.Pattern", string.Empty);
                                        // gets name of pattern from the name of type like UiaInvokePattern -> InvokePattern
                                        ptrn.GetType().Name.Replace("Uia", string.Empty);
                                    strElementPatterns += ": use the ";
                                    
                                    string tempControlNameForCmdlet =
                                        // 20131227
                                        // "-UIA" +
                                        "-Uia" +
                                        elementControlType;
                                    
                                    // 20131209
                                    // switch (ptrn.ProgrammaticName.Replace("Identifiers.Pattern", "")) {
                                    // 20131210
                                    // switch ((ptrn as AutomationPattern).ProgrammaticName.Replace("Identifiers.Pattern", "")) {
                                    // switch ((ptrn.SourcePattern as AutomationPattern).ProgrammaticName.Replace("Identifiers.Pattern", "")) {
                                    // 20131227
                                    // switch ((ptrn.GetSourcePattern() as AutomationPattern).ProgrammaticName.Replace("Identifiers.Pattern", string.Empty)) {
                                    switch (ptrn.GetType().Name.Replace("Uia", string.Empty)) {
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
                                                // 20140312
//                                                if (element.Current.Name.Length > 0) {
//                                                    tempName = element.Current.Name;
                                                if (element.GetCurrent().Name.Length > 0) {
                                                    tempName = element.GetCurrent().Name;
                                                }
                                            }
                                            catch {
                                                // 20140312
                                                // if (element.Cached.Name.Length > 0) {
                                                // if ((element as ISupportsCached).Cached.Name.Length > 0) {
                                                if (element.GetCached().Name.Length > 0) {
                                                    // tempName = element.Cached.Name;
                                                    // tempName = (element as ISupportsCached).Cached.Name;
                                                    tempName = element.GetCached().Name;
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
                        } catch (Exception) {
//                                                                Exception ePatterns2 =
//                                                                    new Exception("Patterns:\r\n" +
//                                                                                  ePatterns.Message +
//                                                                                  "\r\n" +
//                                                                                  strInfo);
//                            // 20131227
//                                                                throw(ePatterns2);
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
                    
                    
                    
                    
                    // throw (eGatheringCycle2);
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
//            // ValuePattern -> IValuePattern
//            //ValuePattern pattern,
//            IValuePattern pattern,
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
//                        break;
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
//                        break;
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
                    
                    // cache request object for collecting properties
                    classic.CacheRequest cacheRequest = null;
                    
// return;
                    
//                    try {
//                        cacheRequest = new CacheRequest
//                        {
//                            AutomationElementMode = AutomationElementMode.None,
//                            TreeFilter = Automation.RawViewCondition
//                        };
//// return;
//                        cacheRequest.Add(AutomationElement.NameProperty);
//                        // cacheRequest.Add(AutomationElement.AutomationIdProperty);
//                        cacheRequest.Add(AutomationElement.ControlTypeProperty);
//                        // cacheRequest.Add(AutomationElement.ClassNameProperty);
//                        // cacheRequest.Push();
//// return;
//                        cacheRequest.Activate();
//// return;
//                        // element.FindFirst(TreeScope.Element, Condition.TrueCondition);
//                    } catch (Exception eCacheRequest) {
////                        cmdlet.WriteVerbose(cmdlet, "Cache request failed for " + element.Current.Name);
////                        cmdlet.WriteVerbose(cmdlet, eCacheRequest.Message);
//                    }
                    
// return;
                    
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
//return;
                            switch ((pattern.GetSourcePattern() as classic.AutomationPattern).ProgrammaticName) {
                                case "SelectionItemPatternIdentifiers.Pattern":
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             classic.SelectionItemPattern.ElementAddedToSelectionEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             classic.SelectionItemPattern.ElementRemovedFromSelectionEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             classic.SelectionItemPattern.ElementSelectedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    break;
                                case "SelectionPatternIdentifiers.Pattern":
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             classic.SelectionPattern.InvalidatedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    break;
                                case "InvokePatternIdentifiers.Pattern":
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             classic.InvokePattern.InvokedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    break;
                                case "AutomationElementIdentifiers.Pattern":
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             classic.AutomationElement.AsyncContentLoadedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             classic.AutomationElement.LayoutInvalidatedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             classic.AutomationElement.MenuClosedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             classic.AutomationElement.MenuOpenedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             classic.AutomationElement.ToolTipClosedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             classic.AutomationElement.ToolTipOpenedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             classic.AutomationElement.AutomationFocusChangedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             classic.AutomationElement.AutomationPropertyChangedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             classic.AutomationElement.StructureChangedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    break;
                                case "TextPatternIdentifiers.Pattern":
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             classic.TextPattern.TextChangedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             classic.TextPattern.TextSelectionChangedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    break;
                                case "WindowPatternIdentifiers.Pattern":
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             classic.WindowPattern.WindowOpenedEvent,
                                                             null); //,
                                    //cmdlet.OnUIRecordingAutomationEvent);
                                    cmdlet.SubscribeToEvents(cmdlet,
                                                             element,
                                                             classic.WindowPattern.WindowClosedEvent,
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
                                                (pattern.GetSourcePattern() as classic.AutomationPattern).ProgrammaticName +
                                                " event for " +
                                // 20140312
                                                // element.Current.Name);
                                element.GetCurrent().Name);
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
                    // 20140130
                    // TODO:
                    classic.Automation.RemoveAutomationEventHandler(
                        // 20131202
                        // (AutomationEvent)cmdlet.SubscribedEventsIds[i],
                        cmdlet.SubscribedEventsIds[i],
                        // 20140102
                        // cmdlet.thePreviouslyUsedElement.GetSourceElement(),
                        // 20140130
                        // TODO:
                        cmdlet.thePreviouslyUsedElement.GetSourceElement() as classic.AutomationElement,
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
        public static IUiElement GetAutomationElementFromHandle(int handle)
        {
            IUiElement result = null;
            
            if (handle == 0) {
                // cmdlet.WriteVerbose(cmdlet, "handle == 0");
                return result;
            }
            try {
                //System.IntPtr pHwnd = IntPtr.Zero;
                var pHwnd = new IntPtr(handle);
                
                /*
                IntPtr pHwnd = new IntPtr(handle);
                */
                // cmdlet.WriteVerbose(cmdlet, "getting the control");
                // 20131109
                //element =
                //    AutomationElement.FromHandle(pHwnd);
                // 20131112
                //element =
                //    new UiElement(AutomationElement.FromHandle(pHwnd));
                _element =
                    AutomationFactory.GetUiElement(classic.AutomationElement.FromHandle(pHwnd));
                if (_element != null) {
                    // cmdlet.WriteVerbose(cmdlet, _element.Current.Name);
                }
                result = _element;
            }
            catch (Exception) {
                // cmdlet.WriteVerbose(cmdlet, e.Message);
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
        internal static IBasePattern[] GetElementPatternsFromPoint()
        {
            IBasePattern[] result = null;
            GetAutomationElementFromPoint();
            result = _element.GetSupportedPatterns();
            return result;
        }
        
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
            // 20140210
//            if (result != null) {
//                // writer.WriteLine("GetCurrentPatternFromPoint: result = " + result.ToString());
//                ////writer.WriteLine(GetCurrentPatternFromPoint: element.Current.ClassName);
//            } else {
//                // writer.WriteLine("GetCurrentPatternFromPoint: result = null");
//            }
            // writer.Flush();
            return result;
        }
        
        /// <summary>
        ///
        /// </summary>
        /// <param name="patternName"></param>
        /// <returns></returns>
        internal static classic.AutomationPattern GetPatternByName(string patternName)
        {
            classic.AutomationPattern result = null;
            // normalize name
            patternName =
                patternName.Substring(0, patternName.Length - 7) +
                "Pattern";
            patternName.Replace("dock", "Dock"); // ??
            switch (patternName) {
                case "DockPattern":
                    result = classic.DockPattern.Pattern;
                    break;
                case "ExpandCollapsePattern":
                    result = classic.ExpandCollapsePattern.Pattern;
                    break;
                case "GridItemPattern":
                    result = classic.GridItemPattern.Pattern;
                    break;
                case "GridPattern":
                    result = classic.GridPattern.Pattern;
                    break;
                case "InvokePattern":
                    result = classic.InvokePattern.Pattern;
                    break;
                case "MultipleViewPattern":
                    result = classic.MultipleViewPattern.Pattern;
                    break;
                case "RangeValuePattern":
                    result = classic.RangeValuePattern.Pattern;
                    break;
                case "ScrollItemPattern":
                    result = classic.ScrollItemPattern.Pattern;
                    break;
                case "ScrollPattern":
                    result = classic.ScrollPattern.Pattern;
                    break;
                case "SelectionItemPattern":
                    result = classic.SelectionItemPattern.Pattern;
                    break;
                case "SelectionPattern":
                    result = classic.SelectionPattern.Pattern;
                    break;
                case "TableItemPattern":
                    result = classic.TableItemPattern.Pattern;
                    break;
                case "TablePattern":
                    result = classic.TablePattern.Pattern;
                    break;
                case "TextPattern":
                    result = classic.TextPattern.Pattern;
                    break;
                case "TogglePattern":
                    result = classic.TogglePattern.Pattern;
                    break;
                case "TransformPattern":
                    result = classic.TransformPattern.Pattern;
                    break;
                case "ValuePattern":
                    result = classic.ValuePattern.Pattern;
                    break;
                case "WindowPattern":
                    result = classic.WindowPattern.Pattern;
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
            classic.AutomationPattern patternType)
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
                foreach (IBasePattern ptrn in supportedPatterns.Where(ptrn => patternType.ProgrammaticName == (ptrn.GetSourcePattern() as classic.AutomationPattern).ProgrammaticName ||
                                                                                   patternType == null))
                {
                    object pattern = null;
                    if (!element.TryGetCurrentPattern(
                        // 20131209
                        // ptrn, out pattern)) continue;
                        // 20131210
                        // (ptrn as AutomationPattern), out pattern)) continue;
                        (ptrn.GetSourcePattern() as classic.AutomationPattern), out pattern)) continue;
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
                        element.GetCurrentPattern((ptrn.GetSourcePattern() as classic.AutomationPattern));
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
        public static classic.ControlType
            GetControlTypeByTypeName(string controlType)
        {
            string controlTypeInUpperCase = controlType.ToUpper();
            switch (controlTypeInUpperCase)
            {
                    case "BUTTON": { return classic.ControlType.Button; }
                    case "CALENDAR": { return classic.ControlType.Calendar; }
                    case "CHECKBOX": { return classic.ControlType.CheckBox; }
                    case "COMBOBOX": { return classic.ControlType.ComboBox; }
                    case "CUSTOM": { return classic.ControlType.Custom; }
                    case "DATAGRID": { return classic.ControlType.DataGrid; }
                    case "DATAITEM": { return classic.ControlType.DataItem; }
                    case "DOCUMENT": { return classic.ControlType.Document; }
                    case "EDIT": { return classic.ControlType.Edit; }
                    case "GROUP": { return classic.ControlType.Group; }
                    case "HEADER": { return classic.ControlType.Header; }
                    case "HEADERITEM": { return classic.ControlType.HeaderItem; }
                    case "HYPERLINK": { return classic.ControlType.Hyperlink; }
                    case "IMAGE": { return classic.ControlType.Image; }
                    case "LIST": { return classic.ControlType.List; }
                    case "LISTITEM": { return classic.ControlType.ListItem; }
                    case "MENU": { return classic.ControlType.Menu; }
                    case "MENUBAR": { return classic.ControlType.MenuBar; }
                    case "MENUITEM": { return classic.ControlType.MenuItem; }
                    case "PANE": { return classic.ControlType.Pane; }
                    case "PROGRESSBAR": { return classic.ControlType.ProgressBar; }
                    case "RADIOBUTTON": { return classic.ControlType.RadioButton; }
                    case "SCROLLBAR": { return classic.ControlType.ScrollBar; }
                    case "SEPARATOR": { return classic.ControlType.Separator; }
                    case "SLIDER": { return classic.ControlType.Slider; }
                    case "SPINNER": { return classic.ControlType.Spinner; }
                    case "SPLITBUTTON": { return classic.ControlType.SplitButton; }
                    case "STATUSBAR": { return classic.ControlType.StatusBar; }
                    case "TAB": { return classic.ControlType.Tab; }
                    case "TABITEM": { return classic.ControlType.TabItem; }
                    case "TABLE": { return classic.ControlType.Table; }
                    case "TEXT": { return classic.ControlType.Text; }
                    case "THUMB": { return classic.ControlType.Thumb; }
                    case "TITLEBAR": { return classic.ControlType.TitleBar; }
                    case "TOOLBAR": { return classic.ControlType.ToolBar; }
                    case "TOOLTIP": { return classic.ControlType.ToolTip; }
                    case "TREE": { return classic.ControlType.Tree; }
                    case "TREEITEM": { return classic.ControlType.TreeItem; }
                    case "WINDOW": { return classic.ControlType.Window; }
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
                    classic.TreeScope.Descendants,
                    new classic.PropertyCondition(
                        classic.AutomationElement.ControlTypeProperty,
                        classic.ControlType.HeaderItem));
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
                        // 20140312
                        // headerItem.Current.Name;
                        headerItem.GetCurrent().Name;
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
                    classic.TreeScope.Descendants,
                    new classic.PropertyCondition(
                        classic.AutomationElement.ControlTypeProperty,
                        classic.ControlType.Header));
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
                        // 20140312
                        // headerItem.Current.Name;
                        headerItem.GetCurrent().Name;
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
                // object[] coordinates =
                // { rowsCounter, columnsCounter };
                // 20140102
                IUiElement cell;
                if (pattern is IGridPattern) {
                    cell = (pattern as IGridPattern).GetItem(rowsCounter, columnsCounter);
                    // 20140312
                    // onerow += cell.Current.Name;
                    onerow += cell.GetCurrent().Name;
                }
//                if (pattern is ITablePattern) {
//                    cell = (pattern as ITablePattern).
//                }
                /*
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
                */
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
            var rowsCollection =
                new List<string>();
            
            /*
            List<string> rowsCollection =
                new List<string>();
            */
            
            IUiEltCollection rows =
                control.FindAll(classic.TreeScope.Children,
                                new classic.PropertyCondition(
                                    classic.AutomationElement.ControlTypeProperty,
                                    classic.ControlType.Custom));
            if (rows.Count > 0) {
                
                foreach(IUiElement row in rows) {
                    
                    IUiEltCollection rowItems =
                        row.FindAll(classic.TreeScope.Children,
                                    new classic.PropertyCondition(
                                        classic.AutomationElement.ControlTypeProperty,
                                        classic.ControlType.Custom));
                    if (rowItems.Count <= 0) continue;
                    string onerow = String.Empty;
                    
                    int rowCounter = 0;
                    foreach (IUiElement rowItem in rowItems) {
                        
                        rowCounter++;
                        string strValue = String.Empty;
                        strValue += '"';
                        try
                        {
                            IValuePattern valPattern = rowItem.GetCurrentPattern<IValuePattern>(classic.ValuePattern.Pattern);
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
//                                rowItems[i].GetCurrentPattern(classic.ValuePattern.Pattern)
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
                                rowItems[i].GetCurrentPattern(classic.ValuePattern.Pattern)
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
                                    rowItems[i].GetCurrentPattern(classic.ValuePattern.Pattern)
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
                            // (DiscoveryCmdletBase)cmdlet,
                            resultHandle);
                    // 20140312
                    // if (treeItemName == resultElement.Current.Name) {
                    if (treeItemName == resultElement.GetCurrent().Name) {
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
                            // (DiscoveryCmdletBase)cmdlet,
                            childHandle);
                    // 20140312
                    // if (treeItemName == resultElement.Current.Name) {
                    if (treeItemName == resultElement.GetCurrent().Name) {
                        return resultElement;
                    }
                            
                    // gettting children
                    resultElement =
                        GetSheridanTreeItemFromTreeNode(
                            cmdlet,
                            hwndTreeView,
                            (IntPtr)childHandle,
                            treeItemName);
                    // 20140312
                    // if (treeItemName == resultElement.Current.Name) {
                    if (treeItemName == resultElement.GetCurrent().Name) {
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

        // 20140318
        // private static ArrayList GetAllWindows()
//        internal static IEnumerable<IntPtr> GetChildWindows2222(IntPtr parent)
//        {
//            var windowHandles = new ArrayList();
//            // var windowHandles = new List<IntPtr>();
//            EnumedWindow callBackPtr = GetWindowHandle;
//            EnumWindows(callBackPtr, windowHandles);
//            
////            foreach (IntPtr windowHandle in windowHandles.ToArray())
////            {
////                EnumChildWindows(windowHandle, callBackPtr, windowHandles);
////            }
//            
//// Console.WriteLine("all == {0}", windowHandles.Count);
//            // return windowHandles;
//            // return (List<IntPtr>)(windowHandles.ToArray(typeof(IntPtr)));
//            return windowHandles.Cast<IntPtr>().ToList();
//        }

        // private delegate bool EnumedWindow(IntPtr handleWindow, ArrayList handles);
        // private delegate bool EnumedWindow(IntPtr handleWindow, List<IntPtr> handles);
        
//        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
//        [return: MarshalAs(UnmanagedType.Bool)]
//        private static extern bool EnumWindows(EnumedWindow lpEnumFunc, ArrayList lParam);
//        // private static extern bool EnumWindows(EnumedWindow lpEnumFunc, List<IntPtr> lParam);
        
//        [DllImport("user32")]
//        [return: MarshalAs(UnmanagedType.Bool)]
//        private static extern bool EnumChildWindows(IntPtr window, EnumedWindow callback, ArrayList lParam);
//        // private static extern bool EnumChildWindows(IntPtr window, EnumedWindow callback, List<IntPtr> lParam);
        
//        private static bool GetWindowHandle(IntPtr windowHandle, ArrayList windowHandles)
//        // private static bool GetWindowHandle(IntPtr windowHandle, List<IntPtr> windowHandles)
//        {
//            windowHandles.Add(windowHandle);
//            return true;
//        }
        
        
//    [DllImport("user32")]
//    [return: MarshalAs(UnmanagedType.Bool)]
//    public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);

        internal static IEnumerable<IntPtr> GetChildWindows(IntPtr parent)
        // private static IEnumerable<IntPtr> GetChildWindows(IntPtr parent)
        {
            /*
            var result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                var childProc = new EnumWindowProc(EnumWindow);
                NativeMethods.EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return result;
            */
            
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                NativeMethods.EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
                // NativeMethods.Win32Callback childProc = new NativeMethods.Win32Callback(EnumWindow);
                // NativeMethods.EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
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
            var list = gch.Target as List<IntPtr>;
            if (list == null)
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
    
            list.Add(handle);            
            return true;
        }
        
        internal static List<IUiElement> EnumChildWindowsFromHandle(string[] names, string automationId, string className, IntPtr parentHandle)
        {
            // 20140318
            /*
            IEnumerable<IntPtr> list =
                GetChildWindows(parentHandle);
            
            var resultElements =
                new List<IUiElement>();
            
            var automationElements =
                new ArrayList();
            
            foreach (IntPtr handle in list) {
            */
            
            var resultElements =
                new List<IUiElement>();
            
            var automationElements =
                new ArrayList();
            
//Console.WriteLine("before GetChildWindows");
            // var handlesList = GetChildWindows(parentHandle).ToArray();
            var handlesList = GetWindows().ToArray();
//Console.WriteLine("the handles number is {0}", handlesList.Length);
            for (int iHandleCounter = 0; iHandleCounter < handlesList.Length; iHandleCounter++) {
                
            // foreach (IntPtr handle in GetChildWindows(parentHandle)) {
                
                try {
                    
// Console.WriteLine("=========================================================================");
// Console.WriteLine(iHandleCounter++.ToString());
//Console.WriteLine(iHandleCounter.ToString());
//Console.WriteLine("window handle {0}", handle.ToInt32());
                    // 20140318
                    // IUiElement element =
                    //     GetAutomationElementFromHandle(handle.ToInt32());
                    
                    // if (IntPtr.Zero != handle) { // && 0 != handle.ToInt32()) {
                    if (IntPtr.Zero != handlesList[iHandleCounter]) {
//                        IUiElement element =
//                            GetAutomationElementFromHandle(handle.ToInt32());
                        IUiElement element =
                            // AutomationFactory.GetUiElement(classic.AutomationElement.FromHandle(handle));
                            AutomationFactory.GetUiElement(classic.AutomationElement.FromHandle(handlesList[iHandleCounter]));
                        
//if (null != element) {
//    Console.WriteLine("null != element");
//    Console.WriteLine("name = {0}", element.GetCurrent().Name);
//    Console.WriteLine("auId = {0}", element.GetCurrent().AutomationId);
//    Console.WriteLine("class = {0}", element.GetCurrent().ClassName);
//    Console.WriteLine("type = {0}", element.GetCurrent().ControlType.ProgrammaticName);
//    Console.WriteLine("pid = {0}", element.GetCurrent().ProcessId);
//    Console.WriteLine("handle = {0}", element.GetCurrent().NativeWindowHandle);
//} else {
//    Console.WriteLine("null == element");
//}
                        
                        
                        // 20140318
                        // automationElements.Add(element);
                        if (null != element && classic.ControlType.Window == element.GetCurrent().ControlType) {
                            automationElements.Add(element);
                        } else {
                            handlesList[iHandleCounter] = IntPtr.Zero;
                            element.SetSourceElement<IUiElement>(null);
                            AutomationFactory.Release(element);
                            // element.Dispose();
                            // element = null;
                        }
                    
                    }
                }
                catch (Exception) {
//Console.WriteLine(eFromHandle.Message);
                }
            }
            
            if (null == names || 0 == names.Length) {
                names = new string[] { "*" };
            }
            
            foreach (string windowName in names) {
                
                var controlSearcherData =
                    new ControlSearcherData {
                    Name = windowName,
                    AutomationId = automationId,
                    Class = className,
                    Value = string.Empty,
                    ControlType = new string[]{ "Window" }
                };
                
                resultElements.AddRange(
                    WindowSearcher.ReturnOnlyRightElements(
                        automationElements,
                        controlSearcherData,
                        false,
                        true));
            }
            
            // 20140131
//            if (null != automationElements && 0 < automationElements.Count) {
//                foreach (IUiElement element in automationElements) {
//                    element.Dispose();
//                }
//            }
            // extra?
            automationElements.Clear();
            // 20140121
            automationElements = null;
            //
            
            //};
            
            //return automationElements;
            return resultElements;
        }
        
        public static List<IUiElement> Enum1ChildWindows(IntPtr parentHandle)
        {
            
            //PSCmdletBase cmdlet = new GetUiaWindowCommand();
            // GetWindowCmdletBase cmdlet = new GetWindowCmdletBase();
            var cmdlet = new GetWindowCmdletBase();
            List<IUiElement> resultList =
                // EnumChildWindowsFromHandle(cmdlet, parentHandle);
                EnumChildWindowsFromHandle(cmdlet.Name, cmdlet.AutomationId, cmdlet.Class, parentHandle);
            
            return resultList;
        }
        
        public static List<IUiElement> Enum2ChildWindows(IntPtr parentHandle)
        {
            
            //PSCmdletBase cmdlet = new GetUiaWindowCommand();
            // GetWindowCmdletBase cmdlet = new GetWindowCmdletBase();
            var cmdlet = new GetWindowCmdletBase();
            List<IUiElement> resultList =
                // EnumChildWindowsFromHandle(cmdlet, IntPtr.Zero);
                EnumChildWindowsFromHandle(cmdlet.Name, cmdlet.AutomationId, cmdlet.Class, IntPtr.Zero);
            
            return resultList;
        }
        
//        public delegate bool CallBackPtr(int hwnd, int lParam);
//        private CallBackPtr callBackPtr;
//        
//        internal static IEnumerable<IntPtr> GetWindows()
//        {
//            callBackPtr = new CallBackPtr(EnumReport.Report);  
//            NativeMethods.EnumWindows(callBackPtr, 0);
//        }
        
        // public delegate bool EnumedWindow(IntPtr handleWindow, ArrayList handles);
        
        // public static ArrayList GetWindows()
        public static IEnumerable<IntPtr> GetWindows()
        {    
            ArrayList windowHandles = new ArrayList();
            NativeMethods.EnumedWindow callBackPtr = GetWindowHandle;
            NativeMethods.EnumWindows(callBackPtr, windowHandles);
            
            // return windowHandles;
            return windowHandles.Cast<IntPtr>().ToList();            
        }
        
        private static bool GetWindowHandle(IntPtr windowHandle, ArrayList windowHandles)
        {
            windowHandles.Add(windowHandle);
            return true;
        }
        #endregion experimental
        
        public static Type[] GetSupportedInterfaces<T>(T element)
        {
            // always offered patterns
            var supportedTypes = new List<Type>
            {
                typeof (ISupportsHighlighter),
                typeof (ISupportsNavigation),
                typeof (ISupportsConversion),
                typeof (ISupportsRefresh)
            };
            
            if (Preferences.UseElementsSearchObjectModel) {
                supportedTypes.Add(typeof(ISupportsExtendedModel));
            }
            
            if (Preferences.UseElementsCached) {
                supportedTypes.Add(typeof(ISupportsCached));
            }
            if (Preferences.UseElementsCurrent) {
                supportedTypes.Add(typeof(ISupportsCurrent));
            }
            
            if (element is classic.AutomationElement) {
                
                var aElement = element as classic.AutomationElement;
                foreach (classic.AutomationPattern pattern in aElement.GetSupportedPatterns()) {
                    // calculated patterns
                    if (pattern == classic.DockPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsDockPattern));
                    }
                    if (pattern == classic.ExpandCollapsePattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsExpandCollapsePattern));
                    }
                    if (pattern == classic.GridItemPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsGridItemPattern));
                    }
                    if (pattern == classic.GridPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsGridPattern));
                        supportedTypes.Add(typeof(ISupportsExport));
                    }
                    if (pattern == classic.InvokePattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsInvokePattern));
                    }
                    if (pattern == classic.RangeValuePattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsRangeValuePattern));
                    }
                    if (pattern == classic.SelectionItemPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsSelectionItemPattern));
                    }
                    if (pattern == classic.SelectionPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsSelectionPattern));
                    }
                    if (pattern == classic.ScrollItemPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsScrollItemPattern));
                    }
                    if (pattern == classic.ScrollPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsScrollPattern));
                    }
                    if (pattern == classic.TableItemPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsTableItemPattern));
                    }
                    if (pattern == classic.TablePattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsTablePattern));
                        supportedTypes.Add(typeof(ISupportsConversion));
                    }
                    if (pattern == classic.TextPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsTextPattern));
                    }
                    if (pattern == classic.TogglePattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsTogglePattern));
                    }
                    if (pattern == classic.TransformPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsTransformPattern));
                    }
                    if (pattern == classic.ValuePattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsValuePattern));
                    }
                    if (pattern == classic.WindowPattern.Pattern) {
                        supportedTypes.Add(typeof(ISupportsWindowPattern));
                    }
                }
            }
            if (element is IUiElement) {
                
                var uiElement = element as IUiElement;
                foreach (IBasePattern pattern in uiElement.GetSupportedPatterns()) {
                    
                    // calculated patterns
                    if (pattern is IDockPattern) {
                        supportedTypes.Add(typeof(ISupportsDockPattern));
                    }
                    if (pattern is IExpandCollapsePattern) {
                        supportedTypes.Add(typeof(ISupportsExpandCollapsePattern));
                    }
                    if (pattern is IGridItemPattern) {
                        supportedTypes.Add(typeof(ISupportsGridItemPattern));
                    }
                    if (pattern is IGridPattern) {
                        supportedTypes.Add(typeof(ISupportsGridPattern));
                        supportedTypes.Add(typeof(ISupportsExport));
                    }
                    if (pattern is IInvokePattern) {
                        supportedTypes.Add(typeof(ISupportsInvokePattern));
                    }
                    if (pattern is IRangeValuePattern) {
                        supportedTypes.Add(typeof(ISupportsRangeValuePattern));
                    }
                    if (pattern is ISelectionItemPattern) {
                        supportedTypes.Add(typeof(ISupportsSelectionItemPattern));
                    }
                    if (pattern is ISelectionPattern) {
                        supportedTypes.Add(typeof(ISupportsSelectionPattern));
                    }
                    if (pattern is IScrollItemPattern) {
                        supportedTypes.Add(typeof(ISupportsScrollItemPattern));
                    }
                    if (pattern is IScrollPattern) {
                        supportedTypes.Add(typeof(ISupportsScrollPattern));
                    }
                    if (pattern is ITableItemPattern) {
                        supportedTypes.Add(typeof(ISupportsTableItemPattern));
                    }
                    if (pattern is ITablePattern) {
                        supportedTypes.Add(typeof(ISupportsTablePattern));
                        supportedTypes.Add(typeof(ISupportsConversion));
                    }
                    if (pattern is ITextPattern) {
                        supportedTypes.Add(typeof(ISupportsTextPattern));
                    }
                    if (pattern is ITogglePattern) {
                        supportedTypes.Add(typeof(ISupportsTogglePattern));
                    }
                    if (pattern is ITransformPattern) {
                        supportedTypes.Add(typeof(ISupportsTransformPattern));
                    }
                    if (pattern is IValuePattern) {
                        supportedTypes.Add(typeof(ISupportsValuePattern));
                    }
                    if (pattern is IWindowPattern) {
                        supportedTypes.Add(typeof(ISupportsWindowPattern));
                    }
                }
            }
            
            return supportedTypes.ToArray();
        }
        
        internal static classic.Condition GetTreeFilter(string filter)
        {
            var myAutomation = AutomationFactory.GetMyAutomation();
            
            switch (filter.ToUpper()) {
                case "RAW":
                    return myAutomation.RawViewCondition; 
                case "CONTENT":
                    return myAutomation.ContentViewCondition;
                case "CONTROL":
                    return myAutomation.ControlViewCondition;
                default:
                    return myAutomation.RawViewCondition;
            }
        }
        
        internal static classic.TreeScope GetTreeScope(string scope)
        {
            switch (scope.ToUpper()) {
                case "SUBTREE":
                    return classic.TreeScope.Subtree;
                case "CHILDREN":
                    return classic.TreeScope.Children;
                case "DESCENDANTS":
                    return classic.TreeScope.Descendants;
                case "ELEMENT":
                    return classic.TreeScope.Element;
                default:
                    return classic.TreeScope.Descendants;
            }
        }
    }
    
    #region experimental
    public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
    #endregion experimental
}