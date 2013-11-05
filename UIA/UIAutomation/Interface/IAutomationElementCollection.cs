/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/6/2013
 * Time: 2:00 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Collections;
    using System.Windows.Automation;
    
    public interface IAutomationElementCollection : ICollection, IEnumerable
	{
		void CopyTo(Array array, int index);
		void CopyTo(AutomationElement[] array, int index);
		IEnumerator GetEnumerator();
		//AutomationElement Item { get; }
		int Count { get; }
		object SyncRoot { get; }
		bool IsSynchronized { get; }
	}
}
