/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/15/2012
 * Time: 2:39 AM
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
    /// Description of FakeWindow.
    /// </summary>
    public class FakeWindow : IWindow
    {
        public FakeWindow()
        {
        }
        
        public Size Size { get; set; }
        public Point Position { get; set; }
        public void Maximize()
        {
            
        }
    }
}
