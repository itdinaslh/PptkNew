using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PptkNew.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace PptkNew.Controllers.api;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class KegiatanApiController : ControllerBase
{
    private readonly IKegiatan repo;

    public KegiatanApiController(IKegiatan kegiatan) => repo = kegiatan;

    [HttpPost("/api/master/kegiatan/list")]
    public async Task<IActionResult> ProgramList()
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

        var init = repo.Kegiatans;

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.NamaKegiatan.ToLower().Contains(searchValue.ToLower()) ||
                a.KodeKegiatan.ToLower().Contains(searchValue.ToLower())
            );
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal, data = result };

        return Ok(jsonData);
    }

    [HttpGet("/api/master/kegiatan/search")]
    public async Task<IActionResult> SearchKegiatan(string? term)
    {
        var data = await repo.Kegiatans            
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaKegiatan.ToLower().Contains(term.ToLower()) || 
                k.KodeKegiatan.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.KegiatanId,
                namaKegiatan = s.KodeKegiatan + " - " + s.NamaKegiatan
            }).Take(10).ToListAsync();

        return Ok(data);
    }
}
