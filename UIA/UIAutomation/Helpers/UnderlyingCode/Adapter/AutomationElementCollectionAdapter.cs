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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows.Automation;
    using System.Linq;
    using Ninject;
    
	public class MySuperCollection : IMySuperCollection
	{
	    private readonly List<IMySuperWrapper> _collectionHolder =
	        new List<IMySuperWrapper>();
	    
		public IMySuperWrapper this[int index] {
		    get { return _collectionHolder[index]; }
		}
		public int Count {
		    get { return _collectionHolder.Count; } //return this._elements.Length; }
		}
		public virtual object SyncRoot {
		    get { return _collectionHolder; } //return this; }
		}
		public virtual bool IsSynchronized {
			get { return false; }
		}
        
		public MySuperCollection(AutomationElementCollection elements)
		{
		    foreach (AutomationElement element in elements.Cast<AutomationElement>().Where(element => null != element))
		    {
		        _collectionHolder.Add(AutomationFactory.GetMySuperWrapper(element));
		    }
		    /*
            foreach (AutomationElement element in elements) {
		        
		        if (null != element) {
    		        _collectionHolder.Add(ObjectsFactory.GetMySuperWrapper(element));
		        }
		    }
            */
		}

	    public MySuperCollection(IMySuperCollection elements)
	    {
	        foreach (IMySuperWrapper element in elements.Cast<IMySuperWrapper>().Where(element => null != element))
	        {
	            _collectionHolder.Add(element);
	        }
	        /*
            foreach (IMySuperWrapper element in elements) {
		        
		        if (null != element) {
		          _collectionHolder.Add(element);
		        }
		    }
            */
	    }

	    public MySuperCollection(IEnumerable elements)
	    {
	        foreach (var element in elements.Cast<object>().Where(element => null != element))
	        {
	            _collectionHolder.Add((IMySuperWrapper)element);
	        }
	        /*
            foreach (var element in elements) {
		        
		        if (null != element) {
		          _collectionHolder.Add((IMySuperWrapper)element);
		        }
		    }
            */
	    }

	    [Inject]
		public MySuperCollection(bool fake)
		{
		}
		
		public virtual void CopyTo(Array array, int index)
		{
			//this._elements.CopyTo(array, index);
			//this._collectionHolder.CopyTo(array, index);
		}
		public virtual void CopyTo(AutomationElement[] array, int index)
		{
			//((ICollection)this).CopyTo(array, index);
			//this._collectionHolder.CopyTo(array, index);
		}
		public virtual void CopyTo(IMySuperWrapper[] array, int index)
		{
			_collectionHolder.CopyTo(array, index);
		}
		public IEnumerator GetEnumerator()
		{
			return _collectionHolder.GetEnumerator();
		}
		
		public virtual void AddElement(IMySuperWrapper element)
		{
		    _collectionHolder.Add(element);
		}
		
		public virtual List<IMySuperWrapper> SourceCollection
		{
		    get { return _collectionHolder; }
		}
		
		public void Dispose()
		{
//		    if (null != this._collectionHolder) {
//		        for (int i = 0; i < this._collectionHolder.Count; i++) {
//		            if (null != this._collectionHolder[i]) this._collectionHolder[i].Dispose();
//		        }
//		    }
		    
		    // 20131120
		    GC.SuppressFinalize(this);
		}
	}
}
