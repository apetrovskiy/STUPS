// (c) Copyright Microsoft, 2012.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.



using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Automation.Providers;
using UIAComWrapperInternal;

namespace System.Windows.Automation
{
    [Flags]
    public enum ClientSideProviderMatchIndicator
    {
        None,
        AllowSubstringMatch,
        DisallowBaseClassNameMatch
    }

    // Defines a client-side provider creation function
    // I would prefer not to use UIAutomationClient types in the API surface
    // In the original API, this was a System.Windows.Automation.Providers type.
    // But I cannot pass anything but a UIAutomationClient type into 
    // the COM API's return parameter.
    public delegate IRawElementProviderSimple ClientSideProviderFactoryCallback(IntPtr hwnd, int idChild, int idObject);

    [StructLayout(LayoutKind.Sequential)]
    public struct ClientSideProviderDescription
    {
        private string _className;
        private string _imageName;
        private ClientSideProviderMatchIndicator _flags;
        private ClientSideProviderFactoryCallback _proxyFactoryCallback;

        public ClientSideProviderDescription(ClientSideProviderFactoryCallback clientSideProviderFactoryCallback, string className)
        {
            this._className = (className != null) ? className.ToLower(CultureInfo.InvariantCulture) : null;
            this._flags = ClientSideProviderMatchIndicator.None;
            this._imageName = null;
            this._proxyFactoryCallback = clientSideProviderFactoryCallback;
        }

        public ClientSideProviderDescription(ClientSideProviderFactoryCallback clientSideProviderFactoryCallback, string className, string imageName, ClientSideProviderMatchIndicator flags)
        {
            this._className = (className != null) ? className.ToLower(CultureInfo.InvariantCulture) : null;
            this._imageName = (imageName != null) ? imageName.ToLower(CultureInfo.InvariantCulture) : null;
            this._flags = flags;
            this._proxyFactoryCallback = clientSideProviderFactoryCallback;
        }

        public string ClassName
        {
            get
            {
                return this._className;
            }
        }

        public ClientSideProviderMatchIndicator Flags
        {
            get
            {
                return this._flags;
            }
        }

        public string ImageName
        {
            get
            {
                return this._imageName;
            }
        }

        public ClientSideProviderFactoryCallback ClientSideProviderFactoryCallback
        {
            get
            {
                return this._proxyFactoryCallback;
            }
        }
    }

    internal class ProxyFactoryCallbackWrapper : UIAutomationClient.IUIAutomationProxyFactory
    {
        private ClientSideProviderFactoryCallback _callback;
        private int _serialNumber;
        static private int _staticSerialNumber = 1;

        public ProxyFactoryCallbackWrapper(ClientSideProviderFactoryCallback callback)
        {
            System.Diagnostics.Debug.Assert(callback != null);
            _callback = callback;
            _serialNumber = _staticSerialNumber;
            System.Threading.Interlocked.Increment(ref _staticSerialNumber);
        }

        #region IUIAutomationProxyFactory Members

        IRawElementProviderSimple UIAutomationClient.IUIAutomationProxyFactory.CreateProvider(IntPtr hwnd, int idObject, int idChild)
        {
            IRawElementProviderSimple provider = _callback(hwnd, idChild, idObject);
            return provider;
        }

        string UIAutomationClient.IUIAutomationProxyFactory.ProxyFactoryId
        {
            get
            {
                return "ProxyFactory" + this._serialNumber.ToString();
            }
        }

        #endregion
    }

    public static class ClientSettings
    {
        // Methods
        public static void RegisterClientSideProviderAssembly(AssemblyName assemblyName)
        {
            Utility.ValidateArgumentNonNull(assemblyName, "assemblyName");

            // Load the assembly
            Assembly assembly = null;
            try
            {
                assembly = Assembly.Load(assemblyName);
            }
            catch (System.IO.FileNotFoundException)
            {
                throw new ProxyAssemblyNotLoadedException(String.Format("Assembly {0} not found", assemblyName));
            }

            // Find the official type
            string name = assemblyName.Name + ".UIAutomationClientSideProviders";
            Type type = assembly.GetType(name);
            if (type == null)
            {
                throw new ProxyAssemblyNotLoadedException(String.Format("Could not find type {0} in assembly {1}", name, assemblyName));
            }

            // Find the descriptor table
            FieldInfo field = type.GetField("ClientSideProviderDescriptionTable", BindingFlags.Public | BindingFlags.Static);
            if ((field == null) || (field.FieldType != typeof(ClientSideProviderDescription[])))
            {
                throw new ProxyAssemblyNotLoadedException(String.Format("Could not find register method on type {0} in assembly {1}", name, assemblyName));
            }

            // Get the table value
            ClientSideProviderDescription[] clientSideProviderDescription = field.GetValue(null) as ClientSideProviderDescription[];

            // Write it through
            if (clientSideProviderDescription != null)
            {
                ClientSettings.RegisterClientSideProviders(clientSideProviderDescription);
            }
        }

        public static void RegisterClientSideProviders(ClientSideProviderDescription[] clientSideProviderDescription)
        {
            Utility.ValidateArgumentNonNull(clientSideProviderDescription, "clientSideProviderDescription ");

            // Convert providers to native code representation
            List<UIAutomationClient.IUIAutomationProxyFactoryEntry> entriesList = 
                new List<UIAutomationClient.IUIAutomationProxyFactoryEntry>();           
            foreach (ClientSideProviderDescription provider in clientSideProviderDescription)
            {
                // Construct a wrapper for the proxy factory callback
                Utility.ValidateArgumentNonNull(provider.ClientSideProviderFactoryCallback, "provider.ClientSideProviderFactoryCallback");
                ProxyFactoryCallbackWrapper wrapper = new ProxyFactoryCallbackWrapper(provider.ClientSideProviderFactoryCallback);
                
                // Construct a factory entry
                UIAutomationClient.IUIAutomationProxyFactoryEntry factoryEntry =
                    Automation.Factory.CreateProxyFactoryEntry(wrapper);
                factoryEntry.AllowSubstringMatch = ((provider.Flags & ClientSideProviderMatchIndicator.AllowSubstringMatch) != 0) ? 1 : 0;
                factoryEntry.CanCheckBaseClass = ((provider.Flags & ClientSideProviderMatchIndicator.DisallowBaseClassNameMatch) != 0) ? 0 : 1;
                factoryEntry.ClassName = provider.ClassName;
                factoryEntry.ImageName = provider.ImageName;

                // Add it to the list
                entriesList.Add(factoryEntry);
            }

            // Get the proxy map from Automation and restore the default table
            UIAutomationClient.IUIAutomationProxyFactoryMapping map = Automation.Factory.ProxyFactoryMapping;
            map.RestoreDefaultTable();

            // Decide where to insert
            // MSDN recommends inserting after non-control and container proxies
            uint insertBefore;
            uint count = (uint)map.count;
            for (insertBefore = 0; insertBefore < count; ++insertBefore)
            {
                string proxyFactoryId = map.GetEntry(insertBefore).ProxyFactory.ProxyFactoryId;
                if (!proxyFactoryId.Contains("Non-Control") && !proxyFactoryId.Contains("Container"))
                {
                    break;
                }
            }

            // Insert our new entries
            map.InsertEntries(insertBefore, entriesList.ToArray());
        }
    }
}