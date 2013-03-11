/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12.12.2011
 * Time: 1:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTestForms
{
    using System;
    using System.Windows;
    using UIAutomation.Commands;
    using UIAutomation;
    using System.Reflection;
    using UIAutomationTestForms.FormsCollection.WinForms;

    //class Program
    internal sealed class Program
    {
        //public static void Main(string[] args)
        [STAThread]
        private static void Main(string[] args)
        {
            
            // Console.WriteLine(System.Windows.Automation.ControlType.Button.ToString());
            // Console.WriteLine(System.Windows.Automation.ControlType.Button.ProgrammaticName.ToString());
            // Console.WriteLine(System.Windows.Automation.ControlType.Button.GetType().Name);
      

// Dumping types for further investigation

//            Console.WriteLine("Dumping the types...");
//            dumpTypes(System.Environment.GetEnvironmentVariable("TEMP",
//                                                                EnvironmentVariableTarget.User) + 
//                      @"\types.txt");
//            Console.WriteLine("...completed");
//                      return;

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            
            // the second command-line argument FormDelay
            if (args.Length > 1 && args[1] != null && args[1] != string.Empty)
            {
                try {
                    if ((System.Convert.ToInt32(args[0]) != 0) &&
                        (System.Convert.ToInt32(args[1]) != 0))
                    {
                        int sleepTime = 
                            System.Convert.ToInt32(args[1]);
                        System.Threading.Thread.Sleep(sleepTime);
                    }
                } catch {
                    // Console.WriteLine("Wrong arguments!Use numbers:");
                    // Console.WriteLine("TetUIAutomation Forms SleepBefore");
                    return; // 1;
                }
            }
            
// if (Delay > 0) {
// System.Threading.Thread.Sleep(Delay);
// }
            // the first command-line argument FormType
            if (args.Length > 0 && args[0] != null && args[0] != "")
            {
                Forms formCode;
                try {
                    formCode = (Forms)(System.Convert.ToInt32(args[0]));
                } catch {
                    // Console.WriteLine("Wrong arguments!Use numbers:");
                    // Console.WriteLine("TetUIAutomation Forms SleepBefore");
                    return; // 2;
                }

                // System.Windows.Forms.Application.Run(new MainForm());
                
#region reserved code
//                System.Windows.Automation.ControlType ctrlType = null;
//                
//                // the third command-line argument ControlType
//                if (args.Length > 2 && args[2] != null && args[2] != "") {
//                    // string _controlType = String.Empty;
//                    //_controlType = args[2].ToUpper();
//                    ctrlType = 
//                        UIAHelper.GetControlTypeByTypeName(args[2]);
//                }
//                
//                int controlDelay = 0;
//                
//                // the fourth command-line argument ControlDelay
//                if (args.Length > 3 && args[3] != null && args[3] != string.Empty) {
//                    try {
//                        controlDelay = System.Convert.ToInt32(args[3]);
//                    } catch { }
//                }
//                
//                string controlName = string.Empty;
//                
//                // the fifth command-line argument ControlName
//                if (args.Length > 4 && args[4] != null && args[4] != string.Empty) {
//                    try {
//                        controlName = args[4];
//                    } catch { }
//                }
//                
//                string controlAutomationId = string.Empty;
//                
//                // the sixth command-line argument ControlAutomationId
//                if (args.Length > 5 && args[5] != null && args[5] != string.Empty) {
//                    try {
//                        controlAutomationId = args[5];
//                    } catch { }
//                }
//                
//                switch (formCode)
//                {
//                    case Forms.WinFormsEmpty:
//                        System.Windows.Forms.Application.Run(
//                            new WinFormsEmpty(ctrlType, controlName, controlAutomationId, controlDelay));
//                        // WinFormsEmpty frmWFE = new WinFormsEmpty();
//                        // frmWFE.ShowDialog();
//                        break;
//                    case Forms.WinFormsEmptyX2:
//                        System.Windows.Forms.Application.Run(
//                            new WinFormsEmpty(ctrlType, controlName, controlAutomationId, controlDelay));
//                        System.Windows.Forms.Application.Run(
//                            new WinFormsEmpty(ctrlType, controlName, controlAutomationId, controlDelay));
//                        break;
//                    case Forms.WinFormsAnonymous:
//                        System.Windows.Forms.Application.Run(
//                            new WinFormsAnonymous(
//                                ctrlType, controlName, controlAutomationId, controlDelay));
//                        break;
//                    case Forms.WinFormsMinimized:
//                        System.Windows.Forms.Application.Run(
//                            new WinFormsMinimized(ctrlType, controlName, controlAutomationId, controlDelay));
//                        break;
//                    case Forms.WinFormsMaximized:
//                        System.Windows.Forms.Application.Run(
//                            new WinFormsMaximized(ctrlType, controlName, controlAutomationId, controlDelay));
//                        break;
//                    case Forms.WinFormsNoTaskBar:
//                        System.Windows.Forms.Application.Run(
//                            new WinFormsNoTaskBar(ctrlType, controlName, controlAutomationId, controlDelay));
//                        break;
//                    case Forms.WinFormsRich:
//                        System.Windows.Forms.Application.Run(
//                            new WinFormsRich(ctrlType, controlName, controlAutomationId, controlDelay));
//                        break;
//                    
//                        
//                    case Forms.WPFEmpty:
//                        WPFEmpty frmWPFE = new WPFEmpty();
//                        frmWPFE.ShowDialog();
//                        //Application.Run(new MainForm());
//                        break;
//                    case Forms.WPFEmptyX2:
//                        WPFEmpty frmWPFE1 = new WPFEmpty();
//                        frmWPFE1.ShowDialog();
//                        WPFEmpty frmWPFE2 = new WPFEmpty();
//                        frmWPFE2.ShowDialog();
//                        break;
//                    case Forms.WPFAnonymous:
//                        WPFAnonymous frmWPFA = new WPFAnonymous();
//                        frmWPFA.ShowDialog();
//                        break;
//                    case Forms.WPFMinimized:
//                        WPFMinimized frmWPFMi = new WPFMinimized();
//                        frmWPFMi.ShowDialog();
//                        break;
//                    case Forms.WPFMaximized:
//                        WPFMaximized frmWPFMa = new WPFMaximized();
//                        frmWPFMa.ShowDialog();
//                        break;
//                    case Forms.WPFCollapsed:
//                        WPFCollapsed frmWPFCo = new WPFCollapsed();
//                        frmWPFCo.ShowDialog();
//                        break;
//                        
//                }
//            }
#endregion reserved code

            System.Windows.Automation.ControlType ctrlType = null;
            int controlDelay = 0;
            string controlName = string.Empty;
            string controlAutomationId = string.Empty;
            ControlToForm[] controls = null;

            if (args.Length > 2) {
            //    ControlToForm controlToForm = new ControlToForm();
            //    for (int i = 2; i < args.Length; i++) {
            //        controlto
            //    }
            
                System.Collections.ArrayList arrList = 
                    new System.Collections.ArrayList();
                
                for (int i = 2; i < args.Length; i = i + 4) {
                    
                    ControlToForm controlToForm = 
                        new ControlToForm();
                
                    //System.Windows.Automation.ControlType ctrlType = null;
                    ctrlType = null;
                    
                    // the third command-line argument ControlType
                    if (args[i] != null && args[i] != "") {
                        ctrlType = 
                            UIAHelper.GetControlTypeByTypeName(args[i]);
                        controlToForm.ControlType = ctrlType;
                    }
                
                    //int controlDelay = 0;
                    controlDelay = 0;
                    
                    // the fourth command-line argument ControlDelay
                    if (args[i + 1] != null && args[i + 1] != string.Empty) {
                        try {
                            controlDelay = System.Convert.ToInt32(args[i + 1]);
                            controlToForm.ControlDelayEn = controlDelay;
                        } catch { }
                    }
                    
                    //string controlName = string.Empty;
                    controlName = string.Empty;
                    
                    // the fifth command-line argument ControlName
                    if (args[i + 2] != null && args[i + 2] != string.Empty) {
                        try {
                            controlName = args[i + 2];
                            controlToForm.ControlName = controlName;
                        } catch { }
                    }
                
                    //string controlAutomationId = string.Empty;
                    controlAutomationId = string.Empty;
                    
                    // the sixth command-line argument ControlAutomationId
                    if (args[i + 3] != null && args[i + 3] != string.Empty) {
                        try {
                            controlAutomationId = args[i + 3];
                            controlToForm.ControlAutomationId = controlAutomationId;
                        } catch { }
                    }
                    
                    arrList.Add(controlToForm);
                    
                } // for (int i = 2; i < args.Length; i = i + 4)
                
                controls =
                    (ControlToForm[])arrList.ToArray(typeof(ControlToForm));
            }
            
            switch (formCode)
            {
                case Forms.WinFormsEmpty:
                    System.Windows.Forms.Application.Run(
                        new WinFormsEmpty(controls));
                    break;
                case Forms.WinFormsEmptyX2:
                    System.Windows.Forms.Application.Run(
                        new WinFormsEmpty(controls));
                    System.Windows.Forms.Application.Run(
                        new WinFormsEmpty(controls));
                    break;
                case Forms.WinFormsAnonymous:
                    System.Windows.Forms.Application.Run(
                        new WinFormsAnonymous(
                            ctrlType, controlName, controlAutomationId, controlDelay));
                    break;
                case Forms.WinFormsMinimized:
                    System.Windows.Forms.Application.Run(
                        new WinFormsMinimized(ctrlType, controlName, controlAutomationId, controlDelay));
                    break;
                case Forms.WinFormsMaximized:
                    System.Windows.Forms.Application.Run(
                        new WinFormsMaximized(ctrlType, controlName, controlAutomationId, controlDelay));
                    break;
                case Forms.WinFormsNoTaskBar:
                    System.Windows.Forms.Application.Run(
                        new WinFormsNoTaskBar(ctrlType, controlName, controlAutomationId, controlDelay));
                    break;
                case Forms.WinFormsTripled:
                    System.Windows.Forms.Application.Run(
                        new WinFormsTripled(controls));
                    break;
                case Forms.WinFormsThreeSet:
                    System.Windows.Forms.Application.Run(
                        new WinFormsOuter()); //(controls));
                    break;
                case Forms.WinFormsRich:
                    System.Windows.Forms.Application.Run(
                        new WinFormsRich()); //ctrlType, controlName, controlAutomationId, controlDelay));
                    break;
                case Forms.WinFormsFull:
                    System.Windows.Forms.Application.Run(
                        new WinFormsFull()); //ctrlType, controlName, controlAutomationId, controlDelay));
                    break;
                case Forms.WinFormsWizard:
                    System.Windows.Forms.Application.Run(
                        new WinFormsWizard()); //ctrlType, controlName, controlAutomationId, controlDelay));
                    break;
                    
                    
                case Forms.WPFEmpty:
                    WPFEmpty frmWPFE = new WPFEmpty();
                    frmWPFE.ShowDialog();
                    //Application.Run(new MainForm());
                    break;
                case Forms.WPFEmptyX2:
                    WPFEmpty frmWPFE1 = new WPFEmpty();
                    frmWPFE1.ShowDialog();
                    WPFEmpty frmWPFE2 = new WPFEmpty();
                    frmWPFE2.ShowDialog();
                    break;
                case Forms.WPFAnonymous:
                    WPFAnonymous frmWPFA = new WPFAnonymous();
                    frmWPFA.ShowDialog();
                    break;
                case Forms.WPFMinimized:
                    WPFMinimized frmWPFMi = new WPFMinimized();
                    frmWPFMi.ShowDialog();
                    break;
                case Forms.WPFMaximized:
                    WPFMaximized frmWPFMa = new WPFMaximized();
                    frmWPFMa.ShowDialog();
                    break;
                case Forms.WPFCollapsed:
                    WPFCollapsed frmWPFCo = new WPFCollapsed();
                    frmWPFCo.ShowDialog();
                    break;
                case Forms.WPFFull:
                    WPFFull frmWPFFull = new WPFFull();
                    frmWPFFull.ShowDialog();
                    break;
//                case Forms.WPFWizard:
//                    WPFWizard frmWPFWizard = new WPFWizard();
//                    frmWPFWizard.ShowDialog();
//                    break;
            }
            
//            } // if (args.Length > 2)
//            else {
//                System.Windows.Forms.Application.Run(
//                    new WinFormsEmpty(ctrlType, 0));
//            }

                

                

                

                

            }

            
//            // the third command-line argument ControlType
//            if (args.Length > 2 && args[2] != null && args[2] != string.Empty)
//            {
//                
//                
//                FormControls controls;
//                try {
//                    controls = (FormControls)(System.Convert.ToInt32(args[2]));
//                } catch {
//                    // Console.WriteLine("Wrong arguments!Use numbers:");
//                    // Console.WriteLine("TetUIAutomation Forms SleepBefore");
//                    return; // 2;
//                }
//    
//                System.Windows.Forms.Application.EnableVisualStyles();
//                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
//                // System.Windows.Forms.Application.Run(new MainForm());
//                
//                
//                System.Windows.Automation.ControlType ctrlType = null;
//                if (args.Length > 2 && args[2] != null && args[2] != "") {
//                    // string _controlType = String.Empty;
//                    //_controlType = args[2].ToUpper();
//                    ctrlType = 
//                        UIAHelper.GetControlTypeByTypeName(args[2]);
//                
//                
//                try {
//                    if ((System.Convert.ToInt32(args[0]) != 0) &&
//                        (System.Convert.ToInt32(args[1]) != 0))
//                    {
//                        int sleepTime = 
//                            System.Convert.ToInt32(args[1]);
//                        System.Threading.Thread.Sleep(sleepTime);
//                    }
//                } catch {
//                    // Console.WriteLine("Wrong arguments!Use numbers:");
//                    // Console.WriteLine("TetUIAutomation Forms SleepBefore");
//                    return; // 1;
//                }
//            }
        }
        
        private static void dumpTypes(string path)
        {
            UIAutomation.ReadUIAControlIsOffscreenCommand ccc = 
                new ReadUIAControlIsOffscreenCommand();
            
            Assembly[] allAssms = 
                System.AppDomain.CurrentDomain.GetAssemblies();
            
            System.IO.StreamWriter writer = 
                new System.IO.StreamWriter(path);
            
            foreach (Assembly asm in allAssms) {
                Console.WriteLine(asm.FullName);
                if (asm.FullName.Contains("UIAutomation,")) {
                    Console.WriteLine("working...");
                    Type[] types = 
                        asm.GetTypes();
                    foreach (Type t in types) {
                        
                        if (t.FullName.Contains("UIAutomation.Commands") &&
                            t.IsPublic) {
                            // Console.WriteLine(t.FullName);
                            PropertyInfo[] properties = 
                                t.GetProperties(); // BindingFlags.Instance);
                            foreach (PropertyInfo property in properties) {
                                // Console.WriteLine(property.Name);
                                // Console.WriteLine(property.PropertyType);
                                // Console.WriteLine(property.Attributes);
                                // Console.WriteLine(t.FullName + "\t" + property.Name + "\t" + property.PropertyType);
                                if (property.Name != "ParameterSetName" && 
                                    property.Name != "MyInvocation" && 
                                    property.Name != "InvokeCommand" && 
                                    property.Name != "Host" && 
                                    property.Name != "SessionState" && 
                                    property.Name != "Events" && 
                                    property.Name != "JobRepository" && 
                                    property.Name != "InvokeProvider" && 
                                    property.Name != "Stopping" && 
                                    property.Name != "CommandRuntime" && 
                                    property.Name != "CurrentPSTransaction" && 
                                    property.Name != "CommandOrigin") {
                                    if (t.FullName.Contains(".Get") ||
                                        t.FullName.Contains(".Set") ||
                                        t.FullName.Contains(".Invoke") ||
                                        t.FullName.Contains(".Register") ||
                                        t.FullName.Contains(".Unregister") ||
                                        t.FullName.Contains(".Read") ||
                                        t.FullName.Contains(".ConvertFrom") ||
                                        t.FullName.Contains(".ConvertTo") ||
                                        t.FullName.Contains(".Move") ||
                                        t.FullName.Contains(".New") ||
                                        t.FullName.Contains(".Add") ||
                                        t.FullName.Contains(".Save") ||
                                        t.FullName.Contains(".Step") ||
                                        t.FullName.Contains(".Start") ||
                                        t.FullName.Contains(".Stop") ||
                                        t.FullName.Contains(".Wait"))
                                        {
                                    writer.WriteLine(t.FullName.Replace("UIAutomation.Commands.", "").Replace("Command", "").
                                                         Replace("UIA", "-UIA") + "\t" + property.Name + "\t" + property.PropertyType);
                                        }
                                }
                            }
                        }
                    }
                    Console.WriteLine("!");
                }
            }
            
            writer.Flush();
            writer.Close();
        }
    }
    
    public enum Forms
    {
        WinFormsEmpty = 1,
        WinFormsEmptyX2 = 2,
        WinFormsAnonymous = 3,
        WinFormsMinimized = 4,
        WinFormsMaximized = 5,
        WinFormsNoTaskBar = 11,
        WinFormsTripled = 21,
        WinFormsThreeSet = 22,
        WinFormsRich = 31,
        WinFormsFull = 32,
        WinFormsWizard = 33,
        
        
        WPFEmpty = 101,
        WPFEmptyX2 = 102,
        WPFAnonymous = 103,
        WPFMinimized = 104,
        WPFMaximized = 105,
        WPFCollapsed = 106,
        
        WPFRich = 131,
        WPFFull = 132,
        WPFWizard = 133
        
    }
    
//    public enum FormControls {
//        nothing = 0,
//        Button = 10,
//        CheckBox = 20,
//        ComboBox = 30,
//        Label = 40,
//        ListBox = 50,
//        ListView = 60,
//        RadioButton = 70,
//        TextBox = 80,
//        TreeView = 90
//    }

    public class ControlToForm
    {
        public ControlToForm()
        {
            
        }
        
//        public ControlToForm(
//           System.Windows.Automation.ControlType controlType,
//           string controlName,
//           string controlAutomationId,
//           TimeoutsAndDelays controlDelay)
//        {
//            this.ControlType = controlType;
//            this.ControlName = controlName;
//            this.ControlAutomationId = controlAutomationId;
//            this.ControlDelayEn = controlDelay;
//        }
        
        public System.Windows.Automation.ControlType ControlType { get; set; }
        public string ControlName { get; set; }
        public string ControlAutomationId { get; set; }
        //public TimeoutsAndDelays ControlDelayEn { get; set; }
        public int ControlDelayEn { get; set; }
        public string ControlTypeAsString { get; set; }
    }

}