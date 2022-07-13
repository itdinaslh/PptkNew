using Microsoft.AspNetCore.Mvc;
using PptkNew.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace PptkNew.Controllers.api;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "SysAdmin")]
public class SkpdApiController : ControllerBase {
    private readonly ISkpd repo;

    public SkpdApiController(ISkpd repo) => this.repo = repo;

    [HttpGet("/api/administrator/skpd/search")]
    public async Task<IActionResult> SearchKegiatan(string? term)
    {
        var data = await repo.Skpds            
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.SkpdName.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.SkpdId,
                skpdName = s.SkpdCode + " - " + s.SkpdName
            }).Take(10).ToListAsync();

        return Ok(data);
    }
}