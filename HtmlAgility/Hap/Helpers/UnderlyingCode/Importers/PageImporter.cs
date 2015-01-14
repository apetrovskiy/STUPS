/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/12/2014
 * Time: 7:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Hap
{
    using System;
//	using System.Net;
	using System.Text;
    using HtmlAgilityPack;
    
    /// <summary>
    /// Description of PageImporter.
    /// </summary>
    public class PageImporter
    {
        PageImporterData _data;
        
        public PageImporter(PageImporterData data)
        {
            _data = data;
        }
        
        public virtual HtmlNode GetFromDataProvided()
        {
            return !string.IsNullOrEmpty(_data.StringInput) ? GetFromString(_data.StringInput) : !string.IsNullOrEmpty(_data.Path) ? GetFromFile(_data.Path) : !string.IsNullOrEmpty(_data.Url) ? GetFromUrl(_data.Url) : null;
        }
        
        internal virtual HtmlNode GetFromUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return null;
            // TODO: validate!
            
            var htmlDoc = new HtmlDocument();
            var web = new HtmlWeb {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8
            };
            
            htmlDoc = web.Load(url);
            return htmlDoc.DocumentNode;
        }
        
        internal virtual HtmlNode GetFromFile(string path)
        {
            if (!System.IO.File.Exists(path)) return null;
            
            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(path);
            return htmlDoc.DocumentNode;
        }
        
        internal virtual HtmlNode GetFromString(string stringInput)
        {
            if (string.IsNullOrEmpty(stringInput)) return null;
            
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(stringInput);
            return htmlDoc.DocumentNode;
        }
    }
}
