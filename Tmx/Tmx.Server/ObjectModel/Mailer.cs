/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/5/2014
 * Time: 8:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.ObjectModel
{
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Net.Mime;
    using Interfaces;

    /// <summary>
    /// Description of Mailer.
    /// </summary>
    public class Mailer
    {
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
                var client = new SmtpClient(smtpServer) {UseDefaultCredentials = true};
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
            const string to = "jane@contoso.com";
            const string @from = "ben@contoso.com";
            var message = new MailMessage(from, to)
            {
                Subject = "Using the new SMTP client.",
                Body = @"Using this new feature, you can send an e-mail message from an application very easily."
            };
            var client = new SmtpClient(server) {UseDefaultCredentials = true};
            // Credentials are necessary if the server requires the client  
            // to authenticate before it will send e-mail on the client's behalf.

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

        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        public static void CreateMessageWithAttachment(string server)
        {
            // Specify the file to be attached and sent. 
            // This example assumes that a file named Data.xls exists in the 
            // current working directory.
            const string file = "data.xls";
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
            disposition.CreationDate = File.GetCreationTime(file);
            disposition.ModificationDate = File.GetLastWriteTime(file);
            disposition.ReadDate = File.GetLastAccessTime(file);
            // Add the file attachment to this e-mail message.
            message.Attachments.Add(data);
            
            //Send the message.
            var client = new SmtpClient(server) {Credentials = CredentialCache.DefaultNetworkCredentials};
            // Add credentials if the SMTP server requires them.

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
