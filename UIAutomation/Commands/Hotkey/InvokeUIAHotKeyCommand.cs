/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/22/2012
 * Time: 9:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUIAHotKeyCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAHotKey")]
    public class InvokeUIAHotKeyCommand : HasScriptBlockCmdletBase
    {
        #region Constructor
        public InvokeUIAHotKeyCommand()
        {
            this.Key = string.Empty;
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter(Mandatory = false)]
        public string Key { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter Win { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter Enter { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter Ctrl { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter Shift { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter Alt { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Esc { get; set; }
        
        
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Del { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Win { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Win { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Win { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Win { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Win { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Win { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Win { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Win { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Win { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Win { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Win { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Win { get; set; }
//        [Parameter(Mandatory = false)]
//        public SwitchParameter Win { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            //NativeMethods.keybd_event
            
            byte keys = 0x00;
            byte keys2 = 0x00;
            byte keys3 = 0x00;
            
            if (this.Win) { 
                keys = 0xE0;
                keys2 = 0x5B;
            }
            
            if (this.Ctrl) { keys = 0x11; }
            if (this.Shift) { keys = 0x10; }
            if (this.Alt) { keys = 0x12; }
            if (this.Enter) { keys = 0x0D; }
            //if (this.Esc) { keys = 0x1B; }
            
            //if (this.Ctrl) {}
            //if (this.Ctrl) {}
            //if (this.Ctrl) {}
            
            if (this.Key.Length > 0) {
                switch (this.Key) {
                    case "a":
                    case "A":
                        keys3 = NativeMethods.VK_0x41;
                        break;
                    case "b":
                    case "B":
                        keys3 = NativeMethods.VK_0x42;
                        break;
                    case "c":
                    case "C":
                        keys3 = NativeMethods.VK_0x43;
                        break;
                    case "d":
                    case "D":
                        keys3 = NativeMethods.VK_0x44;
                        break;
                    case "e":
                    case "E":
                        keys3 = NativeMethods.VK_0x45;
                        break;
                    case "f":
                    case "F":
                        keys3 = NativeMethods.VK_0x46;
                        break;
                    case "g":
                    case "G":
                        keys3 = NativeMethods.VK_0x47;
                        break;
                    case "h":
                    case "H":
                        keys3 = NativeMethods.VK_0x48;
                        break;
                    case "i":
                    case "I":
                        keys3 = NativeMethods.VK_0x49;
                        break;
                    case "j":
                    case "J":
                        keys3 = NativeMethods.VK_0x4A;
                        break;
                    case "k":
                    case "K":
                        keys3 = NativeMethods.VK_0x4B;
                        break;
                    case "l":
                    case "L":
                        keys3 = NativeMethods.VK_0x4C;
                        break;
                    case "m":
                    case "M":
                        keys3 = NativeMethods.VK_0x4D;
                        break;
                    case "n":
                    case "N":
                        keys3 = NativeMethods.VK_0x4E;
                        break;
                    case "o":
                    case "O":
                        keys3 = NativeMethods.VK_0x4F;
                        break;
                    case "p":
                    case "P":
                        keys3 = NativeMethods.VK_0x50;
                        break;
                    case "q":
                    case "Q":
                        keys3 = NativeMethods.VK_0x51;
                        break;
                    case "r":
                    case "R":
                        keys3 = NativeMethods.VK_0x52;
                        break;
                    case "s":
                    case "S":
                        keys3 = NativeMethods.VK_0x53;
                        break;
                    case "t":
                    case "T":
                        keys3 = NativeMethods.VK_0x54;
                        break;
                    case "u":
                    case "U":
                        keys3 = NativeMethods.VK_0x55;
                        break;
                    case "v":
                    case "V":
                        keys3 = NativeMethods.VK_0x56;
                        break;
                    case "w":
                    case "W":
                        keys3 = NativeMethods.VK_0x57;
                        break;
                    case "x":
                    case "X":
                        keys3 = NativeMethods.VK_0x58;
                        break;
                    case "y":
                    case "Y":
                        keys3 = NativeMethods.VK_0x59;
                        break;
                    case "z":
                    case "Z":
                        keys3 = NativeMethods.VK_0x5A;
                        break;
                    case "0":
                        keys3 = NativeMethods.VK_0x30;
                        break;
                    case "1":
                        keys3 = NativeMethods.VK_0x31;
                        break;
                    case "2":
                        keys3 = NativeMethods.VK_0x32;
                        break;
                    case "3":
                        keys3 = NativeMethods.VK_0x33;
                        break;
                    case "4":
                        keys3 = NativeMethods.VK_0x34;
                        break;
                    case "5":
                        keys3 = NativeMethods.VK_0x35;
                        break;
                    case "6":
                        keys3 = NativeMethods.VK_0x36;
                        break;
                    case "7":
                        keys3 = NativeMethods.VK_0x37;
                        break;
                    case "8":
                        keys3 = NativeMethods.VK_0x38;
                        break;
                    case "9":
                        keys3 = NativeMethods.VK_0x39;
                        break;
//                    case "a":
//                    case "A":
//                        keys3 = NativeMethods.VK_0x41;
//                        break;
//                    case "a":
//                    case "A":
//                        keys3 = NativeMethods.VK_0x41;
//                        break;
//                    case "a":
//                    case "A":
//                        keys3 = NativeMethods.VK_0x41;
//                        break;
//                    case "a":
//                    case "A":
//                        keys3 = NativeMethods.VK_0x41;
//                        break;
//                        
//                    case "a":
//                    case "A":
//                        keys3 = NativeMethods.VK_0x41;
//                        break;
//                    case "a":
//                    case "A":
//                        keys3 = NativeMethods.VK_0x41;
//                        break;
//                    case "a":
//                    case "A":
//                        keys3 = NativeMethods.VK_0x41;
//                        break;
//                    case "a":
//                    case "A":
//                        keys3 = NativeMethods.VK_0x41;
//                        break;
//                    case "a":
//                    case "A":
//                        keys3 = NativeMethods.VK_0x41;
//                        break;
//                    case "a":
//                    case "A":
//                        keys3 = NativeMethods.VK_0x41;
//                        break;
//                    case "a":
//                    case "A":
//                        keys3 = NativeMethods.VK_0x41;
//                        break;
//                    case "a":
//                    case "A":
//                        keys3 = NativeMethods.VK_0x41;
//                        break;
//                    case "a":
//                    case "A":
//                        keys3 = NativeMethods.VK_0x41;
//                        break;
//                    case "a":
//                    case "A":
//                        keys3 = NativeMethods.VK_0x41;
//                        break;
                        
                }
            }
            
            // Simulate a key press
            NativeMethods.keybd_event( keys,
                        0x45,
                        NativeMethods.KEYEVENTF_EXTENDEDKEY | 0,
                        0 );
            
            if (keys2 != 0x00) {
                NativeMethods.keybd_event( keys2,
                                          0x45,
                                          NativeMethods.KEYEVENTF_EXTENDEDKEY | 0,
                                          0 );
            }
                
            if (keys3 != 0x00) {
                NativeMethods.keybd_event( keys3,
                                          0x45,
                                          NativeMethods.KEYEVENTF_EXTENDEDKEY | 0,
                                          0 );
                
                NativeMethods.keybd_event( keys3,
                                          0x45,
                                          NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP,
                                          0 );
            }
                
            if (keys2 != 0x00) {
                NativeMethods.keybd_event( keys2,
                                          0x45,
                                          NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP,
                                          0 );
            }
            
            // Simulate a key release
            NativeMethods.keybd_event( keys,
                        0x45,
                        NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP,
                        0);
            
            
        }
    }
}
