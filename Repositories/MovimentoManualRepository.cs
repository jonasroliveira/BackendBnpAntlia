using Microsoft.Data.SqlClient;
using System.Data;
using BackendBnpAntlia.DTOs;
using BackendBnpAntlia.Interfaces;

namespace BackendBnpAntlia.Repositories;

public class MovimentoManualRepository : IMovimentoManualRepository
{
    private readonly string _connectionString;

    public MovimentoManualRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<MovimentoManualGetDto>> ObterMovimentosManuais()
    {
        var movimentos = new List<MovimentoManualGetDto>();

        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand("sp_ObterMovimentos", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            await connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var movimento = new MovimentoManualGetDto
                    {
                        Mes = Convert.ToInt32(reader["Mes"]),
                        Ano = Convert.ToInt32(reader["Ano"]),
                        CodigoProduto = reader["CodigoProduto"].ToString()!,
                        DescricaoProduto = reader["DescricaoProduto"].ToString()!,
                        NumeroLancamento = Convert.ToInt32(reader["NumeroLancamento"]),
                        Descricao = reader["Descricao"].ToString()!,
                        Valor = Convert.ToDecimal(reader["Valor"])
                    };

                    movimentos.Add(movimento);
                }
            }
        }

        return movimentos;
    }


    public async Task PostMovimentoManual(MovimentoManualPostDto dto)
    {
        using var connection = new SqlConnection(_connectionString);

        var command = new SqlCommand("sp_InserirMovimentoManual", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.AddWithValue("@DAT_MES", dto.Mes);
        command.Parameters.AddWithValue("@DAT_ANO", dto.Ano);
        command.Parameters.AddWithValue("@COD_PRODUTO", dto.CodigoProduto);
        command.Parameters.AddWithValue("@COD_COSIF", dto.CodigoCosif);
        command.Parameters.AddWithValue("@DES_DESCRICAO", dto.DescricaoProduto);
        command.Parameters.AddWithValue("@DAT_MOVIMENTO", dto.DtMovimento);
        command.Parameters.AddWithValue("@COD_USUARIO", dto.CodigoUsuario);
        command.Parameters.AddWithValue("@VAL_VALOR", dto.Valor);

        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();
    }
}