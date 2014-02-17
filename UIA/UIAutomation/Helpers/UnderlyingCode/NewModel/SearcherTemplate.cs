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
    // using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of SearcherTemplate.
    /// </summary>
    public abstract class SearcherTemplate
    {
        internal virtual int Timeout { get; set; }
        internal virtual bool Wait { get; set; }
        internal virtual SearcherTemplateData SearcherData { get; set; }
        internal virtual List<IUiElement> ResultCollection { get; set; }
        public abstract void OnStartHook();
        public abstract void BeforeSearchHook();
        public abstract List<IUiElement> SearchForElements(SearcherTemplateData data);
        public abstract void AfterSearchHook();
        public abstract void OnFailureHook();
        public abstract void OnSuccessHook();
        public abstract string TimeoutExpirationInformation { get; set; }
        
        public virtual void OnSleepHook()
        {
            // 20140218
            var timeoutManager = new TimeoutManager(Timeout);
            // TimeoutManager timeoutManager = new TimeoutManager(Timeout);
            System.Threading.Thread.Sleep(timeoutManager.CalculateAdaptiveDelay());
        }
        
        internal virtual bool ContinueSearch(int timeout, DateTime startTime)
        {
            bool result = false;
            
            // 20140212
            if (0 == timeout) return result;
            
            // 20140218
            if ((null == ResultCollection || 0 == ResultCollection.Count) &&
                (System.DateTime.Now - startTime).TotalSeconds <= timeout / 1000) return true;
            /*
            if ((null == ResultCollection || 0 == ResultCollection.Count) &&
                !((System.DateTime.Now - startTime).TotalSeconds > timeout/1000)) return true;
            */
            
            if (null == ResultCollection) {
                
                Wait = false;
                // 20140218
                var eTimeoutException =
                    new TimeoutException(
                        TimeoutExpirationInformation);
                /*
                TimeoutException eTimeoutException =
                    new TimeoutException(
                        TimeoutExpirationInformation);
                */
                throw(eTimeoutException);
            } else {
                // no action currently
            }
            
            return result;
        }
        
        public List<IUiElement> GetElements(SearcherTemplateData data, int timeout)
        {
            Timeout = timeout;
            SearcherData = data;
            var startTime = System.DateTime.Now;
            Wait = true;
            
            OnStartHook();
            
            // 20140125
            // AutomationFactory.InitNewCustomScope();
            
            do {
                // 20140125
                // AutomationFactory.InitNewCustomScope();
                
                BeforeSearchHook();
                
                ResultCollection =
                    SearchForElements(data);
                
                AfterSearchHook();
                
                if (null != ResultCollection && 0 < ResultCollection.Count) break;
                
                Wait = ContinueSearch(Timeout, startTime);
                
                OnSleepHook();
                
            } while (Wait);
            
            OnFailureHook();
            
            OnSuccessHook();
            
            return ResultCollection;
        }
    }
}
