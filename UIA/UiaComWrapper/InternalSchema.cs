// (c) Copyright Microsoft, 2012.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.


using System;
using System.Globalization;
using System.Windows.Automation;
using System.Windows.Automation.Text;
using System.Windows;

namespace UIAComWrapperInternal
{
    internal delegate object PropertyConverter(object valueAsObject);
    internal delegate object PatternWrapper(AutomationElement el, object pattern, bool cached);

    internal class PropertyTypeInfo
    {
        
        private PropertyConverter _converter;
        private AutomationIdentifier _id;
        private Type _type;

        
        internal PropertyTypeInfo(PropertyConverter converter, AutomationIdentifier id, Type type)
        {
            this._id = id;
            this._type = type;
            this._converter = converter;
        }

        
        internal AutomationIdentifier ID
        {
            get
            {
                return this._id;
            }
        }

        internal PropertyConverter ObjectConverter
        {
            get
            {
                return this._converter;
            }
        }

        internal Type Type
        {
            get
            {
                return this._type;
            }
        }
    }

    internal class PatternTypeInfo
    {
        
        private PatternWrapper _clientSideWrapper;
        private AutomationPattern _id;

        
        public PatternTypeInfo(AutomationPattern id, PatternWrapper clientSideWrapper)
        {
            this._id = id;
            this._clientSideWrapper = clientSideWrapper;
        }

        
        internal PatternWrapper ClientSideWrapper
        {
            get
            {
                return this._clientSideWrapper;
            }
        }

        internal AutomationPattern ID
        {
            get
            {
                return this._id;
            }
        }
    }

    internal class Schema
    {
        
        private static PropertyConverter convertToBool = new PropertyConverter(Schema.ConvertToBool);
        private static PropertyConverter convertToControlType = new PropertyConverter(Schema.ConvertToControlType);
        private static PropertyConverter convertToCultureInfo = new PropertyConverter(Schema.ConvertToCultureInfo);
        private static PropertyConverter convertToDockPosition = new PropertyConverter(Schema.ConvertToDockPosition);
        private static PropertyConverter convertToElement = new PropertyConverter(Schema.ConvertToElement);
        private static PropertyConverter convertToElementArray = new PropertyConverter(Schema.ConvertToElementArray);
        private static PropertyConverter convertToExpandCollapseState = new PropertyConverter(Schema.ConvertToExpandCollapseState);
        private static PropertyConverter convertToOrientationType = new PropertyConverter(Schema.ConvertToOrientationType);
        private static PropertyConverter convertToPoint = new PropertyConverter(Schema.ConvertToPoint);
        private static PropertyConverter convertToRect = new PropertyConverter(Schema.ConvertToRect);
        private static PropertyConverter convertToRowOrColumnMajor = new PropertyConverter(Schema.ConvertToRowOrColumnMajor);
        private static PropertyConverter convertToToggleState = new PropertyConverter(Schema.ConvertToToggleState);
        private static PropertyConverter convertToWindowInteractionState = new PropertyConverter(Schema.ConvertToWindowInteractionState);
        private static PropertyConverter convertToWindowVisualState = new PropertyConverter(Schema.ConvertToWindowVisualState);
        private static PropertyConverter convertToAnnotationType = new PropertyConverter(Schema.ConvertToAnnotationType);
        private static PropertyConverter convertToStyleId = new PropertyConverter(Schema.ConvertToStyleId); 

        private static readonly PropertyTypeInfo[] _propertyInfoTable = new PropertyTypeInfo[] { 
            // Properties requiring conversion
            new PropertyTypeInfo(convertToRect, AutomationElement.BoundingRectangleProperty, typeof(Rect)), 
            new PropertyTypeInfo(convertToControlType, AutomationElement.ControlTypeProperty, typeof(ControlType)), 
            new PropertyTypeInfo(convertToPoint, AutomationElement.ClickablePointProperty, typeof(Point)), 
            new PropertyTypeInfo(convertToCultureInfo, AutomationElement.CultureProperty, typeof(CultureInfo)), 
            new PropertyTypeInfo(convertToOrientationType, AutomationElement.OrientationProperty, typeof(OrientationType)), 
            new PropertyTypeInfo(convertToDockPosition, DockPattern.DockPositionProperty, typeof(DockPosition)), 
            new PropertyTypeInfo(convertToExpandCollapseState, ExpandCollapsePattern.ExpandCollapseStateProperty, typeof(ExpandCollapseState)), 
            new PropertyTypeInfo(convertToWindowVisualState, WindowPattern.WindowVisualStateProperty, typeof(WindowVisualState)), 
            new PropertyTypeInfo(convertToWindowInteractionState, WindowPattern.WindowInteractionStateProperty, typeof(WindowInteractionState)), 
            new PropertyTypeInfo(convertToRowOrColumnMajor, TablePattern.RowOrColumnMajorProperty, typeof(RowOrColumnMajor)), 
            new PropertyTypeInfo(convertToToggleState, TogglePattern.ToggleStateProperty, typeof(ToggleState)), 
            new PropertyTypeInfo(convertToAnnotationType, AnnotationPattern.AnnotationTypeIdProperty, typeof(AnnotationType)),
            new PropertyTypeInfo(convertToStyleId, StylesPattern.StyleIdProperty, typeof(StyleId)),

            // Text attributes 
            new PropertyTypeInfo(null, TextPattern.AnimationStyleAttribute, typeof(AnimationStyle)), 
            new PropertyTypeInfo(null, TextPattern.BackgroundColorAttribute, typeof(int)), 
            new PropertyTypeInfo(null, TextPattern.BulletStyleAttribute, typeof(BulletStyle)), 
            new PropertyTypeInfo(null, TextPattern.CapStyleAttribute, typeof(CapStyle)), 
            new PropertyTypeInfo(convertToCultureInfo, TextPattern.CultureAttribute, typeof(CultureInfo)), 
            new PropertyTypeInfo(null, TextPattern.FontNameAttribute, typeof(string)), 
            new PropertyTypeInfo(null, TextPattern.FontSizeAttribute, typeof(double)), 
            new PropertyTypeInfo(null, TextPattern.FontWeightAttribute, typeof(int)), 
            new PropertyTypeInfo(null, TextPattern.ForegroundColorAttribute, typeof(int)), 
            new PropertyTypeInfo(null, TextPattern.HorizontalTextAlignmentAttribute, typeof(HorizontalTextAlignment)), 
            new PropertyTypeInfo(null, TextPattern.IndentationFirstLineAttribute, typeof(double)), 
            new PropertyTypeInfo(null, TextPattern.IndentationLeadingAttribute, typeof(double)), 
            new PropertyTypeInfo(null, TextPattern.IndentationTrailingAttribute, typeof(double)), 
            new PropertyTypeInfo(null, TextPattern.IsHiddenAttribute, typeof(bool)), new PropertyTypeInfo(null, TextPattern.IsItalicAttribute, typeof(bool)), 
            new PropertyTypeInfo(null, TextPattern.IsReadOnlyAttribute, typeof(bool)), 
            new PropertyTypeInfo(null, TextPattern.IsSubscriptAttribute, typeof(bool)), 
            new PropertyTypeInfo(null, TextPattern.IsSuperscriptAttribute, typeof(bool)), 
            new PropertyTypeInfo(null, TextPattern.MarginBottomAttribute, typeof(double)), 
            new PropertyTypeInfo(null, TextPattern.MarginLeadingAttribute, typeof(double)), 
            new PropertyTypeInfo(null, TextPattern.MarginTopAttribute, typeof(double)), 
            new PropertyTypeInfo(null, TextPattern.MarginTrailingAttribute, typeof(double)), 
            new PropertyTypeInfo(null, TextPattern.OutlineStylesAttribute, typeof(OutlineStyles)), 
            new PropertyTypeInfo(null, TextPattern.OverlineColorAttribute, typeof(int)), 
            new PropertyTypeInfo(null, TextPattern.OverlineStyleAttribute, typeof(TextDecorationLineStyle)), 
            new PropertyTypeInfo(null, TextPattern.StrikethroughColorAttribute, typeof(int)), 
            new PropertyTypeInfo(null, TextPattern.StrikethroughStyleAttribute, typeof(TextDecorationLineStyle)), 
            new PropertyTypeInfo(null, TextPattern.TabsAttribute, typeof(double[])), 
            new PropertyTypeInfo(null, TextPattern.TextFlowDirectionsAttribute, typeof(FlowDirections)), 
            new PropertyTypeInfo(null, TextPattern.UnderlineColorAttribute, typeof(int)), 
            new PropertyTypeInfo(null, TextPattern.UnderlineStyleAttribute, typeof(TextDecorationLineStyle)),
            new PropertyTypeInfo(null, TextPattern2.AnnotationTypesAttribute, typeof(AnnotationType[])),
            new PropertyTypeInfo(null, TextPattern2.AnnotationObjectsAttribute, typeof(AutomationElement[])),
            new PropertyTypeInfo(null, TextPattern2.StyleNameAttribute, typeof(string)),
            new PropertyTypeInfo(null, TextPattern2.StyleIdAttribute, typeof(StyleId)),
            new PropertyTypeInfo(null, TextPattern2.LinkAttribute, typeof(AutomationElement)),
            new PropertyTypeInfo(null, TextPattern2.IsActiveAttribute, typeof(bool)),
            new PropertyTypeInfo(null, TextPattern2.SelectionActiveEndAttribute, typeof(ActiveEnd)),
            new PropertyTypeInfo(null, TextPattern2.CaretPositionAttribute, typeof(CaretPosition)),
            new PropertyTypeInfo(null, TextPattern2.CaretBidiModeAttribute, typeof(CaretBidiMode))
        };

        private static readonly PatternTypeInfo[] _patternInfoTable = new PatternTypeInfo[] { 
            new PatternTypeInfo(InvokePattern.Pattern, new PatternWrapper(InvokePattern.Wrap)), 
            new PatternTypeInfo(SelectionPattern.Pattern, new PatternWrapper(SelectionPattern.Wrap)), 
            new PatternTypeInfo(ValuePattern.Pattern, new PatternWrapper(ValuePattern.Wrap)), 
            new PatternTypeInfo(RangeValuePattern.Pattern, new PatternWrapper(RangeValuePattern.Wrap)), 
            new PatternTypeInfo(ScrollPattern.Pattern, new PatternWrapper(ScrollPattern.Wrap)), 
            new PatternTypeInfo(ExpandCollapsePattern.Pattern, new PatternWrapper(ExpandCollapsePattern.Wrap)), 
            new PatternTypeInfo(GridPattern.Pattern, new PatternWrapper(GridPattern.Wrap)), 
            new PatternTypeInfo(GridItemPattern.Pattern, new PatternWrapper(GridItemPattern.Wrap)), 
            new PatternTypeInfo(MultipleViewPattern.Pattern, new PatternWrapper(MultipleViewPattern.Wrap)), 
            new PatternTypeInfo(WindowPattern.Pattern, new PatternWrapper(WindowPattern.Wrap)), 
            new PatternTypeInfo(SelectionItemPattern.Pattern, new PatternWrapper(SelectionItemPattern.Wrap)), 
            new PatternTypeInfo(DockPattern.Pattern, new PatternWrapper(DockPattern.Wrap)), 
            new PatternTypeInfo(TablePattern.Pattern, new PatternWrapper(TablePattern.Wrap)), 
            new PatternTypeInfo(TableItemPattern.Pattern, new PatternWrapper(TableItemPattern.Wrap)), 
            new PatternTypeInfo(TextPattern.Pattern, new PatternWrapper(TextPattern.Wrap)), 
            new PatternTypeInfo(TogglePattern.Pattern, new PatternWrapper(TogglePattern.Wrap)), 
            new PatternTypeInfo(TransformPattern.Pattern, new PatternWrapper(TransformPattern.Wrap)), 
            new PatternTypeInfo(ScrollItemPattern.Pattern, new PatternWrapper(ScrollItemPattern.Wrap)),
            new PatternTypeInfo(ItemContainerPattern.Pattern, new PatternWrapper(ItemContainerPattern.Wrap)),
            new PatternTypeInfo(VirtualizedItemPattern.Pattern, new PatternWrapper(VirtualizedItemPattern.Wrap)),
            new PatternTypeInfo(LegacyIAccessiblePattern.Pattern, new PatternWrapper(LegacyIAccessiblePattern.Wrap)),
            new PatternTypeInfo(SynchronizedInputPattern.Pattern, new PatternWrapper(SynchronizedInputPattern.Wrap)),
            new PatternTypeInfo(ObjectModelPattern.Pattern, new PatternWrapper(ObjectModelPattern.Wrap)),
            new PatternTypeInfo(AnnotationPattern.Pattern, new PatternWrapper(AnnotationPattern.Wrap)),
            new PatternTypeInfo(TextPattern2.Pattern, new PatternWrapper(TextPattern2.Wrap)),
            new PatternTypeInfo(StylesPattern.Pattern, new PatternWrapper(StylesPattern.Wrap)),
            new PatternTypeInfo(SpreadsheetPattern.Pattern, new PatternWrapper(SpreadsheetPattern.Wrap)),
            new PatternTypeInfo(SpreadsheetItemPattern.Pattern, new PatternWrapper(SpreadsheetItemPattern.Wrap)),
            new PatternTypeInfo(TransformPattern2.Pattern, new PatternWrapper(TransformPattern2.Wrap)),
            new PatternTypeInfo(TextChildPattern.Pattern, new PatternWrapper(TextChildPattern.Wrap)),
            new PatternTypeInfo(DragPattern.Pattern, new PatternWrapper(DragPattern.Wrap)),
            new PatternTypeInfo(DropTargetPattern.Pattern, new PatternWrapper(DropTargetPattern.Wrap)),
     };

        
        private Schema()
        {
        }

        private static object ConvertToBool(object value)
        {
            return value;
        }

        private static object ConvertToControlType(object value)
        {
            if (value is ControlType)
            {
                return value;
            }
            return ControlType.LookupById((int)value);
        }

        private static object ConvertToCultureInfo(object value)
        {
            if (value is int)
            {
                if ((int)value == 0)
                {
                    // Some providers return 0 to mean Invariant
                    return CultureInfo.InvariantCulture;
                }
                else
                {
                    return new CultureInfo((int)value);
                }
            }
            return null;
        }

        private static object ConvertToDockPosition(object value)
        {
            return (DockPosition)value;
        }

        private static object ConvertToElement(object value)
        {
            return AutomationElement.Wrap((UIAutomationClient.IUIAutomationElement)value);
        }

        internal static object ConvertToElementArray(object value)
        {
            return Utility.ConvertToElementArray((UIAutomationClient.IUIAutomationElementArray)value);
        }

        private static object ConvertToExpandCollapseState(object value)
        {
            return (ExpandCollapseState)value;
        }

        private static object ConvertToOrientationType(object value)
        {
            return (OrientationType)value;
        }

        private static object ConvertToPoint(object value)
        {
            double[] numArray = (double[])value;
            return new Point(numArray[0], numArray[1]);
        }

        private static object ConvertToRect(object value)
        {
            double[] numArray = (double[])value;
            double x = numArray[0];
            double y = numArray[1];
            double width = numArray[2];
            return new Rect(x, y, width, numArray[3]);
        }

        private static object ConvertToRowOrColumnMajor(object value)
        {
            return (RowOrColumnMajor)value;
        }

        private static object ConvertToToggleState(object value)
        {
            return (ToggleState)value;
        }

        private static object ConvertToWindowInteractionState(object value)
        {
            return (WindowInteractionState)value;
        }

        private static object ConvertToWindowVisualState(object value)
        {
            return (WindowVisualState)value;
        }

        private static object ConvertToAnnotationType(object value)
        {
            return (AnnotationType)value;
        }

        private static object ConvertToStyleId(object value)
        {
            return (StyleId)value;
        }

        internal static bool GetPatternInfo(AutomationPattern id, out PatternTypeInfo info)
        {
            foreach (PatternTypeInfo info2 in _patternInfoTable)
            {
                if (info2.ID == id)
                {
                    info = info2;
                    return true;
                }
            }
            info = null;
            return false;
        }

        internal static bool GetPropertyTypeInfo(AutomationIdentifier id, out PropertyTypeInfo info)
        {
            foreach (PropertyTypeInfo info2 in _propertyInfoTable)
            {
                if (info2.ID == id)
                {
                    info = info2;
                    return true;
                }
            }
            info = null;
            return false;
        }
    }
}
