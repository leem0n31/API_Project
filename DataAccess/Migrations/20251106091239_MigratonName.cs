using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigratonName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Пользователи",
                columns: table => new
                {
                    ID_пользователя = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Логин = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Пароль = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Имя = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Фамилия = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Телефон = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Активен = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Дата_создания = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    Дата_обновления = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Пользова__B1AC0CDEB0127D7E", x => x.ID_пользователя);
                });

            migrationBuilder.CreateTable(
                name: "Роли",
                columns: table => new
                {
                    ID_роли = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Название_роли = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Описание = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Дата_создания = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Роли__11CE7F093BE2EC30", x => x.ID_роли);
                });

            migrationBuilder.CreateTable(
                name: "УчебныеГруппы",
                columns: table => new
                {
                    ID_группы = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Название_группы = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Курс = table.Column<int>(type: "int", nullable: false),
                    Факультет = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Дата_создания = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__УчебныеГ__7EC7037DD053D9CE", x => x.ID_группы);
                });

            migrationBuilder.CreateTable(
                name: "Уведомления",
                columns: table => new
                {
                    ID_уведомления = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_пользователя = table.Column<int>(type: "int", nullable: false),
                    Тип_уведомления = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Заголовок = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Сообщение = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Прочитано = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Дата_создания = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    Дата_отправки = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Уведомле__3DA678172E68D11A", x => x.ID_уведомления);
                    table.ForeignKey(
                        name: "FK__Уведомлен__ID_по__6EF57B66",
                        column: x => x.ID_пользователя,
                        principalTable: "Пользователи",
                        principalColumn: "ID_пользователя");
                });

            migrationBuilder.CreateTable(
                name: "НазначенияРолей",
                columns: table => new
                {
                    ID_назначения = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_пользователя = table.Column<int>(type: "int", nullable: false),
                    ID_роли = table.Column<int>(type: "int", nullable: false),
                    Дата_назначения = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    Назначил = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Назначен__7034F95F734DA23D", x => x.ID_назначения);
                    table.ForeignKey(
                        name: "FK__Назначени__ID_по__4222D4EF",
                        column: x => x.ID_пользователя,
                        principalTable: "Пользователи",
                        principalColumn: "ID_пользователя");
                    table.ForeignKey(
                        name: "FK__Назначени__ID_ро__4316F928",
                        column: x => x.ID_роли,
                        principalTable: "Роли",
                        principalColumn: "ID_роли");
                    table.ForeignKey(
                        name: "FK__Назначени__Назна__44FF419A",
                        column: x => x.Назначил,
                        principalTable: "Пользователи",
                        principalColumn: "ID_пользователя");
                });

            migrationBuilder.CreateTable(
                name: "Пропуски",
                columns: table => new
                {
                    ID_пропуска = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_пользователя = table.Column<int>(type: "int", nullable: false),
                    ID_группы = table.Column<int>(type: "int", nullable: false),
                    Дата_пропуска = table.Column<DateOnly>(type: "date", nullable: false),
                    Причина = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Описание = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Уважительная = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Отметил = table.Column<int>(type: "int", nullable: false),
                    Дата_создания = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Пропуски__77AC52A5027D18D2", x => x.ID_пропуска);
                    table.ForeignKey(
                        name: "FK__Пропуски__ID_гру__59FA5E80",
                        column: x => x.ID_группы,
                        principalTable: "УчебныеГруппы",
                        principalColumn: "ID_группы");
                    table.ForeignKey(
                        name: "FK__Пропуски__ID_пол__59063A47",
                        column: x => x.ID_пользователя,
                        principalTable: "Пользователи",
                        principalColumn: "ID_пользователя");
                    table.ForeignKey(
                        name: "FK__Пропуски__Отмети__5BE2A6F2",
                        column: x => x.Отметил,
                        principalTable: "Пользователи",
                        principalColumn: "ID_пользователя");
                });

            migrationBuilder.CreateTable(
                name: "РасписаниеДежурств",
                columns: table => new
                {
                    ID_расписания = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_группы = table.Column<int>(type: "int", nullable: false),
                    Дата_дежурства = table.Column<DateOnly>(type: "date", nullable: false),
                    ID_дежурного = table.Column<int>(type: "int", nullable: false),
                    Статус = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "запланировано"),
                    Создал = table.Column<int>(type: "int", nullable: false),
                    Дата_создания = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    Дата_обновления = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Расписан__6BE45D70D9EE56FF", x => x.ID_расписания);
                    table.ForeignKey(
                        name: "FK__Расписани__ID_гр__5165187F",
                        column: x => x.ID_группы,
                        principalTable: "УчебныеГруппы",
                        principalColumn: "ID_группы");
                    table.ForeignKey(
                        name: "FK__Расписани__ID_де__52593CB8",
                        column: x => x.ID_дежурного,
                        principalTable: "Пользователи",
                        principalColumn: "ID_пользователя");
                    table.ForeignKey(
                        name: "FK__Расписани__Созда__5441852A",
                        column: x => x.Создал,
                        principalTable: "Пользователи",
                        principalColumn: "ID_пользователя");
                });

            migrationBuilder.CreateTable(
                name: "ЧленствоВГруппах",
                columns: table => new
                {
                    ID_членства = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_пользователя = table.Column<int>(type: "int", nullable: false),
                    ID_группы = table.Column<int>(type: "int", nullable: false),
                    Дата_вступления = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    Активен = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Членство__ED525EA0621731A9", x => x.ID_членства);
                    table.ForeignKey(
                        name: "FK__ЧленствоВ__ID_гр__4CA06362",
                        column: x => x.ID_группы,
                        principalTable: "УчебныеГруппы",
                        principalColumn: "ID_группы");
                    table.ForeignKey(
                        name: "FK__ЧленствоВ__ID_по__4BAC3F29",
                        column: x => x.ID_пользователя,
                        principalTable: "Пользователи",
                        principalColumn: "ID_пользователя");
                });

            migrationBuilder.CreateTable(
                name: "ДолгиПоДежурствам",
                columns: table => new
                {
                    ID_долга = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_пользователя = table.Column<int>(type: "int", nullable: false),
                    ID_пропущенного_дежурства = table.Column<int>(type: "int", nullable: false),
                    Статус = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "ожидание"),
                    Новая_дата = table.Column<DateOnly>(type: "date", nullable: true),
                    ID_отработочного_дежурства = table.Column<int>(type: "int", nullable: true),
                    Дата_создания = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    Дата_закрытия = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ДолгиПоД__4C9FBB725845CDFC", x => x.ID_долга);
                    table.ForeignKey(
                        name: "FK__ДолгиПоДе__ID_от__6B24EA82",
                        column: x => x.ID_отработочного_дежурства,
                        principalTable: "РасписаниеДежурств",
                        principalColumn: "ID_расписания");
                    table.ForeignKey(
                        name: "FK__ДолгиПоДе__ID_по__68487DD7",
                        column: x => x.ID_пользователя,
                        principalTable: "Пользователи",
                        principalColumn: "ID_пользователя");
                    table.ForeignKey(
                        name: "FK__ДолгиПоДе__ID_пр__693CA210",
                        column: x => x.ID_пропущенного_дежурства,
                        principalTable: "РасписаниеДежурств",
                        principalColumn: "ID_расписания");
                });

            migrationBuilder.CreateTable(
                name: "ЗапросыНаЗамену",
                columns: table => new
                {
                    ID_запроса = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_запрашивающего = table.Column<int>(type: "int", nullable: false),
                    ID_заменяющего = table.Column<int>(type: "int", nullable: false),
                    ID_дежурства = table.Column<int>(type: "int", nullable: false),
                    Новая_дата = table.Column<DateOnly>(type: "date", nullable: true),
                    Статус = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "ожидание"),
                    Комментарий_запроса = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Комментарий_ответа = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Одобрил = table.Column<int>(type: "int", nullable: true),
                    Дата_создания = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    Дата_обновления = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ЗапросыН__01448438A41999EF", x => x.ID_запроса);
                    table.ForeignKey(
                        name: "FK__ЗапросыНа__ID_де__619B8048",
                        column: x => x.ID_дежурства,
                        principalTable: "РасписаниеДежурств",
                        principalColumn: "ID_расписания");
                    table.ForeignKey(
                        name: "FK__ЗапросыНа__ID_за__5FB337D6",
                        column: x => x.ID_запрашивающего,
                        principalTable: "Пользователи",
                        principalColumn: "ID_пользователя");
                    table.ForeignKey(
                        name: "FK__ЗапросыНа__ID_за__60A75C0F",
                        column: x => x.ID_заменяющего,
                        principalTable: "Пользователи",
                        principalColumn: "ID_пользователя");
                    table.ForeignKey(
                        name: "FK__ЗапросыНа__Одобр__6383C8BA",
                        column: x => x.Одобрил,
                        principalTable: "Пользователи",
                        principalColumn: "ID_пользователя");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ДолгиПоДежурствам_ID_отработочного_дежурства",
                table: "ДолгиПоДежурствам",
                column: "ID_отработочного_дежурства");

            migrationBuilder.CreateIndex(
                name: "IX_ДолгиПоДежурствам_ID_пользователя",
                table: "ДолгиПоДежурствам",
                column: "ID_пользователя");

            migrationBuilder.CreateIndex(
                name: "IX_ДолгиПоДежурствам_ID_пропущенного_дежурства",
                table: "ДолгиПоДежурствам",
                column: "ID_пропущенного_дежурства");

            migrationBuilder.CreateIndex(
                name: "IX_ЗапросыНаЗамену_Одобрил",
                table: "ЗапросыНаЗамену",
                column: "Одобрил");

            migrationBuilder.CreateIndex(
                name: "IX_ЗапросыНаЗамену_ID_дежурства",
                table: "ЗапросыНаЗамену",
                column: "ID_дежурства");

            migrationBuilder.CreateIndex(
                name: "IX_ЗапросыНаЗамену_ID_заменяющего",
                table: "ЗапросыНаЗамену",
                column: "ID_заменяющего");

            migrationBuilder.CreateIndex(
                name: "IX_ЗапросыНаЗамену_ID_запрашивающего",
                table: "ЗапросыНаЗамену",
                column: "ID_запрашивающего");

            migrationBuilder.CreateIndex(
                name: "IX_НазначенияРолей_Назначил",
                table: "НазначенияРолей",
                column: "Назначил");

            migrationBuilder.CreateIndex(
                name: "IX_НазначенияРолей_ID_пользователя",
                table: "НазначенияРолей",
                column: "ID_пользователя");

            migrationBuilder.CreateIndex(
                name: "IX_НазначенияРолей_ID_роли",
                table: "НазначенияРолей",
                column: "ID_роли");

            migrationBuilder.CreateIndex(
                name: "UQ__Пользова__A9D105347D5A58FC",
                table: "Пользователи",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Пользова__BC2217D3375C02AA",
                table: "Пользователи",
                column: "Логин",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Пропуски_Отметил",
                table: "Пропуски",
                column: "Отметил");

            migrationBuilder.CreateIndex(
                name: "IX_Пропуски_ID_группы",
                table: "Пропуски",
                column: "ID_группы");

            migrationBuilder.CreateIndex(
                name: "IX_Пропуски_ID_пользователя",
                table: "Пропуски",
                column: "ID_пользователя");

            migrationBuilder.CreateIndex(
                name: "IX_РасписаниеДежурств_Создал",
                table: "РасписаниеДежурств",
                column: "Создал");

            migrationBuilder.CreateIndex(
                name: "IX_РасписаниеДежурств_ID_группы",
                table: "РасписаниеДежурств",
                column: "ID_группы");

            migrationBuilder.CreateIndex(
                name: "IX_РасписаниеДежурств_ID_дежурного",
                table: "РасписаниеДежурств",
                column: "ID_дежурного");

            migrationBuilder.CreateIndex(
                name: "UQ__Роли__927FA07BDADF8E5A",
                table: "Роли",
                column: "Название_роли",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Уведомления_ID_пользователя",
                table: "Уведомления",
                column: "ID_пользователя");

            migrationBuilder.CreateIndex(
                name: "UQ__УчебныеГ__913C6830AB51EB2E",
                table: "УчебныеГруппы",
                column: "Название_группы",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ЧленствоВГруппах_ID_группы",
                table: "ЧленствоВГруппах",
                column: "ID_группы");

            migrationBuilder.CreateIndex(
                name: "IX_ЧленствоВГруппах_ID_пользователя",
                table: "ЧленствоВГруппах",
                column: "ID_пользователя");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ДолгиПоДежурствам");

            migrationBuilder.DropTable(
                name: "ЗапросыНаЗамену");

            migrationBuilder.DropTable(
                name: "НазначенияРолей");

            migrationBuilder.DropTable(
                name: "Пропуски");

            migrationBuilder.DropTable(
                name: "Уведомления");

            migrationBuilder.DropTable(
                name: "ЧленствоВГруппах");

            migrationBuilder.DropTable(
                name: "РасписаниеДежурств");

            migrationBuilder.DropTable(
                name: "Роли");

            migrationBuilder.DropTable(
                name: "УчебныеГруппы");

            migrationBuilder.DropTable(
                name: "Пользователи");
        }
    }
}
