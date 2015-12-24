/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/13/2014
 * Time: 9:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    using System;
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of PatternCommand.
    /// </summary>
    public class PatternCommand : UiaCommand
    {
        public PatternCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet = (PatternCmdletBase)Cmdlet;
            
            foreach (IUiElement inputObject in cmdlet.InputObject) {
                IUiElement control = null;
                try {
                    control =
                        inputObject;
                } catch (Exception) {
//                    WriteVerbose(this, "PatternCmdletBase: Control is not an AutomationElement");
//                    WriteVerbose(this, "PatternCmdletBase: " + eControlTypeException.Message);
                    cmdlet.WriteObject(this, false);
                    return;
                }
                switch (cmdlet.WhatToDo)
                {
                    case "DockSet":
                        cmdlet.CallDockPatternForSet(cmdlet, control, inputObject, ((InvokeUiaDockPatternSetCommand)cmdlet).DockPosition);
                        break;
                    case "DockGet":
                        cmdlet.CallDockPatternForGet(cmdlet, control, inputObject);
                        break;
                    case "Expand":
                        cmdlet.CallExpandPattern(cmdlet, control, inputObject);
                        break;
                    case "Collapse":
                        cmdlet.CallCollapsePattern(cmdlet, control, inputObject);
                        break;
                    case "GridItem":
                        cmdlet.CallGridItemPattern(cmdlet, control, inputObject);
                        break;
                        // not yet implemented
                    case "Grid":
                        cmdlet.CallGridPattern(cmdlet, control, inputObject);
                        break;
                    case "Invoke":
                        cmdlet.CallInvokePattern(cmdlet, control, inputObject);
                        break;
                        // not yet implemented
                        // case "MultipleView":
                        // pattern =
                        // (System.Windows.Automation.MultipleViewPattern)pt;
                        // break;
                    case "RangeValueGet":
                        cmdlet.CallRangeValuePatternForGet(cmdlet, control, inputObject);
                        break;
                    case "RangeValueSet":
                        cmdlet.CallRangeValuePatternForSet(cmdlet, control, inputObject);
                        break;
                    case "ScrollItem":
                        cmdlet.CallScrollItemPattern(cmdlet, control, inputObject);
                        break;
                    case "Scroll":
                        cmdlet.CallScrollPattern(cmdlet, control, inputObject);
                        break;
                    case "SelectionItem":
                        cmdlet.CallSelectionItemPattern(cmdlet, control, inputObject);
                        break;
                    case "SelectionItemState":
                        cmdlet.CallSelectionItemPatternForState(cmdlet, control, inputObject);
                        break;
                    case "SelectedItem": // return only elements that are selected
                        cmdlet.CallSelectedItemPattern(cmdlet, control, inputObject);
                        break;
                    case "Selection":
                        cmdlet.CallSelectionPattern(cmdlet, control, inputObject);
                        break;
                        // not yet implemented
                    case "TableItem":
                        cmdlet.CallTableItemPattern(cmdlet, control, inputObject);
                        break;
                        // not yet implemented
                    case "Table":
                        cmdlet.CallTablePattern(cmdlet, control, inputObject);
                        // pattern =
                        // (System.Windows.Automation.TablePattern)pt;
                        break;
                        // not yet implemented
                        //case "Text":
                    case "TextGet":
                        // pattern =
                        // (System.Windows.Automation.TextPattern)pt;
                        // break;
                        cmdlet.CallTextPatternForGet(cmdlet, control, inputObject);
                        break;
                    case "TextSet":
                        cmdlet.CallTextPatternForSet(cmdlet, control, inputObject);
                        break;
                    case "Toggle":
                        cmdlet.CallTogglePatternMethod(cmdlet, control, inputObject);
                        break;
                    case "ToggleStateGet":
                        cmdlet.CallTogglePatternForGet(cmdlet, control, inputObject);
                        break;
                    case "ToggleStateSet":
                        cmdlet.CallTogglePatternForSet(cmdlet, control, inputObject, ((InvokeUiaToggleStateSetCommand)cmdlet).On);
                        break;
                    case "TransformMove":
                        cmdlet.CallTransformPatternForMove(cmdlet, control, inputObject);
                        break;
                    case "TransformResize":
                        cmdlet.CallTransformPatternForResize(cmdlet, control, inputObject);
                        break;
                    case "TransformRotate":
                        cmdlet.CallTransformPatternForRotate(cmdlet, control, inputObject);
                        break;
                    case "ValueGet":
                        cmdlet.CallValuePatternForGet(cmdlet, control, inputObject);
                        break;
                    case "ValueSet":
                        cmdlet.CallValuePatternForSet(cmdlet, control, inputObject);
                        break;
                    case "Window":
                        cmdlet.CallWindowPattern(cmdlet, control, inputObject);
                        break;
                    case "Annotation":
                        cmdlet.WriteVerbose(cmdlet, "Annotation");
                        break;
                    case "Drag":
                        cmdlet.WriteVerbose(cmdlet, "Drag");
                        break;
                    case "DropTarget":
                        cmdlet.WriteVerbose(cmdlet, "DropTarget");
                        break;
                    case "ItemContainer":
                        cmdlet.WriteVerbose(cmdlet, "ItemContainer");
                        break;
                    case "LegacyIAccessible":
                        cmdlet.WriteVerbose(cmdlet, "LegacyIAccessible");
                        break;
                    case "ObjectModel":
                        cmdlet.WriteVerbose(cmdlet, "ObjectModel");
                        break;
                    case "Spreadsheet":
                        cmdlet.WriteVerbose(cmdlet, "Spreadsheet");
                        break;
                    case "SpreadsheetItem":
                        cmdlet.WriteVerbose(cmdlet, "SpreadsheetItem");
                        break;
                    case "Styles":
                        cmdlet.WriteVerbose(cmdlet, "Styles");
                        break;
                    case "SynchronizedInput":
                        cmdlet.WriteVerbose(cmdlet, "SynchronizedInput");
                        break;
                    case "TextChild":
                        cmdlet.WriteVerbose(cmdlet, "TextChild");
                        break;
                    case "VirtualizedItem":
                        cmdlet.WriteVerbose(cmdlet, "VirtualizedItem");
                        break;
                }
                
                // 2012/04/10
                //            Annotation Control Pattern
                //            Dock Control Pattern
                //            Drag Control Pattern
                //            DropTarget Control Pattern
                //            ExpandCollapse Control Pattern
                //            Grid Control Pattern
                //            GridItem Control Pattern
                //            Invoke Control Pattern
                //            ItemContainer Control Pattern
                //            LegacyIAccessible Control Pattern
                //            MultipleView Control Pattern
                //            ObjectModel Control Pattern
                //            RangeValue Control Pattern
                //            Scroll Control Pattern
                //            ScrollItem Control Pattern
                //            Selection Control Pattern
                //            SelectionItem Control Pattern
                //            Spreadsheet Control Pattern
                //            SpreadsheetItem Control Pattern
                //            Styles Control Pattern
                //            SynchronizedInput Control Pattern
                //            Table Control Pattern
                //            TableItem Control Pattern
                //            Text and TextRange Control Patterns
                //            TextChild Control Pattern
                //            Toggle Control Pattern
                //            Transform Control Pattern
                //            Value Control Pattern
                //            VirtualizedItem Control Pattern
                //            Window Control Pattern
                
            } //20120824
        }
    }
}
