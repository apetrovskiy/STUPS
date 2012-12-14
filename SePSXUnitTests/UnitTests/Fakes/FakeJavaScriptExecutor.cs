/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/8/2012
 * Time: 10:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of JavaScriptFakeExecutor.
    /// </summary>
    public class FakeJavaScriptExecutor : IJavaScriptExecutor
    {
        public FakeJavaScriptExecutor()
        {
        }
        
        public object ExecuteScript(string script, params object[] args)
        {
            object result = null;
            
            
            
            
            return result;
        }
        
        public object ExecuteAsyncScript(string script, params object[] args)
        {
            object result = null;
            
            
            
            
            return result;
        }
    }
}
