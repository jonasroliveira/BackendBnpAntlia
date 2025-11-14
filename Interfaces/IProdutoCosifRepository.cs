using BackendBnpAntlia.DTOs;

namespace BackendBnpAntlia.Interfaces;

public interface IProdutoCosifRepository
{
    Task<IEnumerable<ProdutoCosifDto>> ObterCosifs();
}