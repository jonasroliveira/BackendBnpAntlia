using BackendBnpAntlia.DTOs;

namespace BackendBnpAntlia.Interfaces;
public interface IProdutoRepository
{
    Task<IEnumerable<ProdutoDto>> ObterProdutos();
}