/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/7/2012
 * Time: 8:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;
using System.Linq;

namespace SePSX
{
    using PSTestLib;
    
    /// <summary>
    /// Description of RecordedCodeSequence.
    /// </summary>
    public class RecordedCodeSequence : IRecordedCodeSequence
    {
        public RecordedCodeSequence()
        {
            Items =
                new List<IRecordedItem>();
            Header =
                new List<string>();
            Data =
                new List<string>();
            Footer =
                new List<string>();
            Code =
                new List<string>();
        }
        
        public List<IRecordedItem> Items { get; set; }
        public List<string> Header { get; set; }
        public List<string> Data { get; set; }
        public List<string> Footer { get; set; }
        public List<string> Code { get; set; }
        
        public bool ReadyToProduceCode { get; set; }
        public bool CodeProduced { get; set; }
        
        public bool ContainsDataItem()
        {
            var result = false;
            
            foreach (var element in Items) {
                if (null != (element as RecordedData)) {
                    result = true;
                    break;
                }
            }
            
            return result;
        }
        
        private string ConvertListToString(IEnumerable<string> list)
        {
            return list.Aggregate(string.Empty, (current, listItem) => current + listItem);
            /*
            string result = string.Empty;

            foreach (string listItem in list)
            {
                result += listItem;
            }

            return result;
            */
        }

        public string GenerateCode(CodeAmount codeAmount)
        {
            var result = string.Empty;
            
            if (CodeAmount.HeaderDataFooterCode == codeAmount) {
                result += ConvertListToString(Header);
            }
            if (CodeAmount.DataCode == codeAmount || CodeAmount.HeaderDataFooterCode == codeAmount) {
                result += ConvertListToString(Data);
            }
            if (CodeAmount.HeaderDataFooterCode == codeAmount) {
                result += ConvertListToString(Footer);
            }
            result += ConvertListToString(Code);
            
            return result;
        }
    }
}
