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
    using System;
    using System.Windows.Automation;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
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
            // System.Nullable<System.Drawing.Color> color)
        {
			this.disposeSides();
			
        	this.createHighlighter(
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
        	this.createHighlighter(
        		height,
        		width,
        		X,
        		Y,
        		intHandle,
        		control,
        	    null);
        	
        	this.PaintLabel(highlighterNumber, highlighterData);
        }
        
//        ~Highlighter()
//        {
//            disposeSides();
//        }
        
        [STAThread]
        public void Dispose()
        {
        	this.disposeSides();
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
            // System.Nullable<System.Drawing.Color> color)
        {
            try {
                if (height == 0 || width == 0) return;
                int border = getBorder(control);
                NativeMethods.CursorPoint p = 
                    getPoint(
                        X,
                        Y,
                        intHandle); //;
                    
                this.paintLeftSide(control, border, p, height, width, color);
                this.paintTopSide(control, border, p, height, width, color);
                this.paintRightSide(control, border, p, height, width, color);
                this.paintBottomSide(control, border, p, height, width, color);

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
        		this.rightSide.Left - 20;
        	int top =
        		this.bottomSide.Top - 15;
        	int height =
        		this.bottomSide.Top - top;
        	int width =
        		this.rightSide.Left - left;

        	labelForm =
        		new LabelForm(
        			left,
        			top,
        			width,
        			height, 
        			highlighterNumber,
        			this.bottomSide.BackColor,
        		    highlighterData);
        }
        
//        [STAThread]
//        internal void CreateToolTip(string highlighterData)
//        {
//        	// painting a new form
//        	int left =
//        		this.rightSide.Left - 20;
//        	int top =
//        		this.bottomSide.Top - 15;
//        	int height =
//        		this.bottomSide.Top - top;
//        	int width =
//        		this.rightSide.Left - left;
//
//        	labelForm =
//        		new LabelForm(
//        			left,
//        			top,
//        			width,
//        			height, 
//        			highlighterNumber,
//        			this.bottomSide.BackColor);
//        }
        
        private  NativeMethods.CursorPoint getPoint(
            double X,
            double Y,
            int intHandle)
        {
            NativeMethods.CursorPoint p = new NativeMethods.CursorPoint();
            p.X = (int)X;
            p.Y = (int)Y;
            if (intHandle == 0) return p;
            try { // Windows Vista or higher only
                IntPtr handle = 
                    new IntPtr(intHandle);
                NativeMethods.PhysicalToLogicalPoint(handle, ref p);
            } 
            catch {
            }

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
            this.leftSide.Show();
            this.topSide.Show();
            this.rightSide.Show();
            this.bottomSide.Show();
            try {
                this.labelForm.Show();
            }
            catch {}
        }
        
        [STAThread]
        public void Hide()
        {
            this.leftSide.Hide();
            this.topSide.Hide();
            this.rightSide.Hide();
            this.bottomSide.Hide();
            try {
                this.labelForm.Hide();
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
                this.Dispose();
                return;
            }
            
            this.left = (int)left;
            this.top = (int)top;
            this.width = (int)width;
            this.height = (int)height;
            
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = this.BackColor;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)Preferences.BannerFontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(this.width, this.height);
            this.lblMessage.TabIndex = 0;
            // replace "&" with "&&"
            message = message.Replace("&", "&&");
            this.lblMessage.Text = message;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(this.width, this.height);
            this.Controls.Add(this.lblMessage);
            this.Name = "MainForm";
            this.Opacity = 0.7D;
            this.TopMost = true;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Left = this.left;
            this.Top = this.top;
            this.Width = this.width;
            this.Height = this.height;
            this.Location = new System.Drawing.Point(this.left, this.top);
            this.Text = "UIABanner";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.ResumeLayout(false);
            
            this.Show();
        }
        
        void MainFormLoad(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point((int)this.left, (int)this.top);
        }
        
        public new void Dispose()
        {
            this.Close();
            //GC.SuppressFinalize(this);
        }
        
        private Label lblMessage;
        private int left;
        private int top;
        private int width;
        private int height;
        
        public string Message {
            get { return this.lblMessage.Text; }
            set { this.lblMessage.Text = value; }
        }
        
        private string originalMessage = string.Empty;
        
        public void AppendMessage(string message)
        {
            if (string.Empty != originalMessage) {
                originalMessage = this.Message;
            }
            
            this.Message += message;
            
            Application.DoEvents();
        }
        
        public void RestoreOriginalMessage()
        {
            if (string.Empty != this.originalMessage) {
                this.Message = this.originalMessage;
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
            // System.Nullable<System.Drawing.Color> color)
        {
            this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Visible = false;
            this.Opacity = 0.5;
            
            if (null != color) {
                this.BackColor = (System.Drawing.Color)color;
                this.ForeColor = (System.Drawing.Color)color;
            } else {
                switch (control)
                {
                    case Highlighters.Parent:
                        this.BackColor = Preferences.HighlighterColorParent;
                        this.ForeColor = Preferences.HighlighterColorParent;
                        break;
                    case Highlighters.Element:
                        this.BackColor = Preferences.HighlighterColor;
                        this.ForeColor = Preferences.HighlighterColor;
                        break;
                    default:
                        this.BackColor = Color.FromKnownColor(ExecutionPlan.colorTable[(int)control]);
                        this.ForeColor = Color.FromKnownColor(ExecutionPlan.colorTable[(int)control]);
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
            
            this.AllowTransparency = true;
            this.ControlBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopLevel = true;
            this.UseWaitCursor = false;
            this.WindowState = FormWindowState.Normal;
            this.Left = (int)left;
            this.Top = (int)top;
            this.Width = 0;
            this.Height = 0;
            this.Show();
            this.Hide();
            this.Left = (int)left;
            this.Top = (int)top;
            this.Width = (int)width;
            this.Height = (int)height;
            this.Enabled = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.ShowInTaskbar = false;
            this.UseWaitCursor = false;
            this.Visible = true;
            this.Show();
        }
        
        public new void Dispose()
        {
            this.Close();
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
            int highlighterNumber,
            System.Drawing.Color foreColor,
            string tooltipText)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Visible = false;
            this.Opacity = 0.5;
            this.AllowTransparency = true;
            this.ControlBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopLevel = true;
            this.UseWaitCursor = false;
            this.WindowState = FormWindowState.Normal;
            this.Show();
            this.Hide();
            this.Left = (int)left;
            this.Top = (int)top;
            this.Width = (int)width;
            this.Height = (int)height;
            this.AutoSize = true;
            this.Enabled = false;
            Label labelNumber =
        		new Label();
            labelNumber.AutoSize = true;
            if (null == highlighterNumber || 0 >= highlighterNumber) {
                highlighterNumber = 1;
            }
        	labelNumber.Text = highlighterNumber.ToString();
        	labelNumber.BackColor = Color.FromKnownColor(KnownColor.DarkGray);
        	labelNumber.ForeColor = foreColor;
        	labelNumber.Dock = DockStyle.Fill;
        	labelNumber.MouseMove += 
        		new System.Windows.Forms.MouseEventHandler(this.labelNumberMouseMove);
        	this.Controls.Add(labelNumber);
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.UseWaitCursor = false;
            this.Visible = true;
            
            if (Preferences.ShowInfoToolTip) {
                // tooltip
                ToolTip tooltip = new ToolTip();
                tooltip.Active = true;
                tooltip.ShowAlways = true;
                tooltip.IsBalloon = true;
                tooltip.Show(tooltipText, this);
            }
            
            this.Show();
        }
    	
		void labelNumberMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
		    try {
			 Application.DoEvents();
		    }
		    catch {}
		}
        
        public new void Dispose()
        {
            this.Close();
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
