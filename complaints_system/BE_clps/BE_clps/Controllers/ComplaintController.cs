using BE_clps.Models;
using BE_clps.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_clps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        #region repos
        private readonly ComplaintRepository _repos;

        public ComplaintController(ComplaintRepository repos)
        {
            _repos = repos;
        }
        #endregion

        [HttpPost("insert")]
        public IActionResult Create(Complaint entity)
        {
            if (_repos.Create(entity))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            return Ok(_repos.GetAll());
        }

        [HttpGet("get_by_code/{code}")]
        public IActionResult GetByCode(string code)
        {
            Complaint? cpl = _repos.GetByCode(code);
            if (cpl is not null)
                return Ok(cpl);

            return NotFound();
        }

        //TO DO
        [HttpPut("update_by_code/{code}")]
        public IActionResult UpdateByCode(string code, Complaint entity)
        {
            if (_repos.UpdateByCode(code, entity))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("delete_by_code/{code}")]
        public IActionResult Delete(string code)
        {
            if (_repos.DeleteByCode(code))
                return Ok();

            return BadRequest();
        }

    }
}
