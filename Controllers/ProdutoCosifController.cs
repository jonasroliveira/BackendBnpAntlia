using Microsoft.AspNetCore.Mvc;
using BackendBnpAntlia.Interfaces;

namespace BackendBnpAntlia.Controllers;

[ApiController]
[Route("api/produtos-cosif")]
public class ProdutoCosifController : ControllerBase
{
    private readonly IProdutoCosifService _produtoCosifService;

    public ProdutoCosifController(IProdutoCosifService produtoCosifService)
    {
        _produtoCosifService = produtoCosifService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCosifs()
    {
        var cosifs = await _produtoCosifService.ObterCosifs();
        return Ok(cosifs);
    }
}