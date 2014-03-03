/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/6/2013
 * Time: 2:02 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows.Automation;
    using System.Linq;
    using Ninject;
    using System.Management.Automation;
    
//    using Ninject.Extensions.ChildKernel;
    
	public class UiEltCollection : IUiEltCollection
	{
	    // private readonly List<IUiElement> _collectionHolder =
	    private List<IUiElement> _collectionHolder =
	        new List<IUiElement>();
	    
//	    internal IChildKernel ChildKernel { get; set; }
	    
		public virtual IUiElement this[int index] {
		    get { return _collectionHolder[index]; }
		}
		public virtual IUiEltCollection this[string infoString]
		// public virtual IEnumerable<IUiElement> this[string infoString]
		// public virtual IUiElement[] this[string infoString]
        {
            get
            {
                if (string.IsNullOrEmpty(infoString)) return null;
                
                try {
                    
                    if (null == this || 0 == this.Count) return null;
                    
                    const WildcardOptions options = WildcardOptions.IgnoreCase |
                                                    WildcardOptions.Compiled;
                    
                    var wildcardInfoString = 
                        new WildcardPattern(infoString, options);
                    /*
                    WildcardPattern wildcardInfoString = 
                        new WildcardPattern(infoString, options);
                    */
                    
                    var queryByStringData = from collectionItem
                        in this._collectionHolder //.ToArray()
                        where wildcardInfoString.IsMatch(collectionItem.Current.Name) ||
                              wildcardInfoString.IsMatch(collectionItem.Current.AutomationId) ||
                              wildcardInfoString.IsMatch(collectionItem.Current.ClassName)
//                        where collectionItem.Current.Name == infoString ||
//                              collectionItem.Current.AutomationId == infoString ||
//                              collectionItem.Current.ClassName == info
                        select collectionItem;
                    
                    // return AutomationFactory.GetUiEltCollection(queryByStringData).ToArray();
                    return AutomationFactory.GetUiEltCollection(queryByStringData);
                }
                catch {
                    return null;
                    // return new IUiElement[] {};
                }
            }
        }
		public virtual int Count {
		    get { return _collectionHolder.Count; } //return this._elements.Length; }
		}
		public virtual object SyncRoot {
		    get { return _collectionHolder; } //return this; }
		}
		public virtual bool IsSynchronized {
			get { return false; }
		}
        
		public UiEltCollection(AutomationElementCollection elements)
		{
		    foreach (AutomationElement element in elements.Cast<AutomationElement>().Where(element => null != element))
		    {
		        _collectionHolder.Add(AutomationFactory.GetUiElement(element));
		    }
		}

	    public UiEltCollection(IUiEltCollection elements)
	    {
	        foreach (IUiElement element in elements.Cast<IUiElement>().Where(element => null != element))
	        {
	            _collectionHolder.Add(element);
	        }
	    }

	    public UiEltCollection(IEnumerable elements)
	    {
	        foreach (var element in elements.Cast<object>().Where(element => null != element && element is AutomationElement)) {
	            _collectionHolder.Add(AutomationFactory.GetUiElement(element as AutomationElement));
	        }
	        foreach (var element in elements.Cast<object>().Where(element => null != element && element is IUiElement)) {
	            _collectionHolder.Add((IUiElement)element);
	        }
	    }

	    [Inject]
		public UiEltCollection(bool fake)
		{
		}
		
		public virtual void CopyTo(Array array, int index)
		{
			_collectionHolder.ToArray().CopyTo(array, index);
		}
		
		public void CopyTo(IUiElement[] array, int index)
		{
			((ICollection)this).CopyTo(array, index);
		}
		public IEnumerator GetEnumerator()
		{
			return _collectionHolder.GetEnumerator();
		}
		
		public virtual void AddElement(IUiElement element)
		{
		    _collectionHolder.Add(element);
		}
		
		public virtual List<IUiElement> SourceCollection
		{
		    get { return _collectionHolder; }
		}
		
		public virtual void Dispose()
		// public void Dispose()
		{
		    // ? try {
    		// ?     foreach (IUiElement element in this.ToArray().ToList()) {
    		// ?         element.Dispose();
    		// ?     }
		    // ? }
		    // ? catch {}
		    // ? if (null != this._collectionHolder) {
		    // ?     this._collectionHolder.Clear();
		    // ?     this._collectionHolder = null;
		    // ? }
		    
//		    this.ChildKernel.Dispose();
		    
		    // 20140131
		    // 20140205
		    // foreach (IUiElement element in this.ToArray().ToList()) {
		    //     element.Dispose();
		    // }
		    
		    GC.SuppressFinalize(this);
		}
	}
}
