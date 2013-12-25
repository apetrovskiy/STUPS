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
	public class UiaTransformPattern : ITransformPattern
	{
		private System.Windows.Automation.TransformPattern _transformPattern;
		private IUiElement _element;

		public UiaTransformPattern(IUiElement element, TransformPattern transformPattern)
		{
			this._transformPattern = transformPattern;
			this._element = element;
			//this._useCache = useCache;
		}

		public UiaTransformPattern(IUiElement element)
		{
			this._element = element;
		}

		public struct TransformPatternInformation : ITransformPatternInformation
		{
			// private AutomationElement _el;
			// private bool _useCache;
			
			private readonly bool _useCache;
			private readonly ITransformPattern _transformPattern;

			public TransformPatternInformation(ITransformPattern transformPattern, bool useCache)
			{
				this._transformPattern = transformPattern;
				this._useCache = useCache;
			}
			
			public bool CanMove {
				// get { return (bool)this._el.GetPatternPropertyValue(TransformPattern.CanMoveProperty, this._useCache); }
				get { return (bool)this._transformPattern.GetParentElement().GetPatternPropertyValue(TransformPattern.CanMoveProperty, this._useCache); }
			}
			public bool CanResize {
				// get { return (bool)this._el.GetPatternPropertyValue(TransformPattern.CanResizeProperty, this._useCache); }
				get { return (bool)this._transformPattern.GetParentElement().GetPatternPropertyValue(TransformPattern.CanResizeProperty, this._useCache); }
			}
			public bool CanRotate {
				// get { return (bool)this._el.GetPatternPropertyValue(TransformPattern.CanRotateProperty, this._useCache); }
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
		
		public ITransformPatternInformation Cached {
			get {
				// Misc.ValidateCached(this._cached);
				// return new TransformPattern.TransformPatternInformation(this._el, true);
				return new UiaTransformPattern.TransformPatternInformation(this, true);
			}
		}
		
		public ITransformPatternInformation Current {
			get {
				// Misc.ValidateCurrent(this._hPattern);
				// return new TransformPattern.TransformPatternInformation(this._el, false);
				return new UiaTransformPattern.TransformPatternInformation(this, false);
			}
		}
//		private UiaTransformPattern(AutomationElement el, SafePatternHandle hPattern, bool cached) : base(el, hPattern)
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
		    this._transformPattern = pattern as TransformPattern;
		}
		
		public object GetSourcePattern()
		{
		    return this._transformPattern;
		}
	}
}

