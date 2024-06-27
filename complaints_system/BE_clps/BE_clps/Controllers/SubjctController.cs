using BE_clps.Models;
using BE_clps.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_clps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjctController : ControllerBase
    {
        #region repos
        private readonly SubjctRepository _repos;

        public SubjctController(SubjctRepository repos)
        {
            _repos = repos;
        }
        #endregion

        [HttpPost("insert")]
        public IActionResult Create(Subjct entity)
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

        [HttpGet("get_by_doc_number/{code}")]
        public IActionResult GetByCode(string code)
        {
            Subjct? cnant = _repos.GetByCode(code);
            if (cnant is not null)
                return Ok(cnant);

            return NotFound();
        }

        [HttpPut("update_by_doc_number/{code}")]
        public IActionResult UpdateByCode(string code, Subjct entity)
        {
            if (_repos.UpdateByCode(code, entity))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("delete_by_doc_number/{code}")]
        public IActionResult Delete(string code)
        {
            if (_repos.DeleteByCode(code))
                return Ok();

            return BadRequest();
        }
    }
}
