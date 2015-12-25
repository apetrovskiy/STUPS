/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/9/2013
 * Time: 3:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests
{
    using System;
    using System.Windows.Automation;
    using System.Windows.Automation.Text;
    using UIAutomation;
    
    /// <summary>
    /// Description of PatternsData.
    /// </summary>
    public struct PatternsData : IEquatable<PatternsData>
    {
        int member; // this is just an example member, replace it with your own struct members!
        
        #region Equals and GetHashCode implementation
        // The code in this region is useful if you want to use this structure in collections.
        // If you don't need it, you can just remove the region and the ": IEquatable<PatternsData>" declaration.
        
        public override bool Equals(object obj)
        {
            if (obj is PatternsData)
                return Equals((PatternsData)obj); // use Equals method below
            else
                return false;
        }
        
        public bool Equals(PatternsData other)
        {
            // add comparisions for all members here
            return member == other.member;
        }
        
        public override int GetHashCode()
        {
            // combine the hash codes of all members here (e.g. with XOR operator ^)
            return member.GetHashCode();
        }
        
        public static bool operator ==(PatternsData left, PatternsData right)
        {
            return left.Equals(right);
        }
        
        public static bool operator !=(PatternsData left, PatternsData right)
        {
            return !left.Equals(right);
        }
        #endregion
        
        #region DockPattern
        public DockPosition DockPattern_DockPosition { get; set; }
        #endregion DockPattern
        
        #region ExpandCollapsePattern
        public ExpandCollapseState ExpandCollapsePattern_ExpandCollapseState { get; set; }
        #endregion ExpandCollapsePattern
        
        #region GridItemPattern
        public int GridItemPattern_Column { get; set; }
        public int GridItemPattern_ColumnSpan { get; set; }
        public IUiElement GridItemPattern_ContainingGrid { get; set; }
        public int GridItemPattern_Row { get; set; }
        public int GridItemPattern_RowSpan { get; set; }
        #endregion GridItemPattern
        
        #region GridPattern
        public int GridPattern_ColumnCount { get; set; }
        public int GridPattern_RowCount { get; set; }
        
        public ControlType GridPattern_GetItem_ControlType { get; set; }
        public string GridPattern_GetItem_Name { get; set; }
        public string GridPattern_GetItem_AutomationId { get; set; }
        public string GridPattern_GetItem_Class { get; set; }
        #endregion GridPattern
        
        #region RangeValuePattern
        public bool RangeValuePattern_IsReadOnly { get; set; }
        public double RangeValuePattern_LargeChange { get; set; }
        public double RangeValuePattern_Maximum { get; set; }
        public double RangeValuePattern_Minimum { get; set; }
        public double RangeValuePattern_SmallChange { get; set; }
        public double RangeValuePattern_Value { get; set; }
        #endregion RangeValuePattern
        
        #region ScrollPattern
        public ScrollAmount ScrollPattern_HorizontalAmount { get; set; }
        public ScrollAmount ScrollPattern_VerticalAmount { get; set; }
        public double ScrollPattern_HorizontalPercent { get; set; }
        public double ScrollPattern_VerticalPercent { get; set; }
        
        public bool ScrollPattern_HorizontallyScrollable { get; set; }
        public double ScrollPattern_HorizontalScrollPercent { get; set; }
        public double ScrollPattern_HorizontalViewSize { get; set; }
        public bool ScrollPattern_VerticallyScrollable { get; set; }
        public double ScrollPattern_VerticalScrollPercent { get; set; }
        public double ScrollPattern_VerticalViewSize { get; set; }
        #endregion ScrollPattern
        
        #region SelectionItemPattern
        public bool SelectionItemPattern_IsSelected { get; set; }
        public IUiElement SelectionItemPattern_SelectionContainer { get; set; }
        #endregion SelectionItemPattern
        
        #region SelectionPattern
        public bool SelectionPattern_CanSelectMultiple { get; set; }
        public bool SelectionPattern_IsSelectionRequired { get; set; }
        #endregion SelectionPattern
        
        #region TableItemPattern
        public int TableItemPattern_Column { get; set; }
        public int TableItemPattern_ColumnSpan { get; set; }
        public IUiElement TableItemPattern_ContainingGrid { get; set; }
        public int TableItemPattern_Row { get; set; }
        public int TableItemPattern_RowSpan { get; set; }
        #endregion TableItemPattern
        
        #region TablePattern
        public int TablePattern_ColumnCount { get; set; }
        public int TablePattern_RowCount { get; set; }
        public RowOrColumnMajor TablePattern_RowOrColumnMajor { get; set; }
        #endregion TablePattern
        
        #region TextPattern
        public TextPatternRange TextPattern_DocumentRange { get; set; }
        public SupportedTextSelection TextPattern_SupportedTextSelection { get; set; }
        #endregion TextPattern
        
        #region TogglePattern
        public ToggleState TogglePattern_ToggleState { get; set; }
        #endregion TogglePattern
        
        #region TransformPattern
        public bool TransformPattern_CanMove { get; set; }
        public bool TransformPattern_CanResize { get; set; }
        public bool TransformPattern_CanRotate { get; set; }
        #endregion TransformPattern
        
        #region ValuePattern
        public string ValuePattern_Value { get; set; }
        #endregion ValuePattern
        
        #region WindowPattern
        public WindowVisualState WindowPattern_WindowVisualStateSet { get; set; }
        public int WindowPattern_Milliseconds { get; set; }
        public bool WindowPattern_CanMaximize { get; set; }
        public bool WindowPattern_CanMinimize { get; set; }
        public bool WindowPattern_IsModal { get; set; }
        public bool WindowPattern_IsTopmost { get; set; }
        public WindowInteractionState WindowPattern_WindowInteractionState { get; set; }
        public WindowVisualState WindowPattern_WindowVisualState { get; set; }
        #endregion WindowPattern
    }
}
