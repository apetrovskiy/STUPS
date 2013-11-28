/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/20/2013
 * Time: 12:39 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests
{
    using System;
    using System.Windows.Automation;
    using UIAutomation;
    using NSubstitute;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of FakeFactory.
    /// </summary>
    public class FakeFactory
    {
        public static void Init()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
            ObjectsFactory.InitUnitTests();
        }
        
        private static IMySuperValuePattern GetValuePattern(string txtValue)
        {
            IMySuperValuePattern valuePattern = Substitute.For<IMySuperValuePattern>();
            IValuePatternInformation valuePatternInformation = Substitute.For<IValuePatternInformation>();
            valuePatternInformation.Value.Returns(txtValue);
            valuePattern.Current.Returns(valuePatternInformation);
            return valuePattern;
        }
        
        public static IMySuperWrapper GetAutomationElement(ControlType controlType, string name, string automationId, string className, string txtValue)
        {
            IMySuperWrapper element = Substitute.For<IMySuperWrapper>();
            element.Current.ProcessId.Returns(333);
            element.Current.ControlType.Returns(controlType);
            element.Current.Name.Returns(!string.IsNullOrEmpty(name) ? name : string.Empty);
            element.Current.AutomationId.Returns(!string.IsNullOrEmpty(automationId) ? automationId : string.Empty);
            element.Current.ClassName.Returns(!string.IsNullOrEmpty(className) ? className : string.Empty);
            IMySuperValuePattern valuePattern = FakeFactory.GetValuePattern(txtValue);
            element.GetSupportedPatterns().Returns(new AutomationPattern[] { ValuePattern.Pattern });
            element.GetCurrentPattern(ValuePattern.Pattern).Returns(valuePattern);
            object patternObject;
            element.TryGetCurrentPattern(ValuePattern.Pattern, out patternObject).Returns(true);
            return element;
        }
        
        public static GetControlCollectionCmdletBase Get_GetControlCollectionCmdletBase(ControlType controlType, string name, string automationId, string className, string txtValue)
        {
            GetControlCollectionCmdletBase cmdlet = Substitute.For<GetControlCollectionCmdletBase>();
            if (null != controlType) {
                cmdlet.ControlType.Returns(
                    new[] {
                        controlType.ProgrammaticName.Substring(12)
                    }
                   );
            }
            cmdlet.Name.Returns(!string.IsNullOrEmpty(name) ? name : string.Empty);
            cmdlet.AutomationId.Returns(!string.IsNullOrEmpty(automationId) ? automationId : string.Empty);
            cmdlet.Class.Returns(!string.IsNullOrEmpty(className) ? className : string.Empty);
            cmdlet.Value.Returns(!string.IsNullOrEmpty(txtValue) ? txtValue : string.Empty);
            return cmdlet;
        }
        
        public static GetControlCollectionCmdletBase Get_GetControlCollectionCmdletBase(ControlType controlType, string searchString)
        {
            GetControlCollectionCmdletBase cmdlet = Substitute.For<GetControlCollectionCmdletBase>();
            if (null != controlType) {
                cmdlet.ControlType.Returns(
                    new[] {
                        controlType.ProgrammaticName.Substring(12)
                    }
                   );
            }
            cmdlet.ContainsText.Returns(!string.IsNullOrEmpty(searchString) ? searchString : string.Empty);
            return cmdlet;
        }
        
        // 20131128
        // public static IMySuperWrapper GetElement_ForFindAll(IEnumerable<IMySuperWrapper> elements, AndCondition conditions)
        public static IMySuperWrapper GetElement_ForFindAll(IEnumerable<IMySuperWrapper> elements, Condition conditions)
        {
            //IMySuperWrapper element = Substitute.For<IMySuperWrapper>();
            IMySuperWrapper element =
                GetAutomationElement(ControlType.Pane, string.Empty, string.Empty, string.Empty, string.Empty);
            IMySuperCollection descendants = ObjectsFactory.GetMySuperCollection(elements);
            
            // 20131128
            Condition[] condCollection = null;
            if (conditions is AndCondition) {
                condCollection = (conditions as AndCondition).GetConditions();
            }
            if (conditions is OrCondition) {
                condCollection = (conditions as OrCondition).GetConditions();
            }
            // 20131128
            // foreach (Condition cond in conditions.GetConditions()) {
            foreach (Condition cond in condCollection) {
                
                if (cond is PropertyCondition &&
                    Equals((cond as PropertyCondition).Property, AutomationElement.NameProperty)) {

                    foreach (IMySuperWrapper element1 in descendants
                        .Cast<IMySuperWrapper>()
                        .Where(element1 => "null" != element1.Tag &&
                            element1.Current.Name != (cond as PropertyCondition).Value.ToString()))
                    {
                        element1.Tag = "null";
                    }
                }
                
                if (cond is PropertyCondition &&
                    Equals((cond as PropertyCondition).Property, AutomationElement.AutomationIdProperty)) {

                    foreach (IMySuperWrapper element2 in descendants
                        .Cast<IMySuperWrapper>()
                        .Where(element2 => "null" != element2.Tag &&
                            element2.Current.AutomationId != (cond as PropertyCondition).Value.ToString()))
                    {
                        element2.Tag = "null";
                    }
                }
                
                if (cond is PropertyCondition &&
                    Equals((cond as PropertyCondition).Property, AutomationElement.ClassNameProperty)) {

                    foreach (IMySuperWrapper element3 in descendants
                        .Cast<IMySuperWrapper>()
                        .Where(element3 => "null" != element3.Tag &&
                            element3.Current.ClassName != (cond as PropertyCondition).Value.ToString()))
                    {
                        element3.Tag = "null";
                    }
                }
                
                if (cond is PropertyCondition &&
                    Equals((cond as PropertyCondition).Property, ValuePattern.ValueProperty)) {
                    
                    foreach (IMySuperWrapper element4 in descendants
                        .Cast<IMySuperWrapper>()
                        .Where(element4 => "null" != element4.Tag &&
                               (element4.GetCurrentPattern(ValuePattern.Pattern) as IMySuperValuePattern).Current.Value != (cond as PropertyCondition).Value.ToString()))
                    {
                        element4.Tag = "null";
                    }
                }
                
                if (!(cond is PropertyCondition) ||
                    !Equals((cond as PropertyCondition).Property, AutomationElement.ControlTypeProperty)) continue;

                foreach (IMySuperWrapper element5 in descendants
                    .Cast<IMySuperWrapper>()
                    .Where(element5 => "null" != element5.Tag &&
                        element5.Current.ControlType.Id.ToString() != (cond as PropertyCondition).Value.ToString()))
                {
                    element5.Tag = "null";
                }
            }
            
            IMySuperCollection descendants2 = ObjectsFactory.GetMySuperCollection();
            foreach (IMySuperWrapper elt in descendants
                .Cast<IMySuperWrapper>()
                .Where(elt => "null" != elt.Tag))
            {
                descendants2.SourceCollection.Add(elt);
            }
            
            element.FindAll(TreeScope.Descendants, Arg.Any<Condition>()).Returns(descendants2);
            return element;
        }
    }
}
