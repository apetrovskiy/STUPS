// (c) Copyright Microsoft, 2012.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.



using System;
using System.Runtime.InteropServices;
using UIAComWrapperInternal;

namespace System.Windows.Automation.Providers
{
    public static class AutomationInteropProvider
    {
        // Constants
        public const int AppendRuntimeId = 3;
        public const int InvalidateLimit = 20;
        public const int RootObjectId = -25;

        public static IRawElementProviderSimple HostProviderFromHandle(IntPtr hwnd)
        {
            Utility.ValidateArgument(hwnd != IntPtr.Zero, "HWND must not be null");
            return UiaCoreProviderApi.UiaHostProviderFromHwnd(hwnd);
        }

        public static void RaiseAutomationEvent(AutomationEvent eventId, IRawElementProviderSimple provider, AutomationEventArgs e)
        {
            Utility.ValidateArgumentNonNull(eventId, "eventId");
            Utility.ValidateArgumentNonNull(provider, "provider");
            Utility.ValidateArgumentNonNull(e, "e");
            if (e.EventId == AutomationElementIdentifiers.AsyncContentLoadedEvent)
            {
                AsyncContentLoadedEventArgs args = e as AsyncContentLoadedEventArgs;
                if (args == null)
                {
                    throw new ArgumentException("e");
                }
                UiaCoreProviderApi.UiaRaiseAsyncContentLoadedEvent(provider, args.AsyncContentLoadedState, args.PercentComplete);
            }
            else
            {
                if ((e.EventId == WindowPatternIdentifiers.WindowClosedEvent) && !(e is WindowClosedEventArgs))
                {
                    throw new ArgumentException("e");
                }
                UiaCoreProviderApi.UiaRaiseAutomationEvent(provider, eventId.Id);
            }
        }

        public static void RaiseAutomationPropertyChangedEvent(IRawElementProviderSimple element, AutomationPropertyChangedEventArgs e)
        {
            Utility.ValidateArgumentNonNull(element, "element");
            Utility.ValidateArgumentNonNull(e, "e");
            UiaCoreProviderApi.UiaRaiseAutomationPropertyChangedEvent(element, e.Property.Id, e.OldValue, e.NewValue);
        }

        public static void RaiseStructureChangedEvent(IRawElementProviderSimple provider, StructureChangedEventArgs e)
        {
            Utility.ValidateArgumentNonNull(provider, "provider");
            Utility.ValidateArgumentNonNull(e, "e");
            UiaCoreProviderApi.UiaRaiseStructureChangedEvent(provider, (UIAutomationClient.StructureChangeType)e.StructureChangeType, e.GetRuntimeId());
        }

        public static IntPtr ReturnRawElementProvider(IntPtr hwnd, IntPtr wParam, IntPtr lParam, IRawElementProviderSimple el)
        {
            Utility.ValidateArgument(hwnd != IntPtr.Zero, "HWND must not be null");
            Utility.ValidateArgumentNonNull(el, "el");
            return UiaCoreProviderApi.UiaReturnRawElementProvider(hwnd, wParam, lParam, el);
        }

        public static bool ClientsAreListening
        {
            get
            {
                return UiaCoreProviderApi.UiaClientsAreListening();
            }
        }
    }
           
}
