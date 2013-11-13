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
    
	//public class AutomationElementCollection : ICollection, IEnumerable, IAutomationElementCollection
	public class MySuperCollection : IMySuperCollection
	{
	    //private AutomationElementCollection collectionHolder;
	    //private ICollection collectionHolder;
	    private List<IMySuperWrapper> collectionHolder =
	        new List<IMySuperWrapper>();
	    
		//private AutomationElement[] _elements;
		// 20131108
		//public AutomationElement this[int index] {
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
		//internal MySuperCollection(AutomationElement[] elements)
		[Inject]
		//internal MySuperCollection(AutomationElementCollection elements)
		public MySuperCollection(AutomationElementCollection elements)
        /*
        public MySuperCollection(AutomationElementCollection elements)
        */
        {
		    foreach (AutomationElement element in elements) {
		        
		        // 20131112
		        //this.collectionHolder.Add(new MySuperWrapper(element));
		        this.collectionHolder.Add(ObjectsFactory.GetMySuperWrapper(element));
		    }
		}
		
		internal MySuperCollection(IMySuperCollection elements)
		{
		    foreach (IMySuperWrapper element in elements) {
		        
		        this.collectionHolder.Add(element);
		    }
		}
		
		//
		internal MySuperCollection(IEnumerable elements)
        /*
        internal MySuperCollection(ICollection elements)
        */
		{
		    foreach (var element in elements) {
		        
		        this.collectionHolder.Add((IMySuperWrapper)element);
		    }
		}
		//
		
		public virtual void CopyTo(Array array, int index)
		{
			//this._elements.CopyTo(array, index);
			//this.collectionHolder.CopyTo(array, index);
		}
		public void CopyTo(AutomationElement[] array, int index)
		{
			//((ICollection)this).CopyTo(array, index);
			//this.collectionHolder.CopyTo(array, index);
		}
		public void CopyTo(IMySuperWrapper[] array, int index)
		{
			//((ICollection)this).CopyTo(array, index);
			this.collectionHolder.CopyTo(array, index);
		}
		public IEnumerator GetEnumerator()
		{
			//return this._elements.GetEnumerator();
			return this.collectionHolder.GetEnumerator();
		}
		
		public void AddElement(IMySuperWrapper element)
		{
		    this.collectionHolder.Add(element);
		}
		
		//public AutomationElementCollection SourceCollection
		//public IMySuperCollection SourceCollection
		public List<IMySuperWrapper> SourceCollection
		{
		    //get { return this.collectionHolder; }
		    //get { return ((AutomationElementCollection)this.collectionHolder); }
		    //get { return (IMySuperCollection)this.collectionHolder.Cast<IMySuperWrapper>(); }
		    //get { return (IMySuperCollection)this.collectionHolder.AsEnumerable<IMySuperWrapper>(); }
		    get { return this.collectionHolder; }
		    //internal 
		    //set { this.collectionHolder = value; }
		}
	}
}
