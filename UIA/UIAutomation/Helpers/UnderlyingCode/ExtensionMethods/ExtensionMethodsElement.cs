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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using PSTestLib;
    using System.Text.RegularExpressions;
    
    /// <summary>
    /// Description of ExtensionMethodsElement.
    /// </summary>
    public static class ExtensionMethodsElement
    {
        public static IUiElement GetParent(this IUiElement element)
        {
            IUiElement result = null;
            
            var walker =
                new classic.TreeWalker(
                    classic.Condition.TrueCondition);
            
            try {
                result = AutomationFactory.GetUiElement(walker.GetParent(element.GetSourceElement() as classic.AutomationElement));
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
            var walker =
                new classic.TreeWalker(
                    classic.Condition.TrueCondition);
            
            /*
            TreeWalker walker =
                new TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            */
            
            try {
                
                // 20140102
                // IUiElement testparent = AutomationFactory.GetUiElement(walker.GetParent(element.GetSourceElement()));
                IUiElement testparent = AutomationFactory.GetUiElement(walker.GetParent(element.GetSourceElement() as classic.AutomationElement));
                while (testparent != null &&
                    // 20143012
                       // testparent.Current.NativeWindowHandle == 0) {
                        testparent.GetCurrent().NativeWindowHandle == 0) {
                    testparent =
                        // 20140102
                        // AutomationFactory.GetUiElement(walker.GetParent(testparent.GetSourceElement()));
                        AutomationFactory.GetUiElement(walker.GetParent(testparent.GetSourceElement() as classic.AutomationElement));
                    if (testparent != null &&
                        // 20143012
//                        (int)testparent.Current.ProcessId > 0 &&
//                        testparent.Current.NativeWindowHandle != 0) {
                        (int)testparent.GetCurrent().ProcessId > 0 &&
                        testparent.GetCurrent().NativeWindowHandle != 0) {
                        
                        return testparent;
                    }
                }
                // 20143012
                // return testparent.Current.NativeWindowHandle != 0 ? testparent : null;
                return testparent.GetCurrent().NativeWindowHandle != 0 ? testparent : null;
                
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
        internal static IUiElement[] GetParentOrAncestor(this IUiElement element, classic.TreeScope scope)
        {
            var walker =
                new classic.TreeWalker(
                    classic.Condition.TrueCondition);
            
            var ancestors =
                new List<IUiElement>();
            
            try {
                
                IUiElement testParent = AutomationFactory.GetUiElement(walker.GetParent(element.GetSourceElement() as classic.AutomationElement));
                    
                if (scope == classic.TreeScope.Parent || scope == classic.TreeScope.Ancestors) {
                    
                    if (testParent.GetCurrent() != UiElement.RootElement.GetCurrent()) {
                        ancestors.Add(testParent);
                    }
                    
                    if ((testParent.Equals(UiElement.RootElement) && testParent.GetCurrent().Equals(UiElement.RootElement.GetCurrent())) ||
                        scope == classic.TreeScope.Parent) {
                        return ancestors.ToArray();
                    }
                }
                
                while (testParent != null &&
                    (int)testParent.GetCurrent().ProcessId > 0 &&
                    !testParent.GetCurrent().Equals(UiElement.RootElement.GetCurrent())) {
                    
                    testParent =
                        AutomationFactory.GetUiElement(walker.GetParent(testParent.GetSourceElement() as classic.AutomationElement));
                    
                    if (testParent != null &&
                        (int)testParent.GetCurrent().ProcessId > 0 &&
                        !testParent.GetCurrent().Equals(UiElement.RootElement.GetCurrent())) {
                        
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
            var walker =
                new classic.TreeWalker(
                    classic.Condition.TrueCondition);
            
            /*
            TreeWalker walker =
                new TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            */
            
            try
            {
                // commented out 201206210
                //testparent =
                //    walker.GetParent(element);
                IUiElement testParent = element;
                
                // 20140312
                // while (testParent != null && (int)testParent.Current.ProcessId > 0) {
                while (testParent != null && (int)testParent.GetCurrent().ProcessId > 0) {
                    
                    testParent =
                        // 20140102
                        // AutomationFactory.GetUiElement(walker.GetParent(testParent.GetSourceElement()));
                        AutomationFactory.GetUiElement(walker.GetParent(testParent.GetSourceElement() as classic.AutomationElement));
                    
                    // 20140312
                    // if (testParent == null || (int) testParent.Current.ProcessId <= 0) continue;
                    if (testParent == null || (int) testParent.GetCurrent().ProcessId <= 0) continue;
                    if (testParent == cmdlet.OddRootElement)
                    { testParent = null; }
                    else{
                        string parentControlType =
                            // getControlTypeNameOfAutomationElement(testparent, element);
                            // testparent.Current.ControlType.ProgrammaticName.Substring(
                            // element.Current.ControlType.ProgrammaticName.IndexOf('.') + 1);
                            //  // experimental
                            // 20140312
//                            testParent.Current.ControlType.ProgrammaticName.Substring(
//                                testParent.Current.ControlType.ProgrammaticName.IndexOf('.') + 1);
                            testParent.GetCurrent().ControlType.ProgrammaticName.Substring(
                                testParent.GetCurrent().ControlType.ProgrammaticName.IndexOf('.') + 1);
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
                            // 20140102
                            // if (AutomationFactory.GetUiElement(walker.GetParent(testParent.GetSourceElement())) == cmdlet.OddRootElement) {
                            if (AutomationFactory.GetUiElement(walker.GetParent(testParent.GetSourceElement() as classic.AutomationElement)) == cmdlet.OddRootElement) {
                                parentControlType = "Window";
                            }
                        }
                            
                        string parentVerbosity =
                            @"Get-Uia" + parentControlType;
                        try {
                            // 20140312
//                            if (testParent.Current.AutomationId.Length > 0) {
//                                parentVerbosity += (" -AutomationId '" + testParent.Current.AutomationId + "'");
                            if (testParent.GetCurrent().AutomationId.Length > 0) {
                                parentVerbosity += (" -AutomationId '" + testParent.GetCurrent().AutomationId + "'");
                            }
                        }
                        catch {
                        }
                        if (!cmdlet.NoClassInformation) {
                            try {
                                // 20140312
//                                if (testParent.Current.ClassName.Length > 0) {
//                                    parentVerbosity += (" -Class '" + testParent.Current.ClassName + "'");
                                if (testParent.GetCurrent().ClassName.Length > 0) {
                                    parentVerbosity += (" -Class '" + testParent.GetCurrent().ClassName + "'");
                                }
                            }
                            catch {
                            }
                        }
                        try {
                            // 20140312
//                            if (testParent.Current.Name.Length > 0) {
//                                parentVerbosity += (" -Name '" + testParent.Current.Name + "'");
                            if (testParent.GetCurrent().Name.Length > 0) {
                                parentVerbosity += (" -Name '" + testParent.GetCurrent().Name + "'");
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
                elementControlType = element.GetCurrent().ControlType.ProgrammaticName;
            } catch {
                elementControlType = element.GetCached().ControlType.ProgrammaticName;
            }
            if (string.Empty != elementControlType && 0 < elementControlType.Length) {
                elementControlType = elementControlType.Substring(elementControlType.IndexOf('.') + 1);
            }
            
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
            string tempString = string.Empty;
            try {
                
                switch (propertyName) {
                    case "Name":
                        if (!string.IsNullOrEmpty(element.GetCurrent().Name)) {
                            tempString = element.GetCurrent().Name;
                            hasName = true;
                        }
                        break;
                    case "AutomationId":
                        if (!string.IsNullOrEmpty(element.GetCurrent().AutomationId)) {
                            tempString = element.GetCurrent().AutomationId;
                        }
                        break;
                    case "Class":
                        if (!string.IsNullOrEmpty(element.GetCurrent().ClassName)) {
                            tempString = element.GetCurrent().ClassName;
                        }
                        break;
                    case "Value":
                        try {
                            if (!string.IsNullOrEmpty(pattern.Current.Value)) {
                                tempString = pattern.Current.Value;
                                hasName = true;
                            }
                        }
                        catch {}
                        break;
                    case "Win32":
                        if (0 < element.GetCurrent().NativeWindowHandle) {
                            tempString = ".";
                        }
                        break;
                    default:
                        
                        break;
                }
            } catch {
                switch (propertyName) {
                    case "Name":
                        if (!string.IsNullOrEmpty(element.GetCached().Name)) {
                            tempString = element.GetCached().Name;
                            hasName = true;
                        }
                        break;
                    case "AutomationId":
                        if (!string.IsNullOrEmpty(element.GetCached().AutomationId)) {
                            tempString = element.GetCached().AutomationId;
                        }
                        break;
                    case "Class":
                        if (!string.IsNullOrEmpty(element.GetCached().ClassName)) {
                            tempString = element.GetCached().ClassName;
                        }
                        break;
                    case "Value":
                        try {
                            if (!string.IsNullOrEmpty(pattern.Cached.Value)) {
                                tempString = pattern.Cached.Value;
                                hasName = true;
                            }
                        }
                        catch {}
                        break;
                    case "Win32":
                        if (0 < element.GetCached().NativeWindowHandle) {
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
        
        internal static bool IsMatchWildcardPattern(
            this IUiElement elementInput,
            IList resultCollection,
            WildcardPattern wcPattern,
            string dataToCheck)
        {
            bool result = false;
            
            // 20140314
            // was an experiment
            // resultCollection = resultCollection ?? new List<IUiElement>();
            
            if (string.IsNullOrEmpty(dataToCheck)) {
                return result;
            }
            
            if (!wcPattern.IsMatch(dataToCheck)) return result;
            
            result = true;
            resultCollection.Add(elementInput);
            return result;
        }
        
        internal static IUiElement InvokeContextMenu(this IUiElement inputObject, HasControlInputCmdletBase cmdlet, int x, int y)
        {
            IUiElement resultElement = null;
            try {
                
                if (!cmdlet.ClickControl(
                        cmdlet,
                        inputObject,
                        new ClickSettings() {
                            RightClick = true,
                            RelativeX = (x < 0 ? Preferences.ClickOnControlByCoordX : x),
                            RelativeY = (y < 0 ? Preferences.ClickOnControlByCoordY : y)
                        })) {
                }
            }
            catch (Exception) {
                throw new Exception("failed to click on the control");
            }
            
            // 20140116
            // what are these x and y?
            // int x = Cursor.Position.X;
            // int y = Cursor.Position.Y;
            
            var contextMenuSearcher =
                AutomationFactory.GetSearcherImpl<ContextMenuSearcher>();
            
            var contextMenuSearcherData =
                new ContextMenuSearcherData {
                InputObject = inputObject,
                ProcessId = inputObject.GetCurrent().ProcessId
            };
            
            var elementsMenuRoot =
                contextMenuSearcher.GetElements(
                    contextMenuSearcherData,
                    Preferences.Timeout);
            
            resultElement =
                elementsMenuRoot.First(element => null != element);
            
            return resultElement;
        }
        
        public static bool GetIsValid(this IUiElement element)
        {
            if (null == element) return false;
            
            if (null == element.GetSourceElement()) return false;
            
            try {
                var elementNet = element.GetSourceElement() as classic.AutomationElement;
                if (null != elementNet) {
                    try {
                        var testVariable = elementNet.Current.Name;
                    } catch (Exception) {
                        return false;
                        // throw;
                    }
                    
                    if (0 == elementNet.Current.ProcessId) return false;
                }
            }
            catch {}
            
            return true;
        }
        
        public static string GetInfo(this IUiElement element)
        {
            string resultString = string.Empty;
            
            if (null == element) return resultString;
            
            try {
                if (null == element.GetCurrent()) return resultString;
                
                if (!string.IsNullOrEmpty(element.GetCurrent().Name)) return element.GetCurrent().Name;
                if (!string.IsNullOrEmpty(element.GetCurrent().AutomationId)) return element.GetCurrent().AutomationId;
                if (!string.IsNullOrEmpty(element.GetCurrent().ClassName)) return element.GetCurrent().ClassName;
                
            } catch (Exception) {
                return resultString;
            }
            
            return resultString;
        }
        
        /// <summary>
        /// Checks that the -Value parameter matches the value ValuePattern of the element returns
        /// </summary>
        /// <param name="item">IUiElement element</param>
        /// <param name="textValue">the -Value parameter</param>
        /// <param name="viaWildcardOrRegex">true is wildcard, false is regexp</param>
        /// <param name="wildcardValue">a wildcard object</param>
        /// <param name="regexOptions">a regex options object</param>
        /// <returns></returns>
        internal static bool CompareElementValueAndValueParameter(
            this IUiElement element,
            string textValue,
            bool viaWildcardOrRegex,
            WildcardPattern wildcardValue,
            RegexOptions regexOptions)
        {
            bool result = false;
            
            // getting the real value of a control
            string realValue = string.Empty;
            try {
                realValue =
                    (element.GetCurrentPattern<IValuePattern>(classic.ValuePattern.Pattern)).Current.Value;
            }
            catch { //(Exception eGetCurrentPattern) {
                // nothing to do
                // usually this place never be reached
            }
            
            result = viaWildcardOrRegex ? wildcardValue.IsMatch(realValue) : Regex.IsMatch(realValue, textValue, regexOptions);
            return result;
        }

        public static Hashtable ConvertToHashtable(this IUiElement element)
        {
            return new Hashtable
            {
                {"Name", element.GetCurrent().Name},
                {"AutomationId", element.GetCurrent().AutomationId},
                {"ControlType", element.GetCurrent().ControlType.ProgrammaticName},
                {"Class", element.GetCurrent().ClassName},
                {"AcceleratorKey", element.GetCurrent().AcceleratorKey},
                {"AccessKey", element.GetCurrent().AccessKey},
                {"BoundingRectangle", element.GetCurrent().BoundingRectangle.ToString()},
                {"FrameworkId", element.GetCurrent().FrameworkId},
                {"HasKeyboardFocus", element.GetCurrent().HasKeyboardFocus.ToString()},
                {"HelpText", element.GetCurrent().HelpText},
                {"IsContentElement", element.GetCurrent().IsContentElement.ToString()},
                {"IsControlElement", element.GetCurrent().IsControlElement.ToString()},
                {"IsEnabled", element.GetCurrent().IsEnabled.ToString()},
                {"IsKeyboardFocusable", element.GetCurrent().IsKeyboardFocusable.ToString()},
                {"IsOffscreen", element.GetCurrent().IsOffscreen.ToString()},
                {"IsPassword", element.GetCurrent().IsPassword.ToString()},
                {"IsRequiredForForm", element.GetCurrent().IsRequiredForForm.ToString()},
                {"ItemStatus", element.GetCurrent().ItemStatus},
                {"ItemType", element.GetCurrent().ItemType},
                {"LocalizedControlType", element.GetCurrent().LocalizedControlType},
                {"NativeWindowHandle", element.GetCurrent().NativeWindowHandle.ToString()},
                {"Orientation", element.GetCurrent().Orientation.ToString()},
                {"ProcessId", element.GetCurrent().ProcessId.ToString()}
            };
        }

        public static IEnumerable<Hashtable> ConvertToHashtables(this IEnumerable<IUiElement> elements)
        {
            return elements.Select(element => element.ConvertToHashtable());
        }
    }
}
