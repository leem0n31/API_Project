using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class УчебныеГруппы
{
    public int IdГруппы { get; set; }

    public string НазваниеГруппы { get; set; } = null!;

    public int Курс { get; set; }

    public string? Факультет { get; set; }

    public DateTime? ДатаСоздания { get; set; }

    public virtual ICollection<Пропуски> Пропускиs { get; set; } = new List<Пропуски>();

    public virtual ICollection<РасписаниеДежурств> РасписаниеДежурствs { get; set; } = new List<РасписаниеДежурств>();

    public virtual ICollection<ЧленствоВгруппах> ЧленствоВгруппахs { get; set; } = new List<ЧленствоВгруппах>();
}
