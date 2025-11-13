using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class Proect1Context : DbContext
{
    public Proect1Context()
    {
    }

    public Proect1Context(DbContextOptions<Proect1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<ДолгиПоДежурствам> ДолгиПоДежурствамs { get; set; }

    public virtual DbSet<ЗапросыНаЗамену> ЗапросыНаЗаменуs { get; set; }

    public virtual DbSet<НазначенияРолей> НазначенияРолейs { get; set; }

    public virtual DbSet<Пользователи> Пользователиs { get; set; }

    public virtual DbSet<Пропуски> Пропускиs { get; set; }

    public virtual DbSet<РасписаниеДежурств> РасписаниеДежурствs { get; set; }

    public virtual DbSet<Роли> Ролиs { get; set; }

    public virtual DbSet<Уведомления> Уведомленияs { get; set; }

    public virtual DbSet<УчебныеГруппы> УчебныеГруппыs { get; set; }

    public virtual DbSet<ЧленствоВгруппах> ЧленствоВгруппахs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ДолгиПоДежурствам>(entity =>
        {
            entity.HasKey(e => e.IdДолга).HasName("PK__ДолгиПоД__4C9FBB725845CDFC");

            entity.ToTable("ДолгиПоДежурствам");

            entity.Property(e => e.IdДолга).HasColumnName("ID_долга");
            entity.Property(e => e.IdОтработочногоДежурства).HasColumnName("ID_отработочного_дежурства");
            entity.Property(e => e.IdПользователя).HasColumnName("ID_пользователя");
            entity.Property(e => e.IdПропущенногоДежурства).HasColumnName("ID_пропущенного_дежурства");
            entity.Property(e => e.ДатаЗакрытия).HasColumnName("Дата_закрытия");
            entity.Property(e => e.ДатаСоздания)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Дата_создания");
            entity.Property(e => e.НоваяДата).HasColumnName("Новая_дата");
            entity.Property(e => e.Статус)
                .HasMaxLength(20)
                .HasDefaultValue("ожидание");

            entity.HasOne(d => d.IdОтработочногоДежурстваNavigation).WithMany(p => p.ДолгиПоДежурствамIdОтработочногоДежурстваNavigations)
                .HasForeignKey(d => d.IdОтработочногоДежурства)
                .HasConstraintName("FK__ДолгиПоДе__ID_от__6B24EA82");

            entity.HasOne(d => d.IdПользователяNavigation).WithMany(p => p.ДолгиПоДежурствамs)
                .HasForeignKey(d => d.IdПользователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ДолгиПоДе__ID_по__68487DD7");

            entity.HasOne(d => d.IdПропущенногоДежурстваNavigation).WithMany(p => p.ДолгиПоДежурствамIdПропущенногоДежурстваNavigations)
                .HasForeignKey(d => d.IdПропущенногоДежурства)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ДолгиПоДе__ID_пр__693CA210");
        });

        modelBuilder.Entity<ЗапросыНаЗамену>(entity =>
        {
            entity.HasKey(e => e.IdЗапроса).HasName("PK__ЗапросыН__01448438A41999EF");

            entity.ToTable("ЗапросыНаЗамену");

            entity.Property(e => e.IdЗапроса).HasColumnName("ID_запроса");
            entity.Property(e => e.IdДежурства).HasColumnName("ID_дежурства");
            entity.Property(e => e.IdЗаменяющего).HasColumnName("ID_заменяющего");
            entity.Property(e => e.IdЗапрашивающего).HasColumnName("ID_запрашивающего");
            entity.Property(e => e.ДатаОбновления)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Дата_обновления");
            entity.Property(e => e.ДатаСоздания)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Дата_создания");
            entity.Property(e => e.КомментарийЗапроса).HasColumnName("Комментарий_запроса");
            entity.Property(e => e.КомментарийОтвета).HasColumnName("Комментарий_ответа");
            entity.Property(e => e.НоваяДата).HasColumnName("Новая_дата");
            entity.Property(e => e.Статус)
                .HasMaxLength(20)
                .HasDefaultValue("ожидание");

            entity.HasOne(d => d.IdДежурстваNavigation).WithMany(p => p.ЗапросыНаЗаменуs)
                .HasForeignKey(d => d.IdДежурства)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ЗапросыНа__ID_де__619B8048");

            entity.HasOne(d => d.IdЗаменяющегоNavigation).WithMany(p => p.ЗапросыНаЗаменуIdЗаменяющегоNavigations)
                .HasForeignKey(d => d.IdЗаменяющего)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ЗапросыНа__ID_за__60A75C0F");

            entity.HasOne(d => d.IdЗапрашивающегоNavigation).WithMany(p => p.ЗапросыНаЗаменуIdЗапрашивающегоNavigations)
                .HasForeignKey(d => d.IdЗапрашивающего)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ЗапросыНа__ID_за__5FB337D6");

            entity.HasOne(d => d.ОдобрилNavigation).WithMany(p => p.ЗапросыНаЗаменуОдобрилNavigations)
                .HasForeignKey(d => d.Одобрил)
                .HasConstraintName("FK__ЗапросыНа__Одобр__6383C8BA");
        });

        modelBuilder.Entity<НазначенияРолей>(entity =>
        {
            entity.HasKey(e => e.IdНазначения).HasName("PK__Назначен__7034F95F734DA23D");

            entity.ToTable("НазначенияРолей");

            entity.Property(e => e.IdНазначения).HasColumnName("ID_назначения");
            entity.Property(e => e.IdПользователя).HasColumnName("ID_пользователя");
            entity.Property(e => e.IdРоли).HasColumnName("ID_роли");
            entity.Property(e => e.ДатаНазначения)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Дата_назначения");

            entity.HasOne(d => d.IdПользователяNavigation).WithMany(p => p.НазначенияРолейIdПользователяNavigations)
                .HasForeignKey(d => d.IdПользователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Назначени__ID_по__4222D4EF");

            entity.HasOne(d => d.IdРолиNavigation).WithMany(p => p.НазначенияРолейs)
                .HasForeignKey(d => d.IdРоли)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Назначени__ID_ро__4316F928");

            entity.HasOne(d => d.НазначилNavigation).WithMany(p => p.НазначенияРолейНазначилNavigations)
                .HasForeignKey(d => d.Назначил)
                .HasConstraintName("FK__Назначени__Назна__44FF419A");
        });

        modelBuilder.Entity<Пользователи>(entity =>
        {
            entity.HasKey(e => e.IdПользователя).HasName("PK__Пользова__B1AC0CDEB0127D7E");

            entity.ToTable("Пользователи");

            entity.HasIndex(e => e.Email, "UQ__Пользова__A9D105347D5A58FC").IsUnique();

            entity.HasIndex(e => e.Логин, "UQ__Пользова__BC2217D3375C02AA").IsUnique();

            entity.Property(e => e.IdПользователя).HasColumnName("ID_пользователя");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Активен).HasDefaultValue(true);
            entity.Property(e => e.ДатаОбновления)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Дата_обновления");
            entity.Property(e => e.ДатаСоздания)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Дата_создания");
            entity.Property(e => e.Имя).HasMaxLength(50);
            entity.Property(e => e.Логин).HasMaxLength(50);
            entity.Property(e => e.Пароль).HasMaxLength(255);
            entity.Property(e => e.Телефон).HasMaxLength(20);
            entity.Property(e => e.Фамилия).HasMaxLength(50);
        });

        modelBuilder.Entity<Пропуски>(entity =>
        {
            entity.HasKey(e => e.IdПропуска).HasName("PK__Пропуски__77AC52A5027D18D2");

            entity.ToTable("Пропуски");

            entity.Property(e => e.IdПропуска).HasColumnName("ID_пропуска");
            entity.Property(e => e.IdГруппы).HasColumnName("ID_группы");
            entity.Property(e => e.IdПользователя).HasColumnName("ID_пользователя");
            entity.Property(e => e.ДатаПропуска).HasColumnName("Дата_пропуска");
            entity.Property(e => e.ДатаСоздания)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Дата_создания");
            entity.Property(e => e.Причина).HasMaxLength(100);
            entity.Property(e => e.Уважительная).HasDefaultValue(false);

            entity.HasOne(d => d.IdГруппыNavigation).WithMany(p => p.Пропускиs)
                .HasForeignKey(d => d.IdГруппы)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Пропуски__ID_гру__59FA5E80");

            entity.HasOne(d => d.IdПользователяNavigation).WithMany(p => p.ПропускиIdПользователяNavigations)
                .HasForeignKey(d => d.IdПользователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Пропуски__ID_пол__59063A47");

            entity.HasOne(d => d.ОтметилNavigation).WithMany(p => p.ПропускиОтметилNavigations)
                .HasForeignKey(d => d.Отметил)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Пропуски__Отмети__5BE2A6F2");
        });

        modelBuilder.Entity<РасписаниеДежурств>(entity =>
        {
            entity.HasKey(e => e.IdРасписания).HasName("PK__Расписан__6BE45D70D9EE56FF");

            entity.ToTable("РасписаниеДежурств");

            entity.Property(e => e.IdРасписания).HasColumnName("ID_расписания");
            entity.Property(e => e.IdГруппы).HasColumnName("ID_группы");
            entity.Property(e => e.IdДежурного).HasColumnName("ID_дежурного");
            entity.Property(e => e.ДатаДежурства).HasColumnName("Дата_дежурства");
            entity.Property(e => e.ДатаОбновления)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Дата_обновления");
            entity.Property(e => e.ДатаСоздания)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Дата_создания");
            entity.Property(e => e.Статус)
                .HasMaxLength(20)
                .HasDefaultValue("запланировано");

            entity.HasOne(d => d.IdГруппыNavigation).WithMany(p => p.РасписаниеДежурствs)
                .HasForeignKey(d => d.IdГруппы)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Расписани__ID_гр__5165187F");

            entity.HasOne(d => d.IdДежурногоNavigation).WithMany(p => p.РасписаниеДежурствIdДежурногоNavigations)
                .HasForeignKey(d => d.IdДежурного)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Расписани__ID_де__52593CB8");

            entity.HasOne(d => d.СоздалNavigation).WithMany(p => p.РасписаниеДежурствСоздалNavigations)
                .HasForeignKey(d => d.Создал)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Расписани__Созда__5441852A");
        });

        modelBuilder.Entity<Роли>(entity =>
        {
            entity.HasKey(e => e.IdРоли).HasName("PK__Роли__11CE7F093BE2EC30");

            entity.ToTable("Роли");

            entity.HasIndex(e => e.НазваниеРоли, "UQ__Роли__927FA07BDADF8E5A").IsUnique();

            entity.Property(e => e.IdРоли).HasColumnName("ID_роли");
            entity.Property(e => e.ДатаСоздания)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Дата_создания");
            entity.Property(e => e.НазваниеРоли)
                .HasMaxLength(50)
                .HasColumnName("Название_роли");
            entity.Property(e => e.Описание).HasMaxLength(255);
        });

        modelBuilder.Entity<Уведомления>(entity =>
        {
            entity.HasKey(e => e.IdУведомления).HasName("PK__Уведомле__3DA678172E68D11A");

            entity.ToTable("Уведомления");

            entity.Property(e => e.IdУведомления).HasColumnName("ID_уведомления");
            entity.Property(e => e.IdПользователя).HasColumnName("ID_пользователя");
            entity.Property(e => e.ДатаОтправки).HasColumnName("Дата_отправки");
            entity.Property(e => e.ДатаСоздания)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Дата_создания");
            entity.Property(e => e.Заголовок).HasMaxLength(200);
            entity.Property(e => e.Прочитано).HasDefaultValue(false);
            entity.Property(e => e.ТипУведомления)
                .HasMaxLength(50)
                .HasColumnName("Тип_уведомления");

            entity.HasOne(d => d.IdПользователяNavigation).WithMany(p => p.Уведомленияs)
                .HasForeignKey(d => d.IdПользователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Уведомлен__ID_по__6EF57B66");
        });

        modelBuilder.Entity<УчебныеГруппы>(entity =>
        {
            entity.HasKey(e => e.IdГруппы).HasName("PK__УчебныеГ__7EC7037DD053D9CE");

            entity.ToTable("УчебныеГруппы");

            entity.HasIndex(e => e.НазваниеГруппы, "UQ__УчебныеГ__913C6830AB51EB2E").IsUnique();

            entity.Property(e => e.IdГруппы).HasColumnName("ID_группы");
            entity.Property(e => e.ДатаСоздания)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Дата_создания");
            entity.Property(e => e.НазваниеГруппы)
                .HasMaxLength(100)
                .HasColumnName("Название_группы");
            entity.Property(e => e.Факультет).HasMaxLength(200);
        });

        modelBuilder.Entity<ЧленствоВгруппах>(entity =>
        {
            entity.HasKey(e => e.IdЧленства).HasName("PK__Членство__ED525EA0621731A9");

            entity.ToTable("ЧленствоВГруппах");

            entity.Property(e => e.IdЧленства).HasColumnName("ID_членства");
            entity.Property(e => e.IdГруппы).HasColumnName("ID_группы");
            entity.Property(e => e.IdПользователя).HasColumnName("ID_пользователя");
            entity.Property(e => e.Активен).HasDefaultValue(true);
            entity.Property(e => e.ДатаВступления)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Дата_вступления");

            entity.HasOne(d => d.IdГруппыNavigation).WithMany(p => p.ЧленствоВгруппахs)
                .HasForeignKey(d => d.IdГруппы)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ЧленствоВ__ID_гр__4CA06362");

            entity.HasOne(d => d.IdПользователяNavigation).WithMany(p => p.ЧленствоВгруппахs)
                .HasForeignKey(d => d.IdПользователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ЧленствоВ__ID_по__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
