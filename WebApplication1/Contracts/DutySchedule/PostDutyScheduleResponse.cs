namespace WebApplication1.Contracts.DutySchedule
{
    public class PostDutyScheduleResponse
    {
        public int IdРасписания { get; set; }

        public int IdГруппы { get; set; }

        public DateOnly ДатаДежурства { get; set; }

        public int IdДежурного { get; set; }

        public string? Статус { get; set; }

        public int Создал { get; set; }

       
    }
}
