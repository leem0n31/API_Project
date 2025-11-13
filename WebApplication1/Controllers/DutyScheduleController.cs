using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts.DutySchedule;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DutyScheduleController : ControllerBase
    {
        private IDutyScheduleService _dutyScheduleService;
        public DutyScheduleController(IDutyScheduleService dutyScheduleService)
        {
            _dutyScheduleService = dutyScheduleService;
        }

        /// <summary>
        /// Получение списка всех расписаний дежурств
        /// </summary>
        /// <returns>Список расписаний дежурств</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dutySchedules = await _dutyScheduleService.GetAll();
            var response = dutySchedules.Adapt<List<GetDutyScheduleResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение расписания дежурства по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор расписания дежурства</param>
        /// <returns>Данные расписания дежурства</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _dutyScheduleService.GetById(id);
            if (result == null)
                return NotFound();
            var response = result.Adapt<GetDutyScheduleResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового расписания дежурства
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /DutySchedule
        ///     {
        ///        "id_группы" : 1,
        ///        "дата_дежурства" : "2024-01-15",
        ///        "id_дежурного" : 2,
        ///        "статус" : "запланировано",
        ///        "создал" : 3
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Расписание дежурства</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateDutyScheduleRequest request)
        {
            var dutyScheduleDto = request.Adapt<РасписаниеДежурств>();
            await _dutyScheduleService.Create(dutyScheduleDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных расписания дежурства
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /DutySchedule
        ///     {
        ///        "id_расписания" : 1,
        ///        "id_группы" : 1,
        ///        "дата_дежурства" : "2024-01-15",
        ///        "id_дежурного" : 4,
        ///        "статус" : "выполнено",
        ///        "создал" : 3
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Расписание дежурства</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateDutyScheduleRequest request)
        {
            var dutyScheduleDto = new РасписаниеДежурств
            {
                IdРасписания = request.IdРасписания,
                IdГруппы = request.IdГруппы,
                ДатаДежурства = request.ДатаДежурства,
                IdДежурного = request.IdДежурного,
                Статус = request.Статус,
                Создал = request.Создал
            };
            await _dutyScheduleService.Update(dutyScheduleDto);
            return Ok();
        }

        /// <summary>
        /// Удаление расписания дежурства
        /// </summary>
        /// <param name="id">Идентификатор расписания дежурства</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _dutyScheduleService.Delete(id);
            return Ok();
        }
    }
}