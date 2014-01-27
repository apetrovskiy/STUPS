/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/24/2014
 * Time: 8:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    
    /// <summary>
    /// Description of TimeoutManager.
    /// </summary>
    public class TimeoutManager
    {
        private int _givenTimeout;
        
        public int CalculatedTimeout { get; set; }
        
        public TimeoutManager(int timeout)
        {
            _givenTimeout = timeout;
        }
        
        public int CalculateAdaptiveTimeout()
        {
            int timeout = _givenTimeout;
            if (0 == timeout) {
                timeout = Preferences.OnSleepDelay;
            } else if (timeout <= 5000) {
                timeout /= 20;
            } else if (timeout <= 20000) {
                timeout /= 40;
            } else if (timeout <= 60000) {
                timeout /= 60;
            } else if (timeout <= 600000) {
                timeout /= 100;
            } else {
                timeout /= 200;
            }
            if (timeout < Preferences.OnSleepDelay) {
                timeout = Preferences.OnSleepDelay;
            }
            CalculatedTimeout = timeout;
            return CalculatedTimeout;
        }
    }
}
