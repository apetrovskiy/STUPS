/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 28/11/2011
 * Time: 08:00 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Linq;

namespace UIAutomation
{
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
    
    using PSTestLib;
    
    using UIAutomation.Commands;

    /// <summary>
    /// Description of UIAHelper.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public static class UIAHelper
    {
        
        private static Highlighter highlighter = null;
        private static Highlighter highlighterParent = null;
        //private static Highlighter highlighterFirstChild = null;
        private static Highlighter highlighterCheckedControl = null;
        
        private static Banner banner = null;
        
        // 20131109
        //private static System.Windows.Automation.AutomationElement element = null;
        private static IMySuperWrapper element = null;
        
        //internal static CacheRequest CacheRequest = null;
        
        private static ArrayList GetControlByName(
            GetControlCmdletBase cmdlet,
            IntPtr containerHandle,
            string name,
            int level)
        {
            IntPtr resultHandle = IntPtr.Zero;
            IntPtr controlHandle = IntPtr.Zero;
            
            ArrayList controlHandles = new ArrayList();
            ArrayList tempControlHandles = new ArrayList();
            
            cmdlet.WriteVerbose(cmdlet, "name = " + name);
            
            //if ("*" == name || string.Empty == name) {
            cmdlet.WriteVerbose(cmdlet, "using null instead of name");
            cmdlet.WriteVerbose(cmdlet, "test >>>>>>>>>>>>>>>>>>>>>>>>>");
            // 20131109
            //try{ cmdlet.WriteVerbose(cmdlet, "name = " + AutomationElement.FromHandle(controlHandle).Current.Name); } catch {}
            //try{ cmdlet.WriteVerbose(cmdlet, "automationid = " + AutomationElement.FromHandle(controlHandle).Current.AutomationId); } catch {}
            //try{ cmdlet.WriteVerbose(cmdlet, "class = " + AutomationElement.FromHandle(controlHandle).Current.ClassName); } catch {}
            //try{ cmdlet.WriteVerbose(cmdlet, "control type = " + AutomationElement.FromHandle(controlHandle).Current.ControlType.ProgrammaticName); } catch {}
            try{ cmdlet.WriteVerbose(cmdlet, "name = " + MySuperWrapper.FromHandle(controlHandle).Current.Name); } catch {}
            try{ cmdlet.WriteVerbose(cmdlet, "automationid = " + MySuperWrapper.FromHandle(controlHandle).Current.AutomationId); } catch {}
            try{ cmdlet.WriteVerbose(cmdlet, "class = " + MySuperWrapper.FromHandle(controlHandle).Current.ClassName); } catch {}
            try{ cmdlet.WriteVerbose(cmdlet, "control type = " + MySuperWrapper.FromHandle(controlHandle).Current.ControlType.ProgrammaticName); } catch {}
            
            // search at this level
            do {
                cmdlet.WriteVerbose(
                    cmdlet,
                    "performing the search at level " + level.ToString());
                controlHandle =
                    NativeMethods.FindWindowEx(containerHandle, controlHandle, null, null);

                if (controlHandle == IntPtr.Zero) continue;
                controlHandles.Add(controlHandle);
                    
                    
                cmdlet.WriteVerbose(
                    cmdlet,
                    "performing the recursive search at level " + (level + 1).ToString());
                    
                tempControlHandles =
                    GetControlByName(cmdlet, controlHandle, name, level + 1);
                //break;
                if (null == tempControlHandles || 0 == tempControlHandles.Count) continue;
                foreach (IntPtr oneMoreHandle in tempControlHandles) {
                    controlHandles.Add(oneMoreHandle);
                }

                /*
                if (controlHandle != IntPtr.Zero) {
                    
                    controlHandles.Add(controlHandle);
                    
                    
                    cmdlet.WriteVerbose(
                        cmdlet,
                        "performing the recursive search at level " + (level + 1).ToString());
                    
                    tempControlHandles =
                        GetControlByName(cmdlet, controlHandle, name, level + 1);
                    //break;
                    if (null != tempControlHandles && 0 != tempControlHandles.Count) {
                        foreach (IntPtr oneMoreHandle in tempControlHandles) {
                            controlHandles.Add(oneMoreHandle);
                        }
                    }
                }
                */
            } while (controlHandle != IntPtr.Zero);
            
            return controlHandles;
        }
        
        internal static ArrayList GetControlByName(
            GetControlCmdletBase cmdlet,
            // 20131104
            // refactoring
            //AutomationElement container,
            IMySuperWrapper container,
            string controlTitle)
        {

            ArrayList resultCollection = new ArrayList();
            
            cmdlet.WriteVerbose(cmdlet, "checking the container control");

            if (null == container) { return resultCollection; }
            cmdlet.WriteVerbose(cmdlet, "checking the Name parameter");
            
            // 20131108
            //if (string.IsNullOrEmpty(controlTitle) || 0 == controlTitle.Length) { controlTitle = "*"; }
            controlTitle = string.IsNullOrEmpty(controlTitle) ? "*" : controlTitle;

            /*
            if (null == controlTitle || string.Empty == controlTitle || 0 == controlTitle.Length) { controlTitle = "*"; }
            */

            try {
                System.IntPtr containerHandle =
                    new System.IntPtr(container.Current.NativeWindowHandle);
                if (containerHandle == IntPtr.Zero){
                    cmdlet.WriteVerbose(cmdlet, "The container control has no handle");

                    return resultCollection;
                }
                
                ArrayList handlesCollection =
                    new ArrayList();
                handlesCollection =
                    GetControlByName(cmdlet, containerHandle, controlTitle, 1);

                const WildcardOptions options =
                    WildcardOptions.IgnoreCase |
                    WildcardOptions.Compiled;

                /*
                WildcardOptions options;
                options =
                    WildcardOptions.IgnoreCase |
                    WildcardOptions.Compiled;
                */

                WildcardPattern wildcardName =
                    new WildcardPattern(controlTitle,options);
                
                // 20131108
                //if (null == handlesCollection || handlesCollection.Count <= 0) return resultCollection;
                if (null == handlesCollection || 0 == handlesCollection.Count) return resultCollection;
                cmdlet.WriteVerbose(cmdlet, "handles.Count = " + handlesCollection.Count.ToString());
                foreach (System.IntPtr controlHandle in handlesCollection) {
                    try {
                        cmdlet.WriteVerbose(cmdlet, "checking a handle");
                        if (IntPtr.Zero != controlHandle) {
                                
                            cmdlet.WriteVerbose(cmdlet, "the handle is not null");
                            // 20131109
                            //AutomationElement tempElement =
                            //    AutomationElement.FromHandle(controlHandle);
                            IMySuperWrapper tempElement =
                                MySuperWrapper.FromHandle(controlHandle);
                            cmdlet.WriteVerbose(cmdlet, "adding the handle to the collection");
                                
                            cmdlet.WriteVerbose(cmdlet, controlTitle);
                            cmdlet.WriteVerbose(cmdlet, tempElement.Current.Name);

                            if (isMatchWildcardPattern(cmdlet, resultCollection, tempElement, wildcardName, tempElement.Current.Name)) continue;
                            if (isMatchWildcardPattern(cmdlet, resultCollection, tempElement, wildcardName, tempElement.Current.AutomationId)) continue;
                            if (isMatchWildcardPattern(cmdlet, resultCollection, tempElement, wildcardName, tempElement.Current.ClassName)) continue;
                            try {
                                string elementValue =
                                    (tempElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern).Current.Value;
                                if (isMatchWildcardPattern(cmdlet, resultCollection, tempElement, wildcardName, elementValue)) continue;
                            }
                            catch { //(Exception eValuePattern) {
                            }
                            //resultCollection.Add(tempElement);
                        }
                    }
                    catch (Exception eGetAutomationElementFromHandle) {
                        cmdlet.WriteVerbose(cmdlet, eGetAutomationElementFromHandle.Message);
                    }
                }

                /*
                if (null != handlesCollection && handlesCollection.Count > 0) {
                    cmdlet.WriteVerbose(cmdlet, "handles.Count = " + handlesCollection.Count.ToString());
                    foreach (System.IntPtr controlHandle in handlesCollection) {
                        try {
                            cmdlet.WriteVerbose(cmdlet, "checking a handle");
                            if (IntPtr.Zero != controlHandle) {
                                
                                cmdlet.WriteVerbose(cmdlet, "the handle is not null");
                                AutomationElement tempElement =
                                    AutomationElement.FromHandle(controlHandle);
                                cmdlet.WriteVerbose(cmdlet, "adding the handle to the collection");
                                
                                cmdlet.WriteVerbose(cmdlet, controlTitle);
                                cmdlet.WriteVerbose(cmdlet, tempElement.Current.Name);

                                if (isMatchWildcardPattern(cmdlet, resultCollection, tempElement, wildcardName, tempElement.Current.Name)) continue;
                                if (isMatchWildcardPattern(cmdlet, resultCollection, tempElement, wildcardName, tempElement.Current.AutomationId)) continue;
                                if (isMatchWildcardPattern(cmdlet, resultCollection, tempElement, wildcardName, tempElement.Current.ClassName)) continue;
                                try {
                                    string elementValue =
                                        (tempElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern).Current.Value;
                                    if (isMatchWildcardPattern(cmdlet, resultCollection, tempElement, wildcardName, elementValue)) continue;
                                }
                                catch { //(Exception eValuePattern) {
                                }
                                //resultCollection.Add(tempElement);
                            }
                        }
                        catch (Exception eGetAutomationElementFromHandle) {
                            cmdlet.WriteVerbose(cmdlet, eGetAutomationElementFromHandle.Message);
                        }
                    }
                }
                */
                return resultCollection;
            } catch (Exception eWin32Control) {
                cmdlet.WriteVerbose(cmdlet, "UIAHelper.GetControlByName() failed");
                cmdlet.WriteVerbose(cmdlet, eWin32Control.Message);
                return resultCollection;
            }
        }
        
        private static bool isMatchWildcardPattern(
            GetControlCmdletBase cmdlet,
            IList resultCollection,
            // ArrayList resultCollection,
            // 20131109
            //AutomationElement elementInput,
            IMySuperWrapper elementInput,
            WildcardPattern wcPattern,
            string dataToCheck)
        {
            bool result = false;
            
            if (string.IsNullOrEmpty(dataToCheck)) {
                return result;
            }

            /*
            if (null == dataToCheck || string.Empty == dataToCheck) {
                return result;
            }
            */

            if (!wcPattern.IsMatch(dataToCheck)) return result;
            result = true;
            cmdlet.WriteVerbose(cmdlet, "name '" + dataToCheck + "' matches!");
            resultCollection.Add(elementInput);

            // 20131108
            result = true;

            /*
            if (wcPattern.IsMatch(dataToCheck)) {
                result = true;
                cmdlet.WriteVerbose(cmdlet, "name '" + dataToCheck + "' matches!");
                resultCollection.Add(elementInput);
            }
            */

            return result;
        }
        
        // 20131109
        //internal static void Highlight(AutomationElement element) //, Highlighters control)  //(object obj)
        internal static void Highlight(IMySuperWrapper element)
        {
            try { if (highlighter != null) { highlighter.Dispose(); } } catch {}
            try { if (highlighterParent != null) { highlighterParent.Dispose(); } } catch {}
            //try { if (highlighterFirstChild != null) { highlighterFirstChild.Dispose(); } } catch {}
            
            // 20131109
            //if ((element as AutomationElement) != null) {
            if ((element as IMySuperWrapper) != null) {
                
                highlighter =
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
            
            // 20131109
            //AutomationElement parent =
            IMySuperWrapper parent =
                UIAHelper.GetParent(element);
                
            highlighterParent =
                new Highlighter(
                    parent.Current.BoundingRectangle.Height,
                    parent.Current.BoundingRectangle.Width,
                    parent.Current.BoundingRectangle.X,
                    parent.Current.BoundingRectangle.Y,
                    parent.Current.NativeWindowHandle,
                    Highlighters.Parent,
                    Preferences.HighlighterColorParent);

            /*
            if (Preferences.HighlightParent) {
                AutomationElement parent =
                    UIAHelper.GetParent(element);
                
                highlighterParent =
                    new Highlighter(
                        parent.Current.BoundingRectangle.Height,
                        parent.Current.BoundingRectangle.Width,
                        parent.Current.BoundingRectangle.X,
                        parent.Current.BoundingRectangle.Y,
                        parent.Current.NativeWindowHandle,
                        Highlighters.Parent,
                        Preferences.HighlighterColorParent);
            }
            */
        }
        
        // 20131109
        //internal static void HighlightCheckedControl(AutomationElement element) //, Highlighters control)  //(object obj)
        internal static void HighlightCheckedControl(IMySuperWrapper element)
        {
            try { if (highlighterCheckedControl != null) { highlighterCheckedControl.Dispose(); } } catch {}
            
            // 20131109
            //if ((element as AutomationElement) != null) {
            if ((element as IMySuperWrapper) != null) {

                highlighterCheckedControl =
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
                highlighter.Dispose();
                highlighterParent.Dispose();
            }
            catch {}
        }
        
        public static void ShowBanner(string message)
        {
            try { if (null != banner) { banner.Dispose(); } } catch {}
            
            banner =
                new Banner(
                    Preferences.BannerLeft,
                    Preferences.BannerTop,
                    Preferences.BannerWidth,
                    Preferences.BannerHeight,
                    message);
        }
        
        internal static void HideBanner()
        {
            if (null == banner) return;
            try {
                banner.Hide();
            }
            catch {}
            banner.Dispose();

            /*
            if (null != banner) {
                try {
                    banner.Hide();
                }
                catch {}
                banner.Dispose();
            }
            */
        }
        
        public static void AppendBanner(string message)
        {
            if (null != banner) {
                
                banner.AppendMessage(message);
                
            } else {
            
                banner =
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
            if (null != banner) {
                
                banner.Message = string.Empty;
            }
        }
        
        private static string getTimedFileNameForScreenShot()
        {
            string result =
                Preferences.ScreenShotFolder +
                @"\" +
                PSTestLib.PSTestHelper.GetTimedFileName();
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
            System.Drawing.Imaging.ImageFormat format)
        {
            
            //if (null == cmdlet.InputObject || 0 == cmdlet.InputObject.Length) {
            if (null == cmdlet.InputObject || 0 == cmdlet.InputObject.Count()) {
                
                cmdlet.WriteVerbose(cmdlet, "(null == cmdlet.InputObject || 0 == cmdlet.InputObject.Length)");
                
                // 20131109
                //cmdlet.InputObject = new AutomationElement[] { AutomationElement.RootElement };
                cmdlet.InputObject = new MySuperWrapper[] { (MySuperWrapper)MySuperWrapper.RootElement };
            }
            
            cmdlet.WriteVerbose(
                cmdlet,
                //"input array consists of " + cmdlet.InputObject.Length.ToString() + " objects");
                "input array consists of " + cmdlet.InputObject.Count().ToString() + " objects");
            
            // 20131109
            //foreach (AutomationElement inputObject in cmdlet.InputObject) {
            foreach (IMySuperWrapper inputObject in cmdlet.InputObject) {
                
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
            // 20131109
            //AutomationElement element,
            IMySuperWrapper element,
            string description,
            bool save,
            int Left,
            int Top,
            int Height,
            int Width,
            string path,
            System.Drawing.Imaging.ImageFormat format)
        {
            
            cmdlet.WriteVerbose(cmdlet, "hiding highlighter if it's been used");
            
            try {
                
            if (Preferences.HideHighlighterOnScreenShotTaking &&
                ! Preferences.ShowExecutionPlan) {
                
                UIAHelper.HideHighlighters();
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

            //            }
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
                                                 System.Drawing.Imaging.ImageFormat format)
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

                /*
                if (description != null &&
                    description != string.Empty &&
                    description.Length > 0) {
                    
                    description =
                        "_" +
                        description;
                }
                */

                string fileName = string.Empty;
                if (!string.IsNullOrEmpty(path) &&
                    path.Length > 0 &&
                    path != @"\") { // && ! System.IO.File.Exists(path)) {
                    
                    if (System.IO.File.Exists(path)) {
                        
                        cmdlet.WriteError(
                            cmdlet,
                            "File '" +
                            path +
                            "' already exists",
                            "FileAlreadyExists",
                            ErrorCategory.InvalidArgument,
                            true);
                    }
                    
                    //                        if (System.IO.File.Open(
                    fileName = path;
                } else {
                    
                    if (cmdlet is Commands.SaveUIAScreenshotCommand) {
                        
                        fileName =
                            getTimedFileNameForScreenShot() +
                            description +
                            getFileExtensionByImageType(format);
                        
                    } else {  // ??
                        
                        fileName =
                            getTimedFileNameForScreenShot() +
                            description +
                            getFileExtensionByImageType(format);
                        
                    }
                }

                /*
                if (path != null && path != string.Empty &&
                    path.Length > 0 &&
                    path != @"\") { // && ! System.IO.File.Exists(path)) {
                    
                    if (System.IO.File.Exists(path)) {
                        
                        cmdlet.WriteError(
                            cmdlet,
                            "File '" +
                            path +
                            "' already exists",
                            "FileAlreadyExists",
                            ErrorCategory.InvalidArgument,
                            true);
                    }
                    
                    //                        if (System.IO.File.Open(
                    fileName = path;
                } else {
                    
                    if (cmdlet is Commands.SaveUIAScreenshotCommand) {
                        
                        fileName =
                            getTimedFileNameForScreenShot() +
                            description +
                            getFileExtensionByImageType(format);
                        
                    } else {  // ??
                        
                        fileName =
                            getTimedFileNameForScreenShot() +
                            description +
                            getFileExtensionByImageType(format);
                        
                    }
                }
                */

                myImage.Save(fileName, format);
                
                TMX.TMXHelper.AddTestResultScreenshotDetail(fileName);
            } else {
                
                cmdlet.WriteObject(cmdlet, myImage);
            }
            //  //  //
            // ReleaseDC(desktopHandle, dc2);  //// ??
            //  // 
            
            //} // 20120823
            
            
        }  //// ??
        
        private static string getFileExtensionByImageType(System.Drawing.Imaging.ImageFormat format)
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
        
        #region Start-UIATranscript
        
        private static string errorMessageInTheGatheringCycle = String.Empty;
        private static bool errorInTheGatheringCycle = false;
        private static string errorMessageInTheInnerCycle = String.Empty;
        private static bool errorInTheInnerCycle = false;
        
        /// <summary>
        ///
        /// </summary>
        /// <param name="cmdlet"></param>
        internal static void ProcessingTranscript(TranscriptCmdletBase cmdlet)
        {
            Global.GTranscript = true;
            int counter = 0;
            
            cmdlet.oddRootElement =
                // 20131109
                //System.Windows.Automation.AutomationElement.RootElement;
                MySuperWrapper.RootElement;

            cmdlet.StartDate =
                System.DateTime.Now;
            do
            {
                // 20131108
                // refactoring
                // experimental
                counter++;
                bool res = ProcessingTranscriptOnce(cmdlet, counter);
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
            int counter)
        {
            // 20130318
            //cmdlet.RunOnSleepScriptBlocks(cmdlet);
            cmdlet.RunOnSleepScriptBlocks(cmdlet, null);
            System.Threading.Thread.Sleep(Preferences.TranscriptInterval);
            while (cmdlet.Paused) {
                System.Threading.Thread.Sleep(Preferences.TranscriptInterval);
            }
            counter++;
            
            try {
                // use Windows forms mouse code instead of WPF
                System.Drawing.Point mouse = System.Windows.Forms.Cursor.Position;
                // 20131109
                //System.Windows.Automation.AutomationElement element =
                //    System.Windows.Automation.AutomationElement.FromPoint(
                //        new System.Windows.Point(mouse.X, mouse.Y));
                IMySuperWrapper element =
                    MySuperWrapper.FromPoint(
                        new System.Windows.Point(mouse.X, mouse.Y));
                if (element != null && (int)element.Current.ProcessId > 0)
                {
                    ProcessingElement(cmdlet, element);
                }
                if (errorInTheGatheringCycle) {
                    cmdlet.WriteDebug(cmdlet, "An error is in the control hierarchy gathering cycle");
                    cmdlet.WriteDebug(cmdlet, errorMessageInTheGatheringCycle);
                    errorInTheGatheringCycle = false;
                }
            } catch (Exception eUnknown) {
                cmdlet.WriteDebug(cmdlet, eUnknown.Message);
            }
            System.DateTime nowDate = System.DateTime.Now;
            return !((nowDate - cmdlet.StartDate).TotalSeconds > cmdlet.Timeout / 1000);

            /*
            if ((nowDate - cmdlet.StartDate).TotalSeconds > cmdlet.Timeout / 1000) return false; // break;
            return true;
            */
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
            // 20131109
            //AutomationElement element)
            IMySuperWrapper element)
            // 20120618 UIACOMWrapper
            //UIACOM::System.Windows.Automation.AutomationElement element)
        {
            bool result = false;
            // UIAHelper.Highlight(element);
            try {
                CacheRequest cacheRequest = new CacheRequest();
                //cacheRequest.AutomationElementMode = AutomationElementMode.None;
                cacheRequest.AutomationElementMode = AutomationElementMode.Full;
                cacheRequest.TreeFilter = Automation.RawViewCondition;
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
                        getElementControlTypeString(element);
                    if (string.IsNullOrEmpty(elementControlType)) {
                        return result;
                    }

                    /*
                    if (null == elementControlType || string.Empty == elementControlType) {
                        return result;
                    }
                    */

                    string elementVerbosity = String.Empty; // ?

                    elementVerbosity =
                        "Get-UIA" + elementControlType;
                    
                    // collecting the element's properties for parameters
                    bool hasName = false;
                    elementVerbosity +=
                        getElementPropertyString(cmdlet, element, "AutomationId", null, ref hasName);
                    if (!cmdlet.NoClassInformation) {
                        elementVerbosity +=
                            getElementPropertyString(cmdlet, element, "Class", null, ref hasName);
                    }
                    elementVerbosity +=
                        getElementPropertyString(cmdlet, element, "Name", null, ref hasName);
                    try {
                        ValuePattern pattern =
                            element.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                        elementVerbosity +=
                            getElementPropertyString(cmdlet, element, "Value", pattern, ref hasName);
                    }
                    catch {}
                    if (hasName) {
                        elementVerbosity +=
                            getElementPropertyString(cmdlet, element, "Win32", null, ref hasName);
                    }
                    cmdlet.WriteVerbose(cmdlet,
                                        "the concatenated result is: " +
                                        elementVerbosity);
                    // collected
                    
                    if (cmdlet.LastRecordedItem.Count == 0 || elementVerbosity != cmdlet.LastRecordedItem[0].ToString()) {
                        
                        if (!cmdlet.NoEvents) {
                            cmdlet.WriteVerbose(cmdlet, "unsubscribe events");
                            unsubscribeFromEventsDuringRecording(cmdlet); // thePreviouslyUsedElement);
                            cmdlet.WriteVerbose(cmdlet, "events were unsubscribed");
                        }
                        
                        try{
                            UIAHelper.Highlight(element);
                        }
                        catch {
                        }
                        
                        cmdlet.LastRecordedItem = new System.Collections.ArrayList();
                        string strElementPatterns = String.Empty;
                        
                        // if (WriteCurrentPattern) {
                        // strElementPatterns = String.Empty;
                        try {
                            System.Windows.Automation.AutomationPattern[] elementPatterns =
                                element.GetSupportedPatterns();
                            
                            if (!cmdlet.NoEvents) {
                                subscribeToEventsDuringRecording(cmdlet, element, elementPatterns);
                            }
                            
                            if (cmdlet.WriteCurrentPattern) {
                                foreach (System.Windows.Automation.AutomationPattern ptrn in elementPatterns)
                                {
                                    strElementPatterns += "\r\n\t\t#";
                                    strElementPatterns +=
                                        ptrn.ProgrammaticName.Replace("Identifiers.Pattern", "");
                                    strElementPatterns += ": use the ";
                                    
                                    string tempControlNameForCmdlet =
                                        "-UIA" +
                                        elementControlType;
                                    
                                    switch (ptrn.ProgrammaticName.Replace("Identifiers.Pattern", "")) {
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
                        } catch { //(Exception ePatterns) {
                            //                                    Exception ePatterns2 =
                            //                                        new Exception("Patterns:\r\n" +
                            //                                                      ePatterns.Message);
                            //throw(ePatterns2);
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
                            collectAncestors(cmdlet, element);
                        }
                        catch { //(Exception eCollecingAncestors) {
                            //                                Exception eCollecingAncestors2 =
                            //                                    new Exception("Collecting ancestors:\r\n" +
                            //                                                  eCollecingAncestors.Message);
                            //throw(eCollecingAncestors2);
                            //return result;
                        }

                        if (!errorInTheInnerCycle) {
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
                    errorInTheGatheringCycle = true;
                    errorMessageInTheGatheringCycle =
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

        /// <summary>
        /// Retrieves such element's properties as AutomationId, Name, Class(Name) and Value
        /// </summary>
        /// <param name="cmdlet">cmdlet to report</param>
        /// <param name="element">The element properties taken from</param>
        /// <param name="propertyName">The name of property</param>
        /// <param name="pattern">an object of the ValuePattern type</param>
        /// <param name="hasName">an object has Name</param>
        /// <returns></returns>
        // 20131109
        //private static string getElementPropertyString(TranscriptCmdletBase cmdlet, AutomationElement element, string propertyName, ValuePattern pattern, ref bool hasName)
        private static string getElementPropertyString(
            TranscriptCmdletBase cmdlet,
            IMySuperWrapper element,
            string propertyName,
            ValuePattern pattern,
            ref bool hasName)
        {
            cmdlet.WriteVerbose(cmdlet, "getting " + propertyName);
            string tempString = string.Empty;
            try {
                
                switch (propertyName) {
                    case "Name":
                        if (0 < element.Current.Name.Length) {
                            tempString = element.Current.Name;
                            hasName = true;
                        }
                        break;
                    case "AutomationId":
                        if (0 < element.Current.AutomationId.Length) {
                            tempString = element.Current.AutomationId;
                        }
                        break;
                    case "Class":
                        if (0 < element.Current.ClassName.Length) {
                            tempString = element.Current.ClassName;
                        }
                        break;
                    case "Value":
                        if (!string.IsNullOrEmpty(pattern.Current.Value)) {
                            tempString = pattern.Current.Value;
                            hasName = true;
                        }

                        /*
                        if (null != pattern.Current.Value && string.Empty != pattern.Current.Value) {
                            tempString = pattern.Current.Value;
                            hasName = true;
                        }
                        */
                        break;
                    case "Win32":
                        if (0 < element.Current.NativeWindowHandle) {
                            tempString = ".";
                        }
                        break;
                    default:
                        
                    	break;
                }
            } catch {
                switch (propertyName) {
                    case "Name":
                        if (0 < element.Cached.Name.Length) {
                            tempString = element.Cached.Name;
                            hasName = true;
                        }
                        break;
                    case "AutomationId":
                        if (0 < element.Cached.AutomationId.Length) {
                            tempString = element.Cached.AutomationId;
                        }
                        break;
                    case "Class":
                        if (0 < element.Cached.ClassName.Length) {
                            tempString = element.Cached.ClassName;
                        }
                        break;
                    case "Value":
                        if (!string.IsNullOrEmpty(pattern.Cached.Value)) {
                            tempString = pattern.Cached.Value;
                            hasName = true;
                        }

                        /*
                        if (null != pattern.Cached.Value && string.Empty != pattern.Cached.Value) {
                            tempString = pattern.Cached.Value;
                            hasName = true;
                        }
                        */
                        break;
                    case "Win32":
                        if (0 < element.Cached.NativeWindowHandle) {
                            tempString = ".";
                        }
                        break;
                    default:
                        
                    	break;
                }
            }
            if (string.IsNullOrEmpty(tempString)) {
                return string.Empty;
            } else {
                if ("Win32" == propertyName) {
                    tempString =
                        " -" + propertyName;
                } else {
                    tempString =
                        " -" + propertyName + " '" + tempString + "'";
                }
                return tempString;
            }

            /*
            if (null == tempString || string.Empty == tempString) {
                return string.Empty;
            } else {
                if ("Win32" == propertyName) {
                    tempString =
                        " -" + propertyName;
                } else {
                    tempString =
                        " -" + propertyName + " '" + tempString + "'";
                }
                return tempString;
            }
            */
        }

        /// <summary>
        /// Retrievs an element's ControlType property as a string.
        /// </summary>
        /// <param name="element">AutomationElement</param>
        /// <returns>string</returns>
        // 20131109
        //private static string getElementControlTypeString(AutomationElement element)
        private static string getElementControlTypeString(IMySuperWrapper element)
        {
            string elementControlType = String.Empty;
            try {
                elementControlType = element.Current.ControlType.ProgrammaticName;
            } catch {
                elementControlType = element.Cached.ControlType.ProgrammaticName;
            }
            if (string.Empty != elementControlType && 0 < elementControlType.Length) {
                elementControlType = elementControlType.Substring(elementControlType.IndexOf('.') + 1);
            }
            //string elementVerbosity = String.Empty;
            //if (string.Empty == elementControlType || 0 == elementControlType.Length) {
            //    return result;
            //}
            return elementControlType;
        }
        #endregion working with an element
        
        #region collect ancestors
        // 20131109
        //internal static AutomationElement GetParent(AutomationElement element)
        internal static IMySuperWrapper GetParent(IMySuperWrapper element)
        {
            // 20131109
            //AutomationElement result = null;
            IMySuperWrapper result = null;
            
            System.Windows.Automation.TreeWalker walker =
                new System.Windows.Automation.TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            try {
                // 20131109
                //result = walker.GetParent(element);
                result = new MySuperWrapper(walker.GetParent(element.SourceElement));
            }
            catch {}
            
            return result;
        }
        
        // 20131109
        //internal static AutomationElement GetFirstChild(AutomationElement element)
        internal static IMySuperWrapper GetFirstChild(IMySuperWrapper element)
        {
            // 20131109
            //AutomationElement result = null;
            IMySuperWrapper result = null;
            
            System.Windows.Automation.TreeWalker walker =
                new System.Windows.Automation.TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            try {
                // 20131109
                //result = walker.GetFirstChild(element);
                result = new MySuperWrapper(walker.GetFirstChild(element.SourceElement));
            }
            catch {}
            
            return result;
        }
        
        /// <summary>
        ///
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="element"></param>
        // 20131109
        //private static void collectAncestors(TranscriptCmdletBase cmdlet, AutomationElement element)
        private static void collectAncestors(TranscriptCmdletBase cmdlet, IMySuperWrapper element)
        {
            System.Windows.Automation.TreeWalker walker =
                new System.Windows.Automation.TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            // 20131109
            //System.Windows.Automation.AutomationElement testparent;
            IMySuperWrapper testParent;
            
            try {
                
                // commented out 201206210
                //testparent =
                //    walker.GetParent(element);
                testParent = element;
                
                while (testParent != null && (int)testParent.Current.ProcessId > 0) {
                    
                    testParent =
                        // 20131109
                        //walker.GetParent(testParent);
                        new MySuperWrapper(walker.GetParent(testParent.SourceElement));
                    
                    if (testParent == null || (int) testParent.Current.ProcessId <= 0) continue;
                    if (testParent == cmdlet.oddRootElement)
                    { testParent = null; }
                    else{
                        string parentControlType =
                            // getControlTypeNameOfAutomationElement(testparent, element);
                            // testparent.Current.ControlType.ProgrammaticName.Substring(
                            // element.Current.ControlType.ProgrammaticName.IndexOf('.') + 1);
                            //  // experimental
                            testParent.Current.ControlType.ProgrammaticName.Substring(
                                testParent.Current.ControlType.ProgrammaticName.IndexOf('.') + 1);
                        //  // if (parentControlType.Length == 0) {
                        // break;
                        //}
                            
                        // in case this element is an upper-level Pane
                        // residing directrly under the RootElement
                        // change type to window
                        // i.e. Get-UIAPane - >  Get-UIAWindow
                        // since Get-UIAPane is unable to get something more than
                        // a window's child pane control
                        if (parentControlType == "Pane" || parentControlType == "Menu") {
                            
                            // 20131109
                            //if (walker.GetParent(testParent) == cmdlet.rootElement) {
                            if ((new MySuperWrapper(walker.GetParent(testParent.SourceElement))) == cmdlet.oddRootElement) {
                                parentControlType = "Window";
                            }
                        }
                            
                        string parentVerbosity =
                            @"Get-UIA" + parentControlType;
                        try {
                            if (testParent.Current.AutomationId.Length > 0) {
                                parentVerbosity += (" -AutomationId '" + testParent.Current.AutomationId + "'");
                            }
                        }
                        catch {
                        }
                        if (!cmdlet.NoClassInformation) {
                            try {
                                if (testParent.Current.ClassName.Length > 0) {
                                    parentVerbosity += (" -Class '" + testParent.Current.ClassName + "'");
                                }
                            }
                            catch {
                            }
                        }
                        try {
                            if (testParent.Current.Name.Length > 0) {
                                parentVerbosity += (" -Name '" + testParent.Current.Name + "'");
                            }
                        }
                        catch {
                        }

                        if (cmdlet.LastRecordedItem[cmdlet.LastRecordedItem.Count - 1].ToString() != parentVerbosity) {
                            cmdlet.LastRecordedItem.Add(parentVerbosity);
                            cmdlet.WriteVerbose(parentVerbosity);
                        }
                    }

                    /*
                    if (testparent != null && (int)testparent.Current.ProcessId > 0) {
                        if (testparent == cmdlet.rootElement)
                        { testparent = null; }
                        else{
                            string parentControlType =
                                // getControlTypeNameOfAutomationElement(testparent, element);
                                // testparent.Current.ControlType.ProgrammaticName.Substring(
                                // element.Current.ControlType.ProgrammaticName.IndexOf('.') + 1);
                                //  // experimental
                                testparent.Current.ControlType.ProgrammaticName.Substring(
                                    testparent.Current.ControlType.ProgrammaticName.IndexOf('.') + 1);
                            //  // if (parentControlType.Length == 0) {
                            // break;
                            //}
                            
                            // in case this element is an upper-level Pane
                            // residing directrly under the RootElement
                            // change type to window
                            // i.e. Get-UIAPane - >  Get-UIAWindow
                            // since Get-UIAPane is unable to get something more than
                            // a window's child pane control
                            if (parentControlType == "Pane" || parentControlType == "Menu") {
                                if (walker.GetParent(testparent) == cmdlet.rootElement) {
                                    parentControlType = "Window";
                                }
                            }
                            
                            string parentVerbosity =
                                @"Get-UIA" + parentControlType;
                            try {
                                if (testparent.Current.AutomationId.Length > 0) {
                                    parentVerbosity += (" -AutomationId '" + testparent.Current.AutomationId + "'");
                                }
                            }
                            catch {
                            }
                            if (!cmdlet.NoClassInformation) {
                                try {
                                    if (testparent.Current.ClassName.Length > 0) {
                                        parentVerbosity += (" -Class '" + testparent.Current.ClassName + "'");
                                    }
                                }
                                catch {
                                }
                            }
                            try {
                                if (testparent.Current.Name.Length > 0) {
                                    parentVerbosity += (" -Name '" + testparent.Current.Name + "'");
                                }
                            }
                            catch {
                            }

                            if (cmdlet.LastRecordedItem[cmdlet.LastRecordedItem.Count - 1].ToString() != parentVerbosity) {
                                cmdlet.LastRecordedItem.Add(parentVerbosity);
                                cmdlet.WriteVerbose(parentVerbosity);
                            }
                        }
                    }
                    */
                }
            } catch (Exception eErrorInTheInnerCycle) {
                cmdlet.WriteDebug(cmdlet, eErrorInTheInnerCycle.Message);
                errorMessageInTheInnerCycle =
                    eErrorInTheInnerCycle.Message;
                errorInTheInnerCycle = true;
            }
        }
        
        // 20131109
        //public static void CollectAncestors(TranscriptCmdletBase cmdlet, AutomationElement element)
        public static void CollectAncestors(TranscriptCmdletBase cmdlet, IMySuperWrapper element)
        {
            collectAncestors(cmdlet, element);
        }
        #endregion collect ancestors
        
        
        #region Subscribe to events during the recording session
        /// <summary>
        ///
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="element"></param>
        /// <param name="supportedPatterns"></param>
        internal static void subscribeToEventsDuringRecording(HasControlInputCmdletBase cmdlet,
                                                              // 20131109
                                                              //AutomationElement element,
                                                              IMySuperWrapper element,
                                                              AutomationPattern[] supportedPatterns)
        {
            try { // experimental
                
                if (element == null) { return; }
                if (supportedPatterns == null ||
                    supportedPatterns.Length < 1) { return; }
                try {
                    
                    // cache requiest object for collecting properties
                    CacheRequest cacheRequest = null;
                    
                    try {
                        cacheRequest = new CacheRequest();
                        cacheRequest.AutomationElementMode = AutomationElementMode.None;
                        cacheRequest.TreeFilter = Automation.RawViewCondition;
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
                    
                    foreach (AutomationPattern pattern in supportedPatterns) {
                        try {
                            if (element == null) { break; }
                            cmdlet.AutomationEventHandler =
                                cmdlet.OnUIRecordingAutomationEvent;
                            switch (pattern.ProgrammaticName) {
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
                                                pattern.ProgrammaticName +
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
        private static void unsubscribeFromEventsDuringRecording(TranscriptCmdletBase cmdlet)
        {
            try
            {
                if (cmdlet.subscribedEvents == null || cmdlet.subscribedEvents.Count <= 0 ||
                    cmdlet.thePreviouslyUsedElement == null) return;
                for (int i = 0; i < cmdlet.subscribedEvents.Count; i++) {
                    Automation.RemoveAutomationEventHandler(
                        (AutomationEvent)cmdlet.subscribedEventsIds[i],
                        // 20131109
                        //cmdlet.thePreviouslyUsedElement,
                        cmdlet.thePreviouslyUsedElement.SourceElement,
                        (AutomationEventHandler)cmdlet.subscribedEvents[i]);
                }

                /*
                if (cmdlet.subscribedEvents != null &&
                    cmdlet.subscribedEvents.Count > 0 &&
                    cmdlet.thePreviouslyUsedElement != null) {
                    for (int i = 0; i < cmdlet.subscribedEvents.Count; i++) {
                        Automation.RemoveAutomationEventHandler(
                            (AutomationEvent)cmdlet.subscribedEventsIds[i],
                            cmdlet.thePreviouslyUsedElement,
                            (AutomationEventHandler)cmdlet.subscribedEvents[i]);
                    }
                }
                */
            }
            catch (Exception eUnknown) {
                cmdlet.WriteDebug(cmdlet, eUnknown.Message);
                return;
            }
        }
        #endregion Unsubscribe from events during the recording session
        
        #endregion Start-UIATranscript
        
        /// <summary>
        ///  /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="handle"></param>
        /// <returns></returns>
        // 20121011
        //internal static AutomationElement GetAutomationElementFromHandle(
        //public static AutomationElement GetAutomationElementFromHandle(
        // 20131109
        public static IMySuperWrapper GetAutomationElementFromHandle(
            // 20130513
            //DiscoveryCmdletBase cmdlet,
            PSCmdletBase cmdlet,
            int handle)
        {
            // 20131109
            //System.Windows.Automation.AutomationElement result =
            //    null;
            IMySuperWrapper result = null;
            
            if (handle == 0) {
                cmdlet.WriteVerbose(cmdlet, "handle == 0");
                return result;
            }
            try {
                //System.IntPtr pHwnd = IntPtr.Zero;
                System.IntPtr pHwnd = new IntPtr(handle);
                cmdlet.WriteVerbose(cmdlet, "getting the control");
                // 20131109
                //element =
                //    AutomationElement.FromHandle(pHwnd);
                element =
                    new MySuperWrapper(AutomationElement.FromHandle(pHwnd));
                if (element != null) {
                    cmdlet.WriteVerbose(cmdlet, element.Current.Name);
                }
                result = element;
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
        // 20131109
        //public static System.Windows.Automation.AutomationElement GetAutomationElementFromPoint()
        public static IMySuperWrapper GetAutomationElementFromPoint()
        {
            // 20131109
            //System.Windows.Automation.AutomationElement result =
            //    null;
            IMySuperWrapper result = null;
            
            try {
                element =
                    // 20131109
                    //AutomationElement.FromPoint(new System.Windows.Point(
                    //    Cursor.Position.X,
                    //    Cursor.Position.Y));
                    MySuperWrapper.FromPoint(
                        new System.Windows.Point(
                            Cursor.Position.X,
                            Cursor.Position.Y));
                result = element;
            }
            catch { }
            return result;
        }
        
        /// <summary>
        ///  /// </summary>
        /// <returns></returns>
        internal static System.Windows.Automation.AutomationPattern[] GetElementPatternsFromPoint()
        {
            System.Windows.Automation.AutomationPattern[] result = null;
            GetAutomationElementFromPoint();
            result = element.GetSupportedPatterns();
            return result;
        }
        
        #region get the parent or an ancestor
        /// <summary>
        ///  /// </summary>
        /// <param name="element"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        // 20131109
        //internal static AutomationElement[] GetParentOrAncestor(AutomationElement element, TreeScope scope)
        internal static IMySuperWrapper[] GetParentOrAncestor(IMySuperWrapper element, TreeScope scope)
        {
            System.Windows.Automation.TreeWalker walker =
                new System.Windows.Automation.TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            // 20131109
            //System.Windows.Automation.AutomationElement testparent;
            IMySuperWrapper testParent;
            // 20131109
            //System.Collections.Generic.List<AutomationElement> ancestors =
            //    new System.Collections.Generic.List<AutomationElement>();
            System.Collections.Generic.List<IMySuperWrapper> ancestors =
                new System.Collections.Generic.List<IMySuperWrapper>();
            
            try {
                
                // 20131109
                testParent =
                    //walker.GetParent(element);
                    new MySuperWrapper(walker.GetParent(element.SourceElement));
                    
                if (scope == TreeScope.Parent || scope == TreeScope.Ancestors) {
                    
                    // 20131109
                    //if (testparent != AutomationElement.RootElement) {
                    if (testParent != MySuperWrapper.RootElement) {
                        ancestors.Add(testParent);
                    }
                    
                    // 20131109
                    //if (testparent == AutomationElement.RootElement ||
                    if (testParent == MySuperWrapper.RootElement ||
                        scope == TreeScope.Parent) {
                        return ancestors.ToArray();
                    }
                }
                while (testParent != null &&
                       (int)testParent.Current.ProcessId > 0 &&
                       // 20131109
                       //testparent != AutomationElement.RootElement) {
                       testParent != MySuperWrapper.RootElement) {
                    
                    testParent =
                        // 20131109
                        //walker.GetParent(testParent);
                        new MySuperWrapper(walker.GetParent(testParent.SourceElement));
                    if (testParent != null &&
                        (int)testParent.Current.ProcessId > 0 &&
                        // 20131109
                        //testparent != AutomationElement.RootElement) {
                        testParent != MySuperWrapper.RootElement) {
                        ancestors.Add(testParent);
                    }
                }
                return ancestors.ToArray();
            } catch {
                return ancestors.ToArray();
            }
        }
        #endregion get the parent or an ancestor
        
        #region get an ancestor with a handle
        /// <summary>
        ///  /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        // 20131109
        //internal static AutomationElement GetAncestorWithHandle(AutomationElement element)
        internal static IMySuperWrapper GetAncestorWithHandle(IMySuperWrapper element)
        {
            System.Windows.Automation.TreeWalker walker =
                new System.Windows.Automation.TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            // 20131109
            //System.Windows.Automation.AutomationElement testparent;
            IMySuperWrapper testparent;
            
            try {
                
                testparent =
                    // 20131109
                    //walker.GetParent(element);
                    new MySuperWrapper(walker.GetParent(element.SourceElement));
                while (testparent != null &&
                       testparent.Current.NativeWindowHandle == 0) {
                    testparent =
                        // 20131109
                        //walker.GetParent(testparent);
                        new MySuperWrapper(walker.GetParent(testparent.SourceElement));
                    if (testparent != null &&
                        (int)testparent.Current.ProcessId > 0 &&
                        testparent.Current.NativeWindowHandle != 0) {
                        return testparent;
                    }
                }
                return testparent.Current.NativeWindowHandle != 0 ? testparent : null;

                /*
                if (testparent.Current.NativeWindowHandle != 0) {
                    return testparent;
                } else {
                    return null;
                }
                */
            } catch {
                return null;
            }
        }
        #endregion get an ancestor with a handle
        
        /// <summary>
        ///  /// </summary>
        /// <returns></returns>
        internal static object GetCurrentPatternFromPoint()
        {
            object result = null;
            GetAutomationElementFromPoint();
            result =
                GetCurrentPattern(ref element,
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
        internal static System.Windows.Automation.AutomationPattern GetPatternByName(string patternName)
        {
            System.Windows.Automation.AutomationPattern result = null;
            // normalize name
            patternName =
                patternName.Substring(0, patternName.Length - 7) +
                "Pattern";
            patternName.Replace("dock", "Dock");
            switch (patternName) {
                case "DockPattern":
                    result = System.Windows.Automation.DockPattern.Pattern;
                    break;
                case "ExpandCollapsePattern":
                    result = System.Windows.Automation.ExpandCollapsePattern.Pattern;
                    break;
                case "GridItemPattern":
                    result = System.Windows.Automation.GridItemPattern.Pattern;
                    break;
                case "GridPattern":
                    result = System.Windows.Automation.GridPattern.Pattern;
                    break;
                case "InvokePattern":
                    result = System.Windows.Automation.InvokePattern.Pattern;
                    break;
                case "MultipleViewPattern":
                    result = System.Windows.Automation.MultipleViewPattern.Pattern;
                    break;
                case "RangeValuePattern":
                    result = System.Windows.Automation.RangeValuePattern.Pattern;
                    break;
                case "ScrollItemPattern":
                    result = System.Windows.Automation.ScrollItemPattern.Pattern;
                    break;
                case "ScrollPattern":
                    result = System.Windows.Automation.ScrollPattern.Pattern;
                    break;
                case "SelectionItemPattern":
                    result = System.Windows.Automation.SelectionItemPattern.Pattern;
                    break;
                case "SelectionPattern":
                    result = System.Windows.Automation.SelectionPattern.Pattern;
                    break;
                case "TableItemPattern":
                    result = System.Windows.Automation.TableItemPattern.Pattern;
                    break;
                case "TablePattern":
                    result = System.Windows.Automation.TablePattern.Pattern;
                    break;
                case "TextPattern":
                    result = System.Windows.Automation.TextPattern.Pattern;
                    break;
                case "TogglePattern":
                    result = System.Windows.Automation.TogglePattern.Pattern;
                    break;
                case "TransformPattern":
                    result = System.Windows.Automation.TransformPattern.Pattern;
                    break;
                case "ValuePattern":
                    result = System.Windows.Automation.ValuePattern.Pattern;
                    break;
                case "WindowPattern":
                    result = System.Windows.Automation.WindowPattern.Pattern;
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
            // 20131109
            //ref System.Windows.Automation.AutomationElement element,
            ref IMySuperWrapper element,
            System.Windows.Automation.AutomationPattern patternType)
        {
            object result =
                null;
            try {
                System.Windows.Automation.AutomationPattern[] supportedPatterns =
                    element.GetSupportedPatterns();
                if (supportedPatterns == null ||
                    supportedPatterns.Length < 1)
                {
                    return result;
                }
                object pattern = null;
                foreach (AutomationPattern ptrn in supportedPatterns.Where(ptrn => patternType.ProgrammaticName == ptrn.ProgrammaticName ||
                                                                                   patternType == null))
                {
                    if (!element.TryGetCurrentPattern(
                        ptrn, out pattern)) continue;
                    object resPattern =
                        element.GetCurrentPattern(ptrn);
                    // as System.Windows.Automation.AutomationPattern;
                    result = resPattern;
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
        public static System.Windows.Automation.ControlType
            GetControlTypeByTypeName(string controlType)
        {
            System.Windows.Automation.ControlType ctrlType = null;
            string _controlType = controlType.ToUpper();
            switch (_controlType)
            {
                    case "BUTTON": { ctrlType = System.Windows.Automation.ControlType.Button; break; }
                    case "CALENDAR": { ctrlType = System.Windows.Automation.ControlType.Calendar; break; }
                    case "CHECKBOX": { ctrlType = System.Windows.Automation.ControlType.CheckBox; break; }
                    case "COMBOBOX": { ctrlType = System.Windows.Automation.ControlType.ComboBox; break; }
                    case "CUSTOM": { ctrlType = System.Windows.Automation.ControlType.Custom; break; }
                    case "DATAGRID": { ctrlType = System.Windows.Automation.ControlType.DataGrid; break; }
                    case "DATAITEM": { ctrlType = System.Windows.Automation.ControlType.DataItem; break; }
                    case "DOCUMENT": { ctrlType = System.Windows.Automation.ControlType.Document; break; }
                    case "EDIT": { ctrlType = System.Windows.Automation.ControlType.Edit; break; }
                    case "GROUP": { ctrlType = System.Windows.Automation.ControlType.Group; break; }
                    case "HEADER": { ctrlType = System.Windows.Automation.ControlType.Header; break; }
                    case "HEADERITEM": { ctrlType = System.Windows.Automation.ControlType.HeaderItem; break; }
                    case "HYPERLINK": { ctrlType = System.Windows.Automation.ControlType.Hyperlink; break; }
                    case "IMAGE": { ctrlType = System.Windows.Automation.ControlType.Image; break; }
                    case "LIST": { ctrlType = System.Windows.Automation.ControlType.List; break; }
                    case "LISTITEM": { ctrlType = System.Windows.Automation.ControlType.ListItem; break; }
                    case "MENU": { ctrlType = System.Windows.Automation.ControlType.Menu; break; }
                    case "MENUBAR": { ctrlType = System.Windows.Automation.ControlType.MenuBar; break; }
                    case "MENUITEM": { ctrlType = System.Windows.Automation.ControlType.MenuItem; break; }
                    case "PANE": { ctrlType = System.Windows.Automation.ControlType.Pane; break; }
                    case "PROGRESSBAR": { ctrlType = System.Windows.Automation.ControlType.ProgressBar; break; }
                    case "RADIOBUTTON": { ctrlType = System.Windows.Automation.ControlType.RadioButton; break; }
                    case "SCROLLBAR": { ctrlType = System.Windows.Automation.ControlType.ScrollBar; break; }
                    case "SEPARATOR": { ctrlType = System.Windows.Automation.ControlType.Separator; break; }
                    case "SLIDER": { ctrlType = System.Windows.Automation.ControlType.Slider; break; }
                    case "SPINNER": { ctrlType = System.Windows.Automation.ControlType.Spinner; break; }
                    case "SPLITBUTTON": { ctrlType = System.Windows.Automation.ControlType.SplitButton; break; }
                    case "STATUSBAR": { ctrlType = System.Windows.Automation.ControlType.StatusBar; break; }
                    case "TAB": { ctrlType = System.Windows.Automation.ControlType.Tab; break; }
                    case "TABITEM": { ctrlType = System.Windows.Automation.ControlType.TabItem; break; }
                    case "TABLE": { ctrlType = System.Windows.Automation.ControlType.Table; break; }
                    case "TEXT": { ctrlType = System.Windows.Automation.ControlType.Text; break; }
                    case "THUMB": { ctrlType = System.Windows.Automation.ControlType.Thumb; break; }
                    case "TITLEBAR": { ctrlType = System.Windows.Automation.ControlType.TitleBar; break; }
                    case "TOOLBAR": { ctrlType = System.Windows.Automation.ControlType.ToolBar; break; }
                    case "TOOLTIP": { ctrlType = System.Windows.Automation.ControlType.ToolTip; break; }
                    case "TREE": { ctrlType = System.Windows.Automation.ControlType.Tree; break; }
                    case "TREEITEM": { ctrlType = System.Windows.Automation.ControlType.TreeItem; break; }
                    case "WINDOW": { ctrlType = System.Windows.Automation.ControlType.Window; break; }
                default:
                    // WriteVerbose(this, "there's no ControlType value.");
                    ctrlType = null;
                    break;
            }
            return ctrlType;
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
            ref IMySuperWrapper element,
            out string strResultString,
            char delimiter)
        {
            // 20131109
            //System.Windows.Automation.AutomationElementCollection headerItems =
            IMySuperCollection headerItems =
                element.FindAll(
                    System.Windows.Automation.TreeScope.Descendants,
                    new System.Windows.Automation.PropertyCondition(
                        System.Windows.Automation.AutomationElement.ControlTypeProperty,
                        System.Windows.Automation.ControlType.HeaderItem));
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
                foreach (IMySuperWrapper headerItem in headerItems) {
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
            // 20131109
            //ref System.Windows.Automation.AutomationElement element,
            ref IMySuperWrapper element,
            out string strResultString,
            char delimiter)
        {
            // 20131109
            //System.Windows.Automation.AutomationElementCollection headerItems =
            IMySuperCollection headerItems =
                element.FindAll(
                    System.Windows.Automation.TreeScope.Descendants,
                    new System.Windows.Automation.PropertyCondition(
                        System.Windows.Automation.AutomationElement.ControlTypeProperty,
                        System.Windows.Automation.ControlType.Header));
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
                foreach (IMySuperWrapper headerItem in headerItems) {
                    
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
        internal static string GetOutputStringUsingTableGridPattern<T > (
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
                    ((IMySuperWrapper)
                     pattern.GetType().GetMethod(
                         "GetItem").Invoke(
                         pattern,
                         coordinates)).Current.Name;
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
        internal static System.Collections.Generic.List<string >
            GetOutputStringUsingItemsValuePattern(
                // 20131109
                //AutomationElement control,
                IMySuperWrapper control,
                char delimiter)
        {
            System.Collections.Generic.List<string >  rowsCollection =
                new System.Collections.Generic.List<string > ();
            
            // 20131109
            //AutomationElementCollection rows =
            IMySuperCollection rows =
                control.FindAll(TreeScope.Children,
                                new PropertyCondition(
                                    AutomationElement.ControlTypeProperty,
                                    ControlType.Custom));
            if (rows.Count > 0) {
                
                // 20131109
                //foreach ( AutomationElement row in rows) {
                foreach(IMySuperWrapper row in rows) {
                    
                    // 20131109
                    //AutomationElementCollection rowItems =
                    IMySuperCollection rowItems =
                        row.FindAll(TreeScope.Children,
                                    new PropertyCondition(
                                        AutomationElement.ControlTypeProperty,
                                        ControlType.Custom));
                    if (rowItems.Count <= 0) continue;
                    string onerow = String.Empty;
                    
                    // 20131109
                    int rowCounter = 0;
                    foreach (IMySuperWrapper rowItem in rowItems) {
                        
                        rowCounter++;
                        ValuePattern valPattern = null;
                        string strValue = String.Empty;
                        strValue += '"';
                        try {
                            valPattern =
                                rowItem.GetCurrentPattern(ValuePattern.Pattern)
                                    as ValuePattern;
                            strValue += valPattern.Current.Value;
                        } catch {
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
        
        private static bool compareSheridanTreeItemName(
            SheridanCmdletBase cmdlet,
            string neededName)
        {
            bool result = false;
            
            
            
            return result;
        }
        
        // 20131109
        //public static AutomationElement GetSheridanTreeItemByName(
        public static IMySuperWrapper GetSheridanTreeItemByName(
            SheridanCmdletBase cmdlet,
            IntPtr hwndTreeView,
            string treeItemName)
        {
            // 20131109
            //AutomationElement resultElement = null;
            IMySuperWrapper resultElement = null;
            
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
                getSheridanTreeItemFromTreeNode(
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
        
        // 20131109
        //private static AutomationElement getSheridanTreeItemFromTreeNode(
        private static IMySuperWrapper getSheridanTreeItemFromTreeNode(
            CommonCmdletBase cmdlet,
            IntPtr hwndTreeView,
            IntPtr hwndTreeItem,
            string treeItemName)
        {
            // 20131109
            //AutomationElement resultElement = null;
            IMySuperWrapper resultElement = null;
            
            //IntPtr resultHandle = IntPtr.Zero;
            int resultHandle = 0; //IntPtr.Zero;
            //IntPtr childHandle = IntPtr.Zero;
            int childHandle = 0; //IntPtr.Zero;
            
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

        //public static List<IntPtr> GetChildWindows(IntPtr parent)
        internal static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                //EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
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
        
        
        //private static ArrayList EnumChildWindowsFromHandle(PSCmdletBase cmdlet, IntPtr parentHandle)
        internal static ArrayList EnumChildWindowsFromHandle(GetWindowCmdletBase cmdlet, IntPtr parentHandle)
        {
            System.Collections.Generic.List<IntPtr> list =
                GetChildWindows(parentHandle);
            
            System.Collections.ArrayList resultElements =
                new System.Collections.ArrayList();
            
            System.Collections.ArrayList automationElements =
                new System.Collections.ArrayList();
            
            //using (System.Collections.ArrayList automationElements =
            //    new System.Collections.ArrayList()) {
            
            foreach (IntPtr handle in list) {
                
                try {
                    
                    //System.Windows.Automation.Automation.
                    // 20131109
                    //AutomationElement element =
                    IMySuperWrapper element =
                        GetAutomationElementFromHandle(cmdlet, handle.ToInt32());
                    
                    automationElements.Add(element);
                    
                    //Console.WriteLine("title = " + element.Current.Name + "\tautomationId = " + element.Current.AutomationId + "\thandle = " + element.Current.NativeWindowHandle.ToString());
                    
                }
                catch {}
            }
            
            if (null == cmdlet.Name || 0 == cmdlet.Name.Length) {
                cmdlet.Name = new string[] { "*" };
            }
            
            foreach (string windowName in cmdlet.Name) {
                
                resultElements.AddRange(
                    HasTimeoutCmdletBase.ReturnOnlyRightElements(
                        // 20130513
                        (HasTimeoutCmdletBase)cmdlet,
                        automationElements,
                        windowName,
                        cmdlet.AutomationId, //automaitonId,
                        cmdlet.Class, //className,
                        string.Empty,
                        new string[]{ "Window" },
                        false));
            }
            
            //
            // extra?
            automationElements.Clear();
            //
            
            //};
            
            //return automationElements;
            return resultElements;
        }
        
        public static ArrayList Enum1ChildWindows(IntPtr parentHandle)
        {
            
            //PSCmdletBase cmdlet = new GetUIAWindowCommand();
            GetWindowCmdletBase cmdlet = new GetWindowCmdletBase();
            System.Collections.ArrayList resultList =
                EnumChildWindowsFromHandle(cmdlet, parentHandle);
            
            return resultList;
        }
        
        public static ArrayList Enum2ChildWindows(IntPtr parentHandle)
        {
            
            //PSCmdletBase cmdlet = new GetUIAWindowCommand();
            GetWindowCmdletBase cmdlet = new GetWindowCmdletBase();
            System.Collections.ArrayList resultList =
                EnumChildWindowsFromHandle(cmdlet, IntPtr.Zero);
            
            return resultList;
        }
        #endregion experimental
    }
    
    #region experimental
    public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
    #endregion experimental
}