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

        return View(new IndexVM { 
            TransKegiatans = transKegiatans
        });
    }

    [HttpGet("/transaksi/master/create")]
    public IActionResult CreateMasterTrans()
    {
        return PartialView();
    }

    [HttpPost("/transaksi/master/store")]
    public async Task<IActionResult> CreateMasterTrans(TransKegiatan trans)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveDataAsync(trans);
            return Json(Result.Success());
        }

        return PartialView(trans);
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
            TransDetails = new TransDetails
            {
                TransDetailId = Guid.NewGuid()
            }
        });
    }

    [HttpGet("/transaksi/detail/edit")]
    public async Task<IActionResult> EditDetail(Guid id)
    {
        TransDetails? data = await details.TransDetails
            .Include(r => r.Rekening)
            .FirstOrDefaultAsync(t => t.TransDetailId == id);

        if (data is not null)
        {
            return PartialView(new EditDetailVM
            {
                TransDetail = data,
                TransKegiatanId = data.TransKegiatanId,
                NamaRekening = data.Rekening.KodeRekening + " - " + data.Rekening.NamaRekening
            });
        }

        return NotFound();
    }

    [HttpPost("/transaksi/detail/edit")]
    public async Task<IActionResult> EditDetail(EditDetailVM model)
    {
        if (ModelState.IsValid)
        {
            await details.UpdateDataAsync(model.TransDetail);

            return Json(Result.Success());
        }

        return PartialView(model);
    }

    [HttpPost("/transaksi/detail/store")]
    public async Task<IActionResult> StoreDetails(DetailVM model) 
    {
        if (ModelState.IsValid)
        {
            model.TransDetails!.TransDetailId = Guid.NewGuid();

            await details.SaveDataAsync(model.TransDetails!);

            return Json(Result.Success());
        }

        return Json(Result.Failed());
    }

    [HttpPost("/transaksi/detail/kontrak/store")]
    public async Task<IActionResult> StoreKontrak(DetailVM model)
    {
        model.Kontrak!.KontrakId = Guid.NewGuid();

        if (ModelState.IsValid)
        {
            await details.SaveKontrakAsync(model.Kontrak);

            return Json(Result.Success());
        }

        return Json(Result.Failed());
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
