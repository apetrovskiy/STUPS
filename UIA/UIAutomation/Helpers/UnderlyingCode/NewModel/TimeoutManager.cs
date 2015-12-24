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
    /// <summary>
    /// Description of TimeoutManager.
    /// </summary>
    public class TimeoutManager
    {
        private int _givenTimeout;
        
        public int CalculatedDelay { get; set; }
        
        public TimeoutManager(int timeout)
        {
            _givenTimeout = timeout;
        }
        
        public int CalculateAdaptiveDelay()
        {
            int delay = _givenTimeout;
            if (0 == delay) {
                delay = Preferences.OnSleepDelay;
            } else if (delay <= 5000) {
                delay /= 20;
            } else if (delay <= 20000) {
                delay /= 40;
            } else if (delay <= 60000) {
                delay /= 60;
            } else if (delay <= 600000) {
                delay /= 100;
            } else {
                delay /= 200;
            }
            if (delay < Preferences.OnSleepDelay) {
                delay = Preferences.OnSleepDelay;
            }
            CalculatedDelay = delay;
            return CalculatedDelay;
        }
    }
}
