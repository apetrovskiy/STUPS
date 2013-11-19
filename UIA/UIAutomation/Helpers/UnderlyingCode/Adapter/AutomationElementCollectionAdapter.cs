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
    
    //using System.Linq.Expressions;
    
    using Ninject;
    
	public class MySuperCollection : IMySuperCollection
	{
	    private List<IMySuperWrapper> collectionHolder =
	        new List<IMySuperWrapper>();
	    
		public IMySuperWrapper this[int index] {
		    //get { return this.collectionHolder[index]; } //return this._elements[index]; }
		    //get { return ((AutomationElementCollection)this.collectionHolder)[index]; } //return this._elements[index]; }
		    //get { return new MySuperWrapper(((AutomationElementCollection)this.collectionHolder)[index]); } //return this._elements[index]; }
		    //get { return new MySuperWrapper(this.collectionHolder[index]); } //return this._elements[index]; }
		    get { return this.collectionHolder[index]; }
		}
		public int Count {
		    get { return this.collectionHolder.Count; } //return this._elements.Length; }
		}
		public virtual object SyncRoot {
		    get { return this.collectionHolder; } //return this; }
		}
		public virtual bool IsSynchronized {
			get { return false; }
		}
        
		public MySuperCollection(AutomationElementCollection elements)
        {
		    foreach (AutomationElement element in elements) {
		        
		        // 20131112
		        //this.collectionHolder.Add(new MySuperWrapper(element));
		        this.collectionHolder.Add(ObjectsFactory.GetMySuperWrapper(element));
		    }
		}
		
		public MySuperCollection(IMySuperCollection elements)
		{
		    foreach (IMySuperWrapper element in elements) {
		        
		        this.collectionHolder.Add(element);
		    }
		}
		
		public MySuperCollection(IEnumerable elements)
		{
		    foreach (var element in elements) {
		        
		        this.collectionHolder.Add((IMySuperWrapper)element);
		    }
		}
		
		[Inject]
		public MySuperCollection(bool fake)
		{
		}
		
		public virtual void CopyTo(Array array, int index)
		{
			//this._elements.CopyTo(array, index);
			//this.collectionHolder.CopyTo(array, index);
		}
		public virtual void CopyTo(AutomationElement[] array, int index)
		{
			//((ICollection)this).CopyTo(array, index);
			//this.collectionHolder.CopyTo(array, index);
		}
		public virtual void CopyTo(IMySuperWrapper[] array, int index)
		{
			//((ICollection)this).CopyTo(array, index);
			this.collectionHolder.CopyTo(array, index);
		}
		public IEnumerator GetEnumerator()
		{
			//return this._elements.GetEnumerator();
			return this.collectionHolder.GetEnumerator();
		}
		
		public virtual void AddElement(IMySuperWrapper element)
		{
		    this.collectionHolder.Add(element);
		}
		
		public virtual List<IMySuperWrapper> SourceCollection
		{
		    get { return this.collectionHolder; }
		}
		
		public void Dispose()
		{
		    if (null != this.collectionHolder) {
		        for (int i = 0; i < this.collectionHolder.Count; i++) {
		            this.collectionHolder[i].Dispose();
		        }
		    }
		}
	}
}
