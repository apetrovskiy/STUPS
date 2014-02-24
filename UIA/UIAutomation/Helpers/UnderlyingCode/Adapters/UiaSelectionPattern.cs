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

	public class UiaSelectionPattern : ISelectionPattern
	{
	    private System.Windows.Automation.SelectionPattern _selectionPattern;
		private IUiElement _element;
		
		public UiaSelectionPattern(IUiElement element, SelectionPattern selectionPattern)
		{
			this._selectionPattern = selectionPattern;
			this._element = element;
			//this._useCache = useCache;
		}
		
		public UiaSelectionPattern(IUiElement element)
		{
		    this._element = element;
		}
		
		public struct SelectionPatternInformation : ISelectionPatternInformation
		{
            private bool _useCache;
			private ISelectionPattern _selectionPattern;
			
			public SelectionPatternInformation(ISelectionPattern selectionPattern, bool useCache)
			{
			    this._selectionPattern = selectionPattern;
			    this._useCache = useCache;
			}
			
			public bool CanSelectMultiple {
				get {
			        return (bool)this._selectionPattern.GetParentElement().GetPatternPropertyValue(SelectionPattern.CanSelectMultipleProperty, this._useCache);
			    }
			}
			public bool IsSelectionRequired {
				get {
			        return (bool)this._selectionPattern.GetParentElement().GetPatternPropertyValue(SelectionPattern.IsSelectionRequiredProperty, this._useCache);
			    }
			}
            
			public IUiElement[] GetSelection()
			{
				AutomationElement[] nativeElements = (AutomationElement[])this._selectionPattern.GetParentElement().GetPatternPropertyValue(SelectionPattern.SelectionProperty, this._useCache);
                IUiEltCollection tempCollection = AutomationFactory.GetUiEltCollection(nativeElements);
				if (null == tempCollection || 0 == tempCollection.Count) {
				    return new UiElement[] {};
				} else {
				    return tempCollection.Cast<IUiElement>().ToArray<IUiElement>();
				}
			}
		}
		public static readonly AutomationPattern Pattern = SelectionPatternIdentifiers.Pattern;
		public static readonly AutomationProperty SelectionProperty = SelectionPatternIdentifiers.SelectionProperty;
		public static readonly AutomationProperty CanSelectMultipleProperty = SelectionPatternIdentifiers.CanSelectMultipleProperty;
		public static readonly AutomationProperty IsSelectionRequiredProperty = SelectionPatternIdentifiers.IsSelectionRequiredProperty;
		public static readonly AutomationEvent InvalidatedEvent = SelectionPatternIdentifiers.InvalidatedEvent;
        
		public virtual ISelectionPatternInformation Cached {
			get {
				return new UiaSelectionPattern.SelectionPatternInformation(this, true);
			}
		}
		
		public virtual ISelectionPatternInformation Current {
			get {
				return new UiaSelectionPattern.SelectionPatternInformation(this, false);
			}
		}
		
		public void SetParentElement(IUiElement element)
		{
		    this._element = element;
		}
		
		public IUiElement GetParentElement()
		{
		    return this._element;
		}
		
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

