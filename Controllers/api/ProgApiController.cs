﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PptkNew.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace PptkNew.Controllers.api;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProgApiController : ControllerBase
{
    private IProg repo;

    public ProgApiController(IProg repo)
    {
        this.repo = repo;
    }

    [HttpPost("/api/master/program/list")]
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

        var init = repo.Progs;

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.NamaProgram.ToLower().Contains(searchValue.ToLower()) || 
                a.KodeProgram.ToLower().Contains(searchValue.ToLower())
            );
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal, data = result };

        return Ok(jsonData);
    }

    [HttpGet("/api/master/program/search")]
    public async Task<IActionResult> SearchProgram(string? term)
    {
        var data = await repo.Progs
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaProgram.ToLower().Contains(term.ToLower()) || k.KodeProgram.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.ProgramId,
                namaProgram = s.KodeProgram + " - " + s.NamaProgram
            }).Take(10).ToListAsync();

        return Ok(data);
    }
}
