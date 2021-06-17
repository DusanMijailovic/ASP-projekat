using Application.Email;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Implementation.Email
{
	public class SmtpEmailSender : IEmailSender
	{
		public void Send(SendEmailDto mail)
		{
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("sportske.projekat@gmail.com", "sportske123")
            };

            var message = new MailMessage("sportske.projekat@gmail.com", mail.SendTo);
            message.Subject = mail.Subject;
            message.Body = mail.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }

		
	}
}
