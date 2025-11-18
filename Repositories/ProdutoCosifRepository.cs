using Microsoft.Data.SqlClient;
using System.Data;
using BackendBnpAntlia.DTOs;
using BackendBnpAntlia.Interfaces;

namespace BackendBnpAntlia.Repositories;

public class ProdutoCosifRepository : IProdutoCosifRepository
{
    private readonly string _connectionString;
    public ProdutoCosifRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    public async Task<IEnumerable<ProdutoCosifDto>> ObterCosifs()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var cosifs = new List<ProdutoCosifDto>();
            using (var command = new SqlCommand("sp_ObterCosifs", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        cosifs.Add(new ProdutoCosifDto
                        {                            
                            CodigoProduto = reader.GetString(reader.GetOrdinal("COD_PRODUTO")),
                            CodigoCosif = reader.GetString(reader.GetOrdinal("COD_COSIF")),
                            Classificacao = reader.GetString(reader.GetOrdinal("COD_CLASSIFICACAO")),
                            Status = reader.GetString(reader.GetOrdinal("STA_STATUS"))
                        });
                    }
                }
            }
            return cosifs;
        }
    }
}