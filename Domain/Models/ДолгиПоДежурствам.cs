using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ДолгиПоДежурствам
{
    public int IdДолга { get; set; }

    public int IdПользователя { get; set; }

    public int IdПропущенногоДежурства { get; set; }

    public string? Статус { get; set; }

    public DateOnly? НоваяДата { get; set; }

    public int? IdОтработочногоДежурства { get; set; }

    public DateTime? ДатаСоздания { get; set; }

    public DateTime? ДатаЗакрытия { get; set; }

    public virtual РасписаниеДежурств? IdОтработочногоДежурстваNavigation { get; set; }

    public virtual Пользователи IdПользователяNavigation { get; set; } = null!;

    public virtual РасписаниеДежурств IdПропущенногоДежурстваNavigation { get; set; } = null!;
}
