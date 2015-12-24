// (c) Copyright Microsoft, 2012.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.



using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Automation;

namespace UIAComWrapperInternal
{
    internal class EventListener
    {
        private int _eventId;
        private int[] _runtimeId;
        private Delegate _handler;

        public EventListener(int eventId, int[] runtimeId, Delegate handler)
        {
            Debug.Assert(handler != null);

            this._eventId = eventId;
            this._runtimeId = runtimeId;
            this._handler = handler;
        }

        public int EventId
        {
            get { return _eventId; }
        }

        public int[] RuntimeId
        {
            get { return _runtimeId; }
        }

        public Delegate Handler
        {
            get { return _handler; }
        }

        public override bool Equals(object obj)
        {
            EventListener listener = obj as EventListener;
            return (listener != null &&
                    this._eventId == listener.EventId &&
                    this._handler == listener.Handler &&
                    Automation.Compare(this._runtimeId, listener.RuntimeId));
        }

        public override int GetHashCode()
        {
            return _handler.GetHashCode();
        }
    }

    internal class FocusEventListener : EventListener, UIAutomationClient.IUIAutomationFocusChangedEventHandler
    {
        private AutomationFocusChangedEventHandler _focusHandler;

        public FocusEventListener(AutomationFocusChangedEventHandler handler) :
            base(AutomationElement.AutomationFocusChangedEvent.Id, null, handler)
        {
            Debug.Assert(handler != null);
            this._focusHandler = handler;
        }

        #region IUIAutomationFocusChangedEventHandler Members

        void UIAutomationClient.IUIAutomationFocusChangedEventHandler.HandleFocusChangedEvent(
            UIAutomationClient.IUIAutomationElement sender)
        {
            // Can't set the arguments -- they come from a WinEvent handler.
            AutomationFocusChangedEventArgs args = new AutomationFocusChangedEventArgs(0, 0);
            _focusHandler(AutomationElement.Wrap(sender), args);
        }

        #endregion
    }

    internal class BasicEventListener : EventListener, UIAutomationClient.IUIAutomationEventHandler
    {
        private AutomationEventHandler _basicHandler;

        public BasicEventListener(AutomationEvent eventKind, AutomationElement element, AutomationEventHandler handler) :
            base(eventKind.Id, element.GetRuntimeId(), handler)
        {
            Debug.Assert(handler != null);
            this._basicHandler = handler;
        }
        
        #region IUIAutomationEventHandler Members

        void  UIAutomationClient.IUIAutomationEventHandler.HandleAutomationEvent(
            UIAutomationClient.IUIAutomationElement sender, int eventId)
        {
            AutomationEventArgs args;
            if (eventId != WindowPatternIdentifiers.WindowClosedEvent.Id)
            {
                args = new AutomationEventArgs(AutomationEvent.LookupById(eventId));
            }
            else
            {
                args = new WindowClosedEventArgs((int[])sender.GetRuntimeId());
            }
            _basicHandler(AutomationElement.Wrap(sender), args);
        }

        #endregion
    }

    internal class PropertyEventListener : EventListener, UIAutomationClient.IUIAutomationPropertyChangedEventHandler
    {
        private AutomationPropertyChangedEventHandler _propChangeHandler;

        public PropertyEventListener(AutomationEvent eventKind, AutomationElement element, AutomationPropertyChangedEventHandler handler) :
            base(AutomationElement.AutomationPropertyChangedEvent.Id, element.GetRuntimeId(), handler)
        {
            Debug.Assert(handler != null);
            this._propChangeHandler = handler;
        }

        #region IUIAutomationPropertyChangedEventHandler Members

        void UIAutomationClient.IUIAutomationPropertyChangedEventHandler.HandlePropertyChangedEvent(
            UIAutomationClient.IUIAutomationElement sender, 
            int propertyId, 
            object newValue)
        {
            AutomationProperty property = AutomationProperty.LookupById(propertyId);
            object wrappedObj = Utility.WrapObjectAsProperty(property, newValue);
            AutomationPropertyChangedEventArgs args = new AutomationPropertyChangedEventArgs(
                property,
                null,
                wrappedObj);
            this._propChangeHandler(AutomationElement.Wrap(sender), args);
        }

        #endregion
    }

    internal class StructureEventListener : EventListener, UIAutomationClient.IUIAutomationStructureChangedEventHandler
    {
        private StructureChangedEventHandler _structureChangeHandler;

        public StructureEventListener(AutomationEvent eventKind, AutomationElement element, StructureChangedEventHandler handler) :
            base(AutomationElement.StructureChangedEvent.Id, element.GetRuntimeId(), handler)
        {
            Debug.Assert(handler != null);
            this._structureChangeHandler = handler;
        }

        #region IUIAutomationStructureChangedEventHandler Members

        void UIAutomationClient.IUIAutomationStructureChangedEventHandler.HandleStructureChangedEvent(UIAutomationClient.IUIAutomationElement sender, UIAutomationClient.StructureChangeType changeType, Array runtimeId)
        {
            StructureChangedEventArgs args = new StructureChangedEventArgs(
                (StructureChangeType)changeType,
                (int[])runtimeId);
            this._structureChangeHandler(AutomationElement.Wrap(sender), args);
        }

        #endregion
    }

    internal class ClientEventList
    {
        private static readonly System.Collections.Generic.LinkedList<EventListener> _events = new LinkedList<EventListener>();

        public static void Add(EventListener listener)
        {
            lock (_events)
            {
                _events.AddLast(listener);
            }
        }

        public static EventListener Remove(AutomationEvent eventId, AutomationElement element, Delegate handler)
        {
            // Create a prototype to seek
            int[] runtimeId = (element == null) ? null : element.GetRuntimeId();
            EventListener prototype = new EventListener(eventId.Id, runtimeId, handler);
            lock (_events)
            {
                LinkedListNode<EventListener> node = _events.Find(prototype);
                if (node == null)
                {
                    throw new ArgumentException("event handler not found");
                }
                EventListener result = node.Value;
                _events.Remove(node);
                return result;
            }
        }

        public static void Clear()
        {
            lock (_events)
            {
                _events.Clear();
            }
        }
    }
}
