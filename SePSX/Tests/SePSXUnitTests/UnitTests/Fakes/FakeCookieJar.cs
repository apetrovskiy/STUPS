/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/15/2012
 * Time: 2:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
    using OpenQA.Selenium;
    using System.Drawing;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Description of FakeCookieJar.
    /// </summary>
    public class FakeCookieJar : ICookieJar
    {
        public FakeCookieJar()
        {
        }
        
        public ReadOnlyCollection<Cookie> AllCookies {
            get {
                throw new NotImplementedException();
            }
        }
        
        public void AddCookie(Cookie cookie)
        {
            throw new NotImplementedException();
        }
        
        public Cookie GetCookieNamed(string name)
        {
            throw new NotImplementedException();
        }
        
        public void DeleteCookie(Cookie cookie)
        {
            throw new NotImplementedException();
        }
        
        public void DeleteCookieNamed(string name)
        {
            throw new NotImplementedException();
        }
        
        public void DeleteAllCookies()
        {
            throw new NotImplementedException();
        }
    }
}
