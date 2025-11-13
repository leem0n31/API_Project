namespace WebApplication1.Contracts.DutyDebt
{
    public class UpdateDutyDebtRequest
    {
        public int IdДолга { get; set; }

        public int IdПользователя { get; set; }

        public int IdПропущенногоДежурства { get; set; }

        public string? Статус { get; set; }

        public DateOnly? НоваяДата { get; set; }

        public int? IdОтработочногоДежурства { get; set; }

    }
}
