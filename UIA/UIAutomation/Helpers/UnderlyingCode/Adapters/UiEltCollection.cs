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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
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
                    
                    var queryByStringData = from collectionItem
                        in this._collectionHolder //.ToArray()
                            where wildcardInfoString.IsMatch(collectionItem.GetCurrent().Name) ||
                        wildcardInfoString.IsMatch(collectionItem.GetCurrent().AutomationId) ||
                        wildcardInfoString.IsMatch(collectionItem.GetCurrent().ClassName)
                        select collectionItem;
                    
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
        
        // 20140316
//		public UiEltCollection(classic.AutomationElementCollection elements)
//		{
//		    foreach (classic.AutomationElement element in elements.Cast<classic.AutomationElement>().Where(element => null != element))
//		    {
//		        _collectionHolder.Add(AutomationFactory.GetUiElement(element));
//		    }
//		}
//
//	    public UiEltCollection(IUiEltCollection elements)
//	    {
//	        foreach (IUiElement element in elements.Cast<IUiElement>().Where(element => null != element))
//	        {
//	            _collectionHolder.Add(element);
//	        }
//	    }
        
        // 20140316
	    // public UiEltCollection(IEnumerable elements)
        public UiEltCollection(params object[] elements)
	    {
//Console.WriteLine("UiEltCollection 0001");
//Console.WriteLine(elements.GetType().Name);
//Console.WriteLine("UiEltCollection 0001.1");
//foreach (var singleParam in elements) {
//    Console.WriteLine(singleParam.GetType().Name);
//}
            // 20140316
            if (null == elements || 0 == elements.Length) return;
            foreach (IEnumerable subCollection in elements) {
                
//Console.WriteLine("UiEltCollection 0002");
                // 20140316
                if (subCollection is classic.AutomationElementCollection) {
//Console.WriteLine("UiEltCollection 0003");
		          foreach (classic.AutomationElement element in subCollection.Cast<classic.AutomationElement>().Where(element => null != element))
		          {
//Console.WriteLine("UiEltCollection 0004");
		               _collectionHolder.Add(AutomationFactory.GetUiElement(element));
                       // _collectionHolder.Add(AutomationFactory.GetUiElement(element, "collection ctor"));
		          }
//Console.WriteLine("UiEltCollection 0005");
                    return;
                }
                
                if (subCollection is IUiEltCollection) {
//Console.WriteLine("UiEltCollection 0006");
                    foreach (IUiElement element in subCollection.Cast<IUiElement>().Where(element => null != element))
                    {
//Console.WriteLine("UiEltCollection 0007");
                        _collectionHolder.Add(element);
                    }
//Console.WriteLine("UiEltCollection 0008");
                    return;
                }
            }
//Console.WriteLine("UiEltCollection 0014");
	    }
        
        // 20140316
//	    [Inject]
//		public UiEltCollection(bool fake)
//		{
//		}
		
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
