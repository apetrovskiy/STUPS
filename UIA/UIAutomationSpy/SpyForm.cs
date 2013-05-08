/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 24/02/2012
 * Time: 07:18 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationSpy
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Automation;
    using System.Windows;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    
    /// <summary>
    /// Description of SpyForm.
    /// </summary>
    public partial class SpyForm : Form
    {
        
        private int tabooPID = 0;
        private string codeToRun = string.Empty;
        private static Runspace testRunSpace;

        private SpyModes spyMode = SpyModes.uIAutomationSpy;
        
        private void runPowerShellCode()
        {
            bool result = false;
            try {
                string initScript = 
                    @"ipmo '" + 
                    Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf('\\')) +
                    @"\UIAutomation.dll';" + 
                    "\r\n" +
                    @"ipmo '" + 
                    Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf('\\')) +
                    @"\TMX.dll';";
                if (SpyModes.seleniumSpy == spyMode) {
                    initScript +=
                        "\r\n" +
                        @"try {" +
                        @"ipmo '" + 
                        Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf('\\')) +
                        @"\SePSX.dll'; } catch {}";
                }
                result = createRunspace(initScript);
                if (result) {
                    string autoInitScript = Application.ExecutablePath.Replace("exe", "ps1");
                    if (System.IO.File.Exists(autoInitScript)) {
                        processScript(autoInitScript);
                    }
                    processScript(this.codeToRun);
                }
                destroyRunspace();
            }
            catch {
                
            }
        }
        
        private bool createRunspace(string command)
        {
            bool result = false;
            try {
                testRunSpace = null;
                testRunSpace = RunspaceFactory.CreateRunspace();
                testRunSpace.Open();
                Pipeline cmd = 
                    testRunSpace.CreatePipeline(command);
                cmd.Invoke();
                result = true;
            } 
            catch (Exception eInitRunspace) {

                this.richResults.Text += eInitRunspace.Message;
                this.richResults.Text += "\r\n";
                result = false;
            }
            return result;
            //Screen.PrimaryScreen.Bounds.Width
        }
        private System.Collections.ObjectModel.Collection<PSObject> processScript(string codeSnippet)
        {
            System.Collections.ObjectModel.Collection<PSObject> result = null;
            System.Collections.Generic.List<PSObject> resultList = 
                new System.Collections.Generic.List<PSObject>();

            this.richResults.Text = string.Empty;
            try {
                this.pGridElement.SelectedObject = null;
                Pipeline cmd = 
                    testRunSpace.CreatePipeline(codeSnippet);
                System.Collections.ObjectModel.Collection<PSObject> resultObject = 
                    cmd.Invoke();
                if (resultObject.Count > 0) {
                    if (resultObject.Count == 1) {
                        this.pGridElement.SelectedObject = resultObject[0];
                        this.richResults.Text += resultObject[0].ToString();
                        this.richResults.Text += "\r\n";
                    }
                    if (resultObject.Count > 1) {
                        foreach (PSObject psObj in resultObject) {
                            resultList.Add(psObj);
                            this.richResults.Text += psObj.ToString();
                            this.richResults.Text += "\r\n";
                        }
                        this.pGridElement.SelectedObjects = 
                            resultList.ToArray();
                    }
                }
                return resultObject;
            } 
            catch (Exception eRunspace) {

                this.richResults.Text += eRunspace.Message;
                this.richResults.Text += "\r\n";
                throw(eRunspace);
            }
        }
        private void destroyRunspace()
        {

            try {
                testRunSpace.Close();
                testRunSpace.Dispose();
                testRunSpace = null;
            }
            catch (Exception eee) {
                this.txtFullCode.Text = eee.Message;
            }
        }

        public SpyForm(SpyModes spyMode)
        {
            this.spyMode = spyMode;
            
            //  // The InitializeComponent() call is required for Windows Forms designer support.
            // 
            
            InitializeComponent();
            
            try {
            this.tabooPID = 
                System.Diagnostics.Process.GetCurrentProcess().Id;
            } 
            catch (Exception eee) {
                this.txtFullCode.Text = eee.Message;
            }
            //  // TODO: Add constructor code after the InitializeComponent() call.
            // 
            
            switch (spyMode) {
                case SpyModes.uIAutomationSpy:
                    this.switchToUIAutomationSpyMode();
                    break;
                case SpyModes.seleniumSpy:
                    this.switchToSeleniumSpyMode();
                    break;
                default:
                    this.switchToUIAutomationSpyMode();
                    break;
            }
        }
        
        void SpyFormLeave(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
        
        void SpyFormDeactivate(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
        
        void BtnRunAllClick(object sender, EventArgs e)
        {
            this.menuAutomationState_RunScript();
            
            this.codeToRun = this.txtScript.Text;
            this.runPowerShellCode();

            this.menuAutomationState_ReadyToAll();
        }
        
        void BtnRunSelClick(object sender, EventArgs e)
        {
            this.menuAutomationState_RunScript();

            this.codeToRun = this.txtScript.SelectedText;
            this.runPowerShellCode();

            this.menuAutomationState_ReadyToAll();
        }
        
        void BtnBreakPSClick(object sender, EventArgs e)
        {
            this.menuAutomationState_ReadyToAll();
            
            try {
                testRunSpace.CloseAsync();
                testRunSpace = null;
            }
            catch {
                
            }
        }
        
        void btnStartClick(object sender, System.EventArgs e)
        {
            switch (this.spyMode) {
                case SpyModes.uIAutomationSpy:
                    startSpying_UIAutomation();
                    break;
                case SpyModes.seleniumSpy:
                    startSpying_Selenium();
                    break;
                default:
                    startSpying_UIAutomation();
                    break;
            }
        }
        
        private string getNodeNameFromAutomationElement(AutomationElement element)
        {
            string result = string.Empty;
                
            string ancName = string.Empty;
            string ancAuId = string.Empty;
            string ancClass = string.Empty;
            string ancControlType = string.Empty;
                                            
            try {
                ancName = element.Current.Name;
            } catch {}
            try {
                ancAuId = element.Current.AutomationId;
            } catch {}
            try {
                ancClass = element.Current.ClassName;
            } catch {}
            try {
                ancControlType = 
                    element.Current.ControlType.ProgrammaticName.Substring(
                        element.Current.ControlType.ProgrammaticName.IndexOf('.') + 1);
            } catch {}
            result = 
                "name = '" + 
                ancName +
                "'; automationId = '" +
                ancAuId + 
                "'; class = '" +
                ancClass + 
                "'; control type = '" +
                ancControlType +
                "'";
            
            return result;
        }
        
        private string getCodeFromAutomationElement(
            AutomationElement element,
            System.Windows.Automation.TreeWalker walker)
        {
            string result = string.Empty;
            
            string elementControlType = 
                element.Current.ControlType.ProgrammaticName.Substring(
                    element.Current.ControlType.ProgrammaticName.IndexOf('.') + 1);
                
            // in case this element is an upper-level Pane 
            // residing directrly under the RootElement
            // change type to window
            // i.e. Get-UIAPane - >  Get-UIAWindow
            // since Get-UIAPane is unable to get something more than
            // a window's child pane control 
            if (elementControlType == "Pane" || elementControlType == "Menu") {
                if (walker.GetParent(element) == AutomationElement.RootElement) {
                    elementControlType = "Window";
                }
            }
                
            string elementVerbosity = 
                @"Get-UIA" + elementControlType;
            try {
                if (element.Current.AutomationId.Length > 0) {
                    elementVerbosity += (" -AutomationId '" + element.Current.AutomationId + "'");
                }
            }
            catch { 
            }
            try {
                if (element.Current.ClassName.Length > 0) {
                    elementVerbosity += (" -Class '" + element.Current.ClassName + "'");
                }
            }
            catch { 
            }
            try {
                if (element.Current.Name.Length > 0) {
                    elementVerbosity += (" -Name '" + element.Current.Name + "'");
                }
            }
            catch { 
            }
            
            result = elementVerbosity;
            return result;
        }
        
        private void collectAncestry(
            ref System.Collections.Generic.List<string> listForNodes,
            ref System.Collections.Generic.List<string> listForCode,
            AutomationElement element)
        {
            this.cleanAncestry();
            
            System.Windows.Automation.TreeWalker walker = 
                new System.Windows.Automation.TreeWalker(
                    System.Windows.Automation.Condition.TrueCondition);
            System.Windows.Automation.AutomationElement testparent;
            
            try {
                testparent = element;
                //    walker.GetParent(element);
                if (testparent != null && (int)testparent.Current.ProcessId > 0) {
                    listForNodes.Add(getNodeNameFromAutomationElement(testparent));
                    if (testparent != AutomationElement.RootElement) {
                        listForCode.Add(getCodeFromAutomationElement(testparent, walker));
                    }
                }
                
                while (testparent != null && (int)testparent.Current.ProcessId > 0) {
                    testparent = 
                        walker.GetParent(testparent);
                    if (testparent != null && (int)testparent.Current.ProcessId > 0) {
                        listForNodes.Add(getNodeNameFromAutomationElement(testparent));
                        if (testparent != AutomationElement.RootElement) {
                            listForCode.Add(getCodeFromAutomationElement(testparent, walker));
                        }
                    }
                }
            } catch (Exception eNew)  {

                this.txtFullCode.Text = eNew.Message;
            }
        }
        
        void SpyFormFormClosing(object sender, FormClosingEventArgs e)
        {
            this.stopNow = true;
            this.Dispose(); //// ?
        }
        
        
        void BtnStopClick(object sender, EventArgs e)
        {
            this.stopNow = true;
            
            this.menuAutomationState_ReadyToAll();
        }
        
        void SpyFormResize(object sender, EventArgs e)
        {
            // 20130508
            // in the minimized mode
            try {
                this.tabOuter.Height = this.Height - 80;
                this.tabOuter.Width = this.Width - 40;
                
                this.tabInner.Height = this.tabOuter.Height - 40;
                this.tabInner.Width = this.tabOuter.Width - 25;
                
                this.richControlCode.Width = this.tabInner.Width - 40;
                this.richPatterns.Width = this.richControlCode.Width;
                this.txtFullCode.Width = this.richControlCode.Width;
                this.txtFullCode.Height = this.tabInner.Height - 150;
                
                this.splitContScript.SplitterDistance = 51;
            }
            catch {}
            this.TopMost = true;
        }
        
        void SpyFormFormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose(); //// ?
        }
        
        void SpyFormLoad(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
        
        private void cleanAncestry()
        {
            this.tvwHierarhy.Nodes.Clear();
            ancestorsNodesList.Clear();
            ancestorsCodeList.Clear();
        }
        
        private UIAutomation.TranscriptCmdletBase createTranscriptingCmdlet()
        {
            UIAutomation.TranscriptCmdletBase cmdlet = 
                new UIAutomation.TranscriptCmdletBase();
            cmdlet.NoClassInformation = false;
            cmdlet.NoScriptHeader = true;
            cmdlet.NoUI = true;
            cmdlet.WriteCurrentPattern = true;
            cmdlet.Timeout = 600000000;
            cmdlet.Highlight = true;
            cmdlet.HighlightParent = true;
            cmdlet.PassThru = false;
            
            UIAutomation.Preferences.TranscriptInterval = 500;
            return cmdlet;
        }
        
        private void writingAvailablePatterns(AutomationElement element)
        {
            try {
                this.richPatterns.Text = "available patterns";
                this.richPatterns.Text += "\r\n";
                
                // 20120618 UIACOMWrapper
                AutomationPattern[] supportedPatterns =
                    element.GetSupportedPatterns();
                //UIACOM::System.Windows.Automation.AutomationPattern[] supportedPatterns =
                //    element.GetSupportedPatterns();                                    
                
                if (supportedPatterns != null &&
                    supportedPatterns.Length > 0) {
                    for (int i = 0; i < supportedPatterns.Length; i++) {
                        if (i > 0) {
                            this.richPatterns.Text += "\r\n";
                        }
                        this.richPatterns.Text += 
                            supportedPatterns[i].ProgrammaticName.Replace("Identifiers.Pattern", "");
                    }
                }
            }
            catch {}
        }
        
        private AutomationElement getElementFromPoint()
        {
            AutomationElement element = null;
            
            // use Windows forms mouse code instead of WPF
            System.Drawing.Point mouse = System.Windows.Forms.Cursor.Position;

            // commented 20120618 to switch to UIACOMWrapper
            element =
                System.Windows.Automation.AutomationElement.FromPoint(
                    new System.Windows.Point(mouse.X, mouse.Y));
            //element = 
            //	//(UIANET::System.Windows.Automation.AutomationElement)
            //	UIACOM3.UIACOMHelper.GetAutomationElementFromPoint();
            
            return element;
        }
        
        private void writingAutomationElementToPropertyGridControl(AutomationElement element)
        {
            try {
                this.pGridElement.SelectedObject = 
                    element.Current;
            }
            catch {
                try {
                    this.pGridElement.SelectedObject = 
                        element.Cached;
                }
                catch {
                    
                }
            }
        }
        
        private void fillHierarchyTree()
        {
            try {
            if (ancestorsNodesList.Count > 0) {
                TreeNode previousNode = null;
                for (int i = ancestorsNodesList.Count; i > 0; i--) {
                    TreeNode node = new TreeNode(ancestorsNodesList[i - 1]);
                    
                    if (this.tvwHierarhy.Nodes.Count == 0) {
                        this.tvwHierarhy.Nodes.Add(node);
                    } else {
                        previousNode.Nodes.Add(node);
                        previousNode.Expand();
                    }
                    previousNode = node;
                }
            }
            }
            catch (Exception eNodes) {
                this.txtFullCode.Text = eNodes.Message;
            }
        }
        
        private void writeCodeGenerated()
        {
            this.txtFullCode.Text = string.Empty;
            if (ancestorsCodeList.Count > 0) {
                for (int i = ancestorsCodeList.Count; i > 0; i--) {
                    if (this.txtFullCode.Text.Length == 0) {
                        this.txtFullCode.Text += ancestorsCodeList[i - 1];
                    } else {
                        this.txtFullCode.Text += " | `\r\n";
                        this.txtFullCode.Text += ancestorsCodeList[i - 1];
                    }
                }
                
                if (this.txtFullCode.Text.Length > 0) {
                    this.scriptCurrentString = 
                        this.txtFullCode.Text;
                    if (this.scriptPreviousString !=
                        this.scriptCurrentString) {
                        this.txtScript.Text += "\r\n\r\n";
                        this.txtScript.Text += 
                            this.txtFullCode.Text;
                        this.scriptPreviousString =
                            this.scriptCurrentString;
                    }
                }
            }
        }
        
        void StartRecordingToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.btnStart.PerformClick();
        }
        
        void StopRecorgingToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.btnStop.PerformClick();
        }
        
        void RunScriptToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.btnRunAll.PerformClick();
        }
        
        void RunSelectionToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.btnRunSel.PerformClick();
        }
        
        void BreakScriptToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.btnBreakPS.PerformClick();
        }
        
        void UIAutomationToolStripMenuItemClick(object sender, EventArgs e)
        {
            // change controls
            
            switchToUIAutomationSpyMode();
            
            // code
            
        }
        
        void SeleniumToolStripMenuItemClick(object sender, EventArgs e)
        {
            // change controls
            
            switchToSeleniumSpyMode();
            
            // code
            
        }
        
        void CodeGenerationToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.tabOuter.SelectTab((int)SpyTabs.outer_Code);
            this.tabInner.SelectTab((int)SpyTabs.inner_Control);
        }
        
        void AncestryTreeToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.tabOuter.SelectTab((int)SpyTabs.outer_Code);
            this.tabInner.SelectTab((int)SpyTabs.inner_Hierarchy);
        }
        
        void PropertiesToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.tabOuter.SelectTab((int)SpyTabs.outer_Code);
            this.tabInner.SelectTab((int)SpyTabs.inner_Properties);
        }
        
        void ScriptToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.tabOuter.SelectTab((int)SpyTabs.outer_Script);
        }
        
        void ScriptResultsToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.tabOuter.SelectTab((int)SpyTabs.outer_Results);
        }
        
        void NotImplementedToolStripMenuItemClick(object sender, EventArgs e)
        {
            
        }
        
        
        
        private void menuAutomationState_ReadyToAll()
        {
            this.btnStart.Enabled = true;
            this.startRecordingToolStripMenuItem.Enabled = true;
            
            this.btnStop.Enabled = false;
            this.stopRecorgingToolStripMenuItem.Enabled = false;
            
            this.btnRunAll.Enabled = true;
            this.runScriptToolStripMenuItem.Enabled = true;
            
            this.btnRunSel.Enabled = true;
            this.runSelectionToolStripMenuItem.Enabled = true;
            
            this.btnBreakPS.Enabled = false;
            this.breakScriptToolStripMenuItem.Enabled = false;
            
        }
        
        private void menuAutomationState_RunScript()
        {
            this.btnStart.Enabled = false;
            this.startRecordingToolStripMenuItem.Enabled = false;
            
            this.btnStop.Enabled = false;
            this.stopRecorgingToolStripMenuItem.Enabled = false;
            
            this.btnRunAll.Enabled = false;
            this.runScriptToolStripMenuItem.Enabled = false;
            
            this.btnRunSel.Enabled = false;
            this.runSelectionToolStripMenuItem.Enabled = false;
            
            this.btnBreakPS.Enabled = true;
            this.breakScriptToolStripMenuItem.Enabled = true;
        }
        
        private void menuAutomationState_RunSpy()
        {
            this.btnStart.Enabled = false;
            this.startRecordingToolStripMenuItem.Enabled = false;
            
            this.btnStop.Enabled = true;
            this.stopRecorgingToolStripMenuItem.Enabled = true;
            
            this.btnRunAll.Enabled = false;
            this.runScriptToolStripMenuItem.Enabled = false;
            
            this.btnRunSel.Enabled = false;
            this.runSelectionToolStripMenuItem.Enabled = false;
            
            this.btnBreakPS.Enabled = false;
            this.breakScriptToolStripMenuItem.Enabled = false;
        }
        

        // 20121003
        private void switchToUIAutomationSpyMode()
        {
            this.uIAutomationToolStripMenuItem.Checked = true;
            this.seleniumToolStripMenuItem.Checked = false;
            this.Text = "UIAutomationSpy";
        }
        
        private void switchToSeleniumSpyMode()
        {
            this.seleniumToolStripMenuItem.Checked = true;
            this.uIAutomationToolStripMenuItem.Checked = false;
            this.Text = "SeleniumSpy";
        }
        
        private void startSpying_UIAutomation()
        {
            if (this.btnStart.Text == "Start") {
                this.stopNow = false;

                this.menuAutomationState_RunSpy();

                // 20120618 UIACOMWrapper
                AutomationElement rootElement = 
                    System.Windows.Automation.AutomationElement.RootElement;
                
                UIAutomation.TranscriptCmdletBase cmdlet = null;
                System.Windows.Automation.AutomationElement element = null;

//				UIANET::System.Windows.Automation.AutomationElement rootElement =
//                    UIANET::System.Windows.Automation.AutomationElement.RootElement;
//                
//                UIAutomation.TranscriptCmdletBase cmdlet = null;
//                UIACOM::System.Windows.Automation.AutomationElement element = null;

                do{
                    System.Windows.Forms.Application.DoEvents();
                    
                    try {
                        
                        element = 
                            this.getElementFromPoint();
                        
//                        // use Windows forms mouse code instead of WPF
//                        System.Drawing.Point mouse = System.Windows.Forms.Cursor.Position;
//
//                        // commented 20120618 to switch to UIACOMWrapper
//                        element =
//                            System.Windows.Automation.AutomationElement.FromPoint(
//                                new System.Windows.Point(mouse.X, mouse.Y));
//                        //element = 
//                        //	//(UIANET::System.Windows.Automation.AutomationElement)
//                        //	UIACOM3.UIACOMHelper.GetAutomationElementFromPoint();
                        
                        // 20120618 UIACOMWrapper
                        if (element != null && ((element as AutomationElement) != null)) { // && (int)element.Current.ProcessId > 0)
                        //if (element != null && ((element as UIACOM::System.Windows.Automation.AutomationElement) != null)) { // && (int)element.Current.ProcessId > 0)
                                cmdlet = 
                                    this.createTranscriptingCmdlet();

                                try{
                                    bool res =
                                        UIAutomation.UIAHelper.ProcessingElement(
                                            cmdlet, 
                                            element); // as UIANET::System.Windows.Automation.AutomationElement);
                                    if (!res) {
// 
                                    }
                                } 
                                catch (Exception eProcessingElement) {
                                    this.txtFullCode.Text = 
                                        "eProcessingElement element method:\r\n" + 
                                        eProcessingElement.Message;
                                    element = null;
                                    System.Threading.Thread.Sleep(
                                        UIAutomation.Preferences.TranscriptInterval);
                                    continue;
                                }
                                
                                
                            int elementPID = 0;
                            try {
                                elementPID = element.Current.ProcessId;
                            }
                            catch {
//                                this.richTextBox1.Text += 
//                                    "failed to get element.Current.ProcessId\r\n";
                                try {
                                    elementPID = element.Cached.ProcessId;
                                }
                                catch {
//                                    this.richTextBox1.Text +=
//                                        "failed to get  element.Cached.ProcessId\r\n";
                                }
                            }
                            
                            if (elementPID != this.tabooPID) { // ||
                                if (cmdlet.LastRecordedItem.Count > 0) {
                                    try {
                                        this.richControlCode.Text = cmdlet.WritingRecord(
                                            cmdlet.LastRecordedItem,
                                            null,
                                            null,
                                            null);
                                        if (this.chkClipboard.Checked) {
                                            System.Windows.Forms.Clipboard.SetDataObject(
                                                this.richControlCode.Text);
                                        }
                                        
                                    } 
                                    catch (Exception eCollectingElements) {
                                        // there is usually nothing to report
                                        this.txtFullCode.Text = 
                                            "Collecting:\r\n" + 
                                            eCollectingElements.Message;
                                        Exception eCollectingElements2 =
                                            new Exception(
                                                "Collecting (eCollectingElements):\r\n" + 
                                                eCollectingElements.Message);
                                        throw(eCollectingElements2);
                                    }
                                    
                                    // writing to the property grid control
                                    this.writingAutomationElementToPropertyGridControl(element);
                                    
                                    // writing to the family tree and the code
                                    try {
                                        
                                        //try {
                                        this.collectAncestry(
                                            ref ancestorsNodesList, 
                                            ref ancestorsCodeList,
                                            element);
                                        //}
                                        //catch (Exception eCollectAncestry) {
                                        //    this.richTextBox1.Text = eCollectAncestry.Message;
                                        //}
                                        
                                        // the Hierarchy tree
                                        this.fillHierarchyTree();

                                        // the code generated
                                        this.writeCodeGenerated();
 
                                    }
                                    catch {
                                        // 
                                    }
                                }
                                
                                writingAvailablePatterns(element);
                                
                            } // end of if (elementPID != tabooPID)
                        } // end of if (element != null && ((element as AutomationElement) != null))
                        element = null;
                        System.Threading.Thread.Sleep(
                            UIAutomation.Preferences.TranscriptInterval);
                    } catch (Exception eUnknown) {
                        this.txtFullCode.Text += 
                            "External cycle (eUnknown):\r\n" + 
                            eUnknown.Message; // +
                        
                        element = null;
                            
                        System.Threading.Thread.Sleep(
                            UIAutomation.Preferences.TranscriptInterval);
                    }
                    
                } while (!this.stopNow);
                return;
            }
        }
    }
    
    internal enum SpyTabs {
        outer_Code = 0,
        outer_Script = 1,
        outer_Results = 2,
        outer_Others = 3,
        inner_Control = 0,
        inner_Hierarchy = 1,
        inner_Properties = 2
    }
    
    public enum SpyModes {
        uIAutomationSpy,
        seleniumSpy
    }
}
