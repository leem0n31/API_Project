namespace WebApplication1.Contracts.Notification
{
    public class CreateNotificationRequest
    {

        public int IdПользователя { get; set; }

        public string ТипУведомления { get; set; } = null!;

        public string Заголовок { get; set; } = null!;

        public string Сообщение { get; set; } = null!;

        public bool? Прочитано { get; set; }

      
    }
}
