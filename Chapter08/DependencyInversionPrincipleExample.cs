using System;

namespace DIPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var feedbackService = new FeedbackService(new SmsNotifier());
            feedbackService.SaveFeedback(new Feedback());
        }
    }

    public class Feedback : IFeedback
    {
    }

    public interface IFeedback
    {
    }

    public interface IFeedbackService
    {
        void SaveFeedback(IFeedback feedback);
    }

    public class FeedbackService : IFeedbackService
    {
        private readonly INotifier _notifier;

        public FeedbackService(INotifier notifier)
        {
            _notifier = notifier;
        }

        public void SaveFeedback(IFeedback feedback)
        {
            SaveFeedbackToDb(feedback);

            _notifier.SendNotification(feedback);
        }

        private int SaveFeedbackToDb(IFeedback feedback)
        {
            Console.WriteLine("Db Saving Started.");
            return 1;
        }
    }

    public interface INotifier
    {
        void SendNotification(IFeedback feedback);
    }

    public class EmailNotifier : INotifier
    {
        public void SendNotification(IFeedback feedback)
        {
            Console.WriteLine("Email Notification starts!");
        }
    }

    public class SmsNotifier : INotifier
    {
        public void SendNotification(IFeedback feedback)
        {
            Console.WriteLine("Sms Notification starts!");
        }
    }

    public class VoiceNotifier : INotifier
    {
        public void SendNotification(IFeedback feedback)
        {
            Console.WriteLine("Voice Notification starts!");
        }
    }
}