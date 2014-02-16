/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/16/2014
 * Time: 1:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Commands.Event
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;using Xunit;
    using System.Linq;
    using UIAutomation.Commands;
    using UIAutomation.Helpers.Commands;
    using NSubstitute;
    
    /// <summary>
    /// Description of EventCmdletBaseTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class EventCmdletBaseTestFixture
    {
        public EventCmdletBaseTestFixture()
        {
            FakeFactory.Init();
            UIAutomation.Preferences.UseElementsPatternObjectModel = false;
            UIAutomation.Preferences.UseElementsSearchObjectModel = false;
        }
        
        [SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [TearDown]
        public void TearDown()
        {
            TestAutomation = null;
        }
        
        internal IAutomation TestAutomation { get; set; }
        
        #region helpers
        private void TestEvent(
            EventCmdletBase cmdlet)
        {
            // Arrange
            IAutomation automation = Substitute.For<IAutomation>();
            automation.RawViewCondition.Returns(Condition.TrueCondition);
            cmdlet.UiaAutomation = automation;
            var command =
                AutomationFactory.GetCommand<EventCommand>(cmdlet);
            
            // Act
            command.Execute();
            
            // Assert
            foreach (var element in cmdlet.InputObject) {
                switch (cmdlet.GetType().Name) {
                    case "RegisterUiaFocusChangedEventCommand":
                        automation.Received(1).AddAutomationFocusChangedEventHandler(
                            new AutomationFocusChangedEventHandler(cmdlet.AutomationEventHandler));
                        break;
                    case "RegisterUiaInvokedEventCommand":
                        automation.Received(1).AddAutomationEventHandler(
                            InvokePattern.InvokedEvent,
                            (element as IUiElement),
                            TreeScope.Element,
                            new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        break;
                    case "RegisterUiaMenuClosedEventCommand":
                        automation.Received(1).AddAutomationEventHandler(
                            AutomationElement.MenuClosedEvent,
                            (element as IUiElement),
                            TreeScope.Subtree,
                            new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        break;
                    case "RegisterUiaMenuOpenedEventCommand":
                        automation.Received(1).AddAutomationEventHandler(
                            AutomationElement.MenuOpenedEvent,
                            (element as IUiElement),
                            TreeScope.Subtree,
                            new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        break;
                        
                    case "RegisterUiaToolTipClosedEventCommand":
                        automation.Received(1).AddAutomationEventHandler(
                            AutomationElement.ToolTipClosedEvent,
                            (element as IUiElement),
                            TreeScope.Subtree,
                            new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        break;
                    case "RegisterUiaToolTipOpenedEventCommand":
                        automation.Received(1).AddAutomationEventHandler(
                            AutomationElement.ToolTipOpenedEvent,
                            (element as IUiElement),
                            TreeScope.Subtree,
                            new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        break;
                        
                    case "RegisterUiaWindowClosedEventCommand":
                        automation.Received(1).AddAutomationEventHandler(
                            WindowPattern.WindowClosedEvent,
                            (element as IUiElement),
                            TreeScope.Subtree,
                            new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        break;
                    case "RegisterUiaWindowOpenedEventCommand":
                        automation.Received(1).AddAutomationEventHandler(
                            WindowPattern.WindowOpenedEvent,
                            (element as IUiElement),
                            TreeScope.Subtree,
                            new AutomationEventHandler(cmdlet.AutomationEventHandler));
                        break;
                    default:
                        
                    	break;
                }
            }
        }
        #endregion helpers
        
        [Test][Fact]
        public void FocusChangedEvent()
        {
            // Arrange
            var element =
                FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
            var cmdlet =
                new RegisterUiaFocusChangedEventCommand {
                InputObject = new IUiElement[] { element }
            };
            TestEvent(
                cmdlet);
        }
        
        [Test][Fact]
        public void InvokedEvent()
        {
            // Arrange
            var element =
                FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
            var cmdlet =
                new RegisterUiaInvokedEventCommand {
                InputObject = new IUiElement[] { element }
            };
            TestEvent(
                cmdlet);
        }
        
        [Test][Fact]
        public void MenuClosedEvent()
        {
            // Arrange
            var element =
                FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
            var cmdlet =
                new RegisterUiaMenuClosedEventCommand {
                InputObject = new IUiElement[] { element }
            };
            TestEvent(
                cmdlet);
        }
        
        [Test][Fact]
        public void MenuOpenedEvent()
        {
            // Arrange
            var element =
                FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
            var cmdlet =
                new RegisterUiaMenuOpenedEventCommand {
                InputObject = new IUiElement[] { element }
            };
            TestEvent(
                cmdlet);
        }
        
        [Test][Fact]
        public void ToolTipClosedEvent()
        {
            // Arrange
            var element =
                FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
            var cmdlet =
                new RegisterUiaToolTipClosedEventCommand {
                InputObject = new IUiElement[] { element }
            };
            TestEvent(
                cmdlet);
        }
        
        [Test][Fact]
        public void ToolTipOpenedEvent()
        {
            // Arrange
            var element =
                // FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
                AutomationFactory.GetUiElement(AutomationElement.RootElement);
                // AutomationFactory.GetUiElement();
            var cmdlet =
                new RegisterUiaToolTipOpenedEventCommand {
                InputObject = new IUiElement[] { element }
            };
            TestEvent(
                cmdlet);
        }
        
        [Test][Fact]
        public void WindowClosedEvent()
        {
            // Arrange
            var element =
                FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
            var cmdlet =
                new RegisterUiaWindowClosedEventCommand {
                InputObject = new IUiElement[] { element }
            };
            TestEvent(
                cmdlet);
        }
        
        [Test][Fact]
        public void WindowOpenedEvent()
        {
            // Arrange
            var element =
                FakeFactory.GetAutomationElementExpected(ControlType.Window, string.Empty, string.Empty, string.Empty, string.Empty);
            var cmdlet =
                new RegisterUiaWindowOpenedEventCommand {
                InputObject = new IUiElement[] { element }
            };
            TestEvent(
                cmdlet);
        }
    }
}
