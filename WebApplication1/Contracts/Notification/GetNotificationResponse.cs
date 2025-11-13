namespace WebApplication1.Contracts.Notification
{
    public class GetNotificationResponse
    {
        public int IdУведомления { get; set; }

        public int IdПользователя { get; set; }

        public string ТипУведомления { get; set; } = null!;

        public string Заголовок { get; set; } = null!;

        public string Сообщение { get; set; } = null!;

        public bool? Прочитано { get; set; }

        public DateTime? ДатаСоздания { get; set; }

        public DateTime? ДатаОтправки { get; set; }
    }
}
