namespace Decorator
{
    /// <summary>
    /// Component
    /// </summary>
    public interface IMailService
    {
        bool SendMail(string message);
    }
    /// <summary>
    /// Concrete Component
    /// </summary>
    public class CloudMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine("CloudMailService {0}", message);
            return true;
        }
    }
    /// <summary>
    /// Concrete Component
    /// </summary>
    public class OnPremiseMailServicer : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine("OnPremiseMailServicer {0}", message);
            return true;
        }
    }
    /// <summary>
    /// Decorator
    /// </summary>
    public abstract class MailDecoratorBase : IMailService
    {
        private readonly IMailService _mailService;
        public MailDecoratorBase(IMailService mailService)
        {
            _mailService = mailService;
        }
        public virtual bool SendMail(string message)
        {
            return _mailService.SendMail(message);
        }
    }
    public class StatisticMailService : MailDecoratorBase
    {
        public StatisticMailService(IMailService mailService) : base(mailService)
        {
        }
        public override bool SendMail(string message)
        {
            Console.WriteLine("StatisticMailService {0}", message);
            return base.SendMail(message);
        }
    }
    public class DatabaseMailService : MailDecoratorBase
    {
        public List<string> databases = new List<string>();
        public DatabaseMailService(IMailService mailService) : base(mailService)
        {
        }
        public override bool SendMail(string message)
        {
            Console.WriteLine("DatabaseMailService {0}", message);
            if (base.SendMail(message))
            {
                databases.Add(message);
                return true;
            }
            return false;
        }
    }
}
