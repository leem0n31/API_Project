using Azure.Core;
using BusinessLogic.Services;
using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts.StudyGroup;
using WebApplication1.Contracts.User;


namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyGroupController : ControllerBase
    {
        private IStudyGroupService _studyGroupService;
        public StudyGroupController(IStudyGroupService studyGroupService)
        {
            _studyGroupService = studyGroupService;
        }

        /// <summary>
        /// Получение списка всех учебных групп
        /// </summary>
        /// <returns>Список учебных групп</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var studygroup = await _studyGroupService.GetAll();
            var response = studygroup.Adapt<List<GetStudyGroupResponse>>();
            return Ok(response);
        }

        /// <summary>
        /// Получение учебной группы по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор учебной группы</param>
        /// <returns>Данные учебной группы</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _studyGroupService.GetById(id);
            if (result == null)
                return NotFound();
            var response = result.Adapt<GetStudyGroupResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание новой учебной группы
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /StudyGroup
        ///     {
        ///        "название_группы" : "ИТ-21",
        ///        "курс" : 2,
        ///        "факультет" : "Информационные технологии"
        ///     }
        ///
        /// </remarks>
        /// <param name="studyGroup">Учебная группа</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateStudyGroupRequest request)
        {
            var studygroupDto = request.Adapt<УчебныеГруппы>();
            await _studyGroupService.Create(studygroupDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных учебной группы
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /StudyGroup
        ///     {
        ///        "id_группы" : 1,
        ///        "название_группы" : "ИТ-21",
        ///        "курс" : 3,
        ///        "факультет" : "Информационные технологии и системы"
        ///     }
        ///
        /// </remarks>
        /// <param name="studyGroup">Учебная группа</param>
        /// <returns></returns>
       [HttpPut]
public async Task<IActionResult> Update(UpdateStudyGroupRequest request)
{
    var studygroupDto = new УчебныеГруппы
    {
        IdГруппы = request.IdГруппы,
        НазваниеГруппы = request.НазваниеГруппы,
        Курс = request.Курс,
        Факультет = request.Факультет
    };
    await _studyGroupService.Update(studygroupDto);
    return Ok();
}

        /// <summary>
        /// Удаление учебной группы
        /// </summary>
        /// <param name="id">Идентификатор учебной группы</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _studyGroupService.Delete(id);
            return Ok();
        }
    }
}