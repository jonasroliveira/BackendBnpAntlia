using BackendBnpAntlia.DTOs;
using BackendBnpAntlia.Interfaces;

namespace BackendBnpAntlia.Services;

public class ProdutoCosifService : IProdutoCosifService
{
    private readonly IProdutoCosifRepository _produtoCosifRepository;

    public ProdutoCosifService(IProdutoCosifRepository produtoCosifRepository)
    {
        _produtoCosifRepository = produtoCosifRepository;
    }

    public Task<IEnumerable<ProdutoCosifDto>> ObterCosifs() => _produtoCosifRepository.ObterCosifs();
}