/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08/02/2012
 * Time: 09:08 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using System.Windows.Forms;
    using System.Drawing;

    /// <summary>
    /// Description of Highlighter.
    /// </summary>
    public class Highlighter : IDisposable
    {
        
        internal Side leftSide = null;
        internal Side topSide = null;
        internal Side rightSide = null;
        internal Side bottomSide = null;
        internal LabelForm labelForm = null;
        
        private void disposeSides()
        {
            try {
                leftSide.Dispose();
                rightSide.Dispose();
                topSide.Dispose();
                bottomSide.Dispose();
            }
            catch { //(Exception eSides) {
            }
            
            try {
                labelForm.Dispose();
            }
            catch { //(Exception eLabelForm) {
            }
        }
        
        public Highlighter(
            double height,
            double width,
            double X,
            double Y,
            int intHandle,
            Highlighters control,
            Color? color)
        {
            disposeSides();
            
            createHighlighter(
                height,
                width,
                X,
                Y,
                intHandle,
                control,
                color);
        }
        
        public Highlighter(
            double height,
            double width,
            double X,
            double Y,
            int intHandle,
            Highlighters control,
            int highlighterNumber,
            string highlighterData)
        {
            createHighlighter(
                height,
                width,
                X,
                Y,
                intHandle,
                control,
                null);
            
            PaintLabel(highlighterNumber, highlighterData);
        }
        
//        ~Highlighter()
//        {
//            disposeSides();
//        }
        
        [STAThread]
        public void Dispose()
        {
            disposeSides();
            //GC.SuppressFinalize(this);
        }
        
        [STAThread]
        private void createHighlighter(
            double height,
            double width,
            double X,
            double Y,
            int intHandle,
            Highlighters control,
            Color? color)
        {
            try {
                if (height == 0 || width == 0) return;
                int border = getBorder(control);
                NativeMethods.CursorPoint p = 
                    getPoint(
                        X,
                        Y,
                        intHandle); //;
                    
                paintLeftSide(control, border, p, height, width, color);
                paintTopSide(control, border, p, height, width, color);
                paintRightSide(control, border, p, height, width, color);
                paintBottomSide(control, border, p, height, width, color);

                /*
                if (height != 0 && width != 0) {
                    
                    int border = getBorder(control);
                    NativeMethods.CursorPoint p = 
                        getPoint(
                            X,
                            Y,
                            intHandle);;
                    
                    this.paintLeftSide(control, border, p, height, width, color);
                    this.paintTopSide(control, border, p, height, width, color);
                    this.paintRightSide(control, border, p, height, width, color);
                    this.paintBottomSide(control, border, p, height, width, color);
                }
                */
            }
            catch { //(Exception eHighlighter) {
            }
        }
        
        [STAThread]
        internal void PaintLabel(int highlighterNumber, string highlighterData)
        {
            // painting a new form
            int left =
                rightSide.Left - 20;
            int top =
                bottomSide.Top - 15;
            int height =
                bottomSide.Top - top;
            int width =
                rightSide.Left - left;

            labelForm =
                new LabelForm(
                    left,
                    top,
                    width,
                    height, 
                    highlighterNumber,
                    bottomSide.BackColor,
                    highlighterData);
        }
        
//        [STAThread]
//        internal void CreateToolTip(string highlighterData)
//        {
//            // painting a new form
//            int left =
//                this.rightSide.Left - 20;
//            int top =
//                this.bottomSide.Top - 15;
//            int height =
//                this.bottomSide.Top - top;
//            int width =
//                this.rightSide.Left - left;
//
//            labelForm =
//                new LabelForm(
//                    left,
//                    top,
//                    width,
//                    height, 
//                    highlighterNumber,
//                    this.bottomSide.BackColor);
//        }
        
        private  NativeMethods.CursorPoint getPoint(
            double X,
            double Y,
            int intHandle)
        {
            var p = new NativeMethods.CursorPoint {X = (int) X, Y = (int) Y};
            if (intHandle == 0) return p;
            try { // Windows Vista or higher only
                var handle = 
                    new IntPtr(intHandle);
                NativeMethods.PhysicalToLogicalPoint(handle, ref p);
            } 
            catch {
            }
            
            /*
            NativeMethods.CursorPoint p = new NativeMethods.CursorPoint {X = (int) X, Y = (int) Y};
            if (intHandle == 0) return p;
            try { // Windows Vista or higher only
                IntPtr handle = 
                    new IntPtr(intHandle);
                NativeMethods.PhysicalToLogicalPoint(handle, ref p);
            } 
            catch {
            }
            */

            /*
            if (intHandle != 0) {
                try { // Windows Vista or higher only
                    IntPtr handle = 
                        new IntPtr(intHandle);
                     NativeMethods.PhysicalToLogicalPoint(handle, ref p);
                } 
                catch {
                }
            }
            */
            return p;
        }

        private static int getBorder(Highlighters control)
        {
            int border = Preferences.HighlighterBorder;
            if (control == Highlighters.Parent) {
                border = Preferences.HighlighterBorderParent;
            } 
//            else if (control == Highlighters.FirstChild) {
//                border = Preferences.HighlighterBorderFirstChild;
//            }
            return border;
        }
        
        [STAThread]
        private void paintLeftSide(
            Highlighters control,
            int border,
            NativeMethods.CursorPoint p,
            double height,
            double width,
            Color? color)
            // System.Nullable<System.Drawing.Color> color)
        {
            leftSide = new Side(p.X - (border / 2),
                                p.Y,
                                border,
                                height,
                                control,
                                color);
        }
        
        [STAThread]
        private void paintTopSide(
            Highlighters control,
            int border,
            NativeMethods.CursorPoint p,
            double height,
            double width,
            Color? color)
            // System.Nullable<System.Drawing.Color> color)
        {
            topSide = new Side(p.X,
                               p.Y - (border / 2),
                               width,
                               border,
                               control,
                               color);
        }
        
        [STAThread]
        private void paintRightSide(
            Highlighters control,
            int border,
            NativeMethods.CursorPoint p,
            double height,
            double width,
            Color? color)
            // System.Nullable<System.Drawing.Color> color)
        {
            rightSide = new Side(p.X +
                                 width -
                                     (border / 2),
                                 p.Y,
                                 border,
                                 height,
                                 control,
                                 color);
        }
        
        [STAThread]
        private void paintBottomSide(
            Highlighters control,
            int border,
            NativeMethods.CursorPoint p,
            double height,
            double width,
            Color? color)
            // System.Nullable<System.Drawing.Color> color)
        {
            bottomSide = new Side(p.X,
                                  p.Y +
                                  height -
                                      (border / 2),
                                  width,
                                  border,
                                  control,
                                  color);
        }
        
        [STAThread]
        public void Show()
        {
            leftSide.Show();
            topSide.Show();
            rightSide.Show();
            bottomSide.Show();
            try {
                labelForm.Show();
            }
            catch {}
        }
        
        [STAThread]
        public void Hide()
        {
            leftSide.Hide();
            topSide.Hide();
            rightSide.Hide();
            bottomSide.Hide();
            try {
                labelForm.Hide();
            }
            catch {}
        }
    }
    
    internal class Banner : Form, IDisposable
    {
        public Banner(
            double left, 
            double top, 
            double width, 
            double height,
            string message)
        {
            
            if (string.Empty == message || 0 == message.Length) {
                Dispose();
                return;
            }
            
            this.left = (int)left;
            this.top = (int)top;
            this.width = (int)width;
            this.height = (int)height;
            
            lblMessage = new Label();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.BackColor = BackColor;
            lblMessage.Font = new Font("Microsoft Sans Serif", (float)Preferences.BannerFontSize, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            lblMessage.Location = new Point(0, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(this.width, this.height);
            lblMessage.TabIndex = 0;
            // replace "&" with "&&"
            message = message.Replace("&", "&&");
            lblMessage.Text = message;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(this.width, this.height);
            Controls.Add(lblMessage);
            Name = "MainForm";
            Opacity = 0.7D;
            TopMost = true;
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.None;
            Left = this.left;
            Top = this.top;
            Width = this.width;
            Height = this.height;
            Location = new Point(this.left, this.top);
            Text = "UiaBanner";
            Load += new EventHandler(MainFormLoad);
            ResumeLayout(false);
            
            Show();
        }
        
        void MainFormLoad(object sender, EventArgs e)
        {
            Location = new Point((int)left, (int)top);
        }
        
        public new void Dispose()
        {
            Close();
            //GC.SuppressFinalize(this);
        }
        
        private readonly Label lblMessage;
        private readonly int left;
        private readonly int top;
        private int width;
        private int height;
        
        public string Message {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }
        
        private string originalMessage = string.Empty;
        
        public void AppendMessage(string message)
        {
            if (string.Empty != originalMessage) {
                originalMessage = Message;
            }
            
            Message += message;
            
            Application.DoEvents();
        }
        
        public void RestoreOriginalMessage()
        {
            if (string.Empty != originalMessage) {
                Message = originalMessage;
            }
            
            Application.DoEvents();
        }
    }
    
    internal class Side : Form, IDisposable
    {
        
        public Side(
            double left, 
            double top, 
            double width, 
            double height, 
            Highlighters control,
            Color? color)
        {
            TopMost = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Visible = false;
            Opacity = 0.5;
            
            if (null != color) {
                BackColor = (Color)color;
                ForeColor = (Color)color;
            } else {
                switch (control)
                {
                    case Highlighters.Parent:
                        BackColor = Preferences.HighlighterColorParent;
                        ForeColor = Preferences.HighlighterColorParent;
                        break;
                    case Highlighters.Element:
                        BackColor = Preferences.HighlighterColor;
                        ForeColor = Preferences.HighlighterColor;
                        break;
                    default:
                        BackColor = Color.FromKnownColor(ExecutionPlan.colorTable[(int)control]);
                        ForeColor = Color.FromKnownColor(ExecutionPlan.colorTable[(int)control]);
                        break;
                }
    //            else if (control == Highlighters.FirstChild) {
    //                this.BackColor = Preferences.HighlighterColorFirstChild;
    //                this.ForeColor = Preferences.HighlighterColorFirstChild;
    //            }

                /*
                if (control == Highlighters.Parent) {
                    this.BackColor = Preferences.HighlighterColorParent;
                    this.ForeColor = Preferences.HighlighterColorParent;
                } else if (control == Highlighters.Element) {
                    this.BackColor = Preferences.HighlighterColor;
                    this.ForeColor = Preferences.HighlighterColor;
                } else {
                    this.BackColor = Color.FromKnownColor(ExecutionPlan.colorTable[(int)control]);
                    this.ForeColor = Color.FromKnownColor(ExecutionPlan.colorTable[(int)control]);
                }
                */
            }
            
            AllowTransparency = true;
            ControlBox = false;
            ShowIcon = false;
            ShowInTaskbar = false;
            TopLevel = true;
            UseWaitCursor = false;
            WindowState = FormWindowState.Normal;
            Left = (int)left;
            Top = (int)top;
            Width = 0;
            Height = 0;
            Show();
            Hide();
            Left = (int)left;
            Top = (int)top;
            Width = (int)width;
            Height = (int)height;
            Enabled = false;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ShowInTaskbar = false;
            UseWaitCursor = false;
            Visible = true;
            Show();
        }
        
        public new void Dispose()
        {
            Close();
            //GC.SuppressFinalize(this);
        }
    }
    
    internal class LabelForm : Form, IDisposable
    {
        
        public LabelForm(
            double left, 
            double top, 
            double width, 
            double height,
            // 20140713            
            // int highlighterNumber,
            int? highlighterNumber,
            Color foreColor,
            string tooltipText)
        {
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            Visible = false;
            Opacity = 0.5;
            AllowTransparency = true;
            ControlBox = false;
            ShowIcon = false;
            ShowInTaskbar = false;
            TopLevel = true;
            UseWaitCursor = false;
            WindowState = FormWindowState.Normal;
            Show();
            Hide();
            Left = (int)left;
            Top = (int)top;
            Width = (int)width;
            Height = (int)height;
            AutoSize = true;
            Enabled = false;
            var labelNumber =
                new Label {AutoSize = true};
            /*
            Label labelNumber =
                new Label {AutoSize = true};
            */
            if (null == highlighterNumber || 0 == highlighterNumber) {
                highlighterNumber = 1;
            }
            labelNumber.Text = highlighterNumber.ToString();
            labelNumber.BackColor = Color.FromKnownColor(KnownColor.DarkGray);
            labelNumber.ForeColor = foreColor;
            labelNumber.Dock = DockStyle.Fill;
            labelNumber.MouseMove += 
                new MouseEventHandler(labelNumberMouseMove);
            Controls.Add(labelNumber);
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            UseWaitCursor = false;
            Visible = true;
            
            if (Preferences.ShowInfoToolTip) {
                // tooltip
                var tooltip = new ToolTip {Active = true, ShowAlways = true, IsBalloon = true};
                tooltip.Show(tooltipText, this);
            }
            
            Show();
        }
        
        void labelNumberMouseMove(object sender, MouseEventArgs e)
        {
            try {
             Application.DoEvents();
            }
            catch {}
        }
        
        public new void Dispose()
        {
            Close();
            //GC.SuppressFinalize(this);
        }
    }
    
    public enum Highlighters
    {
        ExecPlan01 = 0,
        ExecPlan02 = 1,
        ExecPlan03 = 2,
        ExecPlan04 = 3,
        ExecPlan05 = 4,
        ExecPlan06 = 5,
        ExecPlan07 = 6,
        ExecPlan08 = 7,
        ExecPlan09 = 8,
        ExecPlan10 = 9,
        Element = 101,
        Parent = 102 //,
//        FirstChild
    }
}
