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
                            COD_PRODUTO = reader["COD_PRODUTO"] == DBNull.Value ? null : Convert.ToString(reader["COD_PRODUTO"]),
                            COD_COSIF = reader["COD_COSIF"] == DBNull.Value ? null : Convert.ToString(reader["COD_COSIF"]),
                            COD_CLASSIFICACAO = reader["COD_CLASSIFICACAO"] == DBNull.Value ? null : Convert.ToString(reader["COD_CLASSIFICACAO"]),
                            STA_STATUS = reader["STA_STATUS"] == DBNull.Value ? null : Convert.ToString(reader["STA_STATUS"])
                        });
                    }
                }
            }
            return cosifs;
        }
    }
}