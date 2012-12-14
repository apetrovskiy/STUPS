///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 7/19/2012
// * Time: 5:37 PM
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//
//namespace SePSXTest.CheckParameters
//{
//    using System;
//    using SePSX; using MbUnit.Framework;
//    using OpenQA.Selenium;
//    
//    /// <summary>
//    /// Description of InvokeSeWebElementClickCommand.
//    /// </summary>
//    [Cmdlet(VerbsLifecycle.Invoke, "SeWebElementClick")]
//    [OutputType(typeof(IWebElement))]
//    public class InvokeSeWebElementClickCommandTestFixture // WebElementCmdletBase
//    {
//        public InvokeSeWebElementClickCommandTestFixture()
//        {
//        }
//        
//        protected override void ProcessRecord()
//        {
//            //this.checkInputWebElement(true);
//            //this.checkInputWebDriverOrWebElement();
//            this.checkInputWebElementOnly(this.InputObject);
//            
//            try {
//                ((IWebElement)this.InputObject).Click();
//                WriteObject(this, ((IWebElement)this.InputObject));
//            }
//            catch {
//                string errorMessage = 
//                    "The Click() method has failed";
//                ErrorRecord err = 
//                    new ErrorRecord(
//                        new Exception(errorMessage),
//                        "ClickFailed",
//                        ErrorCategory.InvalidArgument,
//                        this.InputObject);
//                err.ErrorDetails = 
//                    new ErrorDetails(errorMessage);
//            }
//        }
//    }
//}
