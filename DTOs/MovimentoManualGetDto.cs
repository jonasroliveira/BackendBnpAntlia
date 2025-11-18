namespace BackendBnpAntlia.DTOs;

public class MovimentoManualGetDto
{
    public int Mes { get; set; }
    public int Ano { get; set; }
    public string CodigoProduto { get; set; } = string.Empty;
    public string DescricaoProduto { get; set; } = string.Empty;
    public long NumeroLancamento { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
}