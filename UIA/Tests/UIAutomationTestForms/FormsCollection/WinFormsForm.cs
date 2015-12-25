/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12.12.2011
 * Time: 12:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTestForms
{
    using System;
    using System.Windows.Forms;
    using System.Collections;
    
    /// <summary>
    /// Description of WinFormsForm.
    /// </summary>
    public partial class WinFormsForm : Form
    {
        //        public WinFormsForm()
        //        {
        //            //  // The InitializeComponent() call is required for Windows Forms designer support.
        //            // InitializeComponent();
        //
        //            //  // TODO: Add constructor code after the InitializeComponent() call.
        //            //
        //        }
        
        protected WinFormsForm(
            string formName,
            string formTitle,
            System.Windows.Automation.ControlType controlType,
            int controlDelay)
        {
            ControlType = controlType;
            ControlDelay = controlDelay;
            FormName = formName;
            FormTitle = formTitle;
            
            if (FormName == "WinFormsNoTaskBar") {
                FormBorderStyle = FormBorderStyle.FixedToolWindow;
                this.Visible = false;
                AllowTransparency = true;
                ControlBox = false;
                ShowIcon = false;
                ShowInTaskbar = false;
            }
            
            //this.ChildForm = this;
            //  // The InitializeComponent() call is required for Windows Forms designer support.
            // 
            InitializeComponent();
            
            //  // TODO: Add constructor code after the InitializeComponent() call.
            // 
        }
        
        protected WinFormsForm(
            string formName,
            string formTitle,
            System.Windows.Automation.ControlType controlType,
            string controlName,
            string controlAutomationId,
            int controlDelay)
        {
            ControlType = controlType;
            ControlDelay = controlDelay;
            ControlName = controlName;
            ControlAutomationId = controlAutomationId;
            FormName = formName;
            FormTitle = formTitle;
            
            if (FormName == "WinFormsNoTaskBar") {
                FormBorderStyle = FormBorderStyle.FixedToolWindow;
                this.Visible = false;
                AllowTransparency = true;
                ControlBox = false;
                ShowIcon = false;
                ShowInTaskbar = false;
            }
            
            //this.ChildForm = this;
            //  // The InitializeComponent() call is required for Windows Forms designer support.
            // 
            InitializeComponent();
            
            //  // TODO: Add constructor code after the InitializeComponent() call.
            // 
        }
        
        protected WinFormsForm(
            string formName,
            string formTitle,
            ControlToForm[] controlToForm)
        {
//            this.ControlType = controlType;
//            this.ControlDelay = controlDelay;
//            this.ControlName = controlName;
//            this.ControlAutomationId = controlAutomationId;
            
            controlsArray = controlToForm;
            
            FormName = formName;
            FormTitle = formTitle;
            
            if (FormName == "WinFormsNoTaskBar") {
                FormBorderStyle = FormBorderStyle.FixedToolWindow;
                this.Visible = false;
                AllowTransparency = true;
                ControlBox = false;
                ShowIcon = false;
                ShowInTaskbar = false;
            }
            
            //this.ChildForm = this;
            //  // The InitializeComponent() call is required for Windows Forms designer support.
            // 
            InitializeComponent();
            
            //  // TODO: Add constructor code after the InitializeComponent() call.
            // 
        }
        
        private ControlToForm[] controlsArray { get; set; }
        
        protected System.Windows.Automation.ControlType ControlType;
        protected int ControlDelay;
        protected Form ChildForm;
        protected string ControlName;
        protected string ControlAutomationId;
        string FormName;
        string FormTitle;
        
        void WinFormsFormShown(object sender, EventArgs e)
        {
            if ((null == ControlType) &&
                (null == controlsArray ||
                controlsArray.Length == 0)) {
                return;
            }
            
            ControlToForm[] arr;
            if (null == controlsArray &&
                null != ControlType) {
                var ctf = new ControlToForm();
                ctf.ControlType = ControlType;
                ctf.ControlName = ControlName;
                ctf.ControlAutomationId = ControlAutomationId;
                ctf.ControlDelayEn = ControlDelay;
                var arrList = new ArrayList();
                arrList.Add(ctf);
                arr = (ControlToForm[])arrList.ToArray(typeof(ControlToForm));
            } else {
                arr = controlsArray;
            }

            for (int i = 0; i < arr.Length; i++) {
                
                string _controlType = arr[i].ControlType.ProgrammaticName.Substring(
                                          arr[i].ControlType.ProgrammaticName.IndexOf(".") + 1);
                arr[i].ControlTypeAsString = _controlType;
                switch (_controlType) {
                    case "Button":
                        var b = new Button();
                        loadControl(b, arr[i]);
                        break;
                    case "MonthCalendar":
                    case "Calendar":
                        var mc = new MonthCalendar();
                        loadControl(mc, arr[i]);
                        break;
                    case "CheckBox":
                        var chk = new CheckBox();
                        loadControl(chk, arr[i]);
                        break;
                    case "ComboBox":
                        var cmb = new ComboBox();
                        loadControl(cmb, arr[i]);
                        break;
                    case "GroupBox":
                    case "Group":
                        var gb = new GroupBox();
                        loadControl(gb, arr[i]);
                        break;
                    case "Label":
                    case "Text":
                        var l = new Label();
                        loadControl(l, arr[i]);
                        break;
                    case "ListBox":
                    case "List":
                        var lb = new ListBox();
                        loadControl(lb, arr[i]);
                        break;
                    case "ListView":
                    //case "Table":
                        var lv = new ListView();
                        loadControl(lv, arr[i]);
                        break;
                    case "MenuBar":
                        var ms = new MenuStrip();
                        loadControl(ms, arr[i]);
                        break;
                    case "ProgressBar":
                        var pb = new ProgressBar();
                        loadControl(pb, arr[i]);
                        break;
                    case "RadioButton":
                        var rb = new RadioButton();
                        loadControl(rb, arr[i]);
                        break;
                    case "RichTextBox":
                    case "Document":
                        var rtb = new RichTextBox();
                        loadControl(rtb, arr[i]);
                        break;
                    case "StatusBar":
                        var sb = new StatusBar();
                        loadControl(sb, arr[i]);
                        break;
                    case "Table":
                        var pg = new PropertyGrid();
                        loadControl(pg, arr[i]);
                        break;
                    case "TextBox":
                    case "Edit":
                        var tb = new TextBox();
                        loadControl(tb, arr[i]);
                        break;
                    case "TreeView":
                    case "Tree":
                        var tv = new TreeView();
                        loadControl(tv, arr[i]);
                        break;
                    default:
                        //System.Windows.Forms.DataGridTextBox
                        //System.Windows.Forms.DataGridView
                        //System.Windows.Forms.GridItem
                        //System.Windows.Forms.DomainUpDown
                        //System.Windows.Forms.RichTextBox
                        //System.Windows.Automation.ControlType.Document
                        break;
                } // switch (_controlType)
                
                Application.DoEvents();
                
            } // for (int i = 0; i < arr.Length; i++)
            
            //Application.DoEvents();
        }
        
        private void loadControl<T>(T control, string _controlType)
        {
            try {
                (control as Control).GetType()
                    .GetProperty("Text")
                    .SetValue(control, ControlName != string.Empty ? ControlName : _controlType, null);

                /*
                if (this.ControlName != string.Empty){
                    (control as System.Windows.Forms.Control).GetType().GetProperty("Text").SetValue(control, this.ControlName, null);
                } else {
                    (control as System.Windows.Forms.Control).GetType().GetProperty("Text").SetValue(control, _controlType, null);
                }
                */
                (control as Control).GetType()
                    .GetProperty("Name")
                    .SetValue(control,
                    ControlAutomationId != string.Empty ? ControlAutomationId : _controlType, null);

                /*
                if (this.ControlAutomationId != string.Empty){
                    (control as System.Windows.Forms.Control).GetType().GetProperty("Name").SetValue(control, this.ControlAutomationId, null);
                } else {
                    (control as System.Windows.Forms.Control).GetType().GetProperty("Name").SetValue(control, _controlType, null);
                }
                */
                (control as Control).Visible = false;
                var r = new Random();
                (control as Control).Left = 
                    r.Next(0, this.Width - 20);
                (control as Control).Top = 
                    r.Next(0, this.Height - 20);
                ChildForm.Controls.Add(control as Control);
                
                var showControlDelegate = new ShowControl(runTimeout);
                showControlDelegate(ControlDelay, control as Control);
            } catch {
            }
        }
        
        private void loadControl<T>(T control, ControlToForm controlToForm)
        {
            try {
                //            if (this.ControlName != string.Empty){
                //                (control as System.Windows.Forms.Control).GetType().GetProperty("Text").SetValue(control, this.ControlName, null);
                //            } else {
                //                (control as System.Windows.Forms.Control).GetType().GetProperty("Text").SetValue(control, _controlType, null);
                //            }
                (control as Control).GetType()
                    .GetProperty("Text")
                    .SetValue(control,
                    controlToForm.ControlName != string.Empty
                            ? controlToForm.ControlName
                            : controlToForm.ControlTypeAsString, null);

                /*
                if (controlToForm.ControlName != string.Empty){
                    (control as System.Windows.Forms.Control).GetType().GetProperty("Text").SetValue(control, controlToForm.ControlName, null);
                } else {
                    (control as System.Windows.Forms.Control).GetType().GetProperty("Text").SetValue(control, controlToForm.ControlTypeAsString, null);
                }
                */
                //            if (this.ControlAutomationId != string.Empty){
                //                (control as System.Windows.Forms.Control).GetType().GetProperty("Name").SetValue(control, this.ControlAutomationId, null);
                //            } else {
                //                (control as System.Windows.Forms.Control).GetType().GetProperty("Name").SetValue(control, _controlType, null);
                //            }
                (control as Control).GetType()
                    .GetProperty("Name")
                    .SetValue(control,
                    controlToForm.ControlAutomationId != string.Empty
                            ? controlToForm.ControlAutomationId
                            : controlToForm.ControlTypeAsString, null);

                /*
                if (controlToForm.ControlAutomationId != string.Empty) {
                    (control as System.Windows.Forms.Control).GetType().GetProperty("Name").SetValue(control, controlToForm.ControlAutomationId, null);
                } else {
                    (control as System.Windows.Forms.Control).GetType().GetProperty("Name").SetValue(control, controlToForm.ControlTypeAsString, null);
                }
                */
                (control as Control).Visible = false;
                var r = new Random();
                (control as Control).Left = 
                // 20130110
                //r.Next(0, this.Width - 20);
                    r.Next(0, this.Width - 50);
                (control as Control).Top = 
                // 20130110
                //r.Next(0, this.Height - 20);
                    r.Next(0, this.Height - 50);
                // this.Controls.Add(b);
                ChildForm.Controls.Add(control as Control);
                
                var showControlDelegate = new ShowControl(runTimeout);
                // WriteVerbose(this, "runScriptBlocks 5 fired");
                //showControlDelegate(this.ControlDelay, control as System.Windows.Forms.Control);
                showControlDelegate(controlToForm.ControlDelayEn, control as Control);
            } catch {
            }
        }
        
        private void runTimeout(int timeout, Control control)
        {
            System.Threading.Thread.Sleep(timeout);
            control.Visible = true;
        }
        
    }
    
    delegate void ShowControl(int timeout, Control control);
}
