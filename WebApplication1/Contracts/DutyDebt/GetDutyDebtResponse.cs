namespace WebApplication1.Contracts.DutyDebt
{
    public class GetDutyDebtResponse
    {
        public int IdДолга { get; set; }

        public int IdПользователя { get; set; }

        public int IdПропущенногоДежурства { get; set; }

        public string? Статус { get; set; }

        public DateOnly? НоваяДата { get; set; }

        public int? IdОтработочногоДежурства { get; set; }

        public DateTime? ДатаСоздания { get; set; }

        public DateTime? ДатаЗакрытия { get; set; }
    }
}
