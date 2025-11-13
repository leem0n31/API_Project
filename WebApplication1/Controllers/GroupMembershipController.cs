using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts.GroupMembership;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMembershipController : ControllerBase
    {
        private IGroupMembershipService _groupMembershipService;
        public GroupMembershipController(IGroupMembershipService groupMembershipService)
        {
            _groupMembershipService = groupMembershipService;
        }

        /// <summary>
        /// Получение списка всех членств в группах
        /// </summary>
        /// <returns>Список членств в группах</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var groupMemberships = await _groupMembershipService.GetAll();
            var response = groupMemberships.Adapt<List<GetGroupMembershipResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение членства в группе по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор членства в группе</param>
        /// <returns>Данные членства в группе</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _groupMembershipService.GetById(id);
            if (result == null)
                return NotFound();
            var response = result.Adapt<GetGroupMembershipResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового членства в группе
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /GroupMembership
        ///     {
        ///        "id_пользователя" : 1,
        ///        "id_группы" : 2,
        ///        "активен" : true
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Членство в группе</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateGroupMembershipRequest request)
        {
            var groupMembershipDto = request.Adapt<ЧленствоВгруппах>();
            await _groupMembershipService.Create(groupMembershipDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных членства в группе
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /GroupMembership
        ///     {
        ///        "id_членства" : 1,
        ///        "id_пользователя" : 1,
        ///        "id_группы" : 2,
        ///        "активен" : false
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Членство в группе</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateGroupMembershipRequest request)
        {
            var groupMembershipDto = new ЧленствоВгруппах
            {
                IdЧленства = request.IdЧленства,
                IdПользователя = request.IdПользователя,
                IdГруппы = request.IdГруппы,
                Активен = request.Активен
            };
            await _groupMembershipService.Update(groupMembershipDto);
            return Ok();
        }

        /// <summary>
        /// Удаление членства в группе
        /// </summary>
        /// <param name="id">Идентификатор членства в группе</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupMembershipService.Delete(id);
            return Ok();
        }
    }
}