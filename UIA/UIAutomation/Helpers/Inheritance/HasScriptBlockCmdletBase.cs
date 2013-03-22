/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 20/01/2012
 * Time: 09:26 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Description of HasScriptBlockCmdletBase.
    /// </summary>
    public class HasScriptBlockCmdletBase : CommonCmdletBase
    {
        #region Constructor
        public HasScriptBlockCmdletBase()
        {
            //this.WriteVerbose(this, "constructor");
            
            this.TestPassed = false;

            this.Highlight = Preferences.Highlight;
            this.HighlightParent = Preferences.HighlightParent;
//            this.HighlightFirstChild = Preferences.HighlightFirstChild;
            
            this.KnownIssue = false;
            
            // 20130322
            this.Banner = string.Empty;
        }
        #endregion Constructor

        #region Parameters
        
        // 20120816
//            #region Actions
//        [Parameter(Mandatory = false)]
//        public ScriptBlock[] OnSuccessAction { get; set; }
//        [Parameter(Mandatory = false)]
//        public ScriptBlock[] OnErrorAction { get; set; }
//        [Parameter(Mandatory = false)]
//        public virtual SwitchParameter OnErrorScreenShot { get; set; }
//        [Parameter(Mandatory = false)]
//        internal ScriptBlock[] EventAction { get; set; }
//            #endregion Actions
//            #region Testing
//        [Parameter(Mandatory = false)]
//        public virtual string TestResultName { get; set; }
//        [Parameter(Mandatory = false)]
//        public virtual string TestResultId { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter TestPassed { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter KnownIssue { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter TestLog { get; set; }
//            #endregion Testing
        // 20120208
        [Parameter(Mandatory = false)]
        public SwitchParameter Highlight { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter HighlightParent { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter HighlightFirstChild { get; set; }
        // 20130322
        [Parameter(Mandatory = false)]
        public string Banner { get; set; }
        #endregion Parameters
        
        protected internal AutomationElement ElementToSubscribe;
        // list of all subscribed events
        protected internal System.Collections.ArrayList subscribedEvents = 
            new System.Collections.ArrayList();
        protected internal System.Collections.ArrayList subscribedEventsIds = 
            new System.Collections.ArrayList();
        
//        #region declarations
//        [DllImport("user32.dll")]
//        private static extern IntPtr GetForegroundWindow();
//        #endregion declarations
        
        #region for script recording
        //internal System.Collections.ArrayList recording = 
        public System.Collections.ArrayList Recording = 
            new System.Collections.ArrayList();
        #endregion for script recording
        
        #region get active window
        protected AutomationElement GetActiveWindow()
        {
            AutomationElement result = null;
            try {
                IntPtr _hWnd = 
                    NativeMethods.GetForegroundWindow();
                WriteVerbose(this, 
                             "the handle to the active window is " + 
                             _hWnd.ToInt32().ToString());
                if (_hWnd == IntPtr.Zero) return result;
                result = 
                    AutomationElement.FromHandle(_hWnd);
                WriteVerbose(this, 
                             "the active window element is " + 
                             result.Current.Name);
            } catch (Exception e) {
                WriteVerbose(this, e.Message);
            }
            return result;
        }
        #endregion get active window
        
// #region subscribe to events
// protected internal void SubscribeToEvents(HasControlInputCmdletBase cmdlet,
// AutomationElement inputObject,
// AutomationEvent eventType,
// AutomationProperty prop)
// {
// AutomationEventHandler uiaEventHandler;
// AutomationPropertyChangedEventHandler uiaPropertyChangedEventHandler;
// StructureChangedEventHandler uiaSTructureChangedEventHandler;
// try {
// switch (eventType.ProgrammaticName) {
// case "InvokePatternIdentifiers.InvokedEvent":
// WriteVerbose(cmdlet, "subscribing to the InvokedEvent handler");
// Automation.AddAutomationEventHandler(
// InvokePattern.InvokedEvent,
// inputObject, 
// TreeScope.Element, // TreeScope.Subtree, // TreeScope.Element,
//  // uiaEventHandler = new AutomationEventHandler(OnUIAutomationEvent));
//  //uiaEventHandler = new AutomationEventHandler(handler));
//  //uiaEventHandler = new AutomationEventHandler(((EventCmdletBase)cmdlet).AutomationEventHandler));
// uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
// WriteObject(cmdlet, uiaEventHandler);
// break;
// case "TextPatternIdentifiers.TextChangedEvent":
// WriteVerbose(cmdlet, "subscribing to the TextChangedEvent handler");
// Automation.AddAutomationEventHandler(
// TextPattern.TextChangedEvent,
// inputObject, 
// TreeScope.Element,
//  // uiaEventHandler = new AutomationEventHandler(OnUIAutomationEvent));
//  //uiaEventHandler = new AutomationEventHandler(handler));
//  //uiaEventHandler = new AutomationEventHandler(((EventCmdletBase)cmdlet).AutomationEventHandler));
// uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
// WriteObject(cmdlet, uiaEventHandler);
// break;
// case "TextPatternIdentifiers.TextSelectionChangedEvent":
// WriteVerbose(cmdlet, "subscribing to the TextSelectionChangedEvent handler");
// Automation.AddAutomationEventHandler(
// TextPattern.TextSelectionChangedEvent,
// inputObject, 
// TreeScope.Element,
//  // uiaEventHandler = new AutomationEventHandler(OnUIAutomationEvent));
//  //uiaEventHandler = new AutomationEventHandler(handler));
//  //uiaEventHandler = new AutomationEventHandler(((EventCmdletBase)cmdlet).AutomationEventHandler));
// uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
// WriteObject(cmdlet, uiaEventHandler);
// break;
// case "WindowPatternIdentifiers.WindowOpenedProperty":
// WriteVerbose(cmdlet, "subscribing to the WindowOpenedEvent handler");
// Automation.AddAutomationEventHandler(
// WindowPattern.WindowOpenedEvent,
// inputObject, 
// TreeScope.Subtree,
//  // uiaEventHandler = new AutomationEventHandler(OnUIAutomationEvent));
//  //uiaEventHandler = new AutomationEventHandler(handler));
//  //uiaEventHandler = new AutomationEventHandler(((EventCmdletBase)cmdlet).AutomationEventHandler));
// uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
// WriteObject(cmdlet, uiaEventHandler);
// break;
// case "AutomationElementIdentifiers.AutomationPropertyChangedEvent":
// if (prop != null) {
// WriteVerbose(cmdlet, "subscribing to the AutomationPropertyChangedEvent handler");
// Automation.AddAutomationPropertyChangedEventHandler(
// inputObject, 
// TreeScope.Subtree,
// uiaPropertyChangedEventHandler = 
//  // new AutomationPropertyChangedEventHandler(OnUIAutomationPropertyChangedEvent),
//  //new AutomationPropertyChangedEventHandler(handler),
//  //new AutomationPropertyChangedEventHandler(((EventCmdletBase)cmdlet).AutomationPropertyChangedEventHandler),
// new AutomationPropertyChangedEventHandler(cmdlet.AutomationPropertyChangedEventHandler),
// prop);
// WriteObject(cmdlet, uiaPropertyChangedEventHandler);
// }
// break;
// case "AutomationElementIdentifiers.StructureChangedEvent":
// WriteVerbose(cmdlet, "subscribing to the StructureChangedEvent handler");
// Automation.AddStructureChangedEventHandler(
// inputObject,
// TreeScope.Subtree,
// uiaSTructureChangedEventHandler = 
//  // new StructureChangedEventHandler(OnUIStructureChangedEvent));
//  //new StructureChangedEventHandler(handler));
//  //new StructureChangedEventHandler(((EventCmdletBase)cmdlet).StructureChangedEventHandler));
// new StructureChangedEventHandler(cmdlet.StructureChangedEventHandler));
// WriteObject(cmdlet, uiaSTructureChangedEventHandler);
// break;
// case "WindowPatternIdentifiers.WindowClosedProperty":
// WriteVerbose(cmdlet, "subscribing to the WindowClosedEvent handler");
// Automation.AddAutomationEventHandler(
// WindowPattern.WindowClosedEvent,
// inputObject, 
// TreeScope.Subtree,
//  // uiaEventHandler = new AutomationEventHandler(OnUIAutomationEvent));
//  //uiaEventHandler = new AutomationEventHandler(handler));
//  //uiaEventHandler = new AutomationEventHandler(((EventCmdletBase)cmdlet).AutomationEventHandler));
// uiaEventHandler = new AutomationEventHandler(cmdlet.AutomationEventHandler));
// WriteObject(cmdlet, uiaEventHandler);
// break;
// default:
// WriteVerbose(cmdlet, 
// "the following event has not been subscribed to: " + 
// eventType.ProgrammaticName);
// break;
// }
// WriteVerbose(cmdlet, "on the object " + inputObject.Current.Name);
// } catch (Exception e) {
//// try {
//// ErrorRecord err = new ErrorRecord(
//// e,
//// "RegisteringEvent",
//// ErrorCategory.OperationStopped,
//// inputObject);
//// err.ErrorDetails = 
//// new ErrorDetails("Unable to register event handler " +
////  // handler.ToString());
//// eventType.ProgrammaticName + 
//// " for " + 
//// inputObject.Current.Name);
////  // this.OnSuccessAction.ToString());
//// WriteError(this, err, false);
//// }
//// catch {
//// ErrorRecord err = new ErrorRecord(
//// e,
//// "RegisteringEvent",
//// ErrorCategory.OperationStopped,
//// inputObject);
//// err.ErrorDetails = 
//// new ErrorDetails("Unable to register event handler " +
//// eventType.ProgrammaticName);;
//// WriteError(this, err, false);
//// }
// 
// WriteVerbose(cmdlet,
// "Unable to register event handler " +
// eventType.ProgrammaticName +
// " for " +
// inputObject.Current.Name);
// WriteVerbose(cmdlet,
// e.Message);
// }
// }
// #endregion subscribe to events
        
// #region Event handling for recording
// protected internal void OnUIRecordingAutomationEvent(object src, 
// AutomationEventArgs e)
// {
// try { // experimental
// 
// AutomationElement sourceElement;
// string elementTitle = String.Empty;
// string elementType = String.Empty;
// AutomationEvent eventId = null;
// 
// try {
// sourceElement = src as AutomationElement;
// try { elementTitle = sourceElement.Cached.Name; } catch { }
// try {
// elementType =
// sourceElement.Cached.ControlType.ProgrammaticName;
// } catch { }
//
// try {
// elementType = 
// elementType.Substring(
// elementType.IndexOf('.') + 1);
// if (elementType.Length == 0) {
// return;
// }
// } catch { }
// 
// try {
// eventId = e.EventId;
// if (sourceElement == null ||
// elementType.Length == 0 ||
// eventId == null) {
// return;
// }
// } catch { }
// } catch (ElementNotAvailableException) {
// return;
// }
//  // try {
// string whatToWrite = String.Empty;
//  // string elementType = 
//  //  // getControlTypeNameOfAutomationElement(sourceElement, sourceElement);
//  // sourceElement.Current.ControlType.ProgrammaticName.Substring(
//  // sourceElement.Current.ControlType.ProgrammaticName.IndexOf('.') + 1);
//  // if (elementType.Length == 0) {
//  // return;
//  //}
// string specificToEvent = String.Empty;
//  //
// try {
// if (eventId == AutomationElement.AsyncContentLoadedEvent) {
// specificToEvent = "#AsyncContentLoadedEvent triggered\r\n#source title: " + 
// elementTitle + " of the type " + elementType;
// }
// if (eventId == SelectionItemPattern.ElementAddedToSelectionEvent) {
// specificToEvent =
// "SelectItem -AddToSelection:$true -ItemName " + 
// elementTitle;
// }
// if (eventId == SelectionItemPattern.ElementRemovedFromSelectionEvent) {
// specificToEvent =
// "SelectItem -RemoveFromSelection:$true -ItemName " + 
// elementTitle;
// }
// if (eventId == SelectionItemPattern.ElementSelectedEvent) {
// specificToEvent =
// "SelectItem -ItemName " + 
// elementTitle;
// }
// if (eventId == SelectionPattern.InvalidatedEvent) {
// specificToEvent = "#InvalidatedEvent triggered\r\n#source title: " + 
// elementTitle + " of the type " + elementType;
// }
// if (eventId == InvokePattern.InvokedEvent) {
// specificToEvent = "Click";
// }
// if (eventId == AutomationElement.LayoutInvalidatedEvent) {
// specificToEvent = "#LayoutInvalidatedEvent triggered\r\n#source title: " + 
// elementTitle + " of the type " + elementType;
// }
// if (eventId == AutomationElement.MenuClosedEvent) {
// specificToEvent = "#MenuClosedEvent triggered\r\n#source title: " + 
// elementTitle + " of the type " + elementType;
// }
// if (eventId == AutomationElement.MenuOpenedEvent) {
// specificToEvent = "#MenuOpenedEvent triggered\r\n#source title: " + 
// elementTitle + " of the type " + elementType;
// }
// if (eventId == TextPattern.TextChangedEvent) {
// specificToEvent = "#TextChangedEvent triggered\r\n#source title: " + 
// elementTitle + " of the type " + elementType;
// }
// if (eventId == TextPattern.TextSelectionChangedEvent) {
// specificToEvent = "#TextSelectionChangedEvent triggered\r\n#source title: " + 
// elementTitle + " of the type " + elementType;
// }
// if (eventId == AutomationElement.ToolTipClosedEvent) {
// specificToEvent = "#ToolTipClosedEvent triggered\r\n#source title: " + 
// elementTitle + " of the type " + elementType;
// }
// if (eventId == AutomationElement.ToolTipOpenedEvent) {
// specificToEvent = "#ToolTipOpenedEvent triggered\r\n#source title: " + 
// elementTitle + " of the type " + elementType;
// }
// if (eventId == WindowPattern.WindowOpenedEvent) {
// specificToEvent = "#WindowOpenedEvent triggered\r\n#source title: " + 
// elementTitle + " of the type " + elementType;
// }
// if (eventId == AutomationElement.AutomationFocusChangedEvent) {
// specificToEvent = "#AutomationFocusChangedEvent triggered\r\n#source title: " + 
// elementTitle + " of the type " + elementType;
// }
// if (eventId == AutomationElement.AutomationPropertyChangedEvent) {
// specificToEvent = "#AutomationPropertyChangedEvent triggered\r\n#source title: " + 
// elementTitle + " of the type " + elementType;
//  // specificToEvent += "old value: ";
//  // specificToEvent += eventId.
// }
// if (eventId == AutomationElement.StructureChangedEvent) {
// specificToEvent = "#StructureChangedEvent triggered\r\n#source title: " + 
// elementTitle + " of the type " + elementType;
// }
// if (eventId == WindowPattern.WindowClosedEvent) {
// specificToEvent = "#WindowClosedEvent triggered\r\n#source title: " + 
// elementTitle + " of the type " + elementType;
// }
// } catch (Exception e1) {
// WriteVerbose(this,
// "Event handling for element: " + 
// sourceElement.Current.Name + 
// " eventId: " +
// eventId + 
// " failed");
// WriteVerbose(this,
// e1.Message);
// }
//// } else {
////  // handle any other events
//// }
// if (specificToEvent.Length > 0) {
// if (specificToEvent.Substring(0, 1) != "#") {
// whatToWrite += "Invoke-UIA";
// whatToWrite += elementType;
// whatToWrite += specificToEvent;
// } else {
// whatToWrite = specificToEvent;
// }
// if (whatToWrite != 
// ((System.Collections.ArrayList)this.recording[this.recording.Count - 1])[0].ToString()) {
// ((System.Collections.ArrayList)this.recording[this.recording.Count - 1]).Insert(0, whatToWrite);
// }
// }
//  //} catch { return; }
// 
// 
// } catch (Exception eUnknown) {
//  // WriteVerbose("!!!OnUIRecording " + eUnknown.Message);
// WriteDebug(this, eUnknown.Message);
// } // experimental
// try {
// WriteVerbose(this, e.EventId + "on " + (src as AutomationElement) + " fired");
// } catch { }
// }
// #endregion Event handling for recording

// #region checker event handler inputs
// [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "check")]
// protected bool checkNotNull(object objectToTest, AutomationEventArgs e)
// {
// AutomationElement sourceElement;
// try {
// sourceElement = objectToTest as AutomationElement;
// this.EventSource = sourceElement;
// this.EventArgs = e;
// } 
// catch { //(ElementNotAvailableException eNotAvailable) {
// return false;
// }
// return true;
// }
// #endregion checker event handler inputs
    }
}