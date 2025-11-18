using BackendBnpAntlia.DTOs;

namespace BackendBnpAntlia.Interfaces;
public interface IProdutoService
{
    Task<IEnumerable<ProdutoDto>> ObterProdutos();
}