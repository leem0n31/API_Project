using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts.Absence;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceController : ControllerBase
    {
        private IAbsenceService _absenceService;
        public AbsenceController(IAbsenceService absenceService)
        {
            _absenceService = absenceService;
        }

        /// <summary>
        /// Получение списка всех пропусков
        /// </summary>
        /// <returns>Список пропусков</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var absences = await _absenceService.GetAll();
            var response = absences.Adapt<List<GetAbsenceResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение пропуска по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пропуска</param>
        /// <returns>Данные пропуска</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _absenceService.GetById(id);
            if (result == null)
                return NotFound();
            var response = result.Adapt<GetAbsenceResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пропуска
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Absence
        ///     {
        ///        "id_пользователя" : 1,
        ///        "id_группы" : 2,
        ///        "дата_пропуска" : "2024-01-15",
        ///        "причина" : "Болезнь",
        ///        "описание" : "Температура 38.5",
        ///        "уважительная" : true,
        ///        "отметил" : 3
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Пропуск</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateAbsenceRequest request)
        {
            var absenceDto = request.Adapt<Пропуски>();
            await _absenceService.Create(absenceDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных пропуска
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Absence
        ///     {
        ///        "id_пропуска" : 1,
        ///        "id_пользователя" : 1,
        ///        "id_группы" : 2,
        ///        "дата_пропуска" : "2024-01-15",
        ///        "причина" : "Болезнь",
        ///        "описание" : "Температура 38.5, справка от врача",
        ///        "уважительная" : true,
        ///        "отметил" : 3
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Пропуск</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAbsenceRequest request)
        {
            var absenceDto = new Пропуски
            {
                IdПропуска = request.IdПропуска,
                IdПользователя = request.IdПользователя,
                IdГруппы = request.IdГруппы,
                ДатаПропуска = request.ДатаПропуска,
                Причина = request.Причина,
                Описание = request.Описание,
                Уважительная = request.Уважительная,
                Отметил = request.Отметил
            };
            await _absenceService.Update(absenceDto);
            return Ok();
        }

        /// <summary>
        /// Удаление пропуска
        /// </summary>
        /// <param name="id">Идентификатор пропуска</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _absenceService.Delete(id);
            return Ok();
        }
    }
}