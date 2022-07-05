using Microsoft.AspNetCore.Mvc;
using PptkNew.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace PptkNew.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RekeningApiController : ControllerBase
    {
        private readonly IRekening repo;

        public RekeningApiController(IRekening repo)
        {
            this.repo = repo;
        }

        [HttpPost("/api/master/rekening/list")]
        public async Task<IActionResult> RekeningList()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var init = repo.Rekenings;

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                init = init.OrderBy(sortColumn + " " + sortColumnDirection);
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                init = init.Where(a => a.NamaRekening.ToLower().Contains(searchValue.ToLower()) ||
                    a.KodeRekening.ToLower().Contains(searchValue.ToLower())
                );
            }

            recordsTotal = init.Count();

            var result = await init.Skip(skip).Take(pageSize).ToListAsync();

            var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal, data = result };

            return Ok(jsonData);
        }
    }
}
