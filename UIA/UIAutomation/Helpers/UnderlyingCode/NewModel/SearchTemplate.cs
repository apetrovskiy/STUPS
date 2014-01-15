/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/15/2014
 * Time: 12:32 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of SearchTemplate.
    /// </summary>
    public abstract class SearchTemplate
    {
        internal virtual int Timeout { get; set; }
        internal virtual bool Wait { get; set; }
        // internal virtual DateTime StartTime { get; set; }
        // internal virtual DateTime NowTime { get; set; }
        internal virtual SearchTemplateData SearchData { get; set; }
        internal virtual List<IUiElement> ResultCollection { get; set; }
        public abstract void BeforeSearchHook();
        public abstract List<IUiElement> SearchForElements(SearchTemplateData data);
        public abstract void AfterSearchHook();
        public abstract void OnSleepAction();
        public abstract string TimeoutExpirationInformation { get; set; }
        
        internal virtual bool ContinueSearch(int timeout, DateTime startTime)
        {
            bool result = false;
            
            if ((null == ResultCollection || 0 == ResultCollection.Count) &&
                // !((System.DateTime.Now - startTime).TotalSeconds > Timeout/1000)) return false;
                !((System.DateTime.Now - startTime).TotalSeconds > timeout/1000)) return true;
            if (null == ResultCollection) {
                Wait = false;
                TimeoutException eReturn =
                    new TimeoutException(
                        TimeoutExpirationInformation);
                throw(eReturn);
            }else{
//                        WriteVerbose(this, "got the window: " +
//                                     // 20120824
//                                     //aeWindow.Current.Name);
//                                     ((AutomationElement)aeWindowList[0]).Current.Name);
            }
                
//            if (!cmdlet.WaitNoWindow) {
//                Wait = false;
//            }
            
            return result;
        }
        
        // public virtual List<IUiElement> GetElements(SearchTemplateData data, int timeout)
        public List<IUiElement> GetElements(SearchTemplateData data, int timeout)
        {
            Timeout = timeout;
            SearchData = data;
            // StartTime = System.DateTime.Now;
            var startTime = System.DateTime.Now;
            Wait = true;
            
            do {
                
//Console.WriteLine("before before hook");
                
                BeforeSearchHook();
                
//Console.WriteLine("before search");
                
                ResultCollection =
                    SearchForElements(data);
                
//Console.WriteLine("after search");
//if (null == ResultCollection) {
//    Console.WriteLine("null == ResultCollection");
//} else {
//    Console.WriteLine("null != ResultCollection");
//    Console.WriteLine(ResultCollection.Count.ToString());
//}
//Console.WriteLine("timeout = " + Timeout.ToString());
                
                AfterSearchHook();
                
//Console.WriteLine("after after search hook");
                
                if (null != ResultCollection && 0 < ResultCollection.Count) break;
                
                Wait = ContinueSearch(Timeout, startTime);
                
                OnSleepAction();
                
            } while (Wait);
            
            return ResultCollection;
        }
    }
}
