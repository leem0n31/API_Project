using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Пропуски
{
    public int IdПропуска { get; set; }

    public int IdПользователя { get; set; }

    public int IdГруппы { get; set; }

    public DateOnly ДатаПропуска { get; set; }

    public string? Причина { get; set; }

    public string? Описание { get; set; }

    public bool? Уважительная { get; set; }

    public int Отметил { get; set; }

    public DateTime? ДатаСоздания { get; set; }

    public virtual УчебныеГруппы IdГруппыNavigation { get; set; } = null!;

    public virtual Пользователи IdПользователяNavigation { get; set; } = null!;

    public virtual Пользователи ОтметилNavigation { get; set; } = null!;
}
