using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts.Notification;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        /// <summary>
        /// Получение списка всех уведомлений
        /// </summary>
        /// <returns>Список уведомлений</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notifications = await _notificationService.GetAll();
            var response = notifications.Adapt<List<GetNotificationResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение уведомления по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор уведомления</param>
        /// <returns>Данные уведомления</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _notificationService.GetById(id);
            if (result == null)
                return NotFound();
            var response = result.Adapt<GetNotificationResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового уведомления
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Notification
        ///     {
        ///        "id_пользователя" : 1,
        ///        "тип_уведомления" : "Замена дежурства",
        ///        "заголовок" : "Запрос на замену дежурства",
        ///        "сообщение" : "Вам поступил запрос на замену дежурства от пользователя Иванов",
        ///        "прочитано" : false,
        ///        "дата_отправки" : "2024-01-15T10:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Уведомление</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateNotificationRequest request)
        {
            var notificationDto = request.Adapt<Уведомления>();
            await _notificationService.Create(notificationDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных уведомления
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Notification
        ///     {
        ///        "id_уведомления" : 1,
        ///        "id_пользователя" : 1,
        ///        "тип_уведомления" : "Замена дежурства",
        ///        "заголовок" : "Запрос на замену дежурства",
        ///        "сообщение" : "Вам поступил запрос на замену дежурства от пользователя Иванов",
        ///        "прочитано" : true,
        ///        "дата_отправки" : "2024-01-15T10:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Уведомление</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateNotificationRequest request)
        {
            var notificationDto = new Уведомления
            {
                IdУведомления = request.IdУведомления,
                IdПользователя = request.IdПользователя,
                ТипУведомления = request.ТипУведомления,
                Заголовок = request.Заголовок,
                Сообщение = request.Сообщение,
                Прочитано = request.Прочитано,
             
            };
            await _notificationService.Update(notificationDto);
            return Ok();
        }

        /// <summary>
        /// Удаление уведомления
        /// </summary>
        /// <param name="id">Идентификатор уведомления</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _notificationService.Delete(id);
            return Ok();
        }
    }
}