namespace WebApplication1.Contracts.ReplacementRequest
{
    public class CreateReplacementRequestRequest
    {

        public int IdЗапрашивающего { get; set; }

        public int IdЗаменяющего { get; set; }

        public int IdДежурства { get; set; }

        public DateOnly? НоваяДата { get; set; }

        public string? Статус { get; set; }

        public string? КомментарийЗапроса { get; set; }

        public string? КомментарийОтвета { get; set; }

        public int? Одобрил { get; set; }


    }
}
