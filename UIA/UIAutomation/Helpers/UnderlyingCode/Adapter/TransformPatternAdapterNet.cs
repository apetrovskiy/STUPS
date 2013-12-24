/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/8/2013
 * Time: 10:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	extern alias UIANET;
	using System;
	using System.Windows.Automation;

	/// <summary>
	/// Description of TransformPatternAdapterNet.
	/// </summary>
	public class MyTransformPatternNet : IMySuperTransformPattern
	{
		private System.Windows.Automation.TransformPattern _transformPattern;
		private IUiElement _element;

		public MyTransformPatternNet(IUiElement element, TransformPattern transformPattern)
		{
			this._transformPattern = transformPattern;
			this._element = element;
			//this._useCache = useCache;
		}

		public MyTransformPatternNet(IUiElement element)
		{
			this._element = element;
		}

		public struct TransformPatternInformation : ITransformPatternInformation
		{
			// private AutomationElement _el;
			// private bool _useCache;
			
			private readonly bool _useCache;
			private readonly IMySuperTransformPattern _transformPattern;

			public TransformPatternInformation(IMySuperTransformPattern transformPattern, bool useCache)
			{
				this._transformPattern = transformPattern;
				this._useCache = useCache;
			}
			
			public bool CanMove {
				// get { return (bool)this._el.GetPatternPropertyValue(TransformPattern.CanMoveProperty, this._useCache); }
				// 20131224
				// get { return (bool)this._transformPattern.ParentElement.GetPatternPropertyValue(TransformPattern.CanMoveProperty, this._useCache); }
				get { return (bool)this._transformPattern.GetParentElement().GetPatternPropertyValue(TransformPattern.CanMoveProperty, this._useCache); }
			}
			public bool CanResize {
				// get { return (bool)this._el.GetPatternPropertyValue(TransformPattern.CanResizeProperty, this._useCache); }
				// 20131224
				// get { return (bool)this._transformPattern.ParentElement.GetPatternPropertyValue(TransformPattern.CanResizeProperty, this._useCache); }
				get { return (bool)this._transformPattern.GetParentElement().GetPatternPropertyValue(TransformPattern.CanResizeProperty, this._useCache); }
			}
			public bool CanRotate {
				// get { return (bool)this._el.GetPatternPropertyValue(TransformPattern.CanRotateProperty, this._useCache); }
				// 20131224
				// get { return (bool)this._transformPattern.ParentElement.GetPatternPropertyValue(TransformPattern.CanRotateProperty, this._useCache); }
				get { return (bool)this._transformPattern.GetParentElement().GetPatternPropertyValue(TransformPattern.CanRotateProperty, this._useCache); }
			}
//			internal TransformPatternInformation(AutomationElement el, bool useCache)
//			{
//				this._el = el;
//				this._useCache = useCache;
//			}
		}
		public static readonly AutomationPattern Pattern = TransformPatternIdentifiers.Pattern;
		public static readonly AutomationProperty CanMoveProperty = TransformPatternIdentifiers.CanMoveProperty;
		public static readonly AutomationProperty CanResizeProperty = TransformPatternIdentifiers.CanResizeProperty;
		public static readonly AutomationProperty CanRotateProperty = TransformPatternIdentifiers.CanRotateProperty;
		// private SafePatternHandle _hPattern;
		// private bool _cached;
		// public TransformPattern.TransformPatternInformation Cached {
		public ITransformPatternInformation Cached {
			get {
				// Misc.ValidateCached(this._cached);
				// return new TransformPattern.TransformPatternInformation(this._el, true);
				return new MyTransformPatternNet.TransformPatternInformation(this, true);
			}
		}
		// public TransformPattern.TransformPatternInformation Current {
		public ITransformPatternInformation Current {
			get {
				// Misc.ValidateCurrent(this._hPattern);
				// return new TransformPattern.TransformPatternInformation(this._el, false);
				return new MyTransformPatternNet.TransformPatternInformation(this, false);
			}
		}
//		private MyTransformPatternNet(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern)
//		{
//			this._hPattern = hPattern;
//			this._cached = cached;
//		}
		public void Move(double x, double y)
		{
			// UiaCoreApi.TransformPattern_Move(this._hPattern, x, y);
			this._transformPattern.Move(x, y);
		}
		public void Resize(double width, double height)
		{
			// UiaCoreApi.TransformPattern_Resize(this._hPattern, width, height);
			this._transformPattern.Resize(width, height);
		}
		public void Rotate(double degrees)
		{
			// UiaCoreApi.TransformPattern_Rotate(this._hPattern, degrees);
			this._transformPattern.Rotate(degrees);
		}
//		static internal object Wrap(AutomationElement el, SafePatternHandle hPattern, bool cached)
//		{
//			return new TransformPattern(el, hPattern, cached);
//		}
		
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

//		public object SourcePattern {
//			get { return this._transformPattern; }
//			set { this._transformPattern = value as TransformPattern; }
//		}
		
		public void SetSourcePattern(object pattern)
		{
		    this._transformPattern = pattern as TransformPattern;
		}
		
		public object GetSourcePattern()
		{
		    return this._transformPattern;
		}
	}
}

