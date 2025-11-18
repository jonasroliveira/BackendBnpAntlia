using BackendBnpAntlia.DTOs;

namespace BackendBnpAntlia.Interfaces;

public interface IMovimentoManualService
{
    Task<IEnumerable<MovimentoManualGetDto>> ObterMovimentosManuais();
    Task PostMovimentoManual(MovimentoManualPostDto dto);
}