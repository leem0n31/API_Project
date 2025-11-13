using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts.DutyDebt;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DutyDebtController : ControllerBase
    {
        private IDutyDebtService _dutyDebtService;
        public DutyDebtController(IDutyDebtService dutyDebtService)
        {
            _dutyDebtService = dutyDebtService;
        }

        /// <summary>
        /// Получение списка всех долгов по дежурствам
        /// </summary>
        /// <returns>Список долгов по дежурствам</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dutyDebts = await _dutyDebtService.GetAll();
            var response = dutyDebts.Adapt<List<GetDutyDebtResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение долга по дежурству по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор долга по дежурству</param>
        /// <returns>Данные долга по дежурству</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _dutyDebtService.GetById(id);
            if (result == null)
                return NotFound();
            var response = result.Adapt<GetDutyDebtResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового долга по дежурству
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /DutyDebt
        ///     {
        ///        "id_пользователя" : 1,
        ///        "id_пропущенного_дежурства" : 5,
        ///        "статус" : "ожидание",
        ///        "новая_дата" : "2024-01-20"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Долг по дежурству</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateDutyDebtRequest request)
        {
            var dutyDebtDto = request.Adapt<ДолгиПоДежурствам>();
            await _dutyDebtService.Create(dutyDebtDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных долга по дежурству
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /DutyDebt
        ///     {
        ///        "id_долга" : 1,
        ///        "id_пользователя" : 1,
        ///        "id_пропущенного_дежурства" : 5,
        ///        "статус" : "отработано",
        ///        "новая_дата" : "2024-01-20",
        ///        "id_отработочного_дежурства" : 8,
        ///        "дата_закрытия" : "2024-01-20T18:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Долг по дежурству</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateDutyDebtRequest request)
        {
            var dutyDebtDto = new ДолгиПоДежурствам
            {
                IdДолга = request.IdДолга,
                IdПользователя = request.IdПользователя,
                IdПропущенногоДежурства = request.IdПропущенногоДежурства,
                Статус = request.Статус,
                НоваяДата = request.НоваяДата,
                IdОтработочногоДежурства = request.IdОтработочногоДежурства,
               
            };
            await _dutyDebtService.Update(dutyDebtDto);
            return Ok();
        }

        /// <summary>
        /// Удаление долга по дежурству
        /// </summary>
        /// <param name="id">Идентификатор долга по дежурству</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _dutyDebtService.Delete(id);
            return Ok();
        }
    }
}