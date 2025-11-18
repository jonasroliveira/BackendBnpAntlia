using Microsoft.Data.SqlClient;
using System.Data;
using BackendBnpAntlia.DTOs;
using BackendBnpAntlia.Interfaces;

namespace BackendBnpAntlia.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly string _connectionString;
    public ProdutoRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    public async Task<IEnumerable<ProdutoDto>> ObterProdutos()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var produtos = new List<ProdutoDto>();
            using (var command = new SqlCommand("sp_ObterProdutos", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        produtos.Add(new ProdutoDto
                        {
                            CodigoProduto = reader.GetString(reader.GetOrdinal("COD_PRODUTO")),
                            DescricaoProduto = reader.GetString(reader.GetOrdinal("DES_PRODUTO")),
                            Status = reader.GetString(reader.GetOrdinal("STA_STATUS"))
                        });
                    }
                }
            }
            return produtos;
        }
    }
}