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
    using System.Windows.Automation;
    using UIAutomation;
    using NSubstitute;
    using System.Linq;
    
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
        
        /*
        public class MyValuePatternInformation : IValuePatternInformation //ValuePattern.ValuePatternInformation
        {
            
        }
        */
        
        private static ValuePattern GetValuePattern(string txtValue)
        {
            ValuePattern valuePattern = Substitute.For<ValuePattern>();
            //ValuePattern.ValuePatternInformation valuePatternInformation = Substitute.For<ValuePattern.ValuePatternInformation>();
            //valuePatternInformation.Value.Returns(txtValue);
            
            //ValuePattern.ValuePatternInformation valuePatternInformation = new ValuePattern.ValuePatternInformation();
            //valuePatternInformation.Value = txtValue;
            
            //valuePattern.Current.Returns(new ValuePattern.ValuePatternInformation());
            //valuePattern.Current.Value.Returns(txtValue);
            
            //valuePattern.Current.Returns(valuePatternInformation);
            return valuePattern;
        }
        
        public static IMySuperWrapper GetAutomationElement(ControlType controlType, string name, string automationId, string className, string txtValue)
        {
            IMySuperWrapper element = Substitute.For<IMySuperWrapper>();
            element.Current.ControlType.Returns(controlType);
            element.Current.Name.Returns(!string.IsNullOrEmpty(name) ? name : string.Empty);
            element.Current.AutomationId.Returns(!string.IsNullOrEmpty(automationId) ? automationId : string.Empty);
            element.Current.ClassName.Returns(!string.IsNullOrEmpty(className) ? className : string.Empty);
            //element.GetSupportedPatterns().Returns(new[] { SelectionItemPattern.Pattern });
            ValuePattern valuePattern = FakeFactory.GetValuePattern(txtValue);
            //element.GetSupportedPatterns().Returns<object[]>(new[] { valuePattern });
            return element;
        }
        
        public static GetControlCollectionCmdletBase Get_GetControlCollectionCmdletBase(ControlType controlType, string name, string automationId, string className, string txtValue)
        {
            GetControlCollectionCmdletBase cmdlet = Substitute.For<GetControlCollectionCmdletBase>();
            if (null != controlType) {
                cmdlet.ControlType.Returns(
                    new[] {
                        controlType.ProgrammaticName.Substring(controlType.ProgrammaticName.IndexOf('.') + 1)
                    }
                   );
            }
            cmdlet.Name.Returns(!string.IsNullOrEmpty(name) ? name : string.Empty);
            cmdlet.AutomationId.Returns(!string.IsNullOrEmpty(automationId) ? automationId : string.Empty);
            cmdlet.Class.Returns(!string.IsNullOrEmpty(className) ? className : string.Empty);
            cmdlet.Value.Returns(!string.IsNullOrEmpty(txtValue) ? txtValue : string.Empty);
            return cmdlet;
        }
        
        public static IMySuperWrapper GetElement_ForFindAll(IMySuperWrapper[] elements, AndCondition conditions)
        {
            IMySuperWrapper element = Substitute.For<IMySuperWrapper>();
            IMySuperCollection descendants = ObjectsFactory.GetMySuperCollection(elements);
            
            foreach (Condition cond in conditions.GetConditions()) {
                
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
                
//                if (cond is PropertyCondition && (cond as PropertyCondition).Property == AutomationElement.ControlTypeProperty) {
//                    //foreach (IMySuperWrapper element in descendants) {
//                    for (int i = 0; i < descendants.Count; i++) {
//                        if (null != descendants[i] && descendants[i].Current.ControlType != (cond as PropertyCondition).Value) {
//                            descendants[i] = null;
//                        }
//                    }
//                }

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
        
//        public static IValuePatternAdapter GetValuePattern(string txtValue)
//        {
//            IValuePatternAdapter valuePattern = new MyValuePattern(
//        }
    }
}
