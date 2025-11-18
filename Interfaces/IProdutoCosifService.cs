using BackendBnpAntlia.DTOs;

namespace BackendBnpAntlia.Interfaces;

public interface IProdutoCosifService
{
    Task<IEnumerable<ProdutoCosifDto>> ObterCosifs();
}