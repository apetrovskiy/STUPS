/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/8/2012
 * Time: 2:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Commands.Select
{
    using MbUnit.Framework;
    //using NUnit.Framework;
    using OpenQA.Selenium.Support.UI;
    using Moq;
//    using System.Drawing;
//    using System.Collections.ObjectModel;

    /// <summary>
    /// Description of GetSeSelectionCommandTestFixture.
    /// </summary>
    public class GetSeSelectionCommandTestFixture
    {
        public GetSeSelectionCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
        }
        
        private SelectElement getSelectElement(System.Collections.Generic.List<string> elements, int index)
        {
            SelectElement selectElement = null;
            
            var mock = new Mock<ISelectElement>();
            //mock.Setup(element => element.SelectByIndex(1)).
            
            
            return selectElement;
        }
        
        
        
        
//                     if (firstSelected) {
//                        cmdlet.WriteVerbose(cmdlet, "getting first selected element");
//                        resultList.Add(select.SelectedOption);
//                    }
//                    
//                    if (selected) {
//                        cmdlet.WriteVerbose(cmdlet, "getting all selected elements");
//                        foreach (IWebElement option in select.AllSelectedOptions) {
//                            resultList.Add(option);
//                        }
//                    }
//                    
//                    if (all) {
//                        cmdlet.WriteVerbose(cmdlet, "getting all elements");
//                        foreach (IWebElement oneElement in select.Options) {
//                            resultList.Add(oneElement);
//                        }
//                    }
        
        
        
        [TearDown]
        public void DisposeRunspace()
        {
            //Settings.CleanUpRecordingCollection();
        }
    }
}
