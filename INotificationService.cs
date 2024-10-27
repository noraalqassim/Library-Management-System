namespace LibraryManagementSystem
{
    public interface INotificationService
    {
        void SendNotificationOnSuccess(string message);
        void SendNotificationOnFailure(string errorMessage);
    }

    public class EmailNotificationService : INotificationService
    {
        public void SendNotificationOnSuccess(string message)
        {
            Console.WriteLine($"[Email]: {message}");
        }

        public void SendNotificationOnFailure(string errorMessage)
        {
            Console.WriteLine($"[Email]: {errorMessage}");
        }
    }

    public class SMSNotificationService : INotificationService
    {
        public void SendNotificationOnSuccess(string message)
        {
            Console.WriteLine($"[SMS]: {message}");
        }

        public void SendNotificationOnFailure(string errorMessage)
        {
            Console.WriteLine($"[SMS] : {errorMessage}");
        }
    }
}
