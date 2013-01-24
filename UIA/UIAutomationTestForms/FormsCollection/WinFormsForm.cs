/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12.12.2011
 * Time: 12:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace UIAutomationTestForms
{
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
            this.ControlType = controlType;
            this.ControlDelay = controlDelay;
            this.FormName = formName;
            this.FormTitle = formTitle;
            
            if (FormName == "WinFormsNoTaskBar") {
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                this.Visible = false;
                this.AllowTransparency = true;
                this.ControlBox = false;
                this.ShowIcon = false;
                this.ShowInTaskbar = false;
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
            this.ControlType = controlType;
            this.ControlDelay = controlDelay;
            this.ControlName = controlName;
            this.ControlAutomationId = controlAutomationId;
            this.FormName = formName;
            this.FormTitle = formTitle;
            
            if (FormName == "WinFormsNoTaskBar") {
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                this.Visible = false;
                this.AllowTransparency = true;
                this.ControlBox = false;
                this.ShowIcon = false;
                this.ShowInTaskbar = false;
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
            
            this.controlsArray = controlToForm;
            
            this.FormName = formName;
            this.FormTitle = formTitle;
            
            if (FormName == "WinFormsNoTaskBar") {
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                this.Visible = false;
                this.AllowTransparency = true;
                this.ControlBox = false;
                this.ShowIcon = false;
                this.ShowInTaskbar = false;
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
        protected int ControlDelay; // = 0;
        protected System.Windows.Forms.Form ChildForm;
        protected string ControlName;
        protected string ControlAutomationId;
        private string FormName;
        private string FormTitle;
        
        void WinFormsFormShown(object sender, EventArgs e)
        {
// Console.WriteLine("Shown");
            //System.Threading.Thread.Sleep(this.ControlDelay);
// Console.WriteLine("Sleeped");
            if ((null == this.ControlType) &&
                (null == this.controlsArray ||
                this.controlsArray.Length == 0)) { return; }
// Console.WriteLine("not null");
            // string _controlType = this.ControlType.ToString();
//            string _controlType = this.ControlType.ProgrammaticName.Substring(
//                this.ControlType.ProgrammaticName.IndexOf(".") + 1);
// Console.WriteLine(_controlType);

            ControlToForm[] arr;
            if (null == this.controlsArray &&
                null != this.ControlType) {
                ControlToForm ctf = new ControlToForm();
                ctf.ControlType = this.ControlType;
                ctf.ControlName = this.ControlName;
                ctf.ControlAutomationId = this.ControlAutomationId;
                ctf.ControlDelayEn = this.ControlDelay;
                System.Collections.ArrayList arrList = 
                    new System.Collections.ArrayList();
                arrList.Add(ctf);
                arr = (ControlToForm[])arrList.ToArray(typeof(ControlToForm));
            } else {
//MessageBox.Show("Name = " + this.controlsArray[0].ControlName);
//MessageBox.Show("AuId = " + this.controlsArray[0].ControlAutomationId);
//                if (this.controlsArray != null) {
                    arr = this.controlsArray;
//                } else {
//                    loadControl((new Button), 
//                }
            }

            for (int i = 0; i < arr.Length; i++) {
                
                string _controlType = arr[i].ControlType.ProgrammaticName.Substring(
                    arr[i].ControlType.ProgrammaticName.IndexOf(".") + 1);
                arr[i].ControlTypeAsString = _controlType;
//this.Text += 
//    _controlType + "\t" + arr[i].ControlName + "\t" + arr[i].ControlAutomationId;
                switch (_controlType) {
                    case "Button":
                        Button b = new Button();
                        //loadControl(b, _controlType);
                        loadControl(b, arr[i]);
    //                    if (this.ControlName != string.Empty){
    //                        b.Text = this.ControlName;
    //                    } else {
    //                        b.Text = _controlType;
    //                    }
    //                    if (this.ControlAutomationId != string.Empty){
    //                        b.Name = this.ControlAutomationId;
    //                    } else {
    //                        b.Name = _controlType;
    //                    }
    //                    b.Visible = true;
    //                    // this.Controls.Add(b);
    //                    ChildForm.Controls.Add(b);
                        break;
                    case "MonthCalendar":
                    case "Calendar":
                        MonthCalendar mc = new MonthCalendar();
                        //loadControl(mc, _controlType);
                        loadControl(mc, arr[i]);
                        break;
                    case "CheckBox":
                        CheckBox chk = new CheckBox();
                        //loadControl(chk, _controlType);
                        loadControl(chk, arr[i]);
                        break;
                    case "ComboBox":
                        ComboBox cmb = new ComboBox();
                        //loadControl(cmb, _controlType);
                        loadControl(cmb, arr[i]);
                        break;
                    case "GroupBox":
                    case "Group":
                        GroupBox gb = new GroupBox();
                        //loadControl(gb, _controlType);
                        loadControl(gb, arr[i]);
                        break;
                    case "Label":
                    case "Text":
                        Label l = new Label();
                        //loadControl(l, _controlType);
                        loadControl(l, arr[i]);
                        break;
                    case "ListBox":
                    case "List":
                        ListBox lb = new ListBox();
                        //loadControl(lb, _controlType);
                        loadControl(lb, arr[i]);
                        break;
                    case "ListView":
                    //case "Table":
                        ListView lv = new ListView();
                        //loadControl(lv, _controlType);
                        loadControl(lv, arr[i]);
                        break;
                    case "MenuBar":
                        MenuStrip ms = new MenuStrip();
                        //loadControl(ms, _controlType);
                        loadControl(ms, arr[i]);
                        break;
                    case "ProgressBar":
                        ProgressBar pb = new ProgressBar();
                        //loadControl(pb, _controlType);
                        loadControl(pb, arr[i]);
                        break;
                    case "RadioButton":
                        RadioButton rb = new RadioButton();
                        //loadControl(rb, _controlType);
                        loadControl(rb, arr[i]);
                        break;
                    case "RichTextBox":
                    case "Document":
                        RichTextBox rtb = new RichTextBox();
                        //loadControl(rtb, _controlType);
                        loadControl(rtb, arr[i]);
                        break;
                    case "StatusBar":
                        StatusBar sb = new StatusBar();
                        //loadControl(sb, _controlType);
                        loadControl(sb, arr[i]);
                        break;
                    case "Table":
                        PropertyGrid pg = new PropertyGrid();
                        //loadControl(pg, _controlType);
                        loadControl(pg, arr[i]);
                        break;
                    case "TextBox":
                    case "Edit":
                        TextBox tb = new TextBox();
                        //loadControl(tb, _controlType);
                        loadControl(tb, arr[i]);
                        break;
                    case "TreeView":
                    case "Tree":
                        TreeView tv = new TreeView();
                        //loadControl(tv, _controlType);
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
                if (this.ControlName != string.Empty){
                    (control as System.Windows.Forms.Control).GetType().GetProperty("Text").SetValue(control, this.ControlName, null);
                } else {
                    (control as System.Windows.Forms.Control).GetType().GetProperty("Text").SetValue(control, _controlType, null);
                }
                if (this.ControlAutomationId != string.Empty){
                    (control as System.Windows.Forms.Control).GetType().GetProperty("Name").SetValue(control, this.ControlAutomationId, null);
                } else {
                    (control as System.Windows.Forms.Control).GetType().GetProperty("Name").SetValue(control, _controlType, null);
                }
                (control as System.Windows.Forms.Control).Visible = false;
                Random r = new Random();
                (control as System.Windows.Forms.Control).Left = 
                    r.Next(0, this.Width - 20);
                (control as System.Windows.Forms.Control).Top = 
                    r.Next(0, this.Height - 20);
                // this.Controls.Add(b);
                this.ChildForm.Controls.Add(control as System.Windows.Forms.Control);
                
                ShowControl showControlDelegate = new ShowControl(runTimeout);
                // WriteVerbose(this, "runScriptBlocks 5 fired");
                showControlDelegate(this.ControlDelay, control as System.Windows.Forms.Control);
            }
            catch {}
        }
        
        private void loadControl<T>(T control, ControlToForm controlToForm)
        {
            try {
    //            if (this.ControlName != string.Empty){
    //                (control as System.Windows.Forms.Control).GetType().GetProperty("Text").SetValue(control, this.ControlName, null);
    //            } else {
    //                (control as System.Windows.Forms.Control).GetType().GetProperty("Text").SetValue(control, _controlType, null);
    //            }
                if (controlToForm.ControlName != string.Empty){
                    (control as System.Windows.Forms.Control).GetType().GetProperty("Text").SetValue(control, controlToForm.ControlName, null);
                } else {
                    (control as System.Windows.Forms.Control).GetType().GetProperty("Text").SetValue(control, controlToForm.ControlTypeAsString, null);
                }
    //            if (this.ControlAutomationId != string.Empty){
    //                (control as System.Windows.Forms.Control).GetType().GetProperty("Name").SetValue(control, this.ControlAutomationId, null);
    //            } else {
    //                (control as System.Windows.Forms.Control).GetType().GetProperty("Name").SetValue(control, _controlType, null);
    //            }
                if (controlToForm.ControlAutomationId != string.Empty) {
                    (control as System.Windows.Forms.Control).GetType().GetProperty("Name").SetValue(control, controlToForm.ControlAutomationId, null);
                } else {
                    (control as System.Windows.Forms.Control).GetType().GetProperty("Name").SetValue(control, controlToForm.ControlTypeAsString, null);
                }
                (control as System.Windows.Forms.Control).Visible = false;
                Random r = new Random();
                (control as System.Windows.Forms.Control).Left = 
                    // 20130110
                    //r.Next(0, this.Width - 20);
                    r.Next(0, this.Width - 50);
                (control as System.Windows.Forms.Control).Top = 
                    // 20130110
                    //r.Next(0, this.Height - 20);
                    r.Next(0, this.Height - 50);
                // this.Controls.Add(b);
                this.ChildForm.Controls.Add(control as System.Windows.Forms.Control);
                
                ShowControl showControlDelegate = new ShowControl(runTimeout);
                // WriteVerbose(this, "runScriptBlocks 5 fired");
                //showControlDelegate(this.ControlDelay, control as System.Windows.Forms.Control);
                showControlDelegate(controlToForm.ControlDelayEn, control as System.Windows.Forms.Control);
            }
            catch {}
        }
        
        private void runTimeout(int timeout, System.Windows.Forms.Control control)
        {
            System.Threading.Thread.Sleep(timeout);
            control.Visible = true;
        }
        
    }
    
    delegate void ShowControl(int timeout, System.Windows.Forms.Control control);
}
