// (c) Copyright Microsoft, 2012.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.


using System;
using System.Collections;
using System.Resources;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using UIAComWrapperInternal;

namespace System.Windows.Automation
{
    #region Well-known properties

    public static class AutomationElementIdentifiers
    {
        
        public static readonly AutomationProperty AcceleratorKeyProperty = AutomationProperty.Register(AutomationIdentifierGuids.AcceleratorKey_Property, "AutomationElementIdentifiers.AcceleratorKeyProperty");
        public static readonly AutomationProperty AccessKeyProperty = AutomationProperty.Register(AutomationIdentifierGuids.AccessKey_Property, "AutomationElementIdentifiers.AccessKeyProperty");
        public static readonly AutomationEvent AsyncContentLoadedEvent = AutomationEvent.Register(AutomationIdentifierGuids.AsyncContentLoaded_Event, "AutomationElementIdentifiers.AsyncContentLoadedEvent");
        public static readonly AutomationEvent AutomationFocusChangedEvent = AutomationEvent.Register(AutomationIdentifierGuids.AutomationFocusChanged_Event, "AutomationElementIdentifiers.AutomationFocusChangedEvent");
        public static readonly AutomationProperty AutomationIdProperty = AutomationProperty.Register(AutomationIdentifierGuids.AutomationId_Property, "AutomationElementIdentifiers.AutomationIdProperty");
        public static readonly AutomationEvent AutomationPropertyChangedEvent = AutomationEvent.Register(AutomationIdentifierGuids.AutomationPropertyChanged_Event, "AutomationElementIdentifiers.AutomationPropertyChangedEvent");
        public static readonly AutomationProperty BoundingRectangleProperty = AutomationProperty.Register(AutomationIdentifierGuids.BoundingRectangle_Property, "AutomationElementIdentifiers.BoundingRectangleProperty");
        public static readonly AutomationProperty ClassNameProperty = AutomationProperty.Register(AutomationIdentifierGuids.ClassName_Property, "AutomationElementIdentifiers.ClassNameProperty");
        public static readonly AutomationProperty ClickablePointProperty = AutomationProperty.Register(AutomationIdentifierGuids.ClickablePoint_Property, "AutomationElementIdentifiers.ClickablePointProperty");
        public static readonly AutomationProperty ControlTypeProperty = AutomationProperty.Register(AutomationIdentifierGuids.ControlType_Property, "AutomationElementIdentifiers.ControlTypeProperty");
        public static readonly AutomationProperty CultureProperty = AutomationProperty.Register(AutomationIdentifierGuids.Culture_Property, "AutomationElementIdentifiers.CultureProperty");
        public static readonly AutomationProperty FrameworkIdProperty = AutomationProperty.Register(AutomationIdentifierGuids.FrameworkId_Property, "AutomationElementIdentifiers.FrameworkIdProperty");
        public static readonly AutomationProperty HasKeyboardFocusProperty = AutomationProperty.Register(AutomationIdentifierGuids.HasKeyboardFocus_Property, "AutomationElementIdentifiers.HasKeyboardFocusProperty");
        public static readonly AutomationProperty HelpTextProperty = AutomationProperty.Register(AutomationIdentifierGuids.HelpText_Property, "AutomationElementIdentifiers.HelpTextProperty");
        public static readonly AutomationProperty IsContentElementProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsContentElement_Property, "AutomationElementIdentifiers.IsContentElementProperty");
        public static readonly AutomationProperty IsControlElementProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsControlElement_Property, "AutomationElementIdentifiers.IsControlElementProperty");
        public static readonly AutomationProperty IsDockPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsDockPatternAvailable_Property, "AutomationElementIdentifiers.IsDockPatternAvailableProperty");
        public static readonly AutomationProperty IsEnabledProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsEnabled_Property, "AutomationElementIdentifiers.IsEnabledProperty");
        public static readonly AutomationProperty IsExpandCollapsePatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsExpandCollapsePatternAvailable_Property, "AutomationElementIdentifiers.IsExpandCollapsePatternAvailableProperty");
        public static readonly AutomationProperty IsGridItemPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsGridItemPatternAvailable_Property, "AutomationElementIdentifiers.IsGridItemPatternAvailableProperty");
        public static readonly AutomationProperty IsGridPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsGridPatternAvailable_Property, "AutomationElementIdentifiers.IsGridPatternAvailableProperty");
        public static readonly AutomationProperty IsInvokePatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsInvokePatternAvailable_Property, "AutomationElementIdentifiers.IsInvokePatternAvailableProperty");
        public static readonly AutomationProperty IsKeyboardFocusableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsKeyboardFocusable_Property, "AutomationElementIdentifiers.IsKeyboardFocusableProperty");
        public static readonly AutomationProperty IsMultipleViewPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsMultipleViewPatternAvailable_Property, "AutomationElementIdentifiers.IsMultipleViewPatternAvailableProperty");
        public static readonly AutomationProperty IsOffscreenProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsOffscreen_Property, "AutomationElementIdentifiers.IsOffscreenProperty");
        public static readonly AutomationProperty IsPasswordProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsPassword_Property, "AutomationElementIdentifiers.IsPasswordProperty");
        public static readonly AutomationProperty IsRangeValuePatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsRangeValuePatternAvailable_Property, "AutomationElementIdentifiers.IsRangeValuePatternAvailableProperty");
        public static readonly AutomationProperty IsRequiredForFormProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsRequiredForForm_Property, "AutomationElementIdentifiers.IsRequiredForFormProperty");
        public static readonly AutomationProperty IsScrollItemPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsScrollItemPatternAvailable_Property, "AutomationElementIdentifiers.IsScrollItemPatternAvailableProperty");
        public static readonly AutomationProperty IsScrollPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsScrollPatternAvailable_Property, "AutomationElementIdentifiers.IsScrollPatternAvailableProperty");
        public static readonly AutomationProperty IsSelectionItemPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsSelectionItemPatternAvailable_Property, "AutomationElementIdentifiers.IsSelectionItemPatternAvailableProperty");
        public static readonly AutomationProperty IsSelectionPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsSelectionPatternAvailable_Property, "AutomationElementIdentifiers.IsSelectionPatternAvailableProperty");
        public static readonly AutomationProperty IsTableItemPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsTableItemPatternAvailable_Property, "AutomationElementIdentifiers.IsTableItemPatternAvailableProperty");
        public static readonly AutomationProperty IsTablePatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsTablePatternAvailable_Property, "AutomationElementIdentifiers.IsTablePatternAvailableProperty");
        public static readonly AutomationProperty IsTextPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsTextPatternAvailable_Property, "AutomationElementIdentifiers.IsTextPatternAvailableProperty");
        public static readonly AutomationProperty IsTogglePatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsTogglePatternAvailable_Property, "AutomationElementIdentifiers.IsTogglePatternAvailableProperty");
        public static readonly AutomationProperty IsTransformPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsTransformPatternAvailable_Property, "AutomationElementIdentifiers.IsTransformPatternAvailableProperty");
        public static readonly AutomationProperty IsValuePatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsValuePatternAvailable_Property, "AutomationElementIdentifiers.IsValuePatternAvailableProperty");
        public static readonly AutomationProperty IsWindowPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsWindowPatternAvailable_Property, "AutomationElementIdentifiers.IsWindowPatternAvailableProperty");
        public static readonly AutomationProperty ItemStatusProperty = AutomationProperty.Register(AutomationIdentifierGuids.ItemStatus_Property, "AutomationElementIdentifiers.ItemStatusProperty");
        public static readonly AutomationProperty ItemTypeProperty = AutomationProperty.Register(AutomationIdentifierGuids.ItemType_Property, "AutomationElementIdentifiers.ItemTypeProperty");
        public static readonly AutomationProperty LabeledByProperty = AutomationProperty.Register(AutomationIdentifierGuids.LabeledBy_Property, "AutomationElementIdentifiers.LabeledByProperty");
        public static readonly AutomationEvent LayoutInvalidatedEvent = AutomationEvent.Register(AutomationIdentifierGuids.LayoutInvalidated_Event, "AutomationElementIdentifiers.LayoutInvalidatedEvent");
        public static readonly AutomationProperty LocalizedControlTypeProperty = AutomationProperty.Register(AutomationIdentifierGuids.LocalizedControlType_Property, "AutomationElementIdentifiers.LocalizedControlTypeProperty");
        public static readonly AutomationEvent MenuClosedEvent = AutomationEvent.Register(AutomationIdentifierGuids.MenuClosed_Event, "AutomationElementIdentifiers.MenuClosedEvent");
        public static readonly AutomationEvent MenuOpenedEvent = AutomationEvent.Register(AutomationIdentifierGuids.MenuOpened_Event, "AutomationElementIdentifiers.MenuOpenedEvent");
        public static readonly AutomationProperty NameProperty = AutomationProperty.Register(AutomationIdentifierGuids.Name_Property, "AutomationElementIdentifiers.NameProperty");
        public static readonly AutomationProperty NativeWindowHandleProperty = AutomationProperty.Register(AutomationIdentifierGuids.NewNativeWindowHandle_Property, "AutomationElementIdentifiers.NativeWindowHandleProperty");
        public static readonly object NotSupported = Automation.Factory.ReservedNotSupportedValue;
        public static readonly AutomationProperty OrientationProperty = AutomationProperty.Register(AutomationIdentifierGuids.Orientation_Property, "AutomationElementIdentifiers.OrientationProperty");
        public static readonly AutomationProperty ProcessIdProperty = AutomationProperty.Register(AutomationIdentifierGuids.ProcessId_Property, "AutomationElementIdentifiers.ProcessIdProperty");
        public static readonly AutomationProperty RuntimeIdProperty = AutomationProperty.Register(AutomationIdentifierGuids.RuntimeId_Property, "AutomationElementIdentifiers.RuntimeIdProperty");
        public static readonly AutomationEvent StructureChangedEvent = AutomationEvent.Register(AutomationIdentifierGuids.StructureChanged_Event, "AutomationElementIdentifiers.StructureChangedEvent");
        public static readonly AutomationEvent ToolTipClosedEvent = AutomationEvent.Register(AutomationIdentifierGuids.ToolTipClosed_Event, "AutomationElementIdentifiers.ToolTipClosedEvent");
        public static readonly AutomationEvent ToolTipOpenedEvent = AutomationEvent.Register(AutomationIdentifierGuids.ToolTipOpened_Event, "AutomationElementIdentifiers.ToolTipOpenedEvent");

        // New for Windows 7
        //

        public static readonly AutomationProperty IsLegacyIAccessiblePatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsLegacyIAccessiblePatternAvailable_Property, "AutomationElementIdentifiers.IsLegacyIAccessiblePatternAvailableProperty");
        public static readonly AutomationProperty IsItemContainerPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsItemContainerPatternAvailable_Property, "AutomationElementIdentifiers.IsItemContainerPatternAvailableProperty");
        public static readonly AutomationProperty IsVirtualizedItemPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsVirtualizedItemPatternAvailable_Property, "AutomationElementIdentifiers.IsVirtualizedItemPatternAvailableProperty");
        public static readonly AutomationProperty IsSynchronizedInputPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsSynchronizedInputPatternAvailable_Property, "AutomationElementIdentifiers.IsSynchronizedInputPatternAvailableProperty");

        public static readonly AutomationProperty AriaRoleProperty = AutomationProperty.Register(AutomationIdentifierGuids.AriaRole_Property, "AutomationElementIdentifiers.AriaRoleProperty");
        public static readonly AutomationProperty AriaPropertiesProperty = AutomationProperty.Register(AutomationIdentifierGuids.AriaProperties_Property, "AutomationElementIdentifiers.AriaPropertiesProperty");
        public static readonly AutomationProperty IsDataValidForFormProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsDataValidForForm_Property, "AutomationElementIdentifiers.IsDataValidForFormProperty");
        public static readonly AutomationProperty ControllerForProperty = AutomationProperty.Register(AutomationIdentifierGuids.ControllerFor_Property, "AutomationElementIdentifiers.ControllerForProperty");
        public static readonly AutomationProperty DescribedByProperty = AutomationProperty.Register(AutomationIdentifierGuids.DescribedBy_Property, "AutomationElementIdentifiers.DescribedByProperty");
        public static readonly AutomationProperty FlowsToProperty = AutomationProperty.Register(AutomationIdentifierGuids.FlowsTo_Property, "AutomationElementIdentifiers.FlowsToProperty");
        public static readonly AutomationProperty ProviderDescriptionProperty = AutomationProperty.Register(AutomationIdentifierGuids.ProviderDescription_Property, "AutomationElementIdentifiers.Property");

        public static readonly AutomationEvent MenuModeStartEvent = AutomationEvent.Register(AutomationIdentifierGuids.MenuModeStart_Event, "AutomationElementIdentifiers.MenuModeStartEvent");
        public static readonly AutomationEvent MenuModeEndEvent = AutomationEvent.Register(AutomationIdentifierGuids.MenuModeEnd_Event, "AutomationElementIdentifiers.MenuModeEndEvent");

        // New for Windows 8
        //

        public static readonly AutomationProperty IsObjectModelPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsObjectModelPatternAvailable_Property, "AutomationElementIdentifiers.IsObjectModelPatternAvailableProperty");
        public static readonly AutomationProperty IsAnnotationPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsAnnotationPatternAvailable_Property, "AutomationElementIdentifiers.IsAnnotationPatternAvailableProperty");
        public static readonly AutomationProperty IsTextPattern2AvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsTextPattern2Available_Property, "AutomationElementIdentifiers.IsTextPattern2AvailableProperty");
        public static readonly AutomationProperty IsStylesPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsStylesPatternAvailable_Property, "AutomationElementIdentifiers.IsStylesPatternAvailableProperty");
        public static readonly AutomationProperty IsSpreadsheetPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsSpreadsheetPatternAvailable_Property, "AutomationElementIdentifiers.IsSpreadsheetPatternAvailableProperty");
        public static readonly AutomationProperty IsSpreadsheetItemPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsSpreadsheetItemPatternAvailable_Property, "AutomationElementIdentifiers.IsSpreadsheetItemPatternAvailableProperty");
        public static readonly AutomationProperty IsTransformPattern2AvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsTransformPattern2Available_Property, "AutomationElementIdentifiers.IsTransformPattern2AvailableProperty");
        public static readonly AutomationProperty IsTextChildPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsTextChildPatternAvailable_Property, "AutomationElementIdentifiers.IsTextChildPatternAvailableProperty");
        public static readonly AutomationProperty IsDragPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsDragPatternAvailable_Property, "AutomationElementIdentifiers.IsDragPatternAvailableProperty");
        public static readonly AutomationProperty IsDropTargetPatternAvailableProperty = AutomationProperty.Register(AutomationIdentifierGuids.IsDropTargetPatternAvailable_Property, "AutomationElementIdentifiers.IsDropTargetPatternAvailableProperty");

        public static readonly AutomationProperty OptimizeForVisualContentProperty = AutomationProperty.Register(AutomationIdentifierGuids.OptimizeForVisualContent_Property, "AutomationElementIdentifiers.OptimizeForVisualContentProperty");
        public static readonly AutomationProperty LiveSettingProperty = AutomationProperty.Register(AutomationIdentifierGuids.LiveSetting_Property, "AutomationElementIdentifiers.LiveSettingProperty");

        public static readonly AutomationEvent SystemAlertEvent = AutomationEvent.Register(AutomationIdentifierGuids.SystemAlert_Event, "AutomationElementIdentifiers.SystemAlertEvent");
        public static readonly AutomationEvent LiveRegionChangedEvent = AutomationEvent.Register(AutomationIdentifierGuids.LiveRegionChanged_Event, "AutomationElementIdentifiers.LiveRegionChangedEvent");
        public static readonly AutomationEvent HostedFragmentRootsInvalidatedEvent = AutomationEvent.Register(AutomationIdentifierGuids.HostedFragmentRootsInvalidated_Event, "AutomationElementIdentifiers.HostedFragmentRootsInvalidatedEvent");
    }

    public static class DockPatternIdentifiers
    {
        
        public static readonly AutomationProperty DockPositionProperty = AutomationProperty.Register(AutomationIdentifierGuids.Dock_Position_Property, "DockPatternIdentifiers.DockPositionProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.Dock_Pattern, "DockPatternIdentifiers.Pattern");
    }

    public static class ExpandCollapsePatternIdentifiers
    {
        
        public static readonly AutomationProperty ExpandCollapseStateProperty = AutomationProperty.Register(AutomationIdentifierGuids.ExpandCollapse_State_Property, "ExpandCollapsePatternIdentifiers.ExpandCollapseStateProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.ExpandCollapse_Pattern, "ExpandCollapsePatternIdentifiers.Pattern");
    }

    public static class GridItemPatternIdentifiers
    {
        
        public static readonly AutomationProperty ColumnProperty = AutomationProperty.Register(AutomationIdentifierGuids.GridItem_Column_Property, "GridItemPatternIdentifiers.ColumnProperty");
        public static readonly AutomationProperty ColumnSpanProperty = AutomationProperty.Register(AutomationIdentifierGuids.GridItem_ColumnSpan_Property, "GridItemPatternIdentifiers.ColumnSpanProperty");
        public static readonly AutomationProperty ContainingGridProperty = AutomationProperty.Register(AutomationIdentifierGuids.GridItem_Parent_Property, "GridItemPatternIdentifiers.ContainingGridProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.GridItem_Pattern, "GridItemPatternIdentifiers.Pattern");
        public static readonly AutomationProperty RowProperty = AutomationProperty.Register(AutomationIdentifierGuids.GridItem_Row_Property, "GridItemPatternIdentifiers.RowProperty");
        public static readonly AutomationProperty RowSpanProperty = AutomationProperty.Register(AutomationIdentifierGuids.GridItem_RowSpan_Property, "GridItemPatternIdentifiers.RowSpanProperty");
    }

    public static class GridPatternIdentifiers
    {
        
        public static readonly AutomationProperty ColumnCountProperty = AutomationProperty.Register(AutomationIdentifierGuids.Grid_ColumnCount_Property, "GridPatternIdentifiers.ColumnCountProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.Grid_Pattern, "GridPatternIdentifiers.Pattern");
        public static readonly AutomationProperty RowCountProperty = AutomationProperty.Register(AutomationIdentifierGuids.Grid_RowCount_Property, "GridPatternIdentifiers.RowCountProperty");
    }

    public static class InvokePatternIdentifiers
    {
        
        public static readonly AutomationEvent InvokedEvent = AutomationEvent.Register(AutomationIdentifierGuids.Invoke_Invoked_Event, "InvokePatternIdentifiers.InvokedEvent");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.Invoke_Pattern, "InvokePatternIdentifiers.Pattern");
    }

    public static class MultipleViewPatternIdentifiers
    {
        
        public static readonly AutomationProperty CurrentViewProperty = AutomationProperty.Register(AutomationIdentifierGuids.MultipleView_CurrentView_Property, "MultipleViewPatternIdentifiers.CurrentViewProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.MultipleView_Pattern, "MultipleViewPatternIdentifiers.Pattern");
        public static readonly AutomationProperty SupportedViewsProperty = AutomationProperty.Register(AutomationIdentifierGuids.MultipleView_SupportedViews_Property, "MultipleViewPatternIdentifiers.SupportedViewsProperty");
    }

    public static class RangeValuePatternIdentifiers
    {
        
        public static readonly AutomationProperty IsReadOnlyProperty = AutomationProperty.Register(AutomationIdentifierGuids.RangeValue_IsReadOnly_Property, "RangeValuePatternIdentifiers.IsReadOnlyProperty");
        public static readonly AutomationProperty LargeChangeProperty = AutomationProperty.Register(AutomationIdentifierGuids.RangeValue_LargeChange_Property, "RangeValuePatternIdentifiers.LargeChangeProperty");
        public static readonly AutomationProperty MaximumProperty = AutomationProperty.Register(AutomationIdentifierGuids.RangeValue_Maximum_Property, "RangeValuePatternIdentifiers.MaximumProperty");
        public static readonly AutomationProperty MinimumProperty = AutomationProperty.Register(AutomationIdentifierGuids.RangeValue_Minimum_Property, "RangeValuePatternIdentifiers.MinimumProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.RangeValue_Pattern, "RangeValuePatternIdentifiers.Pattern");
        public static readonly AutomationProperty SmallChangeProperty = AutomationProperty.Register(AutomationIdentifierGuids.RangeValue_SmallChange_Property, "RangeValuePatternIdentifiers.SmallChangeProperty");
        public static readonly AutomationProperty ValueProperty = AutomationProperty.Register(AutomationIdentifierGuids.RangeValue_Value_Property, "RangeValuePatternIdentifiers.ValueProperty");
    }

    public static class ScrollItemPatternIdentifiers
    {
        
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.ScrollItem_Pattern, "ScrollItemPatternIdentifiers.Pattern");
    }

    public static class ScrollPatternIdentifiers
    {
        
        public static readonly AutomationProperty HorizontallyScrollableProperty = AutomationProperty.Register(AutomationIdentifierGuids.Scroll_HorizontallyScrollable_Property, "ScrollPatternIdentifiers.HorizontallyScrollableProperty");
        public static readonly AutomationProperty HorizontalScrollPercentProperty = AutomationProperty.Register(AutomationIdentifierGuids.Scroll_HorizontalScrollPercent_Property, "ScrollPatternIdentifiers.HorizontalScrollPercentProperty");
        public static readonly AutomationProperty HorizontalViewSizeProperty = AutomationProperty.Register(AutomationIdentifierGuids.Scroll_HorizontalViewSize_Property, "ScrollPatternIdentifiers.HorizontalViewSizeProperty");
        public const double NoScroll = -1.0;
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.Scroll_Pattern, "ScrollPatternIdentifiers.Pattern");
        public static readonly AutomationProperty VerticallyScrollableProperty = AutomationProperty.Register(AutomationIdentifierGuids.Scroll_VerticallyScrollable_Property, "ScrollPatternIdentifiers.VerticallyScrollableProperty");
        public static readonly AutomationProperty VerticalScrollPercentProperty = AutomationProperty.Register(AutomationIdentifierGuids.Scroll_VerticalScrollPercent_Property, "ScrollPatternIdentifiers.VerticalScrollPercentProperty");
        public static readonly AutomationProperty VerticalViewSizeProperty = AutomationProperty.Register(AutomationIdentifierGuids.Scroll_VerticalViewSize_Property, "ScrollPatternIdentifiers.VerticalViewSizeProperty");
    }

    public static class SelectionItemPatternIdentifiers
    {
        
        public static readonly AutomationEvent ElementAddedToSelectionEvent = AutomationEvent.Register(AutomationIdentifierGuids.SelectionItem_ElementAddedToSelection_Event, "SelectionItemPatternIdentifiers.ElementAddedToSelectionEvent");
        public static readonly AutomationEvent ElementRemovedFromSelectionEvent = AutomationEvent.Register(AutomationIdentifierGuids.SelectionItem_ElementRemovedFromSelection_Event, "SelectionItemPatternIdentifiers.ElementRemovedFromSelectionEvent");
        public static readonly AutomationEvent ElementSelectedEvent = AutomationEvent.Register(AutomationIdentifierGuids.SelectionItem_ElementSelected_Event, "SelectionItemPatternIdentifiers.ElementSelectedEvent");
        public static readonly AutomationProperty IsSelectedProperty = AutomationProperty.Register(AutomationIdentifierGuids.SelectionItem_IsSelected_Property, "SelectionItemPatternIdentifiers.IsSelectedProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.SelectionItem_Pattern, "SelectionItemPatternIdentifiers.Pattern");
        public static readonly AutomationProperty SelectionContainerProperty = AutomationProperty.Register(AutomationIdentifierGuids.SelectionItem_SelectionContainer_Property, "SelectionItemPatternIdentifiers.SelectionContainerProperty");
    }

    public static class SelectionPatternIdentifiers
    {
        
        public static readonly AutomationProperty CanSelectMultipleProperty = AutomationProperty.Register(AutomationIdentifierGuids.Selection_CanSelectMultiple_Property, "SelectionPatternIdentifiers.CanSelectMultipleProperty");
        public static readonly AutomationEvent InvalidatedEvent = AutomationEvent.Register(AutomationIdentifierGuids.Selection_Invalidated_Event, "SelectionPatternIdentifiers.InvalidatedEvent");
        public static readonly AutomationProperty IsSelectionRequiredProperty = AutomationProperty.Register(AutomationIdentifierGuids.Selection_IsSelectionRequired_Property, "SelectionPatternIdentifiers.IsSelectionRequiredProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.Selection_Pattern, "SelectionPatternIdentifiers.Pattern");
        public static readonly AutomationProperty SelectionProperty = AutomationProperty.Register(AutomationIdentifierGuids.Selection_Selection_Property, "SelectionPatternIdentifiers.SelectionProperty");
    }

    public static class TableItemPatternIdentifiers
    {
        
        public static readonly AutomationProperty ColumnHeaderItemsProperty = AutomationProperty.Register(AutomationIdentifierGuids.TableItem_ColumnHeaderItems_Property, "TableItemPatternIdentifiers.ColumnHeaderItemsProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.TableItem_Pattern, "TableItemPatternIdentifiers.Pattern");
        public static readonly AutomationProperty RowHeaderItemsProperty = AutomationProperty.Register(AutomationIdentifierGuids.TableItem_RowHeaderItems_Property, "TableItemPatternIdentifiers.RowHeaderItemsProperty");
    }

    public static class TablePatternIdentifiers
    {
        
        public static readonly AutomationProperty ColumnHeadersProperty = AutomationProperty.Register(AutomationIdentifierGuids.Table_ColumnHeaders_Property, "TablePatternIdentifiers.ColumnHeadersProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.Table_Pattern, "TablePatternIdentifiers.Pattern");
        public static readonly AutomationProperty RowHeadersProperty = AutomationProperty.Register(AutomationIdentifierGuids.Table_RowHeaders_Property, "TablePatternIdentifiers.RowHeadersProperty");
        public static readonly AutomationProperty RowOrColumnMajorProperty = AutomationProperty.Register(AutomationIdentifierGuids.Table_RowOrColumnMajor_Property, "TablePatternIdentifiers.RowOrColumnMajorProperty");
    }

    public static class TextPatternIdentifiers
    {
        
        public static readonly AutomationTextAttribute AnimationStyleAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_AnimationStyle_Attribute, "TextPatternIdentifiers.AnimationStyleAttribute");
        public static readonly AutomationTextAttribute BackgroundColorAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_BackgroundColor_Attribute, "TextPatternIdentifiers.BackgroundColorAttribute");
        public static readonly AutomationTextAttribute BulletStyleAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_BulletStyle_Attribute, "TextPatternIdentifiers.BulletStyleAttribute");
        public static readonly AutomationTextAttribute CapStyleAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_CapStyle_Attribute, "TextPatternIdentifiers.CapStyleAttribute");
        public static readonly AutomationTextAttribute CultureAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_Culture_Attribute, "TextPatternIdentifiers.CultureAttribute");
        public static readonly AutomationTextAttribute FontNameAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_FontName_Attribute, "TextPatternIdentifiers.FontNameAttribute");
        public static readonly AutomationTextAttribute FontSizeAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_FontSize_Attribute, "TextPatternIdentifiers.FontSizeAttribute");
        public static readonly AutomationTextAttribute FontWeightAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_FontWeight_Attribute, "TextPatternIdentifiers.FontWeightAttribute");
        public static readonly AutomationTextAttribute ForegroundColorAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_ForegroundColor_Attribute, "TextPatternIdentifiers.ForegroundColorAttribute");
        public static readonly AutomationTextAttribute HorizontalTextAlignmentAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_HorizontalTextAlignment_Attribute, "TextPatternIdentifiers.HorizontalTextAlignmentAttribute");
        public static readonly AutomationTextAttribute IndentationFirstLineAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_IndentationFirstLine_Attribute, "TextPatternIdentifiers.IndentationFirstLineAttribute");
        public static readonly AutomationTextAttribute IndentationLeadingAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_IndentationLeading_Attribute, "TextPatternIdentifiers.IndentationLeadingAttribute");
        public static readonly AutomationTextAttribute IndentationTrailingAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_IndentationTrailing_Attribute, "TextPatternIdentifiers.IndentationTrailingAttribute");
        public static readonly AutomationTextAttribute IsHiddenAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_IsHidden_Attribute, "TextPatternIdentifiers.IsHiddenAttribute");
        public static readonly AutomationTextAttribute IsItalicAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_IsItalic_Attribute, "TextPatternIdentifiers.IsItalicAttribute");
        public static readonly AutomationTextAttribute IsReadOnlyAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_IsReadOnly_Attribute, "TextPatternIdentifiers.IsReadOnlyAttribute");
        public static readonly AutomationTextAttribute IsSubscriptAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_IsSubscript_Attribute, "TextPatternIdentifiers.IsSubscriptAttribute");
        public static readonly AutomationTextAttribute IsSuperscriptAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_IsSuperscript_Attribute, "TextPatternIdentifiers.IsSuperscriptAttribute");
        public static readonly AutomationTextAttribute MarginBottomAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_MarginBottom_Attribute, "TextPatternIdentifiers.MarginBottomAttribute");
        public static readonly AutomationTextAttribute MarginLeadingAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_MarginLeading_Attribute, "TextPatternIdentifiers.MarginLeadingAttribute");
        public static readonly AutomationTextAttribute MarginTopAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_MarginTop_Attribute, "TextPatternIdentifiers.MarginTopAttribute");
        public static readonly AutomationTextAttribute MarginTrailingAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_MarginTrailing_Attribute, "TextPatternIdentifiers.MarginTrailingAttribute");
        public static readonly object MixedAttributeValue = Automation.Factory.ReservedMixedAttributeValue;
        public static readonly AutomationTextAttribute OutlineStylesAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_OutlineStyles_Attribute, "TextPatternIdentifiers.OutlineStylesAttribute");
        public static readonly AutomationTextAttribute OverlineColorAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_OverlineColor_Attribute, "TextPatternIdentifiers.OverlineColorAttribute");
        public static readonly AutomationTextAttribute OverlineStyleAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_OverlineStyle_Attribute, "TextPatternIdentifiers.OverlineStyleAttribute");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.Text_Pattern, "TextPatternIdentifiers.Pattern");
        public static readonly AutomationTextAttribute StrikethroughColorAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_StrikethroughColor_Attribute, "TextPatternIdentifiers.StrikethroughColorAttribute");
        public static readonly AutomationTextAttribute StrikethroughStyleAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_StrikethroughStyle_Attribute, "TextPatternIdentifiers.StrikethroughStyleAttribute");
        public static readonly AutomationTextAttribute TabsAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_Tabs_Attribute, "TextPatternIdentifiers.TabsAttribute");
        public static readonly AutomationEvent TextChangedEvent = AutomationEvent.Register(AutomationIdentifierGuids.Text_TextChanged_Event, "TextPatternIdentifiers.TextChangedEvent");
        public static readonly AutomationTextAttribute TextFlowDirectionsAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_FlowDirections_Attribute, "TextPatternIdentifiers.TextFlowDirectionsAttribute");
        public static readonly AutomationEvent TextSelectionChangedEvent = AutomationEvent.Register(AutomationIdentifierGuids.Text_TextSelectionChanged_Event, "TextPatternIdentifiers.TextSelectionChangedEvent");
        public static readonly AutomationTextAttribute UnderlineColorAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_UnderlineColor_Attribute, "TextPatternIdentifiers.UnderlineColorAttribute");
        public static readonly AutomationTextAttribute UnderlineStyleAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_UnderlineStyle_Attribute, "TextPatternIdentifiers.UnderlineStyleAttribute");
    }

    public static class TogglePatternIdentifiers
    {
        
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.Toggle_Pattern, "TogglePatternIdentifiers.Pattern");
        public static readonly AutomationProperty ToggleStateProperty = AutomationProperty.Register(AutomationIdentifierGuids.Toggle_State_Property, "TogglePatternIdentifiers.ToggleStateProperty");
    }

    public static class TransformPatternIdentifiers
    {
        
        public static readonly AutomationProperty CanMoveProperty = AutomationProperty.Register(AutomationIdentifierGuids.Transform_CanMove_Property, "TransformPatternIdentifiers.CanMoveProperty");
        public static readonly AutomationProperty CanResizeProperty = AutomationProperty.Register(AutomationIdentifierGuids.Transform_CanResize_Property, "TransformPatternIdentifiers.CanResizeProperty");
        public static readonly AutomationProperty CanRotateProperty = AutomationProperty.Register(AutomationIdentifierGuids.Transform_CanRotate_Property, "TransformPatternIdentifiers.CanRotateProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.Transform_Pattern, "TransformPatternIdentifiers.Pattern");
    }

    public static class ValuePatternIdentifiers
    {
        
        public static readonly AutomationProperty IsReadOnlyProperty = AutomationProperty.Register(AutomationIdentifierGuids.Value_IsReadOnly_Property, "ValuePatternIdentifiers.IsReadOnlyProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.Value_Pattern, "ValuePatternIdentifiers.Pattern");
        public static readonly AutomationProperty ValueProperty = AutomationProperty.Register(AutomationIdentifierGuids.Value_Property, "ValuePatternIdentifiers.ValueProperty");
    }

    public static class WindowPatternIdentifiers
    {
        
        public static readonly AutomationProperty CanMaximizeProperty = AutomationProperty.Register(AutomationIdentifierGuids.Window_CanMaximize_Property, "WindowPatternIdentifiers.CanMaximizeProperty");
        public static readonly AutomationProperty CanMinimizeProperty = AutomationProperty.Register(AutomationIdentifierGuids.Window_CanMinimize_Property, "WindowPatternIdentifiers.CanMinimizeProperty");
        public static readonly AutomationProperty IsModalProperty = AutomationProperty.Register(AutomationIdentifierGuids.Window_IsModal_Property, "WindowPatternIdentifiers.IsModalProperty");
        public static readonly AutomationProperty IsTopmostProperty = AutomationProperty.Register(AutomationIdentifierGuids.Window_IsTopmost_Property, "WindowPatternIdentifiers.IsTopmostProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.Window_Pattern, "WindowPatternIdentifiers.Pattern");
        public static readonly AutomationEvent WindowClosedEvent = AutomationEvent.Register(AutomationIdentifierGuids.Window_Closed_Event, "WindowPatternIdentifiers.WindowClosedProperty");
        public static readonly AutomationProperty WindowInteractionStateProperty = AutomationProperty.Register(AutomationIdentifierGuids.Window_InteractionState_Property, "WindowPatternIdentifiers.WindowInteractionStateProperty");
        public static readonly AutomationEvent WindowOpenedEvent = AutomationEvent.Register(AutomationIdentifierGuids.Window_Opened_Event, "WindowPatternIdentifiers.WindowOpenedProperty");
        public static readonly AutomationProperty WindowVisualStateProperty = AutomationProperty.Register(AutomationIdentifierGuids.Window_VisualState_Property, "WindowPatternIdentifiers.WindowVisualStateProperty");
    }

    // New for Windows 7
    //
    public static class LegacyIAccessiblePatternIdentifiers
    {
        public static readonly AutomationProperty ChildIdProperty = AutomationProperty.Register(AutomationIdentifierGuids.LegacyIAccessible_ChildId_Property, "LegacyIAccessiblePatternIdentifiers.ChildIdProperty");
        public static readonly AutomationProperty NameProperty = AutomationProperty.Register(AutomationIdentifierGuids.LegacyIAccessible_Name_Property, "LegacyIAccessiblePatternIdentifiers.NameProperty");
        public static readonly AutomationProperty ValueProperty = AutomationProperty.Register(AutomationIdentifierGuids.LegacyIAccessible_Value_Property, "LegacyIAccessiblePatternIdentifiers.ValueProperty");
        public static readonly AutomationProperty DescriptionProperty = AutomationProperty.Register(AutomationIdentifierGuids.LegacyIAccessible_Description_Property, "LegacyIAccessiblePatternIdentifiers.DescriptionProperty");
        public static readonly AutomationProperty RoleProperty = AutomationProperty.Register(AutomationIdentifierGuids.LegacyIAccessible_Role_Property, "LegacyIAccessiblePatternIdentifiers.RoleProperty");
        public static readonly AutomationProperty StateProperty = AutomationProperty.Register(AutomationIdentifierGuids.LegacyIAccessible_State_Property, "LegacyIAccessiblePatternIdentifiers.StateProperty");
        public static readonly AutomationProperty HelpProperty = AutomationProperty.Register(AutomationIdentifierGuids.LegacyIAccessible_Help_Property, "LegacyIAccessiblePatternIdentifiers.HelpProperty");
        public static readonly AutomationProperty KeyboardShortcutProperty = AutomationProperty.Register(AutomationIdentifierGuids.LegacyIAccessible_KeyboardShortcut_Property, "LegacyIAccessiblePatternIdentifiers.KeyboardShortcutProperty");
        public static readonly AutomationProperty SelectionProperty = AutomationProperty.Register(AutomationIdentifierGuids.LegacyIAccessible_Selection_Property, "LegacyIAccessiblePatternIdentifiers.SelectionProperty");
        public static readonly AutomationProperty DefaultActionProperty = AutomationProperty.Register(AutomationIdentifierGuids.LegacyIAccessible_DefaultAction_Property, "LegacyIAccessiblePatternIdentifiers.DefaultActionProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.LegacyIAccessible_Pattern, "LegacyIAccessiblePatternIdentifiers.Pattern");
    }

    public static class ItemContainerPatternIdentifiers
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.ItemContainer_Pattern, "ItemContainerPatternIdentifiers.Pattern");
    }

    public static class VirtualizedItemPatternIdentifiers
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.VirtualizedItem_Pattern, "VirtualizedItemPatternIdentifiers.Pattern");
    }

    public static class SynchronizedInputPatternIdentifiers
    {
        public static readonly AutomationEvent InputReachedTargetEvent = AutomationEvent.Register(AutomationIdentifierGuids.SynchronizedInput_InputReachedTarget_Event, "SynchronizedInputPatternIdentifiers.InputReachedTargetEvent");
        public static readonly AutomationEvent InputReachedOtherElementEvent = AutomationEvent.Register(AutomationIdentifierGuids.SynchronizedInput_InputReachedOtherElement_Event, "SynchronizedInputPatternIdentifiers.InputReachedOtherElementEvent");
        public static readonly AutomationEvent InputDiscardedEvent = AutomationEvent.Register(AutomationIdentifierGuids.SynchronizedInput_InputDiscarded_Event, "SynchronizedInputPatternIdentifiers.InputDiscardedEvent");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.SynchronizedInput_Pattern, "SynchronizedInputPatternIdentifiers.Pattern");
    }

    // New for Windows 8
    //

    public static class ObjectModelPatternIdentifiers
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.ObjectModel_Pattern, "ObjectModelPatternIdentifiers.Pattern");
    }

    public static class AnnotationPatternIdentifiers
    {
        public static readonly AutomationProperty AnnotationTypeIdProperty = AutomationProperty.Register(AutomationIdentifierGuids.Annotation_AnnotationTypeId_Property, "AnnotationPatternIdentifiers.AnnotationTypeIdProperty");
        public static readonly AutomationProperty AnnotationTypeNameProperty = AutomationProperty.Register(AutomationIdentifierGuids.Annotation_AnnotationTypeName_Property, "AnnotationPatternIdentifiers.AnnotationTypeNameProperty");
        public static readonly AutomationProperty AuthorProperty = AutomationProperty.Register(AutomationIdentifierGuids.Annotation_Author_Property, "AnnotationPatternIdentifiers.AuthorProperty");
        public static readonly AutomationProperty DateTimeProperty = AutomationProperty.Register(AutomationIdentifierGuids.Annotation_DateTime_Property, "AnnotationPatternIdentifiers.DateTimeProperty");
        public static readonly AutomationProperty TargetProperty = AutomationProperty.Register(AutomationIdentifierGuids.Annotation_Target_Property, "AnnotationPatternIdentifiers.TargetProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.Annotation_Pattern, "AnnotationPatternIdentifiers.Pattern");
    }

    public static class TextPattern2Identifiers
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.Text_Pattern2, "TextPattern2Identifiers.Pattern");
        public static readonly AutomationTextAttribute AnnotationTypesAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_AnnotationTypes_Attribute, "TextPatternIdentifiers.AnnotationTypesAttribute");
        public static readonly AutomationTextAttribute AnnotationObjectsAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_AnnotationObjects_Attribute, "TextPatternIdentifiers.AnnotationObjectsAttribute");
        public static readonly AutomationTextAttribute StyleNameAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_StyleName_Attribute, "TextPatternIdentifiers.StyleNameAttribute");
        public static readonly AutomationTextAttribute StyleIdAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_StyleId_Attribute, "TextPatternIdentifiers.StyleIdAttribute");
        public static readonly AutomationTextAttribute LinkAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_Link_Attribute, "TextPatternIdentifiers.LinkAttribute");
        public static readonly AutomationTextAttribute IsActiveAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_IsActive_Attribute, "TextPatternIdentifiers.IsActiveAttribute");
        public static readonly AutomationTextAttribute SelectionActiveEndAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_SelectionActiveEnd_Attribute, "TextPatternIdentifiers.SelectionActiveEndAttribute");
        public static readonly AutomationTextAttribute CaretPositionAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_CaretPosition_Attribute, "TextPatternIdentifiers.CaretPositionAttribute");
        public static readonly AutomationTextAttribute CaretBidiModeAttribute = AutomationTextAttribute.Register(AutomationIdentifierGuids.Text_CaretBidiMode_Attribute, "TextPatternIdentifiers.CaretBidiModeAttribute");
    }

    public static class StylesPatternIdentifiers
    {        
        public static readonly AutomationProperty StyleIdProperty = AutomationProperty.Register(AutomationIdentifierGuids.Styles_StyleId_Property, "StylesPatternIdentifiers.StyleIdProperty");
        public static readonly AutomationProperty StyleNameProperty = AutomationProperty.Register(AutomationIdentifierGuids.Styles_StyleName_Property, "StylesPatternIdentifiers.StyleNameProperty");
        public static readonly AutomationProperty FillColorProperty = AutomationProperty.Register(AutomationIdentifierGuids.Styles_FillColor_Property, "StylesPatternIdentifiers.FillColorProperty");
        public static readonly AutomationProperty FillPatternStyleProperty = AutomationProperty.Register(AutomationIdentifierGuids.Styles_FillPatternStyle_Property, "StylesPatternIdentifiers.FillPatternStyleProperty");
        public static readonly AutomationProperty ShapeProperty = AutomationProperty.Register(AutomationIdentifierGuids.Styles_Shape_Property, "StylesPatternIdentifiers.ShapeProperty");
        public static readonly AutomationProperty FillPatternColorProperty = AutomationProperty.Register(AutomationIdentifierGuids.Styles_FillPatternColor_Property, "StylesPatternIdentifiers.FillPatternColorProperty");
        public static readonly AutomationProperty ExtendedPropertiesProperty = AutomationProperty.Register(AutomationIdentifierGuids.Styles_ExtendedProperties_Property, "StylesPatternIdentifiers.ExtendedPropertiesProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.Styles_Pattern, "StylesPatternIdentifiers.Pattern");

    }

    public static class SpreadsheetPatternIdentifiers
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.Spreadsheet_Pattern, "SpreadsheetPatternIdentifiers.Pattern");
    }

    public static class SpreadsheetItemPatternIdentifiers
    {
        public static readonly AutomationProperty FormulaProperty = AutomationProperty.Register(AutomationIdentifierGuids.SpreadsheetItem_Formula_Property, "SpreadsheetItemPatternIdentifiers.FormulaProperty");
        public static readonly AutomationProperty AnnotationObjectsProperty = AutomationProperty.Register(AutomationIdentifierGuids.SpreadsheetItem_AnnotationObjects_Property, "SpreadsheetItemPatternIdentifiers.AnnotationObjectsProperty");
        public static readonly AutomationProperty AnnotationTypesProperty = AutomationProperty.Register(AutomationIdentifierGuids.SpreadsheetItem_AnnotationTypes_Property, "SpreadsheetItemPatternIdentifiers.AnnotationTypesProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.SpreadsheetItem_Pattern, "SpreadsheetItemPatternIdentifiers.Pattern");
    }

    public static class TransformPattern2Identifiers
    {
        public static readonly AutomationProperty CanZoomProperty = AutomationProperty.Register(AutomationIdentifierGuids.Transform2_CanZoom_Property, "TransformPattern2Identifiers.CanZoomProperty");
        public static readonly AutomationProperty ZoomLevelProperty = AutomationProperty.Register(AutomationIdentifierGuids.Transform2_ZoomLevel_Property, "TransformPattern2Identifiers.ZoomLevelProperty");
        public static readonly AutomationProperty ZoomMinimumProperty = AutomationProperty.Register(AutomationIdentifierGuids.Transform2_ZoomMinimum_Property, "TransformPattern2Identifiers.ZoomMinimumProperty");
        public static readonly AutomationProperty ZoomMaximumProperty = AutomationProperty.Register(AutomationIdentifierGuids.Transform2_ZoomMaximum_Property, "TransformPattern2Identifiers.ZoomMaximumProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.Tranform_Pattern2, "TransformPattern2Identifiers.Pattern");
    }

    public static class TextChildPatternIdentifiers
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.TextChild_Pattern, "TextChildPatternIdentifiers.Pattern");
    }

    public static class DragPatternIdentifiers
    {
        public static readonly AutomationProperty IsGrabbedProperty = AutomationProperty.Register(AutomationIdentifierGuids.Drag_IsGrabbed_Property, "DragPatternIdentifiers.IsGrabbedProperty");
        public static readonly AutomationProperty GrabbedItemsProperty = AutomationProperty.Register(AutomationIdentifierGuids.Drag_GrabbedItems_Property, "DragPatternIdentifiers.GrabbedItemsProperty");
        public static readonly AutomationProperty DropEffectProperty = AutomationProperty.Register(AutomationIdentifierGuids.Drag_DropEffect_Property, "DragPatternIdentifiers.DropEffectProperty");
        public static readonly AutomationProperty DropEffectsProperty = AutomationProperty.Register(AutomationIdentifierGuids.Drag_DropEffects_Property, "DragPatternIdentifiers.DropEffectsProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.Drag_Pattern, "DragPatternIdentifiers.Pattern");
        public static readonly AutomationEvent DragStartEvent = AutomationEvent.Register(AutomationIdentifierGuids.Drag_DragStart_Event, "DragPatternIdentifiers.DragStartEvent");
        public static readonly AutomationEvent DragCancelEvent = AutomationEvent.Register(AutomationIdentifierGuids.Drag_DragCancel_Event, "DragPatternIdentifiers.DragCancelEvent");
        public static readonly AutomationEvent DragCompleteEvent = AutomationEvent.Register(AutomationIdentifierGuids.Drag_DragComplete_Event, "DragPatternIdentifiers.DragCompleteEvent");
    }

    public static class DropTargetPatternIdentifiers
    {
        public static readonly AutomationProperty DropTargetEffectProperty = AutomationProperty.Register(AutomationIdentifierGuids.DropTarget_DropTargetEffect_Property, "DropTargetPatternIdentifiers.DropTargetEffectProperty");
        public static readonly AutomationProperty DropTargetEffectsProperty = AutomationProperty.Register(AutomationIdentifierGuids.DropTarget_DropTargetEffects_Property, "DropTargetPatternIdentifiers.DropTargetEffectsProperty");
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(AutomationIdentifierGuids.DropTarget_Pattern, "DropTargetPatternIdentifiers.Pattern");
        public static readonly AutomationEvent DragEnterEvent = AutomationEvent.Register(AutomationIdentifierGuids.DropTarget_DragEnter_Event, "DropTargetPatternIdentifiers.DragEnterEvent");
        public static readonly AutomationEvent DragLeaveEvent = AutomationEvent.Register(AutomationIdentifierGuids.DropTarget_DragLeave_Event, "DropTargetPatternIdentifiers.DragLeaveEvent");
        public static readonly AutomationEvent DroppedEvent = AutomationEvent.Register(AutomationIdentifierGuids.DropTarget_Dropped_Event, "DropTargetPatternIdentifiers.DroppedEvent");
    }

    #endregion

    #region Identifier classes
    
    /// <summary>
    /// Core Automation Identifier - essentially a wrapped integer
    /// </summary>
    public class AutomationIdentifier : IComparable
    {
        
        private Guid _guid;
        private int _id;
        private static Hashtable _identifierDirectory = new Hashtable(200, 1f);
        private string _programmaticName;
        private UiaCoreIds.AutomationIdType _type;

        
        internal AutomationIdentifier(UiaCoreIds.AutomationIdType type, int id, Guid guid, string programmaticName)
        {
            this._id = id;
            this._type = type;
            this._guid = guid;
            this._programmaticName = programmaticName;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            return (this.GetHashCode() - obj.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            AutomationIdentifier objAutomationIdentifier;
            if (obj == null || (objAutomationIdentifier = (obj as AutomationIdentifier)) == null)
            {
                return false;
            }

            return (objAutomationIdentifier == this);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        internal static AutomationIdentifier LookupById(UiaCoreIds.AutomationIdType type, int id)
        {
            AutomationIdentifier identifier;
            lock (_identifierDirectory)
            {
                identifier = (AutomationIdentifier)_identifierDirectory[id];
            }
            if (identifier == null)
            {
                return null;
            }
            if (identifier._type != type)
            {
                return null;
            }
            return identifier;
        }

        internal static AutomationIdentifier Register(UiaCoreIds.AutomationIdType type, Guid guid, string programmaticName)
        {
            int id = UiaCoreIds.UiaLookupId(type, ref guid);
            if (id == 0)
            {
                return null;
            }
            lock (_identifierDirectory)
            {
                AutomationIdentifier identifier = (AutomationIdentifier)_identifierDirectory[guid];
                if (identifier == null)
                {
                    switch (type)
                    {
                        case UiaCoreIds.AutomationIdType.Property:
                            identifier = new AutomationProperty(id, guid, programmaticName);
                            break;

                        case UiaCoreIds.AutomationIdType.Pattern:
                            identifier = new AutomationPattern(id, guid, programmaticName);
                            break;

                        case UiaCoreIds.AutomationIdType.Event:
                            identifier = new AutomationEvent(id, guid, programmaticName);
                            break;

                        case UiaCoreIds.AutomationIdType.ControlType:
                            identifier = new ControlType(id, guid, programmaticName);
                            break;

                        case UiaCoreIds.AutomationIdType.TextAttribute:
                            identifier = new AutomationTextAttribute(id, guid, programmaticName);
                            break;

                        default:
                            throw new InvalidOperationException("Invalid type specified for AutomationIdentifier");
                    }
                    _identifierDirectory[id] = identifier;
                }
                return identifier;
            }
        }

        
        public int Id
        {
            get
            {
                return this._id;
            }
        }

        public string ProgrammaticName
        {
            get
            {
                return this._programmaticName;
            }
        }
    }

    public class AutomationEvent : AutomationIdentifier
    {
        
        internal AutomationEvent(int id, Guid guid, string programmaticName)
            : base(UiaCoreIds.AutomationIdType.Event, id, guid, programmaticName)
        {
        }

        public static AutomationEvent LookupById(int id)
        {
            return (AutomationEvent)AutomationIdentifier.LookupById(UiaCoreIds.AutomationIdType.Event, id);
        }

        internal static AutomationEvent Register(Guid guid, string programmaticName)
        {
            return (AutomationEvent)AutomationIdentifier.Register(UiaCoreIds.AutomationIdType.Event, guid, programmaticName);
        }
    }

    public class AutomationPattern : AutomationIdentifier
    {
        
        internal AutomationPattern(int id, Guid guid, string programmaticName)
            : base(UiaCoreIds.AutomationIdType.Pattern, id, guid, programmaticName)
        {
        }

        public static AutomationPattern LookupById(int id)
        {
            return (AutomationPattern)AutomationIdentifier.LookupById(UiaCoreIds.AutomationIdType.Pattern, id);
        }

        internal static AutomationPattern Register(Guid guid, string programmaticName)
        {
            return (AutomationPattern)AutomationIdentifier.Register(UiaCoreIds.AutomationIdType.Pattern, guid, programmaticName);
        }
    }


    public class AutomationProperty : AutomationIdentifier
    {
        
        internal AutomationProperty(int id, Guid guid, string programmaticName)
            : base(UiaCoreIds.AutomationIdType.Property, id, guid, programmaticName)
        {
        }

        public static AutomationProperty LookupById(int id)
        {
            return (AutomationProperty)AutomationIdentifier.LookupById(UiaCoreIds.AutomationIdType.Property, id);
        }

        internal static AutomationProperty Register(Guid guid, string programmaticName)
        {
            return (AutomationProperty)AutomationIdentifier.Register(UiaCoreIds.AutomationIdType.Property, guid, programmaticName);
        }
    }

    public class AutomationTextAttribute : AutomationIdentifier
    {
        
        internal AutomationTextAttribute(int id, Guid guid, string programmaticName)
            : base(UiaCoreIds.AutomationIdType.TextAttribute, id, guid, programmaticName)
        {
        }

        public static AutomationTextAttribute LookupById(int id)
        {
            return (AutomationTextAttribute)AutomationIdentifier.LookupById(UiaCoreIds.AutomationIdType.TextAttribute, id);
        }

        internal static AutomationTextAttribute Register(Guid guid, string programmaticName)
        {
            return (AutomationTextAttribute)AutomationIdentifier.Register(UiaCoreIds.AutomationIdType.TextAttribute, guid, programmaticName);
        }
    }

    public class ControlType : AutomationIdentifier
    {
        /// <summary>
        /// Ensures the types are not marked with the beforefieldinit flag (causing lazy initialization).
        /// This ensures the registration (mapping) of the control GUIDs to the Uia_ControlIds is  
        /// guaranteed to exist during first access of the '_identifierDirectory' via ControlType.LookupById()
        /// Note on the static constructor performance: The performance points measured typically depend on 
        /// the initialization that goes with the type initialization. So if that's within permissible limits, 
        /// in this case the Register() calls for the controltypes which aren't expensive, having static
        /// constructor isn't that bad. Follow link for more details.
        /// http://coderjournal.com/2009/08/static-constructors-in-net-3-5-still-a-bad-thing/
        /// </summary>
        static ControlType() { }

        private AutomationPattern[] _neverSupportedPatterns;
        private AutomationPattern[][] _requiredPatternsSets;
        private AutomationProperty[] _requiredProperties;
        public static readonly ControlType Button = Register(AutomationIdentifierGuids.Button_Control, "ControlType.Button", new AutomationPattern[][] { new AutomationPattern[] { InvokePatternIdentifiers.Pattern } });
        public static readonly ControlType Calendar = Register(AutomationIdentifierGuids.Calendar_Control, "ControlType.Calendar", new AutomationPattern[][] { new AutomationPattern[] { GridPatternIdentifiers.Pattern, ValuePatternIdentifiers.Pattern, SelectionPatternIdentifiers.Pattern } });
        public static readonly ControlType CheckBox = Register(AutomationIdentifierGuids.CheckBox_Control, "ControlType.CheckBox", new AutomationPattern[][] { new AutomationPattern[] { TogglePatternIdentifiers.Pattern } });
        public static readonly ControlType ComboBox = Register(AutomationIdentifierGuids.ComboBox_Control, "ControlType.ComboBox", new AutomationPattern[][] { new AutomationPattern[] { SelectionPatternIdentifiers.Pattern, ExpandCollapsePatternIdentifiers.Pattern } });
        public static readonly ControlType Custom = Register(AutomationIdentifierGuids.Custom_Control, "ControlType.Custom");
        public static readonly ControlType DataGrid = Register(AutomationIdentifierGuids.DataGrid_Control, "ControlType.DataGrid", new AutomationPattern[][] { new AutomationPattern[] { GridPatternIdentifiers.Pattern }, new AutomationPattern[] { SelectionPatternIdentifiers.Pattern }, new AutomationPattern[] { TablePatternIdentifiers.Pattern } });
        public static readonly ControlType DataItem = Register(AutomationIdentifierGuids.DataItem_Control, "ControlType.DataItem", new AutomationPattern[][] { new AutomationPattern[] { SelectionItemPatternIdentifiers.Pattern } });
        public static readonly ControlType Document = Register(AutomationIdentifierGuids.Document_Control, "ControlType.Document", new AutomationProperty[0], new AutomationPattern[] { ValuePatternIdentifiers.Pattern }, new AutomationPattern[][] { new AutomationPattern[] { ScrollPatternIdentifiers.Pattern }, new AutomationPattern[] { TextPatternIdentifiers.Pattern } });
        public static readonly ControlType Edit = Register(AutomationIdentifierGuids.Edit_Control, "ControlType.Edit", new AutomationPattern[][] { new AutomationPattern[] { ValuePatternIdentifiers.Pattern } });
        public static readonly ControlType Group = Register(AutomationIdentifierGuids.Group_Control, "ControlType.Group");
        public static readonly ControlType Header = Register(AutomationIdentifierGuids.Header_Control, "ControlType.Header");
        public static readonly ControlType HeaderItem = Register(AutomationIdentifierGuids.HeaderItem_Control, "ControlType.HeaderItem");
        public static readonly ControlType Hyperlink = Register(AutomationIdentifierGuids.Hyperlink_Control, "ControlType.Hyperlink", new AutomationPattern[][] { new AutomationPattern[] { InvokePatternIdentifiers.Pattern } });
        public static readonly ControlType Image = Register(AutomationIdentifierGuids.Image_Control, "ControlType.Image");
        public static readonly ControlType List = Register(AutomationIdentifierGuids.List_Control, "ControlType.List", new AutomationPattern[][] { new AutomationPattern[] { SelectionPatternIdentifiers.Pattern, TablePatternIdentifiers.Pattern, GridPatternIdentifiers.Pattern, MultipleViewPatternIdentifiers.Pattern } });
        public static readonly ControlType ListItem = Register(AutomationIdentifierGuids.ListItem_Control, "ControlType.ListItem", new AutomationPattern[][] { new AutomationPattern[] { SelectionItemPatternIdentifiers.Pattern } });
        public static readonly ControlType Menu = Register(AutomationIdentifierGuids.Menu_Control, "ControlType.Menu");
        public static readonly ControlType MenuBar = Register(AutomationIdentifierGuids.MenuBar_Control, "ControlType.MenuBar");
        public static readonly ControlType MenuItem = Register(AutomationIdentifierGuids.MenuItem_Control, "ControlType.MenuItem", new AutomationPattern[][] { new AutomationPattern[] { InvokePatternIdentifiers.Pattern }, new AutomationPattern[] { ExpandCollapsePatternIdentifiers.Pattern }, new AutomationPattern[] { TogglePatternIdentifiers.Pattern } });
        public static readonly ControlType Pane = Register(AutomationIdentifierGuids.Pane_Control, "ControlType.Pane", new AutomationPattern[][] { new AutomationPattern[] { TransformPatternIdentifiers.Pattern } });
        public static readonly ControlType ProgressBar = Register(AutomationIdentifierGuids.ProgressBar_Control, "ControlType.ProgressBar", new AutomationPattern[][] { new AutomationPattern[] { ValuePatternIdentifiers.Pattern } });
        public static readonly ControlType RadioButton = Register(AutomationIdentifierGuids.RadioButton_Control, "ControlType.RadioButton");
        public static readonly ControlType ScrollBar = Register(AutomationIdentifierGuids.ScrollBar_Control, "ControlType.ScrollBar");
        public static readonly ControlType Separator = Register(AutomationIdentifierGuids.Separator_Control, "ControlType.Separator");
        public static readonly ControlType Slider = Register(AutomationIdentifierGuids.Slider_Control, "ControlType.Slider", new AutomationPattern[][] { new AutomationPattern[] { RangeValuePatternIdentifiers.Pattern }, new AutomationPattern[] { SelectionPatternIdentifiers.Pattern } });
        public static readonly ControlType Spinner = Register(AutomationIdentifierGuids.Spinner_Control, "ControlType.Spinner", new AutomationPattern[][] { new AutomationPattern[] { RangeValuePatternIdentifiers.Pattern }, new AutomationPattern[] { SelectionPatternIdentifiers.Pattern } });
        public static readonly ControlType SplitButton = Register(AutomationIdentifierGuids.SplitButton_Control, "ControlType.SplitButton", new AutomationPattern[][] { new AutomationPattern[] { InvokePatternIdentifiers.Pattern }, new AutomationPattern[] { ExpandCollapsePatternIdentifiers.Pattern } });
        public static readonly ControlType StatusBar = Register(AutomationIdentifierGuids.StatusBar_Control, "ControlType.StatusBar");
        public static readonly ControlType Tab = Register(AutomationIdentifierGuids.Tab_Control, "ControlType.Tab");
        public static readonly ControlType TabItem = Register(AutomationIdentifierGuids.TabItem_Control, "ControlType.TabItem");
        public static readonly ControlType Table = Register(AutomationIdentifierGuids.Table_Control, "ControlType.Table", new AutomationPattern[][] { new AutomationPattern[] { GridPatternIdentifiers.Pattern }, new AutomationPattern[] { SelectionPatternIdentifiers.Pattern }, new AutomationPattern[] { TablePatternIdentifiers.Pattern } });
        public static readonly ControlType Text = Register(AutomationIdentifierGuids.Text_Control, "ControlType.Text");
        public static readonly ControlType Thumb = Register(AutomationIdentifierGuids.Thumb_Control, "ControlType.Thumb");
        public static readonly ControlType TitleBar = Register(AutomationIdentifierGuids.TitleBar_Control, "ControlType.TitleBar");
        public static readonly ControlType ToolBar = Register(AutomationIdentifierGuids.ToolBar_Control, "ControlType.ToolBar");
        public static readonly ControlType ToolTip = Register(AutomationIdentifierGuids.ToolTip_Control, "ControlType.ToolTip");
        public static readonly ControlType Tree = Register(AutomationIdentifierGuids.Tree_Control, "ControlType.Tree");
        public static readonly ControlType TreeItem = Register(AutomationIdentifierGuids.TreeItem_Control, "ControlType.TreeItem");
        public static readonly ControlType Window = Register(AutomationIdentifierGuids.Window_Control, "ControlType.Window", new AutomationPattern[][] { new AutomationPattern[] { TransformPatternIdentifiers.Pattern }, new AutomationPattern[] { WindowPatternIdentifiers.Pattern } });

        
        internal ControlType(int id, Guid guid, string programmaticName)
            : base(UiaCoreIds.AutomationIdType.ControlType, id, guid, programmaticName)
        {
        }

        public AutomationPattern[] GetNeverSupportedPatterns()
        {
            return (AutomationPattern[])this._neverSupportedPatterns.Clone();
        }

        public AutomationPattern[][] GetRequiredPatternSets()
        {
            int length = this._requiredPatternsSets.Length;
            AutomationPattern[][] patternArray = new AutomationPattern[length][];
            for (int i = 0; i < length; i++)
            {
                patternArray[i] = (AutomationPattern[])this._requiredPatternsSets[i].Clone();
            }
            return patternArray;
        }

        public AutomationProperty[] GetRequiredProperties()
        {
            return (AutomationProperty[])this._requiredProperties.Clone();
        }

        public static ControlType LookupById(int id)
        {
            return (ControlType)AutomationIdentifier.LookupById(UiaCoreIds.AutomationIdType.ControlType, id);
        }

        internal static ControlType Register(Guid guid, string programmaticName)
        {
            return (ControlType)AutomationIdentifier.Register(UiaCoreIds.AutomationIdType.ControlType, guid, programmaticName);
        }

        internal static ControlType Register(Guid guid, string programmaticName, AutomationProperty[] requiredProperties)
        {
            return Register(guid, programmaticName, requiredProperties, new AutomationPattern[0], new AutomationPattern[0][]);
        }

        internal static ControlType Register(Guid guid, string programmaticName, AutomationPattern[][] requiredPatternsSets)
        {
            return Register(guid, programmaticName, new AutomationProperty[0], new AutomationPattern[0], requiredPatternsSets);
        }

        internal static ControlType Register(Guid guid, string programmaticName, AutomationProperty[] requiredProperties, AutomationPattern[] neverSupportedPatterns, AutomationPattern[][] requiredPatternsSets)
        {
            ControlType type = (ControlType)AutomationIdentifier.Register(UiaCoreIds.AutomationIdType.ControlType, guid, programmaticName);
            type._requiredPatternsSets = requiredPatternsSets;
            type._neverSupportedPatterns = neverSupportedPatterns;
            type._requiredProperties = requiredProperties;
            return type;
        }

        
        public string LocalizedControlType
        {
            get
            {
                throw new NotImplementedException("UI Automation COM API does not have a matching method");
            }
        }
    }

    #endregion

    #region Exceptions

    [Serializable]
    public class ElementNotAvailableException : SystemException
    {
        public ElementNotAvailableException()
            : base("Element not available")
        {
            base.HResult = UiaCoreIds.UIA_E_ELEMENTNOTAVAILABLE;
        }

        public ElementNotAvailableException(Exception innerException)
            : base("Element not available", innerException)
        {
            base.HResult = UiaCoreIds.UIA_E_ELEMENTNOTAVAILABLE;
        }

        public ElementNotAvailableException(string message)
            : base(message)
        {
            base.HResult = UiaCoreIds.UIA_E_ELEMENTNOTAVAILABLE;
        }

        protected ElementNotAvailableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            base.HResult = UiaCoreIds.UIA_E_ELEMENTNOTAVAILABLE;
        }

        public ElementNotAvailableException(string message, Exception innerException)
            : base(message, innerException)
        {
            base.HResult = UiaCoreIds.UIA_E_ELEMENTNOTAVAILABLE;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }


    [Serializable]
    public class ElementNotEnabledException : InvalidOperationException
    {
        public ElementNotEnabledException()
            : base("Element not enabled")
        {
            base.HResult = UiaCoreIds.UIA_E_ELEMENTNOTENABLED;
        }

        public ElementNotEnabledException(Exception innerException)
            : base("Element not enabled", innerException)
        {
            base.HResult = UiaCoreIds.UIA_E_ELEMENTNOTENABLED;
        }

        public ElementNotEnabledException(string message)
            : base(message)
        {
            base.HResult = UiaCoreIds.UIA_E_ELEMENTNOTENABLED;
        }

        protected ElementNotEnabledException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            base.HResult = UiaCoreIds.UIA_E_ELEMENTNOTENABLED;
        }

        public ElementNotEnabledException(string message, Exception innerException)
            : base(message, innerException)
        {
            base.HResult = UiaCoreIds.UIA_E_ELEMENTNOTENABLED;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }

    [Serializable]
    public class NoClickablePointException : Exception
    {
        
        public NoClickablePointException()
        {
        }

        public NoClickablePointException(Exception innerException) :
            base(String.Empty, innerException)
        {
        }

        public NoClickablePointException(string message)
            : base(message)
        {
        }

        protected NoClickablePointException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public NoClickablePointException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }

    [Serializable]
    public class ProxyAssemblyNotLoadedException : Exception
    {
        
        public ProxyAssemblyNotLoadedException()
        {
        }

        public ProxyAssemblyNotLoadedException(Exception innerException) :
            base(String.Empty, innerException)
        {
        }

        public ProxyAssemblyNotLoadedException(string message)
            : base(message)
        {
        }

        protected ProxyAssemblyNotLoadedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ProxyAssemblyNotLoadedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }

    #endregion

    #region Enums

    [Guid("70d46e77-e3a8-449d-913c-e30eb2afecdb"), ComVisible(true)]
    public enum DockPosition
    {
        Top,
        Left,
        Bottom,
        Right,
        Fill,
        None
    }

    [Guid("76d12d7e-b227-4417-9ce2-42642ffa896a"), ComVisible(true)]
    public enum ExpandCollapseState
    {
        Collapsed,
        Expanded,
        PartiallyExpanded,
        LeafNode
    }

    [Guid("5F8A77B4-E685-48c1-94D0-8BB6AFA43DF9"), ComVisible(true)]
    public enum OrientationType
    {
        None,
        Horizontal,
        Vertical
    }

    [ComVisible(true), Guid("15fdf2e2-9847-41cd-95dd-510612a025ea")]
    public enum RowOrColumnMajor
    {
        RowMajor,
        ColumnMajor,
        Indeterminate
    }

    [ComVisible(true), Guid("bd52d3c7-f990-4c52-9ae3-5c377e9eb772")]
    public enum ScrollAmount
    {
        LargeDecrement,
        SmallDecrement,
        NoAmount,
        LargeIncrement,
        SmallIncrement
    }

    [Flags, ComVisible(true), Guid("3d9e3d8f-bfb0-484f-84ab-93ff4280cbc4")]
    public enum SupportedTextSelection
    {
        None,
        Single,
        Multiple
    }

    [Guid("ad7db4af-7166-4478-a402-ad5b77eab2fa"), ComVisible(true)]
    public enum ToggleState
    {
        Off,
        On,
        Indeterminate
    }

    [Flags]
    public enum TreeScope
    {
        Element = 1,
        Children = 2,
        Descendants = 4,
        Subtree = 7,
        Parent = 8,
        Ancestors = 16,
    }

    [Guid("65101cc7-7904-408e-87a7-8c6dbd83a18b"), ComVisible(true)]
    public enum WindowInteractionState
    {
        Running,
        Closing,
        ReadyForUserInteraction,
        BlockedByModalWindow,
        NotResponding
    }

    [ComVisible(true), Guid("fdc8f176-aed2-477a-8c89-ea04cc5f278d")]
    public enum WindowVisualState
    {
        Normal,
        Maximized,
        Minimized
    }

    // New for Windows 7
    //

    [Flags]
    public enum SynchronizedInputType
    {
        KeyUp =         0x01,
        KeyDown =       0x02,
        LeftMouseUp =   0x04,
        LeftMouseDown = 0x08,
        RightMouseUp =  0x10,
        RightMouseDown =0x20
    };

    // New for Windows 8
    //

    public enum AnnotationType
    {
        Unknown = 0xEA60,
        SpellingError,
        GrammarError,
        Comment,
        FormulaError,
        TrackChanges,
        Header,
        Footer,
        Highlighted
    };

    public enum StyleId
    {
        Custom = 0x11170,
        Heading1,
        Heading2,
        Heading3,
        Heading4,
        Heading5,
        Heading6,
        Heading7,
        Heading8,
        Heading9,
        Title,
        Subtitle,
        Normal,
        Emphasis,
        Quote
    }

    public enum ZoomUnit
    {
        NoAmount = 0,
        LargeDecrement,
        SmallDecrement,
        LargeIncrement,
        SmallIncrement
    }

    public enum LiveSetting
    {
        Off = 0,
        Polite = 1,
        Assertive = 2
    };

    public enum ActiveEnd
    {
        None = 0,
        Start = 1,
        End = 2
    };

    public enum CaretPosition
    {
        Unknown = 0,
        EndOfLine = 1,
        BeginningOfLine = 2
    };

    public enum CaretBidiMode
    {
        LTR = 0,
        RTL = 1
    };

    #endregion

}