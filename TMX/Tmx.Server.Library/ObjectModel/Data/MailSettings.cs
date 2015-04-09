/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/5/2014
 * Time: 10:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Library.ObjectModel.Data
{
    using System.Collections.Generic;
    using Library.Interfaces;

    /// <summary>
    /// Description of MailSettings.
    /// </summary>
    public class MailSettings : IMailSettings
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
        public List<string> SmtpServers { get; set; }
    }
}
