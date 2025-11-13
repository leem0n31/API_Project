using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ЧленствоВгруппах
{
    public int IdЧленства { get; set; }

    public int IdПользователя { get; set; }

    public int IdГруппы { get; set; }

    public DateTime? ДатаВступления { get; set; }

    public bool? Активен { get; set; }

    public virtual УчебныеГруппы IdГруппыNavigation { get; set; } = null!;

    public virtual Пользователи IdПользователяNavigation { get; set; } = null!;
}
