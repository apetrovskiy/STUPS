/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/5/2014
 * Time: 8:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */


namespace Tmx.Server.Helpers
{
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Mail;
    using System.Net.Mime;
    using Tmx.Server.Interfaces;
    
    /// <summary>
    /// Description of Mailer.
    /// </summary>
    public class Mailer
    {
        public Mailer()
        {
        }
        
        /*
        System.Net.Mail.MailAddress NewMail = new MailAddress("netwrix.r" + (char)0x26 + "d.spb.qc.at.msi@netwrix.com", "netwrix.r" + (char)0x26 + "d.spb.qc.at.msi", System.Text.Encoding.UTF8); 
        */
        
        public virtual void SendMessage(IMailSettings settings)
        {
            var message = new MailMessage(
                settings.From,
                settings.To,
                settings.Subject,
                settings.Body) {
                IsBodyHtml = settings.IsBodyHtml
            };
            
            foreach (var smtpServer in settings.SmtpServers) {
                var client = new SmtpClient(smtpServer);
                client.UseDefaultCredentials = true;
                try {
                    client.Send(message);
                }
                catch (Exception ex) {
                    // TODO: AOP
                    Trace.TraceError("SendMessage(IMailSettings settings)");
                    // ??
                    Trace.TraceError(ex.Message);
                }
            }
        }
        
        
        
        public void CreateTestMessage2(string server)
        {
            string to = "jane@contoso.com";
            string from = "ben@contoso.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Using the new SMTP client.";
            message.Body = @"Using this new feature, you can send an e-mail message from an application very easily.";
            SmtpClient client = new SmtpClient(server);
            // Credentials are necessary if the server requires the client  
            // to authenticate before it will send e-mail on the client's behalf.
            client.UseDefaultCredentials = true;

            try {
                client.Send(message);
            }
            catch (Exception ex) {
                // TODO: AOP
                Trace.TraceError("CreateTestMessage2(string server)");
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}", ex);
                Trace.TraceError(ex.Message);
            }
        }
        
        public static void CreateMessageWithAttachment(string server)
        {
            // Specify the file to be attached and sent. 
            // This example assumes that a file named Data.xls exists in the 
            // current working directory.
            string file = "data.xls";
            // Create a message and set up the recipients.
            MailMessage message = new MailMessage(
                                      "jane@contoso.com",
                                      "ben@contoso.com",
                                      "Quarterly data report.",
                                      "See the attached spreadsheet.");
            
            // Create  the file attachment for this e-mail message.
            Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
            // Add time stamp information for the file.
            ContentDisposition disposition = data.ContentDisposition;
            disposition.CreationDate = System.IO.File.GetCreationTime(file);
            disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
            disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
            // Add the file attachment to this e-mail message.
            message.Attachments.Add(data);
            
            //Send the message.
            SmtpClient client = new SmtpClient(server);
            // Add credentials if the SMTP server requires them.
            client.Credentials = CredentialCache.DefaultNetworkCredentials;

            try {
                client.Send(message);
            }
            catch (Exception ex) {
                // TODO: AOP
                Trace.TraceError("CreateMessageWithAttachment(string server)");
                Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}", ex);
                Trace.TraceError(ex.Message);
            }
            // Display the values in the ContentDisposition for the attachment.
            ContentDisposition cd = data.ContentDisposition;
            Console.WriteLine("Content disposition");
            Console.WriteLine(cd.ToString());
            Console.WriteLine("File {0}", cd.FileName);
            Console.WriteLine("Size {0}", cd.Size);
            Console.WriteLine("Creation {0}", cd.CreationDate);
            Console.WriteLine("Modification {0}", cd.ModificationDate);
            Console.WriteLine("Read {0}", cd.ReadDate);
            Console.WriteLine("Inline {0}", cd.Inline);
            Console.WriteLine("Parameters: {0}", cd.Parameters.Count);
            foreach (DictionaryEntry d in cd.Parameters)
                Console.WriteLine("{0} = {1}", d.Key, d.Value);
            data.Dispose();
        }
    }
}
