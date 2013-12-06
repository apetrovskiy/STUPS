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
	//using Ninject;

	public class MySelectionPatternNet : IMySuperSelectionPattern
	{
	    private readonly System.Windows.Automation.SelectionPattern _selectionPattern;
		private IMySuperWrapper _element;
		
		public MySelectionPatternNet(IMySuperWrapper element, SelectionPattern selectionPattern)
		{
			this._selectionPattern = selectionPattern;
			this._element = element;
			//this._useCache = useCache;
		}
		
		internal MySelectionPatternNet(IMySuperWrapper element)
		{
		    this._element = element;
		}
		
		public struct SelectionPatternInformation : ISelectionPatternInformation
		{
			// private AutomationElement _el;
            private bool _useCache;
			private IMySuperSelectionPattern _selectionPattern;
			
			public SelectionPatternInformation(IMySuperSelectionPattern selectionPattern, bool useCache)
			{
			    this._selectionPattern = selectionPattern;
			    this._useCache = useCache;
			}
			
			public bool CanSelectMultiple {
				get {
			        // return (bool)this._el.GetPatternPropertyValue(SelectionPattern.CanSelectMultipleProperty, this._useCache);
			        return (bool)this._selectionPattern.ParentElement.GetPatternPropertyValue(SelectionPattern.CanSelectMultipleProperty, this._useCache);
			    }
			}
			public bool IsSelectionRequired {
				get {
			        // return (bool)this._el.GetPatternPropertyValue(SelectionPattern.IsSelectionRequiredProperty, this._useCache);
			        return (bool)this._selectionPattern.ParentElement.GetPatternPropertyValue(SelectionPattern.IsSelectionRequiredProperty, this._useCache);
			    }
			}
//			internal SelectionPatternInformation(AutomationElement el, bool useCache)
//			{
//				this._el = el;
//				this._useCache = useCache;
//			}
			// public AutomationElement[] GetSelection()
			public IMySuperWrapper[] GetSelection()
			{
				// return (AutomationElement[])this._el.GetPatternPropertyValue(SelectionPattern.SelectionProperty, this._useCache);
				return AutomationFactory.GetMySuperCollection((AutomationElement[])this._selectionPattern.ParentElement.GetPatternPropertyValue(SelectionPattern.SelectionProperty, this._useCache)).ToArray();
			}
		}
		public static readonly AutomationPattern Pattern = SelectionPatternIdentifiers.Pattern;
		public static readonly AutomationProperty SelectionProperty = SelectionPatternIdentifiers.SelectionProperty;
		public static readonly AutomationProperty CanSelectMultipleProperty = SelectionPatternIdentifiers.CanSelectMultipleProperty;
		public static readonly AutomationProperty IsSelectionRequiredProperty = SelectionPatternIdentifiers.IsSelectionRequiredProperty;
		public static readonly AutomationEvent InvalidatedEvent = SelectionPatternIdentifiers.InvalidatedEvent;
//		private SafePatternHandle _hPattern;
//		private bool _cached;
		// public SelectionPattern.SelectionPatternInformation Cached {
		// public MySelectionPatternNet.SelectionPatternInformation Cached {
		public ISelectionPatternInformation Cached {
			get {
				// Misc.ValidateCached(this._cached);
				// return new SelectionPattern.SelectionPatternInformation(this._el, true);
				return new MySelectionPatternNet.SelectionPatternInformation(this, true);
			}
		}
		// public SelectionPattern.SelectionPatternInformation Current {
		// public MySelectionPatternNet.SelectionPatternInformation Current {
		public ISelectionPatternInformation Current {
			get {
				// Misc.ValidateCurrent(this._hPattern);
				// return new SelectionPattern.SelectionPatternInformation(this._el, false);
				return new MySelectionPatternNet.SelectionPatternInformation(this, false);
			}
		}
//		private SelectionPattern(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern)
//		{
//			this._hPattern = hPattern;
//			this._cached = cached;
//		}
//		internal static object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//		{
//			return new SelectionPattern(el, hPattern, cached);
//		}
		
		public IMySuperWrapper ParentElement
		{
		    get { return this._element; }
		    set { this._element = value; }
		}
	}
}

