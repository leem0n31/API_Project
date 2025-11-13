using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts.ReplacementRequest;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplacementRequestController : ControllerBase
    {
        private IReplacementRequestService _replacementRequestService;
        public ReplacementRequestController(IReplacementRequestService replacementRequestService)
        {
            _replacementRequestService = replacementRequestService;
        }

        /// <summary>
        /// Получение списка всех запросов на замену
        /// </summary>
        /// <returns>Список запросов на замену</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var replacementRequests = await _replacementRequestService.GetAll();
            var response = replacementRequests.Adapt<List<GetReplacementRequestResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение запроса на замену по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор запроса на замену</param>
        /// <returns>Данные запроса на замену</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _replacementRequestService.GetById(id);
            if (result == null)
                return NotFound();
            var response = result.Adapt<GetReplacementRequestResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового запроса на замену
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /ReplacementRequest
        ///     {
        ///        "id_запрашивающего" : 1,
        ///        "id_заменяющего" : 2,
        ///        "id_дежурства" : 5,
        ///        "новая_дата" : "2024-01-15",
        ///        "статус" : "ожидание",
        ///        "комментарий_запроса" : "Прошу замены по семейным обстоятельствам"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Запрос на замену</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateReplacementRequestRequest request)
        {
            var replacementRequestDto = request.Adapt<ЗапросыНаЗамену>();
            await _replacementRequestService.Create(replacementRequestDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных запроса на замену
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /ReplacementRequest
        ///     {
        ///        "id_запроса" : 1,
        ///        "id_запрашивающего" : 1,
        ///        "id_заменяющего" : 2,
        ///        "id_дежурства" : 5,
        ///        "новая_дата" : "2024-01-15",
        ///        "статус" : "одобрено",
        ///        "комментарий_запроса" : "Прошу замены по семейным обстоятельствам",
        ///        "комментарий_ответа" : "Замена согласована",
        ///        "одобрил" : 3
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Запрос на замену</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateReplacementRequestRequest request)
        {
            var replacementRequestDto = new ЗапросыНаЗамену
            {
                IdЗапроса = request.IdЗапроса,
                IdЗапрашивающего = request.IdЗапрашивающего,
                IdЗаменяющего = request.IdЗаменяющего,
                IdДежурства = request.IdДежурства,
                НоваяДата = request.НоваяДата,
                Статус = request.Статус,
                КомментарийЗапроса = request.КомментарийЗапроса,
                КомментарийОтвета = request.КомментарийОтвета,
                Одобрил = request.Одобрил
            };
            await _replacementRequestService.Update(replacementRequestDto);
            return Ok();
        }

        /// <summary>
        /// Удаление запроса на замену
        /// </summary>
        /// <param name="id">Идентификатор запроса на замену</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _replacementRequestService.Delete(id);
            return Ok();
        }
    }
}