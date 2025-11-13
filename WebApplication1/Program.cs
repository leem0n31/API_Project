using BusinessLogic.Services;
using DataAccess.Models;
using DataAccess.Wrapper;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Система управления дежурствами и посещаемостью",
                    Description = "Система позволяет старосте и его заместителю легко назначать дежурных, фиксировать пропуски студентов и гибко управлять изменениями, автоматически перенося absent-дежурных на следующие дни.",
                    Contact = new OpenApiContact
                    {
                        Name = "Связаться с поддержкой",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Проверить лицензию приложения",
                        Url = new Uri("https://example.com/license")
                    }
                });

                // Добавление XML-комментариев
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            builder.Services.AddDbContext<Proect1Context>(options => options.UseSqlServer("Server=DESKTOP-K6LFJKO;Database=proect1;User Id=sa;Password=12345;TrustServerCertificate=true;"));

            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAbsenceService, AbsenceService>();
            builder.Services.AddScoped<IDutyScheduleService, DutyScheduleService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<INotificationService, NotificationService>();
            builder.Services.AddScoped<IStudyGroupService, StudyGroupService>();
            builder.Services.AddScoped<IGroupMembershipService, GroupMembershipService>();
            builder.Services.AddScoped<IDutyDebtService, DutyDebtService>();
            builder.Services.AddScoped<IReplacementRequestService, ReplacementRequestService>();
            builder.Services.AddScoped<IRoleAssignmentService, RoleAssignmentService>();

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}