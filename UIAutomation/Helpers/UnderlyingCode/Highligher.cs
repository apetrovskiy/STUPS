/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08/02/2012
 * Time: 09:08 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
//namespace SePSX
{
    using System;
    using System.Windows.Automation;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Drawing;
    //using OpenQA.Selenium;

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
//        internal static KnownColor[] colorTable = {
//        	KnownColor.Red,
//        	KnownColor.Green,
//        	KnownColor.Blue,
//        	KnownColor.Yellow,
//        	KnownColor.Pink,
//        	KnownColor.SeaGreen,
//        	KnownColor.MediumVioletRed,
//        	KnownColor.Magenta,
//        	KnownColor.YellowGreen,
//        	KnownColor.DarkBlue
//        };
        
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
            Highlighters control)
        {
			this.disposeSides();
			
        	this.createHighlighter(
        		height,
        		width,
        		X,
        		Y,
        		intHandle,
        		control);
        }
        
        public Highlighter(
        	double height,
        	double width,
        	double X,
        	double Y,
        	int intHandle,
        	Highlighters control,
        	int highlighterNumber)
        {
        	this.createHighlighter(
        		height,
        		width,
        		X,
        		Y,
        		intHandle,
        		control);
        	
        	this.PaintLabel(highlighterNumber);
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
            Highlighters control)
        {
            try {

                if (height != 0 && width != 0) {
                    
                    int border = getBorder(control);
                    NativeMethods.CursorPoint p = 
                        getPoint(
                            X,
                            Y,
                            intHandle);;
                    
                    this.paintLeftSide(control, border, p, height, width);
                    this.paintTopSide(control, border, p, height, width);
                    this.paintRightSide(control, border, p, height, width);
                    this.paintBottomSide(control, border, p, height, width);
                }
            }
            catch { //(Exception eHighlighter) {
            }
        }
        
        [STAThread]
        internal void PaintLabel(int highlighterNumber)
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
        			this.bottomSide.BackColor);
        }
        
        private  NativeMethods.CursorPoint getPoint(
            double X,
            double Y,
            int intHandle)
        {
            NativeMethods.CursorPoint p = new NativeMethods.CursorPoint();
            p.X = (int)X;
            p.Y = (int)Y;
            if (intHandle != 0) {
                try { // Windows Vista or higher only
                    IntPtr handle = 
                        new IntPtr(intHandle);
                     NativeMethods.PhysicalToLogicalPoint(handle, ref p);
                } 
                catch {
            	}
            }
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
            //AutomationElement element, 
            Highlighters control,
            int border,
            NativeMethods.CursorPoint p,
            double height,
            double width)
        {
            leftSide = new Side(p.X - (border / 2),
                                p.Y,
                                border,
                                height,
                                control);
        }
        
        [STAThread]
        private void paintTopSide(
            Highlighters control,
            int border,
            NativeMethods.CursorPoint p,
            double height,
            double width)
        {
            topSide = new Side(p.X,
                               p.Y - (border / 2),
                               width,
                               border,
                               control);
        }
        
        [STAThread]
        private void paintRightSide(
            Highlighters control,
            int border,
            NativeMethods.CursorPoint p,
            double height,
            double width)
        {
            rightSide = new Side(p.X +
                                 width -
                                     (border / 2),
                                 p.Y,
                                 border,
                                 height,
                                 control);
        }
        
        [STAThread]
        private void paintBottomSide(
            Highlighters control,
            int border,
            NativeMethods.CursorPoint p,
            double height,
            double width)
        {
            bottomSide = new Side(p.X,
                                  p.Y +
                                  height -
                                      (border / 2),
                                  width,
                                  border,
                                  control);
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
    
    internal class Side : Form, IDisposable
    {
        
        public Side(
            double left, 
            double top, 
            double width, 
            double height, 
            Highlighters control)
        {
            //this.Left = 0;
            //this.Top = 0;
            //this.Width = 1;
            //this.Height = 1;
            this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Visible = false;
            this.Opacity = 0.5;
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
//            else if (control == Highlighters.FirstChild) {
//                this.BackColor = Preferences.HighlighterColorFirstChild;
//                this.ForeColor = Preferences.HighlighterColorFirstChild;
//            }
            
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
            System.Drawing.Color foreColor)
        {
            //this.Left = 0;
            //this.Top = 0;
            //this.Width = 1;
            //this.Height = 1;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            //this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Visible = false;

            this.Opacity = 0.5;

            //this.Opacity = 0.2;
            //this.BackColor = System.Drawing.Color.Transparent;
            
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
        	//labelNumber.BackColor = System.Drawing.Color.Transparent;
        	labelNumber.BackColor = Color.FromKnownColor(KnownColor.DarkGray);
        	labelNumber.ForeColor = foreColor;
        	labelNumber.Dock = DockStyle.Fill;
        	labelNumber.MouseMove += 
        		new System.Windows.Forms.MouseEventHandler(this.labelNumberMouseMove);
        	this.Controls.Add(labelNumber);
            //this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.UseWaitCursor = false;
            this.Visible = true;
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
