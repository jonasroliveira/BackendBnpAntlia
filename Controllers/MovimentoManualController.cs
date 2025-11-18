using Microsoft.AspNetCore.Mvc;
using BackendBnpAntlia.Interfaces;
using BackendBnpAntlia.DTOs;

namespace BackendBnpAntlia.Controllers;

[ApiController]
[Route("api/movimentos-manuais")]

public class MovimentoManualController : ControllerBase
{
    private readonly IMovimentoManualService _movimentoManualService;

    public MovimentoManualController(IMovimentoManualService movimentoManualService)
    {
        _movimentoManualService = movimentoManualService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMovimentosManuais()
    {
        var movimentosManuais = await _movimentoManualService.ObterMovimentosManuais();
        return Ok(movimentosManuais);
    }
    [HttpPost]
    public async Task<IActionResult> InserirMovimentoManual([FromBody] MovimentoManualPostDto dto)
    {
        await _movimentoManualService.PostMovimentoManual(dto);
        return Ok();
    }
}