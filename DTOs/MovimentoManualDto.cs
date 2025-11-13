namespace BackendBnpAntlia.DTOs;

public class MovimentoManualDto
{
    public decimal DAT_MES { get; set; }
    public decimal DAT_ANO { get; set; }
    public decimal NUM_LANCAMENTO { get; set; }
    public string COD_PRODUTO { get; set; }
    public string COD_COSIF { get; set; }
    public string DES_DESCRICAO { get; set; }
    public DateTime DAT_MOVIMENTO { get; set; }
    public string COD_USUARIO { get; set; }
    public decimal VAL_VALOR { get; set; }
}