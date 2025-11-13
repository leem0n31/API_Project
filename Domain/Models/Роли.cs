using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Роли
{
    public int IdРоли { get; set; }

    public string НазваниеРоли { get; set; } = null!;

    public string? Описание { get; set; }

    public DateTime? ДатаСоздания { get; set; }

    public virtual ICollection<НазначенияРолей> НазначенияРолейs { get; set; } = new List<НазначенияРолей>();
}
