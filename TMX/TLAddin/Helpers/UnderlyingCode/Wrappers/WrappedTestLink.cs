/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/15/2012
 * Time: 5:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using Meyn.TestLink;
    
    /// <summary>
    /// Description of WrappedTestLink.
    /// </summary>
    public class WrappedTestLink : TestLink
    {
        public WrappedTestLink(string apiKey, string url) : base (apiKey, url)
        {
        }
    }
}
