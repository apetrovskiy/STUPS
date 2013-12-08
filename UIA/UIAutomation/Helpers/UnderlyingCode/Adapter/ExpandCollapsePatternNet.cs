/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/6/2013
 * Time: 10:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET;
	using System;
	using System.Windows.Automation;

	public class MyExpandCollapsePatternNet : IMySuperExpandCollapsePattern
	{
		private readonly System.Windows.Automation.ExpandCollapsePattern _expandCollapsePattern;
		private IUiElement _element;
		
		public MyExpandCollapsePatternNet(IUiElement element, ExpandCollapsePattern expandCollapsePattern)
		{
			this._expandCollapsePattern = expandCollapsePattern;
			this._element = element;
			//this._useCache = useCache;
		}
		
		internal MyExpandCollapsePatternNet(IUiElement element)
		{
		    this._element = element;
		}

		public struct ExpandCollapsePatternInformation : IExpandCollapsePatternInformationAdapter
		{
			private bool _useCache;
			private IMySuperExpandCollapsePattern _expandCollapsePattern;
			
			public ExpandCollapsePatternInformation(IMySuperExpandCollapsePattern expandCollapsePattern, bool useCache)
			{
			    this._expandCollapsePattern = expandCollapsePattern;
			    this._useCache = useCache;
			}
			
			public ExpandCollapseState ExpandCollapseState {
				get { return (ExpandCollapseState)this._expandCollapsePattern.ParentElement.GetPatternPropertyValue(ExpandCollapsePattern.ExpandCollapseStateProperty, this._useCache); }
			}
		}
		public static readonly AutomationPattern Pattern = ExpandCollapsePatternIdentifiers.Pattern;
		public static readonly AutomationProperty ExpandCollapseStateProperty = ExpandCollapsePatternIdentifiers.ExpandCollapseStateProperty;
        
		public virtual IExpandCollapsePatternInformationAdapter Cached {
			get {
				return new MyExpandCollapsePatternNet.ExpandCollapsePatternInformation(this, true);
			}
		}
		
		public virtual IExpandCollapsePatternInformationAdapter Current {
			get {
				return new MyExpandCollapsePatternNet.ExpandCollapsePatternInformation(this, false);
			}
		}
        
		public virtual void Expand()
		{
			if (null == this._expandCollapsePattern) return;
			this._expandCollapsePattern.Expand();
		}
		public virtual void Collapse()
		{
			if (null == this._expandCollapsePattern) return;
			this._expandCollapsePattern.Collapse();
		}
		
		public virtual IUiElement ParentElement
		{
		    get { return this._element; }
		    set { this._element = value; }
		}
	}
}
