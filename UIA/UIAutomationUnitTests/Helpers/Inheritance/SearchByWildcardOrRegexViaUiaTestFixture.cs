/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/3/2013
 * Time: 10:48 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.Inheritance
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;
    using System.Linq;
    
    /// <summary>
    /// Description of SearchByWildcardOrRegexViaUiaTestFixture.
    /// </summary>
    public class SearchByWildcardOrRegexViaUiaTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        #region helpers
        private void TestParametersAgainstCollection(
            ControlType controlType,
            string searchString,
            IEnumerable<IMySuperWrapper> collection,
            int expectedNumberOfElements)
        {
            // Arrange
            string controlTypeString = string.Empty;
            if (null != controlType) {
                controlTypeString = controlType.ProgrammaticName.Substring(12);
            }
            
            GetControlCmdletBase cmdlet =
                FakeFactory.Get_GetControlCmdletBase(controlType, searchString);
            Condition condition =
                //cmdlet.GetExactSearchCondition(cmdlet);
                cmdlet.GetTextSearchCondition(searchString, new string[]{ controlTypeString }, false);
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    collection,
                    condition);
            
            // Act
            List<IMySuperWrapper> resultList = RealCodeCaller.GetResultList_ExactSearch(cmdlet, element, condition);
            
            // Assert
            Assert.Count(expectedNumberOfElements, resultList);
            if (!string.IsNullOrEmpty(searchString)) {
                Assert.ForAll(
                    resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(),
                    x => x.Current.Name == searchString || x.Current.AutomationId == searchString || x.Current.ClassName == searchString ||
                    (null != (x.GetCurrentPattern(ValuePattern.Pattern) as IMySuperValuePattern) ? (x.GetCurrentPattern(ValuePattern.Pattern) as IMySuperValuePattern).Current.Value == searchString : false));
            }
//            if (null != controlType) {
//                Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ControlType == controlType);
//            }
        }
        #endregion helpers
        
        #region helpers
        private void TestParametersAgainstCollection(
            ControlType controlType,
            string name,
            string automationId,
            string className,
            string txtValue,
            IEnumerable<IMySuperWrapper> collection,
            int expectedNumberOfElements)
        {
            // Arrange
            string controlTypeString = string.Empty;
            if (null != controlType) {
                controlTypeString = controlType.ProgrammaticName.Substring(12);
            }
            
            GetControlCmdletBase cmdlet =
                FakeFactory.Get_GetControlCmdletBase(controlType, name, automationId, className, txtValue);
            
            Condition condition =
                cmdlet.GetWildcardSearchCondition(cmdlet);
            
            IMySuperWrapper element =
                FakeFactory.GetElement_ForFindAll(
                    collection,
                    condition);
            
            // Act
            List<IMySuperWrapper> resultList = RealCodeCaller.GetResultList_ViaWildcards(cmdlet, element, condition);
            
            // Assert
            Assert.Count(expectedNumberOfElements, resultList);
            if (!string.IsNullOrEmpty(name)) {
                Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.Name == name);
            }
            if (!string.IsNullOrEmpty(automationId)) {
                Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.AutomationId == automationId);
            }
            if (!string.IsNullOrEmpty(className)) {
                Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ClassName == className);
            }
            if (null != controlType) {
                Assert.ForAll(resultList.Cast<IMySuperWrapper>().ToList<IMySuperWrapper>(), x => x.Current.ControlType == controlType);
            }
            if (!string.IsNullOrEmpty(txtValue)) {
                Assert.ForAll(
                    resultList
                    .Cast<IMySuperWrapper>()
                    .ToList<IMySuperWrapper>(), x =>
                    {
                        IMySuperValuePattern valuePattern = x.GetCurrentPattern(ValuePattern.Pattern) as IMySuperValuePattern;
                        return valuePattern != null && valuePattern.Current.Value == txtValue;
                    });
            }
        }
        #endregion helpers
    }
}
