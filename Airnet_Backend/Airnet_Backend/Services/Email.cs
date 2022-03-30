using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace Airnet_Backend.Services
{
      public class Email
      {
            public Email()
            {
                  SendTest();
            }
            public static void SendTest()
            {

                  string to = "chanlee.0751@gmail.com";
                  string from = "vinosiva.2001@gmail.com";
                  var mail = new MimeMessage();
                  mail.Sender = MailboxAddress.Parse(from);
                  mail.To.Add(MailboxAddress.Parse(to));
                  mail.Subject = "Using the new SMTP client.";
                  mail.Body = new TextPart("plain")
                  {
                        Text = "Using this new feature,you can send an email message from an application very easily."
                  };
                  using (var client = new SmtpClient())
                  {
                        client.Connect("smtp.gmail.com", 465, true);
                        client.Authenticate("chanlee.0751@gmail.com", "lee751chan");
                        try
                        {
                              client.SendAsync(mail);
                        }
                        catch (Exception ex)
                        {
                              Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                                  ex.ToString());
                        }
                        finally
                        {
                              client.DisconnectAsync(true);
                              client.Dispose();
                        }
                  }
            }
      }
}




