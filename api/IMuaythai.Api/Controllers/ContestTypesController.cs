using System;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Dictionaries;
using IMuaythai.Repositories.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/dictionaries/")]
    public class ContestTypesController : Controller
    {
        private readonly IContestTypesRepository _repository;

        public ContestTypesController(IContestTypesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("types")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var typesEntities = await _repository.GetAll();
                var types = typesEntities.Select(i => (ContestTypeModel)i).ToList();
                return Ok(types);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("types/{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            try
            {
                var type = await _repository.Get(id) ?? new ContestType();
    
                return Ok((ContestTypeModel)type);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

        [HttpPost]
        [Route("types/save")]
        public async Task<IActionResult> Save([FromBody]ContestTypeModel type)
        {
            try
            {
                ContestType typeEntity = type.Id == 0 ? new ContestType() : await _repository.Get(type.Id);
                typeEntity.Id = type.Id;
                typeEntity.Name = type.Name;

                await _repository.Save(typeEntity);

                type.Id = typeEntity.Id;
                return Created("Add", type);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("types/remove")]
        public async Task<IActionResult> Remove([FromBody]ContestTypeModel type)
        {
            try
            {
                await _repository.Remove(type.Id);

                return Ok(type.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}