using BackendBnpAntlia.DTOs;
using BackendBnpAntlia.Interfaces;

namespace BackendBnpAntlia.Services;

public class MovimentoManualService : IMovimentoManualService
{
    private readonly IMovimentoManualRepository _movimentoManualRepository;

    public MovimentoManualService(IMovimentoManualRepository movimentoManualRepository)
    {
        _movimentoManualRepository = movimentoManualRepository;
    }

    public async Task<IEnumerable<MovimentoManualGetDto>> ObterMovimentosManuais() =>
        await _movimentoManualRepository.ObterMovimentosManuais();

    public async Task PostMovimentoManual(MovimentoManualPostDto dto)
    {
        if (dto.Mes <= 0 || dto.Mes > 12)
            throw new ArgumentException("O mês deve estar entre 1 e 12.");

        if (dto.Ano < 1000 || dto.Ano > 9999)
            throw new ArgumentException("O ano é obrigatório.");

        if (string.IsNullOrWhiteSpace(dto.CodigoProduto))
            throw new ArgumentException("O código do produto não pode ser vazio.");

        if (string.IsNullOrWhiteSpace(dto.CodigoCosif))
            throw new ArgumentException("O código COSIF não pode ser vazio.");

        if (string.IsNullOrWhiteSpace(dto.DescricaoProduto))
            throw new ArgumentException("A descrição é obrigatório.");

        if (dto.DtMovimento == DateTime.MinValue)
            throw new ArgumentException("A data do movimento é inválido.");

        if (string.IsNullOrWhiteSpace(dto.CodigoUsuario))
            throw new ArgumentException("O código do usuário é obrigatório.");

        if (dto.Valor <= 0)
            throw new ArgumentException("Valor deve ser maior que zero.");

        await _movimentoManualRepository.PostMovimentoManual(dto);
    }
}