using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using PptkNew.Repositories;

namespace PptkNew.Controllers.api;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class SubKegiatanApiController : ControllerBase
{
    private ISubKegiatan repo;

    public SubKegiatanApiController(ISubKegiatan sRepo) => repo = sRepo;

    [HttpPost("/api/master/subkegiatan/list")]
    public async Task<IActionResult> SubKegiatanList()
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

        var init = repo.SubKegiatans
            .Select(x => new
            {
                SubKegiatanId = x.SubKegiatanId,
                KodeSubKegiatan = x.KodeSubKegiatan,
                NamaSubKegiatan = x.NamaSubKegiatan,
                NamaKegiatan = x.Kegiatan.NamaKegiatan
            });

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.NamaSubKegiatan.ToLower().Contains(searchValue.ToLower()) ||
                a.KodeSubKegiatan.ToLower().Contains(searchValue.ToLower())
            );
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal, data = result };

        return Ok(jsonData);
    }
}
