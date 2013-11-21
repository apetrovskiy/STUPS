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
            if (null != controlType) {
                cmdlet.ControlType.Returns(
                    new string[] {
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
//            IMySuperCollection descendants = ObjectsFactory.GetMySuperCollection();
//            foreach (IMySuperWrapper descendant in elements) {
//                descendants.SourceCollection.Add(descendant);
//            }
            
            Condition[] conds = conditions.GetConditions();
            
            foreach (Condition cond in conds) {
                
//Console.WriteLine("mmmmmmmmmmmmmmm ForEach mmmmmmmmmmmmmmmmmmm");
//try { Console.WriteLine("condition type is " + (cond as PropertyCondition).GetType().Name); } catch {}
//try { Console.WriteLine("condition type is " + (cond as PropertyCondition).Value); } catch {}
//try { Console.WriteLine("condition type is " + (cond as PropertyCondition).Value.GetType().Name); } catch {}
                
                if (cond is PropertyCondition && (cond as PropertyCondition).Property == AutomationElement.NameProperty) {
                    foreach (IMySuperWrapper element1 in descendants) {
                        if ("null" != element1.Tag && element1.Current.Name != (cond as PropertyCondition).Value.ToString()) {
//Console.WriteLine("nullifying name 01");
                            element1.Tag = "null";
                        }
                    }
                }
                
                if (cond is PropertyCondition && (cond as PropertyCondition).Property == AutomationElement.AutomationIdProperty) {
                    foreach (IMySuperWrapper element2 in descendants) {
                        if ("null" != element2.Tag && element2.Current.AutomationId != (cond as PropertyCondition).Value.ToString()) {
//Console.WriteLine("nullifying auId 02");
                            element2.Tag = "null";
                        }
                    }
                }
                
                if (cond is PropertyCondition && (cond as PropertyCondition).Property == AutomationElement.ClassNameProperty) {
                    foreach (IMySuperWrapper element3 in descendants) {
                        if ("null" != element3.Tag && element3.Current.ClassName != (cond as PropertyCondition).Value.ToString()) {
//Console.WriteLine("nullifying class 03");
                            element3.Tag = "null";
                        }
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
                
//Console.WriteLine("///////////////////// ControlType //////////////////////////////");
                
                if (cond is PropertyCondition && (cond as PropertyCondition).Property == AutomationElement.ControlTypeProperty) {
                    
//Console.WriteLine("if");
                    
                    foreach (IMySuperWrapper element5 in descendants) {
                        
//Console.WriteLine("foreach");
//Console.WriteLine("tag = " + element5.Tag);
//if ("null" != element5.Tag) {
//    Console.WriteLine("001 'null' != element5.Tag");
//}
//if ("AutomationElementIdentifiers.ControlTypeProperty" == (cond as PropertyCondition).Property.ProgrammaticName) {
//    Console.WriteLine("002 (cond as PropertyCondition).Property.ProgrammaticName");
//    Console.WriteLine((cond as PropertyCondition).Property.ProgrammaticName);
//    Console.WriteLine((cond as PropertyCondition).Value.ToString());
//}
//Console.WriteLine("003 element5.Current.ControlType.ProgrammaticName = " + element5.Current.ControlType.ProgrammaticName);
//Console.WriteLine("003 element5.Current.ControlType.ProgrammaticName = " + element5.Current.ControlType.Id);
                        
                        if ("null" != element5.Tag && 
                            element5.Current.ControlType.Id.ToString() != (cond as PropertyCondition).Value.ToString()) {
                            
//Console.WriteLine("====================================================");
//Console.WriteLine(element5.Current.Name);
//Console.WriteLine(element5.Current.AutomationId);
//Console.WriteLine(element5.Current.ClassName);
//Console.WriteLine(element5.Current.ControlType.ProgrammaticName);
//Console.WriteLine("----------------------------------------------------");
//                            
//Console.WriteLine("nullifying controlType 05");
                            
                            element5.Tag = "null";
                        }
                    }
                }
                
            }
            
            IMySuperCollection descendants2 = ObjectsFactory.GetMySuperCollection();
            foreach (IMySuperWrapper elt in descendants) {
                //if (null != elt && null != elt.GetSourceElement()) {
                if ("null" != elt.Tag) {
                    descendants2.SourceCollection.Add(elt);
                }
            }
            
//Console.WriteLine("FindAll:");
//foreach (IMySuperWrapper elt2 in descendants2) {
//    Console.WriteLine("==================element========================");
//    Console.WriteLine(elt2.Current.Name);
//    Console.WriteLine(elt2.Current.AutomationId);
//    Console.WriteLine(elt2.Current.ClassName);
//    Console.WriteLine(elt2.Current.ControlType.ProgrammaticName);
//}
            
            //element.FindAll(TreeScope.Descendants, Arg.Any<Condition>()).Returns(descendants);
            element.FindAll(TreeScope.Descendants, Arg.Any<Condition>()).Returns(descendants2);
            return element;
        }
    }
}
