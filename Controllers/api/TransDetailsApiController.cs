using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PptkNew.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
namespace PptkNew.Controllers.api;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TransDetailsApiController : ControllerBase
{
    private readonly ITransDetails repo;

    public TransDetailsApiController(ITransDetails repo)
    {
        this.repo = repo;
    }

    [HttpPost("/api/transaksi/detail/list")]
    public async Task<IActionResult> TransDetailList(long trans)
    {
        var draw = Request.Form["draw"].FirstOrDefault();
        var start = Request.Form["start"].FirstOrDefault();
        var length = Request.Form["length"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();        
        int recordsTotal = 0;

        var init = repo.TransDetails
            .Where(t => t.TransKegiatanId == trans)
            .Select(x => new
            {
                TransDetailId = x.TransDetailId,
                KodeRekening = x.Rekening.KodeRekening,
                NamaRekening = x.Rekening.NamaRekening,
                Anggaran = x.Anggaran.ToString("#,###")
            });

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.KodeRekening.ToLower().Contains(searchValue.ToLower()) ||
                a.NamaRekening.ToLower().Contains(searchValue.ToLower())
            );
        }

        recordsTotal = init.Count();

        var result = await init.ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal, data = result };

        return Ok(jsonData);
    }

    [HttpGet("/api/transaksi/detail/sum")]
    public async Task<IActionResult> ComputeDetails(long id)
    {
        var data = await repo.TransDetails.Where(t => t.TransKegiatanId == id).ToListAsync();

        var result = new
        {
            total = data.Sum(e => e.Anggaran).ToString("#,###")
        };

        return Ok(result);
    }
}
