/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/7/2012
 * Time: 8:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using PSTestLib;
    
    /// <summary>
    /// Description of RecordedCodeSequence.
    /// </summary>
    public class RecordedCodeSequence : IRecordedCodeSequence
    {
        public RecordedCodeSequence()
        {
            this.Items =
                new System.Collections.Generic.List<IRecordedItem>();
            this.Header =
                new System.Collections.Generic.List<string>();
            this.Data =
                new System.Collections.Generic.List<string>();
            this.Footer =
                new System.Collections.Generic.List<string>();
            this.Code =
                new System.Collections.Generic.List<string>();
        }
        
        public System.Collections.Generic.List<IRecordedItem> Items { get; set; }
        public System.Collections.Generic.List<string> Header { get; set; }
        public System.Collections.Generic.List<string> Data { get; set; }
        public System.Collections.Generic.List<string> Footer { get; set; }
        public System.Collections.Generic.List<string> Code { get; set; }
        
        public bool ReadyToProduceCode { get; set; }
        public bool CodeProduced { get; set; }
        
        public bool ContainsDataItem()
        {
            bool result = false;
            
            foreach (var element in this.Items) {
                if (null != (element as RecordedData)) {
                    result = true;
                    break;
                }
            }
            
            return result;
        }
        
        private string convertListToString(System.Collections.Generic.List<string> list)
        {
            string result = string.Empty;
            
            foreach (string listItem in list) {
                result += listItem;
            }
            
            return result;
        }
        
        public string GenerateCode(CodeAmount codeAmount)
        {
            string result = string.Empty;
            
            if (CodeAmount.HeaderDataFooterCode == codeAmount) {
                result += this.convertListToString(this.Header);
            }
            if (CodeAmount.DataCode == codeAmount || CodeAmount.HeaderDataFooterCode == codeAmount) {
                result += this.convertListToString(this.Data);
            }
            if (CodeAmount.HeaderDataFooterCode == codeAmount) {
                result += this.convertListToString(this.Footer);
            }
            result += this.convertListToString(this.Code);
            
            return result;
        }
    }
}
