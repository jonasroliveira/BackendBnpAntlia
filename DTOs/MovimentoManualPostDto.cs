namespace BackendBnpAntlia.DTOs;

public class MovimentoManualPostDto
{
    public int Mes { get; set; }
    public int Ano { get; set; }    
    public string CodigoProduto { get; set; } = string.Empty;
    public string CodigoCosif { get; set; } = string.Empty;
    public string DescricaoProduto { get; set; } = string.Empty;
    public DateTime DtMovimento { get; set; }
    public string CodigoUsuario { get; set; } = string.Empty;
    public decimal Valor { get; set; }
}