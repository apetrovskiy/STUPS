/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/20/2013
 * Time: 12:39 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests
{
    using System;
    using System.Collections;
    using System.Windows.Automation;
    using PSTestLib;
    using UIAutomation;
    using MbUnit.Framework;
    using NSubstitute;
    using System.Linq;
    using System.Linq.Expressions;
    
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
        
        public static IMySuperWrapper GetAutomationElement(ControlType controlType, string name, string automationId, string className, string txtValue)
        {
            IMySuperWrapper element = Substitute.For<IMySuperWrapper>();
            element.Current.ControlType.Returns(controlType);
            //UIAHelper.GetControlTypeByTypeName(controlType.ProgrammaticName.Substring(controlType.ProgrammaticName.IndexOf('.')));
            element.Current.Name.Returns(!string.IsNullOrEmpty(name) ? name : string.Empty);
            element.Current.AutomationId.Returns(!string.IsNullOrEmpty(automationId) ? automationId : string.Empty);
            element.Current.ClassName.Returns(!string.IsNullOrEmpty(className) ? className : string.Empty);
            element.GetSupportedPatterns().Returns<AutomationPattern[]>(new AutomationPattern[] { SelectionItemPattern.Pattern });
            // value
            //return element as MySuperWrapper;
            return element;
        }
        
        public static GetControlCollectionCmdletBase Get_GetControlCollectionCmdletBase(ControlType controlType, string name, string automationId, string className, string txtValue)
        {
            GetControlCollectionCmdletBase cmdlet = Substitute.For<GetControlCollectionCmdletBase>();
            cmdlet.ControlType.Returns(
                new string[] {
                    controlType.ProgrammaticName.Substring(controlType.ProgrammaticName.IndexOf('.') + 1)
                }
               );
            cmdlet.Name.Returns(!string.IsNullOrEmpty(name) ? name : string.Empty);
            cmdlet.AutomationId.Returns(!string.IsNullOrEmpty(automationId) ? automationId : string.Empty);
            cmdlet.Class.Returns(!string.IsNullOrEmpty(className) ? className : string.Empty);
            cmdlet.Value.Returns(!string.IsNullOrEmpty(txtValue) ? txtValue : string.Empty);
            return cmdlet;
        }
        
        public static IMySuperWrapper GetElement_ForFindAll(IMySuperWrapper[] elements)
        {
            IMySuperWrapper element = Substitute.For<IMySuperWrapper>();
            IMySuperCollection descendants = ObjectsFactory.GetMySuperCollection();
            foreach (IMySuperWrapper descendant in elements) {
                descendants.SourceCollection.Add(descendant);
            }
            element.FindAll(TreeScope.Descendants, Arg.Any<Condition>()).Returns(descendants);
            return element;
        }
    }
}
