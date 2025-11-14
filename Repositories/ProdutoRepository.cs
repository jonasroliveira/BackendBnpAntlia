using BackendBnpAntlia.DTOs;
using BackendBnpAntlia.Interfaces;

namespace BackendBnpAntlia.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    public Task<IEnumerable<ProdutoDto>> ObterProdutos()
    {
        throw new NotImplementedException();
    }
}