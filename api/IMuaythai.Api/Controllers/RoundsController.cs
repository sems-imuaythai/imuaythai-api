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
    public class RoundsController : Controller
    {
        private readonly IRoundsRepository _repository;
        public RoundsController(IRoundsRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("rounds")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var rounds = await _repository.GetAll();
                return Ok(rounds.Select(r=>(RoundModel)r).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("rounds/{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            try
            {
                var result = await _repository.Get(id) ?? new Round();
                return Ok((RoundModel)result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("rounds/save")]
        public async Task<IActionResult> Save([FromBody]RoundModel round)
        {
            try
            {
                Round roundEntity = round.Id == 0 ? new Round() : await _repository.Get(round.Id);
                roundEntity.Id = round.Id;
                roundEntity.Name = round.Name;
                roundEntity.Duration = round.Duration;
                roundEntity.BreakDuration = round.BreakDuration;
                roundEntity.RoundsCount = round.RoundsCount;
                await _repository.Save(roundEntity);

                round.Id = roundEntity.Id;

                return Created("Add", round);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("rounds/remove")]
        public async Task<IActionResult> Remove([FromBody]RoundModel round)
        {
            try
            {
                await _repository.Remove(round.Id);

                return Ok(round.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}