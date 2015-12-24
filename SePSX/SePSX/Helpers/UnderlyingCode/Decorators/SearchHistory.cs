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

    /// <summary>
    /// Description of SearchHistory.
    /// </summary>
    public class SearchHistory : ISearchHistory
    {
        public SearchHistory()
        {
        }

        public By ByType { get; set; }
        public string ByValue { get; set; }
        public int PositionInResult { get; set; }
    }
}
