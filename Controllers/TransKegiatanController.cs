using PptkNew.Entities;
using PptkNew.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PptkNew.Models.Transaksi;
using PptkNew.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace PptkNew.Controllers;

[Authorize]
public class TransKegiatanController : Controller
{
    private readonly ITransKegiatan repo;
    private readonly ITransDetails details;

    public TransKegiatanController(ITransKegiatan repo, ITransDetails details)
    {
        this.repo = repo;
        this.details = details;
    }

    [HttpGet("/transaksi/index")]
    public IActionResult Index(int? query)
    {
        int? curYear = query == null ? DateTime.Now.Year : query;
        IQueryable<TransKegiatan>? transKegiatans = repo.TransKegiatans
            .Where(t => t.Tahun == curYear)
            .Where(sk => sk.SkpdId == 1)
            .Include(s => s.SubKegiatan)
            .Include(k => k.SubKegiatan.Kegiatan)
            .Include(p => p.Prog)
            .Include(d => d.TransDetails);
        return View(new IndexVM { TransKegiatans = transKegiatans});
    }

    [HttpGet("/transaksi/master/create")]
    public IActionResult CreateMasterTrans()
    {
        return PartialView();
    }

    [HttpGet("/transaksi/detail")]
    public async Task<IActionResult> Detail(long? trans) {
        TransKegiatan? thisTrans = await repo.TransKegiatans
            .Include(p => p.Prog)
            .Include(sub => sub.SubKegiatan)
            .Include(k => k.SubKegiatan.Kegiatan)
            .Include(t => t.TransDetails)
            .FirstOrDefaultAsync(t => t.TransKegiatanId == trans);

        if (thisTrans is null)
        {
            return NotFound();
        }

        return View(new DetailVM
        {
            TransKegiatan = thisTrans,
            TransDetails = details.TransDetails.Where(t => t.TransKegiatanId == trans)
        });
    }

    [HttpGet("/transaksi/detail/create")]
    public IActionResult CreateDetail(long id)
    {
        return PartialView(new CreateDetailVM
        {
            TransDetail = new TransDetails
            {
                TransKegiatanId = id
            },
            TransKegiatanId = id
        });
    }

    [HttpPost("/transaksi/detail/store")]
    public async Task<IActionResult> StoreDetails(CreateDetailVM model) 
    {
        if (ModelState.IsValid)
        {
            await details.SaveDataAsync(model.TransDetail);

            return Json(Result.Success());
        }

        return PartialView(model);
    }

    [HttpPost("/transaksi/detail/delete")]
    public async Task<IActionResult> DeleteDetails(Guid? id)
    {
        TransDetails? trans = await details.TransDetails.FirstOrDefaultAsync(t => t.TransDetailId == id);

        if (trans is not null)
        {
            await details.DeleteDataAsync(id);

            return Ok(Result.Success());
        }

        return Ok(Result.Failed());
    }
}
