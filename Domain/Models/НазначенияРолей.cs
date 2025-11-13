using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class НазначенияРолей
{
    public int IdНазначения { get; set; }

    public int IdПользователя { get; set; }

    public int IdРоли { get; set; }

    public DateTime? ДатаНазначения { get; set; }

    public int? Назначил { get; set; }

    public virtual Пользователи IdПользователяNavigation { get; set; } = null!;

    public virtual Роли IdРолиNavigation { get; set; } = null!;

    public virtual Пользователи? НазначилNavigation { get; set; }
}
