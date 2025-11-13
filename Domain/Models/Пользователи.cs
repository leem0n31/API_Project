using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Пользователи
{
    public int IdПользователя { get; set; }

    public string Логин { get; set; } = null!;

    public string Пароль { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string Фамилия { get; set; } = null!;

    public string? Телефон { get; set; }

    public bool? Активен { get; set; }

    public DateTime? ДатаСоздания { get; set; }

    public DateTime? ДатаОбновления { get; set; }

    public virtual ICollection<ДолгиПоДежурствам> ДолгиПоДежурствамs { get; set; } = new List<ДолгиПоДежурствам>();

    public virtual ICollection<ЗапросыНаЗамену> ЗапросыНаЗаменуIdЗаменяющегоNavigations { get; set; } = new List<ЗапросыНаЗамену>();

    public virtual ICollection<ЗапросыНаЗамену> ЗапросыНаЗаменуIdЗапрашивающегоNavigations { get; set; } = new List<ЗапросыНаЗамену>();

    public virtual ICollection<ЗапросыНаЗамену> ЗапросыНаЗаменуОдобрилNavigations { get; set; } = new List<ЗапросыНаЗамену>();

    public virtual ICollection<НазначенияРолей> НазначенияРолейIdПользователяNavigations { get; set; } = new List<НазначенияРолей>();

    public virtual ICollection<НазначенияРолей> НазначенияРолейНазначилNavigations { get; set; } = new List<НазначенияРолей>();

    public virtual ICollection<Пропуски> ПропускиIdПользователяNavigations { get; set; } = new List<Пропуски>();

    public virtual ICollection<Пропуски> ПропускиОтметилNavigations { get; set; } = new List<Пропуски>();

    public virtual ICollection<РасписаниеДежурств> РасписаниеДежурствIdДежурногоNavigations { get; set; } = new List<РасписаниеДежурств>();

    public virtual ICollection<РасписаниеДежурств> РасписаниеДежурствСоздалNavigations { get; set; } = new List<РасписаниеДежурств>();

    public virtual ICollection<Уведомления> Уведомленияs { get; set; } = new List<Уведомления>();

    public virtual ICollection<ЧленствоВгруппах> ЧленствоВгруппахs { get; set; } = new List<ЧленствоВгруппах>();
}
