/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/1/2012
 * Time: 11:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
	using System;
    using System.Management.Automation;
    using System.Collections.Generic;
	using System.Windows.Automation;
    
	/// <summary>
	/// Description of ExecutionPlanCmdletBase.
	/// </summary>
	public class ExecutionPlanCmdletBase : CommonCmdletBase
	{
		public ExecutionPlanCmdletBase()
		{
//			this.HighlightersQueue =
//				new Queue<Highlighter>();
//			this.HighlightersMaxCount = 20;
//			this.HighlighterNumber = 0;
		}
		
//		public Queue<Highlighter> HighlightersQueue { get; set; }
//		public int HighlightersMaxCount { get; set; }
//		internal int HighlighterNumber { get; set; }
//		
//		public void DisposeHighlighers()
//		{
//			try {
//				foreach (Highlighter highLighter in this.HighlightersQueue) {
//					highLighter.Dispose();
//				}
//				this.HighlightersQueue.Clear();
//				this.HighlighterNumber = 0;
//			}
//			catch {
// DisposeHighlighers
//			}
//		}
//		
//		internal void DecreaseMaxCount(int newCount)
//		{
//			if (newCount < this.HighlightersQueue.Count) {
//				while (newCount < this.HighlightersQueue.Count) {
//					Highlighter highlighterToBeDisposed = 
//						this.HighlightersQueue.Dequeue();
//					highlighterToBeDisposed.Dispose();
//				}
//			}
//		}
//		
//		
//		
//		internal void Enqueue(Highlighter highLighter)
//		{
//			if (null == highLighter) {
//				return;
//			}
//			
//			if (this.HighlightersMaxCount <= this.HighlightersQueue.Count) {
//				DecreaseMaxCount(this.HighlightersMaxCount - 1);
//			}
//			
//			this.HighlightersQueue.Enqueue(highLighter);
//		}
//		
//		public void Enqueue(AutomationElement elementToHighlight)
//		{
//			Highlighter highlighter = null;
//            if (null != (elementToHighlight as AutomationElement)) {
//
//				HighlighterNumber++;
//				
//				highlighter =
//                    new Highlighter(
//                        elementToHighlight.Current.BoundingRectangle.Height,
//                        elementToHighlight.Current.BoundingRectangle.Width,
//                        elementToHighlight.Current.BoundingRectangle.X,
//                        elementToHighlight.Current.BoundingRectangle.Y,
//                        elementToHighlight.Current.NativeWindowHandle,
//                        (Highlighters)(HighlighterNumber % 10),
//                        HighlighterNumber);
//
//			} else {
//				
//				// fake highlighter ?
//				
//			}
//			
//			//ExecutionPlan.Enqueue(highlighter);
//			this.Enqueue(highlighter);
//			
//		}
	}
}
