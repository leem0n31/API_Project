using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts.User;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Получение списка всех пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = await _userService.GetAll();
            var response = user.Adapt<List<GetUserResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Данные пользователя</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);
            if (result == null) 
                return NotFound();
            var response = result.Adapt<GetUserResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /User
        ///     {
        ///        "логин" : "ivanov123",
        ///        "пароль" : "!Pa$$word123@",
        ///        "email" : "ivanov@example.com",
        ///        "имя" : "Иван",
        ///        "фамилия" : "Иванов",
        ///        "телефон" : "+79991234567"
        ///     }
        ///
        /// </remarks>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = request.Adapt<Пользователи>();
            await _userService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /User
        ///     {
        ///        "id_пользователя" : 1,
        ///        "логин" : "ivanov123",
        ///        "пароль" : "NewPa$$word123!",
        ///        "email" : "ivanov_new@example.com",
        ///        "имя" : "Иван",
        ///        "фамилия" : "Иванов",
        ///        "телефон" : "+79991234568",
        ///        "активен" : true
        ///     }
        ///
        /// </remarks>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserRequest request)
        {
            var userDto = new Пользователи
            {
                IdПользователя = request.IdПользователя,
                Логин = request.Логин,
                Пароль = request.Пароль,
                Email = request.Email,
                Имя = request.Имя,
                Фамилия = request.Фамилия,
                Телефон = request.Телефон,
                
            };
            await _userService.Update(userDto);
            return Ok();
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}