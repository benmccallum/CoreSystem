using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace CoreSystem.Helpers
{
    /// <summary>
    /// Helper class for all email related tasks.
    /// </summary>
    public class MailHelper
    {
        /// <summary>
        /// Sends Basic Email
        /// </summary>
        public static void SendMail(string pstrFrom, string pstrTo, string pstrSubject, string pstrBody, string smtpHost, string pstrFromFriendlyName = "")
        {            
            using (SmtpClient scClient = new SmtpClient(smtpHost))
            {
                MailAddress maFrom = null;
                if (!string.IsNullOrEmpty(pstrFromFriendlyName))
                {
                    maFrom = new MailAddress(pstrFrom, pstrFromFriendlyName);
                }
                else
                {
                    maFrom = new MailAddress(pstrFrom);
                }
                MailAddress maTo = new MailAddress(pstrTo);

                using (var mmMessage = new MailMessage(maFrom, maTo))
                {
                    mmMessage.Subject = pstrSubject;
                    mmMessage.Body = pstrBody;
                    mmMessage.IsBodyHtml = true;
                    scClient.Send(mmMessage);
                }
            }
        }

        /// <summary>
        /// Sends an email with the given properties where the caller specifies a filepath to a HTML template to use.
        /// </summary>
        /// <param name="templateFields">Dictionary of field names and values to replace in template file.</param>
        /// <remarks>Can throw exceptions.</remarks>
        public static void SendUsingTemplate(
            string smtpHost,
            string fromAddress, string fromDisplayName,
            string toAddressesDelimited,
            string subject,
            string htmlTemplateFilePath,
            Dictionary<string, string> templateFields = null,
            Dictionary<string, Stream> attachments = null)
        {
            // Get the HTML temlate file contents
            string fileText = "";
            try
            {
                fileText = File.ReadAllText(htmlTemplateFilePath);
            }
            catch (Exception ex)
            {
                //Log.Error("[MailHelper] was unable to read text from file at path: " + htmlTemplateFilePath + ".", ex, typeof(MailHelper));
                throw;
            }

            // Replace any wildcard template fields with values provided
            var mailBody = new StringBuilder(fileText);
            if (templateFields != null)
            {
                foreach (var fieldValuePair in templateFields)
                {
                    mailBody.Replace(fieldValuePair.Key, fieldValuePair.Value);
                }
            }

            Send(smtpHost, fromAddress, fromDisplayName, toAddressesDelimited, subject, mailBody.ToString(), templateFields, attachments);
        }

        /// <summary>
        /// Sends an email with the given properties.
        /// </summary>
        /// <remarks>Can throw exceptions.</remarks>
        public static void Send(
            string smtpHost,
            string fromAddress, string fromDisplayName,
            string toAddressesDelimited,
            string subject,
            string body,
            Dictionary<string, string> tagValues = null,
            Dictionary<string, Stream> attachments = null)
        {
            //Assert.ArgumentNotNullOrEmpty(smtpHost, "smptHost");
            //Assert.ArgumentNotNullOrEmpty(fromAddress, "smptHost");
            //Assert.ArgumentNotNullOrEmpty(toAddressesDelimited, "toAddressesDelimited");
            //Assert.ArgumentNotNullOrEmpty(subject, "subject");
            //Assert.ArgumentNotNullOrEmpty(body, "body");

            var toAddresses = toAddressesDelimited.Split(new char[] { '|', ';', ',' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                using (var smtpClient = new SmtpClient(smtpHost) { DeliveryMethod = SmtpDeliveryMethod.Network })
                {
                    using
                    (
                        var mailMsg = new MailMessage()
                        {
                            IsBodyHtml = true,
                            Subject = subject,
                            From = new MailAddress(fromAddress, fromDisplayName),
                            Body = body
                        }
                    )
                    {
                        // Set to addresses
                        foreach (var s in toAddresses)
                        {
                            mailMsg.To.Add(new MailAddress(s));
                        }

                        // Set attachments
                        if (attachments != null)
                        {
                            foreach (var attachment in attachments)
                            {
                                mailMsg.Attachments.Add(new Attachment(attachment.Value, attachment.Key));
                            }
                        }

                        // Send
                        smtpClient.Send(mailMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                //Log.Error(String.Format("[MailHelper] was unable to send email with subject [{0}] to email address/es [{1}].", subject, toAddressesDelimited), ex, typeof(MailHelper));
                throw;
            }
        }
    }
}