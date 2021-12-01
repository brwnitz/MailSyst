using System;
using System.IO;
using System.Net.Mail;

namespace MailSyst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            try
            {
                MailMessage mail = new MailMessage(); //EMAIL
                SmtpClient SmtpServer = new SmtpClient("smtp.live.com"); //SERVIDOR
                mail.From = new MailAddress("brunote16@hotmail.com");
                var emails = new StreamReader("G:\\Emails\\emails.txt");

                foreach (var email in emails.ReadLine().Split(","))
                {
                    mail.To.Add(email); //

                }

                mail.Subject = "TESTE EMAIL"; //
                mail.IsBodyHtml = true; //

                var body = File.ReadAllText("G:\\Emails\\email.html");
                body = body.Replace("@Name", "Bruno Torres");
                body = body.Replace("@Descricao", "Tranquilo demais....");

                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("brunote16@hotmail.com", "*");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                Console.WriteLine("SEND MAIL");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}

