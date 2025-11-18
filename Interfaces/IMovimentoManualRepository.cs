using BackendBnpAntlia.DTOs;

namespace BackendBnpAntlia.Interfaces;

public interface IMovimentoManualRepository
{
    Task<IEnumerable<MovimentoManualGetDto>> ObterMovimentosManuais();

    Task PostMovimentoManual(MovimentoManualPostDto dto);
}