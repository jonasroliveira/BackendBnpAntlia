using BackendBnpAntlia.DTOs;
using BackendBnpAntlia.Interfaces;

namespace BackendBnpAntlia.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public Task<IEnumerable<ProdutoDto>> ObterProdutos() => _produtoRepository.ObterProdutos();
}