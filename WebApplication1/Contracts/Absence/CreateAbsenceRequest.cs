namespace WebApplication1.Contracts.Absence
{
    public class CreateAbsenceRequest
    {
   

        public int IdПользователя { get; set; }

        public int IdГруппы { get; set; }

        public DateOnly ДатаПропуска { get; set; }

        public string? Причина { get; set; }

        public string? Описание { get; set; }

        public bool? Уважительная { get; set; }

        public int Отметил { get; set; }

     
    }
}
