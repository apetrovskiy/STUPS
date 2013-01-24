/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/11/2012
 * Time: 11:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of StartUIACacheRequestCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "UIACacheRequest")]
    public class StartUIACacheRequestCommand : CacheRequestCmdletBase
    {
        public StartUIACacheRequestCommand()
        {
            System.Collections.ArrayList defaultPropertiesList = 
                new System.Collections.ArrayList();
            defaultPropertiesList.Add("Name");
            defaultPropertiesList.Add("AutomationId");
            defaultPropertiesList.Add("ClassName");
            defaultPropertiesList.Add("ControlType");
            defaultPropertiesList.Add("NativeWindowHandle");
            defaultPropertiesList.Add("BoundingRectangle");
            defaultPropertiesList.Add("ClickablePoint");
            defaultPropertiesList.Add("IsEnabled");
            defaultPropertiesList.Add("IsOffscreen");
            this.Property = (string[])defaultPropertiesList.ToArray(typeof(string));
            
            System.Collections.ArrayList defaultPatternsList = 
                new System.Collections.ArrayList();
            defaultPatternsList.Add("ExpandCollapsePattern");
            defaultPatternsList.Add("InvokePattern");
            defaultPatternsList.Add("ScrollItemPattern");
            defaultPatternsList.Add("SelectionItemPattern");
            defaultPatternsList.Add("SelectionPattern");
            defaultPatternsList.Add("TextPattern");
            defaultPatternsList.Add("TogglePattern");
            defaultPatternsList.Add("ValuePattern");
            this.Pattern = (string[])defaultPatternsList.ToArray(typeof(string));
            
            this.Scope = "SUBTREE";
            
            this.Filter = "RAW";
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        public string[] Property { get; set; }
        [Parameter(Mandatory = false)]
        public string[] Pattern { get; set; }
        [Parameter(Mandatory = false)]
        public string Scope { get; set; }
        [Parameter(Mandatory = false)]
        public string Filter { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            try {
                //CurrentData.CacheRequest = new CacheRequest();
                
                if (CurrentData.CacheRequest != null) {
                    ErrorRecord err = 
                        new ErrorRecord(
                            new Exception("There is already active CacheRequest"),
                            "cacheRequestIsOpen",
                            ErrorCategory.InvalidOperation,
                            CurrentData.CacheRequest);
                    err.ErrorDetails = 
                        new ErrorDetails("There is already active CacheRequest. Please close it first");
                    WriteError(this, err, true);
                }
                
                CurrentData.CacheRequest = new CacheRequest();
                CurrentData.CacheRequest.AutomationElementMode = AutomationElementMode.Full;
                switch (this.Filter.ToUpper()) {
                    case "RAW":
                        CurrentData.CacheRequest.TreeFilter = Automation.RawViewCondition;
                        break;
                    case "CONTENT":
                        CurrentData.CacheRequest.TreeFilter = Automation.ContentViewCondition;
                        break;
                    case "CONTROL":
                        CurrentData.CacheRequest.TreeFilter = Automation.ControlViewCondition;
                        break;
                }
                //CurrentData.CacheRequest.TreeFilter = Automation.RawViewCondition;
                switch (this.Scope.ToUpper()) {
                    case "SUBTREE":
                        CurrentData.CacheRequest.TreeScope = TreeScope.Subtree;
                        break;
//                    case "ANCESTORS":
//                        CurrentData.CacheRequest.TreeScope = TreeScope.Ancestors;
//                        break;
                    case "CHILDREN":
                        CurrentData.CacheRequest.TreeScope = TreeScope.Children;
                        break;
                    case "DESCENDANTS":
                        CurrentData.CacheRequest.TreeScope = TreeScope.Descendants;
                        break;
                    case "ELEMENT":
                        CurrentData.CacheRequest.TreeScope = TreeScope.Element;
                        break;
//                    case "PARENT":
//                        CurrentData.CacheRequest.TreeScope = TreeScope.Parent;
//                        break;
                }
                //CurrentData.CacheRequest.TreeScope = TreeScope.Subtree;
                
                if (this.Property.Length == 0) {
                    CurrentData.CacheRequest.Add(AutomationElement.NameProperty);
                    CurrentData.CacheRequest.Add(AutomationElement.AutomationIdProperty);
                    CurrentData.CacheRequest.Add(AutomationElement.ClassNameProperty);
                    CurrentData.CacheRequest.Add(AutomationElement.ControlTypeProperty);
                    CurrentData.CacheRequest.Add(AutomationElement.NativeWindowHandleProperty);
                    CurrentData.CacheRequest.Add(AutomationElement.BoundingRectangleProperty);
                    CurrentData.CacheRequest.Add(AutomationElement.ClickablePointProperty);
                    CurrentData.CacheRequest.Add(AutomationElement.IsEnabledProperty);
                    CurrentData.CacheRequest.Add(AutomationElement.IsOffscreenProperty);
                } else {
                    for (int i = 0; i < this.Property.Length; i++) {
                        switch (this.Property[i].ToUpper()) {
                            case "NAME":
                                CurrentData.CacheRequest.Add(AutomationElement.NameProperty);
                                break;
                            case "AUTOMATIONID":
                                CurrentData.CacheRequest.Add(AutomationElement.AutomationIdProperty);
                                break;
                            case "CLASSNAME":
                            case "CLASS":
                                CurrentData.CacheRequest.Add(AutomationElement.ClassNameProperty);
                                break;
                            case "CONTROLTYPE":
                                CurrentData.CacheRequest.Add(AutomationElement.ControlTypeProperty);
                                break;
                            case "NATIVEWINDOWHANDLE":
                                CurrentData.CacheRequest.Add(AutomationElement.NativeWindowHandleProperty);
                                break;
                            case "BOUNDINGRECTANGLE":
                            case "RECTANGLE":
                            case "BOUNDING":
                                CurrentData.CacheRequest.Add(AutomationElement.BoundingRectangleProperty);
                                break;
                            case "CLICKABLEPOINT":
                            case "POINT":
                            case "CLICKABLE":
                                CurrentData.CacheRequest.Add(AutomationElement.ClickablePointProperty);
                                break;
                            case "ISENABLED":
                            case "ENABLED":
                                CurrentData.CacheRequest.Add(AutomationElement.IsEnabledProperty);
                                break;
                            case "ISOFFSCREEN":
                            case "ISVISIBLE":
                            case "VISIBLE":
                                CurrentData.CacheRequest.Add(AutomationElement.IsOffscreenProperty);
                                break;
                        }
                    }
                }
                
                if (this.Pattern.Length == 0) {
                    CurrentData.CacheRequest.Add(ExpandCollapsePattern.Pattern);
                    CurrentData.CacheRequest.Add(InvokePattern.Pattern);
                    CurrentData.CacheRequest.Add(ScrollItemPattern.Pattern);
                    CurrentData.CacheRequest.Add(SelectionItemPattern.Pattern);
                    CurrentData.CacheRequest.Add(SelectionPattern.Pattern);
                    CurrentData.CacheRequest.Add(TextPattern.Pattern);
                    CurrentData.CacheRequest.Add(TogglePattern.Pattern);
                    CurrentData.CacheRequest.Add(ValuePattern.Pattern);
                } else {
                    for (int i = 0; i < this.Pattern.Length; i++) {
                        switch (this.Pattern[i].ToUpper()) {
                            case "DOCK":
                            case "DOCKPATTERN":
                                CurrentData.CacheRequest.Add(DockPattern.Pattern);
                                break;
                            case "EXPAND":
                            case "COLLAPSE":
                            case "EXPANDPATTERN":
                            case "COLLAPSEPATTERN":
                            case "EXPANDCOLLAPSEPATTERN":
                                CurrentData.CacheRequest.Add(ExpandCollapsePattern.Pattern);
                                break;
                            case "GRIDITEM":
                            case "GRIDITEMPATTERN":
                                CurrentData.CacheRequest.Add(GridItemPattern.Pattern);
                                break;
                            case "GRID":
                            case "GRIDPATTERN":
                                CurrentData.CacheRequest.Add(GridPattern.Pattern);
                                break;
                            case "INVOKE":
                            case "INVOKEPATTERN":
                                CurrentData.CacheRequest.Add(InvokePattern.Pattern);
                                break;
                            case "MULTIPLEVIEW":
                            case "MULTIPLEVIEWPATTERN":
                                CurrentData.CacheRequest.Add(MultipleViewPattern.Pattern);
                                break;
                            case "RANGEVALUE":
                            case "RANGEVALUEPATTERN":
                                CurrentData.CacheRequest.Add(RangeValuePattern.Pattern);
                                break;
                            case "SCROLLITEM":
                            case "SCROLLITEMPATTERN":
                                CurrentData.CacheRequest.Add(ScrollItemPattern.Pattern);
                                break;
                            case "SCROLL":
                            case "SCROLLPATTERN":
                                CurrentData.CacheRequest.Add(ScrollPattern.Pattern);
                                break;
                            case "SELECTIONITEM":
                            case "SELECTIONITEMPATTERN":
                                CurrentData.CacheRequest.Add(SelectionItemPattern.Pattern);
                                break;
                            case "SELECTION":
                            case "SELECTIONPATTERN":
                                CurrentData.CacheRequest.Add(SelectionPattern.Pattern);
                                break;
                            case "TABLEITEM":
                            case "TABLEITEMPATTERN":
                                CurrentData.CacheRequest.Add(TableItemPattern.Pattern);
                                break;
                            case "TABLE":
                            case "TABLEPATTERN":
                                CurrentData.CacheRequest.Add(TablePattern.Pattern);
                                break;
                            case "TEXT":
                            case "TEXTPATTERN":
                                CurrentData.CacheRequest.Add(TextPattern.Pattern);
                                break;
                            case "TOGGLE":
                            case "TOGGLEPATTERN":
                                CurrentData.CacheRequest.Add(TogglePattern.Pattern);
                                break;
                            case "TRANSFORM":
                            case "TRANSFORMPATTERN":
                                CurrentData.CacheRequest.Add(TransformPattern.Pattern);
                                break;
                            case "VALUE":
                            case "VALUEPATTERN":
                                CurrentData.CacheRequest.Add(ValuePattern.Pattern);
                                break;
                            case "WINDOW":
                            case "WINDOWPATTERN":
                                CurrentData.CacheRequest.Add(WindowPattern.Pattern);
                                break;
                        }
                    }
                }

                Preferences.FromCache = true;
                CurrentData.CacheRequest.Push();
                //WriteObject(this, returnObject);
            }
            catch (Exception eCacheRequest) {
                ErrorRecord err = 
                    new ErrorRecord(
                        new Exception("Unable to start cache request"),
                        "CacheRequestFailedToPush",
                        ErrorCategory.InvalidOperation,
                        null);
                err.ErrorDetails = 
                    new ErrorDetails(
                        "Failed to start a cache request\r\n" +
                        eCacheRequest.Message);
                WriteError(this, err, true);
            }
        }
    }
}
