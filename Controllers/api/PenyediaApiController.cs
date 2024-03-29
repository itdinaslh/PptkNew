﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PptkNew.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace PptkNew.Controllers.api;

[Route("api/[controller]")]
[ApiController]
public class PenyediaApiController : ControllerBase
{
    private readonly IPenyedia repo;

    public PenyediaApiController(IPenyedia repo)
    {
        this.repo = repo;
    }

    [HttpPost("/api/master/penyedia/list")]
    public async Task<IActionResult> JenisPengadaanList()
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

        var init = repo.Penyedias;

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.NamaPenyedia.ToLower().Contains(searchValue.ToLower()));
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal, data = result };

        return Ok(jsonData);
    }

    [HttpGet("/api/master/penyedia/search")]
    public async Task<IActionResult> SearchProgram(string? term)
    {
        var data = await repo.Penyedias
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaPenyedia.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.PenyediaId,
                namaPenyedia = s.NamaPenyedia
            }).Take(10).ToListAsync();

        return Ok(data);
    }
}
