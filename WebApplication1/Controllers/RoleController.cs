using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts.Role;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Получение списка всех ролей
        /// </summary>
        /// <returns>Список ролей</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetAll();
            var response = roles.Adapt<List<GetRoleResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение роли по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор роли</param>
        /// <returns>Данные роли</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _roleService.GetById(id);
            if (result == null)
                return NotFound();
            var response = result.Adapt<GetRoleResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание новой роли
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Role
        ///     {
        ///        "название_роли" : "Администратор",
        ///        "описание" : "Полный доступ ко всем функциям системы"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Данные для создания роли</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateRoleRequest request)
        {
            var roleDto = request.Adapt<Роли>();
            await _roleService.Create(roleDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных роли
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Role
        ///     {
        ///        "id_роли" : 1,
        ///        "название_роли" : "Администратор",
        ///        "описание" : "Полный доступ ко всем функциям системы с ограничениями"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Данные для обновления роли</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateRoleRequest request)
        {
            var roleDto = new Роли
            {
                IdРоли = request.IdРоли,
                НазваниеРоли = request.НазваниеРоли,
                Описание = request.Описание
            };
            await _roleService.Update(roleDto);
            return Ok();
        }

        /// <summary>
        /// Удаление роли
        /// </summary>
        /// <param name="id">Идентификатор роли</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleService.Delete(id);
            return Ok();
        }
    }
}