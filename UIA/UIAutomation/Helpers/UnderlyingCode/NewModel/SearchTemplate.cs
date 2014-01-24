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
        internal virtual SearchTemplateData SearchData { get; set; }
        internal virtual List<IUiElement> ResultCollection { get; set; }
        public abstract void OnStartHook();
        public abstract void BeforeSearchHook();
        public abstract List<IUiElement> SearchForElements(SearchTemplateData data);
        public abstract void AfterSearchHook();
        // public abstract void OnSleepHook();
        public abstract void OnFailureHook();
        public abstract void OnSuccessHook();
        public abstract string TimeoutExpirationInformation { get; set; }
        
        public virtual void OnSleepHook()
        {
            int timeout = Timeout;
            if (0 == timeout) {
                timeout = 10;
            } else if (timeout <= 5000) {
                timeout /= 20;
            } else if (timeout <= 20000) {
                timeout /= 40;
            } else if (timeout <= 60000) {
                timeout /= 60;
            } else if (timeout <= 600000) {
                timeout /= 100;
            }
            if (timeout < Preferences.Timeout) {
                timeout = Preferences.Timeout;
            }
            System.Threading.Thread.Sleep(timeout);
        }
        
        internal virtual bool ContinueSearch(int timeout, DateTime startTime)
        {
            bool result = false;
            
            if ((null == ResultCollection || 0 == ResultCollection.Count) &&
                !((System.DateTime.Now - startTime).TotalSeconds > timeout/1000)) return true;
            if (null == ResultCollection) {
                Wait = false;
                TimeoutException eTimeoutException =
                    new TimeoutException(
                        TimeoutExpirationInformation);
                throw(eTimeoutException);
            } else {
                // no action currently
            }
            
            return result;
        }
        
        public List<IUiElement> GetElements(SearchTemplateData data, int timeout)
        {
            Timeout = timeout;
            SearchData = data;
            var startTime = System.DateTime.Now;
            Wait = true;
            
            OnStartHook();
            
            do {
                
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
