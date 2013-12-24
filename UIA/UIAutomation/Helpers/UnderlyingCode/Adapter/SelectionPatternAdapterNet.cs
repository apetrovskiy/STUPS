/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/6/2013
 * Time: 6:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET;
	using System;
	using System.Windows.Automation;
	using System.Linq;
	using System.Collections;
	using System.Collections.Generic;

	public class MySelectionPatternNet : IMySuperSelectionPattern
	{
	    private System.Windows.Automation.SelectionPattern _selectionPattern;
		private IUiElement _element;
		
		public MySelectionPatternNet(IUiElement element, SelectionPattern selectionPattern)
		{
			this._selectionPattern = selectionPattern;
			this._element = element;
			//this._useCache = useCache;
		}
		
		public MySelectionPatternNet(IUiElement element)
		{
		    this._element = element;
		}
		
		public struct SelectionPatternInformation : ISelectionPatternInformation
		{
            private bool _useCache;
			private IMySuperSelectionPattern _selectionPattern;
			
			public SelectionPatternInformation(IMySuperSelectionPattern selectionPattern, bool useCache)
			{
			    this._selectionPattern = selectionPattern;
			    this._useCache = useCache;
			}
			
			public bool CanSelectMultiple {
				get {
			        // 20131224
			        // return (bool)this._selectionPattern.ParentElement.GetPatternPropertyValue(SelectionPattern.CanSelectMultipleProperty, this._useCache);
			        return (bool)this._selectionPattern.GetParentElement().GetPatternPropertyValue(SelectionPattern.CanSelectMultipleProperty, this._useCache);
			    }
			}
			public bool IsSelectionRequired {
				get {
			        // 20131224
			        // return (bool)this._selectionPattern.ParentElement.GetPatternPropertyValue(SelectionPattern.IsSelectionRequiredProperty, this._useCache);
			        return (bool)this._selectionPattern.GetParentElement().GetPatternPropertyValue(SelectionPattern.IsSelectionRequiredProperty, this._useCache);
			    }
			}
            
			public IUiElement[] GetSelection()
			{
			    // 20131224
				// return AutomationFactory.GetUiEltCollection((AutomationElement[])this._selectionPattern.ParentElement.GetPatternPropertyValue(SelectionPattern.SelectionProperty, this._useCache)).ToArray();
				return AutomationFactory.GetUiEltCollection((AutomationElement[])this._selectionPattern.GetParentElement().GetPatternPropertyValue(SelectionPattern.SelectionProperty, this._useCache)).ToArray();
			}
		}
		public static readonly AutomationPattern Pattern = SelectionPatternIdentifiers.Pattern;
		public static readonly AutomationProperty SelectionProperty = SelectionPatternIdentifiers.SelectionProperty;
		public static readonly AutomationProperty CanSelectMultipleProperty = SelectionPatternIdentifiers.CanSelectMultipleProperty;
		public static readonly AutomationProperty IsSelectionRequiredProperty = SelectionPatternIdentifiers.IsSelectionRequiredProperty;
		public static readonly AutomationEvent InvalidatedEvent = SelectionPatternIdentifiers.InvalidatedEvent;
        
		public virtual ISelectionPatternInformation Cached {
			get {
				return new MySelectionPatternNet.SelectionPatternInformation(this, true);
			}
		}
		
		public virtual ISelectionPatternInformation Current {
			get {
				return new MySelectionPatternNet.SelectionPatternInformation(this, false);
			}
		}
		
		// public virtual IUiElement ParentElement
//		internal virtual IUiElement ParentElement
//		{
//		    get { return this._element; }
//		    set { this._element = value; }
//		}
		
		public void SetParentElement(IUiElement element)
		{
		    this._element = element;
		}
		
		public IUiElement GetParentElement()
		{
		    return this._element;
		}
		
//		public object SourcePattern
//		{
//		    get { return this._selectionPattern; }
//		    set { this._selectionPattern = value as SelectionPattern; }
//		}
		
		public void SetSourcePattern(object pattern)
		{
		    this._selectionPattern = pattern as SelectionPattern;
		}
		
		public object GetSourcePattern()
		{
		    return this._selectionPattern;
		}
	}
}

