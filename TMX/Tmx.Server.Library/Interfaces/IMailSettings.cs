/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/5/2014
 * Time: 8:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Library.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Description of IMailSettings.
    /// </summary>
    public interface IMailSettings
    {
        string From { get; set; }
        string To { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        bool IsBodyHtml { get; set; }
        List<string> SmtpServers { get; set; }
    }
}
