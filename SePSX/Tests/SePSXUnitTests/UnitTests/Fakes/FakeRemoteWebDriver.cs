/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 12:38 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Interactions.Internal;
    using OpenQA.Selenium.Internal;
    using System.Drawing;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using SePSX;

    /// <summary>
    /// Description of FakeRemoteWebDriver.
    /// </summary>
    public class FakeRemoteWebDriver : RemoteWebDriver
    {
        //public RemoteWebDriver(Uri remoteAddress, ICapabilities desiredCapabilities) 
        public FakeRemoteWebDriver(Uri remoteAddress, ICapabilities desiredCapabilities) :
            base(remoteAddress, desiredCapabilities)
        {
        }
        
        internal Response InternalExecute(string driverCommandToExecute, Dictionary<string, object> parameters)
        {
            //return this.Execute(driverCommandToExecute, parameters);
            
            Response resp =
                new Response();
            
            if ("getElementTagName" == driverCommandToExecute) {
                resp.Value = this.TagNameResponse;
            }
            if ("getElementText" == driverCommandToExecute) {
                resp.Value = this.TextResponse;
            }
            if ("isElementEnabled" == driverCommandToExecute) {
                resp.Value = this.EnabledResponse;
            }
            if ("isElementSelected" == driverCommandToExecute) {
                resp.Value = this.SelectedResponse;
            }
            if ("isElementDisplayed" == driverCommandToExecute) {
                resp.Value = this.DisplayedResponse;
            }
//            if ("" == driverCommandToExecute) {
//                
//            }
//            if ("" == driverCommandToExecute) {
//                
//            }
//            if ("" == driverCommandToExecute) {
//                
//            }
//            if ("" == driverCommandToExecute) {
//                
//            }
//            if ("" == driverCommandToExecute) {
//                
//            }

            return resp;
        }
        
        internal string TagNameResponse { get; set; }
        internal string TextResponse { get; set; }
        internal bool EnabledResponse { get; set; }
        internal bool DisplayedResponse { get; set; }
        internal bool SelectedResponse { get; set; }
    }
}
