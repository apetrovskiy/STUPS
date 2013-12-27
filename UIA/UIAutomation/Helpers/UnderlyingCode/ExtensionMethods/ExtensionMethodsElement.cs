/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/4/2013
 * Time: 10:33 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET;
    using System;
    using System.Windows.Automation;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using PSTestLib;
    
    using System.Globalization;
    using System.Threading;
    using System.Windows.Forms;
    
    /// <summary>
    /// Description of ExtensionMethodsElement.
    /// </summary>
    public static class ExtensionMethodsElement
    {
        public static IUiElement GetParent(this IUiElement element)
        {
            IUiElement result = null;
            
            TreeWalker walker =
                new TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            try {
                result = AutomationFactory.GetUiElement(walker.GetParent(element.GetSourceElement()));
            }
            catch {}
            
            return result;
        }
        
        #region get an ancestor with a handle
        /// <summary>
        ///  /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        internal static IUiElement GetAncestorWithHandle(this IUiElement element)
        {
            TreeWalker walker =
                new TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            try {
                
                IUiElement testparent = AutomationFactory.GetUiElement(walker.GetParent(element.GetSourceElement()));
                while (testparent != null &&
                       testparent.Current.NativeWindowHandle == 0) {
                    testparent =
                        AutomationFactory.GetUiElement(walker.GetParent(testparent.GetSourceElement()));
                    if (testparent != null &&
                        (int)testparent.Current.ProcessId > 0 &&
                        testparent.Current.NativeWindowHandle != 0) {
                        
                        return testparent;
                    }
                }
                return testparent.Current.NativeWindowHandle != 0 ? testparent : null;
                
            } catch {
                return null;
            }
        }
        #endregion get an ancestor with a handle
        
        #region get the parent or an ancestor
        /// <summary>
        ///  /// </summary>
        /// <param name="element"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        internal static IUiElement[] GetParentOrAncestor(this IUiElement element, TreeScope scope)
        {
            TreeWalker walker =
                new TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            List<IUiElement> ancestors =
                new List<IUiElement>();
            
            try {
                
                IUiElement testParent = AutomationFactory.GetUiElement(walker.GetParent(element.GetSourceElement()));
                    
                if (scope == TreeScope.Parent || scope == TreeScope.Ancestors) {
                    
                    // 20131226
                    // if (testParent != UiElement.RootElement) {
                    if (testParent.Current != UiElement.RootElement.Current) {
                        ancestors.Add(testParent);
                    }
                    
                    // 20131226
                    // if (testParent == UiElement.RootElement ||
                    if ((testParent.Equals(UiElement.RootElement) && testParent.Current.Equals(UiElement.RootElement.Current)) ||
                        scope == TreeScope.Parent) {
                        return ancestors.ToArray();
                    }
                }
                while (testParent != null &&
                       (int)testParent.Current.ProcessId > 0 &&
                       // 20131226
                       // testParent != UiElement.RootElement) {
                       !testParent.Current.Equals(UiElement.RootElement.Current)) {
                    
                    testParent =
                        AutomationFactory.GetUiElement(walker.GetParent(testParent.GetSourceElement()));
                    if (testParent != null &&
                        (int)testParent.Current.ProcessId > 0 &&
                        // 20131226
                        // testParent != UiElement.RootElement) {
                        // !testParent.Equals(UiElement.RootElement)) {
                        !testParent.Current.Equals(UiElement.RootElement.Current)) {
                        
                        ancestors.Add(testParent);
                    } else {
                        break;
                    }
                }
                return ancestors.ToArray();
            } catch {
                return ancestors.ToArray();
            }
        }
        #endregion get the parent or an ancestor
        
        #region Collect ancestors
        /// <summary>
        ///
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="element"></param>
        internal static void CollectAncestors(this IUiElement element, TranscriptCmdletBase cmdlet, ref string errorMessage, ref bool errorOccured)
        {
            TreeWalker walker =
                new TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            
            try
            {
                // commented out 201206210
                //testparent =
                //    walker.GetParent(element);
                IUiElement testParent = element;

                while (testParent != null && (int)testParent.Current.ProcessId > 0) {
                    
                    testParent =
                        AutomationFactory.GetUiElement(walker.GetParent(testParent.GetSourceElement()));
                    
                    if (testParent == null || (int) testParent.Current.ProcessId <= 0) continue;
                    if (testParent == cmdlet.OddRootElement)
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
                        // i.e. Get-UiaPane - >  Get-UiaWindow
                        // since Get-UiaPane is unable to get something more than
                        // a window's child pane control
                        if (parentControlType == "Pane" || parentControlType == "Menu") {
                            
                            // 20131109
                            //if (walker.GetParent(testParent) == cmdlet.rootElement) {
                            // 20131112
                            //if ((new UiElement(walker.GetParent(testParent.SourceElement))) == cmdlet.oddRootElement) {
                            // 20131118
                            // property to method
                            //if (ObjectsFactory.GetUiElement(walker.GetParent(testParent.SourceElement)) == cmdlet.oddRootElement) {
                            if (AutomationFactory.GetUiElement(walker.GetParent(testParent.GetSourceElement())) == cmdlet.OddRootElement) {
                                parentControlType = "Window";
                            }
                        }
                            
                        string parentVerbosity =
                            @"Get-Uia" + parentControlType;
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

                        if (cmdlet.LastRecordedItem[cmdlet.LastRecordedItem.Count - 1].ToString() == parentVerbosity)
                            continue;
                        cmdlet.LastRecordedItem.Add(parentVerbosity);
                        cmdlet.WriteVerbose(parentVerbosity);
                    }
                }
            }
            catch (Exception eErrorInTheInnerCycle) {
                cmdlet.WriteDebug(cmdlet, eErrorInTheInnerCycle.Message);
                // _errorMessageInTheInnerCycle =
                errorMessage =
                    eErrorInTheInnerCycle.Message;
                // _errorInTheInnerCycle = true;
                errorOccured = true;
            }
        }
        #endregion Collect ancestors
        
        /// <summary>
        /// Retrievs an element's ControlType property as a string.
        /// </summary>
        /// <param name="element">AutomationElement</param>
        /// <returns>string</returns>
        internal static string GetElementControlTypeString(this IUiElement element)
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
        
        /// <summary>
        /// Retrieves such element's properties as AutomationId, Name, Class(Name) and Value
        /// </summary>
        /// <param name="cmdlet">cmdlet to report</param>
        /// <param name="element">The element properties taken from</param>
        /// <param name="propertyName">The name of property</param>
        /// <param name="pattern">an object of the ValuePattern type</param>
        /// <param name="hasName">an object has Name</param>
        /// <returns></returns>
        internal static string GetElementPropertyString(
            this IUiElement element,
            PSCmdletBase cmdlet,
            string propertyName,
            IValuePattern pattern,
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
        }
        
        internal static List<IUiElement> GetControlByNameViaWin32(
            this IUiElement containerElement,
            GetControlCmdletBase cmdlet,
            string controlTitle,
            string controlValue)
        {
            List<IUiElement> resultCollection = new List<IUiElement>();
            
            cmdlet.WriteVerbose(cmdlet, "checking the container control");

            if (null == containerElement) { return resultCollection; }
            cmdlet.WriteVerbose(cmdlet, "checking the Name parameter");
            
            controlTitle = string.IsNullOrEmpty(controlTitle) ? "*" : controlTitle;
            controlValue = string.IsNullOrEmpty(controlValue) ? "*" : controlValue;
            
            try {
                IntPtr containerHandle =
                    new IntPtr(containerElement.Current.NativeWindowHandle);
                if (containerHandle == IntPtr.Zero){
                    cmdlet.WriteVerbose(cmdlet, "The container control has no handle");

                    return resultCollection;
                }
                
                List<IntPtr> handlesCollection =
                    UiaHelper.GetControlByNameViaWin32Recursively(cmdlet, containerHandle, controlTitle, 1);
                
                const WildcardOptions options =
                    WildcardOptions.IgnoreCase |
                    WildcardOptions.Compiled;
                
                WildcardPattern wildcardName =
                    new WildcardPattern(controlTitle, options);
                WildcardPattern wildcardValue =
                    new WildcardPattern(controlValue, options);
                
                if (null == handlesCollection || 0 == handlesCollection.Count) return resultCollection;
                cmdlet.WriteVerbose(cmdlet, "handles.Count = " + handlesCollection.Count.ToString());
                
                foreach (IntPtr controlHandle in handlesCollection) {
                    try {
                        cmdlet.WriteVerbose(cmdlet, "checking a handle");
                        if (IntPtr.Zero == controlHandle) continue;
                        cmdlet.WriteVerbose(cmdlet, "the handle is not null");
                        
                        IUiElement tempElement =
                            UiElement.FromHandle(controlHandle);
                        cmdlet.WriteVerbose(cmdlet, "adding the handle to the collection");
                                
                        cmdlet.WriteVerbose(cmdlet, controlTitle);
                        cmdlet.WriteVerbose(cmdlet, tempElement.Current.Name);
                        
                        if (tempElement.IsMatchWildcardPattern(cmdlet, resultCollection, wildcardName, tempElement.Current.Name)) continue;
                        if (tempElement.IsMatchWildcardPattern(cmdlet, resultCollection, wildcardName, tempElement.Current.AutomationId)) continue;
                        if (tempElement.IsMatchWildcardPattern(cmdlet, resultCollection, wildcardName, tempElement.Current.ClassName)) continue;
                        try {
                            string elementValue =
                                // 20131208
                                // (tempElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern).Current.Value;
                                // (tempElement.GetCurrentPattern<IValuePattern, ValuePattern>(ValuePattern.Pattern) as ValuePattern).Current.Value;
                                tempElement.GetCurrentPattern<IValuePattern>(ValuePattern.Pattern).Current.Value;
                            if (tempElement.IsMatchWildcardPattern(cmdlet, resultCollection, wildcardName, elementValue)) continue;
                            if (tempElement.IsMatchWildcardPattern(cmdlet, resultCollection, wildcardValue, elementValue)) continue;
                        }
                        catch { //(Exception eValuePattern) {
                        }
                    }
                    catch (Exception eGetAutomationElementFromHandle) {
                        cmdlet.WriteVerbose(cmdlet, eGetAutomationElementFromHandle.Message);
                    }
                }
                return resultCollection;
            } catch (Exception eWin32Control) {
                cmdlet.WriteVerbose(cmdlet, "UiaHelper.GetControlByName() failed");
                cmdlet.WriteVerbose(cmdlet, eWin32Control.Message);
                return resultCollection;
            }
        }
        
        internal static bool IsMatchWildcardPattern(
            this IUiElement elementInput,
            PSCmdletBase cmdlet,
            IList resultCollection,
            WildcardPattern wcPattern,
            string dataToCheck)
        {
            bool result = false;
            
            if (string.IsNullOrEmpty(dataToCheck)) {
                return result;
            }
            
            if (!wcPattern.IsMatch(dataToCheck)) return result;
            
            result = true;
            cmdlet.WriteVerbose(cmdlet, "name '" + dataToCheck + "' matches!");
            resultCollection.Add(elementInput);
            
            return result;
        }
        
        internal static IUiElement InvokeContextMenu(this IUiElement inputObject, HasControlInputCmdletBase cmdlet)
        {
            IUiElement resultElement = null;
            try {
                if (!cmdlet.ClickControl(
                        cmdlet,
                        inputObject,
                        true,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        0,
                        Preferences.ClickOnControlByCoordX,
                        Preferences.ClickOnControlByCoordY)) {
                    // WriteError(this, "Couldn't click on this control", "couldNotClick", ErrorCategory.InvalidResult, true);
                    // throw;
                }
            }
            catch {
                throw; // ??
            }
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;

            // WriteVerbose(this, "cursor coordinate X = " + x.ToString(CultureInfo.InvariantCulture));
            // WriteVerbose(this, "cursor coordinate Y = " + y.ToString(CultureInfo.InvariantCulture));

            // get the context menu window
            int processId = inputObject.Current.ProcessId;
            // WriteVerbose(this, "process Id = " + processId.ToString());
            IUiEltCollection windowsByPid = null;
            DateTime startDate = DateTime.Now;
            bool breakSearch = false;
            do {
                // getting all menus in this process
                if (processId != 0) {
                    windowsByPid =
                        UiElement.RootElement.FindAll(
                            TreeScope.Children,
                            new AndCondition(
                                new PropertyCondition(
                                    AutomationElement.ProcessIdProperty,
                                    processId),
                                new PropertyCondition(
                                    AutomationElement.ControlTypeProperty,
                                    ControlType.Menu)));
                }
                
                if (windowsByPid != null && windowsByPid.Count <= 0)
                    continue;
                
                // WriteVerbose(this, "there are " + windowsByPid.Count.ToString() + " menus running within the process");
                
                DateTime nowDate = DateTime.Now;
                if ((nowDate - startDate).TotalSeconds > 3) {
                    breakSearch = true;
                    break;
                }
                
                if (windowsByPid.Count == 0) {

                    // WriteVerbose(this, "sleeping");
                    Thread.Sleep(200);
                    continue;
                }
                
                foreach (IUiElement element in windowsByPid) {

                    // WriteVerbose(this, element.Current.Name);
                    // WriteVerbose(this, element.Current.BoundingRectangle.ToString());
                    try {
                        // WriteVerbose(this, "the element " + element.Current.Name + " is what we've been searching for");
                        resultElement = element;
                        breakSearch = true;
                        break;
                        //                            }
                    } catch {
                    }

                }
                
            }	 while (!breakSearch);

            // WriteObject(this, resultElement);
            
            // 20131119
            // disposal
            windowsByPid.Dispose();
            windowsByPid = null;
            
            // return the context menu window
            return resultElement;
        }
    }
}
