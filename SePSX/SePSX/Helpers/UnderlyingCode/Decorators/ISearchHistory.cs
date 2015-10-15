/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/12/2012
 * Time: 3:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using OpenQA.Selenium;
    
    public interface ISearchHistory
    {
        By ByType { get; set; }
        string ByValue { get; set; }
        int PositionInResult { get; set; }
    }
}
