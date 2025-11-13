using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts.RoleAssignment;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleAssignmentController : ControllerBase
    {
        private IRoleAssignmentService _roleAssignmentService;
        public RoleAssignmentController(IRoleAssignmentService roleAssignmentService)
        {
            _roleAssignmentService = roleAssignmentService;
        }

        /// <summary>
        /// Получение списка всех назначений ролей
        /// </summary>
        /// <returns>Список назначений ролей</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roleAssignments = await _roleAssignmentService.GetAll();
            var response = roleAssignments.Adapt<List<GetRoleAssignmentResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение назначения роли по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор назначения роли</param>
        /// <returns>Данные назначения роли</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _roleAssignmentService.GetById(id);
            if (result == null)
                return NotFound();
            var response = result.Adapt<GetRoleAssignmentResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового назначения роли
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /RoleAssignment
        ///     {
        ///        "id_пользователя" : 1,
        ///        "id_роли" : 2,
        ///        "назначил" : 3
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Данные для создания назначения роли</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateRoleAssignmentRequest request)
        {
            var roleAssignmentDto = request.Adapt<НазначенияРолей>();
            await _roleAssignmentService.Create(roleAssignmentDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных назначения роли
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /RoleAssignment
        ///     {
        ///        "id_назначения" : 1,
        ///        "id_пользователя" : 1,
        ///        "id_роли" : 3,
        ///        "назначил" : 4
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Данные для обновления назначения роли</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateRoleAssignmentRequest request)
        {
            var roleAssignmentDto = new НазначенияРолей
            {
                IdНазначения = request.IdНазначения,
                IdПользователя = request.IdПользователя,
                IdРоли = request.IdРоли,
                Назначил = request.Назначил
            };
            await _roleAssignmentService.Update(roleAssignmentDto);
            return Ok();
        }

        /// <summary>
        /// Удаление назначения роли
        /// </summary>
        /// <param name="id">Идентификатор назначения роли</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleAssignmentService.Delete(id);
            return Ok();
        }
    }
}