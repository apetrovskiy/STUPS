/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2014
 * Time: 3:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    /// <summary>
    /// Description of StartCachedModeCommand.
    /// </summary>
//    public class StartCachedModeCommand : UiaCommand
//    {
//        public StartUiaCachedModeCommand(CommonCmdletBase cmdlet) : base (cmdlet)
//        {
//            
//        }
//        
//        
//        public override void Execute()
//        {
//            var cmdlet =
//                (AddUiaBannerTextCommand)Cmdlet;
//            
//            
//        }
//        
//        protected override void BeginProcessing()
//        {
//            try {
//                //CurrentData.CacheRequest = new CacheRequest();
//                
//                if (CurrentData.CacheRequest != null) {
//                    
//                    WriteError(
//                        this,
//                        "There is already active CacheRequest. Please close it first",
//                        "cacheRequestIsOpen",
//                        ErrorCategory.InvalidOperation,
//                        true);
//                }
//                
//                CurrentData.CacheRequest = new CacheRequest {AutomationElementMode = AutomationElementMode.None};
//                CurrentData.CacheRequest.TreeFilter = UiaHelper.GetTreeFilter(Filter);
//                CurrentData.CacheRequest.TreeScope = UiaHelper.GetTreeScope(Scope);
//                
//                if (null == Property || 0 == Property.Length) {
//                    WriteVerbose(this, "no properties were provided");
//                    CurrentData.CacheRequest.Add(AutomationElement.NameProperty);
//                    CurrentData.CacheRequest.Add(AutomationElement.AutomationIdProperty);
//                    CurrentData.CacheRequest.Add(AutomationElement.ClassNameProperty);
//                    CurrentData.CacheRequest.Add(AutomationElement.ControlTypeProperty);
//                    CurrentData.CacheRequest.Add(AutomationElement.NativeWindowHandleProperty);
//                    CurrentData.CacheRequest.Add(AutomationElement.BoundingRectangleProperty);
//                    CurrentData.CacheRequest.Add(AutomationElement.ClickablePointProperty);
//                    CurrentData.CacheRequest.Add(AutomationElement.IsEnabledProperty);
//                    CurrentData.CacheRequest.Add(AutomationElement.IsOffscreenProperty);
//                    CurrentData.CacheRequest.Add(AutomationElement.ProcessIdProperty);
//                    // 20140208
//                    CurrentData.CacheRequest.Add(ValuePattern.ValueProperty);
//                    CurrentData.CacheRequest.Add(ExpandCollapsePattern.ExpandCollapseStateProperty);
//                    CurrentData.CacheRequest.Add(SelectionItemPattern.IsSelectedProperty);
//                    CurrentData.CacheRequest.Add(SelectionItemPattern.SelectionContainerProperty);
//                    CurrentData.CacheRequest.Add(SelectionPattern.CanSelectMultipleProperty);
//                    CurrentData.CacheRequest.Add(SelectionPattern.IsSelectionRequiredProperty);
//                    CurrentData.CacheRequest.Add(SelectionPattern.SelectionProperty);
//                } else {
//                    WriteVerbose(this, "using properties that were provided");
//                    foreach (string propertyName in Property)
//                    {
//                        switch (propertyName.ToUpper()) {
//                            case "NAME":
//                                CurrentData.CacheRequest.Add(AutomationElement.NameProperty);
//                                break;
//                            case "AUTOMATIONID":
//                                CurrentData.CacheRequest.Add(AutomationElement.AutomationIdProperty);
//                                break;
//                            case "CLASSNAME":
//                            case "CLASS":
//                                CurrentData.CacheRequest.Add(AutomationElement.ClassNameProperty);
//                                break;
//                            case "CONTROLTYPE":
//                                CurrentData.CacheRequest.Add(AutomationElement.ControlTypeProperty);
//                                break;
//                            case "NATIVEWINDOWHANDLE":
//                                CurrentData.CacheRequest.Add(AutomationElement.NativeWindowHandleProperty);
//                                break;
//                            case "BOUNDINGRECTANGLE":
////                            case "RECTANGLE":
////                            case "BOUNDING":
//                                CurrentData.CacheRequest.Add(AutomationElement.BoundingRectangleProperty);
//                                break;
//                            case "CLICKABLEPOINT":
////                            case "POINT":
////                            case "CLICKABLE":
//                                CurrentData.CacheRequest.Add(AutomationElement.ClickablePointProperty);
//                                break;
//                            case "ISENABLED":
//                            case "ENABLED":
//                                CurrentData.CacheRequest.Add(AutomationElement.IsEnabledProperty);
//                                break;
//                            case "ISOFFSCREEN":
//                            case "ISVISIBLE":
//                            case "VISIBLE":
//                                CurrentData.CacheRequest.Add(AutomationElement.IsOffscreenProperty);
//                                break;
//                            // 20140208
//                            case "PROCESSID":
//                                CurrentData.CacheRequest.Add(AutomationElement.ProcessIdProperty);
//                                break;
//                            case "VALUE":
//                                CurrentData.CacheRequest.Add(RangeValuePattern.ValueProperty);
//                                CurrentData.CacheRequest.Add(ValuePattern.ValueProperty);
//                                break;
////                            default:
////                                CurrentData.CacheRequest.Add(AutomationElement.NameProperty);
////                                CurrentData.CacheRequest.Add(AutomationElement.AutomationIdProperty);
////                                CurrentData.CacheRequest.Add(AutomationElement.ClassNameProperty);
////                                CurrentData.CacheRequest.Add(AutomationElement.ControlTypeProperty);
////                                CurrentData.CacheRequest.Add(AutomationElement.NativeWindowHandleProperty);
////                                CurrentData.CacheRequest.Add(AutomationElement.BoundingRectangleProperty);
////                                CurrentData.CacheRequest.Add(AutomationElement.ClickablePointProperty);
////                                CurrentData.CacheRequest.Add(AutomationElement.IsEnabledProperty);
////                                CurrentData.CacheRequest.Add(AutomationElement.IsOffscreenProperty);
////                                break;
//                        }
//                    }
//                }
//                
//                if (null == Pattern || 0 == Pattern.Length) {
//                    WriteVerbose(this, "no patterns were provided");
//                    CurrentData.CacheRequest.Add(classic.ExpandCollapsePattern.Pattern);
//                    CurrentData.CacheRequest.Add(classic.InvokePattern.Pattern);
//                    CurrentData.CacheRequest.Add(classic.ScrollItemPattern.Pattern);
//                    CurrentData.CacheRequest.Add(classic.SelectionItemPattern.Pattern);
//                    CurrentData.CacheRequest.Add(classic.SelectionPattern.Pattern);
//                    CurrentData.CacheRequest.Add(classic.TextPattern.Pattern);
//                    CurrentData.CacheRequest.Add(classic.TogglePattern.Pattern);
//                    CurrentData.CacheRequest.Add(classic.ValuePattern.Pattern);
//                } else {
//                    WriteVerbose(this, "using patterns that were provided");
//                    foreach (string patternName in Pattern)
//                    {
//                        switch (patternName.ToUpper()) {
//                            case "DOCK":
//                            case "DOCKPATTERN":
//                                CurrentData.CacheRequest.Add(classic.DockPattern.Pattern);
//                                break;
//                            case "EXPAND":
//                            case "COLLAPSE":
//                            case "EXPANDPATTERN":
//                            case "COLLAPSEPATTERN":
//                            case "EXPANDCOLLAPSEPATTERN":
//                                CurrentData.CacheRequest.Add(classic.ExpandCollapsePattern.Pattern);
//                                break;
//                            case "GRIDITEM":
//                            case "GRIDITEMPATTERN":
//                                CurrentData.CacheRequest.Add(classic.GridItemPattern.Pattern);
//                                break;
//                            case "GRID":
//                            case "GRIDPATTERN":
//                                CurrentData.CacheRequest.Add(classic.GridPattern.Pattern);
//                                break;
//                            case "INVOKE":
//                            case "INVOKEPATTERN":
//                                CurrentData.CacheRequest.Add(classic.InvokePattern.Pattern);
//                                break;
//                            case "MULTIPLEVIEW":
//                            case "MULTIPLEVIEWPATTERN":
//                                CurrentData.CacheRequest.Add(classic.MultipleViewPattern.Pattern);
//                                break;
//                            case "RANGEVALUE":
//                            case "RANGEVALUEPATTERN":
//                                CurrentData.CacheRequest.Add(classic.RangeValuePattern.Pattern);
//                                break;
//                            case "SCROLLITEM":
//                            case "SCROLLITEMPATTERN":
//                                CurrentData.CacheRequest.Add(classic.ScrollItemPattern.Pattern);
//                                break;
//                            case "SCROLL":
//                            case "SCROLLPATTERN":
//                                CurrentData.CacheRequest.Add(classic.ScrollPattern.Pattern);
//                                break;
//                            case "SELECTIONITEM":
//                            case "SELECTIONITEMPATTERN":
//                                CurrentData.CacheRequest.Add(classic.SelectionItemPattern.Pattern);
//                                break;
//                            case "SELECTION":
//                            case "SELECTIONPATTERN":
//                                CurrentData.CacheRequest.Add(classic.SelectionPattern.Pattern);
//                                break;
//                            case "TABLEITEM":
//                            case "TABLEITEMPATTERN":
//                                CurrentData.CacheRequest.Add(classic.TableItemPattern.Pattern);
//                                break;
//                            case "TABLE":
//                            case "TABLEPATTERN":
//                                CurrentData.CacheRequest.Add(classic.TablePattern.Pattern);
//                                break;
//                            case "TEXT":
//                            case "TEXTPATTERN":
//                                CurrentData.CacheRequest.Add(classic.TextPattern.Pattern);
//                                break;
//                            case "TOGGLE":
//                            case "TOGGLEPATTERN":
//                                CurrentData.CacheRequest.Add(classic.TogglePattern.Pattern);
//                                break;
//                            case "TRANSFORM":
//                            case "TRANSFORMPATTERN":
//                                CurrentData.CacheRequest.Add(classic.TransformPattern.Pattern);
//                                break;
//                            case "VALUE":
//                            case "VALUEPATTERN":
//                                CurrentData.CacheRequest.Add(classic.ValuePattern.Pattern);
//                                break;
//                            case "WINDOW":
//                            case "WINDOWPATTERN":
//                                CurrentData.CacheRequest.Add(classic.WindowPattern.Pattern);
//                                break;
////                            default:
////                                CurrentData.CacheRequest.Add(classic.DockPattern.Pattern);
////                                CurrentData.CacheRequest.Add(classic.ExpandCollapsePattern.Pattern);
////                                CurrentData.CacheRequest.Add(classic.GridItemPattern.Pattern);
////                                CurrentData.CacheRequest.Add(classic.GridPattern.Pattern);
////                                CurrentData.CacheRequest.Add(classic.InvokePattern.Pattern);
////                                CurrentData.CacheRequest.Add(classic.MultipleViewPattern.Pattern);
////                                CurrentData.CacheRequest.Add(classic.RangeValuePattern.Pattern);
////                                CurrentData.CacheRequest.Add(classic.ScrollItemPattern.Pattern);
////                                CurrentData.CacheRequest.Add(classic.ScrollPattern.Pattern);
////                                CurrentData.CacheRequest.Add(classic.SelectionItemPattern.Pattern);
////                                CurrentData.CacheRequest.Add(classic.SelectionPattern.Pattern);
////                                CurrentData.CacheRequest.Add(classic.TableItemPattern.Pattern);
////                                CurrentData.CacheRequest.Add(classic.TablePattern.Pattern);
////                                CurrentData.CacheRequest.Add(classic.TextPattern.Pattern);
////                                CurrentData.CacheRequest.Add(classic.TogglePattern.Pattern);
////                                CurrentData.CacheRequest.Add(classic.TransformPattern.Pattern);
////                                CurrentData.CacheRequest.Add(classic.ValuePattern.Pattern);
////                                CurrentData.CacheRequest.Add(classic.WindowPattern.Pattern);
////                                break;
//                        }
//                    }
//                }
//                
//                // 20140208
//                // Preferences.FromCache = true;
//                Preferences.CacheRequestCalled = true;
//                // CurrentData.CacheRequest.Push();
//                //WriteObject(this, returnObject);
//            }
//            catch (Exception eCacheRequest) {
//                
//                WriteError(
//                    this,
//                    "Unable to start cache request. " +
//                    eCacheRequest.Message,
//                    "CacheRequestFailedToPush",
//                    ErrorCategory.InvalidOperation,
//                    true);
//            }
//        }
//    }
}
