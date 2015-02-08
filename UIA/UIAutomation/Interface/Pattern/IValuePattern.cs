/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/24/2013
 * Time: 2:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    public interface IValuePattern : IBasePattern
    {
        void SetValue(string value);
        IValuePatternInformation Cached { get; }
        IValuePatternInformation Current { get; }
    }
}
