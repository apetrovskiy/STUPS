// (c) Copyright Microsoft, 2012.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.



using System;
using System.Diagnostics;
using System.Collections;
using UIAComWrapperInternal;

namespace System.Windows.Automation
{
    public class AutomationElementCollection : ICollection, IEnumerable
    {
        private UIAutomationClient.IUIAutomationElementArray _obj;

        internal AutomationElementCollection(UIAutomationClient.IUIAutomationElementArray obj)
        {
            Debug.Assert(obj != null);
            this._obj = obj;
        }

        internal static AutomationElementCollection Wrap(UIAutomationClient.IUIAutomationElementArray obj)
        {
            return (obj == null) ? null : new AutomationElementCollection(obj);
        }

        public virtual void CopyTo(Array array, int index)
        {
            int cElem = this._obj.Length;
            for (int i = 0; i < cElem; ++i)
            {
                array.SetValue(this[i], i + index);
            }
        }

        public void CopyTo(AutomationElement[] array, int index)
        {
            int cElem = this._obj.Length;
            for (int i = 0; i < cElem; ++i)
            {
                array.SetValue(this[i], i + index);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new AutomationElementCollectionEnumerator(this._obj);
        }

        public int Count
        {
            get
            {
                return this._obj.Length;
            }
        }

        public virtual bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public AutomationElement this[int index]
        {
            get
            {
                return AutomationElement.Wrap(this._obj.GetElement(index));
            }
        }

        public virtual object SyncRoot
        {
            get
            {
                return this;
            }
        }
    }

    public class AutomationElementCollectionEnumerator : IEnumerator
    {
        private UIAutomationClient.IUIAutomationElementArray _obj;
        private int _index = -1;
        private int _cElem;

        #region IEnumerator Members

        internal AutomationElementCollectionEnumerator(UIAutomationClient.IUIAutomationElementArray obj)
        {
            Debug.Assert(obj != null);
            this._obj = obj;
            this._cElem = obj.Length;
        }

        public object Current
        {
            get
            {
                return AutomationElement.Wrap(this._obj.GetElement(this._index));
            }
        }

        public bool MoveNext()
        {
            if (this._index < (this._cElem - 1))
            {
                ++this._index;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            this._index = -1;
        }

        #endregion
    }
}
