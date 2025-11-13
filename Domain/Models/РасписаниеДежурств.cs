using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class РасписаниеДежурств
{
    public int IdРасписания { get; set; }

    public int IdГруппы { get; set; }

    public DateOnly ДатаДежурства { get; set; }

    public int IdДежурного { get; set; }

    public string? Статус { get; set; }

    public int Создал { get; set; }

    public DateTime? ДатаСоздания { get; set; }

    public DateTime? ДатаОбновления { get; set; }

    public virtual УчебныеГруппы IdГруппыNavigation { get; set; } = null!;

    public virtual Пользователи IdДежурногоNavigation { get; set; } = null!;

    public virtual ICollection<ДолгиПоДежурствам> ДолгиПоДежурствамIdОтработочногоДежурстваNavigations { get; set; } = new List<ДолгиПоДежурствам>();

    public virtual ICollection<ДолгиПоДежурствам> ДолгиПоДежурствамIdПропущенногоДежурстваNavigations { get; set; } = new List<ДолгиПоДежурствам>();

    public virtual ICollection<ЗапросыНаЗамену> ЗапросыНаЗаменуs { get; set; } = new List<ЗапросыНаЗамену>();

    public virtual Пользователи СоздалNavigation { get; set; } = null!;
}
