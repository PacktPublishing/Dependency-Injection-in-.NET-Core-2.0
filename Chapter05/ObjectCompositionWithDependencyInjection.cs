using System;

namespace DependencyExamples
{
    class Program
    {
        static void Main(string[] args)
        {
			Notification notify = new Notification(new Mail(), new Sms());
            
            // Uncomment the below one if you want SmtpMail as IMail type.
			// Don't forget to comment the above one. :)
            //Notification notify = new Notification(new SmtpMail(), new Sms());
            notify.SendNotification("taditdash@gmail.com", "9132994288", "Hello Tadit!");
			
			Console.ReadKey();
		}
	}
	
	interface IMail
    {
        bool SendMail(string mailId, string message);
    }

    interface ISms
    {
        bool SendSms(string mobile, string message);
    }

    public class Mail : IMail
    {
        public bool SendMail(string mailId, string message)
        {
            // Logic to send an email
            Console.WriteLine("SendMail Called");
            return true;
        }
    }

    public class Sms : ISms
    {
        public bool SendSms(string mailId, string message)
        {
            // Logic to send a Sms
            Console.WriteLine("SendSms Called");
            return true;
        }
    }

    public class SmtpMail : IMail
    {
        public bool SendMail(string mailId, string message)
        {
            // Logic to send an email
            Console.WriteLine("SmtpMail Called");
            return true;
        }
    }

    class Notification
    {
        private readonly IMail _mail;
        private readonly ISms _sms;

        public Notification(IMail mail, ISms sms)
        {
            _mail = mail;
            _sms = sms;
        }

        public void SendNotification(string mailId, string mobile, string message)
        {
            _mail.SendMail(mailId, message);
            _sms.SendSms(mobile, message);
        }
    }
}